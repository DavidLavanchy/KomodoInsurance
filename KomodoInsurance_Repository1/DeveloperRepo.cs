using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoInsurance_Repository1;

namespace KomodoInsurance_POCOs

{
    public class DeveloperRepo
    {
        public List<Developers> _listOfDevelopers = new List<Developers>();

        public void AddDeveloperToList(Developers developer)
        {
            _listOfDevelopers.Add(developer);
        }

        public List<Developers> GetDevelopersList()
        {
            return _listOfDevelopers;
        }


        public bool UpdateExistingDevelopers(int originalIdentificationNumber, Developers newDeveloper)
        {
            Developers oldDeveloper = GetDeveloperByIdentificationNumber(originalIdentificationNumber);

            if(oldDeveloper != null)
            {
                oldDeveloper.IdentificationNumber = newDeveloper.IdentificationNumber;
                oldDeveloper.FirstName = newDeveloper.FirstName;
                oldDeveloper.LastName = newDeveloper.LastName;
                oldDeveloper.HasAcessToPluralsight = newDeveloper.HasAcessToPluralsight;
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool RemoveDevTeamFromList(int identificationNumber)
        {
            Developers developer = GetDeveloperByIdentificationNumber(identificationNumber);

            if(developer == null)
            {
                return false;
            }
            int initialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(developer);

            if(initialCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public Developers GetDeveloperByIdentificationNumber(int identificationNumber)
        {


            foreach(Developers developer in _listOfDevelopers)
            {
                if(developer.IdentificationNumber == identificationNumber)
                {
                    return developer;
                }
               
            }
            return null;
        }

    }
}
