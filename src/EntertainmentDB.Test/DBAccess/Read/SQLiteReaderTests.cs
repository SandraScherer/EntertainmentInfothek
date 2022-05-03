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


using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntertainmentDB.DBAccess.Read;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntertainmentDB.DBAccess.Read.Tests
{
    [TestClass()]
    public class SQLiteReaderTests
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        [TestMethod()]
        public void SQLiteReaderTest()
        {
            // Arrange
            SQLiteReader reader = new SQLiteReader();

            // Act
            // Assert
            Assert.IsNotNull(reader);
            Assert.AreEqual("", reader.Query);
            Assert.IsNotNull(reader.Table);
        }

        [TestMethod()]
        public void NewTest()
        {
            // Arrange
            SQLiteReader reader = new SQLiteReader();

            // Act
            DBReader newReader = reader.New();

            // Assert
            Assert.IsNotNull((SQLiteReader) newReader);
            Assert.IsNotNull(newReader);
            Assert.AreEqual("", newReader.Query);
            Assert.IsNotNull(newReader.Table);
        }

        [DataTestMethod()]
        [DataRow("Movie", true)]
        [DataRow("Movie", false)]
        [DataRow("Series", true)]
        [DataRow("Series", false)]
        public void RetrieveTest_withValidID(string tableName, bool basicInfoOnly)
        {
            // Arrange
            SQLiteReader reader = new SQLiteReader();
            reader.Query = $"SELECT ID FROM {tableName} WHERE ID LIKE \"{VALID_ID}\"";

            // Act
            reader.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, reader.Table.Columns.Count);
            Assert.AreEqual(1, reader.Table.Rows.Count);
        }

        [DataTestMethod()]
        [DataRow("Movie", true)]
        [DataRow("Movie", false)]
        [DataRow("Series", true)]
        [DataRow("Series", false)]
        public void RetrieveTest_withInvalidID(string tableName, bool basicInfoOnly)
        {
            // Arrange
            SQLiteReader reader = new SQLiteReader();
            reader.Query = $"SELECT ID FROM {tableName} WHERE ID LIKE \"{INVALID_ID}\"";

            // Act
            reader.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, reader.Table.Columns.Count);
            Assert.AreEqual(0, reader.Table.Rows.Count);
        }
    }
}
