using Atc.Models.Enums;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System;
using System.IO;

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
                .Build();

            return this;
        }

        public virtual AtcBuilder AddDriver(BrowserDriver driver = BrowserDriver.GoogleChrome)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            switch(driver)
            {
                case BrowserDriver.GoogleChrome:
                    Driver = new ChromeDriver(currentDirectory);
                    break;
                case BrowserDriver.FireFox:
                    Driver = new FirefoxDriver(currentDirectory);
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
