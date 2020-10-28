using System.ComponentModel.DataAnnotations;
using Data.Models.Common;

namespace Data.Models
{
    public class CfHttpHeader : EntityBase
    {
        public string Asn { get; set; }

        public string ClientAcceptEncoding { get; set; }

        public int ClientTcpRtt { get; set; }

        public string Colo { get; set; }

        public string Country { get; set; }

        public string TlsVersion { get; set; }

        public string TlsCipher { get; set; }

        public int EdgeRequestKeepAliveStatus { get; set; }

        public string RequestPriority { get; set; }

        public TlsClientAuth TlsClientAuth { get; set; } 

        public string HttpProtocol { get; set; }

        public TlsExportedAuthenticator TlsExportedAuthenticator { get; set; }
    }
}