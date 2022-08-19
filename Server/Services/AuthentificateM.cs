using Server.Authorization;
using Server;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Services
{
    public interface IUserService
    {
        Task<User> AuthenticateProfesor(string username, string password);
        Task<User> AuthentificateElev(string username, string password);
    }

    public class AuthentificateM : IUserService
    {
        private DataBaseContext _dbcontext;
        private List<Elevi> listEleviLog = new List<Elevi>();
        private List<Profesori> listProfesoriLog = new List<Profesori>();

        public AuthentificateM(DataBaseContext _context)
        {
        _dbcontext = _context;
        }

        public async Task<User?> AuthenticateProfesor(string username, string password)
        {

            List<Profesori> listProfesoriLog = _dbcontext.Profesoris.ToList();
            var user = listProfesoriLog.SingleOrDefault(x => x.NumeCurent == username && x.ParolaCurenta == password);
            User user1 = new User();
            if (user != null)
            {
                user1.nume = user.NumeCurent;
                user1.parola = user.ParolaCurenta;
                // on auth fail: null is returned because user is not found
                // on auth success: user object is returned
                return user1;
            }
            else
            {
                return null;
            }
            // wrapped in "await Task.Run" to mimic fetching user from a db

        }

        public async Task<User?> AuthentificateElev(string username, string password)
        {

            List<Elevi> listEleviLog = _dbcontext.Elevis.ToList();
            var user = listEleviLog.SingleOrDefault(x => x.NumeCurent == username && x.ParolaCurenta == password);
            User user1 = new User();
            if (user != null)
            {
                user1.nume = user.NumeCurent;
                user1.parola = user.ParolaCurenta;
                // on auth fail: null is returned because user is not found
                // on auth success: user object is returned
                return user1;
            }
            else
            {
                return null;
            }
            // wrapped in "await Task.Run" to mimic fetching user from a db

        }
    }
}
