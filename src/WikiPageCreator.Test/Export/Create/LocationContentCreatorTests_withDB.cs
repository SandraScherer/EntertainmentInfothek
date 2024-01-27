// WikiPageCreator.exe: Creates pages for use with a wiki from the
// EntertainmentInfothek.db using EntertainmentDB.dll
// Copyright (C) 2024 Sandra Scherer

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
    public class LocationContentCreatorTests_withDB
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
        public void LocationContentCreatorTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Location entry = new Location(reader, id);
            LocationItem item = new LocationItem(reader);
            item.Location = entry;
            List<LocationItem> list = new List<LocationItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            // Act
            LocationContentCreator creator = new LocationContentCreator(list, formatter, targetLanguageCode);

            // Assert
            Assert.IsNotNull(creator);
            Assert.AreEqual(list, creator.Locations);
            Assert.AreEqual(formatter, creator.Formatter);
            Assert.AreEqual(targetLanguageCode, creator.TargetLanguageCode);
            Assert.AreEqual("Filming Locations", creator.Headings["en"]);
            Assert.AreEqual("Drehorte", creator.Headings["de"]);
        }

        [DataTestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        [ExpectedException(typeof(NullReferenceException))]
        public void LocationContentCreatorTest_withLocationsNull(string targetLanguageCode)
        {
            // Arrange
            Formatter formatter = new DokuWikiFormatter();

            // Act, Assert
            LocationContentCreator creator = new LocationContentCreator(null, formatter, targetLanguageCode);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LocationContentCreatorTest_withFormatterNull(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Location entry = new Location(reader, id);
            LocationItem item = new LocationItem(reader);
            item.Location = entry;
            List<LocationItem> list = new List<LocationItem>();
            list.Add(item);

            // Act, Assert
            LocationContentCreator creator = new LocationContentCreator(list, null, targetLanguageCode);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LocationContentCreatorTest_withTargetLanguageCodeNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Location entry = new Location(reader, id);
            LocationItem item = new LocationItem(reader);
            item.Location = entry;
            List<LocationItem> list = new List<LocationItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            // Act, Assert
            LocationContentCreator creator = new LocationContentCreator(list, formatter, null);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LocationContentCreatorTest_withTargetLanguageCodeEmptyString(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Location entry = new Location(reader, id);
            LocationItem item = new LocationItem(reader);
            item.Location = entry;
            List<LocationItem> list = new List<LocationItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            // Act, Assert
            LocationContentCreator creator = new LocationContentCreator(list, formatter, "");
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
            Location entry = new Location(reader, id);
            LocationItem item = new LocationItem(reader);
            item.Location = entry;
            List<LocationItem> list = new List<LocationItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            LocationContentCreator creator = new LocationContentCreator(list, formatter, targetLanguageCode);

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
        public void CreatePageTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Location entry = new Location(reader, id);
            LocationItem item = new LocationItem(reader);
            item.Location = entry;
            List<LocationItem> list = new List<LocationItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            LocationContentCreator creator = new LocationContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            creator.CreatePage();
        }

        [DataTestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        [ExpectedException(typeof(NotSupportedException))]
        public void CreateInfoBoxContentTest_withValidID(string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Location entry = new Location(reader, VALID_ID);
            LocationItem item = new LocationItem(reader);
            item.Location = entry;
            List<LocationItem> list = new List<LocationItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            LocationContentCreator creator = new LocationContentCreator(list, formatter, targetLanguageCode);

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
            Location entry = new Location(reader, id);
            LocationItem item = new LocationItem(reader);
            item.Location = entry;
            List<LocationItem> list = new List<LocationItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            LocationContentCreator creator = new LocationContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            creator.CreateChapterContent();
        }

        [DataTestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreateSectionContentTest_withValidID(string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Location entry = new Location(reader, VALID_ID);
            entry.Retrieve(false);
            LocationItem item = new LocationItem(reader);
            item.Location = entry;
            List<LocationItem> list = new List<LocationItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            LocationContentCreator creator = new LocationContentCreator(list, formatter, targetLanguageCode);

            List<string> testContent = new List<string>();
            string[] path = { targetLanguageCode, "info" };

            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(path, "Location X")}, {formatter.AsInternalLink(path, "Country OriginalFullName X", "Country EnglishShortName X")}" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(path, "Location X")}, {formatter.AsInternalLink(path, "Country OriginalFullName X", "Country GermanShortName X")}" }));
            }
            testContent.Add($"");
            testContent.Add($"");

            // Act
            List<string> content = creator.CreateSectionContent();

            // Assert
            Assert.AreEqual(testContent.Count, content.Count);
            for (int i = 0; i < testContent.Count; i++)
            {
                Assert.AreEqual(testContent[i], content[i]);
            }
        }
    }
}
