using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Jessica;
using Jessica.ViewEngine.Razor;
using DeckedOut.Infrastructure;

namespace DeckedOut
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Jess.ViewEngines.Add(new RazorViewEngine());
            Jess.Factory = new AutofacJessicaFactory(AutofacConfig.Configure());
            Jess.Initialise();
        }
    }
}