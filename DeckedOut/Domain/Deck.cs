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

        public virtual int NumberOf(Slide slide)
        {
            var index = Slides.IndexOf(slide);

            if (index == -1)
                throw new ArgumentException("The specified slide is not a member of this deck.");

            return index + 1;
        }

        public virtual Slide Slide(int number)
        {
            if (number > Slides.Count || number < 1)
                throw new ArgumentOutOfRangeException();

            return Slides[number - 1];
        }
    }
}