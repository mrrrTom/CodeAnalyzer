using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using CodeAnalyzer.Analyzer;
using CodeAnalyzer.Parser;
using Parser;

namespace CodeAnalyzer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0) return;
            var pathInput = args[0];
            if (string.IsNullOrWhiteSpace(pathInput)) return;

            var host = CreateHost();
            var service = ActivatorUtilities.CreateInstance<AnalyzerService>(host.Services);
            service.PrintCodeAnalysis(pathInput);
        }

        private static IHost CreateHost()
        {
            return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<AbstractASTAnalyzer, PossibleOutputFinder>();
                services.AddSingleton<IParser, JavaParser>();
                services.AddSingleton<AnalyzerService>();
            })
            .Build();
        }
    }
}