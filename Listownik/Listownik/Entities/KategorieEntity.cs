using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Listownik.Entities
{
    public class KategorieEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Pole Nazwa jest wymagane.")]
        public string Nazwa { get; set; } = default!;
    }
}
