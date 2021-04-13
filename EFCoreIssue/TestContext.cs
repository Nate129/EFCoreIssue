using EFCoreIssue.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreIssue
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
    }
}
