using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UITestsComponents.Models;

namespace UITests
{
    [TestFixture]
    public class UITestsFixture : DefaultFixture
    {
        protected UserModel User { get; set; }
        protected IWebDriver Driver { get; set; }

        protected AppConfiguration Conf { get; set; }
        protected IConfiguration Configuration { get; set; }

        public UITestsFixture()
        {
            //User = _user ;
            //Driver = _driver;
            //Configuration = _configuration;
        }

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("Atc.json", false, true)
                //.AddJsonFile($"Atc.{environment}.json", false, true)
                .Build();

            Conf = Configuration.GetValue<AppConfiguration>(nameof(AppConfiguration));            
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Dispose();
        }
    }
}
