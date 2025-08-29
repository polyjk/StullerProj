
using System.Text.Json.Serialization;

namespace PokemonApp.Infra.Dtos
{
    internal class PokemonTypeDto
    {
        public NamedApiResource? Type { get; set; }

        [JsonPropertyName("damage_relations")]
        public TypeDamageRelationsDto? DamageRelations { get; set; }
    }
}
