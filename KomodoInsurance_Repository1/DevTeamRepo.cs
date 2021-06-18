
using KomodoInsurance_POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository1
{
    public class DevTeamsRepo
    {
        private List<DevTeams> _listOfDevTeams = new List<DevTeams>();



        //Create
        public void AddDevelopertoDevTeamToList(DevTeams devTeams)
        {
            _listOfDevTeams.Add(devTeams);
        }


        //Read
        public List<DevTeams> GetListOfDevTeams()
        {
            return _listOfDevTeams;
        }


        //Update
        public bool UpdateExistingDevelopersOnDevTeamsList(int originalTeamIdentificationNumber, DevTeams newDevTeam)
        {
            DevTeams oldDevTeams = GetDevTeamByIdentificationNumber(originalTeamIdentificationNumber);

            if (oldDevTeams != null)
            {

                oldDevTeams.Developer = newDevTeam.Developer;
                oldDevTeams.TeamName = newDevTeam.TeamName;
                oldDevTeams.TeamIdentificationNumber = newDevTeam.TeamIdentificationNumber;
                return true;
            }
            else
            {
                return false;
            }
        }


        //Delete
        public bool RemoveDeveloperFromDevTeamsList(int teamIdentificationNumber)
        {
            DevTeams devTeams = GetDevTeamByIdentificationNumber(teamIdentificationNumber);
            if(devTeams == null)
            {
                return false;
            }
            int initialCount = _listOfDevTeams.Count;
            _listOfDevTeams.Remove(devTeams);

            if(initialCount > _listOfDevTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveDevFromTeam(int devTeamID, int developerID)
        {
            DevTeams developerFromList = GetDevTeamByIdentificationNumber(devTeamID);

            foreach (Developers developers in developerFromList.Developer)
            { 
                if(developerID == developers.IdentificationNumber)
                {
                    developerFromList.Developer.Remove(developers);
                    return true;
                }

            }
            return false;
        }


        //Helper Method
        public DevTeams GetDevTeamByIdentificationNumber(int teamIdentificationNumber)
        {

            foreach(DevTeams devTeams in _listOfDevTeams)
            {
                if(devTeams.TeamIdentificationNumber == teamIdentificationNumber)
                {
                    return devTeams;
                }
            }
            return null;
        }
    }
}
