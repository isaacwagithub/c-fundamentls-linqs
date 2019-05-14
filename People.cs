using System;
using System.Collections.Generic;
using System.Text;

namespace Linqs
{
    class People
    { 
        private string firstName;
        private string lastName;
        private string town;
        private string postalCode;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Town { get => town; set => town = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
    }
}
