using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RegistrationAPI.Models
{
    public class RegisteredUsers
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        private static string states = "|AL|AK|AZ|AR|CA|CO|CT|DE|DC|FM|FL|GA|GU|HI|ID|IL|IN|IA|KS|KY|LA|ME|MH|MD|MA|MI|MN|MS|MO|MT|NE|NV|NH|NJ|NM|NY|NC|ND|MP|OH|OK|OR|PW|PA|PR|RI|SC|SD|TN|TX|UT|VT|VI|VA|WA|WV|WI|WY|";

        public static bool isStateAbbreviation(string state)
        {
            return state.Length == 2 && states.IndexOf(state) > 0;
        }

        public static bool isUSZipCode(string zipCode)
        {
            Regex regex = new Regex(@"^\d{5}$|^\d{5}-\d{4}$");
            return regex.IsMatch(zipCode);
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(LastName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Address1))
            {
                return false;
            }
            if (string.IsNullOrEmpty(City))
            {
                return false;
            }
            if (string.IsNullOrEmpty(State) || !isStateAbbreviation(State))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Zip) || !isUSZipCode(Zip))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Country) || Country != "US")
            {
                return false;
            }

            return true;
        }
    }
}