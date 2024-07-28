using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Listownik.Entities
{
    public class WpisListyEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Nazwa { get; set; } = default!;
        public string? Opis { get; set; }
        public int Ilosc { get; set; }
        public byte[]? Ikona { get; set; }

        [ForeignKey("KategoriaId")]
        public KategorieEntity? Kategoria { get; set; }

        [ForeignKey("ListaId")]
        public ListyEntity? Lista { get; set; }
        public Guid ListaId { get; set; } // Dodano właściwość ListaId
    }
}
