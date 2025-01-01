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
    public class ProductionDateContentCreatorTests_withDB
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
        public void ProductionDateContentCreatorTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TimespanItem item = new TimespanItem(reader);
            item.StartDate = "unknown";
            item.EndDate = "unknown";
            List<TimespanItem> list = new List<TimespanItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            // Act
            ProductionDateContentCreator creator = new ProductionDateContentCreator(list, formatter, targetLanguageCode);

            // Assert
            Assert.IsNotNull(creator);
            Assert.AreEqual(list, creator.Timespans);
            Assert.AreEqual(formatter, creator.Formatter);
            Assert.AreEqual(targetLanguageCode, creator.TargetLanguageCode);
            Assert.AreEqual("Production Dates", creator.Headings["en"]);
            Assert.AreEqual("Produktionsdaten", creator.Headings["de"]);
        }

        [DataTestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void ProductionDateContentCreatorTest_withProductionDatesNull(string targetLanguageCode)
        {
            // Arrange
            Formatter formatter = new DokuWikiFormatter();
            ProductionDateContentCreator creator;

            // Act, Assert
            Assert.ThrowsException<NullReferenceException>(() => creator = new ProductionDateContentCreator(null, formatter, targetLanguageCode));
        }

        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        public void ProductionDateContentCreatorTest_withFormatterNull(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TimespanItem item = new TimespanItem(reader);
            item.StartDate = "unknown";
            item.EndDate = "unknown";
            List<TimespanItem> list = new List<TimespanItem>();
            list.Add(item);
            ProductionDateContentCreator creator;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => creator = new ProductionDateContentCreator(list, null, targetLanguageCode));
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void ProductionDateContentCreatorTest_withTargetLanguageCodeNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TimespanItem item = new TimespanItem(reader);
            item.StartDate = "unknown";
            item.EndDate = "unknown";
            List<TimespanItem> list = new List<TimespanItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();
            ProductionDateContentCreator creator;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => creator = new ProductionDateContentCreator(list, formatter, null));
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void ProductionDateContentCreatorTest_withTargetLanguageCodeEmptyString(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TimespanItem item = new TimespanItem(reader);
            item.StartDate = "unknown";
            item.EndDate = "unknown";
            List<TimespanItem> list = new List<TimespanItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();
            ProductionDateContentCreator creator;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => creator = new ProductionDateContentCreator(list, formatter, ""));
        }

        [DataTestMethod()]
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
            TimespanItem item = new TimespanItem(reader);
            item.StartDate = "unknown";
            item.EndDate = "unknown";
            List<TimespanItem> list = new List<TimespanItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            ProductionDateContentCreator creator = new ProductionDateContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            Assert.ThrowsException<NotSupportedException>(() => creator.GetPageName());
        }

        [DataTestMethod()]
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
            TimespanItem item = new TimespanItem(reader);
            item.StartDate = "unknown";
            item.EndDate = "unknown";
            List<TimespanItem> list = new List<TimespanItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            ProductionDateContentCreator creator = new ProductionDateContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            Assert.ThrowsException<NotSupportedException>(() => creator.CreatePage());
        }

        [DataTestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreateInfoBoxContentTest_withValidID(string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TimespanItem item = new TimespanItem(reader);
            item.StartDate = "unknown";
            item.EndDate = "unknown";
            List<TimespanItem> list = new List<TimespanItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            ProductionDateContentCreator creator = new ProductionDateContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            Assert.ThrowsException<NotSupportedException>(() => creator.CreateInfoBoxContent());
        }

        [DataTestMethod()]
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
            TimespanItem item = new TimespanItem(reader);
            item.StartDate = "unknown";
            item.EndDate = "unknown";
            List<TimespanItem> list = new List<TimespanItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            ProductionDateContentCreator creator = new ProductionDateContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            Assert.ThrowsException<NotSupportedException>(() => creator.CreateChapterContent());
        }

        [DataTestMethod()]
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
            TimespanItem item = new TimespanItem(reader);
            item.StartDate = "unknown";
            item.EndDate = "unknown";
            List<TimespanItem> list = new List<TimespanItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            ProductionDateContentCreator creator = new ProductionDateContentCreator(list, formatter, targetLanguageCode);

            List<string> testContent = new List<string>();
            string[] path = { targetLanguageCode, "date" };

            testContent.Add(formatter.AsTableTitle(new string[] { null }));
            testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(path, "unknown")} - {formatter.AsInternalLink(path, "unknown")}" }));
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


        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        public void CreateSectionContentTest_withEndDateEmpty(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TimespanItem item = new TimespanItem(reader);
            item.StartDate = "unknown";
            List<TimespanItem> list = new List<TimespanItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            ProductionDateContentCreator creator = new ProductionDateContentCreator(list, formatter, targetLanguageCode);

            List<string> testContent = new List<string>();
            string[] path = { targetLanguageCode, "date" };

            testContent.Add(formatter.AsTableTitle(new string[] { null }));
            testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(path, "unknown")}" }));
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


        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        public void CreateSectionContentTest_withStartDateEmpty(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            TimespanItem item = new TimespanItem(reader);
            item.EndDate = "unknown";
            List<TimespanItem> list = new List<TimespanItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            ProductionDateContentCreator creator = new ProductionDateContentCreator(list, formatter, targetLanguageCode);
            List<string> content;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => content= creator.CreateSectionContent());
        }
    }
}
