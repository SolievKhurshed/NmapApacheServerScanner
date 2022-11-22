using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using NmapApacheServerScanner.DAL.DataModels;

namespace NmapApacheServerScanner.DAL.DataConnections;

public class NmapDataConnection : DataConnection
{
    public NmapDataConnection(LinqToDBConnectionOptions<NmapDataConnection> options) : base(options)
    {
    }

    public ITable<NmapScanResultDbModel> NmapScanResult => this.GetTable<NmapScanResultDbModel>();
}
