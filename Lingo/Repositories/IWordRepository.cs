using Lingo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lingo.Repositories
{
    public interface IWordRepository
    {
        void SaveWordList(IEnumerable<Word> words);
        IEnumerable<Word> GetGameWords(int GameId);
    }
}
