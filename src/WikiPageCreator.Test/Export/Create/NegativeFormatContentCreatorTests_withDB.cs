// WikiPageCreator.exe: Creates pages for use with a wiki from the
// EntertainmentInfothek.db using EntertainmentDB.dll
// Copyright (C) 2023 Sandra Scherer

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
    public class NegativeFormatContentCreatorTests_withDB
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
        public void NegativeFormatContentCreatorTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            FilmFormat entry = new FilmFormat(reader, id);
            FilmFormatItem item = new FilmFormatItem(reader);
            item.FilmFormat = entry;
            List<FilmFormatItem> list = new List<FilmFormatItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            // Act
            NegativeFormatContentCreator creator = new NegativeFormatContentCreator(list, formatter, targetLanguageCode);

            // Assert
            Assert.IsNotNull(creator);
            Assert.AreEqual(list, creator.FilmFormats);
            Assert.AreEqual(formatter, creator.Formatter);
            Assert.AreEqual(targetLanguageCode, creator.TargetLanguageCode);
        }

        [DataTestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        [ExpectedException(typeof(NullReferenceException))]
        public void NegativeFormatContentCreatorTest_withNegativeFormatsNull(string targetLanguageCode)
        {
            // Arrange
            Formatter formatter = new DokuWikiFormatter();

            // Act, Assert
            NegativeFormatContentCreator creator = new NegativeFormatContentCreator(null, formatter, targetLanguageCode);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NegativeFormatContentCreatorTest_withFormatterNull(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            FilmFormat entry = new FilmFormat(reader, id);
            FilmFormatItem item = new FilmFormatItem(reader);
            item.FilmFormat = entry;
            List<FilmFormatItem> list = new List<FilmFormatItem>();
            list.Add(item);

            // Act, Assert
            NegativeFormatContentCreator creator = new NegativeFormatContentCreator(list, null, targetLanguageCode);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NegativeFormatContentCreatorTest_withTargetLanguageCodeNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            FilmFormat entry = new FilmFormat(reader, id);
            FilmFormatItem item = new FilmFormatItem(reader);
            item.FilmFormat = entry;
            List<FilmFormatItem> list = new List<FilmFormatItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            // Act, Assert
            NegativeFormatContentCreator creator = new NegativeFormatContentCreator(list, formatter, null);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NegativeFormatContentCreatorTest_withTargetLanguageCodeEmptyString(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            FilmFormat entry = new FilmFormat(reader, id);
            FilmFormatItem item = new FilmFormatItem(reader);
            item.FilmFormat = entry;
            List<FilmFormatItem> list = new List<FilmFormatItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            // Act, Assert
            NegativeFormatContentCreator creator = new NegativeFormatContentCreator(list, formatter, "");
        }

        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        [ExpectedException(typeof(NotSupportedException))]
        public void GetPageNameTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            FilmFormat entry = new FilmFormat(reader, id);
            FilmFormatItem item = new FilmFormatItem(reader);
            item.FilmFormat = entry;
            List<FilmFormatItem> list = new List<FilmFormatItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            NegativeFormatContentCreator creator = new NegativeFormatContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            creator.GetPageName();
        }

        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        [ExpectedException(typeof(NotSupportedException))]
        public void CreatePageContentTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            FilmFormat entry = new FilmFormat(reader, id);
            FilmFormatItem item = new FilmFormatItem(reader);
            item.FilmFormat = entry;
            List<FilmFormatItem> list = new List<FilmFormatItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            NegativeFormatContentCreator creator = new NegativeFormatContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            creator.CreatePageContent();
        }

        [DataTestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreateInfoBoxContentTest_withValidID(string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            FilmFormat entry = new FilmFormat(reader, VALID_ID);
            entry.Retrieve(false);
            FilmFormatItem item = new FilmFormatItem(reader);
            item.FilmFormat = entry;
            List<FilmFormatItem> list = new List<FilmFormatItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            NegativeFormatContentCreator creator = new NegativeFormatContentCreator(list, formatter, targetLanguageCode);

            List<string> testContent = new List<string>();

            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Negative Format",
                                   "FilmFormat Format X" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Negativformat",
                                   "FilmFormat Format X" }));
            }

            // Act
            List<string> content = creator.CreateInfoBoxContent();

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
        public void CreateChapterContentTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            FilmFormat entry = new FilmFormat(reader, id);
            FilmFormatItem item = new FilmFormatItem(reader);
            item.FilmFormat = entry;
            List<FilmFormatItem> list = new List<FilmFormatItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            NegativeFormatContentCreator creator = new NegativeFormatContentCreator(list, formatter, targetLanguageCode);

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
            FilmFormat entry = new FilmFormat(reader, id);
            FilmFormatItem item = new FilmFormatItem(reader);
            item.FilmFormat = entry;
            List<FilmFormatItem> list = new List<FilmFormatItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            NegativeFormatContentCreator creator = new NegativeFormatContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            creator.CreateSectionContent();
        }
    }
}
