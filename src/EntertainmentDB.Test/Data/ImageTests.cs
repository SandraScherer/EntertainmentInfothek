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
    public class ImageTests
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        [TestMethod()]
        public void ImageTest_checkEntry()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNotNull(entry);
        }

        [TestMethod()]
        public void ImageTest_checkReader()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNotNull(entry.Reader);
        }

        [TestMethod()]
        public void ImageTest_checkFileName()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNull(entry.FileName);
        }

        [TestMethod()]
        public void ImageTest_checkDescription()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNull(entry.Description);
        }

        [TestMethod()]
        public void ImageTest_checkType()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNull(entry.Type);
        }

        [TestMethod()]
        public void ImageTest_checkCountry()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNull(entry.Country);
        }

        [TestMethod()]
        public void ImageTest_checkDetails()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNull(entry.Details);
        }

        [TestMethod()]
        public void ImageTest_checkStatus()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNull(entry.Status);
        }

        [TestMethod()]
        public void ImageTest_checkLastUpdated()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void ImageTest_checkSources()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.IsNull(entry.Sources);
        }

        [TestMethod()]
        public void ImageTest_withoutID_checkID()
        {
            // Arrange
            Image entry = new Image();

            // Act
            // Assert
            Assert.AreEqual("", entry.ID);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void ImageTest_withID_checkID(string value)
        {
            // Arrange
            Image entry = new Image(value);

            // Act
            // Assert
            Assert.AreEqual(value, entry.ID);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ImageTest_withIDnull_checkException()
        {
            // Arrange, Act, Assert
            Image entry = new Image(null);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkCount(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Image entry = new Image(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);  // TODO: debuggen und Fehler suchen!

            // Assert
            Assert.AreEqual(1, count);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkID(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Image entry = new Image(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("_xxx", entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkFileName(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Image entry = new Image(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Image FileName X", entry.FileName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkDescription(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Image entry = new Image(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Image Description X", entry.Description);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkType(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Image entry = new Image(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Type);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkCountry(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Image entry = new Image(VALID_ID);
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
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Image entry = new Image(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Image Details X", entry.Details);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkStatus(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Image entry = new Image(VALID_ID);
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
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Image entry = new Image(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Image LastUpdated X", entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkSources(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(1);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(1);
            mockDBReader.SetupGet(x => x.Table).Returns(table);

            Image entry = new Image(VALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Sources);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkCount(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Image entry = new Image(INVALID_ID);
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
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Image entry = new Image(INVALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual(INVALID_ID, entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkFileName(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Image entry = new Image(INVALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.FileName);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkDescription(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Image entry = new Image(INVALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Description);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkType(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Image entry = new Image(INVALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Type);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkCountry(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Image entry = new Image(INVALID_ID);
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
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Image entry = new Image(INVALID_ID);
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
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Image entry = new Image(INVALID_ID);
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
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Image entry = new Image(INVALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkSources(bool value)
        {
            // Arrange
            DataTable table = CreateDataTableWithMissingData_TypeID_CountryID_StatusID();
            Mock<DBReader> mockDBReader = new Mock<DBReader>();

            // Setup Mock
            mockDBReader.Setup(x => x.Retrieve(true)).Returns(0);
            mockDBReader.Setup(x => x.Retrieve(false)).Returns(0);

            Image entry = new Image(INVALID_ID);
            entry.Reader = mockDBReader.Object;

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Sources);
        }
/*
        [TestMethod()]
        public void RetrieveTest_withValidID_AdditionalInfo()
        {
            // Arrange
            Image entry = new Image("_xxx");

            // Act
            int count = entry.Retrieve(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Image FileName X", entry.FileName);
            Assert.AreEqual("Image Description X", entry.Description);
            Assert.AreEqual("_xxx", entry.Type.ID);
            Assert.AreEqual("_xxx", entry.Country.ID);
            Assert.AreEqual("Image Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Image LastUpdated X", entry.LastUpdated);

            Assert.AreEqual(3, entry.Sources.Count);
            Assert.AreEqual("_xx1", entry.Sources[0].ID);
            Assert.AreEqual("_xx2", entry.Sources[1].ID);
            Assert.AreEqual("_xx3", entry.Sources[2].ID);
        }
*/
        private DataTable CreateDataTableWithMissingData_TypeID_CountryID_StatusID()
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
            column.ColumnName = "FileName";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Description";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "TypeID";
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
            row["FileName"] = "Image FileName X";
            row["Description"] = "Image Description X";
            row["TypeID"] = "";
            row["CountryID"] = "";
            row["Details"] = "Image Details X";
            row["StatusID"] = "";
            row["LastUpdated"] = "Image LastUpdated X";
            table.Rows.Add(row);

            return table;
        }
    }
}
