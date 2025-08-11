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
    public class CameraItemTests_WithDB
    {
        const string VALID_ID = "_xx1";
        const string INVALID_ID = "_aa1";

        [TestMethod()]
        public void CameraItemTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CameraItem item = new CameraItem(reader);

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.IsNull(item.Camera);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CameraItemTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CameraItem item = new CameraItem(reader, id, "BaseTable", "TargetTable");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("BaseTable", item.BaseTableName);
            Assert.AreEqual("TargetTable", item.TargetTableName);

            Assert.AreEqual(id, item.ID);
            Assert.IsNull(item.Camera);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CameraItemTest_withReaderNull(string id)
        {
            // Arrange
            CameraItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new CameraItem(null, id, "BaseTable", "TargetTable"));
        }

        [TestMethod()]
        public void CameraItemTest_withIDNull()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CameraItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new CameraItem(reader, null, "BaseTable", "TargetTable"));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CameraItemTest_withBaseTableNameNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CameraItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new CameraItem(reader, id, null, "TargetTable"));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CameraItemTest_withTargetTableNameNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CameraItem item;
            
            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new CameraItem(reader, id, "BaseTable", null));
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
            CameraItem item = new CameraItem(reader, VALID_ID, baseTableName, "Camera");

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, item.ID);
            Assert.AreEqual("_xxx", item.Camera.ID);
            Assert.AreEqual($"{baseTableName} Camera Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{baseTableName} Camera LastUpdated X1", item.LastUpdated);
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
            CameraItem item = new CameraItem(reader, INVALID_ID, baseTableName, "Camera");

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, item.ID);
            Assert.IsNull(item.Camera);
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
            List<CameraItem> list = Data.CameraItem.RetrieveList(reader, baseTableName, "_xxx", "Camera");

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual("_xxx", list[0].Camera.ID);
            Assert.AreEqual($"{baseTableName} Camera Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{baseTableName} Camera LastUpdated X1", list[0].LastUpdated);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual("_yyy", list[1].Camera.ID);
            Assert.AreEqual($"{baseTableName} Camera Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{baseTableName} Camera LastUpdated X2", list[1].LastUpdated);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual("_zzz", list[2].Camera.ID);
            Assert.AreEqual($"{baseTableName} Camera Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{baseTableName} Camera LastUpdated X3", list[2].LastUpdated);
        }

        [TestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        public void RetrieveListTest_withReaderNull(string baseTableName)
        {
            // Arrange
            List<CameraItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CameraItem.RetrieveList(null, baseTableName, "_xxx", "Camera"));
        }

        [TestMethod()]
        public void RetrieveListTest_withBaseTableNameNull()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<CameraItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CameraItem.RetrieveList(reader, null, "_xxx", "Camera"));
        }

        [TestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        public void RetrieveListTest_withBaseTableIDNull(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<CameraItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CameraItem.RetrieveList(reader, baseTableName, null, "Camera"));
        }

        [TestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        public void RetrieveListTest_withTargetTableNameNull(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<CameraItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CameraItem.RetrieveList(reader, baseTableName, "_xxx", null));
        }

        [TestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        public void RetrieveListTest_withOrderNull(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<CameraItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.CameraItem.RetrieveList(reader, baseTableName, "_xxx", "Camera", null));
        }
    }
}
