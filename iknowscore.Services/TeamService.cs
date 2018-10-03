using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using iknowscore.DomainModel.Models;
using iknowscore.Repositories.Interfaces;
using iknowscore.Services.Core;
using iknowscore.Services.Exceptions;
using iknowscore.Services.Interfaces;
using iknowscore.Services.Requests;
using iknowscore.Services.ViewModels;

namespace iknowscore.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepository<Team> _teamRepository;

        /// <summary>
        /// ctor
        /// </summary>
        public TeamService(IRepository<Team> teamRepository)
        {
            _teamRepository = teamRepository;
        }

        /// <summary>
        /// Gets Teams by request
        /// </summary>
        public async Task<GenericResponse<TeamViewModel>> GetTeamsAsync(TeamsRequest request)
        {
            if (request == null)
            {
                throw new NotFoundException("The request is empty");
            }

            Expression<Func<Team, bool>> filter = e => !request.CountryId.HasValue || e.CountryId == request.CountryId.Value;

            var teamsCount = await _teamRepository.FindCountAsync(filter);

            var teamsPage = await _teamRepository.FindPageAsync(
                filter,
                request.Sorting,
                request.PageIndex,
                request.PageSize);

            var teamsVm = Mapper.Map<IEnumerable<Team>, IEnumerable<TeamViewModel>>(teamsPage);

            return new GenericResponse<TeamViewModel>
            {
                TotalItems = teamsCount,
                Items = teamsVm
            };
        }

        /// <summary>
        /// Gets Team by ID
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public async Task<TeamViewModel> GetTeamByIdAsync(int teamId)
        {
            var team = await _teamRepository.FindFirstAsync(t => t.TeamId == teamId);
            if (team == null)
            {
                throw new NotFoundException("The requested team was not found");
            }

            TeamViewModel teamVm = Mapper.Map<Team, TeamViewModel>(team);

            return teamVm;
        }

        /// <summary>
        /// Updates Teams
        /// </summary>
        public async Task UpdateTeamAsync(int teamId, TeamViewModel teamVm)
        {
            if (teamId != teamVm.TeamId)
            {
                throw new ValidationException("The updated object has an incorrect teamID value");
            }

            Team team = Mapper.Map<TeamViewModel, Team>(teamVm);

            await _teamRepository.UpdateAsync(teamId, team);
        }

        /// <summary>
        /// Creates Team
        /// </summary>
        public async Task CreateTeamAsync(TeamViewModel teamVm)
        {
            Team team = Mapper.Map<TeamViewModel, Team>(teamVm);

            await _teamRepository.CreateAsync(team);
        }

        /// <summary>
        /// Deletes Team
        /// </summary>
        public async Task DeleteTeamAsync(int teamId)
        {
            var team = await _teamRepository.FindFirstAsync(t => t.TeamId == teamId);
            if (team == null)
            {
                throw new NotFoundException("The requested team was not found");
            }

            await _teamRepository.DeleteAsync(t => t.TeamId == teamId);
        }
    }
}
