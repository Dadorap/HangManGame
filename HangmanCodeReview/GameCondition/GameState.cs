using HangmanGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame.GameCondition
{
    public class GameState : IGameState
    {
        public void GameStatus(char[] guessedWord, string wordToGuess, int lives, string lang)
        {
            if (lang == "swe")
            {
                if (new string(guessedWord) == wordToGuess)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Grattis! Du gissade ordet: {wordToGuess}\nMed {lives} liv kvar.");
                    Console.ResetColor();
                    Console.Write("Tryck på valfri tangent för att återgå till menyn...");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Tyvärr, du har {lives} liv kvar. Ordet var: {wordToGuess}");
                    Console.ResetColor();
                    Console.Write("Tryck på valfri tangent för att återgå till menyn...");
                    Console.ReadKey();
                }
            }
            else
            {
                if (new string(guessedWord) == wordToGuess)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Congratulations! You guessed the word: {wordToGuess}\nWith {lives} lives remaining.");
                    Console.ResetColor();
                    Console.Write("Press any key to return to the menu...");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Unfortunately, you have {lives} left. The word was: {wordToGuess}");
                    Console.ResetColor();
                    Console.Write("Press any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}
