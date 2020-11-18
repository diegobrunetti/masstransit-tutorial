using System;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using MassTransitTutorial.Domain;
using MassTransitTutorial.Domain.Events;

namespace MassTransiTutorial.Application
{
    public class CreateCustomerService : ICreateCustomerService
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publisher;

        public CreateCustomerService(ICustomerRepository repo, IMapper mapper, IPublishEndpoint publisher)
        {
            _repo = repo;
            _mapper = mapper;
            _publisher = publisher;
        }

        public async Task<ServiceResult<CustomerDto>> Create(NewCustomerDto data)
        {
            try
            {
                var newCustomer = _mapper.Map<NewCustomer>(data);
                var createdCustomer = await _repo.CreateCustomer(newCustomer);

                await _publisher.Publish<CustomerCreatedEvent>(new
                {
                    CustomerId = createdCustomer.CustomerId.Id,
                    Name = createdCustomer.Name,
                    BirthDate = createdCustomer.BirthDate,
                    Type = createdCustomer.Type.ToString(),
                    CreatedAt = createdCustomer.CreatedAt
                });
                return ServiceResult<CustomerDto>.Success(_mapper.Map<CustomerDto>(createdCustomer));
            }
            catch (ArgumentException e)
            {
                return ServiceResult<CustomerDto>.Error("ERR_VALIDATION", e.Message);
            }
        }
    }
}