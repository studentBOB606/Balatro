using System;
using System.Collections.Generic;
using System.Linq;
using Cards;

namespace KlasUitwerking.HandCombinations
{
    public class FullHouse : IHandCombination
    {
        public string CombinationName => "Full House";
        public int BaseScore => 200;
        public int Multiplier => 4;

        public bool Matches(List<Card> hand)
        {
            var groups = hand.Select(c => (int)c.Value)
                .GroupBy(v => v)
                .ToList();
            return groups.Any(g => g.Count() == 3) && groups.Any(g => g.Count() == 2);
        }
    }
}
