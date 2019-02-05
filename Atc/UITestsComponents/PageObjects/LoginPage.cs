using OpenQA.Selenium;
using Atc.Attributes;
using System;
using Atc;
using Serilog;

namespace UiTestsComponents.PageObjects
{
    [Url("https://www.phptravels.net/admin")]
    public class LoginPage
    {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            UrlAttribute.LoadPage(typeof(LoginPage), _driver);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        private IWebElement _userNameInput;
        private IWebElement _userPasswordInput;
        private IWebElement _login;

        public MainPage Login(string userName, string password)
        {
            _userNameInput = _driver.FindElement(By.XPath("//input[@placeholder='Email']"));
            _userPasswordInput = _driver.FindElement(By.XPath("//input[@placeholder='Password']"));
            _login = _driver.FindElement(By.XPath("//button[@type='submit']"));
            
            _userNameInput.SendKeys(userName);
            AtcBuilder.Log.Information($"Set {userName} user name to username field");

            _userPasswordInput.SendKeys(password);

            AtcBuilder.Log.Information($"Set {password} password to password field");
            _login.Click();

            return new MainPage(_driver);
        }
    }
}
