namespace UniversityApi.Models
{
    public class Professor
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Specialization { get; set; }
    }
}
