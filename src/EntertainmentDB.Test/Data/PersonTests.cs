﻿// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
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
    public class PersonTests
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        [TestMethod()]
        public void PersonTest_checkEntry()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNotNull(entry);
        }

        [TestMethod()]
        public void PersonTest_checkReader()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNotNull(entry.Reader);
        }

        [TestMethod()]
        public void PersonTest_checkFirstName()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.FirstName);
        }

        [TestMethod()]
        public void PersonTest_checkLastName()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.LastName);
        }

        [TestMethod()]
        public void PersonTest_checkName()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.Name);
        }

        [TestMethod()]
        public void PersonTest_checkNameAddOn()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.NameAddOn);
        }

        [TestMethod()]
        public void PersonTest_checkBirthName()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.BirthName);
        }

        [TestMethod()]
        public void PersonTest_checkDateOfBirth()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.DateOfBirth);
        }

        [TestMethod()]
        public void PersonTest_checkDateOfDeath()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.DateOfDeath);
        }

        [TestMethod()]
        public void PersonTest_checkDetails()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.Details);
        }

        [TestMethod()]
        public void PersonTest_checkStatus()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.Status);
        }

        [TestMethod()]
        public void PersonTest_checkLastUpdated()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void PersonTest_withoutID_checkID()
        {
            // Arrange
            Person entry = new Person();

            // Act
            // Assert
            Assert.AreEqual("", entry.ID);
        }

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

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonTest_withIDnull_checkException()
        {
            // Arrange, Act, Assert
            Person entry = new Person(null);
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

            Person entry = new Person(VALID_ID);
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

            Person entry = new Person(VALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Person entry = new Person(VALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Person entry = new Person(VALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Person entry = new Person(VALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Person entry = new Person(VALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Person entry = new Person(VALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Person entry = new Person(VALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Person entry = new Person(VALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Person entry = new Person(VALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Person entry = new Person(VALID_ID);
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

            Person entry = new Person(VALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Person entry = new Person(INVALID_ID);
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

            Person entry = new Person(INVALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Person entry = new Person(INVALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Person entry = new Person(INVALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Person entry = new Person(INVALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Person entry = new Person(INVALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Person entry = new Person(INVALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Person entry = new Person(INVALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Person entry = new Person(INVALID_ID);
            entry.Reader = mockDBReader.Object;

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
            DataTable table = CreateDataTableWithMissingData_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Person entry = new Person(INVALID_ID);
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

            Person entry = new Person(INVALID_ID);
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

            Person entry = new Person(INVALID_ID);
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
            column.ColumnName = "FirstName";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "LastName";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "NameAddOn";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "BirthName";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "DateOfBirth";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "DateOfDeath";
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
            row["FirstName"] = "Person FirstName X";
            row["LastName"] = "Person LastName X";
            row["NameAddOn"] = "Person NameAddOn X";
            row["BirthName"] = "Person BirthName X";
            row["DateOfBirth"] = "Person DateOfBirth X";
            row["DateOfDeath"] = "Person DateOfDeath X";
            row["Details"] = "Person Details X";
            row["StatusID"] = "";
            row["LastUpdated"] = "Person LastUpdated X";
            table.Rows.Add(row);

            return table;
        }
    }
}
