using AutoMapper;
using NmapApacheServerScanner.DAL.DataModels;
using NmapApacheServerScanner.Models.Nmap;

namespace NmapApacheServerScanner.Configuration.AutoMapperProfiles;

public class AppMapperProfile : Profile
{
    public AppMapperProfile()
    {
        CreateMap<NmapScanResult, NmapScanResultDbModel>();
    }
}
