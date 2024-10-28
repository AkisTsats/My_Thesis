using DTOs.Data;

namespace DTOs.API.Public.GetMySettings
{
    public class Response
    {
        public IEnumerable<CategoryDTO> Categories { get; set; }
        public IEnumerable<SubjectDTO> Subjects { get; set; }
        public IEnumerable<AcademicYearDTO> AcademicYears { get; set; }
    }
}
