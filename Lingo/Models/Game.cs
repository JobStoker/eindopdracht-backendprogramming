using System;
using System.Collections.Generic;

#nullable disable

namespace Lingo.Models
{
    public partial class Game
    {
        public Game()
        {
            GameWords = new HashSet<GameWord>();
            Scores = new HashSet<Score>();
        }

        public int Id { get; set; }
        public string AuthToken { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime BeginTime { get; set; }

        public virtual ICollection<GameWord> GameWords { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}
