using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CodeHub.Api.Models;

[DataContract]
public class CodeHubRepo
{
    [Required]
    public string Owner { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int StarredCount { get; set; }
}
