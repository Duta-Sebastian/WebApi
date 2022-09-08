using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Server.Authorization;
using Server.Models;
using System.Reflection.Metadata;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/Login/[controller]")]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly DataBaseContext _dbcontext;

        public LoginController(DataBaseContext _context)
        {
            _dbcontext = _context;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("LoginElev")]
        public async Task<IActionResult> LoginElev(string nume, string parola)
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
                                var parameter = new SqlParameter
                                {
                                    ParameterName = "@nume",
                                    Value = nume
                                };
                                var x = _dbcontext.ClsNumDs.FromSqlRaw("exec ClsNumD @nume", parameter);
                                
                                return Ok(new { Check = "1", MainBody = x });
                            }
                            else return Ok(new { Check = "0"});                           
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

        [AllowAnonymous]
        [HttpGet]
        [Route("LoginProfesor")]
        public async Task<IActionResult> LoginProfesor(string nume, string parola)
        {
            try
            {
                List<Profesori> listProfesori = _dbcontext.Profesoris.ToList();
                if (listProfesori != null)
                {
                    foreach (Profesori profesori in listProfesori)
                    {
                        if (profesori.NumeDefault == nume || profesori.NumeCurent == nume)
                        {
                            if (profesori.ParolaDefault == parola || profesori.ParolaCurenta == parola)
                            {
                                return Ok("1");
                            }
                            else return Ok("0");
                        }

                    }
                    return Ok("Nu exista profesori cu acest username");
                }
                else return Ok("Nu sunt profesori");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
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

        [Profesor]
        [HttpPost]
        [Route("AdaugNote")]
        public async Task<IActionResult> AdaugNote(string data, string nume , string materia, int nota)
        {
            try
            {
                var parameter = new SqlParameter
                {
                    ParameterName = "@data",
                    Value = data
                };
                var parameter1 = new SqlParameter
                {
                    ParameterName = "@elev",
                    Value = nume
                };
                var parameter2 = new SqlParameter
                {
                    ParameterName = "@disciplina",
                    Value = materia
                };
                var parameter3 = new SqlParameter
                {
                    ParameterName = "@nota",
                    Value = nota
                };
                var x = _dbcontext.AdgNota.FromSqlRaw("exec AdaugaNota @data,@elev,@disciplina,@nota", parameter, parameter1,parameter2,parameter3);
                return Ok(x);
            }
            catch (Exception)
            {
                return Ok("Nereusit");
            }
        }
    }
}