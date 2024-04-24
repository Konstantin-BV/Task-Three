namespace Task3.Framework
{
    public abstract class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            Driver.getInstance();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
