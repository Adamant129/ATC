using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using FluentAssertions;

namespace UiTestsComponents.PageObjects.CarsPages
{
    public class CarsManagementPage
    {
        private IWebDriver _driver;

        public CarsManagementPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement _addNewCarButton;
        private IReadOnlyCollection<IWebElement> _carsNames;

        public AddNewCarPage AddNewCar()
        {
            _addNewCarButton = _driver.FindElement(By.XPath("//button[@type='submit']"));

            _addNewCarButton.Click();
            return new AddNewCarPage(_driver);
        }

        public CarsManagementPage CheckCarCreated(string carName)
        {
            _carsNames = _driver.FindElements(By.XPath("//table//tr/td[5]/a"));
            _carsNames.Select(p => p).Should().Contain(carName);

            return this;
        } 
    }
}
