using System.ComponentModel.DataAnnotations;

namespace EasyOposUI.Models
{
    public class CreateQuestionModel
    {
        [Required]
        public string Question { get; set; }
        [Required]
        public OptionModel OptionA { get; set; } = new();
        [Required]
        public OptionModel OptionB { get; set; } = new();
        [Required]
        public OptionModel OptionC { get; set; } = new();
        [Required]
        [MinLength(1)]
        [Display(Name = "Bloque")]
        public string BlockId { get; set; }
    }
}
