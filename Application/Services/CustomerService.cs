using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Customer;
using Application.DTOs.Response;
using Domain.Helpers;
using Domain.Models.Users;
using Domain.Repositories;

namespace Application.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<ResponseDTO<bool>> RegisterCustomerAsync(AddCustomerDto dto)
        {
            var existing = await _customerRepository.GetByEmailAsync(dto.Email);
            if (existing != null) return ResponseDTO<bool>.Failure(Domain.Enums.ErrorCode.InvalidInput,"This Email Is Already Exist");

            var user = new User
            {
                Email = dto.Email,
                PasswordHash = HashHelper.ComputeHash(dto.Password),
                Username = HashHelper.ComputeHash(dto.UserName),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                City= dto.City,
                Country= dto.Country,

            };

            var customer = new Customer
            {
                User = user,
                NationalId = dto.NationalId,
                DateOfBirth = dto.DateOfBirth
            };

            await _customerRepository.AddAsync(customer); // implement to add both user + customer or rely on cascade
            return ResponseDTO<bool>.Success( true);
        }
        public async Task<ResponseDTO<List<Customer>>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAll();
            return ResponseDTO<List<Customer>>.Success(customers);
        }
        public async Task<ResponseDTO<Customer>> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetById(id);
            if (customer == null) return ResponseDTO<Customer>.Failure(Domain.Enums.ErrorCode.NotFound, "Customer Not Found");
            return ResponseDTO<Customer>.Success(customer);
        }
        public async Task<ResponseDTO<Customer>> GetCustomerByEmailAsync(string email)
        {
            var customer = await _customerRepository.GetByEmailAsync(email);
            if (customer == null) return ResponseDTO<Customer>.Failure(Domain.Enums.ErrorCode.NotFound, "Customer Not Found");
            return ResponseDTO<Customer>.Success(customer);
        }
        public async Task<ResponseDTO<Customer>> UpdateCustomer(UpatedCustomerDto dto)
        {
            throw new NotImplementedException();
        }
        public async Task<ResponseDTO<Customer>> DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();

        }


    }
}
