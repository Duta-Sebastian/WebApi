using Microsoft.EntityFrameworkCore;
using Server.Models;
namespace Server
{
    public class Securitate
    {
        public static bool LoginElev(string nume, string parola)
        {
            using (DataBaseContext _dbcontext = new DataBaseContext())
            {
                return _dbcontext.Elevis.Any(Elevi => Elevi.NumeCurent.Equals(nume) && Elevi.ParolaCurenta.Equals(parola));
            }
               
        }
    }
}
