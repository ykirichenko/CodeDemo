using iknowscore.DomainModel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using iknowscore.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace iknowscore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class CountriesController : Controller
    {
        private readonly IRepository<Country> _countryRepository;

        public CountriesController(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await _countryRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountry([FromRoute] int id)
        {
            var country = await _countryRepository.FindFirstAsync(c => c.CountryId == id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry([FromRoute] int id, [FromBody] Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != country.CountryId)
            {
                return BadRequest();
            }

            await _countryRepository.UpdateAsync(id, country);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostCountry([FromBody] Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _countryRepository.CreateAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.CountryId }, country);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var country = await _countryRepository.FindFirstAsync(c => c.CountryId == id);
            if (country == null)
            {
                return NotFound();
            }

            await _countryRepository.DeleteAsync(c => c.CountryId == id);

            return Ok();
        }
    }
}