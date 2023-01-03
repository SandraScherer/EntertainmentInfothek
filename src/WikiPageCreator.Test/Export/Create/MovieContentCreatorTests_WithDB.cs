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

            string[] pathInfo = { targetLanguageCode, "info" };
            string[] pathDate = { targetLanguageCode, "date" };
            string[] pathCertification = { "certification" };

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

            // InfoBox Begin
            int[] width = { 30, 70 };
            testContent.Add(formatter.BeginBox(475, Alignment.Right));
            testContent.Add(formatter.DefineTable(445, width));

            // InfoBox Title
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Original Title",
                                   "Movie OriginalTitle X" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Originaltitel",
                                   "Movie OriginalTitle X" }));
            }

            // InfoBox Type
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Type",
                                   formatter.AsInternalLink(pathInfo, "Type EnglishTitle X", "Type EnglishTitle X") }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Typ",
                                   formatter.AsInternalLink(pathInfo, "Type EnglishTitle X", "Type GermanTitle X") }));
            }

            // InfoBox ReleaseDate
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Original Release Date",
                                   formatter.AsInternalLink(pathDate, "Movie ReleaseDate X", "Movie ReleaseDate X") }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Erstausstrahlung",
                                   formatter.AsInternalLink(pathDate, "Movie ReleaseDate X", "Movie ReleaseDate X") }));
            }

            // InfoBox Genre
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Genre",
                                   $"{formatter.AsInternalLink(pathInfo, "Genre EnglishTitle X", "Genre EnglishTitle X")} Movie Genre Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Genre EnglishTitle Y", "Genre EnglishTitle Y")} Movie Genre Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Genre EnglishTitle Z", "Genre EnglishTitle Z")} Movie Genre Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Genre",
                                   $"{formatter.AsInternalLink(pathInfo, "Genre EnglishTitle X", "Genre GermanTitle X")} Movie Genre Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Genre EnglishTitle Y", "Genre GermanTitle Y")} Movie Genre Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Genre EnglishTitle Z", "Genre GermanTitle Z")} Movie Genre Details X3" }));
            }

            // InfoBox Certification
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Certification",
                                   $"{formatter.AsImage(pathCertification, "Image FileName X", 75)} Movie Certification Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsImage(pathCertification, "Image FileName Y", 75)} Movie Certification Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsImage(pathCertification, "Image FileName Z", 75)} Movie Certification Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Altersfreigabe",
                                   $"{formatter.AsImage(pathCertification, "Image FileName X", 75)} Movie Certification Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsImage(pathCertification, "Image FileName Y", 75)} Movie Certification Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsImage(pathCertification, "Image FileName Z", 75)} Movie Certification Details X3" }));
            }

            // InfoBox Country
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Production Country",
                                   $"{formatter.AsInternalLink(pathInfo, "Country OriginalFullName X", "Country EnglishShortName X")} Movie Country Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Country OriginalFullName Y", "Country EnglishShortName Y")} Movie Country Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Country OriginalFullName Z", "Country EnglishShortName Z")} Movie Country Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Produktionsland",
                                   $"{formatter.AsInternalLink(pathInfo, "Country OriginalFullName X", "Country GermanShortName X")} Movie Country Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Country OriginalFullName Y", "Country GermanShortName Y")} Movie Country Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Country OriginalFullName Z", "Country GermanShortName Z")} Movie Country Details X3" }));
            }

            // InfoBox Language
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Language",
                                   $"{formatter.AsInternalLink(pathInfo, "Language OriginalName X", "Language EnglishName X")} Movie Language Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Language OriginalName Y", "Language EnglishName Y")} Movie Language Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Language OriginalName Z", "Language EnglishName Z")} Movie Language Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Sprache",
                                   $"{formatter.AsInternalLink(pathInfo, "Language OriginalName X", "Language GermanName X")} Movie Language Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Language OriginalName Y", "Language GermanName Y")} Movie Language Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Language OriginalName Z", "Language GermanName Z")} Movie Language Details X3" }));
            }

            // InfoBox Budget
            testContent.Add(formatter.AsTableRow(
                new string[] { "Budget",
                               "Movie Budget X" }));

            // InfoBox Worldwide Gross
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Worldwide Gross",
                                   $"Movie WorldwideGross X ({formatter.AsInternalLink(pathDate, "Movie WorldwideGrossDate X", "Movie WorldwideGrossDate X")})" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Einspielergebnis (weltweit)",
                                   $"Movie WorldwideGross X ({formatter.AsInternalLink(pathDate, "Movie WorldwideGrossDate X", "Movie WorldwideGrossDate X")})" }));
            }

            // InfoBox SoundMix
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "SoundMix",
                                   $"{formatter.AsInternalLink(pathInfo, "SoundMix EnglishTitle X", "SoundMix EnglishTitle X")} Movie SoundMix Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "SoundMix EnglishTitle Y", "SoundMix EnglishTitle Y")} Movie SoundMix Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "SoundMix EnglishTitle Z", "SoundMix EnglishTitle Z")} Movie SoundMix Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Tonmischung",
                                   $"{formatter.AsInternalLink(pathInfo, "SoundMix EnglishTitle X", "SoundMix GermanTitle X")} Movie SoundMix Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "SoundMix EnglishTitle Y", "SoundMix GermanTitle Y")} Movie SoundMix Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "SoundMix EnglishTitle Z", "SoundMix GermanTitle Z")} Movie SoundMix Details X3" }));
            }

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
