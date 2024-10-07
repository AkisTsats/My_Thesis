using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Data
{
    public record CategoriesDTO(int CategoryID, string CategoryName)
    {
        public static CategoriesDTO? DEFAULT_NO_CATEGORY_CHOOSEN = new(0, "Δεν έχει επιλεχθεί κατηγορία");
    }
}
