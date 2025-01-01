﻿// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
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
    public class FilmLengthItemTests_WithDB
    {
        const string VALID_ID = "_xx1";
        const string INVALID_ID = "_aa1";

        [TestMethod()]
        public void FilmLengthItemTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            FilmLengthItem item = new FilmLengthItem(reader);

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.IsNull(item.Length);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void FilmLengthItemTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            FilmLengthItem item = new FilmLengthItem(reader, id, "BaseTable", "TargetTable");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("BaseTable", item.BaseTableName);
            Assert.AreEqual("TargetTable", item.TargetTableName);

            Assert.AreEqual(id, item.ID);
            Assert.IsNull(item.Length);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void FilmLengthItemTest_withReaderNull(string id)
        {
            // Arrange
            FilmLengthItem item;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => item = new FilmLengthItem(null, id, "BaseTable", "TargetTable"));
        }

        [TestMethod()]
        public void FilmLengthItemTest_withIDNull()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            FilmLengthItem item;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => item = new FilmLengthItem(reader, null, "BaseTable", "TargetTable"));
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void FilmLengthItemTest_withBaseTableNameNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            FilmLengthItem item;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => item = new FilmLengthItem(reader, id, null, "TargetTable"));
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void FilmLengthItemTest_withTargetTableNameNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            FilmLengthItem item;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => item = new FilmLengthItem(reader, id, "BaseTable", null));
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
            FilmLengthItem item = new FilmLengthItem(reader, VALID_ID, baseTableName, "FilmLength");

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, item.ID);
            Assert.AreEqual($"{baseTableName} FilmLength Length X1", item.Length);
            Assert.AreEqual($"{baseTableName} FilmLength Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{baseTableName} FilmLength LastUpdated X1", item.LastUpdated);
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
            FilmLengthItem item = new FilmLengthItem(reader, INVALID_ID, baseTableName, "FilmLength");

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, item.ID);
            Assert.IsNull(item.Length);
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
            List<FilmLengthItem> list = Data.FilmLengthItem.RetrieveList(reader, baseTableName, "_xxx", "FilmLength");

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual($"{baseTableName} FilmLength Length X1", list[0].Length);
            Assert.AreEqual($"{baseTableName} FilmLength Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{baseTableName} FilmLength LastUpdated X1", list[0].LastUpdated);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual($"{baseTableName} FilmLength Length X2", list[1].Length);
            Assert.AreEqual($"{baseTableName} FilmLength Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{baseTableName} FilmLength LastUpdated X2", list[1].LastUpdated);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual($"{baseTableName} FilmLength Length X3", list[2].Length);
            Assert.AreEqual($"{baseTableName} FilmLength Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{baseTableName} FilmLength LastUpdated X3", list[2].LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        public void RetrieveListTest_withReaderNull(string baseTableName)
        {
            // Arrange
            List<FilmLengthItem> list;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => list = Data.FilmLengthItem.RetrieveList(null, baseTableName, "_xxx", "FilmLength"));
        }

        [TestMethod()]
        public void RetrieveListTest_withBaseTableNameNull()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<FilmLengthItem> list;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => list = Data.FilmLengthItem.RetrieveList(reader, null, "_xxx", "FilmLength"));
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        public void RetrieveListTest_withBaseTableIDNull(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<FilmLengthItem> list;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => list = Data.FilmLengthItem.RetrieveList(reader, baseTableName, null, "FilmLength"));
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        public void RetrieveListTest_withTargetTableNameNull(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<FilmLengthItem> list;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => list = Data.FilmLengthItem.RetrieveList(reader, baseTableName, "_xxx", null));
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        [DataRow("Series")]
        public void RetrieveListTest_withOrderNull(string baseTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            List<FilmLengthItem> list;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => list = Data.FilmLengthItem.RetrieveList(reader, baseTableName, "_xxx", "FilmLength", null));
        }
    }
}
