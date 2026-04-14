using System;
using System.Collections.Generic;
using System.Linq;
using Cards;

namespace KlasUitwerking
{
    public class Score
    {
        public int TotalScore { get; private set; }

        public Score()
        {
            TotalScore = 0;
        }

        public void CalculateScore(List<Card> hand)
        {
            TotalScore = 0;

            if (hand.Count == 0) return;

            // Simple score: just sum all card values
            TotalScore = hand.Select(c => (int)c.Value).Sum();
        }
    }
}

