using System;
using System.Collections.Generic;
using System.Linq;
using Cards;

namespace KlasUitwerking.HandCombinations
{
    public class Pair : IHandCombination
    {
        public string CombinationName => "Pair";
        public int BaseScore => 50;
        public int Multiplier => 2;

        public bool Matches(List<Card> hand)
        {
            return hand.GroupBy(c => c.Value).Any(g => g.Count() >= 2);
        }
    }
}
