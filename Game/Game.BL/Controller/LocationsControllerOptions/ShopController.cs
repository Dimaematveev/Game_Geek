using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.BL.Model;
using Game.BL.Model.LocationsOptions;

namespace Game.BL.Controller.LocationsControllerOptions
{
    public class ShopController : ControllerLocation
    {
        public ShopController(Shop[] shops, Shop currentShop) : base(shops, currentShop)
        {
        }
        public void Add(Product product)
        {
            ((Shop)(CurrentLocation)).Add(product);
        }
    }
}
