using System.ComponentModel.DataAnnotations;
using Libs.Models.Common;
using Newtonsoft.Json;

namespace Libs.Models
{
    public class HttpHeader : IEntity
    {
        [Required]
        public string Header { get; set; }
        [Required]
        public string Value { get; set; }

        [Required]
        public int HttpRequestId { get; set; }

        [JsonIgnore]
        public virtual HttpRequest HttpRequest { get; set; }
    }
}