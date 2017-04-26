using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EF.Example {
    public class EFShim : IDbContextFactory<CompanyContext> {
        public CompanyContext Create(DbContextFactoryOptions options) {
            var builder = new DbContextOptionsBuilder<CompanyContext>();
            builder.UseSqlServer(@"Server=.\SQLExpress;Database=EFODataAPI;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new CompanyContext(builder.Options);
        }
    }
}
