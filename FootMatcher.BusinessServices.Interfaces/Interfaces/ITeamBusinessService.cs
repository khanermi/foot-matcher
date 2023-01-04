using FootMatcher.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.BusinessServices.Interfaces.Interfaces
{
    public interface ITeamBusinessService : IBusinessService
    {
        void AddTeam(Team team);
        void AddTeams(IEnumerable<Team> teams);

        void UpdateTeam(Team team);

        Team GetTeam(Guid id);
        IEnumerable<Team> GetTeams();
        IEnumerable<Team> GetTeams(Func<Team, bool> predicate);

        void DeleteTeam(Guid id);
        void DeleteTeam(Team team);
        void DeleteTeams(Func<Team, bool> predicate);
    }
}
