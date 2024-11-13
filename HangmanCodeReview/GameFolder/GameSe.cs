using HangmanGame.GameCondition;
using HangmanGame.Interface;
using HangmanGame.WrodGen;


namespace HangmanGame.GameFolder
{
    public class GameSe : IGame
    {
        private IGeneratWord _wordToGuessSe;
        private IHangMan _hangMan;
        private IGameState _gameState;

        public GameSe(IGeneratWord _wordToGuessSe, IHangMan _hangMan, IGameState _gameState)
        {
            this._wordToGuessSe = _wordToGuessSe;
            this._hangMan = _hangMan;
            this._gameState = _gameState;
        }
        public void GameOn()
        {
            Console.Clear();
            int lives = 6;
            var wordToGuess = _wordToGuessSe.Word();
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
                    Console.WriteLine($"You have already guessed that letter. Try again. Lives remaining: {lives}");
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
                    Console.WriteLine($"Correct guess! Lives remaining: {lives}");
                }
                else
                {
                    lives--;
                    Console.Clear();
                    Console.WriteLine($"Wrong guess! You lost a life. Lives remaining: {lives}");
                }
                state = lives > 0 && new string(guessedWord) != wordToGuess.ToLower();
            }

            _gameState.GameStatus(guessedWord, wordToGuess, lives, "eng");
        }



    }
}
