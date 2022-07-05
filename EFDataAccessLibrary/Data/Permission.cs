using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Data
{
    public class Permission
    {
        [Key]
        public int UserID { get; set; }

        public bool canPostAnn { get; set; }
        public bool canSeePubAnn { get; set; } = true;
        public bool canSeeMyAnn { get; set; }
        public bool canEditMyAnn { get; set; }
        public bool canDeleteMyAnn { get; set; }


        public bool canEditNotifications { get; set; }
        public bool canEditMyYears { get; set; }
        public bool canEditMySubjects { get; set; }
        public bool canPostInfo { get; set; }


        public bool SOS { get; set; }
        public bool selectCategory { get; set; }
        public bool selectSubject { get; set; }


        public bool canSeeAllAnn { get; set; }
        public bool canEditAllAnn { get; set; }
        public bool canAcceptAnn { get; set; }

        public bool canSeeStats { get; set; }
        public bool canDeleteAllAnn { get; set; }
        public bool canAddCategories { get; set; }
        public bool canAddSubjects { get; set; }



        public User User { get; set; }
    }
}