using Autofac;
using HangmanGame.GameFolder;
using HangmanGame.Interface;
using HangmanGame.Welcome;
using HangmanGame.WrodGen;

namespace HangmanGame.AutoFac
{
    public static class DependencyContainer
    {
        public static IContainer Configure()
        {
            var containerBuilder = new ContainerBuilder();

            // Register the dependencies
            containerBuilder.RegisterType<WordGenerator>().As<IGeneratWord>();
            containerBuilder.RegisterType<HangMan>().As<IHangMan>();
            containerBuilder.RegisterType<WelcomeScreen>().As<IWelcome>();

            // Register the named IGame implementations
            containerBuilder.RegisterType<GameEn>().Named<IGame>("gameEn");
            containerBuilder.RegisterType<GameSe>().Named<IGame>("gameSe");

            // Register Menu with all three parameters
            containerBuilder.RegisterType<Menu>().AsSelf()
                .WithParameter(
                    (pi, ctx) => pi.Name == "_gameEn",
                    (pi, ctx) => ctx.ResolveNamed<IGame>("gameEn")
                )
                .WithParameter(
                    (pi, ctx) => pi.Name == "_gameSe",
                    (pi, ctx) => ctx.ResolveNamed<IGame>("gameSe")
                )
                .WithParameter(
                    (pi, ctx) => pi.ParameterType == typeof(IWelcome),
                    (pi, ctx) => ctx.Resolve<IWelcome>()
                );

            return containerBuilder.Build();
        }
    }
}
