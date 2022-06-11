using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class ProfDisc
    {
        public int IdProf { get; set; }
        public int IdDisciplina { get; set; }

        public virtual Discipline IdDisciplinaNavigation { get; set; } = null!;
        public virtual Profesori IdProfNavigation { get; set; } = null!;
    }
}
