using System.ComponentModel.DataAnnotations;
using Data.Models.Common;

namespace Data.Models
{
    public class TlsExportedAuthenticator : EntityBase
    {
        public string ServerFinished { get; set; }

        public string ClientHandshake { get; set; }

        public string ServerHandshake { get; set; }

        public string ClientFinished { get; set; }
    }
}