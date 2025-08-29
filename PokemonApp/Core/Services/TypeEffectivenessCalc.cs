using PokemonApp.Core.Entities;
using PokemonApp.Core.Interfaces;

namespace PokemonApp.Core.Services
{
    internal class TypeEffectivenessCalc : ITypeEffectivenessCalc
    {
        public TypeEffectivenessCalc()
        {
        }

        public void CalculateEffectiveness(DamageRelations damageRelations)
        {
            foreach (var typeEntry in damageRelations.GetDamageRelationsDict())
            {
                var prev = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nType: {typeEntry.Key}");
                Console.ForegroundColor = prev;
                Console.WriteLine("----------------------------");

                var strengths = new HashSet<string>();
                var weaknesses = new HashSet<string>();

                AddAll(strengths, typeEntry.Value["double_damage_to"]);
                AddAll(strengths, typeEntry.Value["no_damage_from"]);
                AddAll(strengths, typeEntry.Value["half_damage_from"]);

                AddAll(weaknesses, typeEntry.Value["no_damage_to"]);
                AddAll(weaknesses, typeEntry.Value["half_damage_to"]);
                AddAll(weaknesses, typeEntry.Value["double_damage_from"]);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("STRONG VS:");
                Console.ForegroundColor = prev;
                
                foreach (var s in strengths)
                {
                    Console.WriteLine($"  - {s}");
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("WEAK VS:");
                Console.ForegroundColor = prev;
                foreach (var w in weaknesses)
                {
                    Console.WriteLine($"  - {w}");
                }
            }
        }

        private static void AddAll(HashSet<string> set, IEnumerable<string>? items)
        {
            if (items == null) return;
            foreach (var s in items)
            {
                if (!string.IsNullOrWhiteSpace(s))
                    set.Add(s.Trim());
            }
        }
    }
}