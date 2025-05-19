using System.ComponentModel.DataAnnotations;

namespace DigitalStore.DataAccess.Entities;

public interface IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
}