﻿// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
// Copyright (C) 2022 Sandra Scherer

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
    public class FilmFormatItemTests_WithDB
    {
        const string VALID_ID = "_xx1";
        const string INVALID_ID = "_aa1";

        [TestMethod()]
        public void FilmFormatItemTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            FilmFormatItem item = new FilmFormatItem(reader);

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("", item.BaseTableName);
            Assert.AreEqual("", item.TargetTableName);

            Assert.AreEqual("", item.ID);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void FilmFormatItemTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            FilmFormatItem item = new FilmFormatItem(reader, id, "BaseTable", "TargetTable");

            // Act
            // Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(reader, item.Reader);
            Assert.AreEqual("BaseTable", item.BaseTableName);
            Assert.AreEqual("TargetTable", item.TargetTableName);

            Assert.AreEqual(id, item.ID);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilmFormatItemTest_withReaderNull(string id)
        {
            // Arrange, Act, Assert
            FilmFormatItem item = new FilmFormatItem(null, id, "BaseTable", "TargetTable");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilmFormatItemTest_withIDNull()
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            FilmFormatItem item = new FilmFormatItem(reader, null, "BaseTable", "TargetTable");
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilmFormatItemTest_withBaseTableNameNull(string id)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            FilmFormatItem item = new FilmFormatItem(reader, id, null, "TargetTable");
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilmFormatItemTest_withTargetTableNameNull(string id)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            FilmFormatItem item = new FilmFormatItem(reader, id, "BaseTable", null);
        }

        [DataTestMethod()]
        [DataRow("Movie", "NegativeFormat", true)]
        [DataRow("Movie", "NegativeFormat", false)]
        [DataRow("Movie", "PrintedFilmFormat", true)]
        [DataRow("Movie", "PrintedFilmFormat", false)]
        [DataRow("Series", "NegativeFormat", true)]
        [DataRow("Series", "NegativeFormat", false)]
        [DataRow("Series", "PrintedFilmFormat", true)]
        [DataRow("Series", "PrintedFilmFormat", false)]
        public void RetrieveTest_withValidID(string baseTableName, string targetTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            FilmFormatItem item = new FilmFormatItem(reader, VALID_ID, baseTableName, targetTableName);

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, item.ID);
            Assert.AreEqual("_xxx", item.FilmFormat.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X1", item.Details);
            Assert.AreEqual("_xxx", item.Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X1", item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "NegativeFormat", true)]
        [DataRow("Movie", "NegativeFormat", false)]
        [DataRow("Movie", "PrintedFilmFormat", true)]
        [DataRow("Movie", "PrintedFilmFormat", false)]
        [DataRow("Series", "NegativeFormat", true)]
        [DataRow("Series", "NegativeFormat", false)]
        [DataRow("Series", "PrintedFilmFormat", true)]
        [DataRow("Series", "PrintedFilmFormat", false)]
        public void RetrieveTest_withInvalidID(string baseTableName, string targetTableName, bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            FilmFormatItem item = new FilmFormatItem(reader, INVALID_ID, baseTableName, targetTableName);

            // Act
            int count = item.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, item.ID);
            Assert.IsNull(item.Details);
            Assert.IsNull(item.Status);
            Assert.IsNull(item.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "NegativeFormat")]
        [DataRow("Movie", "PrintedFilmFormat")]
        [DataRow("Series", "NegativeFormat")]
        [DataRow("Series", "PrintedFilmFormat")]
        public void RetrieveListTest_withValidData(string baseTableName, string targetTableName)
        {
            // Arrange
            DBReader reader = new SQLiteReader();

            // Act
            List<FilmFormatItem> list = Data.FilmFormatItem.RetrieveList(reader, baseTableName, "_xxx", targetTableName);

            // Assert
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual("_xx1", list[0].ID);
            Assert.AreEqual("_xxx", list[0].FilmFormat.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X1", list[0].Details);
            Assert.AreEqual("_xxx", list[0].Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X1", list[0].LastUpdated);

            Assert.AreEqual("_xx2", list[1].ID);
            Assert.AreEqual("_yyy", list[1].FilmFormat.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X2", list[1].Details);
            Assert.AreEqual("_xxx", list[1].Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X2", list[1].LastUpdated);

            Assert.AreEqual("_xx3", list[2].ID);
            Assert.AreEqual("_zzz", list[2].FilmFormat.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} Details X3", list[2].Details);
            Assert.AreEqual("_xxx", list[2].Status.ID);
            Assert.AreEqual($"{baseTableName} {targetTableName} LastUpdated X3", list[2].LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie", "NegativeFormat")]
        [DataRow("Movie", "PrintedFilmFormat")]
        [DataRow("Series", "NegativeFormat")]
        [DataRow("Series", "PrintedFilmFormat")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RetrieveListTest_withReaderNull(string baseTableName, string targetTableName)
        {
            // Arrange, Act, Assert
            List<FilmFormatItem> list = Data.FilmFormatItem.RetrieveList(null, baseTableName, "_xxx", targetTableName);

        }

        [DataTestMethod()]
        [DataRow("Movie", "NegativeFormat")]
        [DataRow("Movie", "PrintedFilmFormat")]
        [DataRow("Series", "NegativeFormat")]
        [DataRow("Series", "PrintedFilmFormat")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RetrieveListTest_withBaseTableNameNull(string baseTableName, string targetTableName)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            List<FilmFormatItem> list = Data.FilmFormatItem.RetrieveList(reader, null, "_xxx", targetTableName);
        }

        [DataTestMethod()]
        [DataRow("Movie", "NegativeFormat")]
        [DataRow("Movie", "PrintedFilmFormat")]
        [DataRow("Series", "NegativeFormat")]
        [DataRow("Series", "PrintedFilmFormat")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RetrieveListTest_withBaseTableIDNull(string baseTableName, string targetTableName)
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            List<FilmFormatItem> list = Data.FilmFormatItem.RetrieveList(reader, baseTableName, null, targetTableName);
        }

        [DataTestMethod()]
        [DataRow("Movie", "NegativeFormat")]
        [DataRow("Movie", "PrintedFilmFormat")]
        [DataRow("Series", "NegativeFormat")]
        [DataRow("Series", "PrintedFilmFormat")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RetrieveListTest_withTargetTableNameNull(string baseTableName, string targetTableName)
        {
            DBReader reader = new SQLiteReader();
            List<FilmFormatItem> list = Data.FilmFormatItem.RetrieveList(reader, baseTableName, "_xxx", null);
        }

        [DataTestMethod()]
        [DataRow("Movie", "NegativeFormat")]
        [DataRow("Movie", "PrintedFilmFormat")]
        [DataRow("Series", "NegativeFormat")]
        [DataRow("Series", "PrintedFilmFormat")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RetrieveListTest_withOrderNull(string baseTableName, string targetTableName)
        {
            DBReader reader = new SQLiteReader();
            List<FilmFormatItem> list = Data.FilmFormatItem.RetrieveList(reader, baseTableName, "_xxx", targetTableName, null);
        }
    }
}
