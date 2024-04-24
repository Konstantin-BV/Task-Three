using OpenQA.Selenium;
using Task3.Utils;

namespace Task3.Framework
{
    public static class Driver
    {
        private static IWebDriver? instance;
        public static IAlert? alert = null;

        public static IWebDriver getInstance()
        {
            if (instance == null)
            {
                instance = FactoryMethod.Result();
            }
            return instance;
        }

        public static void Quit()
        {
            instance.Quit();
            instance = null;
        }

        public static void ClooseAndBackTab()
        {
            var windowHandles = getInstance().WindowHandles.ToList();
            getInstance().Close();
            var currentIndex = windowHandles.Count - 1;
            getInstance().SwitchTo().Window(windowHandles[currentIndex - 1]);
        }

        public static void GoSecongTab()
        {
            var currentWindowHandle = getInstance().CurrentWindowHandle;
            var windowHandles = getInstance().WindowHandles.ToList();
            var currentIndex = windowHandles.IndexOf(currentWindowHandle);
            if (currentIndex < windowHandles.Count - 1)
            {
                string nextWindowHandle = windowHandles[currentIndex + 1];
                getInstance().SwitchTo().Window(nextWindowHandle);
            }
        }

        public static void GoToUrl(string url, By a)
        {
            getInstance().Navigate().GoToUrl(url);
            Waiting.WaitForElement(a);
        }

        public static IWebElement FindEliment(string locatorElement, string locatorFrime)
        {
            Driver.getInstance().SwitchTo().Frame(Driver.getInstance().FindElement(By.XPath(locatorFrime)));
            IWebElement Eliment = Driver.getInstance().FindElement(By.XPath(locatorElement));
            return Eliment;
        }

        public static void GoToIframe(string locatorFrime)
        {
            Driver.getInstance().SwitchTo().Frame(Driver.getInstance().FindElement(By.XPath(locatorFrime)));
        }

        public static void GoToDefaultContent()
        {
            Driver.getInstance().SwitchTo().DefaultContent();
        }

        public static string? GetText()
        {
            alert = Driver.getInstance().SwitchTo().Alert();
            var text = alert.Text;
            if (alert != null) return text;
            else return null;
        }

        public static void Accert()
        {
            alert = Driver.getInstance().SwitchTo().Alert();
            alert.Accept();
            alert = null;
        }

        public static void Dismiss()
        {
            alert = Driver.getInstance().SwitchTo().Alert();
            alert.Dismiss();
            alert = null;
        }

        public static void SendKeysRandString()
        {
            string RandSrt = StringsRand.RandomString(5);
            alert = Driver.getInstance().SwitchTo().Alert();
            alert.SendKeys(RandSrt);
            alert.Accept();
        }

        public static void GoToBack() { Driver.getInstance().SwitchTo().Window(Driver.getInstance().WindowHandles[0]); }
    }
}
