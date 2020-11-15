using System.Threading.Tasks;
using AutoMapper;
using MassTransitTutorial.Domain;

namespace MassTransiTutorial.Application
{
    public class UpdateBirthDateService : IUpdateBirthDateService
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public UpdateBirthDateService(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CustomerDto>> Update(UpdateBirthDateDto newDate)
        {
            var customer = await _repo.WithId(CustomerId.FromValue(newDate.CustomerId));

            if (customer != Customer.Empty)
            {
                customer.ChangeBirthDate(newDate.NewBirthDate);
                await _repo.ChangeBirthDate(customer);

                return ServiceResult<CustomerDto>.Success(_mapper.Map<CustomerDto>(customer));
            }
            return ServiceResult<CustomerDto>.Error(
                "ERR_CUST_404", $"There not customer with id {newDate.CustomerId}");
        }
    }
}