using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Atc.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class UrlAttribute : Attribute
    {
        private string _url;
        public UrlAttribute(string url)
        {
            _url = url;
        }

        public static void LoadPage(Type t, IWebDriver driver)
        {
            var att = (UrlAttribute)GetCustomAttribute(t, typeof(UrlAttribute));
            if (att != null)
            {
                driver.Navigate().GoToUrl(att._url);
            }
        }
    }
}
