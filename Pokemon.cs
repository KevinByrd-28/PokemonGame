using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame
{
    public enum PokeType {Fire, Grass, Water, Electric, Bug, Normal}
    public abstract class Pokemon
    {
        public string Creature { get; set; }
        public PokeType PokeType { get; set; }
        public int Score { get; set; }
        

        public Pokemon()
        {

        }
        public Pokemon(string creature, PokeType type)
        {
            Creature = creature;
            PokeType = type;
        }
    }
}
