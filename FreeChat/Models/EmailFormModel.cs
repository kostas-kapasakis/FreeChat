using System.ComponentModel.DataAnnotations;

namespace FreeChat.Models
{
    public class EmailFormModel
    {
        [DataType(DataType.EmailAddress), Display(Name = "To")]
        [Required]
        public string ToEmail { get; set; }
        [Required, Display(Name = "Name")]
        public string FromName { get; set; }
        [Required, Display(Name = "Email"), EmailAddress]
        public string FromEmail { get; set; }
        [Required]
        public string Message { get; set; }
        [Display(Name = "Subject")]
        public string EmailSubject { get; set; }
    }
}