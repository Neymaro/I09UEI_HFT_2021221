using I09UEI_HFT_2021221.Logic;
using I09UEI_HFT_2021221.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace I09UEI_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class TravelAgenciesController : ControllerBase
    {
        private readonly ITravelAgencyLogic _travelAgencyLogic;

        public TravelAgenciesController(ITravelAgencyLogic travelAgencyLogic)
        {
            _travelAgencyLogic = travelAgencyLogic;
        }

        [HttpGet()]
        public IActionResult Get(int id)
        {
            var travelAgency = _travelAgencyLogic.GetOneAgency(id);

            if (travelAgency is null)
                return NotFound();

            return Ok(travelAgency);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var all = _travelAgencyLogic.GetAll();

            if (all is null)
                return NotFound();

            return Ok(all);
        }

        [HttpPost]
        public IActionResult CreateTravelAgency([FromBody] TravelAgencyPostDto dto)
        {
            var travelAgency = _travelAgencyLogic.Create(
                dto.Name,
                dto.Point);

            return Ok(travelAgency);
        }

        [HttpPut]
        public IActionResult UpdatetravelAgency([FromBody] TravelAgencyPutDto dto)
        {
            var travelAgency = _travelAgencyLogic.Update(dto.Id, dto.Name, dto.Rating);

            return Ok(travelAgency);
        }

        [HttpDelete]
        public IActionResult PuttravelAgency(int id)
        {
            _travelAgencyLogic.DeleteAgency(id);

            return Ok();
        }
    }
}
