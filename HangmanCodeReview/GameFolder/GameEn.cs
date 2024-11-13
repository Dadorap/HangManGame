using HangmanGame.Interface;
using HangmanGame.WrodGen;

namespace HangmanGame.GameFolder
{
    public class GameEn : IGame
    {
        private IGeneratWord _wordToGuess;
        private IHangMan _hangMan;

        public GameEn(IGeneratWord _genWord, IHangMan _hangman)
        {
            _wordToGuess = _genWord;
            _hangMan = _hangman;
        }
        public void GameOn()
        {
            
            Console.Clear();
            int lives = 6;
            var wordToGuess = _wordToGuess.Word();
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
                char guess = Console.ReadLine().ToLower()[0];

                if (guessedLetters.Contains(guess))
                {
                    Console.Clear();
                    Console.WriteLine("You have already guessed that letter. Try again.");
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
                    Console.WriteLine("Correct guess!");
                }
                else
                {
                    lives--;
                    Console.Clear();
                    Console.WriteLine("Wrong guess! You lost a life.");
                }
                state = lives > 0 && new string(guessedWord) != wordToGuess.ToLower();
            }

            if (new string(guessedWord) == wordToGuess)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nCongratulations! You guessed the word: {wordToGuess}");
                Console.ResetColor();
                Console.Write("Press any key to retun to menu...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"\nUnfortunately, you have no lives left. The word was: {wordToGuess}");
                Console.ResetColor();
                Console.Write("Press any key to return to the menu...");
                Console.ReadKey();
            }
        }
    }
}
