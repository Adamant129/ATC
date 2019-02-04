using Atc.Models.Enums;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System;

namespace Atc
{
    public class AtcBuilder
    {
        public IConfiguration Configuration { get; set; }

        public IWebDriver Driver { get; set; }

        public virtual AtcBuilder AddJsonConfiguration()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("Atc.json", false, true)
                //.AddJsonFile($"Atc.{environment}.json", false, true)
                .Build();

            return this;
        }

        public virtual AtcBuilder AddDriver(BrowserDriver driver = BrowserDriver.GoogleChrome)
        {
            switch(driver)
            {
                case BrowserDriver.GoogleChrome:
                    Driver = new ChromeDriver();
                    break;
                case BrowserDriver.FireFox:
                    Driver = new FirefoxDriver();
                    break;
            }

            return this;
        }

        public virtual AtcBuilder AddLogging()
        {
            return this;
        }
    }
}
