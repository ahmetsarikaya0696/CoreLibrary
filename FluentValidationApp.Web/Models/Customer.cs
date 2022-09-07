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

        public virtual IList<Address> Addresses { get; set; }
        public string GetFullName() => $"Name:{Name}, Email:{Email}, Age:{Age}";
        //public string FullName2() => $"Name:{Name}, Email:{Email}, Age:{Age}";
        public CreditCard CreditCard { get; set; }
    }
}
