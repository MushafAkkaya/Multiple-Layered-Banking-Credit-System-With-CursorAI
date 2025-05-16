using BankCreditApp.Application.Features.CorporateCustomers.Commands.CreateCorporateCustomer;
using BankCreditApp.Application.Features.CorporateCustomers.Commands.UpdateCorporateCustomer;
using BankCreditApp.Application.Features.CorporateCustomers.Dtos.Requests;
using BankCreditApp.Core.Repositories;
using BankCreditApp.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using BankCreditApp.Application.Features.CorporateCustomers.Queries.GetCorporateCustomerById;
using BankCreditApp.Application.Features.CorporateCustomers.Queries.GetCorporateCustomerList;
using BankCreditApp.Application.Features.CorporateCustomers.Commands.DeleteCorporateCustomer;

namespace BankCreditApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CorporateCustomersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCorporateCustomerRequest request)
    {
        var command = new CreateCorporateCustomerCommand(request);
        var result = await Mediator.Send(command);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCorporateCustomerRequest request)
    {
        var command = new UpdateCorporateCustomerCommand(request);
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetCorporateCustomerByIdQuery(id);
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PaginationParams pagination)
    {
        var query = new GetCorporateCustomerListQuery(pagination);
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteCorporateCustomerCommand(id);
        await Mediator.Send(command);
        return NoContent();
    }
} 