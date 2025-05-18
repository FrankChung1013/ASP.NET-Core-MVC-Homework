using Homework_SkillTree.Api.Request;
using Homework_SkillTree.Domain.Entities.DTO;
using Homework_SkillTree.Domain.Interfaces.Service;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Homework_SkillTree.Api.Controllers;

/// <summary>
/// 記帳本API
/// </summary>
/// <param name="logger"></param>
/// <param name="accountService"></param>
public class AccountBookController(
    ILogger<AccountBookController> logger,
    IAccountService accountService) : BaseController(logger)
{
    /// <summary>
    /// 取得帳目
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAccountBooksAsync([FromQuery]GetAccountBooksRequest request)
    {
        return await ExecuteAsync(accountService.GetAccountBooksAsync(request.PageNumber, request.PageSize, request.CategoryEnum));
    }
    
    /// <summary>
    /// 取得帳目總數
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetCountAsync() 
        => await ExecuteAsync(accountService.GetAccountBooksCountAsync());
    
    /// <summary>
    /// 新增帳目
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> AddAccountBookAsync([FromBody]AddAccountBookRequest request)
        => await ExecuteAsync(accountService.AddAccountBookAsync(request.Adapt<Accounting>()));
    
    /// <summary>
    /// 更新帳目
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> UpdateAccountBookAsync([FromBody]UpdateAccountBookRequest request)
        => await ExecuteAsync(accountService.UpdateAccountBookAsync(request.Adapt<Accounting>()));
}