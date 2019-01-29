using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using NewDictionary.Entity;
using NewDictionary.Interfaces;
using NewDictionary.Models.KnownValues;

namespace NewDictionary.DataAccess {
    public class DictionaryRepository : IDictionaryRepository
    {
         private readonly WordContext _context;

        public DictionaryRepository(IOptions<Settings> settings){
            _context = new WordContext(settings);
        }

        public async Task<IEnumerable<Word>> GetAllWords()
        {
            try{
                return await _context.Words.Find(new BsonDocument()).ToListAsync();
            }
            catch(Exception ex){
                throw ex;
            }
            
        }

        public async Task<Word> GetWordById(string id)
        {
            try{
                return await _context.Words.Find(word => word.Id == id).FirstOrDefaultAsync();
            }
            catch(Exception ex){
                throw ex;
            }
        }

        //public async Task<IEnumerable<Word>> GetWordsByField(string fieldName, string fieldValue)
        public async Task<IEnumerable<Word>> GetWordsByField(SearchField searchField, string fieldValue, SearchType searchType)
        {
            try
            {
                var fieldName = Enum.GetName(typeof(SearchField), searchField);
                var regexExp = searchType == SearchType.Contains ?  ".*{0}.*" : @"^{0}";
                var regex = new BsonRegularExpression(string.Format(regexExp, fieldValue), "i");
                Console.WriteLine(regex.ToString());
                var filter = Builders<Word>
                                .Filter.Regex(fieldName, regex);
                var result = await _context.Words.Find(filter).ToListAsync();
                Console.WriteLine(result.Count);
                return result;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public bool HealthCheck()
        {
            return _context.IsMongoDbActive();
        }

        public async Task InsertWord(Word word)
        {
            try
            {
                await _context.Words.InsertOneAsync(word);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}