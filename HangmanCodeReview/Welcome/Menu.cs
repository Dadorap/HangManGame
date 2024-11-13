using HangmanGame.Interface;

namespace HangmanGame.Welcome
{
    public class Menu
    {
        private IGame _gameEn;
        private IGame _gameSe;
        private IWelcome _welcome;

        public Menu(IGame _gameEn, IGame _gameSe, IWelcome _welcome)
        {
            this._gameEn = _gameEn;
            this._gameSe = _gameSe;
            this._welcome = _welcome;
        }
        public void DisplayMenu()
        {
            int currentSelect = 0;
            List<string> menu = new List<string>() { "Play in English", "Spela på Svenksa", "Exit/Avsluta" };

            while (true)
            {
                Console.Clear();
                _welcome.WelcomeDisplay();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Choose a language and press Enter:\n");
                Console.ResetColor();
                for (int i = 0; i < menu.Count; i++)
                {
                    if (i == currentSelect)
                    {
                        if (menu[i].ToLower() == "exit/avsluta")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                        }
                        Console.WriteLine($"{menu[i]}");
                    }
                    else
                    {
                        Console.WriteLine($">>{menu[i]}<<");
                    }
                    Console.ResetColor();
                }

                ConsoleKey keyPressed = Console.ReadKey(true).Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    currentSelect = currentSelect > 0 ? currentSelect - 1 : menu.Count - 1;
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    currentSelect = currentSelect < menu.Count - 1 ? currentSelect + 1 : 0;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (currentSelect)
                    {
                        case 0:
                            _gameEn.GameOn();
                            return;
                        case 1:
                            _gameSe.GameOn();
                            break;
                        case 2:
                            Environment.Exit(0);
                            return;
                    }
                }
            }
        }
    }

}

