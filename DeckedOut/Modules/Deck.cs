using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jessica;
using DeckedOut.ViewModels;
using DeckedOut.Domain;
using System.Web.Script.Serialization;
using Autofac.Features.OwnedInstances;
using Jessica.Responses;

namespace DeckedOut.Modules
{
    public class Deck : JessModule
    {
        protected virtual Func<Owned<IDeckRepository>>  Repository { get; private set; }

        public Deck(Func<Owned<IDeckRepository>> repository)
        {
            Repository = repository;

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
            using (var repo = Repository().Value)
            {
                return
                    new DeckList {
                        Decks =
                            repo.GetAll()
                                .Select(this.MapToModel)
                                .ToList()
                    };
            }
        }

        protected virtual ViewModels.Deck MapToModel(Domain.Deck domain)
        {
            return new ViewModels.Deck  {
                Id = domain.Id,
                Name = domain.Name };
        }

        protected virtual Response CreateDeck(dynamic args)
        {
            //var serializer = new JavaScriptSerializer();
            
            try
            {
                var newDeck = new Domain.Deck() { Name = args.name };
                newDeck.Slides.Add(new Domain.Slide());

                using (var repo = Repository().Value)
                {
                    repo.Add(newDeck);
                }

                return Response.AsJson(new { success = true, id = newDeck.Id });
                //return serializer.Serialize(new { success = true, id = newDeck.Id });
            }
            catch (Exception ex)
            {
                return Response.AsJson(new { success = false, message = ex.Message });
                //return serializer.Serialize(new { success = false, message = ex.Message });
            }
        }
    }
}