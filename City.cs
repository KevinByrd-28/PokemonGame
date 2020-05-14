using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGame
{



    public class City
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Weather { get; set; }

        public City()
        {

        }
       
        public void Beigeville()
        {

        }
        public void VermillianCity()
        {

        }
        public void Brownstown()
        {

        }

    }

    public static class Cities
    {
        public static List<City> AllCities = new List<City> { new VeridianCity()};
    }

    public class VeridianCity : City
    {
       public void RunCity()
        {
            Console.WriteLine("test");
        }
    }
}
