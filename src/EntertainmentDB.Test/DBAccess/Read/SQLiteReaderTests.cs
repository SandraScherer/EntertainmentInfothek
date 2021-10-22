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

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveTest_validID_BasicInfoOnly(string value)
        {
            // Arrange
            SQLiteReader reader = new SQLiteReader();
            reader.Query = $"SELECT ID FROM {value} WHERE ID LIKE \"_xxx\"";

            // Act
            reader.Retrieve(true);

            // Assert
            Assert.AreEqual(1, reader.Table.Columns.Count);
            Assert.AreEqual(1, reader.Table.Rows.Count);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveTest_validID_AdditionalInfo(string value)
        {
            // Arrange
            SQLiteReader reader = new SQLiteReader();
            reader.Query = $"SELECT ID FROM {value} WHERE ID LIKE \"_xxx\"";

            // Act
            reader.Retrieve(false);

            // Assert
            Assert.AreEqual(1, reader.Table.Columns.Count);
            Assert.AreEqual(1, reader.Table.Rows.Count);
        }
    }
}
