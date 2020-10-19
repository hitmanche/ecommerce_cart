using DAL.NoSql.Functions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Business.CartOperations
{
    class CartMongo : ACart
    {
        Mongodb mongodb;
        public CartMongo()
        {
            mongodb = new Mongodb();
        }
        public override void AddCart(string prmKey, string prmValue)
        {
            mongodb.SetString(prmKey, prmValue);
        }

        public async override Task<string> GetCart(string prmKey)
        {
            return await mongodb.GetString(prmKey);
        }
    }
}
