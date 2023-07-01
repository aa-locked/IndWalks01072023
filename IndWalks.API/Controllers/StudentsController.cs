using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()   
        {
            string[] stududents = new string[] { "Praveen","Mohit"};
            return Ok(stududents);
        }

    }
}
