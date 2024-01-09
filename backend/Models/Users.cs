public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
    public string UserRefreshToken { get; set; }
    public int ProfileId { get; set; }

    public Profile Profile { get; set; }
}