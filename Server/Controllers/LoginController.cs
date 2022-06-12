using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Server.Models;
namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LoginController : ControllerBase
    {
        private readonly DataBaseContext _dbcontext;

        public LoginController(DataBaseContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> GetElevi(string nume, string parola)
        {
            try 
            {
                List<Elevi> listElevi = _dbcontext.Elevis.ToList();
                if (listElevi != null)
                {
                    foreach (Elevi elevi in listElevi)
                    {
                        if (elevi.NumeDefault == nume || elevi.NumeCurent == nume) 
                        {
                            if (elevi.ParolaDefault == parola || elevi.ParolaCurenta == parola)
                            {
                                return Ok("1");
                            }
                            else return Ok("0");                           
                        }
                            
                    }
                    return Ok("Nu exista elevi cu acest username");
                }
                else return Ok("Nu sunt elevi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("sp1")]
        public async Task<IActionResult> sp1(string prof,string disciplina)
        {
            try
            {
                var parameter = new SqlParameter
                {
                    ParameterName = "@prof",
                    Value = prof
                };
                var parameter1 = new SqlParameter
                {
                    ParameterName = "@disciplina",
                    Value = disciplina
                };
                var x = _dbcontext.Class_1.FromSqlRaw("exec GetClase @prof,@disciplina", parameter, parameter1);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("AfisNote")]
        public async Task<IActionResult> AfisNote(string materia, string elev)
        {
            try
            {
                var parameter = new SqlParameter
                {
                    ParameterName = "@materia",
                    Value = materia
                };
                var parameter1 = new SqlParameter
                {
                    ParameterName = "@elev",
                    Value = elev
                };
                var x = _dbcontext.AfsNote.FromSqlRaw("exec AfisNote @materia,@elev", parameter, parameter1);
                return Ok(x);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}