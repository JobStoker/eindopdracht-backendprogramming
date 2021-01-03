using Lingo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lingo.Repositories
{
    public class WordRepository : IWordRepository
    {

        private readonly lingoContext _context;
        public WordRepository(lingoContext context)
        {
            _context = context;
        }

        public IEnumerable<Word> GetGameWords(int GameId)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Saves all the words from a given list 
        /// </summary>
        /// <param name="words"></param>
        public void SaveWordList(IEnumerable<Word> words)
        {
            foreach(var word in words)
            {
                _context.Add(word);
                _context.SaveChanges();
            }
        }
    }
}
