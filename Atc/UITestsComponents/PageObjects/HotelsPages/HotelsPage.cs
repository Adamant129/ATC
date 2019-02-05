using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using Atc;
using OpenQA.Selenium.Support.UI;

namespace UiTestsComponents.PageObjects.HotelsPages
{
    public class HotelsPage
    {
        private IWebDriver _driver;
        public HotelsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement _paginateButton;
        private IReadOnlyCollection<IWebElement> _hotelNames;

        public HotelsPage PaginateHotels(int amount)
        {
            _paginateButton = _driver.FindElement(By.XPath($"//button[@data-limit='{amount}']"));

            AtcBuilder.Log.Information($"Clicking paginate hotels amount by {amount} amount");
            _paginateButton.Click();
            AtcBuilder.Log.Information($"Finished clicking paginate hotels amount by {amount} amount");

            new WebDriverWait(_driver, TimeSpan.FromSeconds(2));

            _hotelNames = _driver.FindElements(By.XPath("//table//tr/td[5]/a"));
            _hotelNames.Select(p => p).Count().Should().BeLessOrEqualTo(amount);

            return this;
        }
    }
}
