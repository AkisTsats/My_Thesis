﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Data
{
    public class PreferenceDTO
    {
        public int PreferenceID { get; set; }
        public bool InMail { get; set; }
        public bool InBrowser { get; set; }
        public bool InPhone { get; set; }
        public bool PauseOneHour { get; set; }
        public bool PauseOneDay { get; set; }
        public bool PauseAlert { get; set; }

    }
}
