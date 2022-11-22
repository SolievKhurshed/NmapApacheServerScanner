using AutoMapper;
using LinqToDB;
using NmapApacheServerScanner.DAL.DataConnections;
using NmapApacheServerScanner.DAL.DataModels;
using NmapApacheServerScanner.Models.Nmap;

namespace NmapApacheServerScanner.DAL.Repositories;

public class NmapRepository : INmapRepository
{
    private readonly NmapDataConnection _db;
    private readonly IMapper _mapper;

    public NmapRepository(NmapDataConnection db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public void SaveScanResult(NmapScanResult nmapScanResult)
    {
        var dataToSave = _mapper.Map<NmapScanResultDbModel>(nmapScanResult);
        _db.Insert(dataToSave);
    }
}
