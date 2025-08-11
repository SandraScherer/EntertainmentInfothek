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
    public class CertificationContentCreatorTests_withDB
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
        public void CertificationContentCreatorTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Certification entry = new Certification(reader, id);
            CertificationItem item = new CertificationItem(reader);
            item.Certification = entry;
            List<CertificationItem> list = new List<CertificationItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            // Act
            CertificationContentCreator creator = new CertificationContentCreator(list, formatter, targetLanguageCode);

            // Assert
            Assert.IsNotNull(creator);
            Assert.AreEqual(list, creator.Certifications);
            Assert.AreEqual(formatter, creator.Formatter);
            Assert.AreEqual(targetLanguageCode, creator.TargetLanguageCode);
            Assert.AreEqual("Certification", creator.Headings["en"]);
            Assert.AreEqual("Altersfreigabe", creator.Headings["de"]);
        }

        [TestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CertificationContentCreatorTest_withCertificationsNull(string targetLanguageCode)
        {
            // Arrange
            Formatter formatter = new DokuWikiFormatter();
            CertificationContentCreator creator;

            // Act, Assert
            Assert.ThrowsException<NullReferenceException>(() => creator = new CertificationContentCreator(null, formatter, targetLanguageCode));
        }

        [TestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        public void CertificationContentCreatorTest_withFormatterNull(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Certification entry = new Certification(reader, id);
            CertificationItem item = new CertificationItem(reader);
            item.Certification = entry;
            List<CertificationItem> list = new List<CertificationItem>();
            list.Add(item);
            CertificationContentCreator creator;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => creator = new CertificationContentCreator(list, null, targetLanguageCode));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CertificationContentCreatorTest_withTargetLanguageCodeNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Certification entry = new Certification(reader, id);
            CertificationItem item = new CertificationItem(reader);
            item.Certification = entry;
            List<CertificationItem> list = new List<CertificationItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();
            CertificationContentCreator creator;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => creator = new CertificationContentCreator(list, formatter, null));
        }

        [TestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        public void CertificationContentCreatorTest_withTargetLanguageCodeEmptyString(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Certification entry = new Certification(reader, id);
            CertificationItem item = new CertificationItem(reader);
            item.Certification = entry;
            List<CertificationItem> list = new List<CertificationItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();
            CertificationContentCreator creator;

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => creator = new CertificationContentCreator(list, formatter, ""));
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
            Certification entry = new Certification(reader, id);
            CertificationItem item = new CertificationItem(reader);
            item.Certification = entry;
            List<CertificationItem> list = new List<CertificationItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            CertificationContentCreator creator = new CertificationContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            Assert.ThrowsException<NotSupportedException>(() => creator.GetPageName());
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
            Certification entry = new Certification(reader, id);
            CertificationItem item = new CertificationItem(reader);
            item.Certification = entry;
            List<CertificationItem> list = new List<CertificationItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            CertificationContentCreator creator = new CertificationContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            Assert.ThrowsException<NotSupportedException>(() => creator.CreatePage());
        }

        [TestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreateInfoBoxContentTest_withValidID(string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Certification entry = new Certification(reader, VALID_ID);
            entry.Retrieve(false);
            CertificationItem item = new CertificationItem(reader);
            item.Certification = entry;
            List<CertificationItem> list = new List<CertificationItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            CertificationContentCreator creator = new CertificationContentCreator(list, formatter, targetLanguageCode);

            List<string> testContent = new List<string>();

            string[] pathInfo = { "certification" };

            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Certification",
                                   formatter.AsImage(pathInfo, "Image FileName X", 75) }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Altersfreigabe",
                                   formatter.AsImage(pathInfo, "Image FileName X", 75) }));
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
            Certification entry = new Certification(reader, id);
            CertificationItem item = new CertificationItem(reader);
            item.Certification = entry;
            List<CertificationItem> list = new List<CertificationItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            CertificationContentCreator creator = new CertificationContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            Assert.ThrowsException<NotSupportedException>(() => creator.CreateChapterContent());
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
            Certification entry = new Certification(reader, id);
            CertificationItem item = new CertificationItem(reader);
            item.Certification = entry;
            List<CertificationItem> list = new List<CertificationItem>();
            list.Add(item);
            Formatter formatter = new DokuWikiFormatter();

            CertificationContentCreator creator = new CertificationContentCreator(list, formatter, targetLanguageCode);

            // Act, Assert
            Assert.ThrowsException<NotSupportedException>(() => creator.CreateSectionContent());
        }
    }
}
