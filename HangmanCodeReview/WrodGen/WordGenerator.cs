using HangmanGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame.WrodGen
{
    public class WordGenerator : IGeneratWord
    {
        public string Word()
        {
            Random random = new Random();
            string[] words = { "program", "utveckla", "lärande", "teknik", "dator" };
            string wordToGuess = words[random.Next(words.Length)];

            return wordToGuess;
        }
    }
}
