using System.ComponentModel.DataAnnotations;

namespace Libs.Models.Common
{
    public abstract class EntityBase : IEntity
    {
        [Required, Key] 
        public int Id { get; set; }
    }
}