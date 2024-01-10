public class Profile
{
    public int profile_id { get; set; }
    public string profile_name { get; set; }
    public bool profile_status { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<ProfileTransaction> ProfileTransactions { get; set; }
}