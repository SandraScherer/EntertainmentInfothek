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


using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntertainmentDB.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntertainmentDB.Data.Tests
{
    [TestClass()]
    public class StatusTests_withDB
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        // obsolete
        [TestMethod()]
        public void StatusTest_checkEntry()
        {
            // Arrange
            Status entry = new Status();

            // Act
            // Assert
            Assert.IsNotNull(entry);
        }

        // obsolete
       [TestMethod()]
        public void StatusTest_checkReader()
        {
            // Arrange
            Status entry = new Status();

            // Act
            // Assert
            Assert.IsNotNull(entry.Reader);
        }

        // obsolete
        [TestMethod()]
        public void StatusTest_checkEnglishTitle()
        {
            // Arrange
            Status entry = new Status();

            // Act
            // Assert
            Assert.IsNull(entry.EnglishTitle);
        }

        // obsolete
        [TestMethod()]
        public void StatusTest_checkGermanTitle()
        {
            // Arrange
            Status entry = new Status();

            // Act
            // Assert
            Assert.IsNull(entry.GermanTitle);
        }

        // obsolete
        [TestMethod()]
        public void StatusTest_checkDetails()
        {
            // Arrange
            Status entry = new Status();

            // Act
            // Assert
            Assert.IsNull(entry.Details);
        }

        // obsolete
        [TestMethod()]
        public void StatusTest_checkStatus()
        {
            // Arrange
            Status entry = new Status();

            // Act
            // Assert
            Assert.IsNull(entry.StatusString);
        }

        // obsolete
        [TestMethod()]
        public void StatusTest_checkLastUpdated()
        {
            // Arrange
            Status entry = new Status();

            // Act
            // Assert
            Assert.IsNull(entry.LastUpdated);
        }

        // obsolete
        [TestMethod()]
        public void StatusTest_withoutID_checkID()
        {
            // Arrange
            Status entry = new Status();

            // Act
            // Assert
            Assert.AreEqual("", entry.ID);
        }

        // obsolete
        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void StatusTest_withID_checkID(string value)
        {
            // Arrange
            Status entry = new Status(value);

            // Act
            // Assert
            Assert.AreEqual(value, entry.ID);
        }

        // obsolete
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StatusTest_withIDnull_checkException()
        {
            // Arrange, Act, Assert
            Status entry = new Status(null);
        }

        // TODO: delete
        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withValidID(bool value)
        {
            // Arrange
            Status entry = new Status(VALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(value);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Status EnglishTitle X", entry.EnglishTitle);
            Assert.AreEqual("Status GermanTitle X", entry.GermanTitle);
            Assert.AreEqual("Status Details X", entry.Details);
            Assert.AreEqual("", entry.StatusString);
            Assert.AreEqual("Status LastUpdated X", entry.LastUpdated);
        }

        // TODO: delete
        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withInvalidID(bool value)
        {
            // Arrange
            Status entry = new Status(INVALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(value);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, entry.ID);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.StatusString);
            Assert.IsNull(entry.LastUpdated);
        }

        // TODO: delete
        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void RetrieveAdditionalInformationTest(string value)
        {
            // Arrange
            Status entry = new Status(value);

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
            Status entry = new Status(VALID_ID);

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
            Status entry = new Status(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("_xxx", entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkEnglishTitle(bool value)
        {
            // Arrange
            Status entry = new Status(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Status EnglishTitle X", entry.EnglishTitle);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkGermanTitle(bool value)
        {
            // Arrange
            Status entry = new Status(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Status GermanTitle X", entry.GermanTitle);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkDetails(bool value)
        {
            // Arrange
            Status entry = new Status(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Status Details X", entry.Details);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkStatus(bool value)
        {
            // Arrange
            Status entry = new Status(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("", entry.StatusString);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkLastUpdated(bool value)
        {
            // Arrange
            Status entry = new Status(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Status LastUpdated X", entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkCount(bool value)
        {
            // Arrange
            Status entry = new Status(INVALID_ID);

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
            Status entry = new Status(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual(INVALID_ID, entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkEnglishTitle(bool value)
        {
            // Arrange
            Status entry = new Status(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.EnglishTitle);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkGermanTitle(bool value)
        {
            // Arrange
            Status entry = new Status(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.GermanTitle);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkDetails(bool value)
        {
            // Arrange
            Status entry = new Status(INVALID_ID);

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
            Status entry = new Status(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.StatusString);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkLastUpdated(bool value)
        {
            // Arrange
            Status entry = new Status(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.LastUpdated);
        }
    }
}
