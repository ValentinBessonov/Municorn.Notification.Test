namespace Municorn.TestApp.Core
{
    public class ElementNotFoundException: Exception
    {
        public ElementNotFoundException(): base("Element not found")
        {
        }

        public ElementNotFoundException(string message): base(message)
        {
        }
    }
}
