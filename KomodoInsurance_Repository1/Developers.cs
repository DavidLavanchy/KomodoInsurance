using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_POCOs

{
    public class Developers
    {
        public Developers(){}

        public Developers(string firstName, string lastName, int identificationNumber, bool hasAccesToPluralsight)
        {
            FirstName = firstName;
            LastName = lastName;
            IdentificationNumber = identificationNumber;
            HasAcessToPluralsight = hasAccesToPluralsight;

        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int IdentificationNumber { get; set; }

        public bool HasAcessToPluralsight { get; set; }
    }
}
