namespace Southport.Messaging.Phone.Twilio.Shared
{
    public class TwilioOptions
    {
        public const string Key = "Twilio";
        
        public string AccountSid { get; set; }
        public string ApiKey { get; set; }
        public string AuthToken { get; set; }
        public bool UseSandbox { get; set; }
        public string TestPhoneNumbers { get; set; }
        public string MessagingServiceSid { get; set; }
    }
}