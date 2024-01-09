

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User GetUserById(int userId) => _userRepository.GetUserById(userId);

    public IEnumerable<User> GetAllUsers() => _userRepository.GetAllUsers();

    public void AddUser(User user) => _userRepository.AddUser(user);

    public void UpdateUser(User user) => _userRepository.UpdateUser(user);

    public void DeleteUser(int userId) => _userRepository.DeleteUser(userId);
}