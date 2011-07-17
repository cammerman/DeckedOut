using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckedOut.Domain;

namespace DeckedOut.Services
{
    public interface IMarkdown
    {
        Slide Parse(string markdown);
        string Render(Slide slide);
    }
}
