using System;
using System.Collections.Generic;

#nullable disable

namespace Lingo.Models
{
    public partial class Score
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public decimal Score1 { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
