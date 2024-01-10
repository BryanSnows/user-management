using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IEnumerable<User> GetUsers() => _userService.GetAllUsers();

    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
            return NotFound();

        return user;
    }

    [HttpPost]
public ActionResult<User> AddUser([FromBody] CreateUserDto createUserDto)
{
    // Mapeie os dados do DTO para a entidade User
    var user = new User
    {
        user_name = createUserDto.User_Name,
        user_surname = createUserDto.User_Surname,
        user_email = createUserDto.User_Email,
        user_password = createUserDto.User_Password,
        profile_id = createUserDto.Profile_Id
    };

    _userService.AddUser(user);

    // Retorne a resposta com o ID do usuário criado
    return CreatedAtAction(nameof(GetUserById), new { id = user.user_id }, user);
}

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User user)
    {
        var existingUser = _userService.GetUserById(id);
        if (existingUser == null)
            return NotFound();

        user.user_id = id;
        _userService.UpdateUser(user);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var existingUser = _userService.GetUserById(id);
        if (existingUser == null)
            return NotFound();

        _userService.DeleteUser(id);

        return NoContent();
    }
}