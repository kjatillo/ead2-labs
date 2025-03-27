using System.ComponentModel.DataAnnotations;

namespace PhoneBookService.Entities;

public class Contact
{
    [Required]
    [Key]
    public string PhoneNumber { get; set; }
    [Required]
    public string Name { get; set; }
    public string? Address { get; set; }
}
