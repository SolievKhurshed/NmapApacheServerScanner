using LinqToDB.Mapping;

namespace NmapApacheServerScanner.DAL.DataModels;

[Table(Schema = "public", Name = "nmap_scan_results")]
public class NmapScanResultDbModel
{
    [Column("id"), PrimaryKey, Identity]
    public int Id { get; set; }

    [Column("created"), NotNull]
    public DateTime Created { get; set; }

    [Column("host"), NotNull]
    public string Host { get; set; }

    [Column("tomcat_version"), Nullable]
    public string TomcatVersion { get; set; }

    [Column(DataType = LinqToDB.DataType.Json, Name = "full_result"), Nullable]
    public string FullResult { get; set; }
}
