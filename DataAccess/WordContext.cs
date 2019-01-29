using System;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using NewDictionary.Entity;

namespace NewDictionary.DataAccess{
    public class WordContext{
        private readonly IMongoDatabase _database = null;

        public WordContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Word> Words
        {
            get
            {
                //return _database.GetCollection<Word>("Word");
                return _database.GetCollection<Word>("worddetails");
            }
        }

        public bool IsMongoDbActive(){
            try{
            bool isMongoLive = _database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(1000);
            return isMongoLive;
            }
            catch(System.Exception ex){
                Console.WriteLine(ex);
            }
            return false;
        }
    }
}