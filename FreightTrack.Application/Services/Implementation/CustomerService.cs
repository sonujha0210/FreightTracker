using FreightTrack.Application.DTO.Request;
using FreightTrack.Application.DTO.Response;
using FreightTrack.Application.Interface;
using FreightTrack.Application.Services.Interface;
using FreightTrack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Application.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null) return null;

            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Role = customer.Role
            };
        }

        public async Task<CustomerDto> GetByEmailAsync(string email)
        {
            var customer = await _customerRepository.GetByEmailAsync(email);
            if (customer == null) return null;

            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Role = customer.Role
            };
        }

        public async Task AddAsync(CreateCustomerDto dto)
        {
            var customer = new Customer
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = dto.Password, // BCrypt hashing comes on Day 10
                Role = dto.Role,
                CreatedAt = DateTime.UtcNow
            };
            await _customerRepository.AddAsync(customer);
        }
    }
}
