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
    public class ConnectionTests_withDB
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        // oblsolete
        [TestMethod()]
        public void ConnectionTest_checkEntry()
        {
            // Arrange
            Connection entry = new Connection();

            // Act
            // Assert
            Assert.IsNotNull(entry);
        }

        // oblsolete
        [TestMethod()]
        public void ConnectionTest_checkReader()
        {
            // Arrange
            Connection entry = new Connection();

            // Act
            // Assert
            Assert.IsNotNull(entry.Reader);
        }

        // oblsolete
        [TestMethod()]
        public void ConnectionTest_checkTitle()
        {
            // Arrange
            Connection entry = new Connection();

            // Act
            // Assert
            Assert.IsNull(entry.Title);
        }

        // oblsolete
        [TestMethod()]
        public void ConnectionTest_checkBaseConnection()
        {
            // Arrange
            Connection entry = new Connection();

            // Act
            // Assert
            Assert.IsNull(entry.BaseConnection);
        }

        // oblsolete
        [TestMethod()]
        public void ConnectionTest_checkDetails()
        {
            // Arrange
            Connection entry = new Connection();

            // Act
            // Assert
            Assert.IsNull(entry.Details);
        }

        // oblsolete
        [TestMethod()]
        public void ConnectionTest_checkStatus()
        {
            // Arrange
            Connection entry = new Connection();

            // Act
            // Assert
            Assert.IsNull(entry.Status);
        }

        // oblsolete
        [TestMethod()]
        public void ConnectionTest_checkLastUpdated()
        {
            // Arrange
            Connection entry = new Connection();

            // Act
            // Assert
            Assert.IsNull(entry.LastUpdated);
        }

        // oblsolete
        [TestMethod()]
        public void ConnectionTest_withoutID_checkID()
        {
            // Arrange
            Connection entry = new Connection();

            // Act
            // Assert
            Assert.AreEqual("", entry.ID);
        }

        // oblsolete
        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void ConnectionTest_withID_checkID(string value)
        {
            // Arrange
            Connection entry = new Connection(value);

            // Act
            // Assert
            Assert.AreEqual(value, entry.ID);
        }

        // oblsolete
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompanyTest_withIDnull_checkException()
        {
            // Arrange, Act, Assert
            Connection entry = new Connection(null);
        }

        // TODO: delete
        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withValidID(bool value)
        {
            // Arrange
            Connection entry = new Connection(VALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(value);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Connection Title X", entry.Title);
            Assert.IsNull(entry.BaseConnection);
            Assert.AreEqual("Connection Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Connection LastUpdated X", entry.LastUpdated);
        }

        // TODO: delete
        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withInvalidID(bool value)
        {
            // Arrange
            Connection entry = new Connection(INVALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(value);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, entry.ID);
            Assert.IsNull(entry.Title);
            Assert.IsNull(entry.BaseConnection);
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
            Connection entry = new Connection(value);

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
            Connection entry = new Connection(VALID_ID);

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
            Connection entry = new Connection(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("_xxx", entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkTitle(bool value)
        {
            // Arrange
            Connection entry = new Connection(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Connection Title X", entry.Title);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkBaseConnection(bool value)
        {
            // Arrange
            Connection entry = new Connection(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.BaseConnection);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkDetails(bool value)
        {
            // Arrange
            Connection entry = new Connection(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Connection Details X", entry.Details);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkStatus(bool value)
        {
            // Arrange
            Connection entry = new Connection(VALID_ID);

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
            Connection entry = new Connection(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Connection LastUpdated X", entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkCount(bool value)
        {
            // Arrange
            Connection entry = new Connection(INVALID_ID);

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
            Connection entry = new Connection(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual(INVALID_ID, entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkTitle(bool value)
        {
            // Arrange
            Connection entry = new Connection(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Title);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkBaseConnection(bool value)
        {
            // Arrange
            Connection entry = new Connection(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.BaseConnection);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkDetails(bool value)
        {
            // Arrange
            Connection entry = new Connection(INVALID_ID);

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
            Connection entry = new Connection(INVALID_ID);

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
            Connection entry = new Connection(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.LastUpdated);
        }
    }
}
