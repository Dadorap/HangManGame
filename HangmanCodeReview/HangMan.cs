using HangmanGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame
{
    public class HangMan : IHangMan
    {

        public void DisplayHangman(int incorrectGuesses)
        {
            char head = incorrectGuesses > 0 ? 'o' : ' ';
            char leftArm = incorrectGuesses > 2 ? '-' : ' ';
            char body = incorrectGuesses > 1 ? '|' : ' ';
            char rightArm = incorrectGuesses > 3 ? '-' : ' ';
            char leftLeg = incorrectGuesses > 4 ? '/' : ' ';
            char rightLeg = incorrectGuesses > 5 ? '\\' : ' ';

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(" --------- ");
            Console.WriteLine(" |   |   | ");
            Console.WriteLine($" |   {head}   | ");
            Console.WriteLine($" |  {leftArm}{body}{rightArm}  | ");
            Console.WriteLine($" |  {leftLeg} {rightLeg}  | ");
            Console.WriteLine(" |       | ");
            Console.WriteLine("_|_______|_");
            Console.WriteLine("|||||||||||");
            Console.ResetColor();
        }


    }
}
