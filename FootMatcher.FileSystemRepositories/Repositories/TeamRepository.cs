using FootMatcher.FileSystemRepositories.Options;
using FootMatcher.Models.Models;
using FootMatcher.Repositories.Interfaces.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.FileSystemRepositories.Repositories
{
    public class TeamRepository : FileSystemRepository<Team>, ITeamRepository
    {
        public TeamRepository(IOptions<FileSystemRepositoryOptions> options) : base(options, options.Value.TeamRepositoryFilename)
        {
        }
    }
}
