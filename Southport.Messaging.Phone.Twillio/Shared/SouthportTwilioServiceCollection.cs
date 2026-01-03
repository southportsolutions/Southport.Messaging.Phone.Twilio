using System;
using Microsoft.Extensions.Configuration;
using Southport.Messaging.Phone.Twilio.Shared;
using Southport.Messaging.Phone.Twilio.TextMessage;
using Southport.Messaging.Phone.Twilio.Verifier;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
    {
        public static class SouthportTwilioServiceCollection
        {
            public static IServiceCollection AddKeyVaultCollection(this IServiceCollection services, IConfiguration config, string keyVaultConfigKey = TwilioOptions.Key)
            {
                if (string.IsNullOrWhiteSpace(keyVaultConfigKey))
                {
                    throw new ArgumentNullException(nameof(keyVaultConfigKey));
                }
                
                services.Configure<TwilioOptions>(config.GetSection(keyVaultConfigKey));
                services.AddHttpClient<ITwilioTextMessageFactory, TwilioTextMessageFactory>();
                services.AddScoped<ITwilioPhoneNumberVerifier, TwilioPhoneNumberVerifier>();

                return services;
            }
        }


    }
