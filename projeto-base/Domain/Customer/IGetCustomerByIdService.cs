using System;
using System.Threading.Tasks;

namespace MassTransitTutorial.Domain
{
    public interface IGetCustomerByIdService
    {
        Task<ServiceResult<CustomerDto>> GetCustomer(Guid customerId);
    }
}