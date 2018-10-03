using System.Threading.Tasks;
using iknowscore.Services.Core;
using iknowscore.Services.Requests;
using iknowscore.Services.ViewModels;

namespace iknowscore.Services.Interfaces
{
    public interface ITeamService
    {
        Task<GenericResponse<TeamViewModel>> GetTeamsAsync(TeamsRequest request);

        Task<TeamViewModel> GetTeamByIdAsync(int teamId);

        Task UpdateTeamAsync(int teamId, TeamViewModel teamVm);

        Task CreateTeamAsync(TeamViewModel teamVm);

        Task DeleteTeamAsync(int teamId);
    }
}
