using System.Collections.Generic;
using System.Linq;
using Data.Logic;
using Data.Models;

namespace Data
{

    public class HttpLogsObservable : Observable<List<int>>
    {
        private readonly ApplicationContext _context;

        public HttpLogsObservable(ApplicationContext context)
        {
            _context = context;
        }

        internal void Notify()
        {
            Notify(
            _context.ChangeTracker.Entries<HttpRequestLog>()
                    .Select(entry => entry.Entity)
                    .Select(entity => entity.Id)
                    .ToList()
            );
        }
    }
}