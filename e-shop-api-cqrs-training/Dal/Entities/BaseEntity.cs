using Dal.Interfaces;

namespace Dal.Entities;

public class BaseEntity : IBaseEntity
{
    public Guid Id { get; set; }
}
