using System.ComponentModel.DataAnnotations;

namespace EasyOposUI.Models
{
    public class CreateUnitModel
    {
        [Required]
        public int Number { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
