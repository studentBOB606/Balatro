using System;
using System.Collections.Generic;
using Cards;

namespace KlasUitwerking
{
    public class ConsoleGameUI : IGameUI
    {
        public void ClearScreen()
        {
            Console.Clear();
            try
            {
                if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
                {
                    Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
                }
            }
            catch
            {
                // If buffer size can't be set, just continue with regular clear
            }
        }

        public void DisplayGameTitle()
        {
            Console.WriteLine("=== BALATRO GAME ===\n");
        }

        public void DisplayCurrentGoal(int currentGoal, int totalScore)
        {
            int remaining = currentGoal - totalScore;
            string status = remaining <= 0 ? "✓ COMPLETE" : $"Need {remaining} more";
            Console.WriteLine($"╔════════════════════════════════════╗");
            Console.WriteLine($"║ GOAL: {currentGoal} points              │");
            Console.WriteLine($"║ Current Score: {totalScore}                   │");
            Console.WriteLine($"║ {status,-34}║");
            Console.WriteLine($"╚════════════════════════════════════╝");
        }

        public void DisplayHand(List<Card> hand, List<int> selectedIndexes)
        {
            Console.WriteLine("HAND:");
            for (int i = 0; i < hand.Count; i++)
            {
                string selection = selectedIndexes.Contains(i) ? "[x]" : "[ ]";
                Console.WriteLine($"  {selection} {i + 1}: {hand[i]}");
            }
        }

        public void DisplayInstructions()
        {
            Console.WriteLine("\n[enter numbers (1-8)] | play  |  clear  |  quit\n");
        }

        public void DisplaySelectedCardsPreview(List<Card> selectedCards, int previewScore)
        {
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║      SELECTED CARDS (PREVIEW)      ║");
            Console.WriteLine("╠════════════════════════════════════╣");
            foreach (var card in selectedCards)
            {
                Console.WriteLine($"║ → {card} ({(int)card.Value})");
            }
            Console.WriteLine("╠════════════════════════════════════╣");
            Console.WriteLine($"║ TOTAL SCORE: {previewScore}");
            Console.WriteLine("╚════════════════════════════════════╝");
        }

        public void DisplayScoreBreakdown(List<Card> hand, int totalScore)
        {
            Console.WriteLine("\n╔════════════════════════════════════╗");
            Console.WriteLine("║       SCORE BREAKDOWN              ║");
            Console.WriteLine("╠════════════════════════════════════╣");
            foreach (var card in hand)
            {
                Console.WriteLine($"║ {card}: {(int)card.Value} points");
            }
            Console.WriteLine("╠════════════════════════════════════╣");
            Console.WriteLine($"║ TOTAL SCORE: {totalScore}");
            Console.WriteLine("╚════════════════════════════════════╝");
        }

        public void DisplayCumulativeScoreBreakdown(List<Card> hand, int totalScore)
        {
            Console.WriteLine("\n╔════════════════════════════════════╗");
            Console.WriteLine("║   CUMULATIVE ROUND SCORE           ║");
            Console.WriteLine("╠════════════════════════════════════╣");
            foreach (var card in hand)
            {
                Console.WriteLine($"║ {card}: {(int)card.Value} points");
            }
            Console.WriteLine("╠════════════════════════════════════╣");
            Console.WriteLine($"║ ROUND TOTAL: {totalScore}");
            Console.WriteLine("╚════════════════════════════════════╝");
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayGoalReached(int goalScore, int newGoal, bool allGoalsCompleted)
        {
            Console.WriteLine($"╔════════════════════════════════════╗");
            Console.WriteLine($"║ 🎉 GOAL REACHED!                   ║");
            Console.WriteLine($"║ You reached {goalScore} points!          ║");
            if (!allGoalsCompleted)
            {
                Console.WriteLine($"║ 📈 New goal: {newGoal}              ║");
            }
            else
            {
                Console.WriteLine($"║ 🏆 All goals completed!            ║");
            }
            Console.WriteLine($"╚════════════════════════════════════╝\n");
        }

        public void DisplayEarnedPoints(int earnedPoints, int totalScore)
        {
            Console.WriteLine($"\n✦ You earned {earnedPoints} points!");
            Console.WriteLine($"✦ Total Score: {totalScore}\n");
        }

        public void DisplayError(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }

        public void DisplayGameOver(int finalScore, int goalScore)
        {
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║          GAME OVER                 ║");
            Console.WriteLine("╠════════════════════════════════════╣");
            Console.WriteLine($"║ Final Score: {finalScore}");
            Console.WriteLine($"║ Goal Score: {goalScore}");
            Console.WriteLine($"║ You were short by: {goalScore - finalScore} points");
            Console.WriteLine("║                                    ║");
            Console.WriteLine("║ Better luck next time!             ║");
            Console.WriteLine("╚════════════════════════════════════╝\n");
        }

        public string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine()?.ToLower() ?? string.Empty;
        }

        public void WaitForInput()
        {
            Console.ReadKey();
        }
    }
}
