using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jessica;
using DeckedOut.ViewModels;
using DeckedOut.Domain;
using System.Web.Script.Serialization;

namespace DeckedOut.Modules
{
    public class Deck : JessModule
    {
        protected virtual IDeckRepository Repository { get; private set; }

        public Deck(IDeckRepository repository)
        {
            Repository = repository;

            //new DeckList() {
            //    Decks = new[] {
            //        new ViewModels.Deck { Id = 1, Name = "Intro to .NET Micro Web Frameworks, via JessicaFx" },
            //        new ViewModels.Deck { Id = 2, Name = "Unit Testing Patterns and Practices" }
            //        }
            //    }

            Get(
                "/Deck",
                p => View(
                    "Deck/Index",
                    GetListModel()));

            Post(
                "/Deck/New",
                p => CreateDeck(p));
        }

        protected virtual DeckList GetListModel()
        {
            return 
                new DeckList {
                    Decks =
                        Repository.GetAll()
                        .Select(this.MapToModel)
                        .ToList() };
        }

        protected virtual ViewModels.Deck MapToModel(Domain.Deck domain)
        {
            return new ViewModels.Deck  {
                Id = domain.Id,
                Name = domain.Name };
        }

        protected virtual string CreateDeck(dynamic args)
        {
            var serializer = new JavaScriptSerializer();

            try
            {
                var newDeck = new Domain.Deck() { Name = args.name };
                newDeck.Slides.Add(new Domain.Slide());
                Repository.Add(newDeck);
                
                return serializer.Serialize(new { success = true, id = newDeck.Id });
            }
            catch (Exception ex)
            {
                return serializer.Serialize(new { success = false, message = ex.Message });
            }
        }
    }
}