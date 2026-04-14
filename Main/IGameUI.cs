using System.Collections.Generic;
using Cards;

namespace KlasUitwerking
{
    interface IGameUI
    {
        void ClearScreen();
        void DisplayGameTitle();
        void DisplayCurrentGoal(int currentGoal, int totalScore);
        void DisplayHand(List<Card> hand, List<int> selectedIndexes);
        void DisplayInstructions();
        void DisplaySelectedCardsPreview(List<Card> selectedCards, int previewScore);
        void DisplayScoreBreakdown(List<Card> hand, int totalScore);
        void DisplayCumulativeScoreBreakdown(List<Card> hand, int totalScore);
        void DisplayMessage(string message);
        void DisplayGoalReached(int goalScore, int newGoal, bool allGoalsCompleted);
        void DisplayEarnedPoints(int earnedPoints, int totalScore);
        void DisplayError(string errorMessage);
        void DisplayGameOver(int finalScore, int goalScore);
        string GetUserInput(string prompt);
        void WaitForInput();
    }
}
