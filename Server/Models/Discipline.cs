using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class Discipline
    {
        public Discipline()
        {
            Absentes = new HashSet<Absente>();
            Notes = new HashSet<Note>();
        }

        public int IdDisciplina { get; set; }
        public string? Denumire { get; set; }

        public virtual ICollection<Absente> Absentes { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
