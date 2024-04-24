using Task3.Framework;

namespace Task3
{
    internal class NestedFrames : BasePage
    {
        private const string locator = "//*[@id='frame1']";
        private const string name = "NestedFramesPage";
        private const string LocatorNestedFrames = "//*[@id='frame1']";
        private const string LocatorSecondFrames = "//*[@srcdoc ='<p>Child Iframe</p>']";
        private const string LocatorTextParent = "//*[contains(text(),'Parent frame')]";
        private const string LocatorTextChild = "//*[contains(text(),'Child Iframe')]";

        public NestedFrames() : base(locator, name) { }

        public Boolean IsFirstForm()
        {
            Driver.GoToDefaultContent();
            var IsContainerFirstFrame = Driver.FindEliment(LocatorTextParent, LocatorNestedFrames).Displayed;
            Driver.GoToDefaultContent();
            if (IsContainerFirstFrame) { Driver.getInstance().SwitchTo().DefaultContent(); return true; }
            else { return false; }
        }

        public Boolean IsSecondForm()
        {
            Driver.GoToDefaultContent();
            Driver.GoToIframe(LocatorNestedFrames);
            var IsContainerSecondFrame = Driver.FindEliment(LocatorTextChild, LocatorSecondFrames).Displayed;
            Driver.GoToDefaultContent();
            if (IsContainerSecondFrame) { Driver.getInstance().SwitchTo().DefaultContent(); return true; }
            else { Driver.getInstance().SwitchTo().DefaultContent();  return false; }
        }
    }
}
