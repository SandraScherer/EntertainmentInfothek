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
            Assert.IsNull(entry.Type);
            Assert.IsNull(entry.ReleaseDate);
            Assert.IsNull(entry.Connection);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Genres);
            Assert.IsNull(entry.Countries);
            Assert.IsNull(entry.Colors);
            Assert.IsNull(entry.Languages);
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
            Assert.IsNull(entry.Type);
            Assert.IsNull(entry.ReleaseDate);
            Assert.IsNull(entry.Connection);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Genres);
            Assert.IsNull(entry.Countries);
            Assert.IsNull(entry.Colors);
            Assert.IsNull(entry.Languages);
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
            Assert.AreEqual("_xxx", entry.Type.ID);
            Assert.AreEqual("Movie Release Date X", entry.ReleaseDate);
            Assert.AreEqual("_xxx", entry.Connection.ID);
            Assert.AreEqual("Movie Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Movie Last Updated X", entry.LastUpdated);

            Assert.IsNull(entry.Genres);
            Assert.IsNull(entry.Countries);
            Assert.IsNull(entry.Colors);
            Assert.IsNull(entry.Languages);
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
            Assert.IsNull(entry.Type);
            Assert.IsNull(entry.ReleaseDate);
            Assert.IsNull(entry.Connection);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);

            Assert.IsNull(entry.Genres);
            Assert.IsNull(entry.Countries);
            Assert.IsNull(entry.Colors);
            Assert.IsNull(entry.Languages);
        }

        [TestMethod()]
        public void RetrieveAdditionalInformationTest_withValidID()
        {
            // Arrange
            Movie entry = new Movie("_xxx");

            // Act
            int count = entry.RetrieveAdditionalInformation();

            // Assert
            Assert.AreEqual((4 * 3), count);

            Assert.AreEqual(3, entry.Genres.Count);
            Assert.AreEqual("_xx1", entry.Genres[0].ID);
            Assert.AreEqual("_xx2", entry.Genres[1].ID);
            Assert.AreEqual("_xx3", entry.Genres[2].ID);

            Assert.AreEqual(3, entry.Countries.Count);
            Assert.AreEqual("_xx1", entry.Countries[0].ID);
            Assert.AreEqual("_xx2", entry.Countries[1].ID);
            Assert.AreEqual("_xx3", entry.Countries[2].ID);

            Assert.AreEqual(3, entry.Colors.Count);
            Assert.AreEqual("_xx1", entry.Colors[0].ID);
            Assert.AreEqual("_xx2", entry.Colors[1].ID);
            Assert.AreEqual("_xx3", entry.Colors[2].ID);

            Assert.AreEqual(3, entry.Languages.Count);
            Assert.AreEqual("_xx1", entry.Languages[0].ID);
            Assert.AreEqual("_xx2", entry.Languages[1].ID);
            Assert.AreEqual("_xx3", entry.Languages[2].ID);
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
            Assert.AreEqual("_xxx", entry.Type.ID);
            Assert.AreEqual("Movie Release Date X", entry.ReleaseDate);
            Assert.AreEqual("_xxx", entry.Connection.ID);
            Assert.AreEqual("Movie Details X", entry.Details);
            Assert.AreEqual("_xxx", entry.Status.ID);
            Assert.AreEqual("Movie Last Updated X", entry.LastUpdated);

            Assert.AreEqual(3, entry.Genres.Count);
            Assert.AreEqual("_xx1", entry.Genres[0].ID);
            Assert.AreEqual("_xx2", entry.Genres[1].ID);
            Assert.AreEqual("_xx3", entry.Genres[2].ID);

            Assert.AreEqual(3, entry.Countries.Count);
            Assert.AreEqual("_xx1", entry.Countries[0].ID);
            Assert.AreEqual("_xx2", entry.Countries[1].ID);
            Assert.AreEqual("_xx3", entry.Countries[2].ID);

            Assert.AreEqual(3, entry.Colors.Count);
            Assert.AreEqual("_xx1", entry.Colors[0].ID);
            Assert.AreEqual("_xx2", entry.Colors[1].ID);
            Assert.AreEqual("_xx3", entry.Colors[2].ID);

            Assert.AreEqual(3, entry.Languages.Count);
            Assert.AreEqual("_xx1", entry.Languages[0].ID);
            Assert.AreEqual("_xx2", entry.Languages[1].ID);
            Assert.AreEqual("_xx3", entry.Languages[2].ID);
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
            Assert.IsNull(entry.Type);
            Assert.IsNull(entry.ReleaseDate);
            Assert.IsNull(entry.Connection);
            Assert.IsNull(entry.Details);
            Assert.IsNull(entry.Status);
            Assert.IsNull(entry.LastUpdated);
        }

        [DataTestMethod()]
        public void RetrieveListTest_withValidData()
        {
            // Arrange
            // TODO: which DB reader is to be used should be defined in configuration
            DBReader reader = new SQLiteReader();

            // Act
            List<Movie> list = Data.Movie.RetrieveList(reader, "_xxx");

            // Assert
            Assert.AreEqual(1, list.Count);

            Assert.AreEqual("_xxx", list[0].ID);
        }
    }
}
