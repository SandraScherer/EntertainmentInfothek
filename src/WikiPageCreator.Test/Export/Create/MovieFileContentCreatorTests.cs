// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
// Copyright (C) 2020 Sandra Scherer

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


using Microsoft.VisualStudio.TestTools.UnitTesting;
using WikiPageCreator.Export.Create;
using System;
using System.Collections.Generic;
using System.Text;
using EntertainmentDB.Data;
using WikiPageCreator.Export.Format;

namespace WikiPageCreator.Export.Create.Tests
{
    [TestClass()]
    public class MovieFileContentCreatorTests
    {
        public Formatter Formatter { get; set; } = new DokuWikiFormatter();

        [TestMethod()]
        public void MovieFileContentCreatorTest()
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            // Assert
            Assert.IsNotNull(creator);
        }

        [TestMethod()]
        public void GetFileNameTest()
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            string filename = creator.GetFileName();

            // Assert
            Assert.AreEqual(creator.Formatter.AsPagename($"{movie.OriginalTitle} ({movie.ReleaseDate[0..4]})"), filename);
        }

        [TestMethod()]
        public void CreateHeaderTest()
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateHeader("zz");

            // Assert
            List<string> content = new List<string>();

            content.Add(creator.Formatter.DisableCache());
            content.Add(creator.Formatter.DisableTOC());
            content.Add(creator.Formatter.BeginComment());
            content.Add($"   Movie Original Title X");
            content.Add($"");
            content.Add($"   @author  WikiPageCreator");
            content.Add($"   @date    {DateTime.Now:yyyy-MM-dd}");
            content.Add($"   @version Status English Title X: Movie Last Updated X");
            content.Add(creator.Formatter.EndComment());

            Assert.AreEqual(content.Count, creator.Content.Count);
            for (int i = 0; i < content.Count; i++)
            {
                Assert.AreEqual(content[i], creator.Content[i]);
            }
        }

        [TestMethod()]
        public void CreateFooterTest()
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateFooter("zz");

            // Assert
            List<string> content = new List<string>();

            Assert.AreEqual(content.Count, creator.Content.Count);
            for (int i = 0; i < content.Count; i++)
            {
                Assert.AreEqual(content[i], creator.Content[i]);
            }
        }

        [TestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreateTitleTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateTitle(value);

            // Assert
            List<string> content = new List<string>();

            content.Add("");
            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading1("Movie English Title X")); break;
                case "de": content.Add(Formatter.AsHeading1("Movie German Title X")); break;
                default:   content.Add(Formatter.AsHeading1("Movie Original Title X")); break;
            }
            content.Add("");

            Assert.AreEqual(content.Count, creator.Content.Count);
            for (int i = 0; i < content.Count; i++)
            {
                Assert.AreEqual(content[i], creator.Content[i]);
            }
        }

        [TestMethod()]
        public void CreateInfoBoxHeaderTest()
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxHeader("zz");

            // Assert
            List<string> content = new List<string>();
            int[] width = { 30, 70 };

            content.Add(Formatter.BeginBox(475, Alignment.Right));
            content.Add(Formatter.DefineTable(450, width));

            Assert.AreEqual(content.Count, creator.Content.Count);
            for (int i = 0; i < content.Count; i++)
            {
                Assert.AreEqual(content[i], creator.Content[i]);
            }
        }

        [TestMethod()]
        public void CreateInfoBoxEndTest()
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxEnd("zz");

            // Assert
            List<string> content = new List<string>();

            content.Add(Formatter.EndBox());
            content.Add("");

            Assert.AreEqual(content.Count, creator.Content.Count);
            for (int i = 0; i < content.Count; i++)
            {
                Assert.AreEqual(content[i], creator.Content[i]);
            }
        }

        [TestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreateInfoBoxTitleTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxTitle(value);

            // Assert
            List<string> content = new List<string>();
            string[] dataEn = { "Original Title", "Movie Original Title X" };
            string[] dataDe = { "Originaltitel", "Movie Original Title X" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsTableRow(dataEn)); break;
                case "de": content.Add(Formatter.AsTableRow(dataDe)); break;
                default: content.Add(Formatter.AsTableRow(dataDe)); break;
            }

            Assert.AreEqual(content.Count, creator.Content.Count);
            for (int i = 0; i < content.Count; i++)
            {
                Assert.AreEqual(content[i], creator.Content[i]);
            }
        }

        [TestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreateInfoBoxTypeTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxType(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "info" };
            string[] dataEn = { "Type", Formatter.AsInternalLink(path, "Type English Title X", "Type English Title X") };
            string[] dataDe = { "Typ", Formatter.AsInternalLink(path, "Type German Title X", "Type German Title X") };
            string[] dataZz = { "Typ", Formatter.AsInternalLink(path, "Type German Title X", "Type German Title X") };

            switch (value)
            {
                case "en": content.Add(Formatter.AsTableRow(dataEn)); break;
                case "de": content.Add(Formatter.AsTableRow(dataDe)); break;
                default: content.Add(Formatter.AsTableRow(dataZz)); break;
            }

            Assert.AreEqual(content.Count, creator.Content.Count);
            for (int i = 0; i < content.Count; i++)
            {
                Assert.AreEqual(content[i], creator.Content[i]);
            }
        }

        [TestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreateInfoBoxOriginalReleaseDateTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxOriginalReleaseDate(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "dates" };
            string[] dataEn = { "Original Release Date", Formatter.AsInternalLink(path, "Movie Release Date X", "Movie Release Date X") };
            string[] dataDe = { "Erstausstrahlung", Formatter.AsInternalLink(path, "Movie Release Date X", "Movie Release Date X") };
            string[] dataZz = { "Erstausstrahlung", Formatter.AsInternalLink(path, "Movie Release Date X", "Movie Release Date X") };

            switch (value)
            {
                case "en": content.Add(Formatter.AsTableRow(dataEn)); break;
                case "de": content.Add(Formatter.AsTableRow(dataDe)); break;
                default: content.Add(Formatter.AsTableRow(dataZz)); break;
            }

            Assert.AreEqual(content.Count, creator.Content.Count);
            for (int i = 0; i < content.Count; i++)
            {
                Assert.AreEqual(content[i], creator.Content[i]);
            }
        }

        [TestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreateContentTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateContent(value);

            // Assert
            List<string> content = new List<string>();
            int[] width = { 30, 70 };
            string[] dataTitleEn = { "Original Title", "Movie Original Title X" };
            string[] dataTitleDe = { "Originaltitel", "Movie Original Title X" };
            string[] pathType = { value, "info" };
            string[] dataTypeEn = { "Type", Formatter.AsInternalLink(pathType, "Type English Title X", "Type English Title X") };
            string[] dataTypeDe = { "Typ", Formatter.AsInternalLink(pathType, "Type German Title X", "Type German Title X") };
            string[] dataTypeZz = { "Typ", Formatter.AsInternalLink(pathType, "Type German Title X", "Type German Title X") };
            string[] pathRelease = { value, "dates" };
            string[] dataReleaseEn = { "Original Release Date", Formatter.AsInternalLink(pathRelease, "Movie Release Date X", "Movie Release Date X") };
            string[] dataReleaseDe = { "Erstausstrahlung", Formatter.AsInternalLink(pathRelease, "Movie Release Date X", "Movie Release Date X") };
            string[] dataReleaseZz = { "Erstausstrahlung", Formatter.AsInternalLink(pathRelease, "Movie Release Date X", "Movie Release Date X") };

            // Header
            content.Add(creator.Formatter.DisableCache());
            content.Add(creator.Formatter.DisableTOC());
            content.Add(creator.Formatter.BeginComment());
            content.Add($"   Movie Original Title X");
            content.Add($"");
            content.Add($"   @author  WikiPageCreator");
            content.Add($"   @date    {DateTime.Now:yyyy-MM-dd}");
            content.Add($"   @version Status English Title X: Movie Last Updated X");
            content.Add(creator.Formatter.EndComment());

            // Title
            content.Add("");
            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading1("Movie English Title X")); break;
                case "de": content.Add(Formatter.AsHeading1("Movie German Title X")); break;
                default: content.Add(Formatter.AsHeading1("Movie Original Title X")); break;
            }
            content.Add("");

            // InfoBox Header
            content.Add(Formatter.BeginBox(475, Alignment.Right));
            content.Add(Formatter.DefineTable(450, width));

            // InfoBox Title
            switch (value)
            {
                case "en": content.Add(Formatter.AsTableRow(dataTitleEn)); break;
                case "de": content.Add(Formatter.AsTableRow(dataTitleDe)); break;
                default: content.Add(Formatter.AsTableRow(dataTitleDe)); break;
            }

            // InfoBox Type
            switch (value)
            {
                case "en": content.Add(Formatter.AsTableRow(dataTypeEn)); break;
                case "de": content.Add(Formatter.AsTableRow(dataTypeDe)); break;
                default: content.Add(Formatter.AsTableRow(dataTypeZz)); break;
            }

            // InfoBox Release Date
            switch (value)
            {
                case "en": content.Add(Formatter.AsTableRow(dataReleaseEn)); break;
                case "de": content.Add(Formatter.AsTableRow(dataReleaseDe)); break;
                default: content.Add(Formatter.AsTableRow(dataReleaseZz)); break;
            }

            // InfoBox Ende
            content.Add(Formatter.EndBox());
            content.Add("");

            // Footer
            // nothing to do

            Assert.AreEqual(content.Count, creator.Content.Count);
            for (int i = 0; i < content.Count; i++)
            {
                Assert.AreEqual(content[i], creator.Content[i]);
            }
        }
    }
}
