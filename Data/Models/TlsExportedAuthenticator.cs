using System.ComponentModel.DataAnnotations;
using Data.Models.Common;

namespace Data.Models
{
    public class TlsExportedAuthenticator : EntityBase
    {
        [Required]
        public string ServerFinished { get; set; }

        [Required]
        public string ClientHandshake { get; set; }

        [Required]
        public string ServerHandshake { get; set; }

        [Required]
        public string ClientFinished { get; set; }
    }
}