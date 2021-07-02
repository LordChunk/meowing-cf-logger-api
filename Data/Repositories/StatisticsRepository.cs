using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Interface.Data;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly ApplicationContext _context;

        public StatisticsRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable> RequestsPerCountry()
        {
            return await _context.HttpHeaders
                .Where(h => h.Header == "cf-ipcountry")
                .Select(h => new
                {
                    country = h.Value,
                    count = h.HttpRequests.Count
                })
                .OrderByDescending(d => d.count)
                .ToListAsync();
        }

        public async Task<IEnumerable> RequestsPerUrl()
        {
            return await _context.RequestUrls
                .Select(u => new
                {
                    url = u.Url,
                    count = u.Requests.Count
                })
                .OrderByDescending(d => d.count)
                .ToListAsync();
        }
    }
}