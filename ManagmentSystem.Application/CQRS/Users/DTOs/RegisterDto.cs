namespace ManagmentSystem.Application.CQRS.Users.DTOs;

public record struct RegisterDto
{
    public int Id { get; init; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
};