﻿// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
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
using Moq;
using EntertainmentDB.DBAccess.Read;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EntertainmentDB.Data.Tests
{
    [TestClass()]
    public class CountryTests
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        [TestMethod()]
        public void CountryTest_checkEntry()
        {
            // Arrange
            Country entry = new Country();

            // Act
            // Assert
            Assert.IsNotNull(entry);
        }

        [TestMethod()]
        public void CountryTest_checkReader()
        {
            // Arrange
            Country entry = new Country();

            // Act
            // Assert
            Assert.IsNotNull(entry.Reader);
        }

        [TestMethod()]
        public void CountryTest_checkOriginalShortName()
        {
            // Arrange
            Country entry = new Country();

            // Act
            // Assert
            Assert.IsNull(entry.OriginalShortName);
        }

        [TestMethod()]
        public void CountryTest_checkOriginalFullName()
        {
            // Arrange
            Country entry = new Country();

            // Act
            // Assert
            Assert.IsNull(entry.OriginalFullName);
        }

        [TestMethod()]
        public void CountryTest_checkEnglishShortName()
        {
            // Arrange
            Country entry = new Country();

            // Act
            // Assert
            Assert.IsNull(entry.EnglishShortName);
        }

        [TestMethod()]
        public void CountryTest_checkEnglishFullName()
        {
            // Arrange
            Country entry = new Country();

            // Act
            // Assert
            Assert.IsNull(entry.EnglishFullName);
        }

        [TestMethod()]
        public void CountryTest_checkGermanShortName()
        {
            // Arrange
            Country entry = new Country();

            // Act
            // Assert
            Assert.IsNull(entry.GermanShortName);
        }

        [TestMethod()]
        public void CountryTest_checkGermanFullName()
        {
            // Arrange
            Country entry = new Country();

            // Act
            // Assert
            Assert.IsNull(entry.GermanFullName);
        }

        [TestMethod()]
        public void CountryTest_checkDetails()
        {
            // Arrange
            Country entry = new Country();

            // Act
            // Assert
            Assert.IsNull(entry.Details);
        }

        [TestMethod()]
        public void CountryTest_checkStatus()
        {
            // Arrange
            Country entry = new Country();

            // Act
            // Assert
            Assert.IsNull(entry.Status);
        }

        [TestMethod()]
        public void CountryTest_checkLastUpdated()
        {
            // Arrange
            Country entry = new Country();

            // Act
            // Assert
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void CountryTest_withoutID_checkID()
        {
            // Arrange
            Country entry = new Country();

            // Act
            // Assert
            Assert.AreEqual("", entry.ID);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CountryTest_withID_checkID(string value)
        {
            // Arrange
            Country entry = new Country(value);

            // Act
            // Assert
            Assert.AreEqual(value, entry.ID);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CountryTest_withIDnull_checkException()
        {
            // Arrange, Act, Assert
            Country entry = new Country(null);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkCount(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Country entry = new Country(VALID_ID);
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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Country entry = new Country(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("_xxx", entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkOriginalShortName(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Country entry = new Country(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Country OriginalShortName X", entry.OriginalShortName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkOriginalFullName(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Country entry = new Country(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Country OriginalFullName X", entry.OriginalFullName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkEnglishShortName(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Country entry = new Country(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Country EnglishShortName X", entry.EnglishShortName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkEnglishFullName(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Country entry = new Country(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Country EnglishFullName X", entry.EnglishFullName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkGermanShortName(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Country entry = new Country(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Country GermanShortName X", entry.GermanShortName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkGermanFullName(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Country entry = new Country(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Country GermanFullName X", entry.GermanFullName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkDetails(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Country entry = new Country(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Country Details X", entry.Details);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkStatus(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Country entry = new Country(VALID_ID);
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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Country entry = new Country(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Country LastUpdated X", entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkCount(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Country entry = new Country(INVALID_ID);
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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Country entry = new Country(INVALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual(INVALID_ID, entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkOriginalShortName(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Country entry = new Country(INVALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.OriginalShortName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkOriginalFullName(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Country entry = new Country(INVALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.OriginalFullName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkEnglishShortName(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Country entry = new Country(INVALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.EnglishShortName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkEnglishFullName(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Country entry = new Country(INVALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.EnglishFullName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkGermanShortName(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Country entry = new Country(INVALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.GermanShortName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkGermanFullName(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Country entry = new Country(INVALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.GermanFullName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkDetails(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Country entry = new Country(INVALID_ID);
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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Country entry = new Country(INVALID_ID);
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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Country entry = new Country(INVALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.LastUpdated);
        }

        private DataTable CreateDataTableWithMissingData_StatusID()
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
            column.ColumnName = "OriginalShortName";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "OriginalFullName";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "EnglishShortName";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "EnglishFullName";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "GermanShortName";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "GermanFullName";
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
            row["OriginalShortName"] = "Country OriginalShortName X";
            row["OriginalFullName"] = "Country OriginalFullName X";
            row["EnglishShortName"] = "Country EnglishShortName X";
            row["EnglishFullName"] = "Country EnglishFullName X";
            row["GermanShortName"] = "Country GermanShortName X";
            row["GermanFullName"] = "Country GermanFullName X";
            row["Details"] = "Country Details X";
            row["StatusID"] = "";
            row["LastUpdated"] = "Country LastUpdated X";
            table.Rows.Add(row);

            return table;
        }
    }
}
