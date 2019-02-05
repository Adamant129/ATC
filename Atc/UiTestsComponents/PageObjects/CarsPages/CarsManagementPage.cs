using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace UiTestsComponents.PageObjects.CarsPages
{
    public class CarsManagementPage
    {
        private IWebElement _addNewCarButton;
        private IReadOnlyCollection<IWebElement> _carsNames;
        private IWebDriver _driver;

        public CarsManagementPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public AddNewCarPage AddNewCar()
        {
            _addNewCarButton = _driver.FindElement(By.XPath("//button[@type='submit']"));

            _addNewCarButton.Click();
            return new AddNewCarPage(_driver);
        }

        public CarsManagementPage CheckCarCreated(string carName)
        {
            _carsNames = _driver.FindElements(By.XPath("//table//tr/td[5]/a"));
            Assert.True(_carsNames.Any(p => p.Text == carName));

            return this;
        } 
    }
}
