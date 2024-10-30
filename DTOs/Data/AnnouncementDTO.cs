using DTOs.Common;

namespace DTOs.Data
{
    public class AnnouncementDTO
    {
        public int Id { get; set; }
        public bool IsPublished { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public UserPublicDTO Author { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; } = [];
        public IEnumerable<SubjectDTO> Subjects { get; set; } = [];
        public IEnumerable<AcademicYearDTO> AcademicYears { get; set; } = [];

        public List<ResourceDTO> Files { get; set; } //TODO
    }

}
