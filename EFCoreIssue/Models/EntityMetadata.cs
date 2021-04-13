using System.Diagnostics.CodeAnalysis;

namespace EFCoreIssue.Models
{
    public class EntityMetadata
    {
        public string EntityId { get; set; }

        [SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Versioning")]
        public byte[] Version { get; set; }
    }
}
