using PokemonApp.Core.Entities;

namespace PokemonApp.Core.Interfaces
{
    internal interface IPokemonService
    {
        Task<Pokemon> GetPokemonAsync(string name);
        Task<DamageRelations> GetDamageRelationsAsync();
    }
}
