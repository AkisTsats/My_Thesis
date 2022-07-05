﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Data
{
    public class Announcement
    {
        [Key]
        public int AnnID { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public bool Alert { get; set; }
        public string Author { get; set; }        
        public User User { get; set; }
        //public CategoriesList Categories { get; set; }
    }

}
