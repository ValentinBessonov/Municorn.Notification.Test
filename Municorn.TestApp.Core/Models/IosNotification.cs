using System.ComponentModel.DataAnnotations;

namespace Municorn.TestApp.Core.Models
{
    public class IosNotification : INotification
    {
        [Required]
        [MaxLength(50)]
        public string PushToken { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Alert { get; set; }

        public int Priority { get; set; } = 10;

        public bool IsBackground { get; set; } = true;
    }
}
