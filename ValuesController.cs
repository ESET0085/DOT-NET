using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private List<string> students = new List<string>
        { "Ghosh", "Nabi", "Shreyansh" };

        private List<Dictionary<string, string>> student_dict = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string>
            {
                { "Id", "1" },
                { "Name", "Ghosh" }

            },
            new Dictionary<string, string>
            {
                { "Id", "2" },
                { "Name", "Nabi" }

            },

        };

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return new JsonResult(student_dict);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(string id)
        {
            var student_details = student_dict.FirstOrDefault(s => s["Id"] == id.ToString());
            if (student_details == null)
            {
                return NotFound();
            }
            return new JsonResult(student_details);

        }


    }
}
