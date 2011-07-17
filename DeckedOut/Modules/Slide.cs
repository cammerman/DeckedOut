using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jessica;
using DeckedOut.Domain;

namespace DeckedOut.Modules
{
    public class Slide : JessModule
    {
        protected virtual IDeckRepository Repository { get; private set; }

        public Slide(IDeckRepository repository)
        {
            Repository = repository;
        
            Get(
                "Deck/:deckId/Slide/:slideNumber",
                p => View(
                    "Slide/Show",
                    MapToModel(p.deckId, p.slideNumber)));
                    
                    //new ViewModels.Slide() {
                    //    DeckName = "Pechakucha",
                    //    SlideNumber = Convert.ToInt32(p.slideNumber),
                    //    Content = String.Format("Slide {0}", p.slideNumber) }));

            Get(
                "Deck/:deckId/Slide/:slideNumber/Edit",
                p => View(
                    "Slide/Edit",
                    MapToModel(p.deckId, p.slideNumber)));
                    
                    //new ViewModels.SlideForm()
                    //{
                    //    DeckName = "Pechakucha",
                    //    SlideNumber = Convert.ToInt32(p.slideNumber),
                    //    Content = String.Format("Slide {0}", p.slideNumber)
                    //}));

        }

        protected virtual ViewModels.Slide MapToModel(int deckId, int slideNumber)
        {
            var deck = Repository.Get(deckId);

            return MapToModel(deck, deck.Slide(slideNumber));
        }

        protected virtual ViewModels.Slide MapToModel(Domain.Deck deck, Domain.Slide slide)
        {
            return new ViewModels.Slide {
                DeckName = deck.Name,
                SlideNumber = deck.NumberOf(slide),
                Content = "" }; 
        }
    }
}