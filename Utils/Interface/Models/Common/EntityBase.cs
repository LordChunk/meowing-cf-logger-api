using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Interface.Models.Common
{
    public abstract class EntityBase : IEntity
    {
        [Required, Key] 
        public int Id { get; set; }

        public static async Task<TEntity> CreateFromStream<TEntity>(Stream stream) where TEntity : EntityBase
        {
            return JsonConvert.DeserializeObject<TEntity>(await new StreamReader(stream).ReadToEndAsync());
        }

        public override string ToString()
        {
            return ToString(Formatting.Indented);
        }

        public string ToString(Formatting formatting)
        {
            return JsonConvert.SerializeObject(this, formatting);
        }
    }
}