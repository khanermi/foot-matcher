using FootMatcher.BusinessServices.BusinessServices;
using FootMatcher.BusinessServices.Interfaces.Interfaces;
using FootMatcher.InitialDataFileParser;
using FootMatcher.Models.Models;
using FootMatcher.Repositories.Interfaces.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootMatcher.FileSystemDbPopulator
{
    //TODO: rewrite all using statements to short format
    public class Executer
    {
        private readonly ITeamBusinessService _teamBusinessService;
        private readonly FileSystemDbPopulatorOptions _options;
        private readonly string _initialDataFilepath;

        public Executer(ITeamBusinessService teamBusinessService, IOptions<FileSystemDbPopulatorOptions> options)
        {
            _teamBusinessService = teamBusinessService;
            _options = options.Value;

            _initialDataFilepath = $"{_options.InitialDataFileDirectoryPath}/{_options.InitialDataFilename}";
        }

        public void Execute()
        {
            var initialDataLines = GetInitialDataFromFile(_initialDataFilepath);

            var parser = new FileSystemDbInitialDataFileParser();
            var initialData = parser.Parse(initialDataLines);

            _teamBusinessService.AddTeams(initialData);
        }

        public IEnumerable<string> GetInitialDataFromFile(string filePath)
        {
            using var reader = new StreamReader(filePath);
            
            var fileLines = new List<string>(1000);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                if (!line.Equals(string.Empty))
                {
                    fileLines.Add(line);
                }
            }

            return fileLines;
        }
    }
}
