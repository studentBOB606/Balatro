using System;
using System.Collections.Generic;
using System.Linq;
using Cards;

namespace KlasUitwerking.HandCombinations
{
    public class Straight : IHandCombination
    {
        public string CombinationName => "Straight";
        public int BaseScore => 150;
        public int Multiplier => 4;

        public bool Matches(List<Card> hand)
        {
            var values = hand.Select(c => (int)c.Value).Distinct().OrderBy(v => v).ToList();
            if (values.Count < 5) return false;
            for (int i = 0; i < values.Count - 4; i++)
            {
                if (values[i + 4] - values[i] == 4)
                    return true;
            }
            return false;
        }
    }
}
