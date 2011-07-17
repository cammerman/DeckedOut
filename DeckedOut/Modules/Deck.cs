using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jessica;
using DeckedOut.ViewModels;
using DeckedOut.Domain;

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
    }
}