
using OpenQA.Selenium;
using Task3.Framework;
using Task3.Framework.Elements;
using Task3.Utils;

namespace Task3
{
    internal class ElementsPage : BasePage
    {
        private const int constUser = 4;
        private const int nullUser = 0;
        private const string locator = "//*[contains(@class,'show')]//*[@id='item-3' and contains(.,'Web')]";
        private const string name = "OpenElementExamplesButton";
        private const string InfoButton = "Была нажата кнопка ";
        private const string LocatorSubmitButton = "//*[@id='submit']";
        private const string LocatorDeleteUsers = "//*[contains(@class,'action-buttons')]//*[@title='Delete']";
        private const string LocatorUsers = "//*[contains(@class,'action-buttons')]";
        private const string LocatorEmailTableFirstHalf = "//*[contains(text(),'";
        private const string LocatorEmailTableSecondHalf = "')]";
        private Button ButtonWebTables => new(locator, "WebTables");
        private Button LinkButton => new("//*[@id = 'simpleLink' ]", "WebTables");
        private Button ButtonAddWebTables => new("//*[@id='addNewRecordButton']", "ButtonNewWebTables");
        private Button ButtonSubmitWebTables => new("//*[@id='submit']", "ButtonNewWebTables");
        private TextBox FirstName => new("//*[@id='firstName']", "FirstName");
        private TextBox LastName => new("//*[@id='lastName']", "LastName");
        private TextBox Email => new("//*[@id='userEmail']", "Email");
        private TextBox Salary => new("//*[@id='salary']", "Salary");
        private TextBox Age => new("//*[@id='age']", "Age");
        private TextBox Deportament => new("//*[@id='department']", "Deportament");

        public ElementsPage() : base(locator, name) { }

        public void ClickWebTables()
        {

            ButtonWebTables.Click();
            Logger.Info(InfoButton + ButtonWebTables.GetName());
        }

        public void ClickLinkHome()
        {
            LinkButton.Click();
            Driver.getInstance().SwitchTo().Window(Driver.getInstance().WindowHandles[1]);
            Logger.Info(InfoButton + LinkButton.GetName());
        }

        public Boolean IsWebTables()
        {
            if (ButtonAddWebTables.IsDisplayed()) { return true; }
            else
            { return false; }
        }

        public void ClickNewWebTables()
        {
            ButtonAddWebTables.Click();
            Logger.Info(InfoButton + ButtonAddWebTables.GetName());
        }

        public void EnterUser(User user)
        {
            FirstName.SendKeys(user.FirstName);
            LastName.SendKeys(user.LastName);
            Email.SendKeys(user.Email);
            Age.SendKeys(user.Age);
            Salary.SendKeys(user.Salary);
            Deportament.SendKeys(user.Departament);
        }

        public void Submit()
        {
            ButtonSubmitWebTables.Click();
        }

        public Boolean IsRegistrationForm()
        {
            Waiting.WaitForElement(By.XPath(LocatorSubmitButton));
            if (ButtonSubmitWebTables.IsDisplayed()) { return true; }
            else { return false; }
        }

        public Boolean IsCountUser()
        {
            var users = Driver.getInstance().FindElements(By.XPath(LocatorUsers));
            if (users.Count == constUser) { return true; }
            else { return false; }
        }

        public Boolean DeleteUser()
        {
            var usersDelete = Driver.getInstance().FindElements(By.XPath(LocatorDeleteUsers));
            usersDelete[usersDelete.Count - 1].Click();
            var usersDeleter = Driver.getInstance().FindElements(By.XPath(LocatorDeleteUsers));
            if (usersDelete.Count == usersDeleter.Count + 1) { return true; }
            else { return false; }
        }

        public Boolean IsCountDeleterUser()
        {
            var users = Driver.getInstance().FindElements(By.XPath(LocatorUsers));
            if (users.Count == constUser - 1) { return true; }
            else { return false; }
        }

        public Boolean IsAddUser(User user)
        {
            var usersEmailLocator = LocatorEmailTableFirstHalf + user.Email + LocatorEmailTableSecondHalf;
            if (Driver.getInstance().FindElement(By.XPath(usersEmailLocator)).Displayed) { return true; }
            else { return false; }
        }

        public Boolean IsDeliteUser(User user)
        {
            var usersEmailLocator = LocatorEmailTableFirstHalf + user.Email + LocatorEmailTableSecondHalf;
            var elements = Driver.getInstance().FindElements(By.XPath(usersEmailLocator));
            if (elements.Count == nullUser) { return true; }
            else { return false; }
        }
    }
}
