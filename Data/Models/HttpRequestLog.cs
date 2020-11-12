using System;
using System.ComponentModel.DataAnnotations;
using Data.Models.Common;

namespace Data.Models
{
    public class HttpRequestLog : EntityBase
    {
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public HttpRequest Request { get; set; }
        [Required]
        public int RequestSize { get; set; }
    }
}