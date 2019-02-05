using System;
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
            _carsManagementLink.Click();

            return new CarsManagementPage(_driver);
        }

        public HotelsPage ManageHotels()
        {
            _hotelsDropDown = _driver.FindElement(By.XPath("//a[@href='#Hotels']"));
            _hotelsDropDown.Click();

            _hotelsManagementLink = _driver.FindElement(By.XPath("//a[text()='Hotels']"));
            _hotelsManagementLink.Click();

            return new HotelsPage(_driver);
        }
    }
}
