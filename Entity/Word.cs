using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NewDictionary.Entity
{
  [BsonIgnoreExtraElements]
  public class Word{
    // [BsonId]
    //   public ObjectId InternalId {get;set;}
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id {get;set;}


    [Required]
    [BsonElement("English_HW")]
    public string English{get;set;}
    [Required]
    [BsonElement("Tamil_Unicode")]
    public string Tamil{get;set;}
    [BsonElement("Tamil_HW")]
    public string TamilWord{get;set;}
    //  [Required]
    [BsonElement("Toda_Lexeme")]
    public string Toda {get;set;}
    //  [Required]
    [BsonElement("Irula_Lexeme")]
    public string Irula {get;set;} 
    //  [Required]
    [BsonElement("Pania_Lexeme")]
    public string Pania {get;set;} 
    //  [Required]
    //[BsonElement("Maduva_Lexeme")]
    public string Maduva {get;set;} 
    [Required]
    [BsonElement("English_Gloss")]
    public string Meaning{get;set;}
    [Required]
    [BsonElement("POS")]
    public string PartOfSpeech {get;set;}
    //public IList<Category> Categories {get;set;}
    [BsonElement("Semantic_Category")]
    public string Categories {get;set;}
  }
}