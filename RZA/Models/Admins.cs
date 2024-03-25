namespace RZA.Models
{
    public class Admins
    {
        public int Id { get; set; }
        public string Admin_Name { get; set; }
        public string Admin_Role { get; set;}
        public int User_Id { get; set; }
        public int Created_At { get; set; }
        public int Updated_At { get; set; }

    }
}
