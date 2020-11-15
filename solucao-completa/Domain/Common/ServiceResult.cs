using System.Collections.Generic;

namespace MassTransitTutorial.Domain
{
    public class ServiceResult<T>
    {
        public ServiceResultType Type { get; private set; }
        public T Model { get; private set; }
        public IEnumerable<ApplicationError> Errors { get; private set; }

        public static ServiceResult<T> Success(T model) => new ServiceResult<T>
        {
            Type = ServiceResultType.Success,
            Model = model
        };

        public static ServiceResult<T> Error(string code, string message) => new ServiceResult<T>
        {
            Type = ServiceResultType.Error,
            Errors = new List<ApplicationError>
            {
                new ApplicationError { Code = code, Message = message }
            }
        };

        public static ServiceResult<T> NotFound() => new ServiceResult<T>
        {
            Type = ServiceResultType.NotFound
        };

        public bool IsSucccess() => Type == ServiceResultType.Success;
    }
}
