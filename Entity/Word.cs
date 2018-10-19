using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NewDictionary.Entity
{
public class Word{
  // [BsonId]
  //   public ObjectId InternalId {get;set;}
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
    public string Id {get;set;}


    [Required]
    public string English{get;set;}
     [Required]
   public string Tamil{get;set;}
   //  [Required]
   public string Toda {get;set;}
   //  [Required]
   public string Irula {get;set;} 
  //  [Required]
   public string Pania {get;set;} 
  //  [Required]
   public string Maduva {get;set;} 
     [Required]
   public string Meaning{get;set;}
     [Required]
   public string PartOfSpeech {get;set;}
    //public IList<Category> Categories {get;set;}
    public string Categories {get;set;}
}
}