using System.Collections.Generic;
using System.Linq;
using MassTransitTutorial.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MassTransitTutorial.Api
{
    public static class ModelStateExtensions
    {
        public static IEnumerable<ApplicationError> AsApplicationError(this ModelStateDictionary modelState)
        {
            return modelState
                .Select(e => new ApplicationError
                {
                    Code = e.Key,
                    Message = string.Join("|", e.Value.Errors.Select(m => m.ErrorMessage))
                });
        }
    }
}