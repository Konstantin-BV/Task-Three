using OpenQA.Selenium;
using Task3.Framework;

namespace Task3
{
    public class TablesTest : BaseTest
    {
        private const string NoOpenPage = "Страница не открылась ";
        private const string OpenPage = "Открылась страница ";
        private const string CountNotEqual = "Колличество заполненых строк в таблице не совпадает с ожидаемым";
        private const string NoOpenForm = "Форма для регистрации не открылась";
        private const string OpenForm = "Форма для регистрации открылась";
        private const string UserNotAdd = "Юзер не добавился";
        private const string UserAdd = "Юзер добавился";
        private const string UserNotDelete = "Юзер не удалился";
        private const string UserDelete = "Юзер удалился";

        [Test]
        [TestCaseSource(nameof(ConfigurationsForTestData.Users))]
        public void Test(User users)
        {
            HomePage home = new();
            ElementsPage elements = new ElementsPage();

            Driver.GoToUrl(ConfigurationForConfigData.Url, By.XPath(home.GetLocator()));
            Assert.That(home.IsDisplayed(), NoOpenPage + home.GetName);
            Logger.Info(OpenPage + home.GetName());
            home.GoToPageElements();
            Assert.That(elements.IsDisplayed(), NoOpenPage + elements.GetName);
            Logger.Info(OpenPage + elements.GetName());
            elements.ClickWebTables();
            Assert.That(elements.IsWebTables(), NoOpenPage + elements.GetName);
            Logger.Info(OpenPage + elements.GetName());
            elements.ClickNewWebTables();
            Assert.That(elements.IsRegistrationForm(), NoOpenForm);
            Logger.Info(OpenForm);
            elements.EnterUser(users);
            elements.Submit();
            Assert.That(elements.IsAddUser(users), UserNotAdd);
            Logger.Info(UserAdd);
            Assert.That(elements.IsCountUser(), CountNotEqual);
            elements.DeleteUser();
            Assert.That(elements.IsCountDeleterUser(), CountNotEqual);
            Assert.That(elements.IsDeliteUser(users), UserNotDelete);
            Logger.Info(UserDelete);
        }

        private static List<User> Users()
        {
            return ConfigurationsForTestData.Users;
        }
    }
}
