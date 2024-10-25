using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Data
{
    public record SubjectsDTO(int SubjectID, string SubjectName)
    {
        public static SubjectsDTO? DEFAULT_NO_SUBJECT_CHOOSEN = new(0, "Δεν έχει επιλεχθεί μάθημα");
    }
}
