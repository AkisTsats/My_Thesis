using DTOs.Data;

namespace DTOs.API.Settings.UpdateMySettings
{
    public class Request
    {
        public DateTime? PauseNotificationUntilDate { get; set; }
        public bool ReceiveNotificationsByEmail { get; set; }
        public IEnumerable<string>? ReceiveNotificationsInEmails { get; set; }
        public bool ReceiveNotificationsByPhone { get; set; }
        public IEnumerable<string>? ReceiveNotificationsInPhones { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }
        public IEnumerable<SubjectDTO> Subjects { get; set; }
        //public IEnumerable<AcademicYearDTO> AcademicYears { get; set; }
    }

    public class Response : DTOs.API.Settings.GetMySettings.Response
    { }
}
