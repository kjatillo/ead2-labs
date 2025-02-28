using System.ComponentModel.DataAnnotations;

namespace SmsService.Api.Entities;

public class ShortMessage
{
    [Required]
    [Phone]
    public string Sender { get; set; }

    [Required]
    [Phone]
    public string Receiver { get; set; }

    [Required]
    [MinLength(1)]
    [MaxLength(140)]
    public string Message { get; set; }
}
