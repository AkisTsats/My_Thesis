using DTOs.Data;

namespace DTOs.API.Requests
{
    public class SettingsForAnnouncementCreation
    {
        public IEnumerable<CategoryDTO> Categories { get; set; }
        public IEnumerable<SubjectDTO> Subjects { get; set; }
        public IEnumerable<AcademicYearDTO> AcademicYears { get; set; }
    }
}
