using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Data.Models.Common
{
    public abstract class EntityBase : IEntity
    {
        [Required, Key] 
        public int Id { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}