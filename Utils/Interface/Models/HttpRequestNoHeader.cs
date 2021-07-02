using System.ComponentModel.DataAnnotations;
using Interface.Models.Common;

namespace Interface.Models
{
    public abstract class HttpRequestNoHeader : EntityBase
    {
        [Required]
        public string Method { get; set; }
        public string Body { get; set; }
        public string Fetchers { get; set; }
        public bool BodyUsed { get; set; }
        public string Redirect { get; set; }
        [Required]
        public int ContentLength { get; set; }
    }
}