using DTOs.Data;

namespace DTOs.API.Public.GetFilteringSettings
{
    public class Response
    {
        public IEnumerable<CategoryDTO> Categories { get; set; }
        public IEnumerable<SubjectDTO> Subjects { get; set; }
    }
}
