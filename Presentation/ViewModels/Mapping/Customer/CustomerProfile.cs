using Presentation.ViewModels.Customer;

namespace Presentation.ViewModels.Mapping.Customer
{
    public class CustomerProfile : AutoMapper.Profile
    {
        public CustomerProfile()
        {
            CreateMap<AddCustomerVM, Application.DTOs.Customer.AddCustomerDto>().ReverseMap();
            //CreateMap<UpdateCustomerVM, Application.DTOs.Customer.UpatedCustomerDto>().ReverseMap();
            //CreateMap<Domain.Models.Users.Customer, Application.DTOs.Customer.CustomerDto>().ReverseMap();
        }
    }
}
