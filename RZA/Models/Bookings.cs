namespace RZA.Models
{
    public class Bookings
    {
        public int Id { get; set; }
        public int Service_Id { get; set; }
        public int Hotel_Id { get; set; }
        public int Quantity { get; set; }
        public int Date { get; set; }
        public int Total_Cost { get; set; }
        public int Loyalty_Cost { get; set;}
        public int Loyalty_Points_Earned { get; set; }
        public string Status { get; set; }
        public int Created_At { get; set; }
        public int Updated_At { get; set; }

    }
}
