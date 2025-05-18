using BankCreditApp.Application.Features.IndividualCustomers.Commands.Create;
using BankCreditApp.Application.Features.IndividualCustomers.Commands.Delete;
using BankCreditApp.Application.Features.IndividualCustomers.Commands.Update;
using BankCreditApp.Application.Features.IndividualCustomers.Dtos.Requests;
using BankCreditApp.Application.Features.IndividualCustomers.Dtos.Responses;
using BankCreditApp.Application.Features.IndividualCustomers.Queries.GetById;
using BankCreditApp.Application.Features.IndividualCustomers.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace BankCreditApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IndividualCustomersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateIndividualCustomerCommand command)
    {
        var result = await Mediator.Send(command);
        return Created("", result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdIndividualCustomerQuery query = new() { Id = id };
        GetIndividualCustomerResponse response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListIndividualCustomerRequest request)
    {
        GetListIndividualCustomerQuery query = new() { Request = request };
        GetListIndividualCustomerResponse response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateIndividualCustomerRequest request)
    {
        UpdateIndividualCustomerCommand command = new() { Request = request };
        UpdateIndividualCustomerResponse response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteIndividualCustomerCommand command = new() { Id = id };
        DeleteIndividualCustomerResponse response = await Mediator.Send(command);
        return Ok(response);
    }
} 