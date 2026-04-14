using System;
using System.Collections.Generic;
using Cards;

namespace KlasUitwerking.HandCombinations
{
    public class HighCard : IHandCombination
    {
        public string CombinationName => "High Card";
        public int BaseScore => 5;
        public int Multiplier => 1;

        public bool Matches(List<Card> hand)
        {
            return true;
        }
    }
}
