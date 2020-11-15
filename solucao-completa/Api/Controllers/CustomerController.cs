using System;
using System.Threading.Tasks;
using MassTransitTutorial.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MassTransitTutorial.Api
{
    [Produces("application/json")]
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewCustomerDto data, [FromServices] ICreateCustomerService service)
        {
            var result = await service.Create(data);

            if (result.IsSucccess())
            {
                return CreatedAtAction(nameof(Get), result.Model.CustomerId, result.Model);
            }
            return BadRequest(result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateBirthDateDto data, [FromServices] IUpdateBirthDateService service)
        {
            if (ModelState.IsValid)
            {
                var result = await service.Update(data);

                if (result.IsSucccess())
                {
                    return Ok(result.Model);
                }
                return BadRequest(result.Errors);
            }
            return BadRequest(ModelState.AsApplicationError());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id, [FromServices] IGetCustomerByIdService service)
        {
            var result = await service.GetCustomer(id);

            if (result.IsSucccess())
            {
                return Ok(result.Model);
            }
            return NotFound();
        }
    }
}