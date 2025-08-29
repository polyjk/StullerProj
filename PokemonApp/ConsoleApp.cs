using PokemonApp.Core.Entities;
using PokemonApp.Core.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace PokemonApp
{
    internal class ConsoleApp
    {
        private readonly IPokemonService m_PokemonService;
        private readonly ITypeEffectivenessCalc m_TypeEffectivenessCalc;

        public ConsoleApp(IPokemonService pokemonService, ITypeEffectivenessCalc typeEffectivenessService)
        {
            m_PokemonService = pokemonService;
            m_TypeEffectivenessCalc = typeEffectivenessService;
        }

        public async Task RunAsync()
        {
            printArt();
            Console.WriteLine("Pokemon Type Effectiveness Calculator");
            Console.WriteLine("Press Ctrl+C to exit.\n");

            while (true)
            {
                Console.Write("Enter Pokemon name: ");
                string? name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Please enter a valid Pokemon name.\n");
                    continue;
                }

                try
                {
                    Pokemon pokemon = await m_PokemonService.GetPokemonAsync(name);

                    Console.WriteLine();
                    var prev = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("====================================================");
                    Console.WriteLine($" Results for: {pokemon.GetName().ToUpper()} ");
                    Console.WriteLine("====================================================");
                    Console.ForegroundColor = prev;

                    DamageRelations damageRelations = await m_PokemonService.GetDamageRelationsAsync();
                    m_TypeEffectivenessCalc.CalculateEffectiveness(damageRelations);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine();
                Console.WriteLine("====================================================");
                Console.WriteLine();
            }
        }

        public void printArt()
        {
            var baseDir = AppContext.BaseDirectory;
            var artPath = Path.Combine(baseDir, "Assets", "art.txt");
            if (File.Exists(artPath))
            {
                var art = File.ReadAllText(artPath);
                Console.WriteLine(art);
            }
        }
    }
}
