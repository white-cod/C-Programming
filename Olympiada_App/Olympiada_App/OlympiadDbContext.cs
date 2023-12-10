using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static Olympiada_App.OlympiadDataModel;

namespace Olympiada_App
{
    internal class OlympiadDbContext : DbContext
    {
        public DbSet<Olympiad> Olympiads { get; set; }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Sport> Sports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-C85D6OJ\\SQLEXPRESS;Database=Olympiad;Integrated Security=True;TrustServerCertificate=true;");

        }
        public class MedalStanding
        {
            public string Country { get; set; }
            public int GoldMedals { get; set; }
            public int SilverMedals { get; set; }
            public int BronzeMedals { get; set; }
        }

        public IQueryable<MedalStanding> GetMedalStandingsForOlympiad(int olympiadId)
        {
            return Athletes
                .Where(a => a.OlympiadId == olympiadId)
                .GroupBy(a => a.Country)
                .Select(group => new MedalStanding
                {
                    Country = group.Key,
                    GoldMedals = group.Sum(a => a.GoldMedals),
                });
        }

        public IQueryable<Medalist> GetMedalistsForOlympiad(int olympiadId)
        {
            var medalists = from athlete in Athletes
                            where athlete.OlympiadId == olympiadId
                            join sport in Sports on athlete.SportId equals sport.SportId
                            select new Medalist
                            {
                                AthleteId = athlete.AthleteId,
                                FullName = athlete.FullName,
                                Country = athlete.Country,
                                DateOfBirth = athlete.DateOfBirth,
                                GoldMedals = athlete.GoldMedals,
                                SportName = sport.Name,
                                OlympiadYear = athlete.Olympiad.Year
                            };

            return medalists;
        }

        public string GetCountryWithMostGoldMedals(int olympiadId)
        {
            var mostGoldMedalsCountry = Athletes
                .Where(a => a.OlympiadId == olympiadId)
                .GroupBy(a => a.Country)
                .Select(group => new
                {
                    Country = group.Key,
                    GoldMedals = group.Sum(a => a.GoldMedals)
                })
                .OrderByDescending(x => x.GoldMedals)
                .FirstOrDefault();

            return mostGoldMedalsCountry?.Country;
        }

        public IQueryable<Athlete> GetMostGoldMedalsInSport(int sportId)
        {
            var mostGoldMedalsInSport = Athletes
                .Where(a => a.SportId == sportId)
                .OrderByDescending(a => a.GoldMedals)
                .FirstOrDefault();

            return mostGoldMedalsInSport != null ? new List<Athlete> { mostGoldMedalsInSport }.AsQueryable() : Enumerable.Empty<Athlete>().AsQueryable();
        }

        public string GetCountryWithMostHostedOlympiads()
        {
            var mostHostedCountry = Olympiads
                .GroupBy(o => o.HostCountry)
                .Select(group => new
                {
                    Country = group.Key,
                    HostedCount = group.Count()
                })
                .OrderByDescending(x => x.HostedCount)
                .FirstOrDefault();

            return mostHostedCountry?.Country;
        }

        public IQueryable<Athlete> GetOlympicTeamComposition(string country)
        {
            var olympicTeamComposition = Athletes
                .Where(a => a.Country == country);

            return olympicTeamComposition;
        }

        public IQueryable<Athlete> GetCountryPerformanceStatisticsForAll(int olympiadYear)
        {
            var countryPerformanceStatistics = Athletes
                .Where(a => a.Olympiad.Year == olympiadYear);

            return countryPerformanceStatistics;
        }

        public IQueryable<Olympiad> GetOlympiads()
        {
            return Olympiads;
        }
    }
}