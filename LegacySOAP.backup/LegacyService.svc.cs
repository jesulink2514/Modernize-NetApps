using LegacySOAP.Data;
using LegacySOAP.Models;
using System.Linq;

namespace LegacySOAP
{
    public class LegacyService : ILegacyService
    {
        private LegacyDbContext dbContext;

        public LegacyService()
        {
            dbContext = new LegacyDbContext();
        }

        public Product[] DoWork()
        {
            return dbContext.Products.ToArray();
        }
    }
}
