using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL.Model.LocationsOptions
{
    public class Shop : Location
    {
        protected List<Product> Products { get; private set; }
        public Shop(string locationName) : base(locationName)
        {
            Products = new List<Product>();
        }
        public void Add(Product product)
        {
            Products.Add(product);
        }
    }
}
