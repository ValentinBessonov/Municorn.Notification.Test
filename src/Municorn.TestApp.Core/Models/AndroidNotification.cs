using System.ComponentModel.DataAnnotations;

namespace Municorn.TestApp.Core.Models;

public class AndroidNotification : INotification
{
    [Required]
    [MaxLength(50)]
    public string DeviceToken { get; set; }

    [Required]
    [MaxLength(2000)]
    public string Message { get; set; }

    [Required]
    [MaxLength(255)]
    public string Title { get; set; }

    [MaxLength(2000)]
    public string? Condition { get; set; }

    public AndroidNotification()
    {

    }
}
