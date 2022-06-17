using System.ComponentModel.DataAnnotations;

namespace EasyOposUI.Models
{
    public class CreateBlockModel
    {
        [Required]
        public int Number { get; set; }
        [Required]
        public string Title { get; set; }
        //[Required]
        //[MinLength(1)]
        //[Display(Name = "Unidad")]
        public string UnitId { get; set; }
    }
}
