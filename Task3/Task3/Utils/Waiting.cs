using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Task3.Framework;

namespace Task3.Utils
{
    internal static class Waiting
    {
        public static void ImplicitExpectation()
        {
            Driver.getInstance().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigurationForConfigData.Wait);
        }

        public static void WaitOpenAlert()
        {
            var wait = new WebDriverWait(Driver.getInstance(), TimeSpan.FromSeconds(ConfigurationForConfigData.Wait));
            wait.Until(ExpectedConditions.AlertIsPresent());
        }

        public static void WaitForElement(By locator)
        {
            var wait = new WebDriverWait(Driver.getInstance(), TimeSpan.FromSeconds(ConfigurationForConfigData.Wait));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}
