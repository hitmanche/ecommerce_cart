using DAL.Operations.Functions;
using System.Threading.Tasks;

namespace BL.Business.Cart
{
    public class CartRedis : ACart
    {
        Redis redis;
        public CartRedis()
        {
            redis = new Redis();
        }
        
        public override void AddCart(string prmKey, string prmValue)
        {
            redis.SetString(prmKey, prmValue);
        }

        public override async Task<string> GetCart(string prmKey)
        {
            return await redis.GetString(prmKey);
        }
    }
}
