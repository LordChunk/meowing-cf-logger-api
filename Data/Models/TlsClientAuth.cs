using System.ComponentModel.DataAnnotations;
using Data.Models.Common;

namespace Data.Models
{
    public class TlsClientAuth : EntityBase
    {

        [Required]
        public string CertIssuerDnrfc2253 { get; set; }

        [Required]
        public string CertFingerprintSha1 { get; set; }

        [Required]
        public string CertSubjectDnLegacy { get; set; }

        [Required]
        public string CertPresented { get; set; }

        [Required]
        public string CertIssuerDnLegacy { get; set; }

        [Required]
        public string CertSubjectDn { get; set; }

        [Required]
        public string CertNotBefore { get; set; }

        [Required]
        public string CertNotAfter { get; set; }

        [Required]
        public string CertSubjectDnrfc2253 { get; set; }

        [Required]
        public string CertVerified { get; set; }

        [Required]
        public string CertSerial { get; set; }

        [Required]
        public string CertIssuerDn { get; set; }
    }
}