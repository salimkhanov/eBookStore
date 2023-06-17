using eBookStore.Application.DTOs.Address;
using eBookStore.Application.DTOs.Country;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [Route("/GetAllCountries")]
        [HttpGet]
        public IActionResult GetAllCountries()
        {
            return Ok(_countryService.GetCountries());
        }

        [Route("/GetCountryById")]
        [HttpGet]
        public IActionResult GetCountryById(int countryId)
        {
            var result = _countryService.GetCountryById(countryId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Nothing Found");
        }

        [Route("/CreateCountry")]
        [HttpPost]
        public IActionResult CreateCountry(CreateCountryDTO createCountryDTO)
        {
            _countryService.CreateCountry(createCountryDTO);
            return Ok("Successfully created");
        }

        [Route("/UpdateCountry")]
        [HttpPut]
        public IActionResult UpdateCountry(UpdateCountryDTO updateCountryDTO)
        {
            if (_countryService.UpdateCountry(updateCountryDTO))
            {
                return Ok("Successfully updated");
            }
            return BadRequest($"Country with ID {updateCountryDTO.Id} not found.");
        }

        [Route("/DeleteCountry")]
        [HttpDelete]
        public IActionResult DeleteCountry(int countryId)
        {
            if (_countryService.DeleteCountry(countryId))
            {
                return Ok("Successfully deleted");
            }
            return BadRequest($"Country with ID {countryId} not found.");
        }

        [Route("/DeactivateCountry")]
        [HttpPut]
        public IActionResult DeactivateCountry(int countryId)
        {
            if (_countryService.DeactivateCountry(countryId))
            {
                return Ok("Successfully deactivated");
            }
            return BadRequest($"Country with ID {countryId} not found.");
        }

        [Route("/ActivateCountry")]
        [HttpPut]
        public IActionResult ActivateCountry(int countryId)
        {
            if (_countryService.ActivateCountry(countryId))
            {
                return Ok("Successfully activated");
            }
            return BadRequest($"Country with ID {countryId} not found.");
        }

        [Route("/AllCountriesForDropDown")]
        [HttpGet]
        public IActionResult AllCountriesForDropDown()
        {
            return Ok(_countryService.AllCountriesForDropDown());
        }

        [Route("/CreateCountries")]
        [HttpPost]
        public IActionResult CreateCountries(List<CreateCountryDTO> createCountryDTOs)
        {
            _countryService.CreateCountries(createCountryDTOs);
            return Ok("Successfully created");
        }

        [Route("/DeleteCountries")]
        [HttpDelete]
        public IActionResult DeleteCountries(List<int> countries)
        {
            if (_countryService.DeleteCountries(countries))
            {
                return Ok("Successfully deleted");
            }
            return BadRequest("Failed to delete");
        }

        [Route("/UpdateCountries")]
        [HttpPut]
        public IActionResult UpdateCountries(List<UpdateCountryDTO> updateCountryDTOs)
        {
            if (_countryService.UpdateCountries(updateCountryDTOs))
            {
                return Ok("Successfully updated");
            }
            return BadRequest("Failed to update countries");
        }
    }
}
