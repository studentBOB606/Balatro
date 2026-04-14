using System;
using System.Collections.Generic;
using Cards;

namespace KlasUitwerking
{
    /// <summary>
    /// Interface for validating poker hand combinations
    /// </summary>
    public interface IHandCombination
    {
        string CombinationName { get; }
        int BaseScore { get; }
        int Multiplier { get; }
        bool Matches(List<Card> hand);
    }
}
