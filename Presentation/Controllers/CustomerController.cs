using Application.DTOs.Customer;
using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Customer;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController:ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(CustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterCustomer([FromBody] AddCustomerVM cutomerVM)
        {
           var dto= _mapper.Map<AddCustomerDto>(cutomerVM);

            var result = await _customerService.RegisterCustomerAsync(dto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
