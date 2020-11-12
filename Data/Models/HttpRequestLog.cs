using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Models.Common;
using Microsoft.VisualBasic;

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