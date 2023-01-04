using FootMatcher.BusinessServices.Interfaces.Interfaces;
using FootMatcher.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.BusinessServices.BusinessServices
{
    public class MatchBusinessService : IMatchBusinessService
    {
        public Match GenerateMatch()
        {
            throw new NotImplementedException();
        }

        // value -1 for halfStarsCount is binded for "Any stars" value
        public Match GenerateMatch(IEnumerable<Team> teams, int halfStarsCount = -1)
        {
            var random = new Random();

            if (halfStarsCount == -1)
            {
                halfStarsCount = random.Next(1, 10);
            }
            
            var filteredTeams = teams.Where(x => x.HalfStarsCount == halfStarsCount);

            var firstRandomIndex = random.Next(0, filteredTeams.Count() - 1);
            var secondRandomIndex = random.Next(0, filteredTeams.Count() - 1);
            while (secondRandomIndex == firstRandomIndex)
            {
                secondRandomIndex = random.Next(0, filteredTeams.Count() - 1);
            }

            var match = new Match()
            {
                FirstPlayerTeam = filteredTeams.ElementAt(firstRandomIndex),
                SecondPlayerTeam = filteredTeams.ElementAt(secondRandomIndex),
            };

            return match;
        }
    }
}
