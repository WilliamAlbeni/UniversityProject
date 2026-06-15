namespace UniversityApi.DTOs
{
    public class StudentDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public string College { get; set; }
    }
}
