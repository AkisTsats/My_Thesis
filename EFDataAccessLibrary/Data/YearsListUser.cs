namespace EFDataAccessLibrary.Data
{
    public class YearsListUser
    {
        
        public int YearID { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }

        public YearsList Year { get; set; }
    }
}