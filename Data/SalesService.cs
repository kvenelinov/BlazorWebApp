using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
    public class SalesService
    {
        Model.Adventureworks2017Context _context;
        public SalesService(Model.Adventureworks2017Context context)
        {
            _context = context;
        }

        public async Task<List<Model.SalesOrderHeader>> GetSalesAsync()
        {
            return await _context.SalesOrderHeader.ToListAsync();
        }
    }
}
