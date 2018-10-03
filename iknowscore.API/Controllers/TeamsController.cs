using System.Threading.Tasks;
using iknowscore.API.Core;
using iknowscore.Services.Interfaces;
using iknowscore.Services.Requests;
using iknowscore.Services.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iknowscore.API.Controllers
{
    /// <summary>
    /// Teams API controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class TeamsController : Controller
    {
        private readonly ITeamService _teamService;

        /// <summary>
        /// ctor
        /// </summary>
        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        /// <summary>
        /// Returns all teams
        /// GET: api/Teams
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetTeams(TeamsRequest request)
        {
            var teamsVm = await _teamService.GetTeamsAsync(request);

            return Response.CreateOkListResult(teamsVm.Items, teamsVm.TotalItems);
        }

        /// <summary>
        /// Returns team by ID
        /// GET: api/Teams/5
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam([FromRoute] int id)
        {
            var teamVm = await _teamService.GetTeamByIdAsync(id);

            return Ok(teamVm);
        }

        /// <summary>
        /// Updates team by ID
        /// PUT: api/Teams/5
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam([FromRoute] int id, [FromBody] TeamViewModel teamVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _teamService.UpdateTeamAsync(id, teamVm);

            return Ok();
        }

        /// <summary>
        /// Creates new team
        /// POST: api/Teams
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> PostTeam([FromBody] TeamViewModel teamVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _teamService.CreateTeamAsync(teamVm);

            return CreatedAtAction("GetTeam", new { id = teamVm.TeamId }, teamVm);
        }

        /// <summary>
        /// Deletes team by ID
        /// DELETE: api/Teams/5
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam([FromRoute] int id)
        {
            await _teamService.DeleteTeamAsync(id);

            return Ok();
        }
    }
}