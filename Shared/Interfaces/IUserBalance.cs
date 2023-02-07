namespace Gizmo
{
    /// <summary>
    /// User balance interface.
    /// </summary>
    public interface IUserBalance
    {
        double? AvailableCreditedTime { get; set; }
        double? AvailableTime { get; set; }
        decimal Balance { get; }
        decimal Deposits { get; set; }
        decimal OnInvoicedUsage { get; set; }
        decimal OnInvoices { get; set; }
        decimal OnUninvoicedUsage { get; set; }
        int Points { get; set; }
        double TimeFixed { get; set; }
        double TimeProduct { get; set; }
        double TimeProductBalance { get; }
        decimal TotalOutstanding { get; }
        decimal UsageBalance { get; }
        int UserId { get; set; }
    }
}
