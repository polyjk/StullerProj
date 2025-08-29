using NUnit.Framework;
using PokemonApp.Core.Entities;
using PokemonApp.Core.Services;
using System.Collections.Generic;

namespace PokemonAppTests
{
    [TestFixture]
    public class TypeEffectivenessCalcTests
    {
        [Test]
        public void CalculateEffectiveness_PrintsExpected()
        {
            var dr = new DamageRelations();
            dr.GetDamageRelationsDict().Add("electric", new Dictionary<string, List<string>>
            {
                { "double_damage_to", new List<string>{ "water" } },
                { "no_damage_from", new List<string>{ "ground" } },
                { "half_damage_from", new List<string>() },
                { "no_damage_to", new List<string>{ "rock" } },
                { "half_damage_to", new List<string>() },
                { "double_damage_from", new List<string>{ "ground" } }
            });

            var calc = new TypeEffectivenessCalc();

            using var sw = new StringWriter();
            Console.SetOut(sw);

            calc.CalculateEffectiveness(dr);

            var output = sw.ToString();
            Assert.IsTrue(output.Contains("water"));
            Assert.IsTrue(output.Contains("ground"));
            Assert.IsTrue(output.Contains("rock"));
        }
    }
}
