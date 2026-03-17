using System;
using System.Collections.Generic;
using System.Text;

namespace Cards
{
    public class Card
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
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return $"{(int)Value} {Suit}";
        }
    }
}

