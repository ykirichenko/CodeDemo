using System.Collections.Generic;
using iknowscore.Services.ViewModels;
using Xunit;

namespace iknowscore.TestX
{
    public class BaseControllerTests : IClassFixture<AutoMapperFixture>
    {
        protected List<TournamentViewModel> GetTestTournaments()
        {
            var tournaments = new List<TournamentViewModel>();

            tournaments.Add(new TournamentViewModel
            {
                TournamentId = 1,
                Name = "La Liga",
                ShortCode = "LaLiga"
            });

            tournaments.Add(new TournamentViewModel
            {
                TournamentId = 2,
                Name = "Seria A",
                ShortCode = "SeriaA"
            });

            tournaments.Add(new TournamentViewModel
            {
                TournamentId = 3,
                Name = "World Cup 2018",
                ShortCode = "WC2018"
            });

            tournaments.Add(new TournamentViewModel
            {
                TournamentId = 4,
                Name = "Friendly Games 2018",
                ShortCode = "FG2018"
            });

            return tournaments;
        }

        protected List<TeamViewModel> GetTestTeams()
        {
            var list = new List<TeamViewModel>();

            list.Add(new TeamViewModel
            {
                TeamId = 1,
                Name = "Test Team 1",
                City = "Kharkiv",
                Country = new CountryViewModel { CountryId = 1, Name = "USA" }
            });

            list.Add(new TeamViewModel
            {
                TeamId = 2,
                Name = "Test Team 2",
                City = "New York",
                Country = new CountryViewModel { CountryId = 2, Name = "Ukraine" }
            });

            list.Add(new TeamViewModel
            {
                TeamId = 3,
                Name = "Test Team 3",
                City = "London",
                Country = new CountryViewModel { CountryId = 1, Name = "USA" }
            });

            list.Add(new TeamViewModel
            {
                TeamId = 4,
                Name = "Test Team 4",
                City = "Kiev",
                Country = new CountryViewModel { CountryId = 2, Name = "Ukraine" }
            });

            list.Add(new TeamViewModel
            {
                TeamId = 5,
                Name = "Test Team 5",
                City = "Odessa",
                Country = new CountryViewModel { CountryId = 3, Name = "Canada" }

            });

            return list;
        }
    }
}
