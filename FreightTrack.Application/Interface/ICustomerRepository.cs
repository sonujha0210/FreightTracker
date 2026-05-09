using FreightTrack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Application.Interface
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(int Id);
        Task<Customer>GetByEmailAsync(string email);
        Task AddAsync(Customer customer);
    }
}
