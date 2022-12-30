using FootMatcher.BusinessServices.BusinessServices;
using FootMatcher.BusinessServices.Interfaces.Interfaces;
using FootMatcher.Models.Models;
using FootMatcher.Repositories.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.FileSystemDbPopulator
{
    public class Executer
    {
        private readonly ITeamBusinessService _teamBusinessService;

        public Executer(ITeamBusinessService teamBusinessService)
        {
            _teamBusinessService = teamBusinessService;
        }

        public void Execute()
        {
            var items = new List<Team>() {
                new Team()
                {
                    Id = Guid.NewGuid(),
                    CountryName = @"Spain",
                    Name = @"Barcelona",
                    HalfStarsCount = 10,
                    IsMale = true
                },
                new Team()
                {
                    Id = Guid.NewGuid(),
                    CountryName = @"Spain",
                    Name = "<national>",
                    HalfStarsCount = 10,
                    IsMale = false
                },
                new Team()
                {
                    Id = Guid.NewGuid(),
                    CountryName = @"France",
                    Name = @"LOSC Lille",
                    HalfStarsCount = 8,
                    IsMale = true
                },
                new Team()
                {
                    Id = Guid.NewGuid(),
                    CountryName = @"Argentina",
                    Name = "<national>",
                    HalfStarsCount = 10,
                    IsMale = true
                }
            };


            _teamBusinessService.AddTeams(items);
        }
    }
}
