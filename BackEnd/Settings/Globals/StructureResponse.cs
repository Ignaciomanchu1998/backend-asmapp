namespace BackEnd.Settings.Globals
{
    public class StructureResponse
    {
        public string? code { get; set; }
        public string? message { get; set; }
        public string? title { get; set; }
        public dynamic? data { get; set; }

        public void response(string code, string sms, string title, dynamic? data = null)
        {
            this.code = code;
            this.message = sms;
            this.title = title;
            this.data = data;
        }
    }
}
