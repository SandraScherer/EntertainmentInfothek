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
using Moq;
using EntertainmentDB.DBAccess.Read;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EntertainmentDB.Data.Tests
{
    [TestClass()]
    public class LocationTests
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        [TestMethod()]
        public void LocationTest_checkEntry()
        {
            // Arrange
            Location entry = new Location();

            // Act
            // Assert
            Assert.IsNotNull(entry);
        }

        [TestMethod()]
        public void LocationTest_checkReader()
        {
            // Arrange
            Location entry = new Location();

            // Act
            // Assert
            Assert.IsNotNull(entry.Reader);
        }

        [TestMethod()]
        public void LocationTest_checkName()
        {
            // Arrange
            Location entry = new Location();

            // Act
            // Assert
            Assert.IsNull(entry.Name);
        }

        [TestMethod()]
        public void LocationTest_checkCountry()
        {
            // Arrange
            Location entry = new Location();

            // Act
            // Assert
            Assert.IsNull(entry.Country);
        }

        [TestMethod()]
        public void LocationTest_checkDetails()
        {
            // Arrange
            Location entry = new Location();

            // Act
            // Assert
            Assert.IsNull(entry.Details);
        }

        [TestMethod()]
        public void LocationTest_checkStatus()
        {
            // Arrange
            Location entry = new Location();

            // Act
            // Assert
            Assert.IsNull(entry.Status);
        }

        [TestMethod()]
        public void LocationTest_checkLastUpdated()
        {
            // Arrange
            Location entry = new Location();

            // Act
            // Assert
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void LocationTest_withoutID_checkID()
        {
            // Arrange
            Location entry = new Location();

            // Act
            // Assert
            Assert.AreEqual("", entry.ID);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void LocationTest_withID_checkID(string value)
        {
            // Arrange
            Location entry = new Location(value);

            // Act
            // Assert
            Assert.AreEqual(value, entry.ID);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LocationTest_withIDnull_checkException()
        {
            // Arrange, Act, Assert
            Location entry = new Location(null);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkCount(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Location entry = new Location(VALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Location entry = new Location(VALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Location entry = new Location(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Location X", entry.Name);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkCountry(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Location entry = new Location(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Country);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkDetails(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Location entry = new Location(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Location Details X", entry.Details);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkStatus(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Location entry = new Location(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Status);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkLastUpdated(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Location entry = new Location(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Location LastUpdated X", entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkCount(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Location entry = new Location(INVALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Location entry = new Location(INVALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Location entry = new Location(INVALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Name);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkCountry(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Location entry = new Location(INVALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Country);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkDetails(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Location entry = new Location(INVALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Location entry = new Location(INVALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Location entry = new Location(INVALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.LastUpdated);
        }

        private DataTable CreateDataTableWithMissingData_CountryID_StatusID()
        {
            // DataTable aufbauen...
            DataTable table = new DataTable();
            DataColumn column;
            DataRow row;

            // Create new DataColumn, set DataType, ColumnName and add to DataTable
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ID";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Location";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "CountryID";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Details";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "StatusID";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "LastUpdated";
            table.Columns.Add(column);

            // Create new DataRow object and add to DataTable
            row = table.NewRow();
            row["ID"] = "_xxx";
            row["Location"] = "Location X";
            row["CountryID"] = "";
            row["Details"] = "Location Details X";
            row["StatusID"] = "";
            row["LastUpdated"] = "Location LastUpdated X";
            table.Rows.Add(row);

            return table;
        }
    }
}
