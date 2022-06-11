using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class ClsElv
    {
        public int IdElev { get; set; }
        public int IdClasa { get; set; }

        public virtual Clase IdClasaNavigation { get; set; } = null!;
        public virtual Elevi IdElevNavigation { get; set; } = null!;
    }
}
