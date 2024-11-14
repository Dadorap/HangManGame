using HangmanGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame.GameFolder
{
    internal class WordReveal : IWordReveal
    {
        public void RevealTwoRandomLetters(string wordToGuess, char[] guessedWord)
        {
            Random random = new Random();
            int index1 = random.Next(wordToGuess.Length);
            int index2;

            do
            {
                index2 = random.Next(wordToGuess.Length);
            } while (index2 == index1);

            guessedWord[index1] = wordToGuess[index1];
            guessedWord[index2] = wordToGuess[index2];
        }
    }
}
