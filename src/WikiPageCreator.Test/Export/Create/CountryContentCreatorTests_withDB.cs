// WikiPageCreator.exe: Creates pages for use with a wiki from the
// EntertainmentInfothek.db using EntertainmentDB.dll
// Copyright (C) 2022 Sandra Scherer

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
    public class CountryContentCreatorTests_withDB
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        [TestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        public void CountryContentCreatorTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Country entry = new Country(reader, id);
            CountryItem item = new CountryItem(reader);
            item.Country = entry;
            List<CountryItem> list = new List<CountryItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            // Act
            CountryContentCreator creator = new CountryContentCreator(list, formatter, targetLanguageCode);

            // Assert
            Assert.IsNotNull(creator);
            Assert.AreEqual(list, creator.Countries);
            Assert.AreEqual(formatter, creator.Formatter);
            Assert.AreEqual(targetLanguageCode, creator.TargetLanguageCode);
            Assert.AreEqual("Production Country", creator.Headings["en"]);
            Assert.AreEqual("Produktionsland", creator.Headings["de"]);
        }

        [TestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CountryContentCreatorTest_withCountriesNull(string targetLanguageCode)
        {
            // Arrange
            Formatter formatter = new DokuWikiFormatter();
            CountryContentCreator creator;

            // Act, Assert
            Assert.ThrowsExactly<NullReferenceException>(() => creator = new CountryContentCreator(null, formatter, targetLanguageCode));
        }

        [TestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        public void CountryContentCreatorTest_withFormatterNull(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Country entry = new Country(reader, id);
            CountryItem item = new CountryItem(reader);
            item.Country = entry;
            List<CountryItem> list = new List<CountryItem>();
            list.Add(item);
            CountryContentCreator creator;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => creator = new CountryContentCreator(list, null, targetLanguageCode));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CountryContentCreatorTest_withTargetLanguageCodeNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Country entry = new Country(reader, id);
            CountryItem item = new CountryItem(reader);
            item.Country = entry;
            List<CountryItem> list = new List<CountryItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();
            CountryContentCreator creator;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => creator = new CountryContentCreator(list, formatter, null));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CountryContentCreatorTest_withTargetLanguageCodeEmptyString(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Country entry = new Country(reader, id);
            CountryItem item = new CountryItem(reader);
            item.Country = entry;
            List<CountryItem> list = new List<CountryItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();
            CountryContentCreator creator;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => creator = new CountryContentCreator(list, formatter, ""));
        }

        [TestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        public void GetPageNameTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Country entry = new Country(reader, id);
            CountryItem item = new CountryItem(reader);
            item.Country = entry;
            List<CountryItem> list = new List<CountryItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            CountryContentCreator creator = new CountryContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            Assert.ThrowsExactly<NotSupportedException>(() => creator.GetPageName());
        }

        [TestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        public void CreatePageTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Country entry = new Country(reader, id);
            CountryItem item = new CountryItem(reader);
            item.Country = entry;
            List<CountryItem> list = new List<CountryItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            CountryContentCreator creator = new CountryContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            Assert.ThrowsExactly<NotSupportedException>(() => creator.CreatePage());
        }

        [TestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreateInfoBoxContentTest_withValidID(string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Country entry = new Country(reader, VALID_ID);
            entry.Retrieve(false);
            CountryItem item = new CountryItem(reader);
            item.Country = entry;
            List<CountryItem> list = new List<CountryItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            CountryContentCreator creator = new CountryContentCreator(list, formatter, targetLanguageCode);

            List<string> testContent = new List<string>();

            string[] pathInfo = { targetLanguageCode, "info" };

            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Production Country",
                                   formatter.AsInternalLink(pathInfo, "Country OriginalFullName X", "Country EnglishShortName X") }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Produktionsland",
                                   formatter.AsInternalLink(pathInfo, "Country OriginalFullName X", "Country GermanShortName X") }));
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

        [TestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        public void CreateChapterContentTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Country entry = new Country(reader, id);
            CountryItem item = new CountryItem(reader);
            item.Country = entry;
            List<CountryItem> list = new List<CountryItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            CountryContentCreator creator = new CountryContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            Assert.ThrowsExactly<NotSupportedException>(() => creator.CreateChapterContent());
        }

        [TestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        public void CreateSectionContentTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Country entry = new Country(reader, id);
            CountryItem item = new CountryItem(reader);
            item.Country = entry;
            List<CountryItem> list = new List<CountryItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            CountryContentCreator creator = new CountryContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            Assert.ThrowsExactly<NotSupportedException>(() => creator.CreateSectionContent());
        }
    }
}
