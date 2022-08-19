using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Server.Authorization;
using Server.Models;
namespace Server.Controllers
{
    [ApiController]
    [Route("api/Elev/[controller]")]
    [Authorize]
    public class ElevController : ControllerBase
    {
        private readonly DataBaseContext _dbcontext;

        public ElevController(DataBaseContext _context)
        {
            _dbcontext = _context;
        }

        [Elev]
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
