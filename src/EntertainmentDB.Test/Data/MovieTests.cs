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
using EntertainmentDB.DBAccess.Read;

namespace EntertainmentDB.Data.Tests
{
    [TestClass()]
    public class MovieTests
    {
        [TestMethod()]
        public void MovieTest()
        {
            // Arrange
            Movie entry = new Movie();

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.IsNotNull(entry.Reader);

            Assert.AreEqual("", entry.ID);
            Assert.IsNull(entry.OriginalTitle);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
            Assert.IsNull(entry.ReleaseDate);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void MovieTest_withID()
        {
            // Arrange
            Movie entry = new Movie("_xxx");

            // Act
            // Assert
            Assert.IsNotNull(entry);
            Assert.IsNotNull(entry.Reader);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.IsNull(entry.OriginalTitle);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
            Assert.IsNull(entry.ReleaseDate);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withValidID()
        {
            // Arrange
            Movie entry = new Movie("_xxx");

            // Act
            int count = entry.RetrieveBasicInformation();

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Movie Original Title X", entry.OriginalTitle);
            Assert.AreEqual("Movie English Title X", entry.EnglishTitle);
            Assert.AreEqual("Movie German Title X", entry.GermanTitle);
            Assert.AreEqual("Movie Release Date X", entry.ReleaseDate);
            Assert.AreEqual("Movie Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Movie Last Updated X", entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveBasicInformationTest_withInvalidID()
        {
            // Arrange
            Movie entry = new Movie("_aaa");

            // Act
            int count = entry.RetrieveBasicInformation();

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.OriginalTitle);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
            Assert.IsNull(entry.ReleaseDate);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withValidID()
        {
            // Arrange
            Movie entry = new Movie("_xxx");

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withInvalidID()
        {
            // Arrange
            Movie entry = new Movie("_aaa");

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod()]
        public void RetrieveTest_withValidID()
        {
            // Arrange
            Movie entry = new Movie("_xxx");

            // Act
            int count = entry.Retrieve();

            // Assert
            Assert.AreEqual(1, count);

            Assert.AreEqual("_xxx", entry.ID);
            Assert.AreEqual("Movie Original Title X", entry.OriginalTitle);
            Assert.AreEqual("Movie English Title X", entry.EnglishTitle);
            Assert.AreEqual("Movie German Title X", entry.GermanTitle);
            Assert.AreEqual("Movie Release Date X", entry.ReleaseDate);
            Assert.AreEqual("Movie Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Movie Last Updated X", entry.LastUpdated);
        }

        [TestMethod()]
        public void RetrieveTest_withInvalidID()
        {
            // Arrange
            Movie entry = new Movie("_aaa");

            // Act
            int count = entry.Retrieve();

            // Assert
            Assert.AreEqual(0, count);

            Assert.AreEqual("_aaa", entry.ID);
            Assert.IsNull(entry.OriginalTitle);
            Assert.IsNull(entry.EnglishTitle);
            Assert.IsNull(entry.GermanTitle);
            Assert.IsNull(entry.ReleaseDate);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [DataTestMethod()]
        [DataRow("Movie")]
        public void RetrieveListTest_withValidData(string value)
        {
            // Arrange
            DBReader reader = new SQLiteReader();

            // Act
            List<Movie> list = Data.Movie.RetrieveList(reader, "_xxx");

            // Assert
            Assert.AreEqual(1, list.Count);

            Assert.AreEqual("_xxx", list[0].ID);
        }
    }
}