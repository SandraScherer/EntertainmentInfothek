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
    public class TextItemTests_WithDB
    {
        const string VALID_ID = "_xx1";
        const string INVALID_ID = "_aa1";

        [TestMethod()]
        public void TextItemTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TextItem item = new TextItem(reader);

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.IsNull(item.Text);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void TextItemTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TextItem item = new TextItem(reader, id, "BaseTable", "TargetTable");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("BaseTable", item.BaseTableName);
            Assert.AreEqual("TargetTable", item.TargetTableName);

            Assert.AreEqual(id, item.ID);
            Assert.IsNull(item.Text);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void TextItemTest_withReaderNull(string id)
        {
            // Arrange
            TextItem item;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => item = new TextItem(null, id, "BaseTable", "TargetTable"));
        }

        [TestMethod()]
        public void TextItemTest_withIDNull()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TextItem item;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => item = new TextItem(reader, null, "BaseTable", "TargetTable"));
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void TextItemTest_withBaseTableNameNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TextItem item;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => item = new TextItem(reader, id, null, "TargetTable"));
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void TextItemTest_withTargetTableNameNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TextItem item;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => item = new TextItem(reader, id, "BaseTable", null));
        }

        [DataTestMethod()]
        [DataRow("Movie", "Description", true)]
        [DataRow("Movie", "Description", false)]
        [DataRow("Movie", "Review", true)]
        [DataRow("Movie", "Review", false)]
        public void RetrieveTest_withValidID(string baseTableName, string targetTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TextItem item = new TextItem(reader, VALID_ID, baseTableName, targetTableName);

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, item.ID);
            Assert.AreEqual("_xxx", item.Text.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "Description", true)]
        [DataRow("Movie", "Description", false)]
        [DataRow("Movie", "Review", true)]
        [DataRow("Movie", "Review", false)]
        public void RetrieveTest_withInvalidID(string baseTableName, string targetTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TextItem item = new TextItem(reader, INVALID_ID, baseTableName, targetTableName);

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, item.ID);
            Assert.IsNull(item.Text);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "Description")]
        [DataRow("Movie", "Review")]
        public void RetrieveListTest_withValidData(string baseTableName, string targetTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();

            // Act
            List<TextItem> list = Data.TextItem.RetrieveList(reader, baseTableName, "_xxx", targetTableName.Replace(" ", ""));

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual("_xxx", list[0].Text.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X1", list[0].LastUpdated);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual("_yyy", list[1].Text.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X2", list[1].LastUpdated);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual("_zzz", list[2].Text.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X3", list[2].LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "Description")]
        [DataRow("Movie", "Review")]
        public void RetrieveListTest_withReaderNull(string baseTableName, string targetTableName)
        {
            // Arrange
            List<TextItem> list;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => list = Data.TextItem.RetrieveList(null, baseTableName, "_xxx", targetTableName.Replace(" ", "")));

        }

        [DataTestMethod()]
        [DataRow("Movie", "Description")]
        [DataRow("Movie", "Review")]
        public void RetrieveListTest_withBaseTableNameNull(string baseTableName, string targetTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<TextItem> list;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => list = Data.TextItem.RetrieveList(reader, null, "_xxx", targetTableName.Replace(" ", "")));
        }

        [DataTestMethod()]
        [DataRow("Movie", "Description")]
        [DataRow("Movie", "Review")]
        public void RetrieveListTest_withBaseTableIDNull(string baseTableName, string targetTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<TextItem> list;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => list = Data.TextItem.RetrieveList(reader, baseTableName, null, targetTableName.Replace(" ", "")));
        }

        [DataTestMethod()]
        [DataRow("Movie", "Description")]
        [DataRow("Movie", "Review")]
        public void RetrieveListTest_withTargetTableNameNull(string baseTableName, string targetTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<TextItem> list;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => list = Data.TextItem.RetrieveList(reader, baseTableName, "_xxx", null));
        }

        [DataTestMethod()]
        [DataRow("Movie", "Description")]
        [DataRow("Movie", "Review")]
        public void RetrieveListTest_withOrderNull(string baseTableName, string targetTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<TextItem> list;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => list = Data.TextItem.RetrieveList(reader, baseTableName, "_xxx", targetTableName.Replace(" ", ""), null));
        }
    }
}
