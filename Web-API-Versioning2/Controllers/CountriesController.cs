using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Versioning2.Models.DTOs;

namespace Web_API_Versioning2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class CountriesController : ControllerBase
    {
        [MapToApiVersion("1.0")]
        [HttpGet]
        public IActionResult GetV1()
        {
            var countriesDomainModel = CountriesData.Get();

            //Map Domain Model to DTO
            var response = new List<CountryDtoV1>();
            foreach (var country in countriesDomainModel)
            {
                response.Add(new CountryDtoV1
                {
                    Id = country.Id,
                    Name = country.Name,
                });
            }
            return Ok(response);
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        public IActionResult GetV2()
        {
            var countriesDomainModel = CountriesData.Get();

            //Map Domain Model to DTO
            var response = new List<CountryDtoV2>();
            foreach (var country in countriesDomainModel)
            {
                response.Add(new CountryDtoV2
                {
                    Id = country.Id,
                    CountryName = country.Name,
                });
            }
            return Ok(response);
        }
    }
}
