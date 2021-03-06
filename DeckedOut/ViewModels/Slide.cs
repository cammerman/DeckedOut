﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckedOut.ViewModels
{
    public class Slide
    {
        public virtual int DeckId { get; set; }
        public virtual string DeckName { get; set; }
        public virtual int SlideNumber { get; set; }
        public virtual HtmlString Content { get; set; }

        public virtual int? PreviousSlideNumber { get; set; }
        public virtual int? NextSlideNumber { get; set; }
    }
}