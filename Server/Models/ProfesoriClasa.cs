using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class ProfesoriClasa
    {
        public int IdClasa { get; set; }
        public int IdProf { get; set; }

        public virtual Clase IdClasaNavigation { get; set; } = null!;
        public virtual Profesori IdProfNavigation { get; set; } = null!;
    }
}
