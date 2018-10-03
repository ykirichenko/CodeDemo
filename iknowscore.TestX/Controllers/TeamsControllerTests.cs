using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iknowscore.API.Controllers;
using iknowscore.DomainModel.Models;
using iknowscore.Services.Core;
using iknowscore.Services.Interfaces;
using iknowscore.Services.Requests;
using iknowscore.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace iknowscore.TestX.Controllers
{
    public class TeamsControllerTests : BaseControllerTests
    {
        [Fact]
        public async void GetTeams_Valid_FirstPage_Request()
        {
            // Arrange
            var teams = GetTestTeams();
            var teamService = new Mock<ITeamService>();
            var controller = InitTeamsController(teamService);
            var request = new TeamsRequest { PageIndex = 1, PageSize = 2 };
            teamService.Setup(repo => repo.GetTeamsAsync(request)).Returns(Task.FromResult(new GenericResponse<TeamViewModel> { Items = teams, TotalItems = teams.Count }));

            // Act
            var result = await controller.GetTeams(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<TeamViewModel>>(okObjectResult.Value);
        }

        [Fact]
        public async void GetTeams_Valid_FilterByCountryId_Request()
        {
            // Arrange
            var teams = GetTestTeams();
            var teamService = new Mock<ITeamService>();
            var controller = InitTeamsController(teamService);
            var request = new TeamsRequest { CountryId = 1 };
            teamService.Setup(repo => repo.GetTeamsAsync(request)).Returns(Task.FromResult(new GenericResponse<TeamViewModel> { Items = teams, TotalItems = teams.Count }));

            // Act
            var result = await controller.GetTeams(request);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IList<TeamViewModel>>(okObjectResult.Value);
        }

        [Fact]
        public async Task GetTeam_ValidRequest()
        {
            // Arrange
            var teamId = 1;
            var team = GetTestTeams().First(e => e.TeamId == teamId);
            var teamService = new Mock<ITeamService>();
            teamService.Setup(repo => repo.GetTeamByIdAsync(teamId)).Returns(Task.FromResult(team));
            var controller = InitTeamsController(teamService);

            // Act
            var result = await controller.GetTeam(teamId);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<TeamViewModel>(okObjectResult.Value);
            Assert.Equal(team.TeamId, model.TeamId);
            Assert.Equal(team.Name, model.Name);
            Assert.Equal(team.City, model.City);
            Assert.Equal(team.Country.CountryId, model.Country.CountryId);
        }

        [Fact]
        public async Task PutTeam_Valid()
        {
            // Arrange
            var teamId = 1;
            var team = GetTestTeams().First(e => e.TeamId == teamId);
            var newTeam = new Team { TeamId = teamId, Name = "New Team Name", City = "New City", CountryId = 100 };
            var teamService = new Mock<ITeamService>();
            teamService.Setup(repo => repo.UpdateTeamAsync(teamId, team)).Returns(Task.FromResult(newTeam));
            var controller = InitTeamsController(teamService);
            var vm = new TeamViewModel { TeamId = newTeam.TeamId, Name = newTeam.Name, City = newTeam.City };

            // Act
            var result = await controller.PutTeam(teamId, vm);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task PostTeam_Valid()
        {
            // Arrange
            var teamId = 1;
            var newTeam = new TeamViewModel { TeamId = teamId, Name = "New Team Name", City = "New City", Country = new CountryViewModel { CountryId = 100 } };
            var teamService = new Mock<ITeamService>();
            teamService.Setup(repo => repo.CreateTeamAsync(newTeam)).Returns(Task.FromResult((Team)null));
            var controller = InitTeamsController(teamService);
            var vm = new TeamViewModel { TeamId = newTeam.TeamId, Name = newTeam.Name, City = newTeam.City, Country = new CountryViewModel { CountryId = newTeam.Country.CountryId } };

            // Act
            var result = await controller.PostTeam(vm);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task DeleteTeam_Valid()
        {
            // Arrange
            var teamId = 1;
            var team = GetTestTeams().First(e => e.TeamId == teamId);
            var teamService = new Mock<ITeamService>();
            teamService.Setup(repo => repo.GetTeamByIdAsync(teamId)).Returns(Task.FromResult(team));
            var controller = InitTeamsController(teamService);

            // Act
            var result = await controller.DeleteTeam(teamId);

            // Assert
            Assert.IsType<OkResult>(result);
            teamService.Verify(v => v.DeleteTeamAsync(teamId), Times.Once);
        }

        private static TeamsController InitTeamsController(Mock<ITeamService> teamService)
        {
            var controller = new TeamsController(teamService.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            return controller;
        }
    }
}
