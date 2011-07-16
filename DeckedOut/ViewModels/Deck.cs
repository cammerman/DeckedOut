using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeckedOut.ViewModels
{
    public class Deck
    {
        public virtual int? Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual DateTime? LastEdited { get; set; }
    }
}