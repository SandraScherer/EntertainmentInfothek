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
using WikiPageCreator.Export.Create;
using System;
using System.Collections.Generic;
using System.Text;
using WikiPageCreator.Export.Format;

namespace WikiPageCreator.Export.Create.IntegrationTests
{
    [TestClass()]
    public class MovieContentCreatorTests
    {
        public Formatter Formatter { get; set; } = new DokuWikiFormatter();

        [TestMethod()]
        public void MovieContentCreatorTest()
        {
            // Arrange
            MovieContentCreator creator = new MovieContentCreator();

            // Act
            // Assert
            Assert.IsNotNull(creator);
        }

        [TestMethod()]
        public void GetFileNameTest()
        {
            // Arrange
            MovieContentCreator creator = new MovieContentCreator();
            Movie movie = new Movie("_xxx");
            movie.Retrieve(false);

            string testContent = $"{Formatter.AsPagename("Movie OriginalTitle X (Movi)")}";

            // Act
            string content = creator.GetFileName(movie, Formatter);

            // Assert
            Assert.AreEqual(testContent, content);
        }

        [DataTestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreateFileContentTest(string value)
        {
            // Arrange
            MovieContentCreator creator = new MovieContentCreator();
            Movie movie = new Movie("_xxx");
            movie.Retrieve(false);

            List<string> testContent = new List<string>();
            string[] data = new string[2];
            string[] pathInfo = { value, "info" };
            string[] pathDate = { value, "date" };

            // File Header
            testContent.Add(Formatter.DisableCache());
            testContent.Add(Formatter.DisableTOC());
            testContent.Add(Formatter.BeginComment());
            testContent.Add($"   Movie OriginalTitle X");
            testContent.Add($"");
            testContent.Add($"   @author  WikiPageCreator");
            testContent.Add($"   @date    {DateTime.Now:yyyy-MM-dd}");
            testContent.Add($"   @version Status EnglishTitle X: Movie LastUpdated X");
            testContent.Add(Formatter.EndComment());
            testContent.Add($"");
            testContent.Add($"");

            // Title
            if (value.Equals("en"))
            {
                testContent.Add(Formatter.AsHeading1("Movie EnglishTitle X"));
            }
            else if (value.Equals("de"))
            {
                testContent.Add(Formatter.AsHeading1("Movie GermanTitle X"));
            }
            else
            {
                testContent.Add(Formatter.AsHeading1("Movie OriginalTitle X"));
            }
            testContent.Add($"");
            testContent.Add($"");

            // InfoBox Begin
            int[] width = { 30, 70 };
            testContent.Add(Formatter.BeginBox(475, Alignment.Right));
            testContent.Add(Formatter.DefineTable(445, width));

            // InfoBox Title
            if (value.Equals("en"))
            {
                data[0] = "Original Title";
                data[1] = "Movie OriginalTitle X";
            }
            else
            {
                data[0] = "Originaltitel";
                data[1] = "Movie OriginalTitle X";
            }
            testContent.Add(Formatter.AsTableRow(data));

            // InfoBox Type
            if (value.Equals("en"))
            {
                data[0] = "Type";
                data[1] = Formatter.AsInternalLink(pathInfo, "Type EnglishTitle X", "Type EnglishTitle X");
            }
            else
            {
                data[0] = "Typ";
                data[1] = Formatter.AsInternalLink(pathInfo, "Type EnglishTitle X", "Type GermanTitle X");
            }
            testContent.Add(Formatter.AsTableRow(data));

            // InfoBox ReleaseDate
            if (value.Equals("en"))
            {
                data[0] = "Original Release Date";
                data[1] = Formatter.AsInternalLink(pathDate, "Movie ReleaseDate X", "Movie ReleaseDate X");
            }
            else
            {
                data[0] = "Erstausstrahlung";
                data[1] = Formatter.AsInternalLink(pathDate, "Movie ReleaseDate X", "Movie ReleaseDate X");
            }
            testContent.Add(Formatter.AsTableRow(data));

            // InfoBox Budget
            data[0] = "Budget";
            data[1] = "Movie Budget X";
            testContent.Add(Formatter.AsTableRow(data));

            // InfoBox Worldwide Gross
            if (value.Equals("en"))
            {
                data[0] = "Worldwide Gross";
                data[1] = $"Movie WorldwideGross X ({Formatter.AsInternalLink(pathDate, "Movie WorldwideGrossDate X", "Movie WorldwideGrossDate X")})";
            }
            else
            {
                data[0] = "Einspielergebnis (weltweit)";
                data[1] = $"Movie WorldwideGross X ({Formatter.AsInternalLink(pathDate, "Movie WorldwideGrossDate X", "Movie WorldwideGrossDate X")})";
            }
            testContent.Add(Formatter.AsTableRow(data));

            // InfoBox End
            testContent.Add(Formatter.EndBox());
            testContent.Add($"");
            testContent.Add($"");

            // Connection Chapter
            if (value.Equals("en"))
            {
                testContent.Add(Formatter.AsHeading2("Connections to other articles"));
            }
            else
            {
                testContent.Add(Formatter.AsHeading2("Bezüge zu anderen Artikeln"));
            }
            testContent.Add(Formatter.AsInsertPage(value + ":navigation:_xxx"));
            testContent.Add($"");
            testContent.Add($"");

            // File Footer
            // nothing to do

            // Act
            List<string> content = creator.CreateFileContent(movie, value, Formatter);

            // Assert
            Assert.AreEqual(testContent.Count, content.Count);
            for (int i = 0; i < testContent.Count; i++)
            {
                Assert.AreEqual(testContent[i], content[i]);
            }
        }
    }
}
