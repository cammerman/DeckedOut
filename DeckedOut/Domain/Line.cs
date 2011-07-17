using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace DeckedOut.Domain
{
    [Serializable]
    public class Line
    {
        public virtual Color TextColor { get; set; }
        public virtual int Size { get; set; }
        public virtual int IndentDepth { get; set; }

        public virtual ListMembership ListMembership { get; set; }
    }
}