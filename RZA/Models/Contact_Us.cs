namespace RZA.Models
{
    public class Contact_Us
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public int Created_At { get; set; }
        public int Updated_At { get; set; }
    }
}
