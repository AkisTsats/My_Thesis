using DTOs.Data;

namespace DTOs.API.Public.UpdateMySettings
{
    public class Request
    {
        public IEnumerable<CategoryDTO> Categories { get; set; }
        public IEnumerable<SubjectDTO> Subjects { get; set; }
        public IEnumerable<AcademicYearDTO> AcademicYears { get; set; }
    }

    public class Response : DTOs.API.Public.GetMySettings.Response
    { }
}
