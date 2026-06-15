using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.DTOs;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var students = await _context.Students.OrderBy(s => s.Name).ToListAsync();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            var student = await _context.Students.SingleOrDefaultAsync(s => s.Id == id);
            if(student == null)
            {
                return NotFound($"No student found with ID: {id}");
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(StudentDto dto)
        {
            var student = new Student() { Name = dto.Name, College = dto.College };

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, StudentDto dto)
        {
            var student = await _context.Students.FindAsync(id);

            if(student == null)
            {
                return NotFound($"No student found with ID: {id}");
            }

            student.Name = dto.Name;
            student.College = dto.College;

            await _context.SaveChangesAsync();

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound($"No student found with ID: {id}");
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }
    }
}
