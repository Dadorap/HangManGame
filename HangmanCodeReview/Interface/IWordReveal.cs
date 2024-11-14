using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame.Interface
{
    public interface IWordReveal
    {
        void RevealTwoRandomLetters(string wordToGuess, char[] guessedWord);
    }
}
