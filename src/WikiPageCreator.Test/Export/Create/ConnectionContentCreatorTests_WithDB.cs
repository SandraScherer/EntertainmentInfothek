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
    public class ConnectionContentCreatorTests_WithDB
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
        public void ConnectionContentCreatorTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Connection entry = new Connection(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            // Act
            ConnectionContentCreator creator = new ConnectionContentCreator(entry, formatter, targetLanguageCode);

            // Assert
            Assert.IsNotNull(creator);
            Assert.AreEqual(entry, creator.Connection);
            Assert.AreEqual(formatter, creator.Formatter);
            Assert.AreEqual(targetLanguageCode, creator.TargetLanguageCode);
            Assert.AreEqual("Connections", creator.Headings["en"]);
            Assert.AreEqual("Verbindungen", creator.Headings["de"]);
        }

        [DataTestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void ConnectionContentCreatorTest_withConnectionNull(string targetLanguageCode)
        {
            // Arrange
            Formatter formatter = new DokuWikiFormatter();
            ConnectionContentCreator creator;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => creator = new ConnectionContentCreator(null, formatter, targetLanguageCode));
        }

        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        public void ConnectionContentCreatorTest_withFormatterNull(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Connection entry = new Connection(reader, id);
            ConnectionContentCreator creator;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => creator = new ConnectionContentCreator(entry, null, targetLanguageCode));
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void ConnectionContentCreatorTest_withTargetLanguageCodeNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Connection entry = new Connection(reader, id);
            Formatter formatter = new DokuWikiFormatter();
            ConnectionContentCreator creator;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => creator = new ConnectionContentCreator(entry, formatter, null));
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void ConnectionContentCreatorTest_withTargetLanguageCodeEmptyString(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Connection entry = new Connection(reader, id);
            Formatter formatter = new DokuWikiFormatter();
            ConnectionContentCreator creator;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => creator = new ConnectionContentCreator(entry, formatter, ""));
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
            Connection entry = new Connection(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            ConnectionContentCreator creator = new ConnectionContentCreator(entry, formatter, targetLanguageCode);

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
            Connection entry = new Connection(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            ConnectionContentCreator creator = new ConnectionContentCreator(entry, formatter, targetLanguageCode);

            // Act, Assert
            Assert.ThrowsException<NotSupportedException>(() => creator.CreatePage());
        }

        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        public void CreateInfoBoxContentTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Connection entry = new Connection(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            ConnectionContentCreator creator = new ConnectionContentCreator(entry, formatter, targetLanguageCode);

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
            Connection entry = new Connection(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            ConnectionContentCreator creator = new ConnectionContentCreator(entry, formatter, targetLanguageCode);

            List<string> testContent = new List<string>();

            testContent.Add(formatter.AsInsertPage(targetLanguageCode + ":navigation:" + id));

            // Act
            List<string> content = creator.CreateChapterContent();

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
        public void CreateSectionContentTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Connection entry = new Connection(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            ConnectionContentCreator creator = new ConnectionContentCreator(entry, formatter, targetLanguageCode);
            List<string> content;

            // Act, Assert
            Assert.ThrowsException<NotSupportedException>(() => content = creator.CreateSectionContent());
        }
    }
}
