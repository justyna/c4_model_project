using System;
using Microsoft.Extensions.Configuration;

namespace modelc4_project
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelC4Config config = new ConfigurationBuilder()
            .AddJsonFile("model_c4_settings.json", true, true)
            .AddEnvironmentVariables()
            .Build()
            .Get<ModelC4Config>();
            
            new ModelC4ExpirationPlatform(config).Publish();
        }
    }
}
