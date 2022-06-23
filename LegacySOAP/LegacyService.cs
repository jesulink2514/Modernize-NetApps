using LegacySOAP.Data;
using LegacySOAP.Models;
using System.Linq;

namespace LegacySOAP
{
    public class LegacyService : ILegacyService
    {
        private LegacyDbContext dbContext;

        public LegacyService(LegacyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Product[] DoWork()
        {
            return dbContext.Products.ToArray();
        }
    }
}
