public class ProfileTransaction
{
    public int ProfileTransactionId { get; set; }
    public int ProfileId { get; set; }
    public int TransactionId { get; set; }
    public Profile Profile { get; set; }
    public Transaction Transaction { get; set; }
}