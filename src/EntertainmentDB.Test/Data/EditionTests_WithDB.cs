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

namespace EntertainmentDB.Data.Tests
{
    [TestClass()]
    public class EditionTests_WithDB
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        [TestMethod()]
        public void EditionTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Edition entry = new Edition(reader);

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.AreEqual(reader, entry.Reader);

            Assert.AreEqual("", entry.ID);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void EditionTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Edition entry = new Edition(reader, id);

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.AreEqual(reader, entry.Reader);

            Assert.AreEqual(id, entry.ID);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void EditionTest_withReaderNull(string id)
        {
            // Arrange
            Edition entry;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => entry = new Edition(null, id));
        }

        [TestMethod()]
        public void EditionTest_withIDNull()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Edition entry;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => entry = new Edition(reader, null));
        }

        [TestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID(bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Edition entry = new Edition(reader, VALID_ID);

            // Act
            int count = entry.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, entry.ID);
            Assert.AreEqual("Edition EnglishTitle X", entry.EnglishTitle);
            Assert.AreEqual("Edition GermanTitle X", entry.GermanTitle);
            Assert.AreEqual("Edition Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Edition LastUpdated X", entry.LastUpdated);
        }

        [TestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID(bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Edition entry = new Edition(reader, INVALID_ID);

            // Act
            int count = entry.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, entry.ID);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }
    }
}
