using System;

namespace Zoom.Model
{
    public class TokenDetails
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
    }

    public class Rootobject
    {
        public string next_page_token { get; set; }
        public int page_size { get; set; }
        public int total_records { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public Call_Logs[] call_logs { get; set; }
    }

    public class Call_Logs
    {
        public string id { get; set; }
        public string user_id { get; set; }
        public string call_type { get; set; }
        public string caller_number { get; set; }
        public int caller_number_type { get; set; }
        public string caller_number_source { get; set; }
        public string caller_name { get; set; }
        public string callee_number { get; set; }
        public int callee_number_type { get; set; }
        public string callee_name { get; set; }
        public string direction { get; set; }
        public int duration { get; set; }
        public string result { get; set; }
        public DateTime date_time { get; set; }
        public string path { get; set; }
        public bool has_recording { get; set; }
        public bool has_voicemail { get; set; }
        public string call_id { get; set; }
        public Owner owner { get; set; }
        public string caller_country_code { get; set; }
        public string caller_country_iso_code { get; set; }
        public string callee_did_number { get; set; }
        public string callee_country_code { get; set; }
        public string callee_country_iso_code { get; set; }
    }

    public class Owner
    {
        public string type { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public int? extension_number { get; set; }
    }

}
