using System.Threading.Tasks;

namespace MassTransitTutorial.Domain
{
    public interface ICreateCustomerService
    {
        Task<ServiceResult<CustomerDto>> Create(NewCustomerDto data);
    }
}