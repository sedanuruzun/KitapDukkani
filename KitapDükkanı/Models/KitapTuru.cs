using System.ComponentModel.DataAnnotations;

namespace KitapDükkanı.Models
{
    public class KitapTuru
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Kitap türü adı alanı boş bırakılamaz")]
        [MaxLength(25)]
        public string Ad { get; set; }
    }
}
