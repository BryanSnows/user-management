public class User
{
    public int user_id { get; set; }
    public string user_name { get; set; }
    public string user_surname { get; set; }
    public string user_email { get; set; }
    public string user_password { get; set; }
    public string? user_refresh_token { get; set; }
    public int profile_id { get; set; }
    public Profile Profile { get; set; }
}