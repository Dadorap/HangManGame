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

        public void DisplayHangman(int lives)
        {
            char head = lives > 0 ? 'o' : ' ';
            char leftArm = lives > 2 ? '-' : ' ';
            char body = lives > 1 ? '|' : ' ';
            char rightArm = lives > 3 ? '-' : ' ';
            char leftLeg = lives > 4 ? '/' : ' ';
            char rightLeg = lives > 5 ? '\\' : ' ';
            Console.Write("Lives: ");
            for (int i = 0; i < lives; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("♥ ");
                Console.ResetColor();
            }
            Console.WriteLine("");
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
