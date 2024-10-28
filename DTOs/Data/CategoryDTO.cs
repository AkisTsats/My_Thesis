using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Data
{
    public record CategoryDTO(int Id, string CategoryName)
    {
        public static CategoryDTO? DEFAULT_NO_CATEGORY_CHOOSEN = new(0, "Δεν έχει επιλεχθεί κατηγορία");
    }
}
