﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDataAccessLibrary.Data
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedTs { get; set; }

        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Body { get; set; }

        public bool IsPublished { get; set; }

        public User Creator { get; set; }

        public Resource? PrimaryResource { get; set; }

        [InverseProperty(nameof(Resource.RelatesToAnnouncement))]
        public ICollection<Resource> RelatedResources { get; set; }

        [InverseProperty(nameof(Category.RelatesToAnnouncements))]
        public ICollection<Category> RelatedToCategories { get; set; }

        [InverseProperty(nameof(Subject.RelatesToAnnouncements))]
        public ICollection<Subject> RelatedToSubjects { get; set; }

        [InverseProperty(nameof(AcademicYears.RelatesToAnnouncements))]
        public ICollection<AcademicYears> RelatesToAcademicYears { get; set; }
    }

}
