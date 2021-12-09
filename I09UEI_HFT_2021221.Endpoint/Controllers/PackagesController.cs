using I09UEI_HFT_2021221.Logic;
using I09UEI_HFT_2021221.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace I09UEI_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageLogic _packageLogic;

        public PackagesController(IPackageLogic packageLogic)
        {
            _packageLogic = packageLogic;
        }

        [HttpGet()]
        public IActionResult Get(int id)
        {
            var travelAgency = _packageLogic.GetOnePackage(id);

            if (travelAgency is null)
                return NotFound();

            return Ok(travelAgency);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var all = _packageLogic.GetAllPackages();

            if (all is null)
                return NotFound();

            return Ok(all);
        }

        [HttpPost]
        public IActionResult CreateTravelAgency([FromBody] PackagePostDto dto)
        {
            var package = _packageLogic.AddNewPackage(dto.Name, dto.Category, dto.Price, dto.VisaNeeded, dto.Description, dto.TravelAgencyId);

            return Ok(package);
        }

        [HttpPut]
        public IActionResult UpdatetravelAgency([FromBody] PackagePutDto dto)
        {
            var package = _packageLogic.Update(dto.Id, dto.Name, dto.Category, dto.Price, dto.VisaNeeded, dto.Description);

            return Ok(package);
        }

        [HttpDelete]
        public IActionResult PuttravelAgency(int id)
        {
            _packageLogic.DeletePackage(id);

            return Ok();
        }

        [HttpPost("GetPackagesWithCategory")]
        public IActionResult GetPackagesWithCategory([FromBody] PackagesWithCategoryPostDto dto)
        {
            var packages = _packageLogic.GetPackagesWithCategory(dto.TravelAgencyIds, dto.Category);

            if (packages is null)
                return NotFound();

            return Ok(packages);
        }

        [HttpGet("GetPackagesVisaNeeded")]
        public IActionResult GetPackagesVisaNeeded(int travelAgencyId, bool visaNeeded)
        {
            var packages = _packageLogic.GetPackagesVisaNeeded(travelAgencyId, visaNeeded);

            if (packages is null)
                return NotFound();

            return Ok(packages);
        }

        [HttpGet("GetPackagesAbovePrice")]
        public IActionResult GetPackagesAbovePrice(int travelAgencyId, int price)
        {
            var packages = _packageLogic.GetPackagesAbovePrice(travelAgencyId, price);

            if (packages is null)
                return NotFound();

            return Ok(packages);
        }
    }
}
