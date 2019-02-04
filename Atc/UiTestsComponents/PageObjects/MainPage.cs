using OpenQA.Selenium;
using UiTestsComponents.PageObjects.CarsPages;

namespace UiTestsComponents.PageObjects
{
    public class MainPage
    {
        private IWebDriver _driver;
        private IWebElement _carsDropDown;
        private IWebElement _carsManagementLink;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public CarsManagementPage ManageCars()
        {


            _carsDropDown.Click();
            _carsManagementLink.Click();

            return new CarsManagementPage(_driver);
        }
    }
}
