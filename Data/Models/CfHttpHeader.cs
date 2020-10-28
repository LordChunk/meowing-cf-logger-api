using System.ComponentModel.DataAnnotations;
using Data.Models.Common;

namespace Data.Models
{
    public class CfHttpHeader : EntityBase
    {
        [Required] 
        public string Asn { get; set; }

        [Required] 
        public string ClientAcceptEncoding { get; set; }

        [Required] 
        public int ClientTcpRtt { get; set; }

        [Required] 
        public string Colo { get; set; }

        [Required] 
        public string Country { get; set; }

        [Required] 
        public string TlsVersion { get; set; }

        [Required] 
        public string TlsCipher { get; set; }

        [Required] 
        public int EdgeRequestKeepAliveStatus { get; set; }

        [Required] 
        public string RequestPriority { get; set; }

        [Required] 
        public TlsClientAuth TlsClientAuth { get; set; } 

        [Required] 
        public string HttpProtocol { get; set; }

        [Required] 
        public TlsExportedAuthenticator TlsExportedAuthenticator { get; set; }
    }
}