using KomodoInsurance_POCOs;
using KomodoInsurance_Repository1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RepositoryPattern_Tests
{
    [TestClass]
    public class DevTeamsRepositoryTests
    {
        private DevTeamsRepo _repo;
        private DevTeams _devTeam;
        private Developers _developers;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new DevTeamsRepo();
            _developers = new Developers("Scott", "Sharp", 1996, true);
            _devTeam = new DevTeams(_developers, "Mobile Team", 2);

            _repo.AddDevelopertoDevTeamToList(_devTeam);
        }
         
        [TestMethod]
        public void AddDevTeam_ShouldReturnNotNull()
        {


            DevTeamsRepo repository = new DevTeamsRepo();

            repository.AddDevelopertoDevTeamToList(_devTeam);
            DevTeams devTeamFromRepository = repository.GetDevTeamByIdentificationNumber(2);

            Assert.IsNotNull(devTeamFromRepository);
        }

        [TestMethod]
        public void UpdateDevTeam_ShouldReturnTrue() 
        {
            DevTeams newDevTeam = new DevTeams(_developers, "DevOps", 2);

            bool updateResult = _repo.UpdateExistingDevelopersOnDevTeamsList(2, newDevTeam);

            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteDevTeamFromList_ShouldReturnTrue() 
        {
            bool deleteResult = _repo.RemoveDeveloperFromDevTeamsList(_devTeam.TeamIdentificationNumber);

            Assert.IsTrue(deleteResult);
        }
    }
}
