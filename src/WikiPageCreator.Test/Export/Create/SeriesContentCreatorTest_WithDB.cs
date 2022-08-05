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

            string[] data = new string[2];
            string[] pathInfo = { targetLanguageCode, "info" };
            string[] pathDate = { targetLanguageCode, "date" };

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
            testContent.Add($"");

            // InfoBox Begin
            int[] width = { 30, 70 };
            testContent.Add(formatter.BeginBox(475, Alignment.Right));
            testContent.Add(formatter.DefineTable(445, width));

            // InfoBox Title
            if (targetLanguageCode.Equals("en"))
            {
                data[0] = "Original Title";
                data[1] = "Series OriginalTitle X";
            }
            else
            {
                data[0] = "Originaltitel";
                data[1] = "Series OriginalTitle X";
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

            // InfoBox ReleaseDate First Episode
            if (targetLanguageCode.Equals("en"))
            {
                data[0] = "Release Date (First Episode)";
                data[1] = formatter.AsInternalLink(pathDate, "Series ReleaseDateFirstEpisode X", "Series ReleaseDateFirstEpisode X");
            }
            else
            {
                data[0] = "Erstausstrahlung (Erste Folge)";
                data[1] = formatter.AsInternalLink(pathDate, "Series ReleaseDateFirstEpisode X", "Series ReleaseDateFirstEpisode X");
            }
            testContent.Add(formatter.AsTableRow(data));

            // InfoBox ReleaseDate Last Episode
            if (targetLanguageCode.Equals("en"))
            {
                data[0] = "Release Date (Last Episode)";
                data[1] = formatter.AsInternalLink(pathDate, "Series ReleaseDateLastEpisode X", "Series ReleaseDateLastEpisode X");
            }
            else
            {
                data[0] = "Erstausstrahlung (Letzte Folge)";
                data[1] = formatter.AsInternalLink(pathDate, "Series ReleaseDateLastEpisode X", "Series ReleaseDateLastEpisode X");
            }
            testContent.Add(formatter.AsTableRow(data));

            // Infobox No of Seasons
            if (targetLanguageCode.Equals("en"))
            {
                data[0] = "# Seasons";
                data[1] = "Series NoOfSeasons X";
            }
            else
            {
                data[0] = "# Staffeln";
                data[1] = "Series NoOfSeasons X";
            }
            testContent.Add(formatter.AsTableRow(data));

            // Infobox No of Episodes
            if (targetLanguageCode.Equals("en"))
            {
                data[0] = "# Episodes";
                data[1] = "Series NoOfEpisodes X";
            }
            else
            {
                data[0] = "# Folgen";
                data[1] = "Series NoOfEpisodes X";
            }
            testContent.Add(formatter.AsTableRow(data));

            // InfoBox Budget
            data[0] = "Budget";
            data[1] = "Series Budget X";
            testContent.Add(formatter.AsTableRow(data));

            // InfoBox Worldwide Gross
            if (targetLanguageCode.Equals("en"))
            {
                data[0] = "Worldwide Gross";
                data[1] = $"Series WorldwideGross X ({formatter.AsInternalLink(pathDate, "Series WorldwideGrossDate X", "Series WorldwideGrossDate X")})";
            }
            else
            {
                data[0] = "Einspielergebnis (weltweit)";
                data[1] = $"Series WorldwideGross X ({formatter.AsInternalLink(pathDate, "Series WorldwideGrossDate X", "Series WorldwideGrossDate X")})";
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
