using System.ComponentModel.DataAnnotations;
using System.Text;
using Homework_SkillTree.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homework_SkillTree.Api;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class BaseController(ILogger logger) : ControllerBase
{
    protected async Task<IActionResult> ExecuteAsync<TResponse>(Task<TResponse> taskExecute)
    {
        try
        {
            
            return Success(await taskExecute);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.ToString());
            return Error(ex.Message);
        }
    }
    
    protected async Task<IActionResult> ExecuteAsync(Task<int> taskExecute)
    {
        try
        {
            var modifyCount = await taskExecute;
            
            return modifyCount > 0 
                ? Success(null, $"Execute success, modify count:{modifyCount}") 
                : Error($"Execute failed, modify count:{modifyCount}");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.ToString());
            return Error(ex.Message);
        }
    }
    
    protected ObjectResult Success(object? data, string message = "Success")
    {
        return Ok(new BaseResponse
        {
            Data = data,
            Message = message,
            Success = true,
        });
    }

    protected ObjectResult Error(string message)
    {
        return BadRequest(new BaseResponse
        {
            Data = null,
            Message = message,
            Success = false,
        });
    }

    protected ObjectResult ValidationError(IEnumerable<string> validations)
    {
        return BadRequest(new BaseResponse
        {
            Data = null,
            Message = validations,
            Success = false,
        });
    }
}