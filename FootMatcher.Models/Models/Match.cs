using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.Models.Models
{
    public class Match
    {
        public Team FirstPlayerTeam { get; set; }
        public Team SecondPlayerTeam { get; set; }

        public int FirstPlayerScore { get; set; }
        public int SecondPlayerScore { get; set; }
    }
}
