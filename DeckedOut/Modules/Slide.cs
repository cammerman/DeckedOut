using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jessica;

namespace DeckedOut.Modules
{
    public class Slide : JessModule
    {
        public Slide()
        {
            Get(
                "Deck/:deckId/Slide/:slideNumber",
                p => View(
                    "Slide/Show",
                    new ViewModels.Slide() {
                        DeckName = "Pechakucha",
                        Number = Convert.ToInt32(p.slideNumber),
                        Text = String.Format("Slide {0}", p.slideNumber) }));

            Get(
                "Deck/:deckId/Slide/:slideNumber/Edit",
                p => View(
                    "Slide/Edit",
                    new ViewModels.Slide()
                    {
                        DeckName = "Pechakucha",
                        Number = Convert.ToInt32(p.slideNumber),
                        Text = String.Format("Slide {0}", p.slideNumber)
                    }));
        }
    }
}