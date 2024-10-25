using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDataAccessLibrary.Data
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedTs { get; set; }

        public ResourceType Type { get; set; }
        public string Name { get; set; }
        public string? ContentType { get; set; }
        public string? FilePath { get; set; }

        public Announcement? RelatesToAnnouncement { get; set; }
    }
}
