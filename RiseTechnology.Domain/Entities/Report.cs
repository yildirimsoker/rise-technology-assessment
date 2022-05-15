namespace RiseTechnology.Domain.Entities
{
    public class Report : BaseEntity
    {
        public DateTime RequestDate { get; set; }
        public string? ReportPath { get; set; }
        public string? TransactionId { get; set; }
        public ReportStatusType ReportStatusType { get; set; }
    }

    public enum ReportStatusType
    {
        New,
        Complate,
        Fail,
        Handle
    }
}
