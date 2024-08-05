using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Domain.ValueObjects
{
    public class UserPaymentDetail
    {
        private string _email;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email
        {
            get => _email;
            set
            {
                // Basit e-posta formatı doğrulaması
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                {
                    throw new ArgumentException("Geçersiz e-posta adresi.");
                }
                _email = value;
            }
        }
        public string IdentityNumber { get; set; }
        public DateTimeOffset LastLoginDate { get; set; }
        public string Address { get; set; }
        public string Ip { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
