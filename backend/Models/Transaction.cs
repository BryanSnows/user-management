public class Transaction
{
    public int transaction_id { get; set; }
    public string transaction_name { get; set; }
    public int transaction_number { get; set; }
    public bool transaction_status { get; set; }
    public ICollection<ProfileTransaction> ProfileTransactions { get; set; }
}
