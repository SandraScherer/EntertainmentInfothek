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
    public class CastPersonItemTests_WithDB
    {
        const string VALID_ID = "_xx1";
        const string INVALID_ID = "_aa1";

        [TestMethod()]
        public void CastPersonItemTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CastPersonItem item = new CastPersonItem(reader);

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.IsNull(item.Actor);
            Assert.IsNull(item.GermanDubber);
            Assert.IsNull(item.Character);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CastPersonItemTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CastPersonItem item = new CastPersonItem(reader, id, "BaseTable", "TargetTable");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("BaseTable", item.BaseTableName);
            Assert.AreEqual("TargetTable", item.TargetTableName);

            Assert.AreEqual(id, item.ID);
            Assert.IsNull(item.Actor);
            Assert.IsNull(item.GermanDubber);
            Assert.IsNull(item.Character);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CastPersonItemTest_withReaderNull(string id)
        {
            // Arrange
            CastPersonItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new CastPersonItem(null, id, "BaseTable", "TargetTable"));
        }

        [TestMethod()]
        public void CastPersonItemTest_withIDNull()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CastPersonItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new CastPersonItem(reader, null, "BaseTable", "TargetTable"));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CastPersonItemTest_withBaseTableNameNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CastPersonItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new CastPersonItem(reader, id, null, "TargetTable"));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CastPersonItemTest_withTargetTableNameNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CastPersonItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new CastPersonItem(reader, id, "BaseTable", null));
        }

        [TestMethod()]
        [DataRow("Movie", true)]
        [DataRow("Movie", false)]
        public void RetrieveTest_withValidID(string baseTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CastPersonItem item = new CastPersonItem(reader, VALID_ID, baseTableName, "Cast");

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, item.ID);
            Assert.AreEqual("_xxx", item.Actor.ID);
            Assert.AreEqual("_xxx", item.GermanDubber.ID);
            Assert.AreEqual($"{baseTableName} Cast Character X1", item.Role);
            Assert.AreEqual($"{baseTableName} Cast Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{baseTableName} Cast LastUpdated X1", item.LastUpdated);
        }

        [TestMethod()]
        [DataRow("Movie", true)]
        [DataRow("Movie", false)]
        public void RetrieveTest_withInvalidID(string baseTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CastPersonItem item = new CastPersonItem(reader, INVALID_ID, baseTableName, "Cast");

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, item.ID);
            Assert.IsNull(item.Actor);
            Assert.IsNull(item.GermanDubber);
            Assert.IsNull(item.Character);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [TestMethod()]
        [DataRow("Movie")]
        public void RetrieveListTest_withValidData(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();

            // Act
            List<CastPersonItem> list = Data.CastPersonItem.RetrieveList(reader, baseTableName, "_xxx", "Cast");

            // Assert
            Assert.HasCount(3, list);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual("_xxx", list[0].Actor.ID);
            Assert.AreEqual("_xxx", list[0].GermanDubber.ID);
            Assert.AreEqual($"{baseTableName} Cast Character X1", list[0].Character);
            Assert.AreEqual($"{baseTableName} Cast Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{baseTableName} Cast LastUpdated X1", list[0].LastUpdated);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual("_yyy", list[1].Actor.ID);
            Assert.AreEqual("_xxx", list[1].GermanDubber.ID);
            Assert.AreEqual($"{baseTableName} Cast Character X2", list[1].Character);
            Assert.AreEqual($"{baseTableName} Cast Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{baseTableName} Cast LastUpdated X2", list[1].LastUpdated);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual("_zzz", list[2].Actor.ID);
            Assert.AreEqual("_xxx", list[2].GermanDubber.ID);
            Assert.AreEqual($"{baseTableName} Cast Character X3", list[2].Character);
            Assert.AreEqual($"{baseTableName} Cast Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{baseTableName} Cast LastUpdated X3", list[2].LastUpdated);
        }

        [TestMethod()]
        [DataRow("Movie")]
        public void RetrieveListTest_withReaderNull(string baseTableName)
        {
            // Arrange
            List<CastPersonItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CastPersonItem.RetrieveList(null, baseTableName, "_xxx", "Cast"));
        }

        [TestMethod()]
        public void RetrieveListTest_withBaseTableNameNull()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<CastPersonItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CastPersonItem.RetrieveList(reader, null, "_xxx", "Cast"));
        }

        [TestMethod()]
        [DataRow("Movie")]
        public void RetrieveListTest_withBaseTableIDNull(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<CastPersonItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CastPersonItem.RetrieveList(reader, baseTableName, null, "Cast"));
        }

        [TestMethod()]
        [DataRow("Movie")]
        public void RetrieveListTest_withTargetTableNameNull(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<CastPersonItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CastPersonItem.RetrieveList(reader, baseTableName, "_xxx", null));
        }

        [TestMethod()]
        [DataRow("Movie")]
        public void RetrieveListTest_withOrderNull(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<CastPersonItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CastPersonItem.RetrieveList(reader, baseTableName, "_xxx", "Cast", null));
        }
    }
}
