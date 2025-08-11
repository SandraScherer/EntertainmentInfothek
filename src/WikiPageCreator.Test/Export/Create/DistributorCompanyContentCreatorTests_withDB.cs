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
    public class DistributorCompanyContentCreatorTests_withDB
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
        public void DistributorCompanyContentCreatorTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Company entry = new Company(reader, id);
            DistributorCompanyItem item = new DistributorCompanyItem(reader);
            item.Company = entry;
            List<DistributorCompanyItem> list = new List<DistributorCompanyItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            // Act
            DistributorCompanyContentCreator creator = new DistributorCompanyContentCreator(list, formatter, targetLanguageCode);

            // Assert
            Assert.IsNotNull(creator);
            Assert.AreEqual(list, creator.Distributors);
            Assert.AreEqual(formatter, creator.Formatter);
            Assert.AreEqual(targetLanguageCode, creator.TargetLanguageCode);
            Assert.AreEqual("Dummy", creator.Headings["en"]);
            Assert.AreEqual("Dummy", creator.Headings["de"]);
        }

        [TestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void DistributorCompanyContentCreatorTest_withDistributorsNull(string targetLanguageCode)
        {
            // Arrange
            Formatter formatter = new DokuWikiFormatter();
            DistributorCompanyContentCreator creator;

            // Act, Assert
            Assert.ThrowsExactly<NullReferenceException>(() => creator = new DistributorCompanyContentCreator(null, formatter, targetLanguageCode));
        }

        [TestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        public void DistributorCompanyContentCreatorTest_withFormatterNull(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Company entry = new Company(reader, id);
            DistributorCompanyItem item = new DistributorCompanyItem(reader);
            item.Company = entry;
            List<DistributorCompanyItem> list = new List<DistributorCompanyItem>();
            list.Add(item);
            DistributorCompanyContentCreator creator;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => creator = new DistributorCompanyContentCreator(list, null, targetLanguageCode));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void DistributorCompanyContentCreatorTest_withTargetLanguageCodeNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Company entry = new Company(reader, id);
            DistributorCompanyItem item = new DistributorCompanyItem(reader);
            item.Company = entry;
            List<DistributorCompanyItem> list = new List<DistributorCompanyItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();
            DistributorCompanyContentCreator creator;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => creator = new DistributorCompanyContentCreator(list, formatter, null));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void DistributorCompanyContentCreatorTest_withTargetLanguageCodeEmptyString(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Company entry = new Company(reader, id);
            DistributorCompanyItem item = new DistributorCompanyItem(reader);
            item.Company = entry;
            List<DistributorCompanyItem> list = new List<DistributorCompanyItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();
            DistributorCompanyContentCreator creator;

            // Act, Assert
            Assert.ThrowsExactly<ArgumentNullException>(() => creator = new DistributorCompanyContentCreator(list, formatter, ""));
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
            Company entry = new Company(reader, id);
            DistributorCompanyItem item = new DistributorCompanyItem(reader);
            item.Company = entry;
            List<DistributorCompanyItem> list = new List<DistributorCompanyItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            DistributorCompanyContentCreator creator = new DistributorCompanyContentCreator(list, formatter, targetLanguageCode);

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
            Company entry = new Company(reader, id);
            DistributorCompanyItem item = new DistributorCompanyItem(reader);
            item.Company = entry;
            List<DistributorCompanyItem> list = new List<DistributorCompanyItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            DistributorCompanyContentCreator creator = new DistributorCompanyContentCreator(list, formatter, targetLanguageCode);

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
            Company entry = new Company(reader, VALID_ID);
            DistributorCompanyItem item = new DistributorCompanyItem(reader);
            item.Company = entry;
            List<DistributorCompanyItem> list = new List<DistributorCompanyItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            DistributorCompanyContentCreator creator = new DistributorCompanyContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            Assert.ThrowsExactly<NotSupportedException>(() => creator.CreateInfoBoxContent());
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
            Company entry = new Company(reader, id);
            DistributorCompanyItem item = new DistributorCompanyItem(reader);
            item.Company = entry;
            List<DistributorCompanyItem> list = new List<DistributorCompanyItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            DistributorCompanyContentCreator creator = new DistributorCompanyContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            Assert.ThrowsExactly<NotSupportedException>(() => creator.CreateChapterContent());
        }

        [TestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreateSectionContentTest_withValidID(string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Company entry = new Company(reader, VALID_ID);
            entry.Retrieve(false);
            DistributorCompanyItem item = new DistributorCompanyItem(reader);
            item.Company = entry;
            List<DistributorCompanyItem> list = new List<DistributorCompanyItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            DistributorCompanyContentCreator creator = new DistributorCompanyContentCreator(list, formatter, targetLanguageCode);

            List<string> testContent = new List<string>();
            string[] path = { targetLanguageCode, "company" };

            testContent.Add(formatter.AsTableTitle(new string[] { null }));
            testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(path, "Company Name X Company NameAddOn X")}" }));
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
