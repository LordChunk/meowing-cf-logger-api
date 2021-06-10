using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data.Models.Common;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Data.Models
{
    [Index(nameof(Url), IsUnique = true)]
    public class RequestUrl : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }

        [JsonIgnore]
        public virtual List<HttpRequest> Requests { get; set; }
    }
}