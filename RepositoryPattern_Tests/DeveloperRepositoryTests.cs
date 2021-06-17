using KomodoInsurance_POCOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RepositoryPattern_Tests
{
    [TestClass]
    public class DeveloperRepositoryTests
    {
        
        private DeveloperRepo _repo;
        private Developers _developer;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new DeveloperRepo();
            _developer = new Developers("Scott", "Sharp", 1996, false);

            _repo.AddDeveloperToList(_developer);
        }

        [TestMethod]
        public void AddDeveloperToList_ShouldGetNotNull()
        {
            Developers developer = new Developers();
            developer.FirstName = "Scott";
            developer.LastName = "Sharp";
            developer.IdentificationNumber = 1996;

            DeveloperRepo repository = new DeveloperRepo();

            repository.AddDeveloperToList(developer);
            Developers developerFromRepository = repository.GetDeveloperByIdentificationNumber(1996);

            Assert.IsNotNull(developerFromRepository);
        }
        [TestMethod]
        public void UpdateDevelopers_ShouldReturnTrue()
        {
            //Arrange
            Developers newDeveloper = new Developers("Scotty", "Sharp", 1996, true);
            
            //Act
            bool updateResult = _repo.UpdateExistingDevelopers(1996, newDeveloper);

            //Assert
            Assert.IsTrue(updateResult);

        }
        [DataTestMethod]
        [DataRow(1996, true)]
        [DataRow(2003, false)]
        public void UpdateExistingDeveloper_ShouldMatchGivenBool(int originalIdentificationNumber, bool shouldUpdate)
        {
            //Arrange
            Developers newDeveloper = new Developers("Scotty", "Sharp", 1996, true);

            //Act
            bool updateResult = _repo.UpdateExistingDevelopers(originalIdentificationNumber, newDeveloper);

            //Assert
            Assert.AreEqual(shouldUpdate,updateResult);

        }
        [TestMethod]
        public void DeleteDevelopers_ShouldReturnTrue()
        {
            //Arrange
        

            //Act
            bool deleteResult = _repo.RemoveDeveloperFromList(_developer.IdentificationNumber);

            //Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
