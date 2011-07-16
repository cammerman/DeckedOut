using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jessica;

namespace DeckedOut.Modules
{
    public class Home : JessModule
    {
        public Home()
        {
            Get("/", p => View("Home"));
        }
    }
}