using System;
using System.Collections.Generic;
using System.Reflection;
using OpenQA.Selenium;

namespace Atc.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class FindByXPathAttribute : Attribute
    {
        private string _expression;

        public FindByXPathAttribute(string expression)
        {
            _expression = expression;
        }

        public static void LoadPage(Type t, IWebDriver driver)
        {
            PropertyInfo[] properties = t.GetProperties();

            foreach (var property in properties)
            {
                var att = (FindByXPathAttribute) GetCustomAttribute(property, typeof(FindByXPathAttribute));
                if (att != null)
                {
                    property.SetValue(t, driver.FindElement(By.XPath(att._expression)));
                }
            }
        }
    }
}
