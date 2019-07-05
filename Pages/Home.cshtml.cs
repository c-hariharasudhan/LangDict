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

using NewDictionary.Models;


namespace NewDictionary.Pages
{
    public class HomeModel : PageModel
    {
        private readonly IDictionaryRepository _repository;

        public HomeModel(IDictionaryRepository repository){
            _repository = repository;
            BuildCategories();
        }

        private void BuildCategories(){
            var result = new List<string>();
            var c = _repository.GetCategories().Result.OrderBy(cat => cat).ToList();
            Categories = c.Select(s => new SelectListItem{
                                Value = s, 
                                Text = s
                                }).ToList();
            Console.WriteLine(Categories.Count());
            // c.ForEach(cat => {
            //     Console.WriteLine(cat);
            //    // result.AddRange(cat.Split(';').ToList());
            //     });
            //Console.WriteLine(result.Distinct().Count());
        }
        [BindProperty(SupportsGet = true)]
        public string Category{get;set;}
        [BindProperty]
        public List<SelectListItem> Categories {get;set;}
        
        [BindProperty]
        public List<Word> Words {get;set;}

        [BindProperty(SupportsGet = true)]
         public SearchField SearchField {get;set;}
         [BindProperty(SupportsGet = true)]
         public SearchType SearchType {get;set;}
        [BindProperty(SupportsGet = true)]
        public string SearchText {get;set;}

        [BindProperty(SupportsGet = true)]
        public List<DisplayField> DisplayFields{get;set;}
                [BindProperty(SupportsGet = true)]
        public List<FieldName> Fields{get;set;}

        
       private void BuildDisplayFields(){
           DisplayFields = new List<DisplayField>();
            Array values = Enum.GetValues(typeof(FieldName));
            Console.WriteLine("F : " + values.Length);
            foreach( FieldName val in values )
            {
                DisplayFields.Add(new DisplayField{
                    FieldName = Enum.GetName(typeof(FieldName), val),
                    FieldValue = val,
                    Selected = Fields.Any(f => f == val)
                });
            } 
       }
        public IActionResult OnGet()
        {
            BuildDisplayFields();
            Words = new List<Word>();
            TempData["DisplayFields"] = string.Join(",", Fields);
            if(!string.IsNullOrEmpty(SearchText)){
                Console.WriteLine(Fields.Count());
                Console.WriteLine(SearchText);
                Console.WriteLine("Field : {0}, Type : {1}, Category: {2}", SearchField, SearchType, Category);
                //var result = _repository.GetAllWords().Result;
                var result = _repository.GetWordsByField(SearchField, 
                                        SearchText.Trim(), SearchType, Category).Result;
                
                Words = result.ToList();
                Console.WriteLine(Words.Count);
                if(Words.Count == 1){
                    Console.WriteLine(Words.FirstOrDefault().Id);
                    return RedirectToPage("Details", new { id = Words.FirstOrDefault().Id });
                }
            }
            return Page();
        }

        // public IActionResult OnPost()
        // {
        //     Console.WriteLine(Fields.Count());
        //     BuildDisplayFields();
        //      if(!string.IsNullOrEmpty(SearchText)){
        //         Console.WriteLine(SearchText);
        //         Console.WriteLine("Field : {0}, Type : {1}", SearchField, SearchType);
        //         //var result = _repository.GetAllWords().Result;
        //         var result = _repository.GetWordsByField(SearchField, 
        //                                 SearchText, SearchType).Result;
                
        //         Words = result.ToList();
        //         Console.WriteLine(Words.Count);
        //         if(Words.Count == 1){
        //             Console.WriteLine(Words.FirstOrDefault().Id);
        //             return RedirectToPage("Details", new { id = Words.FirstOrDefault().Id });
        //         }
        //     }
        //     return Page();
        // }
    }
}
