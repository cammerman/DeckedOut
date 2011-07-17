using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckedOut.ViewModels
{
    public class Slide
    {
        public virtual string DeckName { get; set; }
        public virtual int SlideNumber { get; set; }
        public virtual string Content { get; set; }
    }
}