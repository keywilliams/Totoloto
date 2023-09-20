using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotolotoRepository.Models;

namespace TotolotoRepository
{
    public class TotolotoContextFactory : ITotolotoContextFactory
    {
        public TotolotoContextFactory()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Totolotoconnectionstring"].ConnectionString;
        }

        static string? connectionString = null;

        public TotolotoContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TotolotoContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new TotolotoContext(optionsBuilder.Options);
        }
    }
}
