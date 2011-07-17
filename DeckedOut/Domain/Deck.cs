using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckedOut.Domain
{
    [Serializable]
    public class Deck
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual List<Slide> Slides { get; set; }
    }
}