using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lingo.Models
{
    public class Turn
    {
        public int Id { get; set; }
        public int RoundId { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime BeginTime { get; set; }     
        public String GuessedWord { get; set; }
        public virtual Round Round { get; set; }
        [NotMapped]
        public List<String> Result { get; set; }

        public Turn()
        {
            Result = new List<String>();
        }
    }
}
