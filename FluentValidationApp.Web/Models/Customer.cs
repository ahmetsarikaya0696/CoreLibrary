namespace FluentValidationApp.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime? Birthday { get; set; }
        public Gender Gender { get; set; }

        // Navprop
        public virtual IList<Address> Addresses { get; set; }
    }
}
