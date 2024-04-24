using OpenQA.Selenium;
using Task3.Framework;

namespace Task3
{
    [TestFixture]
    public class HandlesTest : BaseTest
    {
        private const string NoOpenPage = "Страница не открылась ";
        private const string OpenPage = "Открылась страница ";
        private const string NoOpenTab = "Новая вкладка не открылась";

        [Test]
        public void Test()
        {
            HomePage home = new HomePage();
            ElementsPage elements = new ElementsPage();
            AlertPage alert = new AlertPage();

            Driver.GoToUrl(ConfigurationForConfigData.Url, By.XPath(home.GetLocator()));
            Assert.That(home.IsDisplayed(), NoOpenPage + home.GetName);
            Logger.Info(OpenPage + home.GetName());
            home.GoToPageAlert();
            Assert.That(alert.IsDisplayed(), NoOpenPage + alert.GetName);
            Logger.Info(OpenPage + alert.GetName());
            alert.ClickMenuBrowserWindows();
            Assert.That(alert.IsDisplayBrowserWindows(), NoOpenPage + alert.GetName);
            Logger.Info(OpenPage + alert.GetName());
            alert.ClickNewTab();
            Assert.That(alert.IsNewTab(), NoOpenTab);
            Logger.Info(OpenPage + alert.GetName());
            Driver.ClooseAndBackTab();
            Assert.That(alert.IsDisplayBrowserWindows(), NoOpenTab);
            Logger.Info(OpenPage + alert.GetName());
            alert.GoToPageElements();
            Assert.That(elements.IsDisplayed(), NoOpenPage + elements.GetName);
            Logger.Info(OpenPage + elements.GetName());
            elements.ClickLinkHome();
            Assert.That(home.IsDisplayed(), NoOpenPage + home.GetName);
            Logger.Info(OpenPage + home.GetName());
            Driver.GoToBack();
            Assert.That(elements.IsDisplayed(), NoOpenPage + elements.GetName);
            Logger.Info(OpenPage + elements.GetName());
        }
    }
}
