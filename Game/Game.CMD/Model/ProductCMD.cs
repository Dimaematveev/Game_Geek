using Game.BL.Model;
using Game.CMD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.CMD.Model
{
    public class ProductCMD : Product, IConsole
    {
        public ProductCMD(string productName, int price) : base(productName, price)
        {
        }

        public void ToConsole(int spaceLeft)
        {
            throw new NotImplementedException();
        }
    }
}
