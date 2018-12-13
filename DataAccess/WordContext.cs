using Microsoft.Extensions.Options;
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
                return _database.GetCollection<Word>("WordDetails");
            }
        }
    }
}