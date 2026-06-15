namespace UniversityApi.DTOs
{
    public class ProfessorDto
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Specialization { get; set; }
    }
}
