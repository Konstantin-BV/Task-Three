using OpenQA.Selenium;

namespace Task3.Framework.Elements
{
    public class TextBox : BaseElement
    {
        string locator;
        string name;
        private const string NameValue = "value";

        public TextBox(string locator, string name) : base(locator, name)
        {
            this.locator = locator;
            this.name = name;
        }

        public void SendKeys(string key)
        {
            Driver.getInstance().FindElement(By.XPath(locator)).SendKeys(key);
        }

        public string GetKeys()
        {
            var inputElement = Driver.getInstance().FindElement(By.XPath(locator));
            return inputElement.GetAttribute(NameValue);
        }
    }
}
