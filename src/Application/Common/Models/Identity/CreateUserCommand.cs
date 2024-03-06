using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Mac.CarHub.Application.Models;

public class CreateUserCommand
{
    public required string UserName { get; set; } 
    
    public required string Password { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public IFormFile? PersonalPhoto { get; set; }
    
    public string RoleId { get; set; } = Roles.User;
}
