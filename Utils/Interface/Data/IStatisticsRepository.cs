using System.Collections;
using System.Threading.Tasks;

namespace Interface.Data
{
    public interface IStatisticsRepository
    {
        Task<IEnumerable> RequestsPerCountry();
        Task<IEnumerable> RequestsPerUrl();
    }
}