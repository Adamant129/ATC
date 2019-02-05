using System;
using Atc;
using OpenQA.Selenium;
using UiTestsComponents.PageObjects.CarsPages;
using UiTestsComponents.PageObjects.HotelsPages;

namespace UiTestsComponents.PageObjects
{
    public class MainPage
    {
        private IWebDriver _driver;
        private IWebElement _carsDropDown;
        private IWebElement _carsManagementLink;
        private IWebElement _hotelsDropDown;
        private IWebElement _hotelsManagementLink;
        private IWebElement _logOutButton;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        public CarsManagementPage ManageCars()
        {
            _carsDropDown = _driver.FindElement(By.XPath("//a[@href='#Cars']"));
            _carsDropDown.Click();

            _carsManagementLink = _driver.FindElement(By.XPath("//a[text()='Cars']"));
            AtcBuilder.Log.Information("Clicking cars link");
            _carsManagementLink.Click();
            AtcBuilder.Log.Information("Clicked cars link");

            return new CarsManagementPage(_driver);
        }

        public HotelsPage ManageHotels()
        {
            _hotelsDropDown = _driver.FindElement(By.XPath("//a[@href='#Hotels']"));
            _hotelsDropDown.Click();

            _hotelsManagementLink = _driver.FindElement(By.XPath("//a[text()='Hotels']"));
            AtcBuilder.Log.Information("Clicking hotels link");
            _hotelsManagementLink.Click();
            AtcBuilder.Log.Information("Clicked hotels link");

            return new HotelsPage(_driver);
        }

        public LoginPage LogOut()
        {
            _logOutButton = _driver.FindElement(By.XPath("//a[text()='Log Out']"));

            AtcBuilder.Log.Information("Clicking log out button");
            _logOutButton.Click();
            AtcBuilder.Log.Information("Clicked log out button");

            return new LoginPage(_driver);
        }
    }
}
