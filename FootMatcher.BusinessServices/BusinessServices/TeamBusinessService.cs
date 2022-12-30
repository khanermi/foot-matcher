using FootMatcher.BusinessServices.Interfaces.Interfaces;
using FootMatcher.Models.Models;
using FootMatcher.Repositories.Interfaces.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.BusinessServices.BusinessServices
{
    public class TeamBusinessService : ITeamBusinessService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamBusinessService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public void AddTeam(Team team)
        {
            if (team == null)
            {
                throw new ArgumentNullException(nameof(team));
            }

            var isDuplicate = _teamRepository.Get().Any(x => x.Equals(team));
            if (isDuplicate)
            {
                throw new Exception("Trying to add duplicate team");
            }

            _teamRepository.Add(team);
        }

        public void AddTeams(IEnumerable<Team> teams)
        {
            if (teams == null)
            {
                throw new ArgumentNullException(nameof(teams));
            }

            var storedItems = _teamRepository.Get();
            var itemsToAdd = teams.Where(x => storedItems.All(y => !x.Equals(y)));
            
            _teamRepository.Add(itemsToAdd);
        }

        public void DeleteTeam(Guid id)
        {
            _teamRepository.Delete(id);
        }

        public void DeleteTeam(Team team)
        {
            _teamRepository.Delete(team);
        }

        public void DeleteTeams(Func<Team, bool> predicate)
        {
            _teamRepository.Delete(predicate);
        }

        public Team GetTeam(Guid id)
        {
            var team = _teamRepository.Get(id);

            return team;
        }

        public IEnumerable<Team> GetTeams()
        {
            var teams = _teamRepository.Get();

            return teams;
        }

        public IEnumerable<Team> GetTeams(Func<Team, bool> predicate)
        {
            var teams = _teamRepository.Get(predicate);

            return teams;
        }

        public void UpdateTeam(Team team)
        {
            if (team == null)
            {
                throw new ArgumentNullException(nameof(team));
            }

            var existedTeam = _teamRepository.Get(team.Id);
            if (existedTeam == null)
            {
                throw new Exception("Trying to update not existing team");
            }

            _teamRepository.Update(team);
        }
    }
}
