using BankCreditApp.Application.Features.CreditApplications.Commands.CreateIndividualCreditApplication;
using BankCreditApp.Application.Features.CreditApplications.Dtos.Requests;
using BankCreditApp.Application.Features.CreditApplications.Queries.GetCustomerCreditApplications;
using BankCreditApp.Core.Repositories;
using BankCreditApp.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BankCreditApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreditApplicationsController : BaseController
{
    [HttpPost("individual")]
    public async Task<IActionResult> CreateIndividualApplication(
        [FromBody] CreateIndividualCreditApplicationRequest request)
    {
        var command = new CreateIndividualCreditApplicationCommand(request);
        var result = await Mediator.Send(command);
        return Created("", result);
    }

    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetCustomerApplications(
        Guid customerId,
        [FromQuery] bool isIndividual = true,
        [FromQuery] PaginationParams pagination = null)
    {
        pagination ??= new PaginationParams { PageNumber = 1, PageSize = 10 };
        var query = new GetCustomerCreditApplicationsQuery(customerId, isIndividual, pagination);
        var result = await Mediator.Send(query);
        return Ok(result);
    }
} 