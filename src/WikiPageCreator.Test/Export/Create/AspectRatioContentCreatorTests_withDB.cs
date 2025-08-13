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
    public class AspectRatioContentCreatorTests_withDB
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
        public void AspectRatioContentCreatorTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            AspectRatio entry = new AspectRatio(reader, id);
            AspectRatioItem item = new AspectRatioItem(reader);
            item.AspectRatio = entry;
            List<AspectRatioItem> list = new List<AspectRatioItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            // Act
            AspectRatioContentCreator creator = new AspectRatioContentCreator(list, formatter, targetLanguageCode);

            // Assert
            Assert.IsNotNull(creator);
            Assert.AreEqual(list, creator.AspectRatios);
            Assert.AreEqual(formatter, creator.Formatter);
            Assert.AreEqual(targetLanguageCode, creator.TargetLanguageCode);
            Assert.AreEqual("Aspect Ratio", creator.Headings["en"]);
            Assert.AreEqual("Bildformat", creator.Headings["de"]);
        }

        [TestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void AspectRatioContentCreatorTest_withAspectRatiosNull(string targetLanguageCode)
        {
            // Arrange
            Formatter formatter = new DokuWikiFormatter();
            AspectRatioContentCreator creator;

            // Act, Assert
            Assert.ThrowsExactly<NullReferenceException>(() => creator = new AspectRatioContentCreator(null, formatter, targetLanguageCode));
        }

        [TestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        public void AspectRatioContentCreatorTest_withFormatterNull(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            AspectRatio entry = new AspectRatio(reader, id);
            AspectRatioItem item = new AspectRatioItem(reader);
            item.AspectRatio = entry;
            List<AspectRatioItem> list = new List<AspectRatioItem>();
            list.Add(item);
            AspectRatioContentCreator creator;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => creator = new AspectRatioContentCreator(list, null, targetLanguageCode));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void AspectRatioContentCreatorTest_withTargetLanguageCodeNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            AspectRatio entry = new AspectRatio(reader, id);
            AspectRatioItem item = new AspectRatioItem(reader);
            item.AspectRatio = entry;
            List<AspectRatioItem> list = new List<AspectRatioItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();
            AspectRatioContentCreator creator;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => creator = new AspectRatioContentCreator(list, formatter, null));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void AspectRatioContentCreatorTest_withTargetLanguageCodeEmptyString(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            AspectRatio entry = new AspectRatio(reader, id);
            AspectRatioItem item = new AspectRatioItem(reader);
            item.AspectRatio = entry;
            List<AspectRatioItem> list = new List<AspectRatioItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();
            AspectRatioContentCreator creator;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => creator = new AspectRatioContentCreator(list, formatter, ""));
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
            AspectRatio entry = new AspectRatio(reader, id);
            AspectRatioItem item = new AspectRatioItem(reader);
            item.AspectRatio = entry;
            List<AspectRatioItem> list = new List<AspectRatioItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            AspectRatioContentCreator creator = new AspectRatioContentCreator(list, formatter, targetLanguageCode);

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
            AspectRatio entry = new AspectRatio(reader, id);
            AspectRatioItem item = new AspectRatioItem(reader);
            item.AspectRatio = entry;
            List<AspectRatioItem> list = new List<AspectRatioItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            AspectRatioContentCreator creator = new AspectRatioContentCreator(list, formatter, targetLanguageCode);

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
            AspectRatio entry = new AspectRatio(reader, VALID_ID);
            entry.Retrieve(false);
            AspectRatioItem item = new AspectRatioItem(reader);
            item.AspectRatio = entry;
            List<AspectRatioItem> list = new List<AspectRatioItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            AspectRatioContentCreator creator = new AspectRatioContentCreator(list, formatter, targetLanguageCode);

            List<string> testContent = new List<string>();

            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Aspect Ratio",
                                   "AspectRatio Ratio X" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Bildformat",
                                   "AspectRatio Ratio X" }));
            }

            // Act
            List<string> content = creator.CreateInfoBoxContent();

            // Assert
            Assert.HasCount(testContent.Count, content);
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
            AspectRatio entry = new AspectRatio(reader, id);
            AspectRatioItem item = new AspectRatioItem(reader);
            item.AspectRatio = entry;
            List<AspectRatioItem> list = new List<AspectRatioItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            AspectRatioContentCreator creator = new AspectRatioContentCreator(list, formatter, targetLanguageCode);

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
            AspectRatio entry = new AspectRatio(reader, id);
            AspectRatioItem item = new AspectRatioItem(reader);
            item.AspectRatio = entry;
            List<AspectRatioItem> list = new List<AspectRatioItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            AspectRatioContentCreator creator = new AspectRatioContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            Assert.ThrowsExactly<NotSupportedException>(() => creator.CreateSectionContent());
        }
    }
}
