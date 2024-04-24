using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Task3.Framework;

namespace Task3
{
    internal static class FactoryMethod
    {
        private const string ChromeName = "Chrome";
        private const string FirefoxName = "Firefox";
        private static IWebDriver? resultWebDriver;
        private const string ErorrMessage = "Неожиданное значение в файле Config.json";

        public static IWebDriver? Result()
        {
            switch (ConfigurationForConfigData.Browser)
            {
                case ChromeName:
                    resultWebDriver = new ChromeDriver();
                    break;
                case FirefoxName:
                    resultWebDriver = new FirefoxDriver();
                    break;
                default:
                    Logger.Error(ErorrMessage);
                    break;
            }
            return resultWebDriver;
        }
    }
}
