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
using EntertainmentDB.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntertainmentDB.Data.Tests
{
    [TestClass()]
    public class StatusTests
    {
        [TestMethod()]
        public void StatusTest()
        {
            // Arrange
            Status entry = new Status();

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.IsNotNull(entry.Reader);

            Assert.AreEqual("", entry.ID);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.StatusString);
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void StatusTest_withID()
        {
            // Arrange
            Status entry = new Status("_xxx");

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.IsNotNull(entry.Reader);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.StatusString);
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withValidID()
        {
            // Arrange
            Status entry = new Status("_xxx");

            // Act
            int count = entry.RetrieveBasicInformation();

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Status English Title X", entry.EnglishTitle);
            Assert.AreEqual("Status German Title X", entry.GermanTitle);
            Assert.AreEqual("Status Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.StatusString);
            Assert.AreEqual("Status Last Updated X", entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withInvalidID()
        {
            // Arrange
            Status entry = new Status("_aaa");

            // Act
            int count = entry.RetrieveBasicInformation();

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.StatusString);
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withValidID()
        {
            // Arrange
            Status entry = new Status("_xxx");

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withInvalidID()
        {
            // Arrange
            Status entry = new Status("_aaa");

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID()
        {
            // Arrange
            Status entry = new Status("_xxx");

            // Act
            int count = entry.Retrieve();

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Status English Title X", entry.EnglishTitle);
            Assert.AreEqual("Status German Title X", entry.GermanTitle);
            Assert.AreEqual("Status Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.StatusString);
            Assert.AreEqual("Status Last Updated X", entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveTest_withInvalidID()
        {
            // Arrange
            Status entry = new Status("_aaa");

            // Act
            int count = entry.Retrieve();

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.StatusString);
            Assert.IsNull(entry.LastUpdated);
        }
    }
}
