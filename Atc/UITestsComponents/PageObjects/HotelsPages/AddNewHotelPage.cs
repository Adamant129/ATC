using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UiTestsComponents.Models;

namespace UiTestsComponents.PageObjects.HotelsPages
{
    public class AddNewHotelPage
    {
        private IWebDriver _driver;
        public AddNewHotelPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement _hotelNameInput;
        private IWebElement _hotelStarsDropDown;
        private IWebElement _submitButton;
        
        public HotelsPage AddNewHotel(HotelModel model)
        {
            _hotelNameInput = _driver.FindElement(By.XPath("//input[@name='hotelname']"));
            _hotelStarsDropDown = _driver.FindElement(By.XPath("//input[@name='hotelstars']"));
            _submitButton = _driver.FindElement(By.Id("add"));

            _hotelNameInput.SendKeys(model.HotelName);
            _hotelStarsDropDown.SendKeys(((int)model.HotelStars).ToString());

            _submitButton.Click();

            return new HotelsPage(_driver);
        }
    }
}
