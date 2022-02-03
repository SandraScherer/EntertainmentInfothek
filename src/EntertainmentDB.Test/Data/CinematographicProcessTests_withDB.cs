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
    public class CinematographicProcessTests_withDB
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        // obsolete
        [TestMethod()]
        public void CinematographicProcessTest_checkEntry()
        {
            // Arrange
            CinematographicProcess entry = new CinematographicProcess();

            // Act
            // Assert
            Assert.IsNotNull(entry);
        }

        // obsolete
        [TestMethod()]
        public void CinematographicProcessTest_checkReader()
        {
            // Arrange
            CinematographicProcess entry = new CinematographicProcess();

            // Act
            // Assert
            Assert.IsNotNull(entry.Reader);
        }

        // obsolete
        [TestMethod()]
        public void CinematographicProcessTest_checkName()
        {
            // Arrange
            CinematographicProcess entry = new CinematographicProcess();

            // Act
            // Assert
            Assert.IsNull(entry.Name);
        }

        // obsolete
        [TestMethod()]
        public void CinematographicProcessTest_checkDetails()
        {
            // Arrange
            CinematographicProcess entry = new CinematographicProcess();

            // Act
            // Assert
            Assert.IsNull(entry.Details);
        }

        // obsolete
        [TestMethod()]
        public void CinematographicProcessTest_checkStatus()
        {
            // Arrange
            CinematographicProcess entry = new CinematographicProcess();

            // Act
            // Assert
            Assert.IsNull(entry.Status);
        }

        // obsolete
        [TestMethod()]
        public void CinematographicProcessTest_checkLastUpdated()
        {
            // Arrange
            CinematographicProcess entry = new CinematographicProcess();

            // Act
            // Assert
            Assert.IsNull(entry.LastUpdated);
        }

        // obsolete
        [TestMethod()]
        public void CinematographicProcessTest_withoutID_checkID()
        {
            // Arrange
            CinematographicProcess entry = new CinematographicProcess();

            // Act
            // Assert
            Assert.AreEqual("", entry.ID);
        }

        // obsolete
        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CinematographicProcessTest_withID_checkID(string value)
        {
            // Arrange
            CinematographicProcess entry = new CinematographicProcess(value);

            // Act
            // Assert
            Assert.AreEqual(value, entry.ID);
        }

        // obsolete
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CinematographicProcessTest_withIDnull_checkException()
        {
            // Arrange, Act, Assert
            CinematographicProcess entry = new CinematographicProcess(null);
        }

        // TODO: delete
        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withValidID(bool value)
        {
            // Arrange
            CinematographicProcess entry = new CinematographicProcess(VALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(value);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("CinematographicProcess Name X", entry.Name);
            Assert.AreEqual("CinematographicProcess Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("CinematographicProcess LastUpdated X", entry.LastUpdated);
        }

        // TODO: delete
        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withInvalidID(bool value)
        {
            // Arrange
            CinematographicProcess entry = new CinematographicProcess(INVALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(value);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, entry.ID);
            Assert.IsNull(entry.Name);
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
            CinematographicProcess entry = new CinematographicProcess(value);

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
            CinematographicProcess entry = new CinematographicProcess(VALID_ID);

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
            CinematographicProcess entry = new CinematographicProcess(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("_xxx", entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkName(bool value)
        {
            // Arrange
            CinematographicProcess entry = new CinematographicProcess(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("CinematographicProcess Name X", entry.Name);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkDetails(bool value)
        {
            // Arrange
            CinematographicProcess entry = new CinematographicProcess(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("CinematographicProcess Details X", entry.Details);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkStatus(bool value)
        {
            // Arrange
            CinematographicProcess entry = new CinematographicProcess(VALID_ID);

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
            CinematographicProcess entry = new CinematographicProcess(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("CinematographicProcess LastUpdated X", entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkCount(bool value)
        {
            // Arrange
            CinematographicProcess entry = new CinematographicProcess(INVALID_ID);

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
            CinematographicProcess entry = new CinematographicProcess(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual(INVALID_ID, entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkName(bool value)
        {
            // Arrange
            CinematographicProcess entry = new CinematographicProcess(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Name);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkDetails(bool value)
        {
            // Arrange
            CinematographicProcess entry = new CinematographicProcess(INVALID_ID);

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
            CinematographicProcess entry = new CinematographicProcess(INVALID_ID);

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
            CinematographicProcess entry = new CinematographicProcess(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.LastUpdated);
        }
    }
}
