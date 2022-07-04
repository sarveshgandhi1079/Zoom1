using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Zoom.Services;

namespace Zoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoomController : ControllerBase
    {
        private readonly IZoomService _zoomService;

        public ZoomController(IZoomService zoomService)
        {
            _zoomService = zoomService;
        }

        [HttpPost]
        [Route("GetCallLogs")]
        public async Task<IActionResult> GetCallLogs()
        {
            try
            {

                var call_Logs = await _zoomService.GetCallLogs();

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("CallLogs");
                    var currentRow = 1;
                    worksheet.Cell(currentRow, 1).Value = "Id";
                    worksheet.Cell(currentRow, 2).Value = "UserId";
                    worksheet.Cell(currentRow, 3).Value = "CallType";
                    worksheet.Cell(currentRow, 4).Value = "CallerNumber";
                    worksheet.Cell(currentRow, 5).Value = "CallerNumberType";
                    worksheet.Cell(currentRow, 6).Value = "CallerNumberSource";
                    worksheet.Cell(currentRow, 7).Value = "CallerName";
                    worksheet.Cell(currentRow, 8).Value = "CalleeNumber";
                    worksheet.Cell(currentRow, 9).Value = "CalleeNumberType";
                    worksheet.Cell(currentRow, 10).Value = "CalleeName";
                    worksheet.Cell(currentRow, 11).Value = "Direction";
                    worksheet.Cell(currentRow, 12).Value = "Duration";
                    worksheet.Cell(currentRow, 13).Value = "Result";
                    worksheet.Cell(currentRow, 14).Value = "DateTime";
                    worksheet.Cell(currentRow, 15).Value = "Path";
                    worksheet.Cell(currentRow, 16).Value = "HasRecording";
                    worksheet.Cell(currentRow, 17).Value = "HasVoiceMail";
                    worksheet.Cell(currentRow, 18).Value = "CallId";
                    worksheet.Cell(currentRow, 19).Value = "OwnerType";
                    worksheet.Cell(currentRow, 20).Value = "OwnerId";
                    worksheet.Cell(currentRow, 21).Value = "OwnerName";
                    worksheet.Cell(currentRow, 22).Value = "OwnerExtensionNumber";
                    worksheet.Cell(currentRow, 23).Value = "CallerCountryCode";
                    worksheet.Cell(currentRow, 24).Value = "CallerCountryISOCode";
                    worksheet.Cell(currentRow, 25).Value = "CalleeDidNumber";
                    worksheet.Cell(currentRow, 26).Value = "CalleeCountryCode";
                    worksheet.Cell(currentRow, 27).Value = "CalleeCountryISOCode";

                    foreach (var logs in call_Logs)
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = logs.id;
                        worksheet.Cell(currentRow, 2).Value = logs.user_id;
                        worksheet.Cell(currentRow, 3).Value = logs.call_type;
                        worksheet.Cell(currentRow, 4).Value = logs.caller_number;
                        worksheet.Cell(currentRow, 5).Value = logs.caller_number_type;
                        worksheet.Cell(currentRow, 6).Value = logs.caller_number_source;
                        worksheet.Cell(currentRow, 7).Value = logs.caller_name;
                        worksheet.Cell(currentRow, 8).Value = logs.callee_number;
                        worksheet.Cell(currentRow, 9).Value = logs.callee_number_type;
                        worksheet.Cell(currentRow, 10).Value = logs.callee_name;
                        worksheet.Cell(currentRow, 11).Value = logs.direction;
                        worksheet.Cell(currentRow, 12).Value = logs.duration;
                        worksheet.Cell(currentRow, 13).Value = logs.result;
                        worksheet.Cell(currentRow, 14).Value = logs.date_time;
                        worksheet.Cell(currentRow, 15).Value = logs.path;
                        worksheet.Cell(currentRow, 16).Value = logs.has_recording;
                        worksheet.Cell(currentRow, 17).Value = logs.has_voicemail;
                        worksheet.Cell(currentRow, 18).Value = logs.call_id;
                        worksheet.Cell(currentRow, 19).Value = logs.owner==null?" ":logs.owner.type;
                        worksheet.Cell(currentRow, 20).Value = logs.owner==null?" ":logs.owner.id ;
                        worksheet.Cell(currentRow, 21).Value = logs.owner == null ? " " : logs.owner.name;
                        worksheet.Cell(currentRow, 22).Value = logs.owner == null ? " " : logs.owner.extension_number;
                        worksheet.Cell(currentRow, 23).Value = logs.caller_country_code;
                        worksheet.Cell(currentRow, 24).Value = logs.caller_country_iso_code;
                        worksheet.Cell(currentRow, 25).Value = logs.callee_did_number;
                        worksheet.Cell(currentRow, 26).Value = logs.callee_country_code;
                        worksheet.Cell(currentRow, 27).Value = logs.callee_country_iso_code;
                    }


                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content,
                            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            "CallLog" + DateTime.Now.Ticks.ToString() + ".xlsx");

                    }
                }
            }
            catch (Exception ex) 
            {
                throw ;
            }
        }
       
    }
    
}
