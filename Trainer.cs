using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame
{
  
    public class Trainer
    {
        
        public string Name { get; set; }
        public int PokeScore { get; set; }
        public ICollection<Pokemon> PokeCollection { get; set; }
        public Trainer()
        {

        }
        public Trainer(string aName, int aPokeScore)
        {
            Name = aName;
            PokeScore = aPokeScore;
            PokeCollection = new List<Pokemon>();
        }
    }
}
