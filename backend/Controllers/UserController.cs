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

    var user = new User
    {
        user_name = createUserDto.user_name,
        user_surname = createUserDto.user_surname,
        user_email = createUserDto.user_email,
        user_password = createUserDto.user_password,
        profile_id = createUserDto.profile_id
    };

    _userService.AddUser(user);

   
    return CreatedAtAction(nameof(GetUserById), new { id = user.user_id }, user);
}
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
    {
        var existingUser = _userService.GetUserById(id);
        if (existingUser == null)
            return NotFound();

        existingUser.user_name = updateUserDto.user_name;
        existingUser.user_surname = updateUserDto.user_surname;
        existingUser.user_email = updateUserDto.user_email;
        existingUser.profile_id = updateUserDto.profile_id;

        _userService.UpdateUser(existingUser);

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