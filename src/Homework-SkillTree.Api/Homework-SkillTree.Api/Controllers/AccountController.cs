using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Homework_SkillTree.Api.Request;
using Homework_SkillTree.Domain.Entities.DAO;
using Homework_SkillTree.Domain.Entities.DTO;
using Homework_SkillTree.Domain.Interfaces.Service;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Homework_SkillTree.Api.Controllers;

public class AccountController(
    ILogger<AccountController> logger,
    IAccountService accountService,
    IValidator<GetAccountBooksRequest> validator) : BaseController(logger)
{
    [HttpGet]
    public async Task<IActionResult> GetAccountBooksAsync([FromQuery]GetAccountBooksRequest request)
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return ValidationError(validationResult.Errors.Select(error => error.ErrorMessage));
        }
        return await ExecuteAsync(accountService.GetAccountBooksAsync(request.PageNumber, request.PageSize, request.CategoryEnum));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCountAsync() 
        => await ExecuteAsync(accountService.GetAccountBooksCountAsync());
    
    [HttpPut]
    public async Task<IActionResult> AddAccountBookAsync([FromBody]AddAccountBookRequest request)
        => await ExecuteAsync(accountService.AddAccountBookAsync(request.Adapt<Accounting>()));
    
    [HttpPost]
    public async Task<IActionResult> UpdateAccountBookAsync([FromBody]UpdateAccountBookRequest request)
        => await ExecuteAsync(accountService.UpdateAccountBookAsync(request.Adapt<Accounting>()));
}