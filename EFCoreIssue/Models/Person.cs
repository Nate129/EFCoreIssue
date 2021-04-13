using System;

namespace EFCoreIssue.Models
{
    public class Person : Entity<Guid>
    {
        public string Name { get; set; }
    }
}
