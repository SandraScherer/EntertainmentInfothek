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


using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntertainmentDB.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntertainmentDB.Data.Tests
{
    [TestClass()]
    public class AspectRatioTests_withDB
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        // obsolete
        [TestMethod()]
        public void AspectRatioTest_checkEntry()
        {
            // Arrange
            AspectRatio entry = new AspectRatio();

            // Act
            // Assert
            Assert.IsNotNull(entry);
        }

        // oblsolete
        [TestMethod()]
        public void AspectRatioTest_checkReader()
        {
            // Arrange
            AspectRatio entry = new AspectRatio();

            // Act
            // Assert
            Assert.IsNotNull(entry.Reader);
        }

        // obsolete
        [TestMethod()]
        public void AspectRatioTest_checkRatio()
        {
            // Arrange
            AspectRatio entry = new AspectRatio();

            // Act
            // Assert
            Assert.IsNull(entry.Ratio);
        }

        // obsolete
        [TestMethod()]
        public void AspectRatioTest_checkDetails()
        {
            // Arrange
            AspectRatio entry = new AspectRatio();

            // Act
            // Assert
            Assert.IsNull(entry.Details);
        }

        // obsolete
        [TestMethod()]
        public void AspectRatioTest_checkStatus()
        {
            // Arrange
            AspectRatio entry = new AspectRatio();

            // Act
            // Assert
            Assert.IsNull(entry.Status);
        }

        // obsolete
        [TestMethod()]
        public void AspectRatioTest_checkLastUpdated()
        {
            // Arrange
            AspectRatio entry = new AspectRatio();

            // Act
            // Assert
            Assert.IsNull(entry.LastUpdated);
        }

        // obsolete
        [TestMethod()]
        public void AspectRatioTest_withoutID_checkID()
        {
            // Arrange
            AspectRatio entry = new AspectRatio();

            // Act
            // Assert
            Assert.AreEqual("", entry.ID);
        }

        // obsolete
        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void AspectRatioTest_withID_checkID(string value)
        {
            // Arrange
            AspectRatio entry = new AspectRatio(value);

            // Act
            // Assert
            Assert.AreEqual(value, entry.ID);
        }

        // obsolete
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AspectRatioTest_withIDnull_checkException()
        {
            // Arrange, Act, Assert
            AspectRatio entry = new AspectRatio(null);
        }

        // TODO: delete
        [TestMethod()]
        public void RetrieveBasicInformationTest_withValidID_BasicInfoOnly()
        {
            // Arrange
            AspectRatio entry = new AspectRatio(VALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("AspectRatio Ratio X", entry.Ratio);
            Assert.AreEqual("AspectRatio Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("AspectRatio LastUpdated X", entry.LastUpdated);
        }

        // TODO: delete
        [TestMethod()]
        public void RetrieveBasicInformationTest_withValidID_AdditionalInfo()
        {
            // Arrange
            AspectRatio entry = new AspectRatio(VALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("AspectRatio Ratio X", entry.Ratio);
            Assert.AreEqual("AspectRatio Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("AspectRatio LastUpdated X", entry.LastUpdated);
        }

        // TODO: delete
        [TestMethod()]
        public void RetrieveBasicInformationTest_withInvalidID_BasicInfoOnly()
        {
            // Arrange
            AspectRatio entry = new AspectRatio(INVALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(true);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, entry.ID);
            Assert.IsNull(entry.Ratio);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        // TODO: delete
        [TestMethod()]
        public void RetrieveBasicInformationTest_withInvalidID_AdditionalInfo()
        {
            // Arrange
            AspectRatio entry = new AspectRatio(INVALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(false);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, entry.ID);
            Assert.IsNull(entry.Ratio);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        // TODO: delete
        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void RetrieveAdditionalInformationTest(string value)
        {
            // Arrange
            AspectRatio entry = new AspectRatio(value);

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkCount(bool value)
        {
            // Arrange
            AspectRatio entry = new AspectRatio(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual(1, count);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkID(bool value)
        {
            // Arrange
            AspectRatio entry = new AspectRatio(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("_xxx", entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkRatio(bool value)
        {
            // Arrange
            AspectRatio entry = new AspectRatio(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("AspectRatio Ratio X", entry.Ratio);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkDetails(bool value)
        {
            // Arrange
            AspectRatio entry = new AspectRatio(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("AspectRatio Details X", entry.Details);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkStatus(bool value)
        {
            // Arrange
            AspectRatio entry = new AspectRatio(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("_xxx", entry.Status.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkLastUpdated(bool value)
        {
            // Arrange
            AspectRatio entry = new AspectRatio(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("AspectRatio LastUpdated X", entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkCount(bool value)
        {
            // Arrange
            AspectRatio entry = new AspectRatio(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual(0, count);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkID(bool value)
        {
            // Arrange
            AspectRatio entry = new AspectRatio(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual(INVALID_ID, entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkRatio(bool value)
        {
            // Arrange
            AspectRatio entry = new AspectRatio(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Ratio);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkDetails(bool value)
        {
            // Arrange
            AspectRatio entry = new AspectRatio(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Details);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkStatus(bool value)
        {
            // Arrange
            AspectRatio entry = new AspectRatio(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.Status);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkLastUpdated(bool value)
        {
            // Arrange
            AspectRatio entry = new AspectRatio(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.LastUpdated);
        }
    }
}
