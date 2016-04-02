using Nancy.Bootstrapper;

namespace Nancy.Docs
{
    public class DocsRegistrations : Registrations
    {
        public DocsRegistrations()
        {
            RegisterAll<IPageIdentifier>();
        }
    }
}
