using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret() 
        {
            return "secret text";
        }

         [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound() 
        {
            var thing = _context.Users.Find(-1);
            
            if (thing == null) return NotFound();
            
            return thing;
        }

         [HttpGet("server-error")]
        public ActionResult<string> GetServerError() 
        {           
            
            var thing = _context.Users.Find(-1);

            var thingToReturn = thing.ToString(); //an einai null tha epistrepsei exception giati den ginetai metatropi null se string

            return thingToReturn;
        }

         [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest() 
        {
            return BadRequest("This was not a good request");
        }
    }

}