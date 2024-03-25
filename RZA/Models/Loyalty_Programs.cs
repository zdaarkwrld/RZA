namespace RZA.Models
{
    public class Loyalty_Programs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points_Required { get; set; }
        public string Reward {  get; set; }
        public int Created_At { get; set; }
        public int Updated_At { get; set; }

    }
}
