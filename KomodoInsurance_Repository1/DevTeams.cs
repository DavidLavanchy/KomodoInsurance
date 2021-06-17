using KomodoInsurance_POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository1
{
    public class DevTeams
    {
        public DevTeams() { }
    

    public DevTeams(List <Developers> developer, string teamName, int teamIdentificationNumber)
        {
            Developer = developer;
            TeamName = teamName;
            TeamIdentificationNumber = teamIdentificationNumber;
        }
        public List <Developers> Developer { get; set; }

        public string TeamName { get; set; }

        public int TeamIdentificationNumber { get; set; }
    }
}
