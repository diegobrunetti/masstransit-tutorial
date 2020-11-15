using System;
using System.Threading.Tasks;
using AutoMapper;
using MassTransitTutorial.Domain;

namespace MassTransiTutorial.Application
{
    public class GetCustomerByIdService : IGetCustomerByIdService
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public GetCustomerByIdService(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CustomerDto>> GetCustomer(Guid customerId)
        {
            var customer = await _repo.WithId(CustomerId.FromValue(customerId));

            if (customer != Customer.Empty)
            {
                return ServiceResult<CustomerDto>.Success(_mapper.Map<CustomerDto>(customer));
            }
            return ServiceResult<CustomerDto>.NotFound();
        }
    }
}