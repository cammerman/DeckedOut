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
        protected virtual Func<IDeckRepository> CreateRepository { get; private set; }

        public Deck(Func<IDeckRepository> createRepository)
        {
            CreateRepository = createRepository;

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
            var repo = CreateRepository();
            
            return
                new DeckList {
                    Decks =
                        repo.GetAll()
                            .Select(this.MapToModel)
                            .ToList()
                };
        }

        protected virtual ViewModels.Deck MapToModel(Domain.Deck domain)
        {
            return new ViewModels.Deck  {
                Id = domain.Id,
                Name = domain.Name };
        }

        protected virtual Response CreateDeck(dynamic args)
        {
            try
            {
                var newDeck = new Domain.Deck() { Name = args.name };
                newDeck.Slides.Add(new Domain.Slide());

                var repo = CreateRepository();
                repo.Add(newDeck);
                repo.Commit();

                return Response.AsJson(new { success = true, id = newDeck.Id });
            }
            catch (Exception ex)
            {
                return Response.AsJson(new { success = false, message = ex.Message });
            }
        }
    }
}