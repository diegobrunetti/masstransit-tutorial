using System.Threading.Tasks;

namespace MassTransitTutorial.Domain
{
    public interface IUpdateBirthDateService
    {
        Task<ServiceResult<CustomerDto>> Update(UpdateBirthDateDto newDate);
    }
}