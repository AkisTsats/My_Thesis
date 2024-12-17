using Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDataAccessLibrary.Data
{
    public record NotificationSettings(
        bool NotifyByEmail = false,
        IEnumerable<string> NotifyEmails = null,
        bool NotifyByPhone = false,
        IEnumerable<string> NotifyPhoneNumbers = null
        );

    public class User
    {
        [Key]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedTs { get; set; }

        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int EnrollmentYear { get; set; }
        public UserType Type { get; set; }
        public UserRole Role { get; set; }
        public DateTime? PauseNotificationsUntil { get; set; }
        public string NotificationSettings { get; set; }

        [NotMapped]
        public NotificationSettings NotificationSettingsDeserialized
        {
            get => NotificationSettings is null ? new NotificationSettings() : System.Text.Json.JsonSerializer.Deserialize<NotificationSettings>(NotificationSettings);
            set => NotificationSettings = System.Text.Json.JsonSerializer.Serialize(value);
        }

        [InverseProperty(nameof(Subject.SelectedByUsers))]
        public ICollection<Subject> SelectedSubjects { get; set; }

        [InverseProperty(nameof(Category.SelectedByUsers))]
        public ICollection<Category> SelectedCategories { get; set; }

        [InverseProperty(nameof(AcademicYears.SelectedByUsers))]
        public ICollection<AcademicYears> SelectedAcademicYears { get; set; }
    }
}
