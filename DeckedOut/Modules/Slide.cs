using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jessica;
using DeckedOut.Domain;
using System.Web.Script.Serialization;
using System.Text;
using MarkdownSharp;
using Autofac.Features.OwnedInstances;
using Jessica.Responses;

namespace DeckedOut.Modules
{
    public class Slide : JessModule
    {
        protected virtual Func<IDeckRepository> CreateRepository { get; private set; }
        protected virtual Markdown Markdown { get; private set; }

        public Slide(Func<IDeckRepository> createRepository, Markdown markdown)
        {
            CreateRepository = createRepository;
            Markdown = markdown;

            Get(
                "Deck/:deckId/Slide/:slideNumber",
                p => View(
                    "Slide/Show",
                    MapToModel(
                        Convert.ToInt32((string)p.deckId),
                        Convert.ToInt32((string)p.slideNumber))
                    )
                );

            Get(
                "Deck/:deckId/Slide/:slideNumber/Edit",
                p => View(
                    "Slide/Edit",
                    MapToFormModel(
                        Convert.ToInt32((string)p.deckId),
                        Convert.ToInt32((string)p.slideNumber))
                    )
                );

            Post(
                "Deck/:deckId/Slide/:slideNumber/Remove",
                p => RemoveSlide(p));

            Post(
                "Deck/:deckId/Slide/:slideNumber/Edit",
                p => SaveContent(p));

            Post(
                "Deck/:deckId/Slide/:slideNumber/Add",
                p => AddSlide(p));
        }

        protected virtual Domain.Deck GetDeck(IDeckRepository repo, string deckId)
        {
            return repo.Get(Convert.ToInt32(deckId));
        }

        protected virtual Domain.Slide GetDeckSlide(Domain.Deck deck, string slideNumber)
        {
            return deck.Slide(Convert.ToInt32(slideNumber));
        }

        protected virtual Response AddSlide(dynamic p)
        {
            var repo = CreateRepository();
            
            Domain.Deck deck = GetDeck(repo, p.deckId);
            var slideNumber = Convert.ToInt32((string)p.slideNumber);

            if (slideNumber < 0)
                slideNumber = 0;
            else if (slideNumber > deck.Slides.Count + 1)
                slideNumber = deck.Slides.Count + 1;

            deck.AddSlide(slideNumber);

            repo.Commit();

            return Response.AsJson(new { success = true });
        }

        protected virtual Response RemoveSlide(dynamic p)
        {
            var repo = CreateRepository();
            
            Domain.Deck deck = GetDeck(repo, p.deckId);
            var slideNumber = Convert.ToInt32((string)p.slideNumber);

            deck.RemoveSlide(slideNumber);

            repo.Commit();

            return Response.AsJson(new { success = true });
        }

        protected virtual Response SaveContent(dynamic p)
        {
            var repo = CreateRepository();
            
            var deck = GetDeck(repo, p.deckId);
            var slide = GetDeckSlide(deck, p.slideNumber);

            slide.Source = HttpUtility.HtmlDecode((string)p.content);
            slide.Content = Markdown.Transform(slide.Source);

            repo.Commit();

            return Response.AsJson(new { success = true });
        }

        protected virtual Domain.Line MapToLine(string lineContent)
        {
            return new Domain.Line { Content = lineContent };
        }

        protected virtual ViewModels.SlideForm MapToFormModel(int deckId, int slideNumber)
        {
            var repo = CreateRepository();
            
            var deck = repo.Get(deckId);

            var model = MapToFormModel(deck, deck.Slide(slideNumber));

            if (slideNumber > 1)
                model.PreviousSlideNumber = slideNumber - 1;

            if (slideNumber < deck.Slides.Count)
            {
                model.NextSlideNumber = slideNumber + 1;
                model.LastSlideNumber = deck.Slides.Count;
            }

            return model;
        }

        protected virtual ViewModels.SlideForm MapToFormModel(Domain.Deck deck, Domain.Slide slide)
        {
            return new ViewModels.SlideForm
            {
                DeckName = deck.Name,
                SlideNumber = deck.NumberOf(slide),
                Source = slide.Source,
                DeckId = deck.Id
            };
        }

        protected virtual ViewModels.Slide MapToModel(int deckId, int slideNumber)
        {
            var repo = CreateRepository();
            
            var deck = repo.Get(deckId);

            var model = MapToModel(deck, deck.Slide(slideNumber));

            if (slideNumber > 1)
                model.PreviousSlideNumber = slideNumber - 1;

            if (slideNumber < deck.Slides.Count)
            {
                model.NextSlideNumber = slideNumber + 1;
            }

            return model;
        }

        protected virtual ViewModels.Slide MapToModel(Domain.Deck deck, Domain.Slide slide)
        {
            return new ViewModels.Slide {
                DeckName = deck.Name,
                SlideNumber = deck.NumberOf(slide),
                Content = new HtmlString(slide.Content),
                DeckId = deck.Id
            };
        }
    }
}