﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Listownik.Entities
{
    public class Kategorie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; protected set; }
        public string Nazwa { get; set; } = default!;
    }
}
