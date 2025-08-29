
namespace PokemonApp.Infra.Dtos
{
    internal class PokemonDto
    {
        public string? Name { get; set; }
        public List<PokemonTypeDto>? Types { get; set; }
    }
}
