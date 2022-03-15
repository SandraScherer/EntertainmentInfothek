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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WikiPageCreator.Export.Format;

namespace WikiPageCreator.Export.Create.IntegrationTests
{
    [TestClass()]
    public class ConnectionContentCreatorTests
    {
        public Formatter Formatter { get; set; } = new DokuWikiFormatter();

        [TestMethod()]
        public void ConnectionContentCreatorTest()
        {
            // Arrange
            ConnectionContentCreator creator = new ConnectionContentCreator();

            // Act
            // Assert
            Assert.IsNotNull(creator);
        }

        [DataTestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreateSectionContentTest(string value)
        {
            // Arrange
            ConnectionContentCreator creator = new ConnectionContentCreator();
            Connection connection = new Connection("_xxx");
            connection.Retrieve(false);

            List<string> testContent = new List<string>();

            testContent.Add(Formatter.AsInsertPage(value + ":navigation:_xxx"));
            testContent.Add("");
            testContent.Add("");

            // Act
            List<string> content = creator.CreateSectionContent(connection, value, Formatter);

            // Assert
            Assert.AreEqual(testContent.Count, content.Count);
            for (int i = 0; i < testContent.Count; i++)
            {
                Assert.AreEqual(testContent[i], content[i]);
            }
        }
    }
}
