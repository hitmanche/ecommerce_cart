using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Business
{
    public abstract class ACart
    {
        public abstract Task<string> GetCart(string prmKey);
        public abstract void AddCart(string prmKey,string prmValue);
    }
}
