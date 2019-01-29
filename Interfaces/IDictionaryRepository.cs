using System.Collections.Generic;
using System.Threading.Tasks;
using NewDictionary.Entity;
using NewDictionary.Models.KnownValues;

namespace NewDictionary.Interfaces {
    public interface IDictionaryRepository{
        bool HealthCheck();
        Task<IEnumerable<Word>> GetAllWords();    
        //Task<IEnumerable<Word>> GetWordsByField(string fieldName, string fieldValue);
        Task<IEnumerable<Word>> GetWordsByField(SearchField searchField, string fieldValue, SearchType searchType);
        Task<Word> GetWordById(string id);
        Task InsertWord(Word word);

    }
   

}