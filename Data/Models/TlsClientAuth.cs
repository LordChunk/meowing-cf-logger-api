using Data.Models.Common;

namespace Data.Models
{
    public class TlsClientAuth : EntityBase
    {

        public string CertIssuerDnrfc2253 { get; set; }

        public string CertFingerprintSha1 { get; set; }

        public string CertSubjectDnLegacy { get; set; }

        public string CertPresented { get; set; }

        public string CertIssuerDnLegacy { get; set; }

        public string CertSubjectDn { get; set; }

        public string CertNotBefore { get; set; }

        public string CertNotAfter { get; set; }

        public string CertSubjectDnrfc2253 { get; set; }

        public string CertVerified { get; set; }

        public string CertSerial { get; set; }

        public string CertIssuerDn { get; set; }
    }
}