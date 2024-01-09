public class Profile
{
    public int ProfileId { get; set; }
    public string ProfileName { get; set; }
    public bool ProfileStatus { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<ProfileTransaction> ProfileTransactions { get; set; }
}