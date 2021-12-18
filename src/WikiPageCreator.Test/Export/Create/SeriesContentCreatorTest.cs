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
    public class SeriesContentCreatorTests
    {
        public Formatter Formatter { get; set; } = new DokuWikiFormatter();

        [TestMethod()]
        public void SeriesContentCreatorTest()
        {
            // Arrange
            SeriesContentCreator creator = new SeriesContentCreator();

            // Act
            // Assert
            Assert.IsNotNull(creator);
        }

        [TestMethod()]
        public void GetFileNameTest()
        {
            // Arrange
            SeriesContentCreator creator = new SeriesContentCreator();
            Series series = new Series("_xxx");
            series.Retrieve(false);

            string testContent = $"{Formatter.AsPagename("Series OriginalTitle X (Seri)")}";

            // Act
            string content = creator.GetFileName(series, Formatter);

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
            SeriesContentCreator creator = new SeriesContentCreator();
            Series series = new Series("_xxx");
            series.Retrieve(false);

            List<string> testContent = new List<string>();
            string[] data = new string[2];
            string[] pathInfo = { value, "info" };
            string[] pathDate = { value, "date" };

            // File Header
            testContent.Add(Formatter.DisableCache());
            testContent.Add(Formatter.DisableTOC());
            testContent.Add(Formatter.BeginComment());
            testContent.Add($"   Series OriginalTitle X");
            testContent.Add($"");
            testContent.Add($"   @author  WikiPageCreator");
            testContent.Add($"   @date    {DateTime.Now:yyyy-MM-dd}");
            testContent.Add($"   @version Status EnglishTitle X: Series LastUpdated X");
            testContent.Add(Formatter.EndComment());
            testContent.Add($"");
            testContent.Add($"");

            // Title
            if (value.Equals("en"))
            {
                testContent.Add(Formatter.AsHeading1("Series EnglishTitle X"));
            }
            else if (value.Equals("de"))
            {
                testContent.Add(Formatter.AsHeading1("Series GermanTitle X"));
            }
            else
            {
                testContent.Add(Formatter.AsHeading1("Series OriginalTitle X"));
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
                data[1] = "Series OriginalTitle X";
            }
            else
            {
                data[0] = "Originaltitel";
                data[1] = "Series OriginalTitle X";
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

            // InfoBox ReleaseDate First Episode
            if (value.Equals("en"))
            {
                data[0] = "Release Date (First Episode)";
                data[1] = Formatter.AsInternalLink(pathDate, "Series ReleaseDateFirstEpisode X", "Series ReleaseDateFirstEpisode X");
            }
            else
            {
                data[0] = "Erstausstrahlung (Erste Folge)";
                data[1] = Formatter.AsInternalLink(pathDate, "Series ReleaseDateFirstEpisode X", "Series ReleaseDateFirstEpisode X");
            }
            testContent.Add(Formatter.AsTableRow(data));

            // InfoBox ReleaseDate Last Episode
            if (value.Equals("en"))
            {
                data[0] = "Release Date (Last Episode)";
                data[1] = Formatter.AsInternalLink(pathDate, "Series ReleaseDateLastEpisode X", "Series ReleaseDateLastEpisode X");
            }
            else
            {
                data[0] = "Erstausstrahlung (Letzte Folge)";
                data[1] = Formatter.AsInternalLink(pathDate, "Series ReleaseDateLastEpisode X", "Series ReleaseDateLastEpisode X");
            }
            testContent.Add(Formatter.AsTableRow(data));

            // InfoBox No of Seasons
            if (value.Equals("en"))
            {
                data[0] = "No of Seasons";
                data[1] = "Series NoOfSeasons X";
            }
            else
            {
                data[0] = "# Staffeln";
                data[1] = "Series NoOfSeasons X";
            }
            testContent.Add(Formatter.AsTableRow(data));

            // InfoBox No of Episodes
            if (value.Equals("en"))
            {
                data[0] = "No of Episodes";
                data[1] = "Series NoOfEpisodes X";
            }
            else
            {
                data[0] = "# Folgen";
                data[1] = "Series NoOfEpisodes X";
            }
            testContent.Add(Formatter.AsTableRow(data));

            // InfoBox Budget
            data[0] = "Budget";
            data[1] = "Series Budget X";
            testContent.Add(Formatter.AsTableRow(data));

            // InfoBox Worldwide Gross
            if (value.Equals("en"))
            {
                data[0] = "Worldwide Gross";
                data[1] = $"Series WorldwideGross X ({Formatter.AsInternalLink(pathDate, "Series WorldwideGrossDate X", "Series WorldwideGrossDate X")})";
            }
            else
            {
                data[0] = "Einspielergebnis (weltweit)";
                data[1] = $"Series WorldwideGross X ({Formatter.AsInternalLink(pathDate, "Series WorldwideGrossDate X", "Series WorldwideGrossDate X")})";
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
            List<string> content = creator.CreateFileContent(series, value, Formatter);

            // Assert
            //Assert.AreEqual(testContent.Count, content.Count);
            for (int i = 0; i < testContent.Count; i++)
            {
                Assert.AreEqual(testContent[i], content[i]);
            }
        }
    }
}
