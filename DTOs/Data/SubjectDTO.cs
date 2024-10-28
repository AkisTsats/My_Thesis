using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Data
{
    public record SubjectDTO(int Id, string SubjectName)
    {
        public static SubjectDTO? DEFAULT_NO_SUBJECT_CHOOSEN = new(0, "Δεν έχει επιλεχθεί μάθημα");
    }
}
