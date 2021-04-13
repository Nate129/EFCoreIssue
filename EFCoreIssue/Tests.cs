using System.Linq;
using EFCoreIssue.Models;
using EFCoreIssue.Services;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace EFCoreIssue
{
    public class Tests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public Tests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Join_Query_Complies_To_SQL()
        {
            // Arrange
            var dbFactory = new EFCoreSqliteInMemoryDbFactory();
            var context = dbFactory.CreateDbContext<TestContext>(logger: s => _testOutputHelper.WriteLine(s));

            context.People.AddRange(new Person(), new Person());

            context.SaveChanges();

            var metadata = context.People.ToList()
                .Select(p => new EntityMetadata {EntityId = p.Id.ToString(), Version = p.Version});

            // simulate a person being added with having the metadata for it so the join can be tested
            context.People.Add(new Person());

            context.SaveChanges();

            var queryService = new QueryService();

            // Act
            var changedEntities = queryService.JoinQuery(context.People, metadata);

            // Assert
            changedEntities.Count().Should().Be(1);
        }

        [Fact]
        public void Where_Query_Complies_To_SQL()
        {
            // Arrange
            var dbFactory = new EFCoreSqliteInMemoryDbFactory();
            var context = dbFactory.CreateDbContext<TestContext>(logger: s => _testOutputHelper.WriteLine(s));

            context.People.AddRange(new Person(), new Person());

            context.SaveChanges();

            var metadata = context.People.ToList().Select(p => new EntityMetadata
                {EntityId = p.Id.ToString().ToUpper(), Version = p.Version});

            // simulate a person being added with having the metadata for it so the join can be tested
            context.People.Add(new Person());

            context.SaveChanges();

            var queryService = new QueryService();

            // Act
            var changedEntities = queryService.SimpleQuery(context.People, metadata);

            // Assert
            changedEntities.Count().Should().Be(2);
        }
    }
}
