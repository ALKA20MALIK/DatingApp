using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
    private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>>  GetUsers()
        {
            return await _context.Users.ToListAsync();

        }

        //api/Users/3
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            string str = "abcabcd";
             System.Console.WriteLine("output:");
            for (int i = 0; i < str.Length; i++)
            {
                for (int k = 0; k <= i; k++)
                {
                    if(str.Substring(0,k)== str.Substring(i-k+1,k)){
                        System.Console.Write(k+",");
                    }
                }
                
            }
             System.Console.WriteLine("finish:");

            return await _context.Users.FindAsync(id);
        }
    }
}