using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Bootstrapper;

namespace Nancy.Docs
{
    public class DocsRegistrations : Registrations
    {
        public DocsRegistrations()
        {
            Register<IPageIdentifier>();
        }
    }
}
