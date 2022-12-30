namespace FootMatcher.Models.Models
{
    public class Team : ModelBase
    {
        public string CountryName { get; set; } //ak1
        public string Name { get; set; } //ak1
        public int HalfStarsCount { get; set; }
        public bool IsMale { get; set; } //ak1

        public override bool Equals(object obj)
        {
            if (obj is not Team team)
            {
                return false;
            }

            return CountryName == team.CountryName &&
                Name == team.Name &&
                IsMale == team.IsMale;
        }
    }
}
