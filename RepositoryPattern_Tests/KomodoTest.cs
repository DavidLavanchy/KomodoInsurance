using KomodoInsurance_POCOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RepositoryPattern_Tests
{
    [TestClass]
    public class KomodoTest
    {
        [TestMethod]
        public void SetDeveloperProperties_ShouldSetDeveloperProperties()
        {
            Developers developer = new Developers();

            developer.FirstName = "Scott";
            developer.LastName = "Sharp";
            developer.IdentificationNumber = 1996;
            developer.HasAcessToPluralsight = false;

            string expectedFirstName = "Scott";
            string actualFirstName = developer.FirstName;

            string expectedLastName = "Sharp";
            string actualLastName = developer.LastName;

            int expectedID = 1996;
            int actualID = developer.IdentificationNumber;

            bool expectedAccess = false;
            bool actualAccess = developer.HasAcessToPluralsight;

            Assert.AreEqual(expectedFirstName, actualFirstName);
            Assert.AreEqual(expectedLastName, actualLastName);
            Assert.AreEqual(expectedID, actualID);
            Assert.AreEqual(expectedAccess, actualAccess);

        }
    }
}
