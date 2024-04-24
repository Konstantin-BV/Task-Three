using OpenQA.Selenium;
using Task3.Framework;

namespace Task3
{

    [TestFixture]
    public class IframeTest : BaseTest
    {
        private const string NoOpenPage = "Страница не открылась ";
        private const string OpenPage = "Открылась страница ";
        private const string TextNotEqual = "Текст не совпал с ожидаемым";

        [Test]
        public void Test()
        {
            HomePage home = new HomePage();
            AlertPage alert = new AlertPage();
            FormsPage forms = new FormsPage();
            NestedFrames NestedPage = new NestedFrames();

            Driver.GoToUrl(ConfigurationForConfigData.Url, By.XPath(home.GetLocator()));
            Assert.That(home.IsDisplayed(), NoOpenPage + home.GetName);
            Logger.Info(OpenPage + home.GetName());
            home.GoToPageAlert();
            Assert.That(alert.IsDisplayed(), NoOpenPage + alert.GetName());
            Logger.Info(OpenPage + alert.GetName());
            alert.ClickMenuNestedFrames();
            Assert.That(NestedPage.IsDisplayed(), NoOpenPage + NestedPage.GetName());
            Logger.Info(OpenPage + NestedPage.GetName());
            Assert.That(NestedPage.IsFirstForm(), TextNotEqual);
            Assert.That(NestedPage.IsSecondForm(), TextNotEqual);
            alert.ClickMenuForms();
            var FirstFormText = forms.FirstForm();
            var SecondFormText = forms.SecondText();
            Assert.That(SecondFormText == FirstFormText, TextNotEqual);
        }
    }
}
