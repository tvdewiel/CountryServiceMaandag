using CountryServiceMaandag.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountryServiceMaandag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryRepository repo;

        public CountryController(ICountryRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IEnumerable<Country> Getall([FromQuery] string continent, [FromQuery] string? capital)
        {
            if (!string.IsNullOrWhiteSpace(continent))
            {
                if (!string.IsNullOrWhiteSpace(capital))
                {
                    return repo.GetAll(continent, capital);
                }
                else
                {
                    return repo.GetAll(continent);
                }
            }
            else
                return repo.GetAll();
        }
        //[HttpHead]
        //[HttpGet]
        //public IEnumerable<Country> Get()
        //{
        //    return repo.GetAll();
        //}
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    try
        //    {
        //        return Ok(repo.GetCountry(id));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(404);
        //    }
        //}
        //[HttpGet("{id}")]
        //public ActionResult<Country> Get(int id)
        //{
        //    try
        //    {
        //        return repo.GetCountry(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
