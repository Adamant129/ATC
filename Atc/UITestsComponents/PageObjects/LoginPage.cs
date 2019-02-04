using OpenQA.Selenium;
using Atc.Attributes;

namespace UiTestsComponents.PageObjects
{
    [Url("https://www.phptravels.net/admin")]
    public class LoginPage
    {
        private IWebDriver _driver;

        //[FindByXPath("//input[@placeholder='Email']")]
        private IWebElement _userNameInput;

        //[FindByXPath("input[@placeholder='Password']")]
        private IWebElement _userPasswordInput;

        //[FindByXPath("button[@type='submit']")]
        private IWebElement _login;

        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            UrlAttribute.LoadPage(typeof(LoginPage), _driver);
            //FindByXPathAttribute.LoadPage(typeof(LoginPage), _driver);
        }

        public MainPage Login()
        {
            _userNameInput = _driver.FindElement(By.XPath("//input[@placeholder='Email']"));
            _userPasswordInput = _driver.FindElement(By.XPath("//input[@placeholder='Password']"));
            _login = _driver.FindElement(By.XPath("//button[@type='submit']"));

            _userNameInput.SendKeys(UserName);
            _userPasswordInput.SendKeys(Password);
            _login.Click();

            return new MainPage(_driver);
        }
    }
}
