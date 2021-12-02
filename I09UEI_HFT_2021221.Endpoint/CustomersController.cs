using I09UEI_HFT_2021221.Endpoint.Dtos;
using I09UEI_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetCustomer(int customerId)
        {
            var customer = _customerLogic.GetCustomer(customerId);

            if (customer is null)
                return NotFound();

            return Ok(customer);
        }

        [HttpGet("all")]
        public IActionResult GetCustomers()
        {
            var customers = _customerLogic.GetAll();

            if (customers is null)
                return NotFound();

            return Ok(customers);
        }

        [HttpPost]
        public IActionResult PostCustomer([FromBody] CustomerPostDto customerDto)
        {
            var customer = _customerLogic.AddNew(
                customerDto.CustomerName,
                customerDto.Phone);

            return Ok(customer);
        }

        [HttpPut]
        public IActionResult PutCustomer([FromBody] CustomerPutDto customerDto)
        {
            var customer = _customerLogic.UpdateCustomer(customerDto.Id, customerDto.CustomerName, customerDto.PhoneNumber);

            return Ok(customer);
        }

        [HttpDelete]
        public IActionResult PutCustomer(int customerId)
        {
            _customerLogic.DeleteCustomer(customerId);

            return Ok();
        }
    }
}
