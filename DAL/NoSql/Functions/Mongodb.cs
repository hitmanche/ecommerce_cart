using CL;
using CL.Cart;
using DAL.NoSql.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.NoSql.Functions
{
    public class Mongodb : IMongodb
    {
        IMongoDatabase db;
        public Mongodb()
        {
            MongoClient client = new MongoClient(Configuration.prMongodb);
            db = client.GetDatabase("ecommerce");
        }
        public async Task<string> GetString(string prmKey)
        {
            var returnData = db.GetCollection<BsonDocument>(prmKey).Find(new BsonDocument()).ToList();
            List<MongodbCart> jsonData = new List<MongodbCart>();
            foreach (BsonDocument item in returnData)
            {
                jsonData.Add(BsonSerializer.Deserialize<MongodbCart>(item));
            }
            return JsonConvert.SerializeObject(jsonData);
        }

        public async void SetString(string prmKey, string prmValue)
        {
            await db.DropCollectionAsync(prmKey);
            var doc = JsonConvert.DeserializeObject<List<MongodbCart>>(prmValue.Replace("\\", ""));
            foreach (MongodbCart mc in doc)
            {
                await db.GetCollection<BsonDocument>(prmKey).InsertOneAsync(mc.ToBsonDocument());
            }
        }
    }
}
