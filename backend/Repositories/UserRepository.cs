

public class UserRepository : IUserRepository
{
    private List<User> _users = new List<User>();

    public User GetUserById(int userId) => _users.FirstOrDefault(u => u.UserId == userId);

    public IEnumerable<User> GetAllUsers() => _users;

    public void AddUser(User user)
    {
        user.UserId = _users.Count + 1;
        _users.Add(user);
    }

    public void UpdateUser(User user)
    {
        var existingUser = _users.FirstOrDefault(u => u.UserId == user.UserId);
        if (existingUser != null)
        {
            existingUser.UserName = user.UserName;
            existingUser.UserSurname = user.UserSurname;
            existingUser.UserEmail = user.UserEmail;
        }
    }

    public void DeleteUser(int userId)
    {
        _users.RemoveAll(u => u.UserId == userId);
    }
}