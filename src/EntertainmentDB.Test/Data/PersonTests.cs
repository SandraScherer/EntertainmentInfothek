using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntertainmentDB.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntertainmentDB.Data.Tests
{
    [TestClass()]
    public class PersonTests
    {
        [TestMethod()]
        public void PersonTest()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.IsNotNull(entry.Reader);

            Assert.AreEqual("", entry.ID);
            Assert.IsNull(entry.FirstName);
            Assert.IsNull(entry.LastName);
            Assert.IsNull(entry.Name);
            Assert.IsNull(entry.NameAddOn);
            Assert.IsNull(entry.BirthName);
            Assert.IsNull(entry.DateOfBirth);
            Assert.IsNull(entry.DateOfDeath);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void PersonTest_withID()
        {
            // Arrange
            Person entry = new Person("_xxx");

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.IsNotNull(entry.Reader);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.IsNull(entry.FirstName);
            Assert.IsNull(entry.LastName);
            Assert.IsNull(entry.Name);
            Assert.IsNull(entry.NameAddOn);
            Assert.IsNull(entry.BirthName);
            Assert.IsNull(entry.DateOfBirth);
            Assert.IsNull(entry.DateOfDeath);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withValidID_BasicInfoOnly()
        {
            // Arrange
            Person entry = new Person("_xxx");

            // Act
            int count = entry.RetrieveBasicInformation(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Person First Name X", entry.FirstName);
            Assert.AreEqual("Person Last Name X", entry.LastName);
            Assert.AreEqual("Person First Name X Person Last Name X", entry.Name);
            Assert.AreEqual("Person Name AddOn X", entry.NameAddOn);
            Assert.AreEqual("Person Birth Name X", entry.BirthName);
            Assert.AreEqual("Person Date of Birth X", entry.DateOfBirth);
            Assert.AreEqual("Person Date of Death X", entry.DateOfDeath);
            Assert.AreEqual("Person Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Person Last Updated X", entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withValidID_AdditionalInfo()
        {
            // Arrange
            Person entry = new Person("_xxx");

            // Act
            int count = entry.RetrieveBasicInformation(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Person First Name X", entry.FirstName);
            Assert.AreEqual("Person Last Name X", entry.LastName);
            Assert.AreEqual("Person First Name X Person Last Name X", entry.Name);
            Assert.AreEqual("Person Name AddOn X", entry.NameAddOn);
            Assert.AreEqual("Person Birth Name X", entry.BirthName);
            Assert.AreEqual("Person Date of Birth X", entry.DateOfBirth);
            Assert.AreEqual("Person Date of Death X", entry.DateOfDeath);
            Assert.AreEqual("Person Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Person Last Updated X", entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withInvalidID_BasicInfoOnly()
        {
            // Arrange
            Person entry = new Person("_aaa");

            // Act
            int count = entry.RetrieveBasicInformation(true);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.FirstName);
            Assert.IsNull(entry.LastName);
            Assert.IsNull(entry.Name);
            Assert.IsNull(entry.NameAddOn);
            Assert.IsNull(entry.BirthName);
            Assert.IsNull(entry.DateOfBirth);
            Assert.IsNull(entry.DateOfDeath);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withInvalidID_AdditionalInfo()
        {
            // Arrange
            Person entry = new Person("_aaa");

            // Act
            int count = entry.RetrieveBasicInformation(false);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.FirstName);
            Assert.IsNull(entry.LastName);
            Assert.IsNull(entry.Name);
            Assert.IsNull(entry.NameAddOn);
            Assert.IsNull(entry.BirthName);
            Assert.IsNull(entry.DateOfBirth);
            Assert.IsNull(entry.DateOfDeath);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withValidID()
        {
            // Arrange
            Person entry = new Person("_xxx");

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withInvalidID()
        {
            // Arrange
            Person entry = new Person("_aaa");

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID_BasicInfoOnly()
        {
            // Arrange
            Person entry = new Person("_xxx");

            // Act
            int count = entry.Retrieve(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Person First Name X", entry.FirstName);
            Assert.AreEqual("Person Last Name X", entry.LastName);
            Assert.AreEqual("Person First Name X Person Last Name X", entry.Name);
            Assert.AreEqual("Person Name AddOn X", entry.NameAddOn);
            Assert.AreEqual("Person Birth Name X", entry.BirthName);
            Assert.AreEqual("Person Date of Birth X", entry.DateOfBirth);
            Assert.AreEqual("Person Date of Death X", entry.DateOfDeath);
            Assert.AreEqual("Person Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Person Last Updated X", entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID_AdditionalInfo()
        {
            // Arrange
            Person entry = new Person("_xxx");

            // Act
            int count = entry.Retrieve(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Person First Name X", entry.FirstName);
            Assert.AreEqual("Person Last Name X", entry.LastName);
            Assert.AreEqual("Person First Name X Person Last Name X", entry.Name);
            Assert.AreEqual("Person Name AddOn X", entry.NameAddOn);
            Assert.AreEqual("Person Birth Name X", entry.BirthName);
            Assert.AreEqual("Person Date of Birth X", entry.DateOfBirth);
            Assert.AreEqual("Person Date of Death X", entry.DateOfDeath);
            Assert.AreEqual("Person Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Person Last Updated X", entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveTest_withInvalidID_BasicInfoOnly()
        {
            // Arrange
            Person entry = new Person("_aaa");

            // Act
            int count = entry.Retrieve(true);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.FirstName);
            Assert.IsNull(entry.LastName);
            Assert.IsNull(entry.Name);
            Assert.IsNull(entry.NameAddOn);
            Assert.IsNull(entry.BirthName);
            Assert.IsNull(entry.DateOfBirth);
            Assert.IsNull(entry.DateOfDeath);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveTest_withInvalidID_AdditionalInfo()
        {
            // Arrange
            Person entry = new Person("_aaa");

            // Act
            int count = entry.Retrieve(false);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.FirstName);
            Assert.IsNull(entry.LastName);
            Assert.IsNull(entry.Name);
            Assert.IsNull(entry.NameAddOn);
            Assert.IsNull(entry.BirthName);
            Assert.IsNull(entry.DateOfBirth);
            Assert.IsNull(entry.DateOfDeath);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }
    }
}
