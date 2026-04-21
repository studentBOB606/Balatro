using System;
using System.Collections.Generic;
using System.Linq;
using Cards;
using KlasUitwerking.HandCombinations;

namespace KlasUitwerking
{
    public class Score
    {
        public int TotalScore { get; private set; }
        public string CombinationName { get; private set; } = string.Empty;

        private List<IHandCombination> combinations = new List<IHandCombination>
        {
            new Pair()
        };

        public Score()
        {
            TotalScore = 0;
        }

        public void CalculateScore(List<Card> hand)
        {
            TotalScore = 0;
            CombinationName = string.Empty;

            if (hand.Count == 0) return;

            int cardSum = hand.Select(c => (int)c.Value).Sum();

            foreach (var combo in combinations)
            {
                if (combo.Matches(hand))
                {
                    TotalScore = cardSum * combo.Multiplier;
                    CombinationName = combo.CombinationName;
                    return;
                }
            }

            TotalScore = cardSum;
        }
    }
}

