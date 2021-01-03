using Lingo.Models;
using Lingo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lingo.Controllers
{
    public class WordController : Controller
    {
        private readonly ILogger<WordController> _logger;
        private readonly IWordRepository _repository;

        public WordController(IWordRepository repository, ILogger<WordController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public void SaveWords(string[] words)
        {
            //File reader should be in method were savewords gets called from. 
            words = System.IO.File.ReadAllLines(@"Resources\basiswoorden-gekeurd.txt");
            List<Word> saveWords = new List<Word>();
            foreach (string word in words)
            {
                if (WordFilter.FilterWord(word)){
                    var saveableWord = new Word();
                    saveableWord.Name = word;
                    saveWords.Add(saveableWord);
                }
            }

            _repository.SaveWordList(saveWords);
        }
    }
}
