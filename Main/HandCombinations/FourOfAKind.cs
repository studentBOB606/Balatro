using System;
using System.Collections.Generic;
using System.Linq;
using Cards;

namespace KlasUitwerking.HandCombinations
{
    public class FourOfAKind : IHandCombination
    {
        public string CombinationName => "Four of a Kind";
        public int BaseScore => 300;
        public int Multiplier => 7;

        public bool Matches(List<Card> hand)
        {
            return hand.Select(c => (int)c.Value)
                .GroupBy(v => v)
                .Any(g => g.Count() == 4);
        }
    }
}
