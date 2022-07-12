using ClosedXML.Excel;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Zoom.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Zoom.DBContext;
using System.Linq;

namespace Zoom.Services
{
    public class ZoomService : IZoomService
    {
        private readonly IConfiguration _configuration;
        private readonly TS2Context _tS2Context;

        public ZoomService(IConfiguration configuration, TS2Context tS2Context)
        {
            _configuration = configuration;
            _tS2Context = tS2Context;
        }
        #region PublicMethod
        public async Task<List<Call_Logs>> GetCallLogs()
        {
            try
            {
                List<Call_Logs> log = new List<Call_Logs>();
                string nextPageToken = "";
                var token = await GetAccssToken();

                do
                {
                    var logResult = await GetCallLogs(token, nextPageToken);
                    log.AddRange(logResult.call_logs);
                    nextPageToken = logResult.next_page_token;
                }
                while (nextPageToken != "");


                var logdeatils = await GetLogDetails(log, token);


                foreach (var item in log)
                {
                    var timeUtc = item.date_time;
                    var easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                    item.date_time = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);


                    //if (  (item.result == "Auto Recorded" || item.result == "Call connected" || item.result == "Recorded"))
                    //{
                    if (item.direction == "outbound")
                    {
                        int a = item.callee_number.StartsWith("+") == true ? 2 : 0;
                        int b = item.callee_number.StartsWith("+") == true ? 1 : 0;
                        item.empOrCompContNo = item.callee_number.Remove(0, a);
                        item.empOrCompContNo1 = item.callee_number.Remove(0, b);
                        item.empOrCompContNoP = item.callee_number;
                        if (item.callee_number != "1000")
                        {
                            item.intEmpNo = item.caller_number;
                        }
                        else
                        {
                            item.intEmpNo = logdeatils.Where(x => x.id == item.id).Select(x => x.ext).FirstOrDefault();
                        }

                    }
                    else
                    {
                        int a = item.caller_number.StartsWith("+") == true ? 2 : 0;
                        int b = item.caller_number.StartsWith("+") == true ? 1 : 0;
                        item.empOrCompContNo = item.caller_number.Remove(0, a);
                        item.empOrCompContNo1 = item.caller_number.Remove(0, b);
                        item.empOrCompContNoP = item.caller_number;
                        if (item.callee_number != "1000")
                        {
                            item.intEmpNo = item.callee_number;
                        }
                        else
                        {
                            item.intEmpNo = logdeatils.Where(x => x.id == item.id).Select(x => x.ext).FirstOrDefault();
                        }
                    }
                    //}
                    //else
                    //{
                    //    item.empOrCompContNo = "abcd";
                    //    item.intEmpNo = "abcd";

                    //}
                }

                DateTime last = log.Select(x => x.date_time).FirstOrDefault();
                var idea = (from tc in _tS2Context.TblContacts
                            where tc.DeleteFlag == 0 && tc.ActDate <= last.AddMinutes(15) && tc.ActDate >= last.AddDays(-1).AddMinutes(-15)
                            select new Idea
                            {
                                actDate = tc.ActDate,
                                actId = tc.ActId,
                                compContNo = (from tcc in _tS2Context.TblCompanyContacts
                                              join tccp in _tS2Context.TblCompanyContactPhones
                                              on tcc.CompContId equals tccp.CompContId
                                              where tcc.ActiveFlag == 0 && tcc.DeleteFlag == 0 && tccp.ActiveFlag == 0 && tccp.DeleteFlag == 0 && tccp.Phone != null && tcc.CompContId == tc.CompContId
                                              select tccp.NPhone).SingleOrDefault(),
                                empNo = (from te in _tS2Context.TblEmployees
                                         join tep in _tS2Context.TblEmployeePhones
                                         on te.EmpId equals tep.EmpId
                                         where tep.ActiveFlag == 0 && tep.DeleteFlag == 0 && te.ActiveFlag == 0 && te.DeleteFlag == 0 && tep.Phone != null && te.EmpId == tc.EmpId
                                         select tep.NPhone).SingleOrDefault(),
                                intEmpNo = (from tie in _tS2Context.TblInternalEmployees1
                                            where tie.ActiveFlag == 0 && tie.DeleteFlag == 0 && tie.IntEmpId == tc.IntEmpId
                                            select tie.Phone).SingleOrDefault(),

                            }).ToList();

                foreach (var item in idea)
                {
                    if (!string.IsNullOrEmpty(item.intEmpNo) && !item.intEmpNo.EndsWith("____") && !item.intEmpNo.EndsWith("1000"))
                    {
                        var num = item.intEmpNo.Split("-");
                        int length = num.Length;
                        item.ext = num[length - 1];

                    }
                }


                foreach (var item in log)
                {
                    item.actId = idea.Where(x => (x.empNo == item.empOrCompContNo || x.compContNo == item.empOrCompContNo || x.empNo == item.empOrCompContNoP || x.compContNo == item.empOrCompContNoP || x.empNo == item.empOrCompContNo1 || x.compContNo == item.empOrCompContNo1) && x.ext == item.intEmpNo && x.actDate >= item.date_time.AddMinutes(-15) && x.actDate <= item.date_time.AddMinutes(15)).Select(x => x.actId).FirstOrDefault();
                }
                return log;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Call_Logs> GetReports()
        {

            return null;

        }
        #endregion

        #region PrivateMethod
        private async Task<string> GetAccssToken()
        {
            string url = _configuration.GetSection("Zoom").GetSection("AccessTokenUrl").Value;
            url = string.Format(url, _configuration.GetSection("Zoom").GetSection("AccountId1").Value);
            Uri uri = new Uri(url);
            string authcode = string.Concat(_configuration.GetSection("Zoom").GetSection("ClientId1").Value, ":", _configuration.GetSection("Zoom").GetSection("ClientSecret1").Value);
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Headers.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(authcode)));

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseStream = await response.Content.ReadAsStreamAsync();
            var authResult = await JsonSerializer.DeserializeAsync<TokenDetails>(responseStream);

            var token = authResult.access_token;
            return token;
        }

        private async Task<Rootobject> GetCallLogs(string token, string nextPageToken)
        {
            string url = _configuration.GetSection("Zoom").GetSection("CallLogUrl").Value;
            if (!string.IsNullOrEmpty(nextPageToken))
            {
                url = string.Concat(url, "&next_page_token=", nextPageToken);
            }
            Uri uri = new Uri(url);
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Authorization = new AuthenticationHeaderValue(
                "Bearer", token);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseStream = await response.Content.ReadAsStreamAsync();
            var logResult = await JsonSerializer.DeserializeAsync<Rootobject>(responseStream);

            return logResult;
        }
        private async Task<List<Call_Log_Details>> GetLogDetails(List<Call_Logs> callid, string token)
        {
            List<Call_Log_Details> logDetails = new List<Call_Log_Details>();
            foreach (var log in callid)
            {
                if (log.callee_name == "Main Auto Receptionist")
                {
                    string url = _configuration.GetSection("Zoom").GetSection("LogDetailsUrl").Value;
                    url = string.Concat(url, log.id);
                    Uri uri = new Uri(url);
                    HttpClient client = new HttpClient();
                    var request = new HttpRequestMessage(HttpMethod.Get, uri);
                    request.Headers.Authorization = new AuthenticationHeaderValue(
                        "Bearer", token);

                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    var responseStream = await response.Content.ReadAsStreamAsync();
                    var logResult = await JsonSerializer.DeserializeAsync<Call_Log_Details>(responseStream);
                    logResult.ext = logResult.log_details.Where(x => x.result == "Call connected").Select(x => x.forward_to.extension_number).FirstOrDefault();
                    logDetails.Add(logResult);


                }
            }
            return logDetails;
        }

        #endregion
    }
    public interface IZoomService
    {
        Task<List<Call_Logs>> GetCallLogs();
        List<Call_Logs> GetReports();
    }
}
