// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
// Copyright (C) 2021 Sandra Scherer

// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.


using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntertainmentDB.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntertainmentDB.Data.Tests
{
    [TestClass()]
    public class PersonTests_withDB
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        // oblsolete
        [TestMethod()]
        public void PersonTest_checkEntry()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNotNull(entry);
        }

        // oblsolete
        [TestMethod()]
        public void PersonTest_checkReader()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNotNull(entry.Reader);
        }

        // oblsolete
        [TestMethod()]
        public void PersonTest_checkFirstName()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.FirstName);
        }

        // oblsolete
        [TestMethod()]
        public void PersonTest_checkLastName()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.LastName);
        }

        // oblsolete
        [TestMethod()]
        public void PersonTest_checkName()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.Name);
        }

        // oblsolete
        [TestMethod()]
        public void PersonTest_checkNameAddOn()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.NameAddOn);
        }

        // oblsolete
        [TestMethod()]
        public void PersonTest_checkBirthName()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.BirthName);
        }

        // oblsolete
        [TestMethod()]
        public void PersonTest_checkDateOfBirth()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.DateOfBirth);
        }

        // oblsolete
        [TestMethod()]
        public void PersonTest_checkDateOfDeath()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.DateOfDeath);
        }

        // oblsolete
        [TestMethod()]
        public void PersonTest_checkDetails()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.Details);
        }

        // oblsolete
        [TestMethod()]
        public void PersonTest_checkStatus()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.Status);
        }

        // oblsolete
        [TestMethod()]
        public void PersonTest_checkLastUpdated()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.LastUpdated);
        }

        // oblsolete
        [TestMethod()]
        public void PersonTest_withoutID_checkID()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.AreEqual("", entry.ID);
        }

        // oblsolete
        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void PersonTest_withID_checkID(string value)
        {
            // Arrange
            Person entry = new Person(value);

            // Act
            // Assert
            Assert.AreEqual(value, entry.ID);
        }

        // oblsolete
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonTest_withIDnull_checkException()
        {
            // Arrange, Act, Assert
            Person entry = new Person(null);
        }

        // TODO: delete
        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withValidID(bool value)
        {
            // Arrange
            Person entry = new Person(VALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(value);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Person FirstName X", entry.FirstName);
            Assert.AreEqual("Person LastName X", entry.LastName);
            Assert.AreEqual("Person FirstName X Person LastName X", entry.Name);
            Assert.AreEqual("Person NameAddOn X", entry.NameAddOn);
            Assert.AreEqual("Person BirthName X", entry.BirthName);
            Assert.AreEqual("Person DateOfBirth X", entry.DateOfBirth);
            Assert.AreEqual("Person DateOfDeath X", entry.DateOfDeath);
            Assert.AreEqual("Person Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Person LastUpdated X", entry.LastUpdated);
        }

        // TODO: delete
        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withInvalidID(bool value)
        {
            // Arrange
            Person entry = new Person(INVALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(value);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, entry.ID);
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

        // TODO: delete
        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void RetrieveAdditionalInformationTest(string value)
        {
            // Arrange
            Person entry = new Person(value);

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkCount(bool value)
        {
            // Arrange
            Person entry = new Person(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual(1, count);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkID(bool value)
        {
            // Arrange
            Person entry = new Person(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("_xxx", entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkFirstName(bool value)
        {
            // Arrange
            Person entry = new Person(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Person FirstName X", entry.FirstName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkLastName(bool value)
        {
            // Arrange
            Person entry = new Person(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Person LastName X", entry.LastName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkName(bool value)
        {
            // Arrange
            Person entry = new Person(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Person FirstName X Person LastName X", entry.Name);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkNameAddOn(bool value)
        {
            // Arrange
            Person entry = new Person(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Person NameAddOn X", entry.NameAddOn);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkBirthName(bool value)
        {
            // Arrange
            Person entry = new Person(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Person BirthName X", entry.BirthName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkDateOfBirth(bool value)
        {
            // Arrange
            Person entry = new Person(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Person DateOfBirth X", entry.DateOfBirth);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkDateOfDeath(bool value)
        {
            // Arrange
            Person entry = new Person(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Person DateOfDeath X", entry.DateOfDeath);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkDetails(bool value)
        {
            // Arrange
            Person entry = new Person(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Person Details X", entry.Details);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkStatus(bool value)
        {
            // Arrange
            Person entry = new Person(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("_xxx", entry.Status.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkLastUpdated(bool value)
        {
            // Arrange
            Person entry = new Person(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Person LastUpdated X", entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkCount(bool value)
        {
            // Arrange
            Person entry = new Person(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual(0, count);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkID(bool value)
        {
            // Arrange
            Person entry = new Person(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual(INVALID_ID, entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkFirstName(bool value)
        {
            // Arrange
            Person entry = new Person(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.FirstName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkLastName(bool value)
        {
            // Arrange
            Person entry = new Person(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.LastName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkName(bool value)
        {
            // Arrange
            Person entry = new Person(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Name);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkNameAddOn(bool value)
        {
            // Arrange
            Person entry = new Person(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.NameAddOn);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkBirthName(bool value)
        {
            // Arrange
            Person entry = new Person(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.BirthName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkDateOfBirth(bool value)
        {
            // Arrange
            Person entry = new Person(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.DateOfBirth);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkDateOfDeath(bool value)
        {
            // Arrange
            Person entry = new Person(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.DateOfDeath);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkDetails(bool value)
        {
            // Arrange
            Person entry = new Person(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Details);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkStatus(bool value)
        {
            // Arrange
            Person entry = new Person(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Status);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkLastUpdated(bool value)
        {
            // Arrange
            Person entry = new Person(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.LastUpdated);
        }
    }
}
