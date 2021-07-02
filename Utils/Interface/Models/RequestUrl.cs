using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Interface.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace Interface.Models
{
    [Index(nameof(Url), IsUnique = true)]
    public class RequestUrl : EntityBase
    {
        [Required]
        public string Url { get; set; }

        [JsonIgnore]
        public virtual List<HttpRequest> Requests { get; set; }
    }
}