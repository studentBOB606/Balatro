using System;
using System.Collections.Generic;
using System.Text;
using KlasUitwerking;

namespace Cards
{
    public class Card : ICard
    {
        public CardValue Value { get; set; }
        public Suit Suit { get; set; }

        public Card(CardValue startValue, Suit startSuit)
        {
            this.Value = startValue;
            this.Suit = startSuit;
        }

        public void PrintMe()
        {
            System.Console.WriteLine(this.ToString());
        }

        public string MakeAsString()
        {
            return this.ToString();
        }

        public bool SatisfiesSuit(Suit suit)
        {
            return this.Suit == suit;
        }

        private string GetCardDisplayName()
        {
            if (this.Value == CardValue.Ace) return "A";
            if (this.Value == CardValue.Jack) return "J";
            if (this.Value == CardValue.Queen) return "Q";
            if (this.Value == CardValue.King) return "K";
            return ((int)this.Value).ToString();
        }

        public override string ToString()
        {
            return $"{GetCardDisplayName()} of {this.Suit}";
        }
    }
}

