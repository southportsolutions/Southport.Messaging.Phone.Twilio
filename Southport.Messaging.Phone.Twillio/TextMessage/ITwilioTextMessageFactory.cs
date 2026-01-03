using System.Net.Http;
using Microsoft.Extensions.Options;
using Southport.Messaging.Phone.Twilio.Shared;

namespace Southport.Messaging.Phone.Twilio.TextMessage;

public interface ITwilioTextMessageFactory
{
    public TwilioTextMessage Create();
}

public class TwilioTextMessageFactory : ITwilioTextMessageFactory
{
    private readonly HttpClient _httpClient;
    private readonly TwilioOptions _options;

    public TwilioTextMessageFactory(HttpClient httpClient, IOptions<TwilioOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public TwilioTextMessage Create()
    {
        return new TwilioTextMessage(_httpClient, _options);
    }

    public TwilioTextMessage Create(string accountSid, string apiKey, string authToken, bool useSandbox = false,
        string testPhoneNumbers = null)
    {
        return new TwilioTextMessage(_httpClient, accountSid, apiKey, authToken, useSandbox, testPhoneNumbers);
    }
}