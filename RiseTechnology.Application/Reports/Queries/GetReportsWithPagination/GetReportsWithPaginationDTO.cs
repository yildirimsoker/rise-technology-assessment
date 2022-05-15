namespace RiseTechnology.Application.Reports.Queries.GetReportsWithPagination
{
    public class GetReportsWithPaginationDTO
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string? ReportPath { get; set; }
        public string? TransactionId { get; set; }
        public string? ReportStatusType { get; set; }
    }
}
