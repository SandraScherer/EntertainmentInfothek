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


using EntertainmentDB.DBAccess.Read;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WikiPageCreator.Export.Format;
using Type = EntertainmentDB.Data.Type;

namespace WikiPageCreator.Export.Create.IntegrationTests
{
    [TestClass()]
    public class TypeContentCreatorTests_WithDB
    {
        const string VALID_ID = "_xxx";

        public Formatter Formatter { get; set; } = new DokuWikiFormatter();

        [TestMethod()]
        public void TypeContentCreatorTest()
        {
            // Arrange
            TypeContentCreator creator = new TypeContentCreator();

            // Act
            // Assert
            Assert.IsNotNull(creator);
        }

        [DataTestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreateInfoBoxContentTest_withValidID(string languageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Type type = new Type(reader, VALID_ID);
            type.Retrieve(false);

            TypeContentCreator creator = new TypeContentCreator();
            List<string> testContent = new List<string>();
            string[] path = { languageCode, "info" };
            string[] dataEn = { "Type", Formatter.AsInternalLink(path, "Type EnglishTitle X", "Type EnglishTitle X") };
            string[] dataDe = { "Typ", Formatter.AsInternalLink(path, "Type EnglishTitle X", "Type GermanTitle X") };

            if (languageCode.Equals("en"))
            {
                testContent.Add(Formatter.AsTableRow(dataEn));
            }
            else
            {
                testContent.Add(Formatter.AsTableRow(dataDe));
            }

            // Act
            List<string> content = creator.CreateInfoBoxContent(type, languageCode, Formatter);

            // Assert
            Assert.AreEqual(testContent.Count, content.Count);
            for (int i = 0; i < testContent.Count; i++)
            {
                Assert.AreEqual(testContent[i], content[i]);
            }
        }
    }
}
