using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class ClaseProfesor
    {
        public int IdProf { get; set; }
        public int IdClasa { get; set; }
        public int? IdDisc { get; set; }

        public virtual Clase IdClasaNavigation { get; set; } = null!;
        public virtual Profesori IdProfNavigation { get; set; } = null!;
    }
}
