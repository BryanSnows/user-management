public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public User GetUserById(int userId) => _context.Users.FirstOrDefault(u => u.user_id == userId);

    public IEnumerable<User> GetAllUsers() => _context.Users.ToList();

    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void UpdateUser(User user)
    {
        var existingUser = _context.Users.Find(user.user_id);
        if (existingUser != null)
        {
            existingUser.user_name = user.user_name;
            existingUser.user_surname = user.user_surname;
            existingUser.user_email = user.user_email;
            _context.SaveChanges();
        }
    }

    public void DeleteUser(int userId)
    {
        var userToDelete = _context.Users.Find(userId);
        if (userToDelete != null)
        {
            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
        }
    }}