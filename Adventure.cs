using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame
{
    public class Adventure
    {
        public List<City> AvailableCities { get; set; }

        public Adventure()
        {
            AvailableCities = Cities.AllCities;
        }
    }
   
}
