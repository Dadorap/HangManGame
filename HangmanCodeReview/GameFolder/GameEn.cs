﻿using HangmanGame.Interface;
using HangmanGame.WrodGen;

namespace HangmanGame.GameFolder
{
    public class GameEn : IGame
    {
        private IGeneratWord _wordToGuessEn;
        private IHangMan _hangMan;
        private IGameState _gameState;

        public GameEn(IGeneratWord _wordToGuessEn, IHangMan _hangMan, IGameState _gameState)
        {
            this._wordToGuessEn = _wordToGuessEn;
            this._hangMan = _hangMan;
            this._gameState = _gameState;
        }
        public void GameOn()
        {

            Console.Clear();
            int lives = 6;
            var wordToGuess = _wordToGuessEn.Word();
            var hangMan = _hangMan;

            char[] guessedWord = new string('_', wordToGuess.Length).ToCharArray();
            bool state = lives > 0;

            List<char> guessedLetters = new List<char>();
            Console.WriteLine(wordToGuess);

            while (state)
            {
                hangMan.DisplayHangman(lives);

                Console.WriteLine("\nThe word: " + new string(guessedWord));
                Console.WriteLine("Guessed letters: " + string.Join(", ", guessedLetters));
                Console.Write("Guess a letter: ");
                string input = Console.ReadLine().ToLower();
                if (!string.IsNullOrEmpty(input) && char.TryParse(input[0].ToString(), out char guess) && input.Length == 1 && !char.IsDigit(guess))
                {

                    if (guessedLetters.Contains(guess))
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"You have already guessed that letter. Try again. Lives remaining: {lives}");
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
                        Console.WriteLine($"Correct guess! Lives remaining: {lives}");
                        Console.ResetColor();
                    }
                    else
                    {
                        lives--;
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Wrong guess! You lost a life. Lives remaining: {lives}");
                        Console.ResetColor();
                    }
                    state = lives > 0 && new string(guessedWord) != wordToGuess.ToLower();
                }
                else
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input...");
                    Console.ResetColor();
                }
            }
            _gameState.GameStatus(guessedWord, wordToGuess, lives, "eng");

        }


    }
}
