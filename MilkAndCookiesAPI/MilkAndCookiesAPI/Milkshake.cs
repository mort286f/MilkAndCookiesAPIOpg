using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilkAndCookiesAPI
{
    //Represents the milkshake class for use in the Milkshake controller
    public class Milkshake
    {
        public int ID { get; set; }
        public string Flavour { get; set; }
        //public List<Milkshake> Milkshakes { get; set; }
        //public int Size { get; set; }

        public Milkshake(string flavour, int id)
        {
            this.Flavour = flavour;
            this.ID = id;
            //this.Milkshakes = new List<Milkshake>();

            //Milkshakes.Add(new Milkshake("Strawberry"));
            //Milkshakes.Add(new Milkshake("Chocolate"));
            //Milkshakes.Add(new Milkshake("Vanilla"));
        }
    }
}
