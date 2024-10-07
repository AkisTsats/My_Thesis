namespace EFDataAccessLibrary.Data
{
    public class CategoriesListUser
    {
        
        public int CategoryID { get; set; }
        
        public int UserID { get; set; }

        public User User { get; set; }  

        public CategoriesList Category { get; set; }
    }
}
