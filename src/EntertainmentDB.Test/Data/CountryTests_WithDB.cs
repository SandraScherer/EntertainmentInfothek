// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
// Copyright (C) 2020 Sandra Scherer

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
    public class CountryTests_WithDB
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        [TestMethod()]
        public void CountryTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Country entry = new Country(reader);

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.AreEqual(reader, entry.Reader);

            Assert.AreEqual("", entry.ID);
            Assert.IsNull(entry.OriginalShortName);
            Assert.IsNull(entry.OriginalFullName);
            Assert.IsNull(entry.EnglishShortName);
            Assert.IsNull(entry.EnglishFullName);
            Assert.IsNull(entry.GermanShortName);
            Assert.IsNull(entry.GermanFullName);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CountryTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Country entry = new Country(reader, id);

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.AreEqual(reader, entry.Reader);

            Assert.AreEqual(id, entry.ID);
            Assert.IsNull(entry.OriginalShortName);
            Assert.IsNull(entry.OriginalFullName);
            Assert.IsNull(entry.EnglishShortName);
            Assert.IsNull(entry.EnglishFullName);
            Assert.IsNull(entry.GermanShortName);
            Assert.IsNull(entry.GermanFullName);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CountryTest_withReaderNull(string id)
        {
            // Arrange, Act, Assert
            Country entry = new Country(null, id);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CountryTest_withIDNull()
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            Country entry = new Country(reader, null);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withValidID(bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Country entry = new Country(reader, VALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, entry.ID);
            Assert.AreEqual("Country OriginalShortName X", entry.OriginalShortName);
            Assert.AreEqual("Country OriginalFullName X", entry.OriginalFullName);
            Assert.AreEqual("Country EnglishShortName X", entry.EnglishShortName);
            Assert.AreEqual("Country EnglishFullName X", entry.EnglishFullName);
            Assert.AreEqual("Country GermanShortName X", entry.GermanShortName);
            Assert.AreEqual("Country GermanFullName X", entry.GermanFullName);
            Assert.AreEqual("Country Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Country LastUpdated X", entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withInvalidID(bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Country entry = new Country(reader, INVALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, entry.ID);
            Assert.IsNull(entry.OriginalShortName);
            Assert.IsNull(entry.OriginalFullName);
            Assert.IsNull(entry.EnglishShortName);
            Assert.IsNull(entry.EnglishFullName);
            Assert.IsNull(entry.GermanShortName);
            Assert.IsNull(entry.GermanFullName);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void RetrieveAdditionalInformationTest(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Country entry = new Country(reader, id);

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID(bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Country entry = new Country(reader, VALID_ID);

            // Act
            int count = entry.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, entry.ID);
            Assert.AreEqual("Country OriginalShortName X", entry.OriginalShortName);
            Assert.AreEqual("Country OriginalFullName X", entry.OriginalFullName);
            Assert.AreEqual("Country EnglishShortName X", entry.EnglishShortName);
            Assert.AreEqual("Country EnglishFullName X", entry.EnglishFullName);
            Assert.AreEqual("Country GermanShortName X", entry.GermanShortName);
            Assert.AreEqual("Country GermanFullName X", entry.GermanFullName);
            Assert.AreEqual("Country Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Country LastUpdated X", entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID(bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Country entry = new Country(reader, INVALID_ID);

            // Act
            int count = entry.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, entry.ID);
            Assert.IsNull(entry.OriginalShortName);
            Assert.IsNull(entry.OriginalFullName);
            Assert.IsNull(entry.EnglishShortName);
            Assert.IsNull(entry.EnglishFullName);
            Assert.IsNull(entry.GermanShortName);
            Assert.IsNull(entry.GermanFullName);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }
    }
}
