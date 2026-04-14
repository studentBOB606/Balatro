using System;
using System.Collections.Generic;
using System.Linq;
using Cards;

namespace KlasUitwerking.HandCombinations
{
    public class Flush : IHandCombination
    {
        public string CombinationName => "Flush";
        public int BaseScore => 175;
        public int Multiplier => 4;

        public bool Matches(List<Card> hand)
        {
            return hand.Select(c => c.Suit).Distinct().Count() == 1;
        }
    }
}
