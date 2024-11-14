using System;
using HangmanGame.GameFolder;
using HangmanGame.Interface;

namespace HangmanGame.Welcome
{
    public class WelcomeScreen : IWelcome
    {

        public void WelcomeDisplay()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string hangMan = @"
 _                                             
| |                                            
| |__   __ _ _ __   __ _ _ __ ___   __ _ _ __  
| '_ \ / _` | '_ \ / _` | '_ ` _ \ / _` | '_ \ 
| | | | (_| | | | | (_| | | | | | | (_| | | | |
|_| |_|\__,_|_| |_|\__, |_| |_| |_|\__,_|_| |_|
                    __/ |                      
                   |___/  
";

            Console.WriteLine(hangMan);
            Console.ResetColor();
            Console.WriteLine("You have a total of 6 lives. Guess letters to find the correct word.");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(" -------");
            Console.WriteLine(" |   |  ");
            Console.WriteLine(" |   o  ");
            Console.WriteLine(" |  -|- ");
            Console.WriteLine(" |  / \\ ");
            Console.WriteLine(" |      ");
            Console.WriteLine("_|______");
            Console.WriteLine("||||||||");
            Console.ResetColor();

        }
    }
}
