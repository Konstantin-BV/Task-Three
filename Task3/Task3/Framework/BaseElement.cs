using OpenQA.Selenium;
using Task3.Utils;

namespace Task3.Framework
{
    public abstract class BaseElement
    {
        private string name;
        private string locator;

        public BaseElement(string locator, string name)
        {
            this.locator = locator;
            this.name = name;
        }

        public void Click()
        {
            Waiting.WaitForElement(By.XPath(locator));
            Driver.getInstance().FindElement(By.XPath(locator)).Click();
        }

        public bool IsDisplayed()
        {
            return Driver.getInstance().FindElement(By.XPath(locator)).Displayed;
        }

        public string GetText()
        {
            return Driver.getInstance().FindElement(By.XPath(locator)).Text;
        }

        public string GetTagName()
        {
            return Driver.getInstance().FindElement(By.XPath(locator)).TagName;
        }

        public string GetAttribute(string nameAttribute)
        {
            return Driver.getInstance().FindElement(By.XPath(locator)).GetAttribute(nameAttribute);
        }

        public string GetName()
        {
            return name;
        }

        public string GetLocator()
        {
            return locator;
        }
    }
}
