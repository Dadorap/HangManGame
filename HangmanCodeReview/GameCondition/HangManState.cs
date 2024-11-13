using HangmanGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame.GameCondition
{
    public class HangManState : IHangMan
    {

        public void DisplayHangman(int guessesLeft)
        {
            char head = guessesLeft > 0 ? 'o' : ' ';
            char leftArm = guessesLeft > 2 ? '-' : ' ';
            char body = guessesLeft > 1 ? '|' : ' ';
            char rightArm = guessesLeft > 3 ? '-' : ' ';
            char leftLeg = guessesLeft > 4 ? '/' : ' ';
            char rightLeg = guessesLeft > 5 ? '\\' : ' ';

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
