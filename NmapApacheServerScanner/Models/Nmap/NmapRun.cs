using System.Xml.Serialization;

namespace NmapApacheServerScanner.Models.Nmap;

[XmlRoot(ElementName = "nmaprun")]
public class NmapRun
{
    [XmlAttribute(AttributeName = "scanner")]
    public string Scanner { get; set; }

    [XmlAttribute(AttributeName = "args")]
    public string Args { get; set; }

    [XmlAttribute(AttributeName = "start")]
    public int Start { get; set; }

    [XmlAttribute(AttributeName = "startstr")]
    public string StartStr { get; set; }

    [XmlAttribute(AttributeName = "version")]
    public string Version { get; set; }

    [XmlAttribute(AttributeName = "xmloutputversion")]
    public string XmlOutputVersion { get; set; }

    [XmlElement(ElementName = "scaninfo")]
    public ScanInfo ScanInfo { get; set; }

    [XmlElement(ElementName = "verbose")]
    public Verbose Verbose { get; set; }

    [XmlElement(ElementName = "debugging")]
    public Debugging Debugging { get; set; }

    [XmlElement(ElementName = "hosthint")]
    public HostHint HostHint { get; set; }

    [XmlElement(ElementName = "host")]
    public Host Host { get; set; }

    [XmlElement(ElementName = "runstats")]
    public RunStats RunStats { get; set; }
}

public class ScanInfo
{
    [XmlAttribute(AttributeName = "type")]
    public string Type { get; set; }

    [XmlAttribute(AttributeName = "protocol")]
    public string Protocol { get; set; }

    [XmlAttribute(AttributeName = "numservices")]
    public string NumServices { get; set; }

    [XmlAttribute(AttributeName = "services")]
    public string Services { get; set; }
}

public class Verbose
{
    [XmlAttribute(AttributeName = "level")]
    public string Level { get; set; }
}

public class Debugging
{
    [XmlAttribute(AttributeName = "level")]
    public string Level { get; set; }
}

public class HostHint
{
    [XmlElement(ElementName = "status")]
    public Status Status { get; set; }

    [XmlElement(ElementName = "address")]
    public List<Address> Addresses { get; set; }

    [XmlElement(ElementName = "hostnames")]
    public HostNames HostNames { get; set; }
}

public class Status
{
    [XmlAttribute(AttributeName = "state")]
    public string State { get; set; }

    [XmlAttribute(AttributeName = "reason")]
    public string Reason { get; set; }

    [XmlAttribute(AttributeName = "reason_ttl")]
    public string ReasonTTL { get; set; }
}

public class Address
{
    [XmlAttribute(AttributeName = "addr")]
    public string Addr { get; set; }

    [XmlAttribute(AttributeName = "addrtype")]
    public string AddrType { get; set; }

    [XmlAttribute(AttributeName = "vendor")]
    public string Vendor { get; set; }
}

public class HostNames { }

public class Host
{
    [XmlAttribute(AttributeName = "starttime")]
    public string StartTime { get; set; }

    [XmlAttribute(AttributeName = "endtime")]
    public string EndTime { get; set; }

    [XmlElement(ElementName = "status")]
    public Status Status { get; set; }

    [XmlElement(ElementName = "address")]
    public List<Address> Addresses { get; set; }

    [XmlElement(ElementName = "hostnames")]
    public HostNames HostNames { get; set; }

    [XmlElement(ElementName = "ports")]
    public Ports Ports { get; set; }

    [XmlElement(ElementName = "times")]
    public Times Times { get; set; }
}

public class Ports
{
    [XmlElement(ElementName = "extraports")]
    public ExtraPorts ExtraPorts { get; set; }

    [XmlElement(ElementName = "port")]
    public List<Port> PortList { get; set; }
}

public class ExtraPorts
{
    [XmlAttribute(AttributeName = "state")]
    public string State { get; set; }

    [XmlAttribute(AttributeName = "count")]
    public string Count { get; set; }

    [XmlElement(ElementName = "extrareasons")]
    public ExtraReasons ExtraReasons { get; set; }
}

public class ExtraReasons
{
    [XmlAttribute(AttributeName = "reason")]
    public string Reason { get; set; }

    [XmlAttribute(AttributeName = "count")]
    public string Count { get; set; }

    [XmlAttribute(AttributeName = "proto")]
    public string Proto { get; set; }

    [XmlAttribute(AttributeName = "ports")]
    public string Ports { get; set; }
}

public class Port
{
    [XmlAttribute(AttributeName = "protocol")]
    public string Protocol { get; set; }

    [XmlAttribute(AttributeName = "portid")]
    public string PortId { get; set; }

    [XmlElement(ElementName = "state")]
    public PostState State { get; set; }

    [XmlElement(ElementName = "service")]
    public Service Service { get; set; }
}

public class PostState
{
    [XmlAttribute(AttributeName = "state")]
    public string State { get; set; }

    [XmlAttribute(AttributeName = "reason")]
    public string Reason { get; set; }

    [XmlAttribute(AttributeName = "reason_ttl")]
    public string ReasonTTL { get; set; }
}

public class Service
{
    [XmlAttribute(AttributeName = "name")]
    public string Name { get; set; }

    [XmlAttribute(AttributeName = "product")]
    public string Product { get; set; }

    [XmlAttribute(AttributeName = "version")]
    public string Version { get; set; }

    [XmlAttribute(AttributeName = "extrainfo")]
    public string ExtraInfo { get; set; }

    [XmlAttribute(AttributeName = "ostype")]
    public string OsType { get; set; }

    [XmlAttribute(AttributeName = "method")]
    public string Method { get; set; }

    [XmlAttribute(AttributeName = "conf")]
    public string Conf { get; set; }

    [XmlElement(ElementName = "cpe")]
    public List<string> Cpe { get; set; }
}

public class Times
{
    [XmlAttribute(AttributeName = "srtt")]
    public string Srtt { get; set; }

    [XmlAttribute(AttributeName = "rttvar")]
    public string Rttvar { get; set; }

    [XmlAttribute(AttributeName = "to")]
    public string To { get; set; }
}

public class RunStats
{
    [XmlElement(ElementName = "finished")]
    public Finished Finished { get; set; }

    [XmlElement(ElementName = "hosts")]
    public Hosts Hosts { get; set; }
}

public class Finished
{
    [XmlAttribute(AttributeName = "time")]
    public string Time { get; set; }

    [XmlAttribute(AttributeName = "timestr")]
    public string TimeStr { get; set; }

    [XmlAttribute(AttributeName = "summary")]
    public string Summary { get; set; }

    [XmlAttribute(AttributeName = "elapsed")]
    public string Elapsed { get; set; }

    [XmlAttribute(AttributeName = "exit")]
    public string Exit { get; set; }
}

public class Hosts
{
    [XmlAttribute(AttributeName = "up")]
    public string Up { get; set; }

    [XmlAttribute(AttributeName = "down")]
    public string Down { get; set; }

    [XmlAttribute(AttributeName = "total")]
    public string Total { get; set; }
}