using NUnit.Framework;
using PokemonApp.Core.Entities;
using System.Collections.Generic;

namespace PokemonAppTests
{
    [TestFixture]
    public class PokemonTests
    {
        [Test]
        public void Pokemon_HoldsNameAndTypes()
        {
            var p = new Pokemon("pikachu", new List<string> { "electric" });
            Assert.That(p.GetName(), Is.EqualTo("pikachu"));
            Assert.That(p.GetTypes(), Has.Count.EqualTo(1));
            Assert.That(p.GetTypes()[0], Is.EqualTo("electric"));
        }
    }
}
