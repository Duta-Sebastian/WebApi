using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class Profesori
    {
        public Profesori()
        {
            ProfesoriClasas = new HashSet<ProfesoriClasa>();
        }

        public int Id { get; set; }
        public string NumeDefault { get; set; } = null!;
        public string? ParolaDefault { get; set; }
        public string? NumeCurent { get; set; }
        public string? ParolaCurenta { get; set; }
        public string Disciplina { get; set; } = null!;
        public string Clasa { get; set; } = null!;
        public string? Dirigentie { get; set; }

        public virtual ICollection<ProfesoriClasa> ProfesoriClasas { get; set; }
    }
}
