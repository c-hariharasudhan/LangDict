using System.Collections.Generic;
using MongoDB.Bson;
namespace NewDictionary.Entity
{
public class Category{
    public ObjectId InternalId {get;set;}
    public string CategoryId {get;set;}
    public string Name{get;set;}
    public IList<Word> Words {get;set;}
}
}