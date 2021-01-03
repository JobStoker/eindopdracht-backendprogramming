using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

#nullable disable

namespace Lingo.Models
{
    public partial class Word
    {
        public Word()
        {
            Rounds = new HashSet<Round>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Round> Rounds { get; set; }

        /// <summary>
        /// Compares the word to guessed word in turn character by character
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Json array with results</returns>
        public Turn CompareWord(Turn turn)
        {

            if(turn.GuessedWord.Length == this.Name.Length)
            {
                for(var i = 0; i < turn.GuessedWord.Length; i++)
                {
                    if (turn.GuessedWord[i] == this.Name[i])
                    {
                        turn.Result.Add("correct");
                    }
                    else
                    {
                        if (this.Name.Contains(turn.GuessedWord[i]))
                        {
                            turn.Result.Add("present");
                        }
                        else
                        {
                            turn.Result.Add("absent");
                        }
                    }
                }
            }

            return turn;
        }
    }
}
