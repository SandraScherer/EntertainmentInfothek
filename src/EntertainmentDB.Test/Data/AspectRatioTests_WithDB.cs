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
    public class AspectRatioTests_WithDB
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        [TestMethod()]
        public void AspectRatioTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            AspectRatio entry = new AspectRatio(reader);

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.AreEqual(reader, entry.Reader);

            Assert.AreEqual("", entry.ID);
            Assert.IsNull(entry.Ratio);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void AspectRatioTest_withID(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            AspectRatio entry = new AspectRatio(reader, id);

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.AreEqual(reader, entry.Reader);

            Assert.AreEqual(id, entry.ID);
            Assert.IsNull(entry.Ratio);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AspectRatioTest_withReaderNull(string id)
        {
            // Arrange, Act, Assert
            AspectRatio entry = new AspectRatio(null, id);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AspectRatioTest_withIDNull()
        {
            // Arrange, Act, Assert
            DBReader reader = new SQLiteReader();
            AspectRatio entry = new AspectRatio(reader, null);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withValidID(bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            AspectRatio entry = new AspectRatio(reader, VALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, entry.ID);
            Assert.AreEqual("AspectRatio Ratio X", entry.Ratio);
            Assert.AreEqual("AspectRatio Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("AspectRatio LastUpdated X", entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withInvalidID(bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            AspectRatio entry = new AspectRatio(reader, INVALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, entry.ID);
            Assert.IsNull(entry.Ratio);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void RetrieveAdditionalInformationTest(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            AspectRatio entry = new AspectRatio(reader, id);

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID(bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            AspectRatio entry = new AspectRatio(reader, VALID_ID);

            // Act
            int count = entry.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual(VALID_ID, entry.ID);
            Assert.AreEqual("AspectRatio Ratio X", entry.Ratio);
            Assert.AreEqual("AspectRatio Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("AspectRatio LastUpdated X", entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID(bool basicInfoOnly)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            AspectRatio entry = new AspectRatio(reader, INVALID_ID);

            // Act
            int count = entry.Retrieve(basicInfoOnly);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, entry.ID);
            Assert.IsNull(entry.Ratio);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }
    }
}
