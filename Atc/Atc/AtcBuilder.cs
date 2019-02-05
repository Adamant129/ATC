using Atc.Models.Enums;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.IO;
using RestSharp;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System.Text;

namespace Atc
{
    public static class AtcBuilder
    {
        static AtcBuilder()
        {
            CurrentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
        }

        private static DirectoryInfo CurrentDirectory;

        public static IConfiguration Configuration { get; set; }
        public static Logger Log { get; set; }
        public static IWebDriver Driver { get; set; }
        public static RestClient RestClient { get; set; }

        public static void AddJsonConfiguration()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("Atc.json", false, true)
                .Build();
        }

        public static void AddDriver(BrowserDriver driver = BrowserDriver.GoogleChrome)
        {
            switch(driver)
            {
                case BrowserDriver.GoogleChrome:
                    Driver = new ChromeDriver(CurrentDirectory.FullName);
                    break;
                case BrowserDriver.FireFox:
                    Driver = new FirefoxDriver(CurrentDirectory.FullName);
                    break;
            }
        }

        public static void AddLogging(string logsPath = "Logs")
        {
            string loggingDirectory = Path.Combine(CurrentDirectory.FullName, logsPath);

            Log = new LoggerConfiguration()
                .WriteTo.File(Path.Combine(loggingDirectory, "debug.log"), LogEventLevel.Debug)
                .WriteTo.File(Path.Combine(loggingDirectory, "info.log"), LogEventLevel.Information)
                .WriteTo.File(Path.Combine(loggingDirectory, "errors.log"), LogEventLevel.Error)
                .CreateLogger();
        }

        public static void AddRestClient()
        {
            RestClient = new RestClient
            {
                Timeout = System.Convert.ToInt32(System.TimeSpan.FromMinutes(3).TotalMilliseconds),
                Encoding = Encoding.UTF8
            };
        }
    }
}
