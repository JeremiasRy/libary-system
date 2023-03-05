namespace Backend.Controllers;

using Backend.Models;
using Backend.DTOs;
using Backend.Services;

public class UserController : CrudController<User, UserDTO>
{
    public UserController(ICrudService<User, UserDTO> service) : base(service)
    {
    }
}
