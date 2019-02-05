using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UiTestsComponents.PageObjects.HotelsPages
{
    public class HotelsPage
    {
        private IWebDriver _driver;
        public HotelsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement _addNewHotelButton;
        private IReadOnlyCollection<IWebElement> _hotelNames;

        public AddNewHotelPage AddNewHotel()
        {
            _addNewHotelButton = _driver.FindElement(By.XPath("//button[@type='submit']"));
            _addNewHotelButton.Click();

            return new AddNewHotelPage(_driver);
        }

        public HotelsPage CheckHotelCreated(string hotelName)
        {
            _hotelNames = _driver.FindElements(By.XPath("//table//tr/td[5]/a"));
            _hotelNames.Select(p => p).Should().Contain(hotelName);

            return this;
        }
    }
}
