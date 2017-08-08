using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace configtest
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false);
            var configuration = builder.Build();

            var aSection = new SomeSection();
            var section = configuration.GetSection("SomeSection");
            aSection = section.Get<SomeSection>();
            Console.WriteLine($"username: {aSection.UserName}, pwd: {aSection.Password}");
        }
    }

    public class SomeSection
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
