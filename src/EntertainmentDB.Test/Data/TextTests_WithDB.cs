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
    public class TextTests_WithDB
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        [TestMethod()]
        public void TextTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Text entry = new Text(reader);

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.AreEqual(reader, entry.Reader);

            Assert.AreEqual("", entry.ID);
            Assert.IsNull(entry.Content);
            Assert.IsNull(entry.Language);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Authors);
            Assert.IsNull(entry.Sources);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void TextTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Text entry = new Text(reader, id);

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.AreEqual(reader, entry.Reader);

            Assert.AreEqual(id, entry.ID);
            Assert.IsNull(entry.Content);
            Assert.IsNull(entry.Language);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Authors);
            Assert.IsNull(entry.Sources);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TextTest_withReaderNull(string id)
        {
            // Arrange, Act, Assert
            Text entry = new Text(null, id);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TextTest_withIDNull()
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            Text entry = new Text(reader, null);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withValidID(bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Text entry = new Text(reader, VALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, entry.ID);
            Assert.AreEqual("Text Content X", entry.Content);
            Assert.AreEqual("_xxx", entry.Language.ID);
            Assert.AreEqual("Text Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Text LastUpdated X", entry.LastUpdated);

            Assert.IsNull(entry.Authors);
            Assert.IsNull(entry.Sources);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withInvalidID(bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Text entry = new Text(reader, INVALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, entry.ID);
            Assert.IsNull(entry.Content);
            Assert.IsNull(entry.Language);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Authors);
            Assert.IsNull(entry.Sources);
        }

        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withValidID()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Text entry = new Text(reader, VALID_ID);

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(2 * 3, count);

            Assert.AreEqual(3, entry.Authors.Count);
            Assert.AreEqual("_xx1", entry.Authors[0].ID);
            Assert.AreEqual("_xx2", entry.Authors[1].ID);
            Assert.AreEqual("_xx3", entry.Authors[2].ID);

            Assert.AreEqual(3, entry.Sources.Count);
            Assert.AreEqual("_xx1", entry.Sources[0].ID);
            Assert.AreEqual("_xx2", entry.Sources[1].ID);
            Assert.AreEqual("_xx3", entry.Sources[2].ID);
        }

        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withInvalidID()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Text entry = new Text(reader, INVALID_ID);

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID_BasicInfoOnly()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Text entry = new Text(reader, VALID_ID);

            // Act
            int count = entry.Retrieve(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, entry.ID);
            Assert.AreEqual("Text Content X", entry.Content);
            Assert.AreEqual("_xxx", entry.Language.ID);
            Assert.AreEqual("Text Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Text LastUpdated X", entry.LastUpdated);

            Assert.IsNull(entry.Authors);
            Assert.IsNull(entry.Sources);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID_AdditionalInfo()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Text entry = new Text(reader, VALID_ID);

            // Act
            int count = entry.Retrieve(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, entry.ID);
            Assert.AreEqual("Text Content X", entry.Content);
            Assert.AreEqual("_xxx", entry.Language.ID);
            Assert.AreEqual("Text Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Text LastUpdated X", entry.LastUpdated);

            Assert.AreEqual(3, entry.Authors.Count);
            Assert.AreEqual("_xx1", entry.Authors[0].ID);
            Assert.AreEqual("_xx2", entry.Authors[1].ID);
            Assert.AreEqual("_xx3", entry.Authors[2].ID);

            Assert.AreEqual(3, entry.Sources.Count);
            Assert.AreEqual("_xx1", entry.Sources[0].ID);
            Assert.AreEqual("_xx2", entry.Sources[1].ID);
            Assert.AreEqual("_xx3", entry.Sources[2].ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID(bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Text entry = new Text(reader, INVALID_ID);

            // Act
            int count = entry.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, entry.ID);
            Assert.IsNull(entry.Content);
            Assert.IsNull(entry.Language);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Authors);
            Assert.IsNull(entry.Sources);
        }
    }
}
