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
    public class CinematographicProcessItemTests_WithDB
    {
        const string VALID_ID = "_xx1";
        const string INVALID_ID = "_aa1";

        [TestMethod()]
        public void CinematographicProcessItemTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CinematographicProcessItem item = new CinematographicProcessItem(reader);

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.IsNull(item.CinematographicProcess);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CinematographicProcessItemTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CinematographicProcessItem item = new CinematographicProcessItem(reader, id, "BaseTable", "TargetTable");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("BaseTable", item.BaseTableName);
            Assert.AreEqual("TargetTable", item.TargetTableName);

            Assert.AreEqual(id, item.ID);
            Assert.IsNull(item.CinematographicProcess);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CinematographicProcessItemTest_withReaderNull(string id)
        {
            // Arrange
            CinematographicProcessItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new CinematographicProcessItem(null, id, "BaseTable", "TargetTable"));
        }

        [TestMethod()]
        public void CinematographicProcessItemTest_withIDNull()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CinematographicProcessItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new CinematographicProcessItem(reader, null, "BaseTable", "TargetTable"));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CinematographicProcessItemTest_withBaseTableNameNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CinematographicProcessItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new CinematographicProcessItem(reader, id, null, "TargetTable"));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CinematographicProcessItemTest_withTargetTableNameNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CinematographicProcessItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new CinematographicProcessItem(reader, id, "BaseTable", null));
        }

        [TestMethod()]
        [DataRow("Movie", true)]
        [DataRow("Movie", false)]
        [DataRow("Series", true)]
        [DataRow("Series", false)]
        public void RetrieveTest_withValidID(string baseTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CinematographicProcessItem item = new CinematographicProcessItem(reader, VALID_ID, baseTableName, "CinematographicProcess");

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, item.ID);
            Assert.AreEqual("_xxx", item.CinematographicProcess.ID);
            Assert.AreEqual($"{baseTableName} CinematographicProcess Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{baseTableName} CinematographicProcess LastUpdated X1", item.LastUpdated);
        }

        [TestMethod()]
        [DataRow("Movie", true)]
        [DataRow("Movie", false)]
        [DataRow("Series", true)]
        [DataRow("Series", false)]
        public void RetrieveTest_withInvalidID(string baseTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CinematographicProcessItem item = new CinematographicProcessItem(reader, INVALID_ID, baseTableName, "CinematographicProcess");

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, item.ID);
            Assert.IsNull(item.CinematographicProcess);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [TestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        public void RetrieveListTest_withValidData(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();

            // Act
            List<CinematographicProcessItem> list = Data.CinematographicProcessItem.RetrieveList(reader, baseTableName, "_xxx", "CinematographicProcess");

            // Assert
            Assert.HasCount(3, list);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual("_xxx", list[0].CinematographicProcess.ID);
            Assert.AreEqual($"{baseTableName} CinematographicProcess Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{baseTableName} CinematographicProcess LastUpdated X1", list[0].LastUpdated);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual("_yyy", list[1].CinematographicProcess.ID);
            Assert.AreEqual($"{baseTableName} CinematographicProcess Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{baseTableName} CinematographicProcess LastUpdated X2", list[1].LastUpdated);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual("_zzz", list[2].CinematographicProcess.ID);
            Assert.AreEqual($"{baseTableName} CinematographicProcess Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{baseTableName} CinematographicProcess LastUpdated X3", list[2].LastUpdated);
        }

        [TestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        public void RetrieveListTest_withReaderNull(string baseTableName)
        {
            // Arrange
            List<CinematographicProcessItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CinematographicProcessItem.RetrieveList(null, baseTableName, "_xxx", "CinematographicProcess"));
        }

        [TestMethod()]
        public void RetrieveListTest_withBaseTableNameNull()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<CinematographicProcessItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CinematographicProcessItem.RetrieveList(reader, null, "_xxx", "CinematographicProcess"));
        }

        [TestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        public void RetrieveListTest_withBaseTableIDNull(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<CinematographicProcessItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CinematographicProcessItem.RetrieveList(reader, baseTableName, null, "CinematographicProcess"));
        }

        [TestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        public void RetrieveListTest_withTargetTableNameNull(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<CinematographicProcessItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CinematographicProcessItem.RetrieveList(reader, baseTableName, "_xxx", null));
        }

        [TestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        public void RetrieveListTest_withOrderNull(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<CinematographicProcessItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CinematographicProcessItem.RetrieveList(reader, baseTableName, "_xxx", "CinematographicProcess", null));
        }
    }
}
