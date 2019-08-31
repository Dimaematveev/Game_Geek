using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL.Model
{
    public class Product
    {
        protected readonly string ProductName;
        protected int Price { get; private set; }

        public Product(string productName, int price)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                throw new ArgumentNullException("Название товара не должно быть пустым!", nameof(productName));
            }
            if (price<=0)
            {
                throw new ArgumentException("Цена товара не должна быть меньше или равным 0!", nameof(productName));
            }
            ProductName = productName;
            Price = price;
        }

        /// <summary>
        /// Метод выводит фактическую цену товара.
        /// </summary>
        /// <returns> Цена! </returns>
        protected virtual int GetPrice()
        {
            return Price;
        }
    }
}
