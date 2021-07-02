using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Interface.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace Interface.Models
{
    [Index(nameof(Header), nameof(Value), IsUnique = true)]

    public class HttpHeader : EntityBase
    {
        [Required]
        public string Header { get; set; }
        [Required]
        public string Value { get; set; }

        [JsonIgnore]
        public virtual List<HttpRequest> HttpRequests { get; set; }
    }
}