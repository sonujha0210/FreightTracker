using FreightTrack.Application.Interface;
using FreightTrack.Domain.Models;
using FreightTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FreightTrackDbContext _context;
        public CustomerRepository(FreightTrackDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync(); 
        }

        public async Task<Customer> GetByEmailAsync(string email)
        {
            
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Customer> GetByIdAsync(int Id)
        {
            return await _context.Customers.FindAsync(Id);
        }
    }
}
