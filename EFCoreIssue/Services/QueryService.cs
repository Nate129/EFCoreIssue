using System.Collections.Generic;
using System.Linq;
using EFCoreIssue.Abstractions;
using EFCoreIssue.Models;

namespace EFCoreIssue.Services
{
    public class QueryService
    {
        public IEnumerable<IEntity> JoinQuery(IQueryable<IEntity> set, IEnumerable<EntityMetadata> metadata)
        {
            var updates = from e in set
                join m in metadata on e.Id equals m.EntityId into results
                from m in results.DefaultIfEmpty()
                select e;

            return updates;
        }

        public IEnumerable<IEntity> SimpleQuery(IQueryable<IEntity> set, IEnumerable<EntityMetadata> metadata)
        {
            var matches = set.Where(e => metadata.Select(m => m.EntityId).Contains(((string) e.Id).ToUpper()));

            return matches;
        }
    }
}
