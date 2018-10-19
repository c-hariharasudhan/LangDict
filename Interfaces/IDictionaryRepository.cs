using System.Collections.Generic;
using System.Threading.Tasks;
using NewDictionary.Entity;

namespace NewDictionary.Interfaces {
    public interface IDictionaryRepository{
        Task<IEnumerable<Word>> GetAllWords();    
        Task<IEnumerable<Word>> GetWordsByField(string fieldName, string fieldValue);
        Task<Word> GetWordById(string id);
        Task InsertWord(Word word);

    }
   

}