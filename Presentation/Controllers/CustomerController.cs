using Application.DTOs.Customer;
using Application.Services;
using AutoMapper;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Customer;
using Presentation.ViewModels.Response;

namespace Presentation.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(CustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ResponseViewModel<bool>> RegisterCustomer([FromBody] AddCustomerVM cutomerVM)
        {
            var dto = _mapper.Map<AddCustomerDto>(cutomerVM);

            var result = await _customerService.RegisterCustomerAsync(dto);
            if (!result.IsSuccess)
        {
                return new ErrorResponseViewModel<bool>(ErrorCode.InternalError, result.Message);
            }

            var mapped = _mapper.Map<bool>(result.Data);
            return new SuccessResponseViewModel<bool>(mapped);
        }

    }
}
