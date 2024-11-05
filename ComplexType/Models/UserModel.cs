namespace ComplexType.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public ContactInfo ContactInfo { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }

    public class ContactInfo
    {
        public string Phone { get; set; }
        public string AlternatePhone { get; set; }
    }
}
