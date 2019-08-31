using Game.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL.Controller
{
    public class ProductController
    {
        public readonly Product[] Products;
        public ProductController(Product[] products)
        {
            if (products == null || products.Length == 0)
            {
                throw new ArgumentNullException("Список продуктов не должен быть пустым!", nameof(products));
            }
            Products = products;
        }
    }
}
