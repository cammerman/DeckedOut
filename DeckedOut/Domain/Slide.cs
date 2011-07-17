using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckedOut.Domain
{
    [Serializable]
    public class Slide
    {
        public virtual List<Line> Lines { get; set; }
    }
}