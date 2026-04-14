using System;
using System.Collections.Generic;
using System.Linq;
using Cards;

namespace KlasUitwerking
{
    class ViewModel
    {
        private Model Model;
        private List<Card> CardsInHand = new List<Card>();
        private List<int> SelectedCards = new List<int>();
        private Score scoreCalculator = new Score();
        private IGameUI gameUI;
        private List<Card> PlayedCardsThisRound = new List<Card>();
        private int CumulativeRoundScore = 0;

        public ViewModel(Model model, IGameUI ui)
        {
            this.Model = model;
            this.gameUI = ui;
            this.UpdateFromModel();
        }

        public void UpdateFromModel()
        {
            this.CardsInHand = new List<Card>(this.Model.PlayerHand.Hand);
            this.SelectedCards = new List<int>(this.Model.PlayerHand.SelectedIndexes);
        }

        public void RenderUI()
        {
            this.gameUI.ClearScreen();
            this.gameUI.DisplayGameTitle();
            this.gameUI.DisplayCurrentGoal(this.Model.CurrentGoal, this.Model.TotalScore);
            this.gameUI.DisplayHand(this.CardsInHand, this.SelectedCards);
            this.gameUI.DisplayInstructions();

            var selectedCardsList = this.Model.GetSelectedCards();
            scoreCalculator.CalculateScore(selectedCardsList);
            this.gameUI.DisplaySelectedCardsPreview(selectedCardsList, scoreCalculator.TotalScore);

            if (this.PlayedCardsThisRound.Count > 0)
            {
                this.gameUI.DisplayCumulativeScoreBreakdown(this.PlayedCardsThisRound, this.CumulativeRoundScore);
            }
        }

        public void HandleUserInput()
        {
            var input = this.gameUI.GetUserInput("\nEnter command: ");

            if (input == "quit")
            {
                this.gameUI.DisplayMessage("Thanks for playing!");
                Environment.Exit(0);
            }
            else if (input == "play")
            {
                this.PlaySelectedCards();
                this.gameUI.WaitForInput();
            }
            else if (input == "clear")
            {
                this.ClearSelection();
                this.gameUI.DisplayMessage("Deselected all cards");
                this.gameUI.WaitForInput();
            }
            else if (!string.IsNullOrEmpty(input))
            {
                this.SelectCards(input);
                this.gameUI.DisplayMessage("Cards selected");
                this.gameUI.WaitForInput();
            }

            this.UpdateFromModel();
        }

        public void Run()
        {
            this.gameUI.ClearScreen();
            this.gameUI.DisplayGameTitle();
            this.Model.DrawCardsToFillHand();

            while (true)
            {
                this.UpdateFromModel();

                if (this.Model.IsGameOver())
                {
                    this.gameUI.ClearScreen();
                    this.gameUI.DisplayGameOver(this.Model.TotalScore, this.Model.CurrentGoal);
                    this.gameUI.WaitForInput();
                    break;
                }

                this.RenderUI();
                this.HandleUserInput();
            }
        }

        private void SelectCards(string input)
        {
            var indices = input.Split(' ');
            foreach (var idx in indices)
            {
                if (int.TryParse(idx, out int cardIdx))
                {
                    this.Model.SelectCard(cardIdx);
                }
            }
        }

        private void PlaySelectedCards()
        {
            if (this.Model.GetSelectedCards().Count == 0)
            {
                this.gameUI.DisplayError("Select at least one card to play!");
                this.gameUI.WaitForInput();
                return;
            }

            int initialScore = this.Model.TotalScore;
            int previousGoal = this.Model.CurrentGoal;

            var playedCards = new List<Card>(this.Model.GetSelectedCards());

            this.Model.PlaySelectedCards();

            this.PlayedCardsThisRound.AddRange(playedCards);
            scoreCalculator.CalculateScore(playedCards);
            this.CumulativeRoundScore += scoreCalculator.TotalScore;

            this.UpdateFromModel();

            if (initialScore < previousGoal && this.Model.TotalScore >= previousGoal)
            {
                bool allGoalsCompleted = this.Model.GoalIndex >= this.Model.Goals.Length;

                if (!allGoalsCompleted)
                {
                    this.PlayedCardsThisRound.Clear();
                    this.CumulativeRoundScore = 0;
                    this.Model.DrawCardsToFillHand();
                    this.gameUI.ClearScreen();
                    this.gameUI.DisplayGameTitle();
                    int newGoal = this.Model.CurrentGoal;
                    this.gameUI.DisplayGoalReached(previousGoal, newGoal, false);
                    this.gameUI.WaitForInput();
                }
                else
                {
                    this.gameUI.ClearScreen();
                    this.gameUI.DisplayGameTitle();
                    this.gameUI.DisplayMessage("🎉 YOU'VE COMPLETED ALL GOALS! YOU WON! 🎉");
                    this.gameUI.WaitForInput();
                }
            }
        }

        private void ClearSelection()
        {
            this.Model.ClearSelection();
        }
    }
}
