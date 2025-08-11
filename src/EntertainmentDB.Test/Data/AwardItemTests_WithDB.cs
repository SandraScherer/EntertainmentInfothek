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
using System.Collections.Generic;
using System.Data.SQLite;

namespace EntertainmentDB.Data.Tests
{
    [TestClass()]
    public class AwardItemTests_WithDB
    {
        const string VALID_ID = "_xx1";
        const string INVALID_ID = "_aa1";

        [TestMethod()]
        public void AwardItemTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            AwardItem item = new AwardItem(reader);

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.IsNull(item.Award);
            Assert.IsNull(item.Category);
            Assert.IsNull(item.Date);
            Assert.IsNull(item.Winner);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);

            Assert.IsNull(item.Persons);
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void AwardItemTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            AwardItem item = new AwardItem(reader, id, "BaseTable", "TargetTable");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("BaseTable", item.BaseTableName);
            Assert.AreEqual("TargetTable", item.TargetTableName);

            Assert.AreEqual(id, item.ID);
            Assert.IsNull(item.Award);
            Assert.IsNull(item.Category);
            Assert.IsNull(item.Date);
            Assert.IsNull(item.Winner);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);

            Assert.IsNull(item.Persons);
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void AwardItemTest_withReaderNull(string id)
        {
            // Arrange
            AwardItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new AwardItem(null, id, "BaseTable", "TargetTable"));
        }

        [TestMethod()]
        public void AwardItemTest_withIDNull()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            AwardItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new AwardItem(reader, null, "BaseTable", "TargetTable"));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void AwardItemTest_withBaseTableNameNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            AwardItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new AwardItem(reader, id, null, "TargetTable"));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void AwardItemTest_withTargetTableNameNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            AwardItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new AwardItem(reader, id, "BaseTable", null));
        }

        [TestMethod()]
        [DataRow("Movie")]
        public void RetrieveTest_withValidID_BasicInfoOnly(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            AwardItem item = new AwardItem(reader, VALID_ID, baseTableName, "Award");

            // Act
            int count = item.Retrieve(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, item.ID);
            Assert.AreEqual("_xxx", item.Award.ID);
            Assert.AreEqual($"{baseTableName} Award Category X1", item.Category);
            Assert.AreEqual($"{baseTableName} Award Date X1", item.Date);
            Assert.AreEqual($"1", item.Winner);
            Assert.AreEqual($"{baseTableName} Award Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{baseTableName} Award LastUpdated X1", item.LastUpdated);

            Assert.IsNull(item.Persons);
        }

        [TestMethod()]
        [DataRow("Movie")]
        public void RetrieveTest_withValidID_AdditionalInfo(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            AwardItem item = new AwardItem(reader, VALID_ID, baseTableName, "Award");

            // Act
            int count = item.Retrieve(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, item.ID);
            Assert.AreEqual("_xxx", item.Award.ID);
            Assert.AreEqual($"{baseTableName} Award Category X1", item.Category);
            Assert.AreEqual($"{baseTableName} Award Date X1", item.Date);
            Assert.AreEqual($"1", item.Winner);
            Assert.AreEqual($"{baseTableName} Award Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{baseTableName} Award LastUpdated X1", item.LastUpdated);

            Assert.AreEqual(3, item.Persons.Count);
            Assert.AreEqual("_x11", item.Persons[0].ID);
            Assert.AreEqual("_x12", item.Persons[1].ID);
            Assert.AreEqual("_x13", item.Persons[2].ID);
        }

        [TestMethod()]
        [DataRow("Movie", true)]
        [DataRow("Movie", false)]
        public void RetrieveTest_withInvalidID(string baseTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            AwardItem item = new AwardItem(reader, INVALID_ID, baseTableName, "Award");

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, item.ID);
            Assert.IsNull(item.Award);
            Assert.IsNull(item.Category);
            Assert.IsNull(item.Date);
            Assert.IsNull(item.Winner);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);

            Assert.IsNull(item.Persons);
        }

        [TestMethod()]
        [DataRow("Movie")]
        public void RetrieveListTest_withValidData(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();

            // Act
            List<AwardItem> list = Data.AwardItem.RetrieveList(reader, baseTableName, "_xxx", "Award");

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual("_xxx", list[0].Award.ID);
            Assert.AreEqual($"{baseTableName} Award Category X1", list[0].Category);
            Assert.AreEqual($"{baseTableName} Award Date X1", list[0].Date);
            Assert.AreEqual($"1", list[0].Winner);
            Assert.AreEqual($"{baseTableName} Award Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{baseTableName} Award LastUpdated X1", list[0].LastUpdated);

            Assert.AreEqual(3, list[0].Persons.Count);
            Assert.AreEqual("_x11", list[0].Persons[0].ID);
            Assert.AreEqual("_x12", list[0].Persons[1].ID);
            Assert.AreEqual("_x13", list[0].Persons[2].ID);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual("_yyy", list[1].Award.ID);
            Assert.AreEqual($"{baseTableName} Award Category X2", list[1].Category);
            Assert.AreEqual($"{baseTableName} Award Date X2", list[1].Date);
            Assert.AreEqual($"0", list[1].Winner);
            Assert.AreEqual($"{baseTableName} Award Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{baseTableName} Award LastUpdated X2", list[1].LastUpdated);

            Assert.AreEqual(3, list[1].Persons.Count);
            Assert.AreEqual("_x21", list[1].Persons[0].ID);
            Assert.AreEqual("_x22", list[1].Persons[1].ID);
            Assert.AreEqual("_x23", list[1].Persons[2].ID);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual("_zzz", list[2].Award.ID);
            Assert.AreEqual($"{baseTableName} Award Category X3", list[2].Category);
            Assert.AreEqual($"{baseTableName} Award Date X3", list[2].Date);
            Assert.AreEqual($"0", list[2].Winner);
            Assert.AreEqual($"{baseTableName} Award Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{baseTableName} Award LastUpdated X3", list[2].LastUpdated);

            Assert.AreEqual(3, list[2].Persons.Count);
            Assert.AreEqual("_x31", list[2].Persons[0].ID);
            Assert.AreEqual("_x32", list[2].Persons[1].ID);
            Assert.AreEqual("_x33", list[2].Persons[2].ID);
        }

        [TestMethod()]
        [DataRow("Movie")]
        public void RetrieveListTest_withReaderNull(string baseTableName)
        {
            // Arrange
            List<AwardItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.AwardItem.RetrieveList(null, baseTableName, "_xxx", "Award"));
        }

        [TestMethod()]
        public void RetrieveListTest_withBaseTableNameNull()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<AwardItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.AwardItem.RetrieveList(reader, null, "_xxx", "Award"));
        }

        [TestMethod()]
        [DataRow("Movie")]
        public void RetrieveListTest_withBaseTableIDNull(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<AwardItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.AwardItem.RetrieveList(reader, baseTableName, null, "Award"));
        }

        [TestMethod()]
        [DataRow("Movie")]
        public void RetrieveListTest_withTargetTableNameNull(string baseTableName)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            List<AwardItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.AwardItem.RetrieveList(reader, baseTableName, "_xxx", null));
        }

        [TestMethod()]
        [DataRow("Movie")]
        public void RetrieveListTest_withOrderNull(string baseTableName)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            List<AwardItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.AwardItem.RetrieveList(reader, baseTableName, "_xxx", "Award", null));
        }
    }
}
