public class ProfileTransaction
{
    public int profile_transaction_id { get; set; }
    public int profile_id { get; set; }
    public int transaction_id { get; set; }
    public Profile Profile { get; set; }
    public Transaction Transaction { get; set; }
}