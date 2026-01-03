using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Southport.Messaging.Phone.Core.Shared;
using Southport.Messaging.Phone.Twilio.Shared;
using Twilio.Rest.Lookups.V1;
using HttpClient = System.Net.Http.HttpClient;

namespace Southport.Messaging.Phone.Twilio.Verifier
{
    public class TwilioPhoneNumberVerifier : TwilioClientBase, ITwilioPhoneNumberVerifier
    {
        public TwilioPhoneNumberVerifier(HttpClient httpClient, string accountSid, string apiKey, string authToken, bool useSandbox) : base(httpClient, accountSid, apiKey, authToken, useSandbox)
        {
        }

        public TwilioPhoneNumberVerifier(HttpClient httpClient, IOptions<TwilioOptions> options) : base(httpClient, options.Value)
        {
        }


        public async Task<PhoneNumberResource> PhoneNumberLookupAsync(string phoneNumber, PhoneNumberLookupType type, string countryCode)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrEmpty(phoneNumber))
            {
                return null;
            }

            phoneNumber = PhoneHelper.NormalizePhoneNumber(phoneNumber);
            var types = new List<string>();
            switch (type)
            {
                case PhoneNumberLookupType.Carrier:
                    types.Add("carrier");
                    break;
                case PhoneNumberLookupType.CallerName:
                    types.Add("caller-name");
                    break;
                default:
                    types = null;
                    break;
            }

            var result = await PhoneNumberResource.FetchAsync(type: types, countryCode: countryCode, pathPhoneNumber: phoneNumber, client: _innerClient);
            return result;
        }

    }

    public enum PhoneNumberLookupType
    {
        Validate,
        Carrier,
        CallerName
    }
}