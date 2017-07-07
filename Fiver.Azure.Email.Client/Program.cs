using Fiver.Azure.Email;
using Fiver.Azure.Email.Message;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Fiver.Azure.Email.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // Build & Read Configuration
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true)
                                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                                .AddEnvironmentVariables();

            var configuration = builder.Build();

            var apiKey = configuration["Api_Key"];
            var subject = configuration["Email_Subject"];
            var from = configuration["Email_From"];
            var body = configuration["Email_Body"];
            var to = configuration["Email_To"];

            // Prepare Email Message
            var message = EmailMessageBuilder
                            .Init()
                            .AddSubject(subject)
                            .AddFrom(from)
                            .AddBody(body)
                            .AddTo(to)
                            .Build();

            // Send Email Message
            IAzureEmailSender sender = new AzureEmailSender(new AzureEmailSettings(apiKey));
            var response = sender.SendAsync(message).Result;
            Console.WriteLine(response.StatusCode);

            Console.ReadLine();
        }
    }
}