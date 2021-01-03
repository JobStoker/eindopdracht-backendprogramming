using System;
using System.Collections.Generic;

#nullable disable

namespace Lingo.Models
{
    public partial class Game
    {
        public Game()
        {
            Rounds = new HashSet<Round>();
        }

        public int Id { get; set; }
        public string AuthToken { get; set; }
        public string Username { get; set; }
        public virtual ICollection<Round> Rounds { get; set; }

        /// <summary>
        /// Returns if a word needs to be 5 / 6 or 7 letters using the modulo operator.
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public int GetWordLengthFromRound(int rounds)
        {
            return rounds % 3 == 0 ? 7 : rounds % 3 + 4;
        }
    }
}
