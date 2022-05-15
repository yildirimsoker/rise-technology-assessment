using AutoMapper;
using RiseTechnology.Application.Reports.Queries.GetReportsByTransactionId;
using RiseTechnology.Application.Reports.Queries.GetReportsWithPagination;
using RiseTechnology.Domain.Entities;

namespace RiseTechnology.Application.Reports.MappingProfiles
{
    public class ReportMappingProfiles : Profile
    {
        public ReportMappingProfiles()
        {
            CreateMap<Report, GetReportsWithPaginationDTO>();
            CreateMap<Report, GetReportsByTransactionIdDTO>();
        }
    }
}
