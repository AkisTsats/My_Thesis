using DTOs.Data;
using EFDataAccessLibrary.Data;
using System.Linq;

namespace AnnouncementAPI
{
    public static class Mappers
    {
        public static AnnouncementDTO ToAnnouncementDTO(this Announcement entry) => new()
        {
            Id = entry.Id,
            Title = entry.Title,
            Abstract = entry.Abstract,
            Body = entry.Body,
            CreationDate = entry.CreatedTs,
            Author = entry.Creator?.ToUserPublicDTO(),
            Categories = entry.RelatedToCategories.Select(ToCategoryDTO),
            Subjects = entry.RelatedToSubjects.Select(ToSubjectDTO),
        };

        public static UserPublicDTO ToUserPublicDTO(this User entry) => new()
        {
            Id = entry.Id,
            FullName = entry.FullName,
            FirstName = entry.FirstName,
            LastName = entry.LastName,
        };

        public static CategoryDTO ToCategoryDTO(this Category entry) => new(entry.Id, entry.Name);
        public static SubjectDTO ToSubjectDTO(this Subject entry) => new(entry.Id, entry.Name);
        public static AcademicYearDTO ToAcademicYearDTO(this AcademicYears entry) => new()
        {
            Id = entry.Id,
            Year = entry.Year
        };

        public static UserDTO ToUserDTO(this User entry) => new()
        {
            Id = entry.Id,
            FullName = entry.FullName,
            FirstName = entry.FirstName,
            LastName = entry.LastName,
            CreatedTs = entry.CreatedTs,
            Email = entry.Email,
            Role = entry.Role,
            //EnrollmentYear = entry?.EnrollmentYear,
            //NotifyByEmail = entry?.NotificationSettingsDeserialized?.NotifyByEmail
            //TODO: Add other properties
        };
    }
}
