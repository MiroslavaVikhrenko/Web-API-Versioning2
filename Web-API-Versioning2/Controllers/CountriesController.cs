using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Versioning2.Models.DTOs;

namespace Web_API_Versioning2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var countriesDomainModel = CountriesData.Get();

            //Map Domain Model to DTO
            var response = new List<CountryDto>();
            foreach (var country in countriesDomainModel)
            {
                response.Add(new CountryDto
                {
                    Id = country.Id,
                    Name = country.Name,
                });
            }
            return Ok(response);
        }
    }
}
