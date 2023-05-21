using System.ComponentModel.DataAnnotations;

namespace Dal.Interfaces;

public interface IBaseEntity
{
    public Guid Id { get; set; }
}
