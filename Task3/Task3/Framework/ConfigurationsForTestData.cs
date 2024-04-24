using Microsoft.Extensions.Configuration;

namespace Task3.Framework
{
    public static class ConfigurationsForTestData
    {
        private static string NameExpectedTextAlert = "ExpectedTextAlert";
        private static string NameExpectedTextAlertTime = "ExpectedTextAlertTime";
        private static string NameExpectedTextAlertApper = "ExpectedTextAlertApper";
        private static string NameExpectedTextAlertPromt = "ExpectedTextAlertPromt";
        private static IConfiguration ConfigurationForTestData
        {
            get
            {
                var data = new ConfigurationBuilder().AddJsonFile(AppDomain.CurrentDomain.BaseDirectory + PathToTestJson).Build();
                config = data;
                return config;
            }
        }

        public static List<User> Users
        {
            get
            {
                List<User> user = new List<User>();
                int i = 1;
                var TestFirstName = ConfigurationForTestData[$"Users:user{i}:FirstName"];
                while (TestFirstName != null)
                {
                    user.Add(new User(ConfigurationForTestData[$"Users:user{i}:FirstName"], ConfigurationForTestData[$"Users:user{i}:LastName"], ConfigurationForTestData[$"Users:user{i}:Email"], ConfigurationForTestData[$"Users:user{i}:Age"], ConfigurationForTestData[$"Users:user{i}:Salary"], ConfigurationForTestData[$"Users:user{i}:Departament"]));
                    i++;
                    TestFirstName = ConfigurationForTestData[$"Users:user{i}:FirstName"];
                }
                return user;
            }
        }

        public static string ExpectedTextAlert => ConfigurationForTestData[NameExpectedTextAlert];
        public static string ExpectedTextAlertTime => ConfigurationForTestData[NameExpectedTextAlertTime];
        public static string ExpectedTextAlertApper => ConfigurationForTestData[NameExpectedTextAlertApper];
        public static string ExpectedTextAlertPromt => ConfigurationForTestData[NameExpectedTextAlertPromt];
        private const string PathToTestJson = "Test.json";
        private static IConfiguration config;

        public static List<User> getUsers()
        {
            return Users;
        }
    }
}
