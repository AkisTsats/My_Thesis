using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Data
{
    public class Permissions
    {
        [Key]
        public bool Access { get; set; }
        public bool Repeat { get; set; }
        public bool CreateNewUser { get; set; }
        public bool DeleteUser { get; set; }
        public bool Publish { get; set; }
        public bool StatsLevel1 { get; set; }
        public bool StatsLevel2 { get; set; }
        public bool SOS { get; set; }
    }
}
