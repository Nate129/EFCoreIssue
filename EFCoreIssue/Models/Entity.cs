using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using EFCoreIssue.Abstractions;

namespace EFCoreIssue.Models
{
    public abstract class Entity<T> : IEntity
    {
        [Key] public T Id { get; set; }

        [SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "Versioning")]
        [Timestamp]
        public byte[] Version { get; set; }

        object IEntity.Id
        {
            get => Id;
            set => Id = value != null ? (T) value : default;
        }
    }
}
