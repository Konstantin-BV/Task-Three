using OpenQA.Selenium;
using Task3.Framework;

namespace Task3
{
    [TestFixture]
    public class AlertsTest : BaseTest
    {
        private const string NoOpenPage = "Страница не открылась ";
        private const string OpenPage = "Открылась страница ";
        private const string TextNotEqual = "Текст не совпал с ожидаемым";

        [Test]
        public void Test()
        {
            Setup();
            HomePage home = new HomePage();
            AlertPage alert = new AlertPage();
            var ExpectedTextAlert = ConfigurationsForTestData.ExpectedTextAlert;
            var ExpectedTextAlertTime = ConfigurationsForTestData.ExpectedTextAlertTime;
            var ExpectedTextAlertApper = ConfigurationsForTestData.ExpectedTextAlertApper;
            var ExpectedTextAlertPromt = ConfigurationsForTestData.ExpectedTextAlertPromt;

            Driver.GoToUrl(ConfigurationForConfigData.Url, By.XPath(home.GetLocator()));
            Assert.That(home.IsDisplayed(), NoOpenPage + home.GetName);
            Logger.Info(OpenPage + home.GetName());
            home.GoToPageAlert();
            Assert.That(alert.IsDisplayed(), NoOpenPage + alert.GetName);
            Logger.Info(OpenPage + alert.GetName());
            alert.ClickMenuAlert();
            Assert.That(alert.IsDisplayAlertButton(), NoOpenPage + alert.GetName);
            Logger.Info(OpenPage + alert.GetName());
            alert.ClickAlertSee();
            var RealResultAlert = alert.TextAlert();
            Assert.That(RealResultAlert == ExpectedTextAlert, TextNotEqual);
            alert.ClickAlertAccet();
            alert.ClickAlertTime();
            var RealResultAlertTime = alert.TextAlert();
            Assert.That(ExpectedTextAlertTime == RealResultAlertTime, TextNotEqual);
            alert.ClickAlertTimeAccet();
            alert.ClickAlertApear();
            var RealResultAlertApper = alert.TextAlert();
            Assert.That(RealResultAlertApper == ExpectedTextAlertApper, TextNotEqual);
            alert.ClickAlertAppearAccet();
            Assert.That(alert.IsResultAlertAppear(), TextNotEqual);
            alert.ClickAlertPromtButton();
            var RealTextAlertPromt = alert.TextAlert();
            Assert.That(ExpectedTextAlertPromt == RealTextAlertPromt, TextNotEqual);
            alert.EnterStringAlertPromtButtonAccet();
            Assert.That(alert.IsResultAlertPromtButton(), TextNotEqual);
        }
    }
}
