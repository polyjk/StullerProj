
namespace PokemonApp.Core.Entities
{
    internal class Pokemon
    {
        private readonly string m_Name;
        private readonly List<string> m_Types;

        public Pokemon(string name, List<string> types) {
            m_Name = name;
            m_Types = types;
        }

        public string GetName() { return m_Name; }
        public List<string>? GetTypes() { return m_Types; }
    }
}
