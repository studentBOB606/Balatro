using System;
using System.Collections.Generic;
using System.Linq;
using Cards;

namespace KlasUitwerking
{
    public class Model
    {
        public Deck Deck { get; private set; }
        public PlayerHand PlayerHand { get; private set; }
        public int TotalScore { get; set; }
        public int CurrentGoal { get; set; }
        public int GoalIndex { get; set; }
        public int[] Goals { get; private set; }

        public Model()
        {
            Deck = new Deck();
            PlayerHand = new PlayerHand(8);
            TotalScore = 0;
            Goals = new int[] { 100, 250, 500 };
            GoalIndex = 0;
            CurrentGoal = Goals[0];
        }

        public void DrawCardsToFillHand()
        {
            if (PlayerHand.Hand.Count < 8)
            {
                int cardsToDraw = 8 - PlayerHand.Hand.Count;
                var drawnCards = Deck.DrawMultiple(cardsToDraw);
                foreach (var card in drawnCards)
                {
                    PlayerHand.AddCard(card);
                }
            }
        }

        public void PlaySelectedCards()
        {
            var selectedCards = PlayerHand.GetSelected();
            if (selectedCards.Count == 0)
                return;

            var score = new Score();
            score.CalculateScore(selectedCards);
            TotalScore += score.TotalScore;

            if (TotalScore >= CurrentGoal)
            {
                GoalIndex++;
                if (GoalIndex < Goals.Length)
                {
                    CurrentGoal = Goals[GoalIndex];
                }
            }

            PlayerHand.RemoveSelected();
        }

        public bool IsGameOver()
        {
            return PlayerHand.Hand.Count == 0 && TotalScore < CurrentGoal;
        }

        public List<Card> GetSelectedCards()
        {
            return PlayerHand.GetSelected();
        }

        public void SelectCard(int index)
        {
            PlayerHand.SelectCard(index - 1);
        }

        public void DeselectCard(int index)
        {
            PlayerHand.DeselectCard(index - 1);
        }

        public void ClearSelection()
        {
            PlayerHand.SelectedIndexes.Clear();
        }
    }
}
