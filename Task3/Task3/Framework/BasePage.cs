using OpenQA.Selenium;

namespace Task3.Framework
{
    public abstract class BasePage
    {
        private string name;
        private string locator;

        public BasePage(string locator, string name)
        {
            this.locator = locator;
            this.name = name;
        }

        public bool IsDisplayed()
        {
            var CheackPage = Driver.getInstance().FindElement(By.XPath(locator));
            return CheackPage.Displayed;
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
