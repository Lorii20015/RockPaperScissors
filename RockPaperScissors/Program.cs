using System;
using System.Collections.Generic;

namespace RockPaperScissors
{
    class Program
    {
        static string intro = "Hello!\nWelcome to rock, paper, scissors! Try to win by predicting the computer!\n\n      rock\n    /     /\npaper <-- scissors\n\nStop playing at any time by typing 'back' or 'b'!\n(rock/R/paper/P/scissors/S)\n";
        static string hidden;
        static int end = 0;
        static int wins = 0;
        static int loses = 0;
        static int rounds = 1;
        static void Main(string[] args)
        {
            Console.WriteLine(intro);
            while (end != 1)
            {
                Console.WriteLine("Round " + rounds + "\n");
                GetRandomHidden();
                GetGuess();
                CompareHiddenAndGuess();
                ShowScoreBoard();
            }
        }
        static void GetRandomHidden()
        {
            Random random = new Random();
            int hiddenNum = random.Next(1, 100);
            if (hiddenNum < 33)
            {
                hidden = "Rock";
            }
            else if (hiddenNum > 66)
            {
                hidden = "Scissors";
            }
            else
            {
                hidden = "Paper";
            }
            Console.WriteLine("Computer chose, now your turn!");
        }
        static string input;
        static string guess;
        static void GetGuess()
        {
            while (guess != "Rock" || guess != "Paper" || guess != "Scissors" || guess !="back")
            {
                Console.WriteLine("Please, enter your guess:");
                input = Console.ReadLine().ToLower();
                if (input == "rock" || input == "r")
                {
                    guess = "Rock";
                    break;
                }
                else if (input == "paper" || input == "p")
                {
                    guess = "Paper";
                    break;
                }
                else if (input == "scissors" || input == "s")
                {
                    guess = "Scissors";
                    break;
                }
                else if (input == "back" || input == "b")
                {
                    guess = "back";
                    break;
                }
                else
                {
                    Console.WriteLine("Incorect format!\nTry again!");
                    continue;
                }
            }
        }
        static void CompareHiddenAndGuess()
        {
            if (hidden == guess)
            {
                Console.WriteLine("Your guess was " + guess + " and the computer picked... " + hidden + "!\nIt's a tie!");

            }
            else if ((hidden == "Rock" && guess == "Paper") || (hidden == "Paper" && guess == "Scissors") || (hidden == "Scissors" && guess == "Rock"))
            {
                Console.WriteLine("Your guess was " + guess + " and the computer picked... " + hidden + "!\nCongratulations!\nYou've predicted the computer and won this round!");
                wins = wins + 1;
                rounds++;
            }
            else if ((hidden == "Paper" && guess == "Rock") || (hidden == "Scissors" && guess == "Paper") || (hidden == "Rock" && guess == "Scissors"))
            {
                Console.WriteLine("Your guess was " + guess + " and the computer picked... " + hidden + "!\nYou've failed to predict the computer this round.\nBetter luck next time!");
                loses = loses + 1;
                rounds++;
            }
            else if (guess == "back")
            {
                Console.WriteLine("You chose to stop playing!");
                end++;
            }
            else
            {

            }
        }
        static void ShowScoreBoard()
        {
            if (guess != "back")
            {
                Console.WriteLine("\nThe score is ... " + wins + ":" + loses + "\n");
            }
        }
    }
} 