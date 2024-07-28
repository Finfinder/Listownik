using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Listownik.Entities
{
    public class WpisListyEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Pole Nazwa jest wymagane.")]
        public string Nazwa { get; set; } = default!;
        public string? Opis { get; set; }
        public int Ilosc { get; set; }
        public byte[]? Ikona { get; set; }

        [ForeignKey("ListaId")]
        [Required(ErrorMessage = "Pole ListaId jest wymagane.")]
        public Guid ListaId { get; set; } // Dodano właściwość ListaId
    }
}
