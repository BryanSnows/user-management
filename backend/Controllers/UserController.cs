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
    public ActionResult<User> AddUser([FromBody] User user)
    {
        _userService.AddUser(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User user)
    {
        var existingUser = _userService.GetUserById(id);
        if (existingUser == null)
            return NotFound();

        user.UserId = id;
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