using System.ComponentModel.DataAnnotations;

namespace Data.Models.Common
{
    public abstract class EntityBase : IEntity
    {
        [Required, Key] 
        public int Id { get; set; }
    }
}