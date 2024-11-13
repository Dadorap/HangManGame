using HangmanGame.Interface;
using HangmanGame.WrodGen;


namespace HangmanGame.GameFolder
{
    public class GameSe : IGame
    {
        private readonly IGeneratWord _wordToGuess;
        private IHangMan _hangMan;

        public GameSe(IGeneratWord _genWord, IHangMan _hangman)
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

                Console.WriteLine("\nOrdet: " + new string(guessedWord));
                Console.WriteLine("Gissade bokstäver: " + string.Join(", ", guessedLetters));
                Console.Write("Gissa en bokstav: ");
                char guess = Console.ReadLine().ToLower()[0];

                if (guessedLetters.Contains(guess))
                {
                    Console.Clear();
                    Console.WriteLine($"Du har redan gissat den bokstaven. Försök igen. Liv kvar {lives}");
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
                    Console.WriteLine($"Rätt gissat! Liv kvar {lives}");
                }
                else
                {
                    lives--;
                    Console.Clear();
                    Console.WriteLine($"Fel gissat! Du förlorade ett liv. Liv kvar {lives}");
                }
                state = lives > 0 && new string(guessedWord) != wordToGuess.ToLower();
            }

            if (new string(guessedWord) == wordToGuess)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nGrattis! Du gissade ordet: {wordToGuess}\nMed {lives} liv kvar.");
                Console.ResetColor();
                Console.Write("Tryck på valfri tangent för att återgå till menyn...");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"\nTyvärr, du har {lives} liv kvar. Ordet var: {wordToGuess}");
                Console.ResetColor();
                Console.Write("Tryck på valfri tangent för att återgå till menyn...");
                Console.ReadKey();
            }
        }
    }
}
