namespace FluentValidationApp.Web.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Province { get; set; }
        public string PostCode { get; set; }

        // FK
        public int CustomerId { get; set; }

        // Navprop
        public virtual Customer Customer { get; set; }
    }
}
