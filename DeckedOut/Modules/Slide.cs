﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jessica;
using DeckedOut.Domain;
using System.Web.Script.Serialization;
using System.Text;
using MarkdownSharp;
using Autofac.Features.OwnedInstances;

namespace DeckedOut.Modules
{
    public class Slide : JessModule
    {
        protected virtual Func<Owned<IDeckRepository>> Repository { get; private set; }
        protected virtual Markdown Markdown { get; private set; }

        public Slide(Func<Owned<IDeckRepository>> repository, Markdown markdown)
        {
            Repository = repository;
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

        protected virtual string AddSlide(dynamic p)
        {
            using (var repo = Repository().Value)
            {
                Domain.Deck deck = GetDeck(repo, p.deckId);
                var slideNumber = Convert.ToInt32((string)p.slideNumber);

                if (slideNumber < 0)
                    slideNumber = 0;
                else if (slideNumber > deck.Slides.Count + 1)
                    slideNumber = deck.Slides.Count + 1;

                deck.AddSlide(slideNumber);
            }

            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(new { success = true });
        }

        protected virtual string RemoveSlide(dynamic p)
        {
            using (var repo = Repository().Value)
            {
                Domain.Deck deck = GetDeck(repo, p.deckId);
                var slideNumber = Convert.ToInt32((string)p.slideNumber);

                deck.RemoveSlide(slideNumber);
            }

            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(new { success = true });
        }

        protected virtual string SaveContent(dynamic p)
        {
            using (var repo = Repository().Value)
            {
                var deck = GetDeck(repo, p.deckId);
                var slide = GetDeckSlide(deck, p.slideNumber);

                slide.Content = HttpUtility.HtmlDecode((string)p.content);
            }

            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(new { success = true });
        }

        protected virtual Domain.Line MapToLine(string lineContent)
        {
            return new Domain.Line { Content = lineContent };
        }

        protected virtual ViewModels.SlideForm MapToFormModel(int deckId, int slideNumber)
        {
            using (var repo = Repository().Value)
            {
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
        }

        protected virtual ViewModels.SlideForm MapToFormModel(Domain.Deck deck, Domain.Slide slide)
        {
            return new ViewModels.SlideForm
            {
                DeckName = deck.Name,
                SlideNumber = deck.NumberOf(slide),
                Content = slide.Content,
                DeckId = deck.Id
            };
        }

        protected virtual ViewModels.Slide MapToModel(int deckId, int slideNumber)
        {
            using (var repo = Repository().Value)
            {
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
        }

        protected virtual ViewModels.Slide MapToModel(Domain.Deck deck, Domain.Slide slide)
        {
            return new ViewModels.Slide {
                DeckName = deck.Name,
                SlideNumber = deck.NumberOf(slide),
                Content = new HtmlString(Markdown.Transform(slide.Content)),
                DeckId = deck.Id
            };
        }
    }
}