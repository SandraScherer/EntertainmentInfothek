﻿// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
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
    public class GenreTests_withDB
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        // oblsolete
        [TestMethod()]
        public void GenreTest_checkEntry()
        {
            // Arrange
            Genre entry = new Genre();

            // Act
            // Assert
            Assert.IsNotNull(entry);
        }

        // oblsolete
        [TestMethod()]
        public void GenreTest_checkReader()
        {
            // Arrange
            Genre entry = new Genre();

            // Act
            // Assert
            Assert.IsNotNull(entry.Reader);
        }

        // oblsolete
        [TestMethod()]
        public void GenreTest_checkEnglishTitle()
        {
            // Arrange
            Genre entry = new Genre();

            // Act
            // Assert
            Assert.IsNull(entry.EnglishTitle);
        }

        // oblsolete
        [TestMethod()]
        public void GenreTest_checkGermanitle()
        {
            // Arrange
            Genre entry = new Genre();

            // Act
            // Assert
            Assert.IsNull(entry.GermanTitle);
        }

        // oblsolete
        [TestMethod()]
        public void GenreTest_checkDetails()
        {
            // Arrange
            Genre entry = new Genre();

            // Act
            // Assert
            Assert.IsNull(entry.Details);
        }

        // oblsolete
        [TestMethod()]
        public void GenreTest_checkStatus()
        {
            // Arrange
            Genre entry = new Genre();

            // Act
            // Assert
            Assert.IsNull(entry.Status);
        }

        // oblsolete
        [TestMethod()]
        public void GenreTest_checkLastUpdated()
        {
            // Arrange
            Genre entry = new Genre();

            // Act
            // Assert
            Assert.IsNull(entry.LastUpdated);
        }

        // oblsolete
        [TestMethod()]
        public void GenreTest_withoutID_checkID()
        {
            // Arrange
            Genre entry = new Genre();

            // Act
            // Assert
            Assert.AreEqual("", entry.ID);
        }

        // oblsolete
        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void GenreTest_withID_checkID(string value)
        {
            // Arrange
            Genre entry = new Genre(value);

            // Act
            // Assert
            Assert.AreEqual(value, entry.ID);
        }

        // oblsolete
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GenreTest_withIDnull_checkException()
        {
            // Arrange, Act, Assert
            Genre entry = new Genre(null);
        }

        // TODO: delete
        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withValidID(bool value)
        {
            // Arrange
            Genre entry = new Genre(VALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(value);

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Genre EnglishTitle X", entry.EnglishTitle);
            Assert.AreEqual("Genre GermanTitle X", entry.GermanTitle);
            Assert.AreEqual("Genre Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Genre LastUpdated X", entry.LastUpdated);
        }

        // TODO: delete
        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveBasicInformationTest_withInvalidID(bool value)
        {
            // Arrange
            Genre entry = new Genre(INVALID_ID);

            // Act
            int count = entry.RetrieveBasicInformation(value);

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual(INVALID_ID, entry.ID);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
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
            Genre entry = new Genre(value);

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
            Genre entry = new Genre(VALID_ID);

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
            Genre entry = new Genre(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("_xxx", entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkEnglishTitle(bool value)
        {
            // Arrange
            Genre entry = new Genre(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Genre EnglishTitle X", entry.EnglishTitle);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkGermanTitle(bool value)
        {
            // Arrange
            Genre entry = new Genre(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Genre GermanTitle X", entry.GermanTitle);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkDetails(bool value)
        {
            // Arrange
            Genre entry = new Genre(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Genre Details X", entry.Details);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withValidID_checkStatus(bool value)
        {
            // Arrange
            Genre entry = new Genre(VALID_ID);

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
            Genre entry = new Genre(VALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual("Genre LastUpdated X", entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkCount(bool value)
        {
            // Arrange
            Genre entry = new Genre(INVALID_ID);

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
            Genre entry = new Genre(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.AreEqual(INVALID_ID, entry.ID);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkEnglishTitle(bool value)
        {
            // Arrange
            Genre entry = new Genre(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.EnglishTitle);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkGermanTitle(bool value)
        {
            // Arrange
            Genre entry = new Genre(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.GermanTitle);
        }

        [DataTestMethod()]
        [DataRow(true)]
        [DataRow(false)]
        public void RetrieveTest_withInvalidID_checkDetails(bool value)
        {
            // Arrange
            Genre entry = new Genre(INVALID_ID);

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
            Genre entry = new Genre(INVALID_ID);

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
            Genre entry = new Genre(INVALID_ID);

            // Act
            int count = entry.Retrieve(value);

            // Assert
            Assert.IsNull(entry.LastUpdated);
        }
    }
}