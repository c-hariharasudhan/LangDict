using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace NewDictionary.Entity{
    [Table("Notes")]
    public class Note{
        [Key]
        public Guid Id {get;set;}

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