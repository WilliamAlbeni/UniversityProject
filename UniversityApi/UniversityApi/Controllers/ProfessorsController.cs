using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.DTOs;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfessorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var professors = await _context.Professors.OrderBy(p => p.Name).ToListAsync();

            return Ok(professors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfessorByIdAsync(int id)
        {
            var professor = await _context.Professors.FindAsync(id);
            if (professor == null)
            {
                return NotFound($"No professor found with ID: {id}");
            }

            return Ok(professor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProfessorDto dto)
        {
            var professor = new Professor() { Name = dto.Name, Specialization = dto.Specialization };

            await _context.Professors.AddAsync(professor);
            await _context.SaveChangesAsync();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, ProfessorDto dto)
        {
            var professor = await _context.Professors.FindAsync(id);

            if (professor == null)
            {
                return NotFound($"No professor found with ID: {id}");
            }

            professor.Name = dto.Name;
            professor.Specialization = dto.Specialization;

            await _context.SaveChangesAsync();

            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var professor = await _context.Professors.FindAsync(id);

            if (professor == null)
            {
                return NotFound($"No professor found with ID: {id}");
            }

            _context.Professors.Remove(professor);
            await _context.SaveChangesAsync();
            return Ok(professor);
        }
    }
}
