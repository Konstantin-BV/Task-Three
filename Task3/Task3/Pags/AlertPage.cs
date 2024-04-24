using OpenQA.Selenium;
using Task3.Framework;
using Task3.Framework.Elements;
using Task3.Utils;

namespace Task3
{
    internal class AlertPage : BasePage
    {
        private const string locator = "//*[contains(@class,'show')]//*[@id='item-0' and contains(.,'Browser Windows')]";
        private const string name = "Driver page";
        private const string InfoButton = "Была нажата кнопка ";
        private const string LocatorResultAlertAppear = "//*[contains(.,'Ok') and @id='confirmResult']";
        private const string LocatorResultAlertPromtFirstHalf = "//*[contains(.,'";
        private const string LocatorResultAlertPromtSecondHalf = "') and @id='promptResult']";
        private const string locatorNestedFramePage = "//*[@id='frame1']";
        private Button OpenAlertExamplesButton => new("//*[contains(@class,'show')]//*[@id='item-1']", "OpenAlertExamples");
        private Button OpenElementExamplesButton => new("//span[contains(.,'Elements')]", "OpenElementExamples");
        private Button OpenElementLinkButton => new("//*[contains(@class,'show')]//*[@id='item-5']", "OpenLinkExamples");
        private Button OpenElementWindowButton => new("//*[contains(@class,'show')]//*[@id='item-0']", "OpenLinkWindow");
        private Button ButtonNewTab => new("//*[@id=\"tabButton\"]", "button on the left menu brouser window");
        private Button PageToNewTab => new("//*[@id='sampleHeading']", "button on the page NewTab");
        private Button AlertButtonSee => new("//*[@id=\"alertButton\"]", "AlertPageSee");
        private Button AlertButtonTime => new("//*[@id=\"timerAlertButton\"]", "AlertPageSee");
        private Button AlertButtonForm => new("//*[contains(@class,'show')]//*[@id='item-2']", "AlertButtonForm");
        private Button NestedFramesButton => new("//*[contains(@class,'show')]//*[@id='item-3']", "NestedFramesButton");
        private Button PromtButton => new("//*[@id='promtButton']", "PromtButton");
        private Button ApperButton => new("//*[@id=\"confirmButton\"]", "ApperButton");

        public AlertPage() : base(locator, name) { }

        public void ClickMenuAlert()
        {
            OpenAlertExamplesButton.Click();
            Logger.Info(InfoButton + OpenAlertExamplesButton.GetName());
        }

        public void GoToPageElements()
        {
            OpenElementExamplesButton.Click();
            OpenElementLinkButton.Click();
            Logger.Info(InfoButton + OpenElementLinkButton.GetName());
        }

        public void ClickMenuBrowserWindows()
        {
            OpenElementWindowButton.Click();
            Logger.Info(InfoButton + OpenElementWindowButton.GetName());
        }

        public Boolean IsDisplayBrowserWindows()
        {
            if (OpenElementWindowButton.IsDisplayed()) { return true; }
            else
            { return false; }
        }

        public void ClickNewTab()
        {
            ButtonNewTab.Click();
            Logger.Info(InfoButton + ButtonNewTab.GetName());
            Driver.GoSecongTab();
        }

        public Boolean IsNewTab()
        {
            if (PageToNewTab.IsDisplayed()) { return true; }
            else return false;
        }

        public Boolean IsDisplayAlertButton()
        {
            if (AlertButtonSee.IsDisplayed()) { return true; }
            else
            { return false; }
        }

        public void ClickAlertSee()
        {
            AlertButtonSee.Click();
            Logger.Info(InfoButton + AlertButtonSee.GetName());
        }

        public string? TextAlert()
        {
            if (Driver.GetText() != null)
                return Driver.GetText();
            else return null;
        }

        public void ClickAlertAccet()
        {
            Driver.Accert();
        }

        public void ClickAlertTime()
        {
            AlertButtonTime.Click();
            Logger.Info(InfoButton + AlertButtonTime.GetName());
            Waiting.WaitOpenAlert();
        }

        public void ClickAlertTimeAccet()
        {
            Driver.Accert();
        }

        public void ClickAlertApear()
        {
            ApperButton.Click();
            Logger.Info(InfoButton + ApperButton.GetName());
            Waiting.WaitOpenAlert();
        }

        public void ClickAlertAppearAccet()
        {
            Driver.Accert();
        }

        public Boolean IsResultAlertAppear()
        {
            if (Driver.getInstance().FindElement(By.XPath(LocatorResultAlertAppear)).Displayed) { return true; }
            else
            { return false; }
        }

        public void ClickAlertPromtButton()
        {
            PromtButton.Click();
            Logger.Info(InfoButton + PromtButton.GetName());
            Waiting.WaitOpenAlert();
        }

        public void EnterStringAlertPromtButtonAccet()
        {
            Driver.SendKeysRandString();
        }

        public bool IsResultAlertPromtButton()
        {
            var locatorCheck = LocatorResultAlertPromtFirstHalf + StringsRand.RandomString(5) + LocatorResultAlertPromtSecondHalf;
            if (Driver.getInstance().FindElement(By.XPath(locatorCheck)).Displayed) { return true; }
            else
            { return false; }
        }

        public void ClickMenuNestedFrames()
        {
            NestedFramesButton.Click();
            Logger.Info(InfoButton + NestedFramesButton.GetName());
            Waiting.WaitForElement(By.XPath(locatorNestedFramePage));
        }

        public void ClickMenuForms()
        {
            AlertButtonForm.Click();
            Logger.Info(InfoButton + AlertButtonForm.GetName());
        }
    }
}
