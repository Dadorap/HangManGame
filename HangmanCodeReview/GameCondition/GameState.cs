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
            string congrats = @"                                 _       
                                | |      
  ___ ___  _ __   __ _ _ __ __ _| |_ ___ 
 / __/ _ \| '_ \ / _` | '__/ _` | __/ __|
| (_| (_) | | | | (_| | | | (_| | |_\__ \
 \___\___/|_| |_|\__, |_|  \__,_|\__|___/
                  __/ |                  
                 |___/ ";
            string gameOver = @"
 ██████╗  █████╗ ███╗   ███╗███████╗     ██████╗ ██╗   ██╗███████╗██████╗ 
 ██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██╔═══██╗██║   ██║██╔════╝██╔══██╗
 ██║  ███╗███████║██╔████╔██║█████╗      ██║   ██║██║   ██║█████╗  ██████╔╝
 ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║   ██║██║   ██║██╔══╝  ██╔══██╗
 ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ╚██████╔╝╚██████╔╝███████╗██║  ██║
 ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝     ╚═════╝  ╚═════╝ ╚══════╝╚═╝  ╚═╝
                               ";

            if (lang == "swe")
            {
                if (new string(guessedWord) == wordToGuess)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(congrats);
                    Console.WriteLine($"\nGrattis! Du gissade ordet: {wordToGuess}\nMed {lives} liv kvar.");
                    Console.ResetColor();
                    Console.Write("Tryck på valfri tangent för att återgå till menyn...");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(gameOver);
                    Console.ResetColor();
                    Console.WriteLine($"\nTyvärr, du har {lives} liv kvar. Ordet var: {wordToGuess}");
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
                    Console.WriteLine(congrats);
                    Console.WriteLine($"\nCongratulations! You guessed the word: {wordToGuess}\nWith {lives} lives remaining.");
                    Console.ResetColor();
                    Console.Write("Press any key to return to the menu...");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(gameOver);
                    Console.WriteLine($"\nUnfortunately, you have {lives} lives left. The word was: {wordToGuess}");
                    Console.ResetColor();
                    Console.Write("Press any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}
