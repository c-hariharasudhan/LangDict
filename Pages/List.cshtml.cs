using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewDictionary.Entity;
using NewDictionary.Interfaces;
using MongoDB.Driver;
using NewDictionary.Models.KnownValues;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace NewDictionary.Pages
{
    public class ListModel : PageModel
    {
        private readonly IDictionaryRepository _dictionaryRepository;

        [BindProperty]
        public List<Word> Words {get;set;}
        [BindProperty(SupportsGet = true)]
        public string SearchKey{get;set;}
        [BindProperty]
        public List<char> Options{get;set;}

        public ListModel(IDictionaryRepository dictionaryRepository){
            _dictionaryRepository = dictionaryRepository;
            Options = Enumerable.Range('A', 26).Select(x => (char)x).ToList();
        }

        public IActionResult OnGet(){
            Words = new List<Word>();
            if(!string.IsNullOrEmpty(SearchKey) && SearchKey != "*"){
                var result = _dictionaryRepository.GetWordsByField(SearchField.English, SearchKey, SearchType.StartsWith, null).Result;
                Words.AddRange(result);
            }
            else{
                 Words.AddRange(_dictionaryRepository.GetAllWords().Result);
            }
            return Page();
        }
    }
}