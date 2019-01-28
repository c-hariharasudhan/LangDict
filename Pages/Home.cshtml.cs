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

namespace NewDictionary.Pages
{
    public class HomeModel : PageModel
    {
        private readonly IDictionaryRepository _repository;

        public HomeModel(IDictionaryRepository repository){
            _repository = repository;
        }
        public SearchField SearchField {get;set;}
        public SearchType SearchType {get;set;}
        [BindProperty]
        public List<Word> Words {get;set;}
        
        public IActionResult OnGet(string searchText)
        {
            Words = new List<Word>();
            if(!string.IsNullOrEmpty(searchText)){
            Console.WriteLine(searchText);
            //var result = _repository.GetAllWords().Result;
            var result = _repository.GetWordsByField(SearchField, 
                                    searchText, SearchType).Result;
            
            Words = result.ToList();
            Console.WriteLine(Words.Count);
            if(Words.Count == 1){
                Console.WriteLine(Words.FirstOrDefault().Id);
                return RedirectToPage("Details", new { id = Words.FirstOrDefault().Id });
            }
            }
            return Page();
        }
    }
}
