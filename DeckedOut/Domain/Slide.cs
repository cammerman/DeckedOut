using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckedOut.Domain
{
    [Serializable]
    public class Slide
    {
        public Slide()
        {
            Content = "";
            Source = "";
        }

        public virtual string Content { get; set; }
        public virtual string Source { get; set; }
    }
}