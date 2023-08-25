using ASP.NET_core_web_api_part_01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_core_web_api_part_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase

    {
        private readonly DbFirstContext dbFirstContext;

        public StudentController(DbFirstContext dbFirstContext)
        {
            this.dbFirstContext = dbFirstContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var data = await dbFirstContext.Students.ToListAsync();

            return Ok(data);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var data = await dbFirstContext.Students.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            await dbFirstContext.Students.AddAsync(student);
            await dbFirstContext.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)

        {
            if (id != std.Id)
            {
                return BadRequest();
            }

            dbFirstContext.Students.Update(std);
            //dbFirstContext.Entry(std).State=EntityState.Modified;
            await dbFirstContext.SaveChangesAsync();
            return Ok(std);
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var data=await dbFirstContext.Students.FindAsync(id);
            if(data == null)
            {
                return NotFound(id);
            }
            dbFirstContext.Students.Remove(data);
            await dbFirstContext.SaveChangesAsync();  
            return Ok(data);
        }
    }
}
