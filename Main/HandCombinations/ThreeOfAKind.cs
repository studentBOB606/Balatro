using System;
using System.Collections.Generic;
using System.Linq;
using Cards;

namespace KlasUitwerking.HandCombinations
{
    public class ThreeOfAKind : IHandCombination
    {
        public string CombinationName => "Three of a Kind";
        public int BaseScore => 150;
        public int Multiplier => 3;

        public bool Matches(List<Card> hand)
        {
            return hand.Select(c => (int)c.Value)
                .GroupBy(v => v)
                .Any(g => g.Count() == 3);
        }
    }
}
