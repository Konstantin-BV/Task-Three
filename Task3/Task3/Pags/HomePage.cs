using Task3.Framework;
using Task3.Framework.Elements;

namespace Task3
{
    public class HomePage : BasePage
    {
        private const string locator = "//*[@class='banner-image']";
        private const string name = "Home page";
        private const string InfoButton = "Была нажата кнопка ";
        private Button AlertPage => new("//*[contains(@class,'top-card') and contains(.,'Alerts')]", "ButtonAlertPage");
        private Button ElementsPage => new("//*[contains(@class,'top-card') and contains(.,'Elements')]", "ButtonElementPage");

        public HomePage() : base(locator, name) { }

        public void GoToPageAlert()
        {
            AlertPage.Click();
            Logger.Info(InfoButton + AlertPage.GetName());
        }

        public void GoToPageElements()
        {
            ElementsPage.Click();
        }
    }
}
