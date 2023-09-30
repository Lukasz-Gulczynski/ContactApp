using Database.Data;
using Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class UsersController : ControllerBase
    {
        private readonly DataContex _contex;
        public UsersController(DataContex contex)
        {
            _contex = contex;
        }

        //Pobieranie listy użytkowników z bazy danych
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _contex.Users.ToListAsync();
        }

        //Pobranie konkretnego użytkownika
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _contex.Users.FindAsync(id);
        }
    }
}
