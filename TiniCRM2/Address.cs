namespace TiniCRM2
{
    public class Address
    {
        private string iD;
        private string phone;
        private string email;
        private string location;

        public string ID { get => iD; set => iD = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Location { get => location; set => location = value; }

        public Address(string id = null, string phone = null, string email = null,  string location = null)
        {
            ID = id;
            Email = email;
            Phone = phone;
            Location = location;
        }
    }
}