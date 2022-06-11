using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class Clase
    {
        public int Id { get; set; }
        public string Clasa { get; set; } = null!;

        public virtual ProfesoriClasa ProfesoriClasa { get; set; } = null!;
    }
}
