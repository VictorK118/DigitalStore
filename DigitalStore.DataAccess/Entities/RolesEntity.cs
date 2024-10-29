using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalStore.DataAccess.Entities;

[Table("Roles")]
public class RolesEntity: BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public virtual ICollection<UsersEntity> Users { get; set; }
}