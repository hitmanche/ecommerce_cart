using CL;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Operations.Functions
{
    public class Redis : Interfaces.IRedis
    {
        IDatabase db;
        public Redis()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(Configuration.prmRedisUrl);
            db = redis.GetDatabase();
        }

        public async Task<string> GetString(string prmKey)
        {
            return await db.StringGetAsync(prmKey);
        }

        public async void SetString(string prmKey, string prmValue)
        {
            TimeSpan expires = TimeSpan.FromMinutes(Configuration.prmExpiresCart);
            await db.StringSetAsync(prmKey, prmValue, expires);
        }
    }
}
