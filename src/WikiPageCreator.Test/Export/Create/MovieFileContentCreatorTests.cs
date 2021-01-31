// WikiPageCreator.exe: Creates pages for use with a wiki from the
// EntertainmentInfothek.db using EntertainmentDB.dll
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
            content.Add($"");

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

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading1("Movie English Title X")); break;
                case "de": content.Add(Formatter.AsHeading1("Movie German Title X")); break;
                default: content.Add(Formatter.AsHeading1("Movie Original Title X")); break;
            }
            content.Add($"");

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
            content.Add(Formatter.DefineTable(445, width));

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
            content.Add($"");
            content.Add($"");

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
            string[] dataDe = { "Typ", Formatter.AsInternalLink(path, "Type English Title X", "Type German Title X") };
            string[] dataZz = { "Typ", Formatter.AsInternalLink(path, "Type English Title X", "Type German Title X") };

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
            string[] path = { value, "date" };
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
        public void CreateInfoBoxGenreTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxGenre(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "info" };
            string[] dataEn1 = { "Genre", Formatter.AsInternalLink(path, "Genre English Title X", "Genre English Title X") };
            string[] dataEn2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Genre English Title Y", "Genre English Title Y") };
            string[] dataEn3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Genre English Title Z", "Genre English Title Z") };
            string[] dataDe1 = { "Genre", Formatter.AsInternalLink(path, "Genre English Title X", "Genre German Title X") };
            string[] dataDe2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Genre English Title Y", "Genre German Title Y") };
            string[] dataDe3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Genre English Title Z", "Genre German Title Z") };
            string[] dataZz1 = { "Genre", Formatter.AsInternalLink(path, "Genre English Title X", "Genre German Title X") };
            string[] dataZz2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Genre English Title Y", "Genre German Title Y") };
            string[] dataZz3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Genre English Title Z", "Genre German Title Z") };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataEn1));
                    content.Add(Formatter.AsTableRow(dataEn2));
                    content.Add(Formatter.AsTableRow(dataEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataDe1));
                    content.Add(Formatter.AsTableRow(dataDe2));
                    content.Add(Formatter.AsTableRow(dataDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataZz1));
                    content.Add(Formatter.AsTableRow(dataZz2));
                    content.Add(Formatter.AsTableRow(dataZz3));
                    break;
            }

            Assert.AreEqual(content.Count, creator.Content.Count);
            for (int i = 0; i < content.Count; i++)
            {
                Assert.AreEqual(content[i], creator.Content[i]);
            }
        }

        [TestMethod]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreateInfoBoxCountryTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxCountry(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "info" };
            string[] dataEn1 = { "Production Country", Formatter.AsInternalLink(path, "Country Original Name X", "Country English Name X") };
            string[] dataEn2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Country Original Name Y", "Country English Name Y") };
            string[] dataEn3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Country Original Name Z", "Country English Name Z") };
            string[] dataDe1 = { "Produktionsland", Formatter.AsInternalLink(path, "Country Original Name X", "Country German Name X") };
            string[] dataDe2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Country Original Name Y", "Country German Name Y") };
            string[] dataDe3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Country Original Name Z", "Country German Name Z") };
            string[] dataZz1 = { "Produktionsland", Formatter.AsInternalLink(path, "Country Original Name X", "Country German Name X") };
            string[] dataZz2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Country Original Name Y", "Country German Name Y") };
            string[] dataZz3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Country Original Name Z", "Country German Name Z") };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataEn1));
                    content.Add(Formatter.AsTableRow(dataEn2));
                    content.Add(Formatter.AsTableRow(dataEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataDe1));
                    content.Add(Formatter.AsTableRow(dataDe2));
                    content.Add(Formatter.AsTableRow(dataDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataZz1));
                    content.Add(Formatter.AsTableRow(dataZz2));
                    content.Add(Formatter.AsTableRow(dataZz3));
                    break;
            }

            Assert.AreEqual(content.Count, creator.Content.Count);
            for (int i = 0; i < content.Count; i++)
            {
                Assert.AreEqual(content[i], creator.Content[i]);
            }
        }

        [TestMethod]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreateInfoBoxLanguageTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxLanguage(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "info" };
            string[] dataEn1 = { "Language", Formatter.AsInternalLink(path, "Language Original Name X", "Language English Name X") };
            string[] dataEn2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Language Original Name Y", "Language English Name Y") };
            string[] dataEn3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Language Original Name Z", "Language English Name Z") };
            string[] dataDe1 = { "Sprache", Formatter.AsInternalLink(path, "Language Original Name X", "Language German Name X") };
            string[] dataDe2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Language Original Name Y", "Language German Name Y") };
            string[] dataDe3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Language Original Name Z", "Language German Name Z") };
            string[] dataZz1 = { "Sprache", Formatter.AsInternalLink(path, "Language Original Name X", "Language German Name X") };
            string[] dataZz2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Language Original Name Y", "Language German Name Y") };
            string[] dataZz3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Language Original Name Z", "Language German Name Z") };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataEn1));
                    content.Add(Formatter.AsTableRow(dataEn2));
                    content.Add(Formatter.AsTableRow(dataEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataDe1));
                    content.Add(Formatter.AsTableRow(dataDe2));
                    content.Add(Formatter.AsTableRow(dataDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataZz1));
                    content.Add(Formatter.AsTableRow(dataZz2));
                    content.Add(Formatter.AsTableRow(dataZz3));
                    break;
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
        public void CreateInfoBoxBudgetTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxBudget(value);

            // Assert
            List<string> content = new List<string>();
            string[] dataEn = { "Budget", $"Movie Budget X" };
            string[] dataDe = { "Budget", $"Movie Budget X" };
            string[] dataZz = { "Budget", $"Movie Budget X" };

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
        public void CreateInfoBoxWorldwideGrossTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxWorldwideGross(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "date" };
            string[] dataEn = { "Worldwide Gross", $"Movie Worldwide Gross X ({Formatter.AsInternalLink(path, "Movie Worldwide Gross Date X", "Movie Worldwide Gross Date X")})" };
            string[] dataDe = { "Einspielergebnis (weltweit)", $"Movie Worldwide Gross X ({Formatter.AsInternalLink(path, "Movie Worldwide Gross Date X", "Movie Worldwide Gross Date X")})" };
            string[] dataZz = { "Einspielergebnis (weltweit)", $"Movie Worldwide Gross X ({Formatter.AsInternalLink(path, "Movie Worldwide Gross Date X", "Movie Worldwide Gross Date X")})" };

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
        public void CreateInfoBoxRuntimeTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxRuntime(value);

            List<string> content = new List<string>();
            string[] path = { value, "info" };
            string[] dataEn1 = { "Runtime", $"1 min. ({Formatter.AsInternalLink(path, "Edition English Title X", "Edition English Title X")})" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(path, "Edition English Title Y", "Edition English Title Y")})" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(path, "Edition English Title Z", "Edition English Title Z")})" };
            string[] dataDe1 = { "Laufzeit", $"1 min. ({Formatter.AsInternalLink(path, "Edition English Title X", "Edition German Title X")})" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(path, "Edition English Title Y", "Edition German Title Y")})" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(path, "Edition English Title Z", "Edition German Title Z")})" };
            string[] dataZz1 = { "Laufzeit", $"1 min. ({Formatter.AsInternalLink(path, "Edition English Title X", "Edition German Title X")})" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(path, "Edition English Title Y", "Edition German Title Y")})" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(path, "Edition English Title Z", "Edition German Title Z")})" };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataEn1));
                    content.Add(Formatter.AsTableRow(dataEn2));
                    content.Add(Formatter.AsTableRow(dataEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataDe1));
                    content.Add(Formatter.AsTableRow(dataDe2));
                    content.Add(Formatter.AsTableRow(dataDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataZz1));
                    content.Add(Formatter.AsTableRow(dataZz2));
                    content.Add(Formatter.AsTableRow(dataZz3));
                    break;
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
        public void CreateInfoBoxSoundMixTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxSoundMix(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "info" };
            string[] dataEn1 = { "Sound Mix", Formatter.AsInternalLink(path, "Sound Mix English Title X", "Sound Mix English Title X") };
            string[] dataEn2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Sound Mix English Title Y", "Sound Mix English Title Y") };
            string[] dataEn3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Sound Mix English Title Z", "Sound Mix English Title Z") };
            string[] dataDe1 = { "Tonmischung", Formatter.AsInternalLink(path, "Sound Mix English Title X", "Sound Mix German Title X") };
            string[] dataDe2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Sound Mix English Title Y", "Sound Mix German Title Y") };
            string[] dataDe3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Sound Mix English Title Z", "Sound Mix German Title Z") };
            string[] dataZz1 = { "Tonmischung", Formatter.AsInternalLink(path, "Sound Mix English Title X", "Sound Mix German Title X") };
            string[] dataZz2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Sound Mix English Title Y", "Sound Mix German Title Y") };
            string[] dataZz3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Sound Mix English Title Z", "Sound Mix German Title Z") };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataEn1));
                    content.Add(Formatter.AsTableRow(dataEn2));
                    content.Add(Formatter.AsTableRow(dataEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataDe1));
                    content.Add(Formatter.AsTableRow(dataDe2));
                    content.Add(Formatter.AsTableRow(dataDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataZz1));
                    content.Add(Formatter.AsTableRow(dataZz2));
                    content.Add(Formatter.AsTableRow(dataZz3));
                    break;
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
        public void CreateInfoBoxColorTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxColor(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "info" };
            string[] dataEn1 = { "Color", Formatter.AsInternalLink(path, "Color English Title X", "Color English Title X") };
            string[] dataEn2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Color English Title Y", "Color English Title Y") };
            string[] dataEn3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Color English Title Z", "Color English Title Z") };
            string[] dataDe1 = { "Farbe", Formatter.AsInternalLink(path, "Color English Title X", "Color German Title X") };
            string[] dataDe2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Color English Title Y", "Color German Title Y") };
            string[] dataDe3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Color English Title Z", "Color German Title Z") };
            string[] dataZz1 = { "Farbe", Formatter.AsInternalLink(path, "Color English Title X", "Color German Title X") };
            string[] dataZz2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Color English Title Y", "Color German Title Y") };
            string[] dataZz3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(path, "Color English Title Z", "Color German Title Z") };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataEn1));
                    content.Add(Formatter.AsTableRow(dataEn2));
                    content.Add(Formatter.AsTableRow(dataEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataDe1));
                    content.Add(Formatter.AsTableRow(dataDe2));
                    content.Add(Formatter.AsTableRow(dataDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataZz1));
                    content.Add(Formatter.AsTableRow(dataZz2));
                    content.Add(Formatter.AsTableRow(dataZz3));
                    break;
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
        public void CreateInfoBoxAspectRatioTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxAspectRatio(value);

            // Assert
            List<string> content = new List<string>();
            string[] dataEn1 = { "Aspect Ratio", "Aspect Ratio X Movie Aspect Ratio Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), "Aspect Ratio Y Movie Aspect Ratio Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), "Aspect Ratio Z Movie Aspect Ratio Details X3" };
            string[] dataDe1 = { "Bildformat", "Aspect Ratio X Movie Aspect Ratio Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), "Aspect Ratio Y Movie Aspect Ratio Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), "Aspect Ratio Z Movie Aspect Ratio Details X3" };
            string[] dataZz1 = { "Bildformat", "Aspect Ratio X Movie Aspect Ratio Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), "Aspect Ratio Y Movie Aspect Ratio Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), "Aspect Ratio Z Movie Aspect Ratio Details X3" };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataEn1));
                    content.Add(Formatter.AsTableRow(dataEn2));
                    content.Add(Formatter.AsTableRow(dataEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataDe1));
                    content.Add(Formatter.AsTableRow(dataDe2));
                    content.Add(Formatter.AsTableRow(dataDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataZz1));
                    content.Add(Formatter.AsTableRow(dataZz2));
                    content.Add(Formatter.AsTableRow(dataZz3));
                    break;
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
        public void CreateInfoBoxCameraTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxCamera(value);

            // Assert
            List<string> content = new List<string>();
            string[] dataEn1 = { "Camera", "Camera Name X, Camera Lense X" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), "Camera Name Y, Camera Lense Y" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), "Camera Name Z, Camera Lense Z" };
            string[] dataDe1 = { "Kamera", "Camera Name X, Camera Lense X" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), "Camera Name Y, Camera Lense Y" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), "Camera Name Z, Camera Lense Z" };
            string[] dataZz1 = { "Kamera", "Camera Name X, Camera Lense X" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), "Camera Name Y, Camera Lense Y" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), "Camera Name Z, Camera Lense Z" };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataEn1));
                    content.Add(Formatter.AsTableRow(dataEn2));
                    content.Add(Formatter.AsTableRow(dataEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataDe1));
                    content.Add(Formatter.AsTableRow(dataDe2));
                    content.Add(Formatter.AsTableRow(dataDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataZz1));
                    content.Add(Formatter.AsTableRow(dataZz2));
                    content.Add(Formatter.AsTableRow(dataZz3));
                    break;
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
        public void CreateInfoBoxLaboratoryTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxLaboratory(value);

            // Assert
            List<string> content = new List<string>();
            string[] dataEn1 = { "Laboratory", "Laboratory Name X" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), "Laboratory Name Y" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), "Laboratory Name Z" };
            string[] dataDe1 = { "Labor", "Laboratory Name X" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), "Laboratory Name Y" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), "Laboratory Name Z" };
            string[] dataZz1 = { "Labor", "Laboratory Name X" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), "Laboratory Name Y" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), "Laboratory Name Z" };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataEn1));
                    content.Add(Formatter.AsTableRow(dataEn2));
                    content.Add(Formatter.AsTableRow(dataEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataDe1));
                    content.Add(Formatter.AsTableRow(dataDe2));
                    content.Add(Formatter.AsTableRow(dataDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataZz1));
                    content.Add(Formatter.AsTableRow(dataZz2));
                    content.Add(Formatter.AsTableRow(dataZz3));
                    break;
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
        public void CreateInfoBoxFilmLengthTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxFilmLength(value);

            // Assert
            List<string> content = new List<string>();
            string[] dataEn1 = { "Film Length", "Movie Film Length X" };
            //string[] dataEn2 = { Formatter.CellSpanVertically(), "Movie Film Length Y" };
            //string[] dataEn3 = { Formatter.CellSpanVertically(), "Movie Film Length Z" };
            string[] dataDe1 = { "Filmlänge", "Movie Film Length X" };
            //string[] dataDe2 = { Formatter.CellSpanVertically(), "Movie Film Length Y" };
            //string[] dataDe3 = { Formatter.CellSpanVertically(), "Movie Film Length Z" };
            string[] dataZz1 = { "Filmlänge", "Movie Film Length X" };
            //string[] dataZz2 = { Formatter.CellSpanVertically(), "Movie Film Length Y" };
            //string[] dataZz3 = { Formatter.CellSpanVertically(), "Movie Film Length Z" };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataEn1));
                    //content.Add(Formatter.AsTableRow(dataEn2));
                    //content.Add(Formatter.AsTableRow(dataEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataDe1));
                    //content.Add(Formatter.AsTableRow(dataDe2));
                    //content.Add(Formatter.AsTableRow(dataDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataZz1));
                    //content.Add(Formatter.AsTableRow(dataZz2));
                    //content.Add(Formatter.AsTableRow(dataZz3));
                    break;
            }

            Assert.AreEqual(content.Count, creator.Content.Count);
            for (int i = 0; i < content.Count; i++)
            {
                Assert.AreEqual(content[i], creator.Content[i]);
            }
        }

        [TestMethod]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreateCastAndCrewChapterTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateCastAndCrewChapter(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "biography" };
            string[] dataDirector1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Director Role X1) Movie Director Details X1" };
            string[] dataDirector2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Director Role X2) Movie Director Details X2" };
            string[] dataDirector3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Director Role X3) Movie Director Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Cast and Crew")); break;
                case "de": content.Add(Formatter.AsHeading2("Darsteller und Mannschaft")); break;
                default: content.Add(Formatter.AsHeading2("Darsteller und Mannschaft")); break;
            }
            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Director")); break;
                case "de": content.Add(Formatter.AsHeading3("Regie")); break;
                default: content.Add(Formatter.AsHeading3("Regie")); break;
            }
            content.Add(Formatter.AsTableRow(dataDirector1));
            content.Add(Formatter.AsTableRow(dataDirector2));
            content.Add(Formatter.AsTableRow(dataDirector3));
            content.Add($"");
            content.Add($"");

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
        public void CreateConnectionChapterTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateConnectionChapter(value);

            // Assert
            List<string> content = new List<string>();

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Connections to other articles")); break;
                case "de": content.Add(Formatter.AsHeading2("Bezüge zu anderen Artikeln")); break;
                default: content.Add(Formatter.AsHeading2("Bezüge zu anderen Artikeln")); break;
            }
            content.Add(Formatter.AsInsertPage(value + ":navigation:_xxx"));
            content.Add($"");
            content.Add($"");

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
            string[] dataTypeDe = { "Typ", Formatter.AsInternalLink(pathType, "Type English Title X", "Type German Title X") };
            string[] dataTypeZz = { "Typ", Formatter.AsInternalLink(pathType, "Type English Title X", "Type German Title X") };

            string[] pathRelease = { value, "date" };
            string[] dataReleaseEn = { "Original Release Date", Formatter.AsInternalLink(pathRelease, "Movie Release Date X", "Movie Release Date X") };
            string[] dataReleaseDe = { "Erstausstrahlung", Formatter.AsInternalLink(pathRelease, "Movie Release Date X", "Movie Release Date X") };
            string[] dataReleaseZz = { "Erstausstrahlung", Formatter.AsInternalLink(pathRelease, "Movie Release Date X", "Movie Release Date X") };

            string[] pathGenre = { value, "info" };
            string[] dataGenreEn1 = { "Genre", Formatter.AsInternalLink(pathGenre, "Genre English Title X", "Genre English Title X") };
            string[] dataGenreEn2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathGenre, "Genre English Title Y", "Genre English Title Y") };
            string[] dataGenreEn3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathGenre, "Genre English Title Z", "Genre English Title Z") };
            string[] dataGenreDe1 = { "Genre", Formatter.AsInternalLink(pathGenre, "Genre English Title X", "Genre German Title X") };
            string[] dataGenreDe2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathGenre, "Genre English Title Y", "Genre German Title Y") };
            string[] dataGenreDe3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathGenre, "Genre English Title Z", "Genre German Title Z") };
            string[] dataGenreZz1 = { "Genre", Formatter.AsInternalLink(pathGenre, "Genre English Title X", "Genre German Title X") };
            string[] dataGenreZz2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathGenre, "Genre English Title Y", "Genre German Title Y") };
            string[] dataGenreZz3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathGenre, "Genre English Title Z", "Genre German Title Z") };

            string[] pathCountry = { value, "info" };
            string[] dataCountryEn1 = { "Production Country", Formatter.AsInternalLink(pathCountry, "Country Original Name X", "Country English Name X") };
            string[] dataCountryEn2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathCountry, "Country Original Name Y", "Country English Name Y") };
            string[] dataCountryEn3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathCountry, "Country Original Name Z", "Country English Name Z") };
            string[] dataCountryDe1 = { "Produktionsland", Formatter.AsInternalLink(pathCountry, "Country Original Name X", "Country German Name X") };
            string[] dataCountryDe2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathCountry, "Country Original Name Y", "Country German Name Y") };
            string[] dataCountryDe3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathCountry, "Country Original Name Z", "Country German Name Z") };
            string[] dataCountryZz1 = { "Produktionsland", Formatter.AsInternalLink(pathCountry, "Country Original Name X", "Country German Name X") };
            string[] dataCountryZz2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathCountry, "Country Original Name Y", "Country German Name Y") };
            string[] dataCountryZz3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathCountry, "Country Original Name Z", "Country German Name Z") };

            string[] pathLanguage = { value, "info" };
            string[] dataLanguageEn1 = { "Language", Formatter.AsInternalLink(pathLanguage, "Language Original Name X", "Language English Name X") };
            string[] dataLanguageEn2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathLanguage, "Language Original Name Y", "Language English Name Y") };
            string[] dataLanguageEn3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathLanguage, "Language Original Name Z", "Language English Name Z") };
            string[] dataLanguageDe1 = { "Sprache", Formatter.AsInternalLink(pathLanguage, "Language Original Name X", "Language German Name X") };
            string[] dataLanguageDe2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathLanguage, "Language Original Name Y", "Language German Name Y") };
            string[] dataLanguageDe3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathLanguage, "Language Original Name Z", "Language German Name Z") };
            string[] dataLanguageZz1 = { "Sprache", Formatter.AsInternalLink(pathLanguage, "Language Original Name X", "Language German Name X") };
            string[] dataLanguageZz2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathLanguage, "Language Original Name Y", "Language German Name Y") };
            string[] dataLanguageZz3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathLanguage, "Language Original Name Z", "Language German Name Z") };

            string[] dataBudgetEn = { "Budget", $"Movie Budget X" };
            string[] dataBudgetDe = { "Budget", $"Movie Budget X" };
            string[] dataBudgetZz = { "Budget", $"Movie Budget X" };

            string[] pathGross = { value, "date" };
            string[] dataGrossEn = { "Worldwide Gross", $"Movie Worldwide Gross X ({Formatter.AsInternalLink(pathGross, "Movie Worldwide Gross Date X", "Movie Worldwide Gross Date X")})" };
            string[] dataGrossDe = { "Einspielergebnis (weltweit)", $"Movie Worldwide Gross X ({Formatter.AsInternalLink(pathGross, "Movie Worldwide Gross Date X", "Movie Worldwide Gross Date X")})" };
            string[] dataGrossZz = { "Einspielergebnis (weltweit)", $"Movie Worldwide Gross X ({Formatter.AsInternalLink(pathGross, "Movie Worldwide Gross Date X", "Movie Worldwide Gross Date X")})" };

            string[] pathRuntime = { value, "info" };
            string[] dataRuntimeEn1 = { "Runtime", $"1 min. ({Formatter.AsInternalLink(pathRuntime, "Edition English Title X", "Edition English Title X")})" };
            string[] dataRuntimeEn2 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(pathRuntime, "Edition English Title Y", "Edition English Title Y")})" };
            string[] dataRuntimeEn3 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(pathRuntime, "Edition English Title Z", "Edition English Title Z")})" };
            string[] dataRuntimeDe1 = { "Laufzeit", $"1 min. ({Formatter.AsInternalLink(pathRuntime, "Edition English Title X", "Edition German Title X")})" };
            string[] dataRuntimeDe2 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(pathRuntime, "Edition English Title Y", "Edition German Title Y")})" };
            string[] dataRuntimeDe3 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(pathRuntime, "Edition English Title Z", "Edition German Title Z")})" };
            string[] dataRuntimeZz1 = { "Laufzeit", $"1 min. ({Formatter.AsInternalLink(pathRuntime, "Edition English Title X", "Edition German Title X")})" };
            string[] dataRuntimeZz2 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(pathRuntime, "Edition English Title Y", "Edition German Title Y")})" };
            string[] dataRuntimeZz3 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(pathRuntime, "Edition English Title Z", "Edition German Title Z")})" };

            string[] pathSoundMix = { value, "info" };
            string[] dataSoundMixEn1 = { "Sound Mix", Formatter.AsInternalLink(pathSoundMix, "Sound Mix English Title X", "Sound Mix English Title X") };
            string[] dataSoundMixEn2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathSoundMix, "Sound Mix English Title Y", "Sound Mix English Title Y") };
            string[] dataSoundMixEn3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathSoundMix, "Sound Mix English Title Z", "Sound Mix English Title Z") };
            string[] dataSoundMixDe1 = { "Tonmischung", Formatter.AsInternalLink(pathSoundMix, "Sound Mix English Title X", "Sound Mix German Title X") };
            string[] dataSoundMixDe2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathSoundMix, "Sound Mix English Title Y", "Sound Mix German Title Y") };
            string[] dataSoundMixDe3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathSoundMix, "Sound Mix English Title Z", "Sound Mix German Title Z") };
            string[] dataSoundMixZz1 = { "Tonmischung", Formatter.AsInternalLink(pathSoundMix, "Sound Mix English Title X", "Sound Mix German Title X") };
            string[] dataSoundMixZz2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathSoundMix, "Sound Mix English Title Y", "Sound Mix German Title Y") };
            string[] dataSoundMixZz3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathSoundMix, "Sound Mix English Title Z", "Sound Mix German Title Z") };

            string[] pathColor = { value, "info" };
            string[] dataColorEn1 = { "Color", Formatter.AsInternalLink(pathColor, "Color English Title X", "Color English Title X") };
            string[] dataColorEn2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathColor, "Color English Title Y", "Color English Title Y") };
            string[] dataColorEn3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathColor, "Color English Title Z", "Color English Title Z") };
            string[] dataColorDe1 = { "Farbe", Formatter.AsInternalLink(pathColor, "Color English Title X", "Color German Title X") };
            string[] dataColorDe2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathColor, "Color English Title Y", "Color German Title Y") };
            string[] dataColorDe3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathColor, "Color English Title Z", "Color German Title Z") };
            string[] dataColorZz1 = { "Farbe", Formatter.AsInternalLink(pathColor, "Color English Title X", "Color German Title X") };
            string[] dataColorZz2 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathColor, "Color English Title Y", "Color German Title Y") };
            string[] dataColorZz3 = { Formatter.CellSpanVertically(), Formatter.AsInternalLink(pathColor, "Color English Title Z", "Color German Title Z") };

            string[] dataAspectRatioEn1 = { "Aspect Ratio", "Aspect Ratio X Movie Aspect Ratio Details X1" };
            string[] dataAspectRatioEn2 = { Formatter.CellSpanVertically(), "Aspect Ratio Y Movie Aspect Ratio Details X2" };
            string[] dataAspectRatioEn3 = { Formatter.CellSpanVertically(), "Aspect Ratio Z Movie Aspect Ratio Details X3" };
            string[] dataAspectRatioDe1 = { "Bildformat", "Aspect Ratio X Movie Aspect Ratio Details X1" };
            string[] dataAspectRatioDe2 = { Formatter.CellSpanVertically(), "Aspect Ratio Y Movie Aspect Ratio Details X2" };
            string[] dataAspectRatioDe3 = { Formatter.CellSpanVertically(), "Aspect Ratio Z Movie Aspect Ratio Details X3" };
            string[] dataAspectRatioZz1 = { "Bildformat", "Aspect Ratio X Movie Aspect Ratio Details X1" };
            string[] dataAspectRatioZz2 = { Formatter.CellSpanVertically(), "Aspect Ratio Y Movie Aspect Ratio Details X2" };
            string[] dataAspectRatioZz3 = { Formatter.CellSpanVertically(), "Aspect Ratio Z Movie Aspect Ratio Details X3" };

            string[] dataCameraEn1 = { "Camera", "Camera Name X, Camera Lense X" };
            string[] dataCameraEn2 = { Formatter.CellSpanVertically(), "Camera Name Y, Camera Lense Y" };
            string[] dataCameraEn3 = { Formatter.CellSpanVertically(), "Camera Name Z, Camera Lense Z" };
            string[] dataCameraDe1 = { "Kamera", "Camera Name X, Camera Lense X" };
            string[] dataCameraDe2 = { Formatter.CellSpanVertically(), "Camera Name Y, Camera Lense Y" };
            string[] dataCameraDe3 = { Formatter.CellSpanVertically(), "Camera Name Z, Camera Lense Z" };
            string[] dataCameraZz1 = { "Kamera", "Camera Name X, Camera Lense X" };
            string[] dataCameraZz2 = { Formatter.CellSpanVertically(), "Camera Name Y, Camera Lense Y" };
            string[] dataCameraZz3 = { Formatter.CellSpanVertically(), "Camera Name Z, Camera Lense Z" };

            string[] dataLaboratoryEn1 = { "Laboratory", "Laboratory Name X" };
            string[] dataLaboratoryEn2 = { Formatter.CellSpanVertically(), "Laboratory Name Y" };
            string[] dataLaboratoryEn3 = { Formatter.CellSpanVertically(), "Laboratory Name Z" };
            string[] dataLaboratoryDe1 = { "Labor", "Laboratory Name X" };
            string[] dataLaboratoryDe2 = { Formatter.CellSpanVertically(), "Laboratory Name Y" };
            string[] dataLaboratoryDe3 = { Formatter.CellSpanVertically(), "Laboratory Name Z" };
            string[] dataLaboratoryZz1 = { "Labor", "Laboratory Name X" };
            string[] dataLaboratoryZz2 = { Formatter.CellSpanVertically(), "Laboratory Name Y" };
            string[] dataLaboratoryZz3 = { Formatter.CellSpanVertically(), "Laboratory Name Z" };

            string[] dataFilmLengthEn1 = { "Film Length", "Movie Film Length X" };
            //string[] dataFilmLengthEn2 = { Formatter.CellSpanVertically(), "Movie Film Length Y" };
            //string[] dataFilmLengthEn3 = { Formatter.CellSpanVertically(), "Movie Film Length Z" };
            string[] dataFilmLengthDe1 = { "Filmlänge", "Movie Film Length X" };
            //string[] dataFilmLengthDe2 = { Formatter.CellSpanVertically(), "Movie Film Length Y" };
            //string[] dataFilmLengthDe3 = { Formatter.CellSpanVertically(), "Movie Film Length Z" };
            string[] dataFilmLengthZz1 = { "Filmlänge", "Movie Film Length X" };
            //string[] dataFilmLengthZz2 = { Formatter.CellSpanVertically(), "Movie Film Length Y" };
            //string[] dataFilmLengthZz3 = { Formatter.CellSpanVertically(), "Movie Film Length Z" };

            string[] pathDirector = { value, "biography" };
            string[] dataDirector1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Director Role X1) Movie Director Details X1" };
            string[] dataDirector2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Director Role X2) Movie Director Details X2" };
            string[] dataDirector3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Director Role X3) Movie Director Details X3" };

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
            content.Add("");

            // Title
            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading1("Movie English Title X")); break;
                case "de": content.Add(Formatter.AsHeading1("Movie German Title X")); break;
                default: content.Add(Formatter.AsHeading1("Movie Original Title X")); break;
            }
            content.Add("");

            // InfoBox Header
            content.Add(Formatter.BeginBox(475, Alignment.Right));
            content.Add(Formatter.DefineTable(445, width));

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

            // InfoBox Genre
            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataGenreEn1));
                    content.Add(Formatter.AsTableRow(dataGenreEn2));
                    content.Add(Formatter.AsTableRow(dataGenreEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataGenreDe1));
                    content.Add(Formatter.AsTableRow(dataGenreDe2));
                    content.Add(Formatter.AsTableRow(dataGenreDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataGenreZz1));
                    content.Add(Formatter.AsTableRow(dataGenreZz2));
                    content.Add(Formatter.AsTableRow(dataGenreZz3));
                    break;
            }

            // InfoBox Country
            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataCountryEn1));
                    content.Add(Formatter.AsTableRow(dataCountryEn2));
                    content.Add(Formatter.AsTableRow(dataCountryEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataCountryDe1));
                    content.Add(Formatter.AsTableRow(dataCountryDe2));
                    content.Add(Formatter.AsTableRow(dataCountryDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataCountryZz1));
                    content.Add(Formatter.AsTableRow(dataCountryZz2));
                    content.Add(Formatter.AsTableRow(dataCountryZz3));
                    break;
            }

            // InfoBox Language
            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataLanguageEn1));
                    content.Add(Formatter.AsTableRow(dataLanguageEn2));
                    content.Add(Formatter.AsTableRow(dataLanguageEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataLanguageDe1));
                    content.Add(Formatter.AsTableRow(dataLanguageDe2));
                    content.Add(Formatter.AsTableRow(dataLanguageDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataLanguageZz1));
                    content.Add(Formatter.AsTableRow(dataLanguageZz2));
                    content.Add(Formatter.AsTableRow(dataLanguageZz3));
                    break;
            }

            // InfoBox Budget
            switch (value)
            {
                case "en": content.Add(Formatter.AsTableRow(dataBudgetEn)); break;
                case "de": content.Add(Formatter.AsTableRow(dataBudgetDe)); break;
                default: content.Add(Formatter.AsTableRow(dataBudgetZz)); break;
            }

            // InfoBox Worldwide Gross
            switch (value)
            {
                case "en": content.Add(Formatter.AsTableRow(dataGrossEn)); break;
                case "de": content.Add(Formatter.AsTableRow(dataGrossDe)); break;
                default: content.Add(Formatter.AsTableRow(dataGrossZz)); break;
            }

            // InfoBox Runtime
            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataRuntimeEn1));
                    content.Add(Formatter.AsTableRow(dataRuntimeEn2));
                    content.Add(Formatter.AsTableRow(dataRuntimeEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataRuntimeDe1));
                    content.Add(Formatter.AsTableRow(dataRuntimeDe2));
                    content.Add(Formatter.AsTableRow(dataRuntimeDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataRuntimeZz1));
                    content.Add(Formatter.AsTableRow(dataRuntimeZz2));
                    content.Add(Formatter.AsTableRow(dataRuntimeZz3));
                    break;
            }

            // InfoBox Sound Mix
            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataSoundMixEn1));
                    content.Add(Formatter.AsTableRow(dataSoundMixEn2));
                    content.Add(Formatter.AsTableRow(dataSoundMixEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataSoundMixDe1));
                    content.Add(Formatter.AsTableRow(dataSoundMixDe2));
                    content.Add(Formatter.AsTableRow(dataSoundMixDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataSoundMixZz1));
                    content.Add(Formatter.AsTableRow(dataSoundMixZz2));
                    content.Add(Formatter.AsTableRow(dataSoundMixZz3));
                    break;
            }

            // InfoBox Color
            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataColorEn1));
                    content.Add(Formatter.AsTableRow(dataColorEn2));
                    content.Add(Formatter.AsTableRow(dataColorEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataColorDe1));
                    content.Add(Formatter.AsTableRow(dataColorDe2));
                    content.Add(Formatter.AsTableRow(dataColorDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataColorZz1));
                    content.Add(Formatter.AsTableRow(dataColorZz2));
                    content.Add(Formatter.AsTableRow(dataColorZz3));
                    break;
            }

            // InfoBox AspectRatio
            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataAspectRatioEn1));
                    content.Add(Formatter.AsTableRow(dataAspectRatioEn2));
                    content.Add(Formatter.AsTableRow(dataAspectRatioEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataAspectRatioDe1));
                    content.Add(Formatter.AsTableRow(dataAspectRatioDe2));
                    content.Add(Formatter.AsTableRow(dataAspectRatioDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataAspectRatioZz1));
                    content.Add(Formatter.AsTableRow(dataAspectRatioZz2));
                    content.Add(Formatter.AsTableRow(dataAspectRatioZz3));
                    break;
            }

            // Infobox Camera
            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataCameraEn1));
                    content.Add(Formatter.AsTableRow(dataCameraEn2));
                    content.Add(Formatter.AsTableRow(dataCameraEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataCameraDe1));
                    content.Add(Formatter.AsTableRow(dataCameraDe2));
                    content.Add(Formatter.AsTableRow(dataCameraDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataCameraZz1));
                    content.Add(Formatter.AsTableRow(dataCameraZz2));
                    content.Add(Formatter.AsTableRow(dataCameraZz3));
                    break;
            }

            // Infobox Laboratory
            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataLaboratoryEn1));
                    content.Add(Formatter.AsTableRow(dataLaboratoryEn2));
                    content.Add(Formatter.AsTableRow(dataLaboratoryEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataLaboratoryDe1));
                    content.Add(Formatter.AsTableRow(dataLaboratoryDe2));
                    content.Add(Formatter.AsTableRow(dataLaboratoryDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataLaboratoryZz1));
                    content.Add(Formatter.AsTableRow(dataLaboratoryZz2));
                    content.Add(Formatter.AsTableRow(dataLaboratoryZz3));
                    break;
            }

            // Infobox Film Length
            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataFilmLengthEn1));
                    //content.Add(Formatter.AsTableRow(dataFilmLengthEn2));
                    //content.Add(Formatter.AsTableRow(dataFilmLengthEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataFilmLengthDe1));
                    //content.Add(Formatter.AsTableRow(dataFilmLengthDe2));
                    //content.Add(Formatter.AsTableRow(dataFilmLengthDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataFilmLengthZz1));
                    //content.Add(Formatter.AsTableRow(dataFilmLengthZz2));
                    //content.Add(Formatter.AsTableRow(dataFilmLengthZz3));
                    break;
            }

            // InfoBox Ende
            content.Add(Formatter.EndBox());
            content.Add($"");
            content.Add($"");

            // Cast and Crew Chapter
            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Cast and Crew")); break;
                case "de": content.Add(Formatter.AsHeading2("Darsteller und Mannschaft")); break;
                default: content.Add(Formatter.AsHeading2("Darsteller und Mannschaft")); break;
            }

            // Director
            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Director")); break;
                case "de": content.Add(Formatter.AsHeading3("Regie")); break;
                default: content.Add(Formatter.AsHeading3("Regie")); break;
            }
            content.Add(Formatter.AsTableRow(dataDirector1));
            content.Add(Formatter.AsTableRow(dataDirector2));
            content.Add(Formatter.AsTableRow(dataDirector3));
            content.Add($"");
            content.Add($"");

            // Connection Chapter
            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Connections to other articles")); break;
                case "de": content.Add(Formatter.AsHeading2("Bezüge zu anderen Artikeln")); break;
                default: content.Add(Formatter.AsHeading2("Bezüge zu anderen Artikeln")); break;
            }
            content.Add(Formatter.AsInsertPage(value + ":navigation:_xxx"));
            content.Add($"");
            content.Add($"");

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
