using System;
using System.Collections.Generic;

#nullable disable

namespace Lingo.Models
{
    public partial class GameWord
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int WordId { get; set; }
        public bool Correct { get; set; }
        public virtual Game Game { get; set; }
        public virtual Word Word { get; set; }
    }
}
