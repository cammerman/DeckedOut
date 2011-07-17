using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jessica;
using DeckedOut.ViewModels;

namespace DeckedOut.Modules
{
    public class Deck : JessModule
    {
        public Deck()
        {
            Get(
                "/Deck",
                p => View(
                    "Deck/Index",
                    new DeckList() {
                        Decks = new[] {
                            new ViewModels.Deck { Id = 1, Name = "Intro to .NET Micro Web Frameworks, via JessicaFx" },
                            new ViewModels.Deck { Id = 2, Name = "Unit Testing Patterns and Practices" }
                            }
                        }));

            Get("/Deck/New", p => null);
        }
    }
}