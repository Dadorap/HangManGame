﻿using HangmanGame.Interface;

namespace HangmanGame.GameFolder
{
    public class GameSe : IGame
    {
        private IGeneratWord _wordToGuessSe;
        private IHangMan _hangMan;
        private IGameState _gameState;
        private IWordReveal _wordReveal;
        public GameSe(IGeneratWord _wordToGuessSe, IHangMan _hangMan, IGameState _gameState, IWordReveal _wordReveal)
        {
            this._wordToGuessSe = _wordToGuessSe;
            this._hangMan = _hangMan;
            this._gameState = _gameState;
            this._wordReveal = _wordReveal;
        }
        public void GameOn()
        {

            Console.Clear();
            int lives = 6;
            var wordToGuess = _wordToGuessSe.Word();
            var hangMan = _hangMan;

            char[] guessedWord = new string('_', wordToGuess.Length).ToCharArray();
            _wordReveal.RevealTwoRandomLetters(wordToGuess, guessedWord);

            List<char> guessedLetters = new List<char>();

            Console.WriteLine(wordToGuess);

            bool state = lives > 0;
            while (state)
            {
                hangMan.DisplayHangman(lives);

                Console.WriteLine("\nOrdet: " + new string(guessedWord));
                Console.WriteLine("Gissade bokstäver: " + string.Join(", ", guessedLetters));
                Console.Write("Gissa en bokstav (a-ö): ");
                string input = Console.ReadLine().ToLower();
                if (!string.IsNullOrEmpty(input) && char.TryParse(input[0].ToString(), out char guess) && input.Length == 1 && !char.IsDigit(guess))
                {

                    if (guessedLetters.Contains(guess))
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"Du har redan gissat på den bokstaven. Försök igen. Liv kvar: {lives}");
                        Console.ResetColor();
                        continue;
                    }

                    guessedLetters.Add(guess);

                    if (wordToGuess.Contains(guess))
                    {
                        for (int i = 0; i < wordToGuess.Length; i++)
                        {
                            if (wordToGuess[i] == guess)
                            {
                                guessedWord[i] = guess;
                            }
                        }
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"Rätt gissat! Liv kvar: {lives}");
                        Console.ResetColor();
                    }
                    else
                    {
                        lives--;
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Fel gissat! Du förlorade ett liv. Liv kvar: {lives}");
                        Console.ResetColor();
                    }
                    state = lives > 0 && new string(guessedWord) != wordToGuess.ToLower();
                }
                else
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltig inmatning försök igen...");
                    Console.ResetColor();
                }
            }
            _gameState.GameStatus(guessedWord, wordToGuess, lives, "swe");

        }
    }
}
