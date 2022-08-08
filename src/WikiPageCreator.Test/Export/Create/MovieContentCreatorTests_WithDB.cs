// WikiPageCreator.exe: Creates pages for use with a wiki from the
// EntertainmentInfothek.db using EntertainmentDB.dll
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


using EntertainmentDB.Data;
using EntertainmentDB.DBAccess.Read;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WikiPageCreator.Export.Format;

namespace WikiPageCreator.Export.Create.IntegrationTests
{
    [TestClass()]
    public class MovieContentCreatorTests_WithDB
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        public void MovieContentCreatorTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            // Act
            MovieContentCreator creator = new MovieContentCreator(movie, formatter, targetLanguageCode);

            // Assert
            Assert.IsNotNull(creator);
            Assert.AreEqual(movie, creator.Movie);
            Assert.AreEqual(formatter, creator.Formatter);
            Assert.AreEqual(targetLanguageCode, creator.TargetLanguageCode);
        }

        [DataTestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MovieContentCreatorTest_withMovieNull(string targetLanguageCode)
        {
            // Arrange
            Formatter formatter = new DokuWikiFormatter();

            // Act, Assert
            MovieContentCreator creator = new MovieContentCreator(null, formatter, targetLanguageCode);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MovieContentCreatorTest_withFormatterNull(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, id);

            // Act, Assert
            MovieContentCreator creator = new MovieContentCreator(movie, null, targetLanguageCode);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MovieContentCreatorTest_withTargetLanguageCodeNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            // Act, Assert
            MovieContentCreator creator = new MovieContentCreator(movie, formatter, null);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MovieContentCreatorTest_withTargetLanguageCodeEmptyString(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            // Act, Assert
            MovieContentCreator creator = new MovieContentCreator(movie, formatter, "");
        }

        [DataTestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void GetPageNameTest_withValidID(string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, VALID_ID);
            movie.Retrieve(false);
            Formatter formatter = new DokuWikiFormatter();

            MovieContentCreator creator = new MovieContentCreator(movie, formatter, targetLanguageCode);

            string testContent = $"{formatter.AsFilename("Movie OriginalTitle X (Movi)")}";

            // Act
            string content = creator.GetPageName();

            // Assert
            Assert.AreEqual(testContent, content);
        }

        [DataTestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreatePageContentTest_withValidID(string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, VALID_ID);
            movie.Retrieve(false);
            Formatter formatter = new DokuWikiFormatter();

            MovieContentCreator creator = new MovieContentCreator(movie, formatter, targetLanguageCode);

            List<string> testContent = new List<string>();

            string[] data = new string[2];
            string[] pathInfo = { targetLanguageCode, "info" };
            string[] pathDate = { targetLanguageCode, "date" };

            // File Header
            testContent.Add(formatter.DisableCache());
            testContent.Add(formatter.DisableTOC());
            testContent.Add(formatter.BeginComment());
            testContent.Add($"   Movie OriginalTitle X");
            testContent.Add($"");
            testContent.Add($"   @author  WikiPageCreator");
            testContent.Add($"   @date    {DateTime.Now:yyyy-MM-dd}");
            testContent.Add($"   @version Status EnglishTitle X: Movie LastUpdated X");
            testContent.Add(formatter.EndComment());
            testContent.Add($"");
            testContent.Add($"");

            // Title
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsHeading1("Movie EnglishTitle X"));
            }
            else if (targetLanguageCode.Equals("de"))
            {
                testContent.Add(formatter.AsHeading1("Movie GermanTitle X"));
            }
            else
            {
                testContent.Add(formatter.AsHeading1("Movie OriginalTitle X"));
            }
            testContent.Add($"");
            testContent.Add($"");

            // InfoBox Begin
            int[] width = { 30, 70 };
            testContent.Add(formatter.BeginBox(475, Alignment.Right));
            testContent.Add(formatter.DefineTable(445, width));

            // InfoBox Title
            if (targetLanguageCode.Equals("en"))
            {
                data[0] = "Original Title";
                data[1] = "Movie OriginalTitle X";
            }
            else
            {
                data[0] = "Originaltitel";
                data[1] = "Movie OriginalTitle X";
            }
            testContent.Add(formatter.AsTableRow(data));

            // InfoBox Type
            if (targetLanguageCode.Equals("en"))
            {
                data[0] = "Type";
                data[1] = formatter.AsInternalLink(pathInfo, "Type EnglishTitle X", "Type EnglishTitle X");
            }
            else
            {
                data[0] = "Typ";
                data[1] = formatter.AsInternalLink(pathInfo, "Type EnglishTitle X", "Type GermanTitle X");
            }
            testContent.Add(formatter.AsTableRow(data));

            // InfoBox ReleaseDate
            if (targetLanguageCode.Equals("en"))
            {
                data[0] = "Original Release Date";
                data[1] = formatter.AsInternalLink(pathDate, "Movie ReleaseDate X", "Movie ReleaseDate X");
            }
            else
            {
                data[0] = "Erstausstrahlung";
                data[1] = formatter.AsInternalLink(pathDate, "Movie ReleaseDate X", "Movie ReleaseDate X");
            }
            testContent.Add(formatter.AsTableRow(data));

            // InfoBox Budget
            data[0] = "Budget";
            data[1] = "Movie Budget X";
            testContent.Add(formatter.AsTableRow(data));

            // InfoBox Worldwide Gross
            if (targetLanguageCode.Equals("en"))
            {
                data[0] = "Worldwide Gross";
                data[1] = $"Movie WorldwideGross X ({formatter.AsInternalLink(pathDate, "Movie WorldwideGrossDate X", "Movie WorldwideGrossDate X")})";
            }
            else
            {
                data[0] = "Einspielergebnis (weltweit)";
                data[1] = $"Movie WorldwideGross X ({formatter.AsInternalLink(pathDate, "Movie WorldwideGrossDate X", "Movie WorldwideGrossDate X")})";
            }
            testContent.Add(formatter.AsTableRow(data));

            // InfoBox End
            testContent.Add(formatter.EndBox());
            testContent.Add($"");
            testContent.Add($"");

            // Connection Chapter
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsHeading2("Connections to other articles"));
            }
            else
            {
                testContent.Add(formatter.AsHeading2("Bezüge zu anderen Artikeln"));
            }
            testContent.Add($"");
            testContent.Add($"");

            testContent.Add(formatter.AsInsertPage(targetLanguageCode + ":navigation:_xxx"));

            // File Footer
            testContent.Add($"");
            testContent.Add($"");

            // Act
            List<string> content = creator.CreatePageContent();

            // Assert
            Assert.AreEqual(testContent.Count, content.Count);
            for (int i = 0; i < testContent.Count; i++)
            {
                Assert.AreEqual(testContent[i], content[i]);
            }
        }

        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        [ExpectedException(typeof(NotSupportedException))]
        public void CreateInfoBoxContentTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            MovieContentCreator creator = new MovieContentCreator(movie, formatter, targetLanguageCode);

            // Act, Assert
            creator.CreateInfoBoxContent();
        }

        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        [ExpectedException(typeof(NotSupportedException))]
        public void CreateChapterContentTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            MovieContentCreator creator = new MovieContentCreator(movie, formatter, targetLanguageCode);

            // Act, Assert
            creator.CreateChapterContent();
        }

        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        [ExpectedException(typeof(NotSupportedException))]
        public void CreateSectionContentTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            MovieContentCreator creator = new MovieContentCreator(movie, formatter, targetLanguageCode);

            // Act, Assert
            creator.CreateSectionContent();
        }
    }
}
