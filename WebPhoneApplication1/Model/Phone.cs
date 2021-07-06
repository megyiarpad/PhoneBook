using System;

namespace PhoneRestApi
{
    public class PhoneDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

    }

    public class Phone : PhoneDTO
    {
        public int ID { get; set; }
    }
}
