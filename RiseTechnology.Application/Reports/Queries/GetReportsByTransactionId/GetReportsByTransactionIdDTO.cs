namespace RiseTechnology.Application.Reports.Queries.GetReportsByTransactionId
{
    public class GetReportsByTransactionIdDTO
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string? ReportPath { get; set; }
        public string? TransactionId { get; set; }
        public string? ReportStatusType { get; set; }
    }
}
