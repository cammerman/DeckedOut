using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Jessica;
using Jessica.ViewEngine.Razor;

namespace DeckedOut
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Jess.Initialise();
            Jess.ViewEngines.Add(new RazorViewEngine());
        }
    }
}