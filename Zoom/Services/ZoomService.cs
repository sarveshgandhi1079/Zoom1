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

namespace Zoom.Services
{
    public class ZoomService : IZoomService
    {
        private readonly IConfiguration _configuration;
        public ZoomService(IConfiguration configuration)
        {
            _configuration = configuration;
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
                   var logResult = await GetCallLogs(token,nextPageToken);
                    log.AddRange(logResult.call_logs);
                    nextPageToken = logResult.next_page_token;
                }
                while (nextPageToken != "");

                return log;

            }
            catch (Exception ex)
            {
                throw;
            }
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

        #endregion
    }
    public interface IZoomService
    {
        Task<List<Call_Logs>> GetCallLogs();
    }
}
