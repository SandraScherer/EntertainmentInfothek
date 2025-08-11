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
    public class ImageItemTests_WithDB
    {
        const string VALID_ID = "_xx1";
        const string INVALID_ID = "_aa1";

        [TestMethod()]
        public void ImageItemTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            ImageItem item = new ImageItem(reader);

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.IsNull(item.Image);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void ImageItemTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            ImageItem item = new ImageItem(reader, id, "BaseTable", "TargetTable");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("BaseTable", item.BaseTableName);
            Assert.AreEqual("TargetTable", item.TargetTableName);

            Assert.AreEqual(id, item.ID);
            Assert.IsNull(item.Image);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void ImageItemTest_withReaderNull(string id)
        {
            // Arrange
            ImageItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new ImageItem(null, id, "BaseTable", "TargetTable"));
        }

        [TestMethod()]
        public void ImageItemTest_withIDNull()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            ImageItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new ImageItem(reader, null, "BaseTable", "TargetTable"));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void ImageItemTest_withBaseTableNameNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            ImageItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new ImageItem(reader, id, null, "TargetTable"));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void ImageItemTest_withTargetTableNameNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            ImageItem item;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => item = new ImageItem(reader, id, "BaseTable", null));
        }

        [TestMethod()]
        [DataRow("Movie", true)]
        [DataRow("Movie", false)]
        public void RetrieveTest_withValidID(string baseTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            ImageItem item = new ImageItem(reader, VALID_ID, baseTableName, "Image");

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, item.ID);
            Assert.AreEqual("_xxx", item.Image.ID);
            Assert.AreEqual($"{baseTableName} Image Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{baseTableName} Image LastUpdated X1", item.LastUpdated);
        }

        [TestMethod()]
        [DataRow("Movie", true)]
        [DataRow("Movie", false)]
        public void RetrieveTest_withInvalidID(string baseTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            ImageItem item = new ImageItem(reader, INVALID_ID, baseTableName, "Image");

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, item.ID);
            Assert.IsNull(item.Image);
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
            List<ImageItem> list = Data.ImageItem.RetrieveList(reader, baseTableName, "_xxx", "Image");

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual("_xxx", list[0].Image.ID);
            Assert.AreEqual($"{baseTableName} Image Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{baseTableName} Image LastUpdated X1", list[0].LastUpdated);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual("_yyy", list[1].Image.ID);
            Assert.AreEqual($"{baseTableName} Image Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{baseTableName} Image LastUpdated X2", list[1].LastUpdated);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual("_zzz", list[2].Image.ID);
            Assert.AreEqual($"{baseTableName} Image Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{baseTableName} Image LastUpdated X3", list[2].LastUpdated);
        }

        [TestMethod()]
        [DataRow("Movie")]
        public void RetrieveListTest_withReaderNull(string baseTableName)
        {
            // Arrange
            List<ImageItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.ImageItem.RetrieveList(null, baseTableName, "_xxx", "Image"));
        }

        [TestMethod()]
        public void RetrieveListTest_withBaseTableNameNull()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<ImageItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.ImageItem.RetrieveList(reader, null, "_xxx", "Image"));
        }

        [TestMethod()]
        [DataRow("Movie")]
        public void RetrieveListTest_withBaseTableIDNull(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<ImageItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.ImageItem.RetrieveList(reader, baseTableName, null, "Image"));
        }

        [TestMethod()]
        [DataRow("Movie")]
        public void RetrieveListTest_withTargetTableNameNull(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<ImageItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.ImageItem.RetrieveList(reader, baseTableName, "_xxx", null));
        }

        [TestMethod()]
        [DataRow("Movie")]
        public void RetrieveListTest_withOrderNull(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<ImageItem> list;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => list = Data.ImageItem.RetrieveList(reader, baseTableName, "_xxx", "Image", null));
        }
    }
}
