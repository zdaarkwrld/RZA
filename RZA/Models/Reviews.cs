namespace RZA.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Service_Id { get; set; }
        public int Rating { get; set; }
        public int Comment_Id { get; set; }
    }
}
