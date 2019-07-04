using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewDictionary.DataAccess;
using NewDictionary.Interfaces;

namespace NewDictionary.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDictionaryRepository _repository;
        public string Message { get; set; }

        public IndexModel(IDictionaryRepository repository){
            _repository = repository;
        }
        public void OnGet()
        {
            var isMongoDbActive = _repository.HealthCheck();
            Message = string.Format("Mongo connection is {0}", isMongoDbActive ? "active" : "not active");
        }
    }
}
