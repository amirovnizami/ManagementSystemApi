using ManagmentSystem.Domain.BaseEntities;

namespace ManagmentSystem.Domain.Entites;

public class Customer:BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
}