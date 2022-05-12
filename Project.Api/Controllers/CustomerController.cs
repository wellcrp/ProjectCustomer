using Microsoft.AspNetCore.Mvc;
using Project.Domain.Model;
using Project.Service.Interface;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> PostAdd([FromBody] CustomerModel customer)
        {
            var result = await _customerService.PostAdd(customer);

            return Ok(result);
        }
    }
}
