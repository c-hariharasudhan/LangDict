using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewDictionary.Entity;
using NewDictionary.Interfaces;
using System.Collections.Generic;
using NewDictionary.Models.KnownValues;
namespace NewDictionary{
    public class DetailsModel  : PageModel {
        private readonly IDictionaryRepository _repository;

        public DetailsModel(IDictionaryRepository repository){
            _repository = repository;
        }

        public Word Word {get;set;}
        public bool ShowIrula {get;set;}
        public bool ShowPania {get;set;}
        public bool ShowToda {get;set;}

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Console.WriteLine(id);
            var t = (TempData["DisplayFields"] ?? "").ToString();
            Console.WriteLine(t);
            ShowIrula = t.Contains("Irula");
            ShowPania = t.Contains("Pania");
            ShowToda = t.Contains("Toda");
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            Word = await _repository.GetWordById(id);

            if (Word == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}