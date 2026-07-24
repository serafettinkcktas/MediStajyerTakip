using Application.DTOs;
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
    public async Task<IActionResult> AddRole()
    {
        return Ok();
    }
    
    [HttpGet]
    public IActionResult GetRoles()
    {
        return Ok();
    }

   
    [HttpPost]
    public async Task<IActionResult> AddMentor([FromBody]NewMentorDto newMentor)
    {
        var result = await _addMentorUseCase.AddMentor(newMentor.Name_Surname, newMentor.Email);
        return Ok(result);
    }

}