using System;
using System.Collections.Generic;

#nullable disable

namespace Lingo.Models
{
    public partial class Word
    {
        public Word()
        {
            GameWords = new HashSet<GameWord>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GameWord> GameWords { get; set; }
    }
}
