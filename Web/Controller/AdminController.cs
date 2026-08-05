using Application.DTOs;
using Application.DTOs.Mentor;
using Application.UseCases.Admin;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controller;
[ApiController]
[Route("api/[controller]/[action]")]
public class AdminController(CreateRoleUseCase createRoleUseCase, AddMentorUseCase addMentorUseCase) : ControllerBase
{
    private readonly CreateRoleUseCase  _createRoleUseCase = createRoleUseCase;
    private readonly AddMentorUseCase _addMentorUseCase = addMentorUseCase;
    [HttpPost]
    public IActionResult AddUser()
    {
        return Ok();
    }

   
    [HttpPost]
    public async Task<IActionResult> CreateRole(string roleName)
    {
        var result = await _createRoleUseCase.CreateRole(roleName);
        return Ok(result);
    }
    
    [HttpGet]
    public IActionResult GetRoles()
    {
        return Ok();
    }

   
    [HttpPost]
    public async Task<IActionResult> AddMentor([FromBody]CreateMentorCommand command)
    {
        var result = await _addMentorUseCase.AddMentorAsync(command);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

}