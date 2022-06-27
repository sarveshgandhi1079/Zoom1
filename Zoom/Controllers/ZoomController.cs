using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Zoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoomController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ZoomController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("ZoomRedirectUrl")]
        public async Task<IActionResult> ZoomRedirectUrl()
        {
            try
            {


                string url = _configuration.GetSection("Zoom").GetSection("AccessTokenUrl").Value;
                url = string.Format(url, _configuration.GetSection("Zoom").GetSection("AccountId").Value);
                Uri uri = new Uri(url);
                string authcode = string.Concat(_configuration.GetSection("Zoom").GetSection("ClientId").Value, ":", _configuration.GetSection("Zoom").GetSection("ClientSecret").Value);
                var bytes = Encoding.UTF8.GetBytes(authcode);
                authcode = Convert.ToBase64String(bytes);
                var data = "";
                string token;

                using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri))
                {
                    var httpClient = new HttpClient();
                    requestMessage.Headers.Authorization =
                        new AuthenticationHeaderValue("Basic", authcode);
                    var respone = await (await httpClient.SendAsync(requestMessage)).Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<TokenDetails>(respone);
                    token = responseData.access_token;
                }
                Uri uri1 = new Uri("https://api.zoom.us/v2/users/me/meetings");
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri1))
                {
                    var httpClient = new HttpClient();
                    requestMessage.Headers.Authorization =
                     new AuthenticationHeaderValue("Bearer", token);
                    var respone = await (await httpClient.SendAsync(requestMessage)).Content.ReadAsStringAsync();
                    data = respone;
                    //return respone;
                }
                    //var response= meeting(token);


                return Ok(data);
            }
            catch (Exception ex) 
            {
                throw ;
            }
        }
        private async Task<string> meeting(string token)
        {
            Uri uri = new Uri("https://api.zoom.us/v2/users/me/meetings");
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get,uri ))
            {
                var httpClient = new HttpClient();
                requestMessage.Headers.Authorization =
                 new AuthenticationHeaderValue("Bearer", token);
                var respone = await(await httpClient.SendAsync(requestMessage)).Content.ReadAsStringAsync();
                return respone;
            }
        }
    }
    public class TokenDetails
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
    }
    public class MeetingDetails
    {
        public int MyProperty { get; set; }
    }
}
