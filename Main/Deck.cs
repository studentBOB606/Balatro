using System;
using System.Collections.Generic;
using System.Linq;
using Cards;

namespace KlasUitwerking
{
    public class Deck
    {
        private List<Card> cards;
        private Random random;

        public int CardsRemaining => cards.Count;

        public Deck()
        {
            cards = new List<Card>();
            random = new Random();
            InitializeDeck();
            Shuffle();
        }

        private void InitializeDeck()
        {
            foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cards.Add(new Card(value, suit));
                }
            }
        }

        public void Shuffle()
        {
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int randomIndex = random.Next(i + 1);
                (cards[i], cards[randomIndex]) = (cards[randomIndex], cards[i]);
            }
        }

        public Card? Draw()
        {
            if (CardsRemaining == 0)
            {
                return null;
            }

            Card drawnCard = cards[0];
            cards.RemoveAt(0);
            return drawnCard;
        }

        public List<Card> DrawMultiple(int count)
        {
            List<Card> drawnCards = new List<Card>();
            for (int i = 0; i < count && CardsRemaining > 0; i++)
            {
                Card? drawnCard = Draw();
                if (drawnCard != null)
                {
                    drawnCards.Add(drawnCard);
                }
            }
            return drawnCards;
        }

        public void Reset()
        {
            cards.Clear();
            InitializeDeck();
            Shuffle();
        }
    }
}
