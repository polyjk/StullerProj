using PokemonApp.Core.Entities;

namespace PokemonApp.Core.Interfaces
{
    internal interface ITypeEffectivenessCalc
    {
        void CalculateEffectiveness(DamageRelations damageRelations);
    }
}
