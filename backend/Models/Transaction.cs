public class Transaction
{
    public int TransactionId { get; set; }
    public string TransactionName { get; set; }
    public int TransactionNumber { get; set; }
    public bool TransactionStatus { get; set; }
    public ICollection<ProfileTransaction> ProfileTransactions { get; set; }
}
