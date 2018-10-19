using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewDictionary.Entity;
using NewDictionary.Interfaces;

namespace NewDictionary{
    public class DetailsModel  : PageModel {
        private readonly IDictionaryRepository _repository;

        public DetailsModel(IDictionaryRepository repository){
            _repository = repository;
        }

        public Word Word {get;set;}

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Console.WriteLine(id);
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