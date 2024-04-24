namespace Task3.Framework.Elements
{
    internal class Button : BaseElement
    {
        string locator;
        string name;

        public Button(string locator, string name) : base(locator, name)
        {
            this.locator = locator;
            this.name = name;
        }
    }
}
