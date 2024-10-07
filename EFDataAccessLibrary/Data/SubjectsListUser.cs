namespace EFDataAccessLibrary.Data
{
    public class SubjectsListUser
    {
        public int SubjectID { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }

        public SubjectsList Subject { get; set; }
    }
}