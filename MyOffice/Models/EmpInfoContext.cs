using Microsoft.EntityFrameworkCore;

namespace MyOffice.Models
{
    public class EmpInfoContext:DbContext
    {
        public EmpInfoContext(DbContextOptions<EmpInfoContext> options) : base(options) { }
        public DbSet<EmpInfo> EmpInfos { get; set; } = null!;
    }
}
