using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class Elevi
    {
        public Elevi()
        {
            Absentes = new HashSet<Absente>();
            Notes = new HashSet<Note>();
        }

        public int Id { get; set; }
        public string NumeDefault { get; set; } = null!;
        public string? ParolaDefault { get; set; }
        public string? NumeCurent { get; set; }
        public string? ParolaCurenta { get; set; }
        public string Clasa { get; set; } = null!;

        public virtual ICollection<Absente> Absentes { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
