using System;
using System.Collections.Generic;
using System.Linq;
using Cards;

namespace KlasUitwerking.HandCombinations
{
    public class StraightFlush : IHandCombination
    {
        public string CombinationName => "Straight Flush";
        public int BaseScore => 500;
        public int Multiplier => 8;

        public bool Matches(List<Card> hand)
        {
            return IsStraight(hand) && IsFlush(hand);
        }

        private bool IsStraight(List<Card> hand)
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

        private bool IsFlush(List<Card> hand)
        {
            return hand.Select(c => c.Suit).Distinct().Count() == 1;
        }
    }
}
