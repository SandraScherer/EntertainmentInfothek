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


using EntertainmentDB.DBAccess.Read;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EntertainmentDB.Data.Tests
{
    [TestClass()]
    public class PersonTests_WithDB
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        [TestMethod()]
        public void PersonTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Person entry = new Person(reader);

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.AreEqual(reader, entry.Reader);

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

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void PersonTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Person entry = new Person(reader, id);

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.AreEqual(reader, entry.Reader);

            Assert.AreEqual(id, entry.ID);
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

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void PersonTest_withReaderNull(string id)
        {
            // Arrange
            Person entry;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => entry = new Person(null, id));
        }

        [TestMethod()]
        public void PersonTest_withIDNull()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Person entry;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => entry = new Person(reader, null));
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID(bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Person entry = new Person(reader, VALID_ID);

            // Act
            int count = entry.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, entry.ID);
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

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID(bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Person entry = new Person(reader, INVALID_ID);

            // Act
            int count = entry.Retrieve(basicInfoOnly);

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
    }
}
