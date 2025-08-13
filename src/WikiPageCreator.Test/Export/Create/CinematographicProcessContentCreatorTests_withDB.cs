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
    public class CinematographicProcessContentCreatorTests_withDB
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
        public void CinematographicProcessContentCreatorTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CinematographicProcess entry = new CinematographicProcess(reader, id);
            CinematographicProcessItem item = new CinematographicProcessItem(reader);
            item.CinematographicProcess = entry;
            List<CinematographicProcessItem> list = new List<CinematographicProcessItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            // Act
            CinematographicProcessContentCreator creator = new CinematographicProcessContentCreator(list, formatter, targetLanguageCode);

            // Assert
            Assert.IsNotNull(creator);
            Assert.AreEqual(list, creator.CinematographicProcesses);
            Assert.AreEqual(formatter, creator.Formatter);
            Assert.AreEqual(targetLanguageCode, creator.TargetLanguageCode);
            Assert.AreEqual("Cinematographic Process", creator.Headings["en"]);
            Assert.AreEqual("Filmprozess", creator.Headings["de"]);
        }

        [TestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CinematographicProcessContentCreatorTest_withCinematographicProcessesNull(string targetLanguageCode)
        {
            // Arrange
            Formatter formatter = new DokuWikiFormatter();

            // Act, Assert
            CinematographicProcessContentCreator creator;
            Assert.ThrowsExactly<NullReferenceException>(() => creator = new CinematographicProcessContentCreator(null, formatter, targetLanguageCode));
        }

        [TestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        public void CinematographicProcessContentCreatorTest_withFormatterNull(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CinematographicProcess entry = new CinematographicProcess(reader, id);
            CinematographicProcessItem item = new CinematographicProcessItem(reader);
            item.CinematographicProcess = entry;
            List<CinematographicProcessItem> list = new List<CinematographicProcessItem>();
            list.Add(item);

            // Act, Assert
            CinematographicProcessContentCreator creator;
            Assert.ThrowsExactly<ArgumentNullException>(() => creator = new CinematographicProcessContentCreator(list, null, targetLanguageCode));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CinematographicProcessContentCreatorTest_withTargetLanguageCodeNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CinematographicProcess entry = new CinematographicProcess(reader, id);
            CinematographicProcessItem item = new CinematographicProcessItem(reader);
            item.CinematographicProcess = entry;
            List<CinematographicProcessItem> list = new List<CinematographicProcessItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();
            CinematographicProcessContentCreator creator;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => creator = new CinematographicProcessContentCreator(list, formatter, null));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CinematographicProcessContentCreatorTest_withTargetLanguageCodeEmptyString(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            CinematographicProcess entry = new CinematographicProcess(reader, id);
            CinematographicProcessItem item = new CinematographicProcessItem(reader);
            item.CinematographicProcess = entry;
            List<CinematographicProcessItem> list = new List<CinematographicProcessItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();
            CinematographicProcessContentCreator creator;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => creator = new CinematographicProcessContentCreator(list, formatter, ""));
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
            CinematographicProcess entry = new CinematographicProcess(reader, id);
            CinematographicProcessItem item = new CinematographicProcessItem(reader);
            item.CinematographicProcess = entry;
            List<CinematographicProcessItem> list = new List<CinematographicProcessItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            CinematographicProcessContentCreator creator = new CinematographicProcessContentCreator(list, formatter, targetLanguageCode);

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
            CinematographicProcess entry = new CinematographicProcess(reader, id);
            CinematographicProcessItem item = new CinematographicProcessItem(reader);
            item.CinematographicProcess = entry;
            List<CinematographicProcessItem> list = new List<CinematographicProcessItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            CinematographicProcessContentCreator creator = new CinematographicProcessContentCreator(list, formatter, targetLanguageCode);

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
            CinematographicProcess entry = new CinematographicProcess(reader, VALID_ID);
            entry.Retrieve(false);
            CinematographicProcessItem item = new CinematographicProcessItem(reader);
            item.CinematographicProcess = entry;
            List<CinematographicProcessItem> list = new List<CinematographicProcessItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            CinematographicProcessContentCreator creator = new CinematographicProcessContentCreator(list, formatter, targetLanguageCode);

            List<string> testContent = new List<string>();

            string[] pathInfo = { targetLanguageCode, "info" };

            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Cinematographic Process",
                                   formatter.AsInternalLink(pathInfo, "CinematographicProcess Name X", "CinematographicProcess Name X") }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Filmprozess",
                                   formatter.AsInternalLink(pathInfo, "CinematographicProcess Name X", "CinematographicProcess Name X") }));
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
            CinematographicProcess entry = new CinematographicProcess(reader, id);
            CinematographicProcessItem item = new CinematographicProcessItem(reader);
            item.CinematographicProcess = entry;
            List<CinematographicProcessItem> list = new List<CinematographicProcessItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            CinematographicProcessContentCreator creator = new CinematographicProcessContentCreator(list, formatter, targetLanguageCode);

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
            CinematographicProcess entry = new CinematographicProcess(reader, id);
            CinematographicProcessItem item = new CinematographicProcessItem(reader);
            item.CinematographicProcess = entry;
            List<CinematographicProcessItem> list = new List<CinematographicProcessItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            CinematographicProcessContentCreator creator = new CinematographicProcessContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            Assert.ThrowsExactly<NotSupportedException>(() => creator.CreateSectionContent());
        }
    }
}
