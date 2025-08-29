using PokemonApp.Infra.Dtos;

namespace PokemonApp.Core.Entities
{
    internal class DamageRelations
    {
        private Dictionary<string, Dictionary<string, List<string>>> m_DamageRelationsDict;
        public DamageRelations()
        {
            m_DamageRelationsDict = new Dictionary<string, Dictionary<string, List<string>>>();
        }
        public Dictionary<string, Dictionary<string, List<string>>> GetDamageRelationsDict() { return m_DamageRelationsDict; }

        public void SetDamageRelationsDict(string typeName, PokemonTypeDto typeResults)
        {
            if (!m_DamageRelationsDict.ContainsKey(typeName))
            {
                m_DamageRelationsDict!.Add(typeName, new Dictionary<string, List<string>>()
                {
                    { "double_damage_from", typeResults.DamageRelations!.DoubleDamageFrom!.Select(x => x.Name!).ToList() },
                    { "half_damage_from", typeResults.DamageRelations!.HalfDamageFrom!.Select(x => x.Name!).ToList() },
                    { "no_damage_from", typeResults.DamageRelations!.NoDamageFrom!.Select(x => x.Name!).ToList() },
                    { "double_damage_to", typeResults.DamageRelations!.DoubleDamageTo!.Select(x => x.Name!).ToList() },
                    { "half_damage_to", typeResults.DamageRelations!.HalfDamageTo!.Select(x => x.Name!).ToList() },
                    { "no_damage_to", typeResults.DamageRelations!.NoDamageTo!.Select(x => x.Name!).ToList() }
                });
            }
        }

        public void PrintDamageRelations()
        {
            foreach (var typeEntry in m_DamageRelationsDict)
            {
                Console.WriteLine($"Type: {typeEntry.Key}");
                foreach (var relation in typeEntry.Value)
                {
                    Console.WriteLine($"  {relation.Key}: [{string.Join(", ", relation.Value)}]");
                }
            }
        }
    }
}
