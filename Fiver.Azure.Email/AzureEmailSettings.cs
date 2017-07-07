using System;

namespace Fiver.Azure.Email
{
    public class AzureEmailSettings
    {
        public AzureEmailSettings(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentException("Api Key must be set");
            
            this.ApiKey = apiKey;
        }

        public string ApiKey { get; }
    }
}
