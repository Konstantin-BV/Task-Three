using Task3.Framework;

namespace Task3
{
    internal class FormsPage : BasePage
    {
        private const string locator = "//*[@id='frame1']";
        private const string name = "NestedFramesPage";
        private const string LocatorNestedFrame = "//*[@id='frame1']";
        private const string LocatorSecondFrame = "//*[@id='frame2']";
        private const string LocatorFirstFrame = "//*[@id=\"sampleHeading\"]";

        public FormsPage() : base(locator, name) { }

        public string FirstForm()
        {
            var FormText = Driver.FindEliment(LocatorFirstFrame, LocatorNestedFrame).Text;
            Driver.getInstance().SwitchTo().DefaultContent();
            return FormText;
        }

        public string SecondText()
        {
            var FormText = Driver.FindEliment(LocatorFirstFrame, LocatorSecondFrame).Text;
            return FormText;
        }
    }
}
