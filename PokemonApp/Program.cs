using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PokemonApp.Core.Interfaces;
using PokemonApp.Core.Services;
using PokemonApp.Infra;


namespace PokemonApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>
            {
                services.AddTransient<IPokemonService, PokemonService>();
                services.AddTransient<ITypeEffectivenessCalc, TypeEffectivenessCalc>();
                services.AddTransient<ConsoleApp>();
            }).Build();

            ConsoleApp app = host.Services.GetRequiredService<ConsoleApp>();
            await app.RunAsync();
        }
    }
}
