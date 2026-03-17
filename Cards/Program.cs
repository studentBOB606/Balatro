using System;
using System.Collections.Generic;
using Cards;

var deck = new List<Card>();

foreach (CardValue v in Enum.GetValues(typeof(CardValue)))
{
    foreach (Suit s in Enum.GetValues(typeof(Suit)))
    {
        deck.Add(new Card(v, s));
    }
}

Console.WriteLine($"Deck contains {deck.Count} cards:");
foreach (var card in deck)
{
    card.PrintMe();
}

Console.ReadKey();
