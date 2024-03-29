﻿using System.Threading.Tasks;
using Twilio.Rest.Lookups.V1;

namespace Southport.Messaging.Phone.Twilio.Verifier
{
    public interface ITwilioPhoneNumberVerifier
    {
        Task<PhoneNumberResource> PhoneNumberLookupAsync(string phoneNumber, PhoneNumberLookupType type, string countryCode);
    }
}