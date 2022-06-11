using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class Absente
    {
        public DateTime Data { get; set; }
        public int IdElev { get; set; }
        public int IdDisciplina { get; set; }
        public int? Absente1 { get; set; }
        public bool Motivat { get; set; }

        public virtual Discipline IdDisciplinaNavigation { get; set; } = null!;
        public virtual Elevi IdElevNavigation { get; set; } = null!;
    }
}
