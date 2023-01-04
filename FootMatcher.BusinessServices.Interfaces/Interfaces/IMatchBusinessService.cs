using FootMatcher.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.BusinessServices.Interfaces.Interfaces
{
    public interface IMatchBusinessService : IBusinessService
    {
        Match GenerateMatch();
        Match GenerateMatch(IEnumerable<Team> teams, int halfStarsCount);
    }
}
