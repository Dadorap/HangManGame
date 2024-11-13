using Autofac;
using HangmanGame.GameCondition;
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

            containerBuilder.RegisterType<WordGeneratorSe>().Named<IGeneratWord>("swedish");
            containerBuilder.RegisterType<WordGeneratorEn>().Named<IGeneratWord>("english");
            containerBuilder.RegisterType<GameState>().As<IGameState>();

            containerBuilder.RegisterType<HangManState>().As<IHangMan>();
            containerBuilder.RegisterType<WelcomeScreen>().As<IWelcome>();

            containerBuilder.RegisterType<GameEn>().Named<IGame>("gameEn")
               .WithParameter(
                   (pi, ctx) => pi.Name == "_wordToGuessEn",
                   (pi, ctx) => ctx.ResolveNamed<IGeneratWord>("english")
               )
               .WithParameter(
                   (pi, ctx) => pi.ParameterType == typeof(IHangMan),
                   (pi, ctx) => ctx.Resolve<IHangMan>()
               ).WithParameter(
                   (pi, ctx) => pi.ParameterType == typeof(IGameState),
                   (pi, ctx) => ctx.Resolve<IGameState>()
               );

            containerBuilder.RegisterType<GameSe>().Named<IGame>("gameSe")
                .WithParameter(
                    (pi, ctx) => pi.Name == "_wordToGuessSe",
                    (pi, ctx) => ctx.ResolveNamed<IGeneratWord>("swedish")
                )
                .WithParameter(
                    (pi, ctx) => pi.ParameterType == typeof(IHangMan),
                    (pi, ctx) => ctx.Resolve<IHangMan>()
                ).WithParameter(
                   (pi, ctx) => pi.ParameterType == typeof(IGameState),
                   (pi, ctx) => ctx.Resolve<IGameState>()
               );

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
