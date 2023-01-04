using FootMatcher.BusinessServices.Interfaces.Interfaces;
using FootMatcher.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.BusinessServices.BusinessServices
{
    public class SessionBusinessService : ISessionBusinessService
    {
        private readonly IMatchBusinessService _matchBusinessService;
        private readonly ITeamBusinessService _teamBusinessService;

        public SessionBusinessService(IMatchBusinessService matchBusinessService,
            ITeamBusinessService teamBusinessService)
        {
            _matchBusinessService = matchBusinessService;
            _teamBusinessService = teamBusinessService;
        }

        public Session GenerateDefaultSession()
        {
            var teams = _teamBusinessService.GetTeams(x => x.IsMale);

            var session = new Session();

            var matches = new List<Match>();
            for (int halfStarsCount = 1; halfStarsCount < 11; halfStarsCount++)
            {
                matches.Add(_matchBusinessService.GenerateMatch(teams, halfStarsCount));
            }

            session.Matches = matches;

            return session;
        }
    }
}
