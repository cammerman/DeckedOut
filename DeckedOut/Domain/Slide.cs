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
            _lines = new List<Line>();
        }

        private List<Line> _lines;

        public virtual List<Line> Lines
        {
            get { return _lines; }
            set { _lines = value ?? new List<Line>(); }
        }
    }
}