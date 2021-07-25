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
    public class CountryTests
    {
        [TestMethod()]
        public void CountryTest()
        {
            // Arrange
            Country entry = new Country();

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.IsNotNull(entry.Reader);

            Assert.AreEqual("", entry.ID);
            Assert.IsNull(entry.OriginalName);
            Assert.IsNull(entry.EnglishName);
            Assert.IsNull(entry.GermanName);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void CountryTest_withID()
        {
            // Arrange
            Country entry = new Country("_xxx");

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.IsNotNull(entry.Reader);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.IsNull(entry.OriginalName);
            Assert.IsNull(entry.EnglishName);
            Assert.IsNull(entry.GermanName);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withValidID_BasicInfoOnly()
        {
            // Arrange
            Country entry = new Country("_xxx");

            // Act
            int count = entry.RetrieveBasicInformation(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Country Original Name X", entry.OriginalName);
            Assert.AreEqual("Country English Name X", entry.EnglishName);
            Assert.AreEqual("Country German Name X", entry.GermanName);
            Assert.AreEqual("Country Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Country Last Updated X", entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withValidID_AdditionalInfo()
        {
            // Arrange
            Country entry = new Country("_xxx");

            // Act
            int count = entry.RetrieveBasicInformation(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Country Original Name X", entry.OriginalName);
            Assert.AreEqual("Country English Name X", entry.EnglishName);
            Assert.AreEqual("Country German Name X", entry.GermanName);
            Assert.AreEqual("Country Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Country Last Updated X", entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withInvalidID_BasicInfoOnly()
        {
            // Arrange
            Country entry = new Country("_aaa");

            // Act
            int count = entry.RetrieveBasicInformation(true);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.OriginalName);
            Assert.IsNull(entry.EnglishName);
            Assert.IsNull(entry.GermanName);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withInvalidID_AdditionalInfo()
        {
            // Arrange
            Country entry = new Country("_aaa");

            // Act
            int count = entry.RetrieveBasicInformation(false);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.OriginalName);
            Assert.IsNull(entry.EnglishName);
            Assert.IsNull(entry.GermanName);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withValidID()
        {
            // Arrange
            Country entry = new Country("_xxx");

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withInvalidID()
        {
            // Arrange
            Country entry = new Country("_aaa");

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID_BasicInfoOnly()
        {
            // Arrange
            Country entry = new Country("_xxx");

            // Act
            int count = entry.Retrieve(true);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Country Original Name X", entry.OriginalName);
            Assert.AreEqual("Country English Name X", entry.EnglishName);
            Assert.AreEqual("Country German Name X", entry.GermanName);
            Assert.AreEqual("Country Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Country Last Updated X", entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID_AdditionalInfo()
        {
            // Arrange
            Country entry = new Country("_xxx");

            // Act
            int count = entry.Retrieve(false);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Country Original Name X", entry.OriginalName);
            Assert.AreEqual("Country English Name X", entry.EnglishName);
            Assert.AreEqual("Country German Name X", entry.GermanName);
            Assert.AreEqual("Country Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Country Last Updated X", entry.LastUpdated);
        }

        [TestMethod()]
        public void Retrieve_withInvalidID_BasicInfoOnly()
        {
            // Arrange
            Country entry = new Country("_aaa");

            // Act
            int count = entry.Retrieve(true);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.OriginalName);
            Assert.IsNull(entry.EnglishName);
            Assert.IsNull(entry.GermanName);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void Retrieve_withInvalidID_AdditionalInfo()
        {
            // Arrange
            Country entry = new Country("_aaa");

            // Act
            int count = entry.Retrieve(false);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.OriginalName);
            Assert.IsNull(entry.EnglishName);
            Assert.IsNull(entry.GermanName);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }
    }
}
