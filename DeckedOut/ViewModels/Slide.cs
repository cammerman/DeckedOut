using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckedOut.ViewModels
{
    public class Slide
    {
        public virtual string DeckName { get; set; }
        public virtual int Number { get; set; }
        public virtual string Text { get; set; }
    }
}