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
    public class SeriesContentCreatorTests_WithDB
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
        public void SeriesContentCreatorTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Series series = new Series(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            // Act
            SeriesContentCreator creator = new SeriesContentCreator(series, formatter, targetLanguageCode);

            // Assert
            Assert.IsNotNull(creator);
            Assert.AreEqual(series, creator.Series);
            Assert.AreEqual(formatter, creator.Formatter);
            Assert.AreEqual(targetLanguageCode, creator.TargetLanguageCode);
        }

        [DataTestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SeriesContentCreatorTest_withSeriesNull(string targetLanguageCode)
        {
            // Arrange
            Formatter formatter = new DokuWikiFormatter();

            // Act, Assert
            SeriesContentCreator creator = new SeriesContentCreator(null, formatter, targetLanguageCode);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SeriesContentCreatorTest_withFormatterNull(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Series series = new Series(reader, id);

            // Act, Assert
            SeriesContentCreator creator = new SeriesContentCreator(series, null, targetLanguageCode);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SeriesContentCreatorTest_withTargetLanguageCodeNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Series series = new Series(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            // Act, Assert
            SeriesContentCreator creator = new SeriesContentCreator(series, formatter, null);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SeriesContentCreatorTest_withTargetLanguageCodeEmptyString(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Series series = new Series(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            // Act, Assert
            SeriesContentCreator creator = new SeriesContentCreator(series, formatter, "");
        }

        [DataTestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void GetPageNameTest_withValidID(string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Series series = new Series(reader, VALID_ID);
            series.Retrieve(false);
            Formatter formatter = new DokuWikiFormatter();

            SeriesContentCreator creator = new SeriesContentCreator(series, formatter, targetLanguageCode);

            string testContent = $"{formatter.AsFilename("Series OriginalTitle X (Seri)")}";

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
            Series series = new Series(reader, VALID_ID);
            series.Retrieve(false);
            Formatter formatter = new DokuWikiFormatter();

            SeriesContentCreator creator = new SeriesContentCreator(series, formatter, targetLanguageCode);

            List<string> testContent = new List<string>();

            string[] pathInfo = { targetLanguageCode, "info" };
            string[] pathDate = { targetLanguageCode, "date" };
            string[] pathCertification = { "certification" };

            // File Header
            testContent.Add(formatter.DisableCache());
            testContent.Add(formatter.DisableTOC());
            testContent.Add(formatter.BeginComment());
            testContent.Add($"   Series OriginalTitle X");
            testContent.Add($"");
            testContent.Add($"   @author  WikiPageCreator");
            testContent.Add($"   @date    {DateTime.Now:yyyy-MM-dd}");
            testContent.Add($"   @version Status EnglishTitle X: Series LastUpdated X");
            testContent.Add(formatter.EndComment());
            testContent.Add($"");
            testContent.Add($"");

            // Title
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsHeading1("Series EnglishTitle X"));
            }
            else if (targetLanguageCode.Equals("de"))
            {
                testContent.Add(formatter.AsHeading1("Series GermanTitle X"));
            }
            else
            {
                testContent.Add(formatter.AsHeading1("Series OriginalTitle X"));
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
                                   "Series OriginalTitle X" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Originaltitel",
                                   "Series OriginalTitle X" }));
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

            // InfoBox ReleaseDate First Episode
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Release Date (First Episode)",
                                   formatter.AsInternalLink(pathDate, "Series ReleaseDateFirstEpisode X", "Series ReleaseDateFirstEpisode X") }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Erstausstrahlung (Erste Folge)",
                                   formatter.AsInternalLink(pathDate, "Series ReleaseDateFirstEpisode X", "Series ReleaseDateFirstEpisode X") }));
            }

            // InfoBox ReleaseDate Last Episode
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Release Date (Last Episode)",
                                   formatter.AsInternalLink(pathDate, "Series ReleaseDateLastEpisode X", "Series ReleaseDateLastEpisode X") }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Erstausstrahlung (Letzte Folge)",
                                   formatter.AsInternalLink(pathDate, "Series ReleaseDateLastEpisode X", "Series ReleaseDateLastEpisode X") }));
            }

            // InfoBox Genre
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Genre",
                                   $"{formatter.AsInternalLink(pathInfo, "Genre EnglishTitle X", "Genre EnglishTitle X")} Series Genre Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Genre EnglishTitle Y", "Genre EnglishTitle Y")} Series Genre Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Genre EnglishTitle Z", "Genre EnglishTitle Z")} Series Genre Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Genre",
                                   $"{formatter.AsInternalLink(pathInfo, "Genre EnglishTitle X", "Genre GermanTitle X")} Series Genre Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Genre EnglishTitle Y", "Genre GermanTitle Y")} Series Genre Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Genre EnglishTitle Z", "Genre GermanTitle Z")} Series Genre Details X3" }));
            }

            // InfoBox Certifiction
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Certification",
                                   $"{formatter.AsImage(pathCertification, "Image FileName X", 75)} Series Certification Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsImage(pathCertification, "Image FileName Y", 75)} Series Certification Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsImage(pathCertification, "Image FileName Z", 75)} Series Certification Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Altersfreigabe",
                                   $"{formatter.AsImage(pathCertification, "Image FileName X", 75)} Series Certification Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsImage(pathCertification, "Image FileName Y", 75)} Series Certification Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsImage(pathCertification, "Image FileName Z", 75)} Series Certification Details X3" }));
            }

            // InfoBox Country
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Production Country",
                                   $"{formatter.AsInternalLink(pathInfo, "Country OriginalFullName X", "Country EnglishShortName X")} Series Country Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Country OriginalFullName Y", "Country EnglishShortName Y")} Series Country Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Country OriginalFullName Z", "Country EnglishShortName Z")} Series Country Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Produktionsland",
                                   $"{formatter.AsInternalLink(pathInfo, "Country OriginalFullName X", "Country GermanShortName X")} Series Country Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Country OriginalFullName Y", "Country GermanShortName Y")} Series Country Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Country OriginalFullName Z", "Country GermanShortName Z")} Series Country Details X3" }));
            }

            // InfoBox Language
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Language",
                                   $"{formatter.AsInternalLink(pathInfo, "Language OriginalName X", "Language EnglishName X")} Series Language Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Language OriginalName Y", "Language EnglishName Y")} Series Language Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Language OriginalName Z", "Language EnglishName Z")} Series Language Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Sprache",
                                   $"{formatter.AsInternalLink(pathInfo, "Language OriginalName X", "Language GermanName X")} Series Language Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Language OriginalName Y", "Language GermanName Y")} Series Language Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Language OriginalName Z", "Language GermanName Z")} Series Language Details X3" }));
            }

            // Infobox No of Seasons
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "# Seasons",
                                   "Series NoOfSeasons X" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "# Staffeln",
                                   "Series NoOfSeasons X" }));
            }

            // Infobox No of Episodes
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "# Episodes",
                                   "Series NoOfEpisodes X" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "# Folgen",
                                   "Series NoOfEpisodes X" }));
            }

            // InfoBox Budget
            testContent.Add(formatter.AsTableRow(
                new string[] { "Budget",
                               "Series Budget X" }));

            // InfoBox Worldwide Gross
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Worldwide Gross",
                                   $"Series WorldwideGross X ({formatter.AsInternalLink(pathDate, "Series WorldwideGrossDate X", "Series WorldwideGrossDate X")})" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Einspielergebnis (weltweit)",
                                   $"Series WorldwideGross X ({formatter.AsInternalLink(pathDate, "Series WorldwideGrossDate X", "Series WorldwideGrossDate X")})" }));
            }

            // InfoBox Runtime
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Runtime",
                                   $"11 min. ({formatter.AsInternalLink(pathInfo, "Edition EnglishTitle X", "Edition EnglishTitle X")}) Series Runtime Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"12 min. ({formatter.AsInternalLink(pathInfo, "Edition EnglishTitle Y", "Edition EnglishTitle Y")}) Series Runtime Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"13 min. ({formatter.AsInternalLink(pathInfo, "Edition EnglishTitle Z", "Edition EnglishTitle Z")}) Series Runtime Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Laufzeit",
                                   $"11 min. ({formatter.AsInternalLink(pathInfo, "Edition EnglishTitle X", "Edition GermanTitle X")}) Series Runtime Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"12 min. ({formatter.AsInternalLink(pathInfo, "Edition EnglishTitle Y", "Edition GermanTitle Y")}) Series Runtime Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"13 min. ({formatter.AsInternalLink(pathInfo, "Edition EnglishTitle Z", "Edition GermanTitle Z")}) Series Runtime Details X3" }));
            }

            // InfoBox SoundMix
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "SoundMix",
                                   $"{formatter.AsInternalLink(pathInfo, "SoundMix EnglishTitle X", "SoundMix EnglishTitle X")} Series SoundMix Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "SoundMix EnglishTitle Y", "SoundMix EnglishTitle Y")} Series SoundMix Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "SoundMix EnglishTitle Z", "SoundMix EnglishTitle Z")} Series SoundMix Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Tonmischung",
                                   $"{formatter.AsInternalLink(pathInfo, "SoundMix EnglishTitle X", "SoundMix GermanTitle X")} Series SoundMix Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "SoundMix EnglishTitle Y", "SoundMix GermanTitle Y")} Series SoundMix Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "SoundMix EnglishTitle Z", "SoundMix GermanTitle Z")} Series SoundMix Details X3" }));
            }

            // InfoBox Color
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Color",
                                   $"{formatter.AsInternalLink(pathInfo, "Color EnglishTitle X", "Color EnglishTitle X")} Series Color Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Color EnglishTitle Y", "Color EnglishTitle Y")} Series Color Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Color EnglishTitle Z", "Color EnglishTitle Z")} Series Color Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Farbe",
                                   $"{formatter.AsInternalLink(pathInfo, "Color EnglishTitle X", "Color GermanTitle X")} Series Color Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Color EnglishTitle Y", "Color GermanTitle Y")} Series Color Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Color EnglishTitle Z", "Color GermanTitle Z")} Series Color Details X3" }));
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
        public void CreateInfoBoxContentTest_withValidID(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Series series = new Series(reader, id);
            series.Retrieve(false);
            Formatter formatter = new DokuWikiFormatter();

            SeriesContentCreator creator = new SeriesContentCreator(series, formatter, targetLanguageCode);

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
        public void CreateChapterContentTest_withValidID(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Series series = new Series(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            SeriesContentCreator creator = new SeriesContentCreator(series, formatter, targetLanguageCode);

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
            Series series = new Series(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            SeriesContentCreator creator = new SeriesContentCreator(series, formatter, targetLanguageCode);

            // Act, Assert
            creator.CreateSectionContent();
        }
    }
}
