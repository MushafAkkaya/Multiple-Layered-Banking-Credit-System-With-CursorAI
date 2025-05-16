using BankCreditApp.Application.Features.CreditTypes.Dtos.Requests;
using BankCreditApp.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using BankCreditApp.Application.Features.CreditTypes.Commands.CreateIndividualCreditType;
using BankCreditApp.Application.Features.CreditTypes.Commands.CreateCorporateCreditType;
using BankCreditApp.Application.Features.CreditTypes.Queries.GetEligibleCreditTypes;
using BankCreditApp.Application.Features.CreditTypes.Commands.UpdateCreditTypeStatus;

namespace BankCreditApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreditTypesController : BaseController
{
    [HttpPost("individual")]
    public async Task<IActionResult> CreateIndividualCreditType(
        [FromBody] CreateIndividualCreditTypeRequest request)
    {
        var command = new CreateIndividualCreditTypeCommand(request);
        var result = await Mediator.Send(command);
        return Created("", result);
    }

    [HttpPost("corporate")]
    public async Task<IActionResult> CreateCorporateCreditType(
        [FromBody] CreateCorporateCreditTypeRequest request)
    {
        var command = new CreateCorporateCreditTypeCommand(request);
        var result = await Mediator.Send(command);
        return Created("", result);
    }

    [HttpGet("individual/eligible")]
    public async Task<IActionResult> GetEligibleIndividualCreditTypes(
        [FromQuery] decimal creditScore,
        [FromQuery] decimal monthlyIncome,
        [FromQuery] int age)
    {
        var query = new GetEligibleIndividualCreditTypesQuery(creditScore, monthlyIncome, age);
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("corporate/eligible")]
    public async Task<IActionResult> GetEligibleCorporateCreditTypes(
        [FromQuery] decimal annualTurnover,
        [FromQuery] int companyAgeInMonths)
    {
        var query = new GetEligibleCorporateCreditTypesQuery(annualTurnover, companyAgeInMonths);
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpPut("individual/{id}/status")]
    public async Task<IActionResult> UpdateIndividualCreditTypeStatus(
        Guid id,
        [FromQuery] bool isActive)
    {
        var command = new UpdateCreditTypeStatusCommand(id, isActive);
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpPut("corporate/{id}/status")]
    public async Task<IActionResult> UpdateCorporateCreditTypeStatus(
        Guid id,
        [FromQuery] bool isActive)
    {
        var command = new UpdateCreditTypeStatusCommand(id, isActive);
        await Mediator.Send(command);
        return NoContent();
    }
} 