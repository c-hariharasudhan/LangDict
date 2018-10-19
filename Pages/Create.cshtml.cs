using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewDictionary.Entity;
using NewDictionary.Interfaces;

namespace NewDictionary{
    public class CreateModel : PageModel
    {
        private readonly IDictionaryRepository _repository;

        public CreateModel(IDictionaryRepository repository)
        {
            _repository = repository;
        }
        [BindProperty]
        public Word Word {get;set;}
        public IActionResult OnGet()
        {
            //_repository.CreateIndexAsync();
            // TODO remove. For quick testing.
            Word = new Word();

            return Page();
        }


        #region snippet_OnPostAsync
        public async Task<IActionResult> OnPostAsync()
        {
            //Word.Id  = Guid.NewGuid().ToString();
            //if (!ModelState.IsValid)
            {
                await _repository.InsertWord(Word); 
                return RedirectToPage("./Home"); 
            }
                return Page();
        }
        #endregion
    }
}