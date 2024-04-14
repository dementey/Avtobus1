using System.ComponentModel.DataAnnotations;

namespace Avtobus1.Models
{
    public class Url
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Long Url")]
        [RegularExpression("(https?://|ftps?://|www.)((?![.,?!;:()]*(\\s|$))[^\\s]){2,}", ErrorMessage = "Enter the site link")]
        [StringLength(250, MinimumLength = 6, ErrorMessage = "The length should be from 6 to 250 characters")]
        public string LongUrl { get; set; }
        [Display(Name = "Short Url")]
        public string ShortUrl { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "Click Count")]
        public int ClickCount { get; set; }
    }
}
