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

namespace EntertainmentDB.Data.Tests
{
    [TestClass()]
    public class RuntimeItemTests_WithDB
    {
        const string VALID_ID = "_xx1";
        const string INVALID_ID = "_aa1";

        [TestMethod()]
        public void RuntimeItemTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            RuntimeItem item = new RuntimeItem(reader);

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.AreEqual(0, item.Runtime);
            Assert.IsNull(item.Edition);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void RuntimeItemTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            RuntimeItem item = new RuntimeItem(reader, id, "BaseTable", "TargetTable");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("BaseTable", item.BaseTableName);
            Assert.AreEqual("TargetTable", item.TargetTableName);

            Assert.AreEqual(id, item.ID);
            Assert.AreEqual(0, item.Runtime);
            Assert.IsNull(item.Edition);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void RuntimeItemTest_withReaderNull(string id)
        {
            // Arrange
            RuntimeItem item;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => item = new RuntimeItem(null, id, "BaseTable", "TargetTable"));
        }

        [TestMethod()]
        public void RuntimeItemTest_withIDNull()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            RuntimeItem item;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => item = new RuntimeItem(reader, null, "BaseTable", "TargetTable"));
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void RuntimeItemTest_withBaseTableNameNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            RuntimeItem item;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => item = new RuntimeItem(reader, id, null, "TargetTable"));
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void RuntimeItemTest_withTargetTableNameNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            RuntimeItem item;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => item = new RuntimeItem(reader, id, "BaseTable", null));
        }

        [DataTestMethod()]
        [DataRow("Movie", true)]
        [DataRow("Movie", false)]
        [DataRow("Series", true)]
        [DataRow("Series", false)]
        public void RetrieveTest_withValidID(string baseTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            RuntimeItem item = new RuntimeItem(reader, VALID_ID, baseTableName, "Runtime");

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, item.ID);
            Assert.AreEqual(11, item.Runtime);
            Assert.AreEqual("_xxx", item.Edition.ID);
            Assert.AreEqual($"{baseTableName} Runtime Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{baseTableName} Runtime LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", true)]
        [DataRow("Movie", false)]
        [DataRow("Series", true)]
        [DataRow("Series", false)]
        public void RetrieveTest_withInvalidID(string baseTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            RuntimeItem item = new RuntimeItem(reader, INVALID_ID, baseTableName, "Runtime");

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, item.ID);
            Assert.AreEqual(0, item.Runtime);
            Assert.IsNull(item.Edition);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        public void RetrieveListTest_withValidData(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();

            // Act
            List<RuntimeItem> list = Data.RuntimeItem.RetrieveList(reader, baseTableName, "_xxx", "Runtime");

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual(11, list[0].Runtime);
            Assert.AreEqual("_xxx", list[0].Edition.ID);
            Assert.AreEqual($"{baseTableName} Runtime Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{baseTableName} Runtime LastUpdated X1", list[0].LastUpdated);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual(12, list[1].Runtime);
            Assert.AreEqual("_yyy", list[1].Edition.ID);
            Assert.AreEqual($"{baseTableName} Runtime Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{baseTableName} Runtime LastUpdated X2", list[1].LastUpdated);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual(13, list[2].Runtime);
            Assert.AreEqual("_zzz", list[2].Edition.ID);
            Assert.AreEqual($"{baseTableName} Runtime Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{baseTableName} Runtime LastUpdated X3", list[2].LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        public void RetrieveListTest_withReaderNull(string baseTableName)
        {
            // Arrange
            List<RuntimeItem> list;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => list = Data.RuntimeItem.RetrieveList(null, baseTableName, "_xxx", "Runtime"));
        }

        [TestMethod()]
        public void RetrieveListTest_withBaseTableNameNull()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<RuntimeItem> list;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => list = Data.RuntimeItem.RetrieveList(reader, null, "_xxx", "Runtime"));
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        public void RetrieveListTest_withBaseTableIDNull(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<RuntimeItem> list;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => list = Data.RuntimeItem.RetrieveList(reader, baseTableName, null, "Runtime"));
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        public void RetrieveListTest_withTargetTableNameNull(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<RuntimeItem> list;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => list = Data.RuntimeItem.RetrieveList(reader, baseTableName, "_xxx", null));
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        public void RetrieveListTest_withOrderNull(string baseTableName)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            List<RuntimeItem> list;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => list = Data.RuntimeItem.RetrieveList(reader, baseTableName, "_xxx", "Runtime", null));
        }
    }
}
