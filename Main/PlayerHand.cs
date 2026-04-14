using System;
using System.Collections.Generic;
using System.Linq;
using Cards;

namespace KlasUitwerking
{
    public class PlayerHand
    {
        public List<Card> Hand { get; set; }
        public int MaxCards { get; private set; }
        public List<int> SelectedIndexes { get; private set; }

        public PlayerHand(int maxCards)
        {
            MaxCards = maxCards;
            Hand = new List<Card>();
            SelectedIndexes = new List<int>();
        }

        public void AddCard(Card newCard)
        {
            Hand.Add(newCard);
        }

        public void SelectCard(int index)
        {
            if (index < 0 || index >= Hand.Count) return;
            if (!SelectedIndexes.Contains(index)) SelectedIndexes.Add(index);
        }

        public void DeselectCard(int index)
        {
            SelectedIndexes.Remove(index);
        }

        public List<Card> GetSelected()
        {
            return Hand
                .Where((card, idx) => SelectedIndexes.Contains(idx))
                .ToList();
        }

        public void RemoveSelected()
        {
            Hand = Hand
                .Where((card, idx) => !SelectedIndexes.Contains(idx))
                .ToList();
            SelectedIndexes.Clear();
        }
    }
}

