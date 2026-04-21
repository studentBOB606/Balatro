using System;
using System.Collections.Generic;
using Cards;

namespace KlasUitwerking
{
   
    public interface IHandCombination
    {
        string CombinationName { get; }
        int BaseScore { get; }
        int Multiplier { get; }
        bool Matches(List<Card> hand);
    }
}
