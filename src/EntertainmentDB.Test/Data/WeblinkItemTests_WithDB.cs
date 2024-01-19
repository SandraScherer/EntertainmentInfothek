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
    public class WeblinkItemTests_WithDB
    {
        const string VALID_ID = "_xx1";
        const string INVALID_ID = "_aa1";

        [TestMethod()]
        public void WeblinkItemTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            WeblinkItem item = new WeblinkItem(reader);

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.IsNull(item.Weblink);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void WeblinkItemTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            WeblinkItem item = new WeblinkItem(reader, id, "BaseTable", "TargetTable");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("BaseTable", item.BaseTableName);
            Assert.AreEqual("TargetTable", item.TargetTableName);

            Assert.AreEqual(id, item.ID);
            Assert.IsNull(item.Weblink);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WeblinkItemTest_withReaderNull(string id)
        {
            // Arrange, Act, Assert
            WeblinkItem item = new WeblinkItem(null, id, "BaseTable", "TargetTable");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WeblinkItemTest_withIDNull()
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            WeblinkItem item = new WeblinkItem(reader, null, "BaseTable", "TargetTable");
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WeblinkItemTest_withBaseTableNameNull(string id)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            WeblinkItem item = new WeblinkItem(reader, id, null, "TargetTable");
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WeblinkItemTest_withTargetTableNameNull(string id)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            WeblinkItem item = new WeblinkItem(reader, id, "BaseTable", null);
        }

        [DataTestMethod()]
        [DataRow("Movie", true)]
        [DataRow("Movie", false)]
        public void RetrieveTest_withValidID(string baseTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            WeblinkItem item = new WeblinkItem(reader, VALID_ID, baseTableName, "Weblink");

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, item.ID);
            Assert.AreEqual("_xxx", item.Weblink.ID);
            Assert.AreEqual($"{baseTableName} Weblink Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{baseTableName} Weblink LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", true)]
        [DataRow("Movie", false)]
        public void RetrieveTest_withInvalidID(string baseTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            WeblinkItem item = new WeblinkItem(reader, INVALID_ID, baseTableName, "Weblink");

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, item.ID);
            Assert.IsNull(item.Weblink);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveListTest_withValidData(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();

            // Act
            List<WeblinkItem> list = Data.WeblinkItem.RetrieveList(reader, baseTableName, "_xxx", "Weblink");

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual("_xxx", list[0].Weblink.ID);
            Assert.AreEqual($"{baseTableName} Weblink Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{baseTableName} Weblink LastUpdated X1", list[0].LastUpdated);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual("_yyy", list[1].Weblink.ID);
            Assert.AreEqual($"{baseTableName} Weblink Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{baseTableName} Weblink LastUpdated X2", list[1].LastUpdated);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual("_zzz", list[2].Weblink.ID);
            Assert.AreEqual($"{baseTableName} Weblink Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{baseTableName} Weblink LastUpdated X3", list[2].LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RetrieveListTest_withReaderNull(string baseTableName)
        {
            // Arrange, Act, Assert
            List<WeblinkItem> list = Data.WeblinkItem.RetrieveList(null, baseTableName, "_xxx", "Weblink");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RetrieveListTest_withBaseTableNameNull()
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            List<WeblinkItem> list = Data.WeblinkItem.RetrieveList(reader, null, "_xxx", "Weblink");
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RetrieveListTest_withBaseTableIDNull(string baseTableName)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            List<WeblinkItem> list = Data.WeblinkItem.RetrieveList(reader, baseTableName, null, "Weblink");
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RetrieveListTest_withTargetTableNameNull(string baseTableName)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            List<WeblinkItem> list = Data.WeblinkItem.RetrieveList(reader, baseTableName, "_xxx", null);
        }
    }
}
