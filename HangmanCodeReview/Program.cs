using Autofac;
using HangmanGame.AutoFac;
using HangmanGame.Welcome;
namespace HangmanGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var container = DependencyContainer.Configure();
            var menu = container.Resolve<Menu>();
            menu.DisplayMenu();
            
        }
    }
}
