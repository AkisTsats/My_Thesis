using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Data
{
    public class Preference
    {
        [Key]
        public int PreferenceId { get; set; }
        public string BackupMail { get; set; }
        public bool InMail { get; set; }
        public bool InBrowser { get; set; }
        public bool InPhone { get; set; }
        public bool PauseOneHour { get; set; }
        public bool PauseOneDay { get; set; }
        public bool PauseAlert { get; set; }
        public DateTime CurrentYear { get; set; }
        public DateTime EnrolmentYear { get; set; }
        public User User { get; set; }

    }
}
