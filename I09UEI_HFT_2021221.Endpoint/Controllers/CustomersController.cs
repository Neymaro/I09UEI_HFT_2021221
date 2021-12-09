using I09UEI_HFT_2021221.Logic;
using I09UEI_HFT_2021221.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace I09UEI_HFT_2021221.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerLogic _customerLogic;

        public CustomersController(ICustomerLogic customerLogic)
        {
            _customerLogic = customerLogic;
        }

        [HttpGet()]
        public IActionResult Get(int customerId)
        {
            var customer = _customerLogic.GetCustomer(customerId);

            if (customer is null)
                return NotFound();

            return Ok(customer);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var customers = _customerLogic.GetAll().ToList();

            if (customers is null)
                return NotFound();

            return Ok(customers);
        }

        [HttpPost]
        public IActionResult PostCustomer([FromBody] CustomerPostDto customerDto)
        {
            var customer = _customerLogic.AddNew(
                customerDto.CustomerName,
                customerDto.Phone,
                customerDto.TravelAgencyId);

            return Ok(customer);
        }

        [HttpPut]
        public IActionResult PutCustomer([FromBody] CustomerPutDto customerDto)
        {
            var customer = _customerLogic.UpdateCustomer(customerDto.Id, customerDto.CustomerName, customerDto.PhoneNumber);

            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            _customerLogic.DeleteCustomer(id);

            return Ok();
        }
    }
}
