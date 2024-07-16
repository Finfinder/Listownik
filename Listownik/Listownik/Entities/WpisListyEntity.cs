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
        public KategorieEntity Kategoria { get; set; } = default!;
        public ListyEntity Lista { get; set; } = default!;

    }
}
