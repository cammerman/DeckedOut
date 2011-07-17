using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckedOut.Domain;

namespace DeckedOut.Services
{
    public interface IRenderHtml
    {
        string Render(Slide slide);
    }
}
