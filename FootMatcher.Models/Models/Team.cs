﻿namespace FootMatcher.Models.Models
{
    public class Team : ModelBase
    {
        public string CountryName { get; set; }
        public string Name { get; set; }
        public int HalfStarsCount { get; set; }
        public bool IsMale { get; set; }
    }
}