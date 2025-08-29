using PokemonApp.Core.Entities;
using PokemonApp.Core.Interfaces;
using PokemonApp.Infra.Dtos;

namespace PokemonApp.Infra
{
    internal class PokemonService : IPokemonService
    {
        private readonly string m_BaseApiUrl = "https://pokeapi.co/api/v2";
        private readonly ApiClient m_ApiClient;
        private Pokemon? m_Pokemon;
        private DamageRelations? m_DamageRelations;
        public PokemonService()
        {
            m_ApiClient = new ApiClient();
        }

        public async Task<Pokemon> GetPokemonAsync(string name)
        {
            try
            {
                string pokemonUrl = $"{m_BaseApiUrl}/pokemon/{name.ToLower()}";
                var pokemonResults = await m_ApiClient.GetAsync<PokemonDto>(pokemonUrl);
                m_Pokemon = new Pokemon(pokemonResults.Name!, pokemonResults.Types!.Select(t => t.Type!.Name!).ToList());

                return m_Pokemon;
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException("Unable to fetch Pokemon. It may not exist or the network is unavailable.", e);
            }
        }

        public async Task<DamageRelations> GetDamageRelationsAsync()
        {
            m_DamageRelations = new DamageRelations();

            foreach (var type in m_Pokemon!.GetTypes()!)
            {
                string typeUrl = $"{m_BaseApiUrl}/type/{type}";
                var typeResults = await m_ApiClient.GetAsync<PokemonTypeDto>(typeUrl);
                m_DamageRelations.SetDamageRelationsDict(type, typeResults);
            }
            // m_DamageRelations.PrintDamageRelations();

            return m_DamageRelations;
        }
    }
}
