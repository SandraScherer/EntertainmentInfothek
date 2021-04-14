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
            string[] dataEn1 = { "Genre", $"{Formatter.AsInternalLink(path, "Genre English Title X", "Genre English Title X")} Movie Genre Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Genre English Title Y", "Genre English Title Y")} Movie Genre Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Genre English Title Z", "Genre English Title Z")} Movie Genre Details X3" };
            string[] dataDe1 = { "Genre", $"{Formatter.AsInternalLink(path, "Genre English Title X", "Genre German Title X")} Movie Genre Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Genre English Title Y", "Genre German Title Y")} Movie Genre Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Genre English Title Z", "Genre German Title Z")} Movie Genre Details X3" };
            string[] dataZz1 = { "Genre", $"{Formatter.AsInternalLink(path, "Genre English Title X", "Genre German Title X")} Movie Genre Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Genre English Title Y", "Genre German Title Y")} Movie Genre Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Genre English Title Z", "Genre German Title Z")} Movie Genre Details X3" };

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
        public void CreateInfoBoxCertificationTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxCertification(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { ".", "certification" };
            string[] dataEn1 = { "Certification", $"{Formatter.AsImage(path, "Image File Name X", 75)} Movie Certification Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(path, "Image File Name Y", 75)} Movie Certification Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(path, "Image File Name Z", 75)} Movie Certification Details X3" };
            string[] dataDe1 = { "Altersfreigabe", $"{Formatter.AsImage(path, "Image File Name X", 75)} Movie Certification Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(path, "Image File Name Y", 75)} Movie Certification Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(path, "Image File Name Z", 75)} Movie Certification Details X3" };
            string[] dataZz1 = { "Altersfreigabe", $"{Formatter.AsImage(path, "Image File Name X", 75)} Movie Certification Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(path, "Image File Name Y", 75)} Movie Certification Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(path, "Image File Name Z", 75)} Movie Certification Details X3" };

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
            string[] dataEn1 = { "Production Country", $"{Formatter.AsInternalLink(path, "Country Original Name X", "Country English Name X")} Movie Country Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Country Original Name Y", "Country English Name Y")} Movie Country Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Country Original Name Z", "Country English Name Z")} Movie Country Details X3" };
            string[] dataDe1 = { "Produktionsland", $"{Formatter.AsInternalLink(path, "Country Original Name X", "Country German Name X")} Movie Country Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Country Original Name Y", "Country German Name Y")} Movie Country Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Country Original Name Z", "Country German Name Z")} Movie Country Details X3" };
            string[] dataZz1 = { "Produktionsland", $"{Formatter.AsInternalLink(path, "Country Original Name X", "Country German Name X")} Movie Country Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Country Original Name Y", "Country German Name Y")} Movie Country Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Country Original Name Z", "Country German Name Z")} Movie Country Details X3" };

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
            string[] dataEn1 = { "Language", $"{Formatter.AsInternalLink(path, "Language Original Name X", "Language English Name X")} Movie Language Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Language Original Name Y", "Language English Name Y")} Movie Language Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Language Original Name Z", "Language English Name Z")} Movie Language Details X3" };
            string[] dataDe1 = { "Sprache", $"{Formatter.AsInternalLink(path, "Language Original Name X", "Language German Name X")} Movie Language Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Language Original Name Y", "Language German Name Y")} Movie Language Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Language Original Name Z", "Language German Name Z")} Movie Language Details X3" };
            string[] dataZz1 = { "Sprache", $"{Formatter.AsInternalLink(path, "Language Original Name X", "Language German Name X")} Movie Language Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Language Original Name Y", "Language German Name Y")} Movie Language Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Language Original Name Z", "Language German Name Z")} Movie Language Details X3" };

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
            string[] dataEn1 = { "Runtime", $"1 min. ({Formatter.AsInternalLink(path, "Edition English Title X", "Edition English Title X")}) Movie Runtime Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(path, "Edition English Title Y", "Edition English Title Y")}) Movie Runtime Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(path, "Edition English Title Z", "Edition English Title Z")}) Movie Runtime Details X3" };
            string[] dataDe1 = { "Laufzeit", $"1 min. ({Formatter.AsInternalLink(path, "Edition English Title X", "Edition German Title X")}) Movie Runtime Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(path, "Edition English Title Y", "Edition German Title Y")}) Movie Runtime Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(path, "Edition English Title Z", "Edition German Title Z")}) Movie Runtime Details X3" };
            string[] dataZz1 = { "Laufzeit", $"1 min. ({Formatter.AsInternalLink(path, "Edition English Title X", "Edition German Title X")}) Movie Runtime Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(path, "Edition English Title Y", "Edition German Title Y")}) Movie Runtime Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(path, "Edition English Title Z", "Edition German Title Z")}) Movie Runtime Details X3" };

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
            string[] dataEn1 = { "Sound Mix", $"{Formatter.AsInternalLink(path, "Sound Mix English Title X", "Sound Mix English Title X")} Movie Sound Mix Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Sound Mix English Title Y", "Sound Mix English Title Y")} Movie Sound Mix Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Sound Mix English Title Z", "Sound Mix English Title Z")} Movie Sound Mix Details X3" };
            string[] dataDe1 = { "Tonmischung", $"{Formatter.AsInternalLink(path, "Sound Mix English Title X", "Sound Mix German Title X")} Movie Sound Mix Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Sound Mix English Title Y", "Sound Mix German Title Y")} Movie Sound Mix Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Sound Mix English Title Z", "Sound Mix German Title Z")} Movie Sound Mix Details X3" };
            string[] dataZz1 = { "Tonmischung", $"{Formatter.AsInternalLink(path, "Sound Mix English Title X", "Sound Mix German Title X")} Movie Sound Mix Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Sound Mix English Title Y", "Sound Mix German Title Y")} Movie Sound Mix Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Sound Mix English Title Z", "Sound Mix German Title Z")} Movie Sound Mix Details X3" };

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
            string[] dataEn1 = { "Color", $"{Formatter.AsInternalLink(path, "Color English Title X", "Color English Title X")} Movie Color Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Color English Title Y", "Color English Title Y")} Movie Color Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Color English Title Z", "Color English Title Z")} Movie Color Details X3" };
            string[] dataDe1 = { "Farbe", $"{Formatter.AsInternalLink(path, "Color English Title X", "Color German Title X")} Movie Color Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Color English Title Y", "Color German Title Y")} Movie Color Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Color English Title Z", "Color German Title Z")} Movie Color Details X3" };
            string[] dataZz1 = { "Farbe", $"{Formatter.AsInternalLink(path, "Color English Title X", "Color German Title X")} Movie Color Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Color English Title Y", "Color German Title Y")} Movie Color Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Color English Title Z", "Color German Title Z")} Movie Color Details X3" };

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
            string[] dataEn1 = { "Camera", "Camera Name X, Camera Lense X Movie Camera Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), "Camera Name Y, Camera Lense Y Movie Camera Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), "Camera Name Z, Camera Lense Z Movie Camera Details X3" };
            string[] dataDe1 = { "Kamera", "Camera Name X, Camera Lense X Movie Camera Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), "Camera Name Y, Camera Lense Y Movie Camera Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), "Camera Name Z, Camera Lense Z Movie Camera Details X3" };
            string[] dataZz1 = { "Kamera", "Camera Name X, Camera Lense X Movie Camera Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), "Camera Name Y, Camera Lense Y Movie Camera Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), "Camera Name Z, Camera Lense Z Movie Camera Details X3" };

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
            string[] dataEn1 = { "Laboratory", "Laboratory Name X Movie Laboratory Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), "Laboratory Name Y Movie Laboratory Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), "Laboratory Name Z Movie Laboratory Details X3" };
            string[] dataDe1 = { "Labor", "Laboratory Name X Movie Laboratory Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), "Laboratory Name Y Movie Laboratory Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), "Laboratory Name Z Movie Laboratory Details X3" };
            string[] dataZz1 = { "Labor", "Laboratory Name X Movie Laboratory Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), "Laboratory Name Y Movie Laboratory Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), "Laboratory Name Z Movie Laboratory Details X3" };

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
            string[] dataEn1 = { "Film Length", "Movie Film Length X Movie Film Length Details X" };
            //string[] dataEn2 = { Formatter.CellSpanVertically(), "Movie Film Length Y Movie Film Length Details X2" };
            //string[] dataEn3 = { Formatter.CellSpanVertically(), "Movie Film Length Z Movie Film Length Details X3" };
            string[] dataDe1 = { "Filmlänge", "Movie Film Length X Movie Film Length Details X" };
            //string[] dataDe2 = { Formatter.CellSpanVertically(), "Movie Film Length Y Movie Film Length Details X2" };
            //string[] dataDe3 = { Formatter.CellSpanVertically(), "Movie Film Length Z Movie Film Length Details X3" };
            string[] dataZz1 = { "Filmlänge", "Movie Film Length X Movie Film Length Details X" };
            //string[] dataZz2 = { Formatter.CellSpanVertically(), "Movie Film Length Y Movie Film Length Details X2" };
            //string[] dataZz3 = { Formatter.CellSpanVertically(), "Movie Film Length Z Movie Film Length Details X3" };

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

        [TestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreateInfoBoxNegativeFormatTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxNegativeFormat(value);

            // Assert
            List<string> content = new List<string>();
            string[] dataEn1 = { "Negative Format", "Film Format Name X Movie Negative Format Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), "Film Format Name Y Movie Negative Format Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), "Film Format Name Z Movie Negative Format Details X3" };
            string[] dataDe1 = { "Negativformat", "Film Format Name X Movie Negative Format Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), "Film Format Name Y Movie Negative Format Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), "Film Format Name Z Movie Negative Format Details X3" };
            string[] dataZz1 = { "Negativformat", "Film Format Name X Movie Negative Format Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), "Film Format Name Y Movie Negative Format Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), "Film Format Name Z Movie Negative Format Details X3" };

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
        public void CreateInfoBoxCinematographicProcessTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxCinematographicProcess(value);

            // Assert
            List<string> content = new List<string>();
            string[] dataEn1 = { "Cinematographic Process", "Cinematographic Process Name X Movie Cinematographic Process Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), "Cinematographic Process Name Y Movie Cinematographic Process Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), "Cinematographic Process Name Z Movie Cinematographic Process Details X3" };
            string[] dataDe1 = { "Filmprozess", "Cinematographic Process Name X Movie Cinematographic Process Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), "Cinematographic Process Name Y Movie Cinematographic Process Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), "Cinematographic Process Name Z Movie Cinematographic Process Details X3" };
            string[] dataZz1 = { "Filmprozess", "Cinematographic Process Name X Movie Cinematographic Process Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), "Cinematographic Process Name Y Movie Cinematographic Process Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), "Cinematographic Process Name Z Movie Cinematographic Process Details X3" };

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
        public void CreateInfoBoxPrintedFilmFormatTest(string value)
        {
            // Arrange
            Movie movie = new Movie("_xxx");
            movie.Retrieve();
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxPrintedFilmFormat(value);

            // Assert
            List<string> content = new List<string>();
            string[] dataEn1 = { "Printed Film Format", "Film Format Name X Movie Printed Film Format Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), "Film Format Name Y Movie Printed Film Format Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), "Film Format Name Z Movie Printed Film Format Details X3" };
            string[] dataDe1 = { "Filmformat", "Film Format Name X Movie Printed Film Format Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), "Film Format Name Y Movie Printed Film Format Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), "Film Format Name Z Movie Printed Film Format Details X3" };
            string[] dataZz1 = { "Filmformat", "Film Format Name X Movie Printed Film Format Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), "Film Format Name Y Movie Printed Film Format Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), "Film Format Name Z Movie Printed Film Format Details X3" };

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

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Cast and Crew")); break;
                case "de": content.Add(Formatter.AsHeading2("Darsteller und Mannschaft")); break;
                default: content.Add(Formatter.AsHeading2("Darsteller und Mannschaft")); break;
            }

            // Director
            string[] dataDirector1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Director Role X1) Movie Director Details X1" };
            string[] dataDirector2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Director Role X2) Movie Director Details X2" };
            string[] dataDirector3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Director Role X3) Movie Director Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Directed by")); break;
                case "de": content.Add(Formatter.AsHeading3("Regie")); break;
                default: content.Add(Formatter.AsHeading3("Regie")); break;
            }
            content.Add(Formatter.AsTableRow(dataDirector1));
            content.Add(Formatter.AsTableRow(dataDirector2));
            content.Add(Formatter.AsTableRow(dataDirector3));
            content.Add($"");
            content.Add($"");

            // Writer
            string[] dataWriter1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Writer Role X1) Movie Writer Details X1" };
            string[] dataWriter2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Writer Role X2) Movie Writer Details X2" };
            string[] dataWriter3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Writer Role X3) Movie Writer Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Writing Credits")); break;
                case "de": content.Add(Formatter.AsHeading3("Drehbuch")); break;
                default: content.Add(Formatter.AsHeading3("Drehbuch")); break;
            }
            content.Add(Formatter.AsTableRow(dataWriter1));
            content.Add(Formatter.AsTableRow(dataWriter2));
            content.Add(Formatter.AsTableRow(dataWriter3));
            content.Add($"");
            content.Add($"");

            // Cast
            string[] dataCast1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Cast Character X1) Movie Cast Details X1" };
            string[] dataCast2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Cast Character X2) Movie Cast Details X2" };
            string[] dataCast3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Cast Character X3) Movie Cast Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Cast")); break;
                case "de": content.Add(Formatter.AsHeading3("Darsteller")); break;
                default: content.Add(Formatter.AsHeading3("Darsteller")); break;
            }
            content.Add(Formatter.AsTableRow(dataCast1));
            content.Add(Formatter.AsTableRow(dataCast2));
            content.Add(Formatter.AsTableRow(dataCast3));
            content.Add($"");
            content.Add($"");

            // Producer
            string[] dataProducer1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Producer Role X1) Movie Producer Details X1" };
            string[] dataProducer2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Producer Role X2) Movie Producer Details X2" };
            string[] dataProducer3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Producer Role X3) Movie Producer Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Produced by")); break;
                case "de": content.Add(Formatter.AsHeading3("Produzenten")); break;
                default: content.Add(Formatter.AsHeading3("Produzenten")); break;
            }
            content.Add(Formatter.AsTableRow(dataProducer1));
            content.Add(Formatter.AsTableRow(dataProducer2));
            content.Add(Formatter.AsTableRow(dataProducer3));
            content.Add($"");
            content.Add($"");

            // Music
            string[] dataMusician1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Music Role X1) Movie Music Details X1" };
            string[] dataMusician2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Music Role X2) Movie Music Details X2" };
            string[] dataMusician3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Music Role X3) Movie Music Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Music by")); break;
                case "de": content.Add(Formatter.AsHeading3("Musik")); break;
                default: content.Add(Formatter.AsHeading3("Musik")); break;
            }
            content.Add(Formatter.AsTableRow(dataMusician1));
            content.Add(Formatter.AsTableRow(dataMusician2));
            content.Add(Formatter.AsTableRow(dataMusician3));
            content.Add($"");
            content.Add($"");

            // Cinematography
            string[] dataCinematographer1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Cinematography Role X1) Movie Cinematography Details X1" };
            string[] dataCinematographer2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Cinematography Role X2) Movie Cinematography Details X2" };
            string[] dataCinematographer3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Cinematography Role X3) Movie Cinematography Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Cinematography by")); break;
                case "de": content.Add(Formatter.AsHeading3("Kamera")); break;
                default: content.Add(Formatter.AsHeading3("Kamera")); break;
            }
            content.Add(Formatter.AsTableRow(dataCinematographer1));
            content.Add(Formatter.AsTableRow(dataCinematographer2));
            content.Add(Formatter.AsTableRow(dataCinematographer3));
            content.Add($"");
            content.Add($"");

            // Film Editing
            string[] dataFilmEditor1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Film Editing Role X1) Movie Film Editing Details X1" };
            string[] dataFilmEditor2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Film Editing Role X2) Movie Film Editing Details X2" };
            string[] dataFilmEditor3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Film Editing Role X3) Movie Film Editing Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Film Editing by")); break;
                case "de": content.Add(Formatter.AsHeading3("Schnitt")); break;
                default: content.Add(Formatter.AsHeading3("Schnitt")); break;
            }
            content.Add(Formatter.AsTableRow(dataFilmEditor1));
            content.Add(Formatter.AsTableRow(dataFilmEditor2));
            content.Add(Formatter.AsTableRow(dataFilmEditor3));
            content.Add($"");
            content.Add($"");

            // Casting
            string[] dataCasting1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Casting Role X1) Movie Casting Details X1" };
            string[] dataCasting2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Casting Role X2) Movie Casting Details X2" };
            string[] dataCasting3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Casting Role X3) Movie Casting Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Casting by")); break;
                case "de": content.Add(Formatter.AsHeading3("Casting")); break;
                default: content.Add(Formatter.AsHeading3("Casting")); break;
            }
            content.Add(Formatter.AsTableRow(dataCasting1));
            content.Add(Formatter.AsTableRow(dataCasting2));
            content.Add(Formatter.AsTableRow(dataCasting3));
            content.Add($"");
            content.Add($"");

            // Production Design
            string[] dataProductionDesigner1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Production Design Role X1) Movie Production Design Details X1" };
            string[] dataProductionDesigner2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Production Design Role X2) Movie Production Design Details X2" };
            string[] dataProductionDesigner3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Production Design Role X3) Movie Production Design Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Production Design by")); break;
                case "de": content.Add(Formatter.AsHeading3("Szenenbild")); break;
                default: content.Add(Formatter.AsHeading3("Szenenbild")); break;
            }
            content.Add(Formatter.AsTableRow(dataProductionDesigner1));
            content.Add(Formatter.AsTableRow(dataProductionDesigner2));
            content.Add(Formatter.AsTableRow(dataProductionDesigner3));
            content.Add($"");
            content.Add($"");

            // Art Direction
            string[] dataArtDirector1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Art Direction Role X1) Movie Art Direction Details X1" };
            string[] dataArtDirector2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Art Direction Role X2) Movie Art Direction Details X2" };
            string[] dataArtDirector3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Art Direction Role X3) Movie Art Direction Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Art Direction by")); break;
                case "de": content.Add(Formatter.AsHeading3("Ausstattung")); break;
                default: content.Add(Formatter.AsHeading3("Ausstattung")); break;
            }
            content.Add(Formatter.AsTableRow(dataArtDirector1));
            content.Add(Formatter.AsTableRow(dataArtDirector2));
            content.Add(Formatter.AsTableRow(dataArtDirector3));
            content.Add($"");
            content.Add($"");

            // Set Decoration
            string[] dataSetDecoration1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Set Decoration Role X1) Movie Set Decoration Details X1" };
            string[] dataSetDecoration2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Set Decoration Role X2) Movie Set Decoration Details X2" };
            string[] dataSetDecoration3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Set Decoration Role X3) Movie Set Decoration Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Set Decoration by")); break;
                case "de": content.Add(Formatter.AsHeading3("Bühnenbild")); break;
                default: content.Add(Formatter.AsHeading3("Bühnenbild")); break;
            }
            content.Add(Formatter.AsTableRow(dataSetDecoration1));
            content.Add(Formatter.AsTableRow(dataSetDecoration2));
            content.Add(Formatter.AsTableRow(dataSetDecoration3));
            content.Add($"");
            content.Add($"");

            // Costume Design
            string[] dataCostumeDesign1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Costume Design Role X1) Movie Costume Design Details X1" };
            string[] dataCostumeDesign2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Costume Design Role X2) Movie Costume Design Details X2" };
            string[] dataCostumeDesign3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Costume Design Role X3) Movie Costume Design Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Costume Design by")); break;
                case "de": content.Add(Formatter.AsHeading3("Kostümausstattung")); break;
                default: content.Add(Formatter.AsHeading3("Kostümausstattung")); break;
            }
            content.Add(Formatter.AsTableRow(dataCostumeDesign1));
            content.Add(Formatter.AsTableRow(dataCostumeDesign2));
            content.Add(Formatter.AsTableRow(dataCostumeDesign3));
            content.Add($"");
            content.Add($"");

            // Makeup Department
            string[] dataMakeupDepartment1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Makeup Department Role X1) Movie Makeup Department Details X1" };
            string[] dataMakeupDepartment2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Makeup Department Role X2) Movie Makeup Department Details X2" };
            string[] dataMakeupDepartment3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Makeup Department Role X3) Movie Makeup Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Makeup Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Maske")); break;
                default: content.Add(Formatter.AsHeading3("Maske")); break;
            }
            content.Add(Formatter.AsTableRow(dataMakeupDepartment1));
            content.Add(Formatter.AsTableRow(dataMakeupDepartment2));
            content.Add(Formatter.AsTableRow(dataMakeupDepartment3));
            content.Add($"");
            content.Add($"");

            // Production Management
            string[] dataProductionManagement1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Production Management Role X1) Movie Production Management Details X1" };
            string[] dataProductionManagement2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Production Management Role X2) Movie Production Management Details X2" };
            string[] dataProductionManagement3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Production Management Role X3) Movie Production Management Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Production Management")); break;
                case "de": content.Add(Formatter.AsHeading3("Produktionsleitung")); break;
                default: content.Add(Formatter.AsHeading3("Produktionsleitung")); break;
            }
            content.Add(Formatter.AsTableRow(dataProductionManagement1));
            content.Add(Formatter.AsTableRow(dataProductionManagement2));
            content.Add(Formatter.AsTableRow(dataProductionManagement3));
            content.Add($"");
            content.Add($"");

            // Assistant Director
            string[] dataAssistantDirector1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Assistant Director Role X1) Movie Assistant Director Details X1" };
            string[] dataAssistantDirector2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Assistant Director Role X2) Movie Assistant Director Details X2" };
            string[] dataAssistantDirector3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Assistant Director Role X3) Movie Assistant Director Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Second Unit Director or Assistant Director")); break;
                case "de": content.Add(Formatter.AsHeading3("Second Unit Regie und Regieassistenz")); break;
                default: content.Add(Formatter.AsHeading3("Second Unit Regie und Regieassistenz")); break;
            }
            content.Add(Formatter.AsTableRow(dataAssistantDirector1));
            content.Add(Formatter.AsTableRow(dataAssistantDirector2));
            content.Add(Formatter.AsTableRow(dataAssistantDirector3));
            content.Add($"");
            content.Add($"");

            // Art Department
            string[] dataArtDepartment1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Art Department Role X1) Movie Art Department Details X1" };
            string[] dataArtDepartment2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Art Department Role X2) Movie Art Department Details X2" };
            string[] dataArtDepartment3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Art Department Role X3) Movie Art Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Art Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Art Abteilung")); break;
                default: content.Add(Formatter.AsHeading3("Art Abteilung")); break;
            }
            content.Add(Formatter.AsTableRow(dataArtDepartment1));
            content.Add(Formatter.AsTableRow(dataArtDepartment2));
            content.Add(Formatter.AsTableRow(dataArtDepartment3));
            content.Add($"");
            content.Add($"");

            // Sound Department
            string[] dataSoundDepartment1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Sound Department Role X1) Movie Sound Department Details X1" };
            string[] dataSoundDepartment2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Sound Department Role X2) Movie Sound Department Details X2" };
            string[] dataSoundDepartment3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Sound Department Role X3) Movie Sound Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Sound Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Sound Abteilung")); break;
                default: content.Add(Formatter.AsHeading3("Sound Abteilung")); break;
            }
            content.Add(Formatter.AsTableRow(dataSoundDepartment1));
            content.Add(Formatter.AsTableRow(dataSoundDepartment2));
            content.Add(Formatter.AsTableRow(dataSoundDepartment3));
            content.Add($"");
            content.Add($"");

            // Special Effects
            string[] dataSpecialEffects1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Special Effects Role X1) Movie Special Effects Details X1" };
            string[] dataSpecialEffects2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Special Effects Role X2) Movie Special Effects Details X2" };
            string[] dataSpecialEffects3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Special Effects Role X3) Movie Special Effects Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Special Effects by")); break;
                case "de": content.Add(Formatter.AsHeading3("Spezialeffekte")); break;
                default: content.Add(Formatter.AsHeading3("Spezialeffekte")); break;
            }
            content.Add(Formatter.AsTableRow(dataSpecialEffects1));
            content.Add(Formatter.AsTableRow(dataSpecialEffects2));
            content.Add(Formatter.AsTableRow(dataSpecialEffects3));
            content.Add($"");
            content.Add($"");

            // Visual Effects
            string[] dataVisualEffects1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Visual Effects Role X1) Movie Visual Effects Details X1" };
            string[] dataVisualEffects2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Visual Effects Role X2) Movie Visual Effects Details X2" };
            string[] dataVisualEffects3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Visual Effects Role X3) Movie Visual Effects Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Visual Effects by")); break;
                case "de": content.Add(Formatter.AsHeading3("Visuelle Effekte")); break;
                default: content.Add(Formatter.AsHeading3("Visuelle Effekte")); break;
            }
            content.Add(Formatter.AsTableRow(dataVisualEffects1));
            content.Add(Formatter.AsTableRow(dataVisualEffects2));
            content.Add(Formatter.AsTableRow(dataVisualEffects3));
            content.Add($"");
            content.Add($"");

            // Stunts
            string[] dataStunts1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Stunts Role X1) Movie Stunts Details X1" };
            string[] dataStunts2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Stunts Role X2) Movie Stunts Details X2" };
            string[] dataStunts3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Stunts Role X3) Movie Stunts Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Stunts by")); break;
                case "de": content.Add(Formatter.AsHeading3("Stunts")); break;
                default: content.Add(Formatter.AsHeading3("Stunts")); break;
            }
            content.Add(Formatter.AsTableRow(dataStunts1));
            content.Add(Formatter.AsTableRow(dataStunts2));
            content.Add(Formatter.AsTableRow(dataStunts3));
            content.Add($"");
            content.Add($"");

            // Electrical Department
            string[] dataElectricalDepartment1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Electrical Department Role X1) Movie Electrical Department Details X1" };
            string[] dataElectricalDepartment2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Electrical Department Role X2) Movie Electrical Department Details X2" };
            string[] dataElectricalDepartment3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Electrical Department Role X3) Movie Electrical Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Camera and Electrical Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Kamera und Beleuchtung")); break;
                default: content.Add(Formatter.AsHeading3("Kamera und Beleuchtung")); break;
            }
            content.Add(Formatter.AsTableRow(dataElectricalDepartment1));
            content.Add(Formatter.AsTableRow(dataElectricalDepartment2));
            content.Add(Formatter.AsTableRow(dataElectricalDepartment3));
            content.Add($"");
            content.Add($"");

            // Animation Department
            string[] dataAnimationDepartment1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Animation Department Role X1) Movie Animation Department Details X1" };
            string[] dataAnimationDepartment2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Animation Department Role X2) Movie Animation Department Details X2" };
            string[] dataAnimationDepartment3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Animation Department Role X3) Movie Animation Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Animation Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Animationen")); break;
                default: content.Add(Formatter.AsHeading3("Animationen")); break;
            }
            content.Add(Formatter.AsTableRow(dataAnimationDepartment1));
            content.Add(Formatter.AsTableRow(dataAnimationDepartment2));
            content.Add(Formatter.AsTableRow(dataAnimationDepartment3));
            content.Add($"");
            content.Add($"");

            // Casting Department
            string[] dataCastingDepartment1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Casting Department Role X1) Movie Casting Department Details X1" };
            string[] dataCastingDepartment2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Casting Department Role X2) Movie Casting Department Details X2" };
            string[] dataCastingDepartment3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Casting Department Role X3) Movie Casting Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Casting Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Casting")); break;
                default: content.Add(Formatter.AsHeading3("Casting")); break;
            }
            content.Add(Formatter.AsTableRow(dataCastingDepartment1));
            content.Add(Formatter.AsTableRow(dataCastingDepartment2));
            content.Add(Formatter.AsTableRow(dataCastingDepartment3));
            content.Add($"");
            content.Add($"");

            // Costume Department
            string[] dataCostumeDepartment1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Costume Department Role X1) Movie Costume Department Details X1" };
            string[] dataCostumeDepartment2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Costume Department Role X2) Movie Costume Department Details X2" };
            string[] dataCostumeDepartment3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Costume Department Role X3) Movie Costume Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Costume and Wardrobe Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Kostümbildnerei")); break;
                default: content.Add(Formatter.AsHeading3("Kostümbildnerei")); break;
            }
            content.Add(Formatter.AsTableRow(dataCostumeDepartment1));
            content.Add(Formatter.AsTableRow(dataCostumeDepartment2));
            content.Add(Formatter.AsTableRow(dataCostumeDepartment3));
            content.Add($"");
            content.Add($"");

            // Editorial Department
            string[] dataEditorialDepartment1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Editorial Department Role X1) Movie Editorial Department Details X1" };
            string[] dataEditorialDepartment2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Editorial Department Role X2) Movie Editorial Department Details X2" };
            string[] dataEditorialDepartment3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Editorial Department Role X3) Movie Editorial Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Editorial Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Redaktion")); break;
                default: content.Add(Formatter.AsHeading3("Redaktion")); break;
            }
            content.Add(Formatter.AsTableRow(dataEditorialDepartment1));
            content.Add(Formatter.AsTableRow(dataEditorialDepartment2));
            content.Add(Formatter.AsTableRow(dataEditorialDepartment3));
            content.Add($"");
            content.Add($"");

            // Location Management
            string[] dataLocationManagement1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Location Management Role X1) Movie Location Management Details X1" };
            string[] dataLocationManagement2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Location Management Role X2) Movie Location Management Details X2" };
            string[] dataLocationManagement3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Location Management Role X3) Movie Location Management Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Location Management")); break;
                case "de": content.Add(Formatter.AsHeading3("Drehort Management")); break;
                default: content.Add(Formatter.AsHeading3("Drehort Management")); break;
            }
            content.Add(Formatter.AsTableRow(dataLocationManagement1));
            content.Add(Formatter.AsTableRow(dataLocationManagement2));
            content.Add(Formatter.AsTableRow(dataLocationManagement3));
            content.Add($"");
            content.Add($"");

            // Music Department
            string[] dataMusicDepartment1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Music Department Role X1) Movie Music Department Details X1" };
            string[] dataMusicDepartment2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Music Department Role X2) Movie Music Department Details X2" };
            string[] dataMusicDepartment3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Music Department Role X3) Movie Music Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Music Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Musik")); break;
                default: content.Add(Formatter.AsHeading3("Musik")); break;
            }
            content.Add(Formatter.AsTableRow(dataMusicDepartment1));
            content.Add(Formatter.AsTableRow(dataMusicDepartment2));
            content.Add(Formatter.AsTableRow(dataMusicDepartment3));
            content.Add($"");
            content.Add($"");

            // Continuity Department
            string[] dataContinuityDepartment1 = { Formatter.AsInternalLink(path, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Continuity Department Role X1) Movie Continuity Department Details X1" };
            string[] dataContinuityDepartment2 = { Formatter.AsInternalLink(path, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Continuity Department Role X2) Movie Continuity Department Details X2" };
            string[] dataContinuityDepartment3 = { Formatter.AsInternalLink(path, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Continuity Department Role X3) Movie Continuity Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Script and Continuity Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Dramaturgie und Continuity")); break;
                default: content.Add(Formatter.AsHeading3("Dramaturgie und Continuity")); break;
            }
            content.Add(Formatter.AsTableRow(dataContinuityDepartment1));
            content.Add(Formatter.AsTableRow(dataContinuityDepartment2));
            content.Add(Formatter.AsTableRow(dataContinuityDepartment3));
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
            string[] dataTitleEn = { "Original Title", "Movie Original Title X" };
            string[] dataTitleDe = { "Originaltitel", "Movie Original Title X" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsTableRow(dataTitleEn)); break;
                case "de": content.Add(Formatter.AsTableRow(dataTitleDe)); break;
                default: content.Add(Formatter.AsTableRow(dataTitleDe)); break;
            }

            // InfoBox Type
            string[] pathType = { value, "info" };
            string[] dataTypeEn = { "Type", Formatter.AsInternalLink(pathType, "Type English Title X", "Type English Title X") };
            string[] dataTypeDe = { "Typ", Formatter.AsInternalLink(pathType, "Type English Title X", "Type German Title X") };
            string[] dataTypeZz = { "Typ", Formatter.AsInternalLink(pathType, "Type English Title X", "Type German Title X") };

            switch (value)
            {
                case "en": content.Add(Formatter.AsTableRow(dataTypeEn)); break;
                case "de": content.Add(Formatter.AsTableRow(dataTypeDe)); break;
                default: content.Add(Formatter.AsTableRow(dataTypeZz)); break;
            }

            // InfoBox Release Date
            string[] pathRelease = { value, "date" };
            string[] dataReleaseEn = { "Original Release Date", Formatter.AsInternalLink(pathRelease, "Movie Release Date X", "Movie Release Date X") };
            string[] dataReleaseDe = { "Erstausstrahlung", Formatter.AsInternalLink(pathRelease, "Movie Release Date X", "Movie Release Date X") };
            string[] dataReleaseZz = { "Erstausstrahlung", Formatter.AsInternalLink(pathRelease, "Movie Release Date X", "Movie Release Date X") };

            switch (value)
            {
                case "en": content.Add(Formatter.AsTableRow(dataReleaseEn)); break;
                case "de": content.Add(Formatter.AsTableRow(dataReleaseDe)); break;
                default: content.Add(Formatter.AsTableRow(dataReleaseZz)); break;
            }

            // InfoBox Genre
            string[] pathGenre = { value, "info" };
            string[] dataGenreEn1 = { "Genre", $"{Formatter.AsInternalLink(pathGenre, "Genre English Title X", "Genre English Title X")} Movie Genre Details X1" };
            string[] dataGenreEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathGenre, "Genre English Title Y", "Genre English Title Y")} Movie Genre Details X2" };
            string[] dataGenreEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathGenre, "Genre English Title Z", "Genre English Title Z")} Movie Genre Details X3" };
            string[] dataGenreDe1 = { "Genre", $"{Formatter.AsInternalLink(pathGenre, "Genre English Title X", "Genre German Title X")} Movie Genre Details X1" };
            string[] dataGenreDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathGenre, "Genre English Title Y", "Genre German Title Y")} Movie Genre Details X2" };
            string[] dataGenreDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathGenre, "Genre English Title Z", "Genre German Title Z")} Movie Genre Details X3" };
            string[] dataGenreZz1 = { "Genre", $"{Formatter.AsInternalLink(pathGenre, "Genre English Title X", "Genre German Title X")} Movie Genre Details X1" };
            string[] dataGenreZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathGenre, "Genre English Title Y", "Genre German Title Y")} Movie Genre Details X2" };
            string[] dataGenreZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathGenre, "Genre English Title Z", "Genre German Title Z")} Movie Genre Details X3" };

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

            // InfoBox Certification
            string[] pathCertification = { ".", "certification" };
            string[] dataCertificationEn1 = { "Certification", $"{Formatter.AsImage(pathCertification, "Image File Name X", 75)} Movie Certification Details X1" };
            string[] dataCertificationEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(pathCertification, "Image File Name Y", 75)} Movie Certification Details X2" };
            string[] dataCertificationEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(pathCertification, "Image File Name Z", 75)} Movie Certification Details X3" };
            string[] dataCertificationDe1 = { "Altersfreigabe", $"{Formatter.AsImage(pathCertification, "Image File Name X", 75)} Movie Certification Details X1" };
            string[] dataCertificationDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(pathCertification, "Image File Name Y", 75)} Movie Certification Details X2" };
            string[] dataCertificationDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(pathCertification, "Image File Name Z", 75)} Movie Certification Details X3" };
            string[] dataCertificationZz1 = { "Altersfreigabe", $"{Formatter.AsImage(pathCertification, "Image File Name X", 75)} Movie Certification Details X1" };
            string[] dataCertificationZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(pathCertification, "Image File Name Y", 75)} Movie Certification Details X2" };
            string[] dataCertificationZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(pathCertification, "Image File Name Z", 75)} Movie Certification Details X3" };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataCertificationEn1));
                    content.Add(Formatter.AsTableRow(dataCertificationEn2));
                    content.Add(Formatter.AsTableRow(dataCertificationEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataCertificationDe1));
                    content.Add(Formatter.AsTableRow(dataCertificationDe2));
                    content.Add(Formatter.AsTableRow(dataCertificationDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataCertificationZz1));
                    content.Add(Formatter.AsTableRow(dataCertificationZz2));
                    content.Add(Formatter.AsTableRow(dataCertificationZz3));
                    break;
            }

            // InfoBox Country
            string[] pathCountry = { value, "info" };
            string[] dataCountryEn1 = { "Production Country", $"{Formatter.AsInternalLink(pathCountry, "Country Original Name X", "Country English Name X")} Movie Country Details X1" };
            string[] dataCountryEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathCountry, "Country Original Name Y", "Country English Name Y")} Movie Country Details X2" };
            string[] dataCountryEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathCountry, "Country Original Name Z", "Country English Name Z")} Movie Country Details X3" };
            string[] dataCountryDe1 = { "Produktionsland", $"{Formatter.AsInternalLink(pathCountry, "Country Original Name X", "Country German Name X")} Movie Country Details X1" };
            string[] dataCountryDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathCountry, "Country Original Name Y", "Country German Name Y")} Movie Country Details X2" };
            string[] dataCountryDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathCountry, "Country Original Name Z", "Country German Name Z")} Movie Country Details X3" };
            string[] dataCountryZz1 = { "Produktionsland", $"{Formatter.AsInternalLink(pathCountry, "Country Original Name X", "Country German Name X")} Movie Country Details X1" };
            string[] dataCountryZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathCountry, "Country Original Name Y", "Country German Name Y")} Movie Country Details X2" };
            string[] dataCountryZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathCountry, "Country Original Name Z", "Country German Name Z")} Movie Country Details X3" };

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
            string[] pathLanguage = { value, "info" };
            string[] dataLanguageEn1 = { "Language", $"{Formatter.AsInternalLink(pathLanguage, "Language Original Name X", "Language English Name X")} Movie Language Details X1" };
            string[] dataLanguageEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathLanguage, "Language Original Name Y", "Language English Name Y")} Movie Language Details X2" };
            string[] dataLanguageEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathLanguage, "Language Original Name Z", "Language English Name Z")} Movie Language Details X3" };
            string[] dataLanguageDe1 = { "Sprache", $"{Formatter.AsInternalLink(pathLanguage, "Language Original Name X", "Language German Name X")} Movie Language Details X1" };
            string[] dataLanguageDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathLanguage, "Language Original Name Y", "Language German Name Y")} Movie Language Details X2" };
            string[] dataLanguageDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathLanguage, "Language Original Name Z", "Language German Name Z")} Movie Language Details X3" };
            string[] dataLanguageZz1 = { "Sprache", $"{Formatter.AsInternalLink(pathLanguage, "Language Original Name X", "Language German Name X")} Movie Language Details X1" };
            string[] dataLanguageZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathLanguage, "Language Original Name Y", "Language German Name Y")} Movie Language Details X2" };
            string[] dataLanguageZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathLanguage, "Language Original Name Z", "Language German Name Z")} Movie Language Details X3" };

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
            string[] dataBudgetEn = { "Budget", $"Movie Budget X" };
            string[] dataBudgetDe = { "Budget", $"Movie Budget X" };
            string[] dataBudgetZz = { "Budget", $"Movie Budget X" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsTableRow(dataBudgetEn)); break;
                case "de": content.Add(Formatter.AsTableRow(dataBudgetDe)); break;
                default: content.Add(Formatter.AsTableRow(dataBudgetZz)); break;
            }

            // InfoBox Worldwide Gross
            string[] pathGross = { value, "date" };
            string[] dataGrossEn = { "Worldwide Gross", $"Movie Worldwide Gross X ({Formatter.AsInternalLink(pathGross, "Movie Worldwide Gross Date X", "Movie Worldwide Gross Date X")})" };
            string[] dataGrossDe = { "Einspielergebnis (weltweit)", $"Movie Worldwide Gross X ({Formatter.AsInternalLink(pathGross, "Movie Worldwide Gross Date X", "Movie Worldwide Gross Date X")})" };
            string[] dataGrossZz = { "Einspielergebnis (weltweit)", $"Movie Worldwide Gross X ({Formatter.AsInternalLink(pathGross, "Movie Worldwide Gross Date X", "Movie Worldwide Gross Date X")})" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsTableRow(dataGrossEn)); break;
                case "de": content.Add(Formatter.AsTableRow(dataGrossDe)); break;
                default: content.Add(Formatter.AsTableRow(dataGrossZz)); break;
            }

            // InfoBox Runtime
            string[] pathRuntime = { value, "info" };
            string[] dataRuntimeEn1 = { "Runtime", $"1 min. ({Formatter.AsInternalLink(pathRuntime, "Edition English Title X", "Edition English Title X")}) Movie Runtime Details X1" };
            string[] dataRuntimeEn2 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(pathRuntime, "Edition English Title Y", "Edition English Title Y")}) Movie Runtime Details X2" };
            string[] dataRuntimeEn3 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(pathRuntime, "Edition English Title Z", "Edition English Title Z")}) Movie Runtime Details X3" };
            string[] dataRuntimeDe1 = { "Laufzeit", $"1 min. ({Formatter.AsInternalLink(pathRuntime, "Edition English Title X", "Edition German Title X")}) Movie Runtime Details X1" };
            string[] dataRuntimeDe2 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(pathRuntime, "Edition English Title Y", "Edition German Title Y")}) Movie Runtime Details X2" };
            string[] dataRuntimeDe3 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(pathRuntime, "Edition English Title Z", "Edition German Title Z")}) Movie Runtime Details X3" };
            string[] dataRuntimeZz1 = { "Laufzeit", $"1 min. ({Formatter.AsInternalLink(pathRuntime, "Edition English Title X", "Edition German Title X")}) Movie Runtime Details X1" };
            string[] dataRuntimeZz2 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(pathRuntime, "Edition English Title Y", "Edition German Title Y")}) Movie Runtime Details X2" };
            string[] dataRuntimeZz3 = { Formatter.CellSpanVertically(), $"0 min. ({Formatter.AsInternalLink(pathRuntime, "Edition English Title Z", "Edition German Title Z")}) Movie Runtime Details X3" };

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
            string[] pathSoundMix = { value, "info" };
            string[] dataSoundMixEn1 = { "Sound Mix", $"{Formatter.AsInternalLink(pathSoundMix, "Sound Mix English Title X", "Sound Mix English Title X")} Movie Sound Mix Details X1" };
            string[] dataSoundMixEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathSoundMix, "Sound Mix English Title Y", "Sound Mix English Title Y")} Movie Sound Mix Details X2" };
            string[] dataSoundMixEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathSoundMix, "Sound Mix English Title Z", "Sound Mix English Title Z")} Movie Sound Mix Details X3" };
            string[] dataSoundMixDe1 = { "Tonmischung", $"{Formatter.AsInternalLink(pathSoundMix, "Sound Mix English Title X", "Sound Mix German Title X")} Movie Sound Mix Details X1" };
            string[] dataSoundMixDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathSoundMix, "Sound Mix English Title Y", "Sound Mix German Title Y")} Movie Sound Mix Details X2" };
            string[] dataSoundMixDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathSoundMix, "Sound Mix English Title Z", "Sound Mix German Title Z")} Movie Sound Mix Details X3" };
            string[] dataSoundMixZz1 = { "Tonmischung", $"{Formatter.AsInternalLink(pathSoundMix, "Sound Mix English Title X", "Sound Mix German Title X")} Movie Sound Mix Details X1" };
            string[] dataSoundMixZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathSoundMix, "Sound Mix English Title Y", "Sound Mix German Title Y")} Movie Sound Mix Details X2" };
            string[] dataSoundMixZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathSoundMix, "Sound Mix English Title Z", "Sound Mix German Title Z")} Movie Sound Mix Details X3" };

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
            string[] pathColor = { value, "info" };
            string[] dataColorEn1 = { "Color", $"{Formatter.AsInternalLink(pathColor, "Color English Title X", "Color English Title X")} Movie Color Details X1" };
            string[] dataColorEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathColor, "Color English Title Y", "Color English Title Y")} Movie Color Details X2" };
            string[] dataColorEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathColor, "Color English Title Z", "Color English Title Z")} Movie Color Details X3" };
            string[] dataColorDe1 = { "Farbe", $"{Formatter.AsInternalLink(pathColor, "Color English Title X", "Color German Title X")} Movie Color Details X1" };
            string[] dataColorDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathColor, "Color English Title Y", "Color German Title Y")} Movie Color Details X2" };
            string[] dataColorDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathColor, "Color English Title Z", "Color German Title Z")} Movie Color Details X3" };
            string[] dataColorZz1 = { "Farbe", $"{Formatter.AsInternalLink(pathColor, "Color English Title X", "Color German Title X")} Movie Color Details X1" };
            string[] dataColorZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathColor, "Color English Title Y", "Color German Title Y")} Movie Color Details X2" };
            string[] dataColorZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathColor, "Color English Title Z", "Color German Title Z")} Movie Color Details X3" };

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
            string[] dataAspectRatioEn1 = { "Aspect Ratio", "Aspect Ratio X Movie Aspect Ratio Details X1" };
            string[] dataAspectRatioEn2 = { Formatter.CellSpanVertically(), "Aspect Ratio Y Movie Aspect Ratio Details X2" };
            string[] dataAspectRatioEn3 = { Formatter.CellSpanVertically(), "Aspect Ratio Z Movie Aspect Ratio Details X3" };
            string[] dataAspectRatioDe1 = { "Bildformat", "Aspect Ratio X Movie Aspect Ratio Details X1" };
            string[] dataAspectRatioDe2 = { Formatter.CellSpanVertically(), "Aspect Ratio Y Movie Aspect Ratio Details X2" };
            string[] dataAspectRatioDe3 = { Formatter.CellSpanVertically(), "Aspect Ratio Z Movie Aspect Ratio Details X3" };
            string[] dataAspectRatioZz1 = { "Bildformat", "Aspect Ratio X Movie Aspect Ratio Details X1" };
            string[] dataAspectRatioZz2 = { Formatter.CellSpanVertically(), "Aspect Ratio Y Movie Aspect Ratio Details X2" };
            string[] dataAspectRatioZz3 = { Formatter.CellSpanVertically(), "Aspect Ratio Z Movie Aspect Ratio Details X3" };

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
            string[] dataCameraEn1 = { "Camera", "Camera Name X, Camera Lense X Movie Camera Details X1" };
            string[] dataCameraEn2 = { Formatter.CellSpanVertically(), "Camera Name Y, Camera Lense Y Movie Camera Details X2" };
            string[] dataCameraEn3 = { Formatter.CellSpanVertically(), "Camera Name Z, Camera Lense Z Movie Camera Details X3" };
            string[] dataCameraDe1 = { "Kamera", "Camera Name X, Camera Lense X Movie Camera Details X1" };
            string[] dataCameraDe2 = { Formatter.CellSpanVertically(), "Camera Name Y, Camera Lense Y Movie Camera Details X2" };
            string[] dataCameraDe3 = { Formatter.CellSpanVertically(), "Camera Name Z, Camera Lense Z Movie Camera Details X3" };
            string[] dataCameraZz1 = { "Kamera", "Camera Name X, Camera Lense X Movie Camera Details X1" };
            string[] dataCameraZz2 = { Formatter.CellSpanVertically(), "Camera Name Y, Camera Lense Y Movie Camera Details X2" };
            string[] dataCameraZz3 = { Formatter.CellSpanVertically(), "Camera Name Z, Camera Lense Z Movie Camera Details X3" };

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
            string[] dataLaboratoryEn1 = { "Laboratory", "Laboratory Name X Movie Laboratory Details X1" };
            string[] dataLaboratoryEn2 = { Formatter.CellSpanVertically(), "Laboratory Name Y Movie Laboratory Details X2" };
            string[] dataLaboratoryEn3 = { Formatter.CellSpanVertically(), "Laboratory Name Z Movie Laboratory Details X3" };
            string[] dataLaboratoryDe1 = { "Labor", "Laboratory Name X Movie Laboratory Details X1" };
            string[] dataLaboratoryDe2 = { Formatter.CellSpanVertically(), "Laboratory Name Y Movie Laboratory Details X2" };
            string[] dataLaboratoryDe3 = { Formatter.CellSpanVertically(), "Laboratory Name Z Movie Laboratory Details X3" };
            string[] dataLaboratoryZz1 = { "Labor", "Laboratory Name X Movie Laboratory Details X1" };
            string[] dataLaboratoryZz2 = { Formatter.CellSpanVertically(), "Laboratory Name Y Movie Laboratory Details X2" };
            string[] dataLaboratoryZz3 = { Formatter.CellSpanVertically(), "Laboratory Name Z Movie Laboratory Details X3" };

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
            string[] dataFilmLengthEn1 = { "Film Length", "Movie Film Length X Movie Film Length Details X" };
            //string[] dataFilmLengthEn2 = { Formatter.CellSpanVertically(), "Movie Film Length Y Movie Film Length Details X2" };
            //string[] dataFilmLengthEn3 = { Formatter.CellSpanVertically(), "Movie Film Length Z Movie Film Length Details X3" };
            string[] dataFilmLengthDe1 = { "Filmlänge", "Movie Film Length X Movie Film Length Details X" };
            //string[] dataFilmLengthDe2 = { Formatter.CellSpanVertically(), "Movie Film Length Y Movie Film Length Details X2" };
            //string[] dataFilmLengthDe3 = { Formatter.CellSpanVertically(), "Movie Film Length Z Movie Film Length Details X3" };
            string[] dataFilmLengthZz1 = { "Filmlänge", "Movie Film Length X Movie Film Length Details X" };
            //string[] dataFilmLengthZz2 = { Formatter.CellSpanVertically(), "Movie Film Length Y Movie Film Length Details X2" };
            //string[] dataFilmLengthZz3 = { Formatter.CellSpanVertically(), "Movie Film Length Z Movie Film Length Details X3" };

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

            // Infobox Negative Format
            string[] dataNegativeFormatEn1 = { "Negative Format", "Film Format Name X Movie Negative Format Details X1" };
            string[] dataNegativeFormatEn2 = { Formatter.CellSpanVertically(), "Film Format Name Y Movie Negative Format Details X2" };
            string[] dataNegativeFormatEn3 = { Formatter.CellSpanVertically(), "Film Format Name Z Movie Negative Format Details X3" };
            string[] dataNegativeFormatDe1 = { "Negativformat", "Film Format Name X Movie Negative Format Details X1" };
            string[] dataNegativeFormatDe2 = { Formatter.CellSpanVertically(), "Film Format Name Y Movie Negative Format Details X2" };
            string[] dataNegativeFormatDe3 = { Formatter.CellSpanVertically(), "Film Format Name Z Movie Negative Format Details X3" };
            string[] dataNegativeFormatZz1 = { "Negativformat", "Film Format Name X Movie Negative Format Details X1" };
            string[] dataNegativeFormatZz2 = { Formatter.CellSpanVertically(), "Film Format Name Y Movie Negative Format Details X2" };
            string[] dataNegativeFormatZz3 = { Formatter.CellSpanVertically(), "Film Format Name Z Movie Negative Format Details X3" };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataNegativeFormatEn1));
                    content.Add(Formatter.AsTableRow(dataNegativeFormatEn2));
                    content.Add(Formatter.AsTableRow(dataNegativeFormatEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataNegativeFormatDe1));
                    content.Add(Formatter.AsTableRow(dataNegativeFormatDe2));
                    content.Add(Formatter.AsTableRow(dataNegativeFormatDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataNegativeFormatZz1));
                    content.Add(Formatter.AsTableRow(dataNegativeFormatZz2));
                    content.Add(Formatter.AsTableRow(dataNegativeFormatZz3));
                    break;
            }

            // Infobox Cinematographic Process
            string[] dataCinematographicProcessEn1 = { "Cinematographic Process", "Cinematographic Process Name X Movie Cinematographic Process Details X1" };
            string[] dataCinematographicProcessEn2 = { Formatter.CellSpanVertically(), "Cinematographic Process Name Y Movie Cinematographic Process Details X2" };
            string[] dataCinematographicProcessEn3 = { Formatter.CellSpanVertically(), "Cinematographic Process Name Z Movie Cinematographic Process Details X3" };
            string[] dataCinematographicProcessDe1 = { "Filmprozess", "Cinematographic Process Name X Movie Cinematographic Process Details X1" };
            string[] dataCinematographicProcessDe2 = { Formatter.CellSpanVertically(), "Cinematographic Process Name Y Movie Cinematographic Process Details X2" };
            string[] dataCinematographicProcessDe3 = { Formatter.CellSpanVertically(), "Cinematographic Process Name Z Movie Cinematographic Process Details X3" };
            string[] dataCinematographicProcessZz1 = { "Filmprozess", "Cinematographic Process Name X Movie Cinematographic Process Details X1" };
            string[] dataCinematographicProcessZz2 = { Formatter.CellSpanVertically(), "Cinematographic Process Name Y Movie Cinematographic Process Details X2" };
            string[] dataCinematographicProcessZz3 = { Formatter.CellSpanVertically(), "Cinematographic Process Name Z Movie Cinematographic Process Details X3" };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataCinematographicProcessEn1));
                    content.Add(Formatter.AsTableRow(dataCinematographicProcessEn2));
                    content.Add(Formatter.AsTableRow(dataCinematographicProcessEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataCinematographicProcessDe1));
                    content.Add(Formatter.AsTableRow(dataCinematographicProcessDe2));
                    content.Add(Formatter.AsTableRow(dataCinematographicProcessDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataCinematographicProcessZz1));
                    content.Add(Formatter.AsTableRow(dataCinematographicProcessZz2));
                    content.Add(Formatter.AsTableRow(dataCinematographicProcessZz3));
                    break;
            }

            // Infobox Printed Film Format
            string[] dataPrintedFilmFormatEn1 = { "Printed Film Format", "Film Format Name X Movie Printed Film Format Details X1" };
            string[] dataPrintedFilmFormatEn2 = { Formatter.CellSpanVertically(), "Film Format Name Y Movie Printed Film Format Details X2" };
            string[] dataPrintedFilmFormatEn3 = { Formatter.CellSpanVertically(), "Film Format Name Z Movie Printed Film Format Details X3" };
            string[] dataPrintedFilmFormatDe1 = { "Filmformat", "Film Format Name X Movie Printed Film Format Details X1" };
            string[] dataPrintedFilmFormatDe2 = { Formatter.CellSpanVertically(), "Film Format Name Y Movie Printed Film Format Details X2" };
            string[] dataPrintedFilmFormatDe3 = { Formatter.CellSpanVertically(), "Film Format Name Z Movie Printed Film Format Details X3" };
            string[] dataPrintedFilmFormatZz1 = { "Filmformat", "Film Format Name X Movie Printed Film Format Details X1" };
            string[] dataPrintedFilmFormatZz2 = { Formatter.CellSpanVertically(), "Film Format Name Y Movie Printed Film Format Details X2" };
            string[] dataPrintedFilmFormatZz3 = { Formatter.CellSpanVertically(), "Film Format Name Z Movie Printed Film Format Details X3" };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataPrintedFilmFormatEn1));
                    content.Add(Formatter.AsTableRow(dataPrintedFilmFormatEn2));
                    content.Add(Formatter.AsTableRow(dataPrintedFilmFormatEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataPrintedFilmFormatDe1));
                    content.Add(Formatter.AsTableRow(dataPrintedFilmFormatDe2));
                    content.Add(Formatter.AsTableRow(dataPrintedFilmFormatDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataPrintedFilmFormatZz1));
                    content.Add(Formatter.AsTableRow(dataPrintedFilmFormatZz2));
                    content.Add(Formatter.AsTableRow(dataPrintedFilmFormatZz3));
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
            string[] pathDirector = { value, "biography" };
            string[] dataDirector1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Director Role X1) Movie Director Details X1" };
            string[] dataDirector2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Director Role X2) Movie Director Details X2" };
            string[] dataDirector3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Director Role X3) Movie Director Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Directed by")); break;
                case "de": content.Add(Formatter.AsHeading3("Regie")); break;
                default: content.Add(Formatter.AsHeading3("Regie")); break;
            }
            content.Add(Formatter.AsTableRow(dataDirector1));
            content.Add(Formatter.AsTableRow(dataDirector2));
            content.Add(Formatter.AsTableRow(dataDirector3));
            content.Add($"");
            content.Add($"");

            // Writer
            string[] dataWriter1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Writer Role X1) Movie Writer Details X1" };
            string[] dataWriter2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Writer Role X2) Movie Writer Details X2" };
            string[] dataWriter3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Writer Role X3) Movie Writer Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Writing Credits")); break;
                case "de": content.Add(Formatter.AsHeading3("Drehbuch")); break;
                default: content.Add(Formatter.AsHeading3("Drehbuch")); break;
            }
            content.Add(Formatter.AsTableRow(dataWriter1));
            content.Add(Formatter.AsTableRow(dataWriter2));
            content.Add(Formatter.AsTableRow(dataWriter3));
            content.Add($"");
            content.Add($"");

            // Cast
            string[] dataCast1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Cast Character X1) Movie Cast Details X1" };
            string[] dataCast2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Cast Character X2) Movie Cast Details X2" };
            string[] dataCast3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Cast Character X3) Movie Cast Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Cast")); break;
                case "de": content.Add(Formatter.AsHeading3("Darsteller")); break;
                default: content.Add(Formatter.AsHeading3("Darsteller")); break;
            }
            content.Add(Formatter.AsTableRow(dataCast1));
            content.Add(Formatter.AsTableRow(dataCast2));
            content.Add(Formatter.AsTableRow(dataCast3));
            content.Add($"");
            content.Add($"");

            // Producer
            string[] dataProducer1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Producer Role X1) Movie Producer Details X1" };
            string[] dataProducer2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Producer Role X2) Movie Producer Details X2" };
            string[] dataProducer3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Producer Role X3) Movie Producer Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Produced by")); break;
                case "de": content.Add(Formatter.AsHeading3("Produzenten")); break;
                default: content.Add(Formatter.AsHeading3("Produzenten")); break;
            }
            content.Add(Formatter.AsTableRow(dataProducer1));
            content.Add(Formatter.AsTableRow(dataProducer2));
            content.Add(Formatter.AsTableRow(dataProducer3));
            content.Add($"");
            content.Add($"");

            // Music
            string[] dataMusician1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Music Role X1) Movie Music Details X1" };
            string[] dataMusician2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Music Role X2) Movie Music Details X2" };
            string[] dataMusician3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Music Role X3) Movie Music Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Music by")); break;
                case "de": content.Add(Formatter.AsHeading3("Musik")); break;
                default: content.Add(Formatter.AsHeading3("Musik")); break;
            }
            content.Add(Formatter.AsTableRow(dataMusician1));
            content.Add(Formatter.AsTableRow(dataMusician2));
            content.Add(Formatter.AsTableRow(dataMusician3));
            content.Add($"");
            content.Add($"");

            // Cinematography
            string[] dataCinematographer1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Cinematography Role X1) Movie Cinematography Details X1" };
            string[] dataCinematographer2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Cinematography Role X2) Movie Cinematography Details X2" };
            string[] dataCinematographer3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Cinematography Role X3) Movie Cinematography Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Cinematography by")); break;
                case "de": content.Add(Formatter.AsHeading3("Kamera")); break;
                default: content.Add(Formatter.AsHeading3("Kamera")); break;
            }
            content.Add(Formatter.AsTableRow(dataCinematographer1));
            content.Add(Formatter.AsTableRow(dataCinematographer2));
            content.Add(Formatter.AsTableRow(dataCinematographer3));
            content.Add($"");
            content.Add($"");

            // Film Editing
            string[] dataFilmEditor1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Film Editing Role X1) Movie Film Editing Details X1" };
            string[] dataFilmEditor2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Film Editing Role X2) Movie Film Editing Details X2" };
            string[] dataFilmEditor3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Film Editing Role X3) Movie Film Editing Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Film Editing by")); break;
                case "de": content.Add(Formatter.AsHeading3("Schnitt")); break;
                default: content.Add(Formatter.AsHeading3("Schnitt")); break;
            }
            content.Add(Formatter.AsTableRow(dataFilmEditor1));
            content.Add(Formatter.AsTableRow(dataFilmEditor2));
            content.Add(Formatter.AsTableRow(dataFilmEditor3));
            content.Add($"");
            content.Add($"");

            // Casting
            string[] dataCasting1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Casting Role X1) Movie Casting Details X1" };
            string[] dataCasting2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Casting Role X2) Movie Casting Details X2" };
            string[] dataCasting3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Casting Role X3) Movie Casting Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Casting by")); break;
                case "de": content.Add(Formatter.AsHeading3("Casting")); break;
                default: content.Add(Formatter.AsHeading3("Casting")); break;
            }
            content.Add(Formatter.AsTableRow(dataCasting1));
            content.Add(Formatter.AsTableRow(dataCasting2));
            content.Add(Formatter.AsTableRow(dataCasting3));
            content.Add($"");
            content.Add($"");

            // Production Design
            string[] dataProductionDesigner1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Production Design Role X1) Movie Production Design Details X1" };
            string[] dataProductionDesigner2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Production Design Role X2) Movie Production Design Details X2" };
            string[] dataProductionDesigner3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Production Design Role X3) Movie Production Design Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Production Design by")); break;
                case "de": content.Add(Formatter.AsHeading3("Szenenbild")); break;
                default: content.Add(Formatter.AsHeading3("Szenenbild")); break;
            }
            content.Add(Formatter.AsTableRow(dataProductionDesigner1));
            content.Add(Formatter.AsTableRow(dataProductionDesigner2));
            content.Add(Formatter.AsTableRow(dataProductionDesigner3));
            content.Add($"");
            content.Add($"");

            // Art Direction
            string[] dataArtDirector1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Art Direction Role X1) Movie Art Direction Details X1" };
            string[] dataArtDirector2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Art Direction Role X2) Movie Art Direction Details X2" };
            string[] dataArtDirector3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Art Direction Role X3) Movie Art Direction Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Art Direction by")); break;
                case "de": content.Add(Formatter.AsHeading3("Ausstattung")); break;
                default: content.Add(Formatter.AsHeading3("Ausstattung")); break;
            }
            content.Add(Formatter.AsTableRow(dataArtDirector1));
            content.Add(Formatter.AsTableRow(dataArtDirector2));
            content.Add(Formatter.AsTableRow(dataArtDirector3));
            content.Add($"");
            content.Add($"");

            // Set Decoration
            string[] dataSetDecoration1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Set Decoration Role X1) Movie Set Decoration Details X1" };
            string[] dataSetDecoration2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Set Decoration Role X2) Movie Set Decoration Details X2" };
            string[] dataSetDecoration3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Set Decoration Role X3) Movie Set Decoration Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Set Decoration by")); break;
                case "de": content.Add(Formatter.AsHeading3("Bühnenbild")); break;
                default: content.Add(Formatter.AsHeading3("Bühnenbild")); break;
            }
            content.Add(Formatter.AsTableRow(dataSetDecoration1));
            content.Add(Formatter.AsTableRow(dataSetDecoration2));
            content.Add(Formatter.AsTableRow(dataSetDecoration3));
            content.Add($"");
            content.Add($"");

            // Costume Design
            string[] dataCostumeDesign1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Costume Design Role X1) Movie Costume Design Details X1" };
            string[] dataCostumeDesign2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Costume Design Role X2) Movie Costume Design Details X2" };
            string[] dataCostumeDesign3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Costume Design Role X3) Movie Costume Design Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Costume Design by")); break;
                case "de": content.Add(Formatter.AsHeading3("Kostümausstattung")); break;
                default: content.Add(Formatter.AsHeading3("Kostümausstattung")); break;
            }
            content.Add(Formatter.AsTableRow(dataCostumeDesign1));
            content.Add(Formatter.AsTableRow(dataCostumeDesign2));
            content.Add(Formatter.AsTableRow(dataCostumeDesign3));
            content.Add($"");
            content.Add($"");

            // Makeup Department
            string[] dataMakeupDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Makeup Department Role X1) Movie Makeup Department Details X1" };
            string[] dataMakeupDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Makeup Department Role X2) Movie Makeup Department Details X2" };
            string[] dataMakeupDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Makeup Department Role X3) Movie Makeup Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Makeup Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Maske")); break;
                default: content.Add(Formatter.AsHeading3("Maske")); break;
            }
            content.Add(Formatter.AsTableRow(dataMakeupDepartment1));
            content.Add(Formatter.AsTableRow(dataMakeupDepartment2));
            content.Add(Formatter.AsTableRow(dataMakeupDepartment3));
            content.Add($"");
            content.Add($"");

            // Production Management
            string[] dataProductionManagement1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Production Management Role X1) Movie Production Management Details X1" };
            string[] dataProductionManagement2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Production Management Role X2) Movie Production Management Details X2" };
            string[] dataProductionManagement3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Production Management Role X3) Movie Production Management Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Production Management")); break;
                case "de": content.Add(Formatter.AsHeading3("Produktionsleitung")); break;
                default: content.Add(Formatter.AsHeading3("Produktionsleitung")); break;
            }
            content.Add(Formatter.AsTableRow(dataProductionManagement1));
            content.Add(Formatter.AsTableRow(dataProductionManagement2));
            content.Add(Formatter.AsTableRow(dataProductionManagement3));
            content.Add($"");
            content.Add($"");

            // AssistantDirector
            string[] dataAssistantDirector1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Assistant Director Role X1) Movie Assistant Director Details X1" };
            string[] dataAssistantDirector2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Assistant Director Role X2) Movie Assistant Director Details X2" };
            string[] dataAssistantDirector3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Assistant Director Role X3) Movie Assistant Director Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Second Unit Director or Assistant Director")); break;
                case "de": content.Add(Formatter.AsHeading3("Second Unit Regie und Regieassistenz")); break;
                default: content.Add(Formatter.AsHeading3("Second Unit Regie und Regieassistenz")); break;
            }
            content.Add(Formatter.AsTableRow(dataAssistantDirector1));
            content.Add(Formatter.AsTableRow(dataAssistantDirector2));
            content.Add(Formatter.AsTableRow(dataAssistantDirector3));
            content.Add($"");
            content.Add($"");

            // Art Department
            string[] dataArtDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Art Department Role X1) Movie Art Department Details X1" };
            string[] dataArtDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Art Department Role X2) Movie Art Department Details X2" };
            string[] dataArtDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Art Department Role X3) Movie Art Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Art Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Art Abteilung")); break;
                default: content.Add(Formatter.AsHeading3("Art Abteilung")); break;
            }
            content.Add(Formatter.AsTableRow(dataArtDepartment1));
            content.Add(Formatter.AsTableRow(dataArtDepartment2));
            content.Add(Formatter.AsTableRow(dataArtDepartment3));
            content.Add($"");
            content.Add($"");

            // Sound Department
            string[] dataSoundDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Sound Department Role X1) Movie Sound Department Details X1" };
            string[] dataSoundDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Sound Department Role X2) Movie Sound Department Details X2" };
            string[] dataSoundDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Sound Department Role X3) Movie Sound Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Sound Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Sound Abteilung")); break;
                default: content.Add(Formatter.AsHeading3("Sound Abteilung")); break;
            }
            content.Add(Formatter.AsTableRow(dataSoundDepartment1));
            content.Add(Formatter.AsTableRow(dataSoundDepartment2));
            content.Add(Formatter.AsTableRow(dataSoundDepartment3));
            content.Add($"");
            content.Add($"");

            // Special Effects
            string[] dataSpecialEffects1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Special Effects Role X1) Movie Special Effects Details X1" };
            string[] dataSpecialEffects2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Special Effects Role X2) Movie Special Effects Details X2" };
            string[] dataSpecialEffects3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Special Effects Role X3) Movie Special Effects Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Special Effects by")); break;
                case "de": content.Add(Formatter.AsHeading3("Spezialeffekte")); break;
                default: content.Add(Formatter.AsHeading3("Spezialeffekte")); break;
            }
            content.Add(Formatter.AsTableRow(dataSpecialEffects1));
            content.Add(Formatter.AsTableRow(dataSpecialEffects2));
            content.Add(Formatter.AsTableRow(dataSpecialEffects3));
            content.Add($"");
            content.Add($"");

            // Visual Effects
            string[] dataVisualEffects1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Visual Effects Role X1) Movie Visual Effects Details X1" };
            string[] dataVisualEffects2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Visual Effects Role X2) Movie Visual Effects Details X2" };
            string[] dataVisualEffects3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Visual Effects Role X3) Movie Visual Effects Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Visual Effects by")); break;
                case "de": content.Add(Formatter.AsHeading3("Visuelle Effekte")); break;
                default: content.Add(Formatter.AsHeading3("Visuelle Effekte")); break;
            }
            content.Add(Formatter.AsTableRow(dataVisualEffects1));
            content.Add(Formatter.AsTableRow(dataVisualEffects2));
            content.Add(Formatter.AsTableRow(dataVisualEffects3));
            content.Add($"");
            content.Add($"");

            // Stunts
            string[] dataStunts1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Stunts Role X1) Movie Stunts Details X1" };
            string[] dataStunts2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Stunts Role X2) Movie Stunts Details X2" };
            string[] dataStunts3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Stunts Role X3) Movie Stunts Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Stunts by")); break;
                case "de": content.Add(Formatter.AsHeading3("Stunts")); break;
                default: content.Add(Formatter.AsHeading3("Stunts")); break;
            }
            content.Add(Formatter.AsTableRow(dataStunts1));
            content.Add(Formatter.AsTableRow(dataStunts2));
            content.Add(Formatter.AsTableRow(dataStunts3));
            content.Add($"");
            content.Add($"");

            // Electrical Department
            string[] dataElectricalDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Electrical Department Role X1) Movie Electrical Department Details X1" };
            string[] dataElectricalDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Electrical Department Role X2) Movie Electrical Department Details X2" };
            string[] dataElectricalDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Electrical Department Role X3) Movie Electrical Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Camera and Electrical Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Kamera und Beleuchtung")); break;
                default: content.Add(Formatter.AsHeading3("Kamera und Beleuchtung")); break;
            }
            content.Add(Formatter.AsTableRow(dataElectricalDepartment1));
            content.Add(Formatter.AsTableRow(dataElectricalDepartment2));
            content.Add(Formatter.AsTableRow(dataElectricalDepartment3));
            content.Add($"");
            content.Add($"");

            // Animation Department
            string[] dataAnimationDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Animation Department Role X1) Movie Animation Department Details X1" };
            string[] dataAnimationDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Animation Department Role X2) Movie Animation Department Details X2" };
            string[] dataAnimationDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Animation Department Role X3) Movie Animation Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Animation Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Animationen")); break;
                default: content.Add(Formatter.AsHeading3("Animationen")); break;
            }
            content.Add(Formatter.AsTableRow(dataAnimationDepartment1));
            content.Add(Formatter.AsTableRow(dataAnimationDepartment2));
            content.Add(Formatter.AsTableRow(dataAnimationDepartment3));
            content.Add($"");
            content.Add($"");

            // Casting Department
            string[] dataCastingDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Casting Department Role X1) Movie Casting Department Details X1" };
            string[] dataCastingDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Casting Department Role X2) Movie Casting Department Details X2" };
            string[] dataCastingDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Casting Department Role X3) Movie Casting Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Casting Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Casting")); break;
                default: content.Add(Formatter.AsHeading3("Casting")); break;
            }
            content.Add(Formatter.AsTableRow(dataCastingDepartment1));
            content.Add(Formatter.AsTableRow(dataCastingDepartment2));
            content.Add(Formatter.AsTableRow(dataCastingDepartment3));
            content.Add($"");
            content.Add($"");

            // Costume Department
            string[] dataCostumeDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Costume Department Role X1) Movie Costume Department Details X1" };
            string[] dataCostumeDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Costume Department Role X2) Movie Costume Department Details X2" };
            string[] dataCostumeDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Costume Department Role X3) Movie Costume Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Costume and Wardrobe Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Kostümbildnerei")); break;
                default: content.Add(Formatter.AsHeading3("Kostümbildnerei")); break;
            }
            content.Add(Formatter.AsTableRow(dataCostumeDepartment1));
            content.Add(Formatter.AsTableRow(dataCostumeDepartment2));
            content.Add(Formatter.AsTableRow(dataCostumeDepartment3));
            content.Add($"");
            content.Add($"");

            // Editorial Department
            string[] dataEditorialDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Editorial Department Role X1) Movie Editorial Department Details X1" };
            string[] dataEditorialDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Editorial Department Role X2) Movie Editorial Department Details X2" };
            string[] dataEditorialDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Editorial Department Role X3) Movie Editorial Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Editorial Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Redaktion")); break;
                default: content.Add(Formatter.AsHeading3("Redaktion")); break;
            }
            content.Add(Formatter.AsTableRow(dataEditorialDepartment1));
            content.Add(Formatter.AsTableRow(dataEditorialDepartment2));
            content.Add(Formatter.AsTableRow(dataEditorialDepartment3));
            content.Add($"");
            content.Add($"");

            // Location Management
            string[] dataLocationManagement1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Location Management Role X1) Movie Location Management Details X1" };
            string[] dataLocationManagement2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Location Management Role X2) Movie Location Management Details X2" };
            string[] dataLocationManagement3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Location Management Role X3) Movie Location Management Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Location Management")); break;
                case "de": content.Add(Formatter.AsHeading3("Drehort Management")); break;
                default: content.Add(Formatter.AsHeading3("Drehort Management")); break;
            }
            content.Add(Formatter.AsTableRow(dataLocationManagement1));
            content.Add(Formatter.AsTableRow(dataLocationManagement2));
            content.Add(Formatter.AsTableRow(dataLocationManagement3));
            content.Add($"");
            content.Add($"");

            // Music Department
            string[] dataMusicDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Music Department Role X1) Movie Music Department Details X1" };
            string[] dataMusicDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Music Department Role X2) Movie Music Department Details X2" };
            string[] dataMusicDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Music Department Role X3) Movie Music Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Music Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Musik")); break;
                default: content.Add(Formatter.AsHeading3("Musik")); break;
            }
            content.Add(Formatter.AsTableRow(dataMusicDepartment1));
            content.Add(Formatter.AsTableRow(dataMusicDepartment2));
            content.Add(Formatter.AsTableRow(dataMusicDepartment3));
            content.Add($"");
            content.Add($"");

            // Continuity Department
            string[] dataContinuityDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person First Name X Person Last Name X Person Name AddOn X"), "(Movie Continuity Department Role X1) Movie Continuity Department Details X1" };
            string[] dataContinuityDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person First Name Y Person Last Name Y Person Name AddOn Y"), "(Movie Continuity Department Role X2) Movie Continuity Department Details X2" };
            string[] dataContinuityDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person First Name Z Person Last Name Z Person Name AddOn Z"), "(Movie Continuity Department Role X3) Movie Continuity Department Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Script and Continuity Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Dramaturgie und Continuity")); break;
                default: content.Add(Formatter.AsHeading3("Dramaturgie und Continuity")); break;
            }
            content.Add(Formatter.AsTableRow(dataContinuityDepartment1));
            content.Add(Formatter.AsTableRow(dataContinuityDepartment2));
            content.Add(Formatter.AsTableRow(dataContinuityDepartment3));
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
