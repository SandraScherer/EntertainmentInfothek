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
using System.Collections.Generic;

namespace EntertainmentDB.Data.Tests
{
    [TestClass()]
    public class TimespanItemTests_WithDB
    {
        const string VALID_ID = "_xx1";
        const string INVALID_ID = "_aa1";

        [TestMethod()]
        public void TimespanItemTest()
        {
            DBReader reader = new SQLiteReader();
            TimespanItem item = new TimespanItem(reader);

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.IsNull(item.StartDate);
            Assert.IsNull(item.EndDate);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void TimespanItemTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TimespanItem item = new TimespanItem(reader, id, "BaseTable", "TargetTable");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("BaseTable", item.BaseTableName);
            Assert.AreEqual("TargetTable", item.TargetTableName);

            Assert.AreEqual(id, item.ID);
            Assert.IsNull(item.StartDate);
            Assert.IsNull(item.EndDate);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimespanItemTest_withReaderNull(string id)
        {
            // Arrange, Act, Assert
            TimespanItem item = new TimespanItem(null, id, "BaseTable", "TargetTable");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimespanItemTest_withIDNull()
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            TimespanItem item = new TimespanItem(reader, null, "BaseTable", "TargetTable");
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimespanItemTest_withBaseTableNameNull(string id)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            TimespanItem item = new TimespanItem(reader, id, null, "TargetTable");
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimespanItemTest_withTargetTableNameNull(string id)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            TimespanItem item = new TimespanItem(reader, id, "BaseTable", null);
        }

        [DataTestMethod()]
        [DataRow("Movie", "FilmingDate", true)]
        [DataRow("Movie", "FilmingDate", false)]
        [DataRow("Movie", "ProductionDate", true)]
        [DataRow("Movie", "ProductionDate", false)]
        public void RetrieveBasicInformationTest_withValidID(string baseTableName, string targetTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TimespanItem item = new TimespanItem(reader, VALID_ID, baseTableName, targetTableName);

            // Act
            int count = item.RetrieveBasicInformation(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, item.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} StartDate X1", item.StartDate);
            Assert.AreEqual($"{baseTableName} {targetTableName} EndDate X1", item.EndDate);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "FilmingDate", true)]
        [DataRow("Movie", "FilmingDate", false)]
        [DataRow("Movie", "ProductionDate", true)]
        [DataRow("Movie", "ProductionDate", false)]
        public void RetrieveBasicInformationTest_withInvalidID(string baseTableName, string targetTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TimespanItem item = new TimespanItem(reader, INVALID_ID, baseTableName, targetTableName);

            // Act
            int count = item.RetrieveBasicInformation(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, item.ID);
            Assert.IsNull(item.StartDate);
            Assert.IsNull(item.EndDate);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "FilmingDate", VALID_ID)]
        [DataRow("Movie", "FilmingDate", INVALID_ID)]
        [DataRow("Movie", "ProductionDate", VALID_ID)]
        [DataRow("Movie", "ProductionDate", INVALID_ID)]
        public void RetrieveAdditionalInformationTest(string baseTableName, string targetTableName, string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TimespanItem item = new TimespanItem(reader, id, baseTableName, targetTableName);

            // Act
            int count = item.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [DataTestMethod()]
        [DataRow("Movie", "FilmingDate", true)]
        [DataRow("Movie", "FilmingDate", false)]
        [DataRow("Movie", "ProductionDate", true)]
        [DataRow("Movie", "ProductionDate", false)]
        public void RetrieveTest_withValidID(string baseTableName, string targetTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TimespanItem item = new TimespanItem(reader, VALID_ID, baseTableName, targetTableName);

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, item.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} StartDate X1", item.StartDate);
            Assert.AreEqual($"{baseTableName} {targetTableName} EndDate X1", item.EndDate);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "FilmingDate", true)]
        [DataRow("Movie", "FilmingDate", false)]
        [DataRow("Movie", "ProductionDate", true)]
        [DataRow("Movie", "ProductionDate", false)]
        public void RetrieveTest_withInvalidID(string baseTableName, string targetTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TimespanItem item = new TimespanItem(reader, INVALID_ID, baseTableName, targetTableName);

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, item.ID);
            Assert.IsNull(item.StartDate);
            Assert.IsNull(item.EndDate);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "FilmingDate")]
        [DataRow("Movie", "ProductionDate")]
        public void RetrieveListTest_withValidData(string baseTableName, string targetTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();

            // Act
            List<TimespanItem> list = Data.TimespanItem.RetrieveList(reader, baseTableName, "_xxx", targetTableName.Replace(" ", ""));

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} StartDate X1", list[0].StartDate);
            Assert.AreEqual($"{baseTableName} {targetTableName} EndDate X1", list[0].EndDate);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X1", list[0].LastUpdated);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} StartDate X2", list[1].StartDate);
            Assert.AreEqual($"{baseTableName} {targetTableName} EndDate X2", list[1].EndDate);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X2", list[1].LastUpdated);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} StartDate X3", list[2].StartDate);
            Assert.AreEqual($"{baseTableName} {targetTableName} EndDate X3", list[2].EndDate);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X3", list[2].LastUpdated);
        }
    }
}
