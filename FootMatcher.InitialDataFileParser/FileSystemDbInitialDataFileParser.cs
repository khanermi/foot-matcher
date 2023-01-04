using FootMatcher.Models.Models;

namespace FootMatcher.InitialDataFileParser
{
    public class FileSystemDbInitialDataFileParser
    {
        public IEnumerable<Team> Parse(IEnumerable<string> lines)
        {
            var teams = lines.Select(Parse);

            return teams;
        }

        private Team Parse(string line)
        {
            var lineElements = line.Split("/");

            var lineElementsCount = lineElements.Count();
            if (lineElementsCount != 3 &&
                lineElementsCount != 5)
            {
                throw new Exception($"wrong line: {line}");
            }

            var isNationalTeam = lineElementsCount == 3;
            
            var isMaleString = isNationalTeam ? lineElements[2] : lineElements[4];
            var isMale = isMaleString == "m";

            var team = new Team()
            {
                CountryName = lineElements[0],
                LeagueName = isNationalTeam ? "<national>" : lineElements[1],
                Name = isNationalTeam ? "<national>" : lineElements[2],
                HalfStarsCount = int.Parse(isNationalTeam ? lineElements[1] : lineElements[3]),
                IsMale = isMale
            };

            return team;
        }
    }
}