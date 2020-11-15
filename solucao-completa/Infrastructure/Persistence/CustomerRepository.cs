using System;
using System.Threading.Tasks;
using AutoMapper;
using MassTransitTutorial.Domain;
using Microsoft.EntityFrameworkCore;

namespace MassTransitTutorial.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(CustomerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Customer> CreateCustomer(NewCustomer customer)
        {
            var entity = _mapper.Map<TbCustomer>(customer);
            _context.Customers.Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Customer>(entity);
        }

        public async Task ChangeBirthDate(Customer customer)
        {
            var entity = await _context.Customers.SingleOrDefaultAsync(c => c.Id == Guid.Parse(customer.CustomerId.Id));

            if (entity != null)
            {
                entity.BirthDate = customer.BirthDate;
                entity.UpdatedAt = customer.UpdatedAt;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<Customer> WithId(CustomerId customerId)
        {
            var entity = await _context.Customers.SingleOrDefaultAsync(c => c.Id == Guid.Parse(customerId.Id));
            return _mapper.Map<Customer>(entity) ?? Customer.Empty;
        }
    }
}