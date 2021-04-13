using System.Diagnostics.CodeAnalysis;

namespace EFCoreIssue.Abstractions
{
    public interface IEntity
    {
        object Id { get; set; }

        [SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Versioning")]
        byte[] Version { get; set; }
    }
}
