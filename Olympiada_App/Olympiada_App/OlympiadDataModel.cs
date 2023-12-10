using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiada_App
{
    internal class OlympiadDataModel
    {
        public class Olympiad
        {
            public int OlympiadId { get; set; }
            public int Year { get; set; }
            public string HostCountry { get; set; }
            public string HostCity { get; set; }
            public bool IsSummerOlympiad { get; set; }
            public ICollection<Athlete> Athletes { get; set; }
        }

        public class Athlete
        {
            private string country;

            public int AthleteId { get; set; }
            public string FullName { get; set; }
            public string Country { get => country; set => country = value; }
            public DateTime DateOfBirth { get; set; }
            public int GoldMedals { get; set; }
            public int SportId { get; set; }
            public required Sport Name { get; set; }
            public int OlympiadId { get; set; }
            public Olympiad Olympiad { get; set; }
        }

        public class Sport
        {
            public int SportId { get; set; }
            public string Name { get; set; }
            public ICollection<Athlete> Athletes { get; set; }
        }

        public class Medalist
        {
            public int AthleteId { get; set; }
            public string FullName { get; set; }
            public string Country { get; set; }
            public DateTime DateOfBirth { get; set; }
            public int GoldMedals { get; set; }
            public string SportName { get; set; }
            public int OlympiadYear { get; set; }
        }
    }
}