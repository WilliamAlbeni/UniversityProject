namespace UniversityApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string College { get; set; }
    }
}
