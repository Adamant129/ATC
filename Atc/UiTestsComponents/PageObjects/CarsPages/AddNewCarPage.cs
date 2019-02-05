using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace UiTestsComponents.PageObjects.CarsPages
{
    public class AddNewCarPage
    {
        public IWebElement _carNameInput;
        public IWebElement _submitButton;
        public IWebDriver _driver;

        public AddNewCarPage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        public CarsManagementPage CreateNewCar(string carName = "Test1")
        {
            _carNameInput = _driver.FindElement(By.XPath("//input[@name='carname']"));
            _submitButton = _driver.FindElement(By.Id("add"));

            _carNameInput.SendKeys(carName);
            _submitButton.Click();

            return new CarsManagementPage(_driver);
        }
    }
}
