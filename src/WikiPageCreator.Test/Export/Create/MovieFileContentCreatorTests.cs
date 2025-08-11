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


using EntertainmentDB.Data;
using EntertainmentDB.DBAccess.Read;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WikiPageCreator.Export.Format;

namespace WikiPageCreator.Export.Create.Tests
{
    [Ignore()] // MovieFileContentCreator is already deprecated; no changes will be commited to class 
    [TestClass()]
    public class MovieFileContentCreatorTests
    {
        public Formatter Formatter { get; set; } = new DokuWikiFormatter();

        [TestMethod()]
        public void MovieFileContentCreatorTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            // Assert
            Assert.IsNotNull(creator);
        }

        [TestMethod()]
        public void GetFileNameTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            string filename = creator.GetFileName();

            // Assert
            Assert.AreEqual(creator.Formatter.AsFilename($"{movie.OriginalTitle} ({movie.ReleaseDate[0..4]})"), filename);
        }

        [TestMethod()]
        public void CreateHeaderTest()
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateHeader("zz");

            // Assert
            List<string> content = new List<string>();

            content.Add(creator.Formatter.DisableCache());
            content.Add(creator.Formatter.DisableTOC());
            content.Add(creator.Formatter.BeginComment());
            content.Add($"   Movie OriginalTitle X");
            content.Add($"");
            content.Add($"   @author  WikiPageCreator");
            content.Add($"   @date    {DateTime.Now:yyyy-MM-dd}");
            content.Add($"   @version Status EnglishTitle X: Movie LastUpdated X");
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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateTitle(value);

            // Assert
            List<string> content = new List<string>();

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading1("Movie EnglishTitle X")); break;
                case "de": content.Add(Formatter.AsHeading1("Movie GermanTitle X")); break;
                default: content.Add(Formatter.AsHeading1("Movie OriginalTitle X")); break;
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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxTitle(value);

            // Assert
            List<string> content = new List<string>();
            string[] dataEn = { "Original Title", "Movie OriginalTitle X" };
            string[] dataDe = { "Originaltitel", "Movie OriginalTitle X" };

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
        public void CreateInfoBoxLogoTest(string value)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxLogo(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { "cinema_and_television_movie" };
            string dataEn0 = Formatter.AsImage(path, "Image FileName X", 450, "Type EnglishTitle X");
            string dataDe0 = Formatter.AsImage(path, "Image FileName X", 450, "Type GermanTitle X");
            string[] dataEn = { dataEn0, null };
            string[] dataDe = { dataDe0, null };

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxType(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "info" };
            string[] dataEn = { "Type", Formatter.AsInternalLink(path, "Type EnglishTitle X", "Type EnglishTitle X") };
            string[] dataDe = { "Typ", Formatter.AsInternalLink(path, "Type EnglishTitle X", "Type GermanTitle X") };
            string[] dataZz = { "Typ", Formatter.AsInternalLink(path, "Type EnglishTitle X", "Type GermanTitle X") };

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxOriginalReleaseDate(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "date" };
            string[] dataEn = { "Original Release Date", Formatter.AsInternalLink(path, "Movie ReleaseDate X", "Movie ReleaseDate X") };
            string[] dataDe = { "Erstausstrahlung", Formatter.AsInternalLink(path, "Movie ReleaseDate X", "Movie ReleaseDate X") };
            string[] dataZz = { "Erstausstrahlung", Formatter.AsInternalLink(path, "Movie ReleaseDate X", "Movie ReleaseDate X") };

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxGenre(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "info" };
            string[] dataEn1 = { "Genre", $"{Formatter.AsInternalLink(path, "Genre EnglishTitle X", "Genre EnglishTitle X")} Movie Genre Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Genre EnglishTitle Y", "Genre EnglishTitle Y")} Movie Genre Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Genre EnglishTitle Z", "Genre EnglishTitle Z")} Movie Genre Details X3" };
            string[] dataDe1 = { "Genre", $"{Formatter.AsInternalLink(path, "Genre EnglishTitle X", "Genre GermanTitle X")} Movie Genre Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Genre EnglishTitle Y", "Genre GermanTitle Y")} Movie Genre Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Genre EnglishTitle Z", "Genre GermanTitle Z")} Movie Genre Details X3" };
            string[] dataZz1 = { "Genre", $"{Formatter.AsInternalLink(path, "Genre EnglishTitle X", "Genre GermanTitle X")} Movie Genre Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Genre EnglishTitle Y", "Genre GermanTitle Y")} Movie Genre Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Genre EnglishTitle Z", "Genre GermanTitle Z")} Movie Genre Details X3" };

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxCertification(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { "certification" };
            string[] dataEn1 = { "Certification", $"{Formatter.AsImage(path, "Image FileName X", 75)} Movie Certification Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(path, "Image FileName Y", 75)} Movie Certification Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(path, "Image FileName Z", 75)} Movie Certification Details X3" };
            string[] dataDe1 = { "Altersfreigabe", $"{Formatter.AsImage(path, "Image FileName X", 75)} Movie Certification Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(path, "Image FileName Y", 75)} Movie Certification Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(path, "Image FileName Z", 75)} Movie Certification Details X3" };
            string[] dataZz1 = { "Altersfreigabe", $"{Formatter.AsImage(path, "Image FileName X", 75)} Movie Certification Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(path, "Image FileName Y", 75)} Movie Certification Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(path, "Image FileName Z", 75)} Movie Certification Details X3" };

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxCountry(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "info" };
            string[] dataEn1 = { "Production Country", $"{Formatter.AsInternalLink(path, "Country OriginalFullName X", "Country EnglishShortName X")} Movie Country Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Country OriginalFullName Y", "Country EnglishShortName Y")} Movie Country Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Country OriginalFullName Z", "Country EnglishShortName Z")} Movie Country Details X3" };
            string[] dataDe1 = { "Produktionsland", $"{Formatter.AsInternalLink(path, "Country OriginalFullName X", "Country GermanShortName X")} Movie Country Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Country OriginalFullName Y", "Country GermanShortName Y")} Movie Country Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Country OriginalFullName Z", "Country GermanShortName Z")} Movie Country Details X3" };
            string[] dataZz1 = { "Produktionsland", $"{Formatter.AsInternalLink(path, "Country OriginalFullName X", "Country GermanShortName X")} Movie Country Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Country OriginalFullName Y", "Country GermanShortName Y")} Movie Country Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Country OriginalFullName Z", "Country GermanShortName Z")} Movie Country Details X3" };

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxLanguage(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "info" };
            string[] dataEn1 = { "Language", $"{Formatter.AsInternalLink(path, "Language OriginalName X", "Language EnglishName X")} Movie Language Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Language OriginalName Y", "Language EnglishName Y")} Movie Language Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Language OriginalName Z", "Language EnglishName Z")} Movie Language Details X3" };
            string[] dataDe1 = { "Sprache", $"{Formatter.AsInternalLink(path, "Language OriginalName X", "Language GermanName X")} Movie Language Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Language OriginalName Y", "Language GermanName Y")} Movie Language Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Language OriginalName Z", "Language GermanName Z")} Movie Language Details X3" };
            string[] dataZz1 = { "Sprache", $"{Formatter.AsInternalLink(path, "Language OriginalName X", "Language GermanName X")} Movie Language Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Language OriginalName Y", "Language GermanName Y")} Movie Language Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Language OriginalName Z", "Language GermanName Z")} Movie Language Details X3" };

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxWorldwideGross(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "date" };
            string[] dataEn = { "Worldwide Gross", $"Movie WorldwideGross X ({Formatter.AsInternalLink(path, "Movie WorldwideGrossDate X", "Movie WorldwideGrossDate X")})" };
            string[] dataDe = { "Einspielergebnis (weltweit)", $"Movie WorldwideGross X ({Formatter.AsInternalLink(path, "Movie WorldwideGrossDate X", "Movie WorldwideGrossDate X")})" };
            string[] dataZz = { "Einspielergebnis (weltweit)", $"Movie WorldwideGross X ({Formatter.AsInternalLink(path, "Movie WorldwideGrossDate X", "Movie WorldwideGrossDate X")})" };

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxRuntime(value);

            List<string> content = new List<string>();
            string[] path = { value, "info" };
            string[] dataEn1 = { "Runtime", $"11 min. ({Formatter.AsInternalLink(path, "Edition EnglishTitle X", "Edition EnglishTitle X")}) Movie Runtime Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), $"12 min. ({Formatter.AsInternalLink(path, "Edition EnglishTitle Y", "Edition EnglishTitle Y")}) Movie Runtime Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), $"13 min. ({Formatter.AsInternalLink(path, "Edition EnglishTitle Z", "Edition EnglishTitle Z")}) Movie Runtime Details X3" };
            string[] dataDe1 = { "Laufzeit", $"11 min. ({Formatter.AsInternalLink(path, "Edition EnglishTitle X", "Edition GermanTitle X")}) Movie Runtime Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), $"12 min. ({Formatter.AsInternalLink(path, "Edition EnglishTitle Y", "Edition GermanTitle Y")}) Movie Runtime Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), $"13 min. ({Formatter.AsInternalLink(path, "Edition EnglishTitle Z", "Edition GermanTitle Z")}) Movie Runtime Details X3" };
            string[] dataZz1 = { "Laufzeit", $"11 min. ({Formatter.AsInternalLink(path, "Edition EnglishTitle X", "Edition GermanTitle X")}) Movie Runtime Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), $"12 min. ({Formatter.AsInternalLink(path, "Edition EnglishTitle Y", "Edition GermanTitle Y")}) Movie Runtime Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), $"13 min. ({Formatter.AsInternalLink(path, "Edition EnglishTitle Z", "Edition GermanTitle Z")}) Movie Runtime Details X3" };

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxSoundMix(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "info" };
            string[] dataEn1 = { "Sound Mix", $"{Formatter.AsInternalLink(path, "SoundMix EnglishTitle X", "SoundMix EnglishTitle X")} Movie SoundMix Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "SoundMix EnglishTitle Y", "SoundMix EnglishTitle Y")} Movie SoundMix Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "SoundMix EnglishTitle Z", "SoundMix EnglishTitle Z")} Movie SoundMix Details X3" };
            string[] dataDe1 = { "Tonmischung", $"{Formatter.AsInternalLink(path, "SoundMix EnglishTitle X", "SoundMix GermanTitle X")} Movie SoundMix Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "SoundMix EnglishTitle Y", "SoundMix GermanTitle Y")} Movie SoundMix Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "SoundMix EnglishTitle Z", "SoundMix GermanTitle Z")} Movie SoundMix Details X3" };
            string[] dataZz1 = { "Tonmischung", $"{Formatter.AsInternalLink(path, "SoundMix EnglishTitle X", "SoundMix GermanTitle X")} Movie SoundMix Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "SoundMix EnglishTitle Y", "SoundMix GermanTitle Y")} Movie SoundMix Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "SoundMix EnglishTitle Z", "SoundMix GermanTitle Z")} Movie SoundMix Details X3" };

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxColor(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "info" };
            string[] dataEn1 = { "Color", $"{Formatter.AsInternalLink(path, "Color EnglishTitle X", "Color EnglishTitle X")} Movie Color Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Color EnglishTitle Y", "Color EnglishTitle Y")} Movie Color Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Color EnglishTitle Z", "Color EnglishTitle Z")} Movie Color Details X3" };
            string[] dataDe1 = { "Farbe", $"{Formatter.AsInternalLink(path, "Color EnglishTitle X", "Color GermanTitle X")} Movie Color Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Color EnglishTitle Y", "Color GermanTitle Y")} Movie Color Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Color EnglishTitle Z", "Color GermanTitle Z")} Movie Color Details X3" };
            string[] dataZz1 = { "Farbe", $"{Formatter.AsInternalLink(path, "Color EnglishTitle X", "Color GermanTitle X")} Movie Color Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Color EnglishTitle Y", "Color GermanTitle Y")} Movie Color Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(path, "Color EnglishTitle Z", "Color GermanTitle Z")} Movie Color Details X3" };

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxAspectRatio(value);

            // Assert
            List<string> content = new List<string>();
            string[] dataEn1 = { "Aspect Ratio", "AspectRatio Ratio X Movie AspectRatio Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), "AspectRatio Ratio Y Movie AspectRatio Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), "AspectRatio Ratio Z Movie AspectRatio Details X3" };
            string[] dataDe1 = { "Bildformat", "AspectRatio Ratio X Movie AspectRatio Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), "AspectRatio Ratio Y Movie AspectRatio Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), "AspectRatio Ratio Z Movie AspectRatio Details X3" };
            string[] dataZz1 = { "Bildformat", "AspectRatio Ratio X Movie AspectRatio Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), "AspectRatio Ratio Y Movie AspectRatio Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), "AspectRatio Ratio Z Movie AspectRatio Details X3" };

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxCamera(value);

            // Assert
            List<string> content = new List<string>();
            string[] dataEn1 = { "Camera", "Camera Name X, Camera Lenses X Movie Camera Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), "Camera Name Y, Camera Lenses Y Movie Camera Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), "Camera Name Z, Camera Lenses Z Movie Camera Details X3" };
            string[] dataDe1 = { "Kamera", "Camera Name X, Camera Lenses X Movie Camera Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), "Camera Name Y, Camera Lenses Y Movie Camera Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), "Camera Name Z, Camera Lenses Z Movie Camera Details X3" };
            string[] dataZz1 = { "Kamera", "Camera Name X, Camera Lenses X Movie Camera Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), "Camera Name Y, Camera Lenses Y Movie Camera Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), "Camera Name Z, Camera Lenses Z Movie Camera Details X3" };

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxFilmLength(value);

            // Assert
            List<string> content = new List<string>();
            string[] dataEn1 = { "Film Length", "Movie FilmLength Length X1 Movie FilmLength Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), "Movie FilmLength Length X2 Movie FilmLength Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), "Movie FilmLength Length X3 Movie FilmLength Details X3" };
            string[] dataDe1 = { "Filmlänge", "Movie FilmLength Length X1 Movie FilmLength Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), "Movie FilmLength Length X2 Movie FilmLength Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), "Movie FilmLength Length X3 Movie FilmLength Details X3" };
            string[] dataZz1 = { "Filmlänge", "Movie FilmLength Length X1 Movie FilmLength Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), "Movie FilmLength Length X2 Movie FilmLength Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), "Movie FilmLength Length X3 Movie FilmLength Details X3" };

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
        public void CreateInfoBoxNegativeFormatTest(string value)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxNegativeFormat(value);

            // Assert
            List<string> content = new List<string>();
            string[] dataEn1 = { "Negative Format", "FilmFormat Format X Movie NegativeFormat Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), "FilmFormat Format Y Movie NegativeFormat Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), "FilmFormat Format Z Movie NegativeFormat Details X3" };
            string[] dataDe1 = { "Negativformat", "FilmFormat Format X Movie NegativeFormat Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), "FilmFormat Format Y Movie NegativeFormat Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), "FilmFormat Format Z Movie NegativeFormat Details X3" };
            string[] dataZz1 = { "Negativformat", "FilmFormat Format X Movie NegativeFormat Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), "FilmFormat Format Y Movie NegativeFormat Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), "FilmFormat Format Z Movie NegativeFormat Details X3" };

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxCinematographicProcess(value);

            // Assert
            List<string> content = new List<string>();
            string[] dataEn1 = { "Cinematographic Process", "CinematographicProcess Name X Movie CinematographicProcess Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), "CinematographicProcess Name Y Movie CinematographicProcess Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), "CinematographicProcess Name Z Movie CinematographicProcess Details X3" };
            string[] dataDe1 = { "Filmprozess", "CinematographicProcess Name X Movie CinematographicProcess Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), "CinematographicProcess Name Y Movie CinematographicProcess Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), "CinematographicProcess Name Z Movie CinematographicProcess Details X3" };
            string[] dataZz1 = { "Filmprozess", "CinematographicProcess Name X Movie CinematographicProcess Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), "CinematographicProcess Name Y Movie CinematographicProcess Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), "CinematographicProcess Name Z Movie CinematographicProcess Details X3" };

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateInfoBoxPrintedFilmFormat(value);

            // Assert
            List<string> content = new List<string>();
            string[] dataEn1 = { "Printed Film Format", "FilmFormat Format X Movie PrintedFilmFormat Details X1" };
            string[] dataEn2 = { Formatter.CellSpanVertically(), "FilmFormat Format Y Movie PrintedFilmFormat Details X2" };
            string[] dataEn3 = { Formatter.CellSpanVertically(), "FilmFormat Format Z Movie PrintedFilmFormat Details X3" };
            string[] dataDe1 = { "Filmformat", "FilmFormat Format X Movie PrintedFilmFormat Details X1" };
            string[] dataDe2 = { Formatter.CellSpanVertically(), "FilmFormat Format Y Movie PrintedFilmFormat Details X2" };
            string[] dataDe3 = { Formatter.CellSpanVertically(), "FilmFormat Format Z Movie PrintedFilmFormat Details X3" };
            string[] dataZz1 = { "Filmformat", "FilmFormat Format X Movie PrintedFilmFormat Details X1" };
            string[] dataZz2 = { Formatter.CellSpanVertically(), "FilmFormat Format Y Movie PrintedFilmFormat Details X2" };
            string[] dataZz3 = { Formatter.CellSpanVertically(), "FilmFormat Format Z Movie PrintedFilmFormat Details X3" };

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
        public void CreatePosterChapterTest(string value)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreatePosterChapter(value);

            // Assert
            List<string> content = new List<string>();
            string[] pathCompany = { value, "company" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Poster")); break;
                case "de": content.Add(Formatter.AsHeading2("Poster")); break;
                default: content.Add(Formatter.AsHeading2("Poster")); break;
            }

            // TODO: change to use formatter

            switch (value)
            {
                case "en":
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName X?200|Type EnglishTitle X \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Y?200|Type EnglishTitle Y \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Z?200|Type EnglishTitle Z \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    break;
                case "de":
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName X?200|Type GermanTitle X \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Y?200|Type GermanTitle Y \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Z?200|Type GermanTitle Z \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    break;
                default:
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName X?200|Type GermanTitle X \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Y?200|Type GermanTitle Y \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Z?200|Type GermanTitle Z \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    break;
            }
            content.Add("");

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
        public void CreateCoverChapterTest(string value)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateCoverChapter(value);

            // Assert
            List<string> content = new List<string>();
            string[] pathCompany = { value, "company" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Cover")); break;
                case "de": content.Add(Formatter.AsHeading2("Cover")); break;
                default: content.Add(Formatter.AsHeading2("Cover")); break;
            }

            // TODO: change to use formatter

            switch (value)
            {
                case "en":
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName X?200|Type EnglishTitle X \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Y?200|Type EnglishTitle Y \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Z?200|Type EnglishTitle Z \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    break;
                case "de":
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName X?200|Type GermanTitle X \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Y?200|Type GermanTitle Y \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Z?200|Type GermanTitle Z \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    break;
                default:
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName X?200|Type GermanTitle X \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Y?200|Type GermanTitle Y \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Z?200|Type GermanTitle Z \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    break;
            }
            content.Add("");

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
        public void CreateDescriptionChapterTest(string value)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);
            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateDescriptionChapter(value);

            // Assert
            List<string> content = new List<string>();
            string[] pathPerson = { value, "biography" };
            string[] pathCompany = { value, "company" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Descriptions")); break;
                case "de": content.Add(Formatter.AsHeading2("Beschreibungen")); break;
                default: content.Add(Formatter.AsHeading2("Beschreibungen")); break;
            }

            string data = $"({Formatter.AsInternalLink(pathPerson, "Person FirstName X Person LastName X Person NameAddOn X")}, " +
                $"{Formatter.AsInternalLink(pathPerson, "Person FirstName Y Person LastName Y Person NameAddOn Y")}, " +
                $"{Formatter.AsInternalLink(pathPerson, "Person FirstName Z Person LastName Z Person NameAddOn Z")}, " +
                $"{Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, " +
                $"{Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, " +
                $"{Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})";

            switch (value)
            {
                case "en":
                    content.Add("Text Content X");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Y");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Z");
                    content.Add(data);
                    content.Add("");
                    break;
                case "de":
                    content.Add("Text Content X");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Y");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Z");
                    content.Add(data);
                    content.Add("");
                    break;
                default:
                    content.Add("Text Content X");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Y");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Z");
                    content.Add(data);
                    content.Add("");
                    break;
            }
            content.Add("");

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
        public void CreateReviewChapterTest(string value)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateReviewChapter(value);

            // Assert
            List<string> content = new List<string>();
            string[] pathPerson = { value, "biography" };
            string[] pathCompany = { value, "company" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Reviews")); break;
                case "de": content.Add(Formatter.AsHeading2("Rezensionen")); break;
                default: content.Add(Formatter.AsHeading2("Rezensionen")); break;
            }

            string data = $"({Formatter.AsInternalLink(pathPerson, "Person FirstName X Person LastName X Person NameAddOn X")}, " +
                $"{Formatter.AsInternalLink(pathPerson, "Person FirstName Y Person LastName Y Person NameAddOn Y")}, " +
                $"{Formatter.AsInternalLink(pathPerson, "Person FirstName Z Person LastName Z Person NameAddOn Z")}, " +
                $"{Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, " +
                $"{Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, " +
                $"{Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})";

            switch (value)
            {
                case "en":
                    content.Add("Text Content X");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Y");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Z");
                    content.Add(data);
                    content.Add("");
                    break;
                case "de":
                    content.Add("Text Content X");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Y");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Z");
                    content.Add(data);
                    content.Add("");
                    break;
                default:
                    content.Add("Text Content X");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Y");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Z");
                    content.Add(data);
                    content.Add("");
                    break;
            }
            content.Add("");


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
        public void CreateImageChapterTest(string value)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateImageChapter(value);
            string[] pathCompany = { value, "company" };

            // Assert
            List<string> content = new List<string>();

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Images")); break;
                case "de": content.Add(Formatter.AsHeading2("Bilder")); break;
                default: content.Add(Formatter.AsHeading2("Bilder")); break;
            }

            // TODO: change to use formatter

            switch (value)
            {
                case "en":
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName X?200|Type EnglishTitle X \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Y?200|Type EnglishTitle Y \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Z?200|Type EnglishTitle Z \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    break;
                case "de":
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName X?200|Type GermanTitle X \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Y?200|Type GermanTitle Y \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Z?200|Type GermanTitle Z \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    break;
                default:
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName X?200|Type GermanTitle X \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Y?200|Type GermanTitle Y \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Z?200|Type GermanTitle Z \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    break;
            }
            content.Add("");

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

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
            string[] dataDirector1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie Director Role X1) Movie Director Details X1" };
            string[] dataDirector2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie Director Role X2) Movie Director Details X2" };
            string[] dataDirector3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie Director Role X3) Movie Director Details X3" };

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
            string[] dataWriter1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie Writer Role X1) Movie Writer Details X1" };
            string[] dataWriter2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie Writer Role X2) Movie Writer Details X2" };
            string[] dataWriter3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie Writer Role X3) Movie Writer Details X3" };

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
            string[] dataCast1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie Cast Character X1) Movie Cast Details X1", Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X") };
            string[] dataCast2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie Cast Character X2) Movie Cast Details X2", Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X") };
            string[] dataCast3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie Cast Character X3) Movie Cast Details X3", Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X") };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsHeading3("Cast"));
                    content.Add("Cast is Status EnglishTitle X.");
                    content.Add("");
                    break;
                case "de":
                    content.Add(Formatter.AsHeading3("Darsteller"));
                    content.Add("Darsteller sind Status GermanTitle X.");
                    content.Add("");
                    break;
                default:
                    content.Add(Formatter.AsHeading3("Darsteller"));
                    content.Add("Darsteller sind Status GermanTitle X.");
                    content.Add("");
                    break;
            }
            content.Add(Formatter.AsTableRow(dataCast1));
            content.Add(Formatter.AsTableRow(dataCast2));
            content.Add(Formatter.AsTableRow(dataCast3));
            content.Add($"");
            content.Add($"");

            // Producer
            string[] dataProducer1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie Producer Role X1) Movie Producer Details X1" };
            string[] dataProducer2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie Producer Role X2) Movie Producer Details X2" };
            string[] dataProducer3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie Producer Role X3) Movie Producer Details X3" };

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
            string[] dataMusician1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie Music Role X1) Movie Music Details X1" };
            string[] dataMusician2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie Music Role X2) Movie Music Details X2" };
            string[] dataMusician3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie Music Role X3) Movie Music Details X3" };

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
            string[] dataCinematographer1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie Cinematography Role X1) Movie Cinematography Details X1" };
            string[] dataCinematographer2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie Cinematography Role X2) Movie Cinematography Details X2" };
            string[] dataCinematographer3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie Cinematography Role X3) Movie Cinematography Details X3" };

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
            string[] dataFilmEditor1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie FilmEditing Role X1) Movie FilmEditing Details X1" };
            string[] dataFilmEditor2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie FilmEditing Role X2) Movie FilmEditing Details X2" };
            string[] dataFilmEditor3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie FilmEditing Role X3) Movie FilmEditing Details X3" };

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
            string[] dataCasting1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie Casting Role X1) Movie Casting Details X1" };
            string[] dataCasting2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie Casting Role X2) Movie Casting Details X2" };
            string[] dataCasting3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie Casting Role X3) Movie Casting Details X3" };

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
            string[] dataProductionDesigner1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie ProductionDesign Role X1) Movie ProductionDesign Details X1" };
            string[] dataProductionDesigner2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie ProductionDesign Role X2) Movie ProductionDesign Details X2" };
            string[] dataProductionDesigner3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie ProductionDesign Role X3) Movie ProductionDesign Details X3" };

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
            string[] dataArtDirector1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie ArtDirection Role X1) Movie ArtDirection Details X1" };
            string[] dataArtDirector2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie ArtDirection Role X2) Movie ArtDirection Details X2" };
            string[] dataArtDirector3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie ArtDirection Role X3) Movie ArtDirection Details X3" };

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
            string[] dataSetDecoration1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie SetDecoration Role X1) Movie SetDecoration Details X1" };
            string[] dataSetDecoration2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie SetDecoration Role X2) Movie SetDecoration Details X2" };
            string[] dataSetDecoration3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie SetDecoration Role X3) Movie SetDecoration Details X3" };

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
            string[] dataCostumeDesign1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie CostumeDesign Role X1) Movie CostumeDesign Details X1" };
            string[] dataCostumeDesign2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie CostumeDesign Role X2) Movie CostumeDesign Details X2" };
            string[] dataCostumeDesign3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie CostumeDesign Role X3) Movie CostumeDesign Details X3" };

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
            string[] dataMakeupDepartment1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie MakeupDepartment Role X1) Movie MakeupDepartment Details X1" };
            string[] dataMakeupDepartment2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie MakeupDepartment Role X2) Movie MakeupDepartment Details X2" };
            string[] dataMakeupDepartment3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie MakeupDepartment Role X3) Movie MakeupDepartment Details X3" };

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
            string[] dataProductionManagement1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie ProductionManagement Role X1) Movie ProductionManagement Details X1" };
            string[] dataProductionManagement2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie ProductionManagement Role X2) Movie ProductionManagement Details X2" };
            string[] dataProductionManagement3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie ProductionManagement Role X3) Movie ProductionManagement Details X3" };

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
            string[] dataAssistantDirector1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie AssistantDirector Role X1) Movie AssistantDirector Details X1" };
            string[] dataAssistantDirector2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie AssistantDirector Role X2) Movie AssistantDirector Details X2" };
            string[] dataAssistantDirector3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie AssistantDirector Role X3) Movie AssistantDirector Details X3" };

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
            string[] dataArtDepartment1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie ArtDepartment Role X1) Movie ArtDepartment Details X1" };
            string[] dataArtDepartment2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie ArtDepartment Role X2) Movie ArtDepartment Details X2" };
            string[] dataArtDepartment3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie ArtDepartment Role X3) Movie ArtDepartment Details X3" };

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
            string[] dataSoundDepartment1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie SoundDepartment Role X1) Movie SoundDepartment Details X1" };
            string[] dataSoundDepartment2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie SoundDepartment Role X2) Movie SoundDepartment Details X2" };
            string[] dataSoundDepartment3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie SoundDepartment Role X3) Movie SoundDepartment Details X3" };

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
            string[] dataSpecialEffects1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie SpecialEffects Role X1) Movie SpecialEffects Details X1" };
            string[] dataSpecialEffects2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie SpecialEffects Role X2) Movie SpecialEffects Details X2" };
            string[] dataSpecialEffects3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie SpecialEffects Role X3) Movie SpecialEffects Details X3" };

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
            string[] dataVisualEffects1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie VisualEffects Role X1) Movie VisualEffects Details X1" };
            string[] dataVisualEffects2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie VisualEffects Role X2) Movie VisualEffects Details X2" };
            string[] dataVisualEffects3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie VisualEffects Role X3) Movie VisualEffects Details X3" };

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
            string[] dataStunts1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie Stunts Role X1) Movie Stunts Details X1" };
            string[] dataStunts2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie Stunts Role X2) Movie Stunts Details X2" };
            string[] dataStunts3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie Stunts Role X3) Movie Stunts Details X3" };

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
            string[] dataElectricalDepartment1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie ElectricalDepartment Role X1) Movie ElectricalDepartment Details X1" };
            string[] dataElectricalDepartment2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie ElectricalDepartment Role X2) Movie ElectricalDepartment Details X2" };
            string[] dataElectricalDepartment3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie ElectricalDepartment Role X3) Movie ElectricalDepartment Details X3" };

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
            string[] dataAnimationDepartment1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie AnimationDepartment Role X1) Movie AnimationDepartment Details X1" };
            string[] dataAnimationDepartment2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie AnimationDepartment Role X2) Movie AnimationDepartment Details X2" };
            string[] dataAnimationDepartment3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie AnimationDepartment Role X3) Movie AnimationDepartment Details X3" };

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
            string[] dataCastingDepartment1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie CastingDepartment Role X1) Movie CastingDepartment Details X1" };
            string[] dataCastingDepartment2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie CastingDepartment Role X2) Movie CastingDepartment Details X2" };
            string[] dataCastingDepartment3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie CastingDepartment Role X3) Movie CastingDepartment Details X3" };

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
            string[] dataCostumeDepartment1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie CostumeDepartment Role X1) Movie CostumeDepartment Details X1" };
            string[] dataCostumeDepartment2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie CostumeDepartment Role X2) Movie CostumeDepartment Details X2" };
            string[] dataCostumeDepartment3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie CostumeDepartment Role X3) Movie CostumeDepartment Details X3" };

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
            string[] dataEditorialDepartment1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie EditorialDepartment Role X1) Movie EditorialDepartment Details X1" };
            string[] dataEditorialDepartment2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie EditorialDepartment Role X2) Movie EditorialDepartment Details X2" };
            string[] dataEditorialDepartment3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie EditorialDepartment Role X3) Movie EditorialDepartment Details X3" };

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
            string[] dataLocationManagement1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie LocationManagement Role X1) Movie LocationManagement Details X1" };
            string[] dataLocationManagement2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie LocationManagement Role X2) Movie LocationManagement Details X2" };
            string[] dataLocationManagement3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie LocationManagement Role X3) Movie LocationManagement Details X3" };

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
            string[] dataMusicDepartment1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie MusicDepartment Role X1) Movie MusicDepartment Details X1" };
            string[] dataMusicDepartment2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie MusicDepartment Role X2) Movie MusicDepartment Details X2" };
            string[] dataMusicDepartment3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie MusicDepartment Role X3) Movie MusicDepartment Details X3" };

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
            string[] dataContinuityDepartment1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie ContinuityDepartment Role X1) Movie ContinuityDepartment Details X1" };
            string[] dataContinuityDepartment2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie ContinuityDepartment Role X2) Movie ContinuityDepartment Details X2" };
            string[] dataContinuityDepartment3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie ContinuityDepartment Role X3) Movie ContinuityDepartment Details X3" };

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

            // Transportation Department
            string[] dataTransportationDepartment1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie TransportationDepartment Role X1) Movie TransportationDepartment Details X1" };
            string[] dataTransportationDepartment2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie TransportationDepartment Role X2) Movie TransportationDepartment Details X2" };
            string[] dataTransportationDepartment3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie TransportationDepartment Role X3) Movie TransportationDepartment Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Transportation Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Transport")); break;
                default: content.Add(Formatter.AsHeading3("Transport")); break;
            }
            content.Add(Formatter.AsTableRow(dataTransportationDepartment1));
            content.Add(Formatter.AsTableRow(dataTransportationDepartment2));
            content.Add(Formatter.AsTableRow(dataTransportationDepartment3));
            content.Add($"");
            content.Add($"");

            // Other Crew
            string[] dataOtherCrew1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie OtherCrew Role X1) Movie OtherCrew Details X1" };
            string[] dataOtherCrew2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie OtherCrew Role X2) Movie OtherCrew Details X2" };
            string[] dataOtherCrew3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie OtherCrew Role X3) Movie OtherCrew Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Additional Crew")); break;
                case "de": content.Add(Formatter.AsHeading3("Weitere Crewmitglieder")); break;
                default: content.Add(Formatter.AsHeading3("Weitere Crewmitglieder")); break;
            }
            content.Add(Formatter.AsTableRow(dataOtherCrew1));
            content.Add(Formatter.AsTableRow(dataOtherCrew2));
            content.Add(Formatter.AsTableRow(dataOtherCrew3));
            content.Add($"");
            content.Add($"");

            // Thanks
            string[] dataThanks1 = { Formatter.AsInternalLink(path, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie Thanks Role X1) Movie Thanks Details X1" };
            string[] dataThanks2 = { Formatter.AsInternalLink(path, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie Thanks Role X2) Movie Thanks Details X2" };
            string[] dataThanks3 = { Formatter.AsInternalLink(path, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie Thanks Role X3) Movie Thanks Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Thanks")); break;
                case "de": content.Add(Formatter.AsHeading3("Dank")); break;
                default: content.Add(Formatter.AsHeading3("Dank")); break;
            }
            content.Add(Formatter.AsTableRow(dataThanks1));
            content.Add(Formatter.AsTableRow(dataThanks2));
            content.Add(Formatter.AsTableRow(dataThanks3));

            content.Add($"");
            content.Add($"");

            switch (value)
            {
                case "en":
                    content.Add("Crew is Status EnglishTitle X.");
                    break;
                case "de":
                    content.Add("Crew ist Status GermanTitle X.");
                    break;
                default:
                    content.Add("Crew ist Status GermanTitle X.");
                    break;
            }
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
        public void CreateCompanyChapterTest(string value)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateCompanyChapter(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "company" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Company Credits")); break;
                case "de": content.Add(Formatter.AsHeading2("Beteiligte Firmen")); break;
                default: content.Add(Formatter.AsHeading2("Beteiligte Firmen")); break;
            }

            // Production Company
            string[] dataProductionCompany1 = { Formatter.AsInternalLink(path, "Company Name X Company NameAddOn X"), "(Movie ProductionCompany Role X1) Movie ProductionCompany Details X1" };
            string[] dataProductionCompany2 = { Formatter.AsInternalLink(path, "Company Name Y Company NameAddOn Y"), "(Movie ProductionCompany Role X2) Movie ProductionCompany Details X2" };
            string[] dataProductionCompany3 = { Formatter.AsInternalLink(path, "Company Name Z Company NameAddOn Z"), "(Movie ProductionCompany Role X3) Movie ProductionCompany Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Production Companies")); break;
                case "de": content.Add(Formatter.AsHeading3("Produktionsfirmen")); break;
                default: content.Add(Formatter.AsHeading3("Produktionsfirmen")); break;
            }
            content.Add(Formatter.AsTableRow(dataProductionCompany1));
            content.Add(Formatter.AsTableRow(dataProductionCompany2));
            content.Add(Formatter.AsTableRow(dataProductionCompany3));
            content.Add($"");
            content.Add($"");

            // Distributor
            string[] pathCountry = { value, "info" };

            string[] dataDistributor1En = { Formatter.AsInternalLink(path, "Company Name X Company NameAddOn X"), $"(Movie Distributor ReleaseDate X1)", $"({Formatter.AsInternalLink(pathCountry, "Country OriginalFullName X", "Country EnglishShortName X")})", "(Movie Distributor Role X1) Movie Distributor Details X1" };
            string[] dataDistributor1De = { Formatter.AsInternalLink(path, "Company Name X Company NameAddOn X"), $"(Movie Distributor ReleaseDate X1)", $"({Formatter.AsInternalLink(pathCountry, "Country OriginalFullName X", "Country GermanShortName X")})", "(Movie Distributor Role X1) Movie Distributor Details X1" };
            string[] dataDistributor2En = { Formatter.AsInternalLink(path, "Company Name Y Company NameAddOn Y"), $"(Movie Distributor ReleaseDate X2)", $"({Formatter.AsInternalLink(pathCountry, "Country OriginalFullName X", "Country EnglishShortName X")})", "(Movie Distributor Role X2) Movie Distributor Details X2" };
            string[] dataDistributor2De = { Formatter.AsInternalLink(path, "Company Name Y Company NameAddOn Y"), $"(Movie Distributor ReleaseDate X2)", $"({Formatter.AsInternalLink(pathCountry, "Country OriginalFullName X", "Country GermanShortName X")})", "(Movie Distributor Role X2) Movie Distributor Details X2" };
            string[] dataDistributor3En = { Formatter.AsInternalLink(path, "Company Name Z Company NameAddOn Z"), $"(Movie Distributor ReleaseDate X3)", $"({Formatter.AsInternalLink(pathCountry, "Country OriginalFullName X", "Country EnglishShortName X")})", "(Movie Distributor Role X3) Movie Distributor Details X3" };
            string[] dataDistributor3De = { Formatter.AsInternalLink(path, "Company Name Z Company NameAddOn Z"), $"(Movie Distributor ReleaseDate X3)", $"({Formatter.AsInternalLink(pathCountry, "Country OriginalFullName X", "Country GermanShortName X")})", "(Movie Distributor Role X3) Movie Distributor Details X3" };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsHeading3("Distributors"));
                    content.Add(Formatter.AsTableRow(dataDistributor1En));
                    content.Add(Formatter.AsTableRow(dataDistributor2En));
                    content.Add(Formatter.AsTableRow(dataDistributor3En));
                    break;
                case "de":
                default:
                    content.Add(Formatter.AsHeading3("Vertrieb"));
                    content.Add(Formatter.AsTableRow(dataDistributor1De));
                    content.Add(Formatter.AsTableRow(dataDistributor2De));
                    content.Add(Formatter.AsTableRow(dataDistributor3De));
                    break;
            }
            content.Add($"");
            content.Add($"");

            // Special Effects Company
            string[] dataSpecialEffectsCompany1 = { Formatter.AsInternalLink(path, "Company Name X Company NameAddOn X"), "(Movie SpecialEffectsCompany Role X1) Movie SpecialEffectsCompany Details X1" };
            string[] dataSpecialEffectsCompany2 = { Formatter.AsInternalLink(path, "Company Name Y Company NameAddOn Y"), "(Movie SpecialEffectsCompany Role X2) Movie SpecialEffectsCompany Details X2" };
            string[] dataSpecialEffectsCompany3 = { Formatter.AsInternalLink(path, "Company Name Z Company NameAddOn Z"), "(Movie SpecialEffectsCompany Role X3) Movie SpecialEffectsCompany Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Special Effects")); break;
                case "de": content.Add(Formatter.AsHeading3("Spezialeffekte")); break;
                default: content.Add(Formatter.AsHeading3("Spezialeffekte")); break;
            }
            content.Add(Formatter.AsTableRow(dataSpecialEffectsCompany1));
            content.Add(Formatter.AsTableRow(dataSpecialEffectsCompany2));
            content.Add(Formatter.AsTableRow(dataSpecialEffectsCompany3));
            content.Add($"");
            content.Add($"");

            // Other Company
            string[] dataOtherCompany1 = { Formatter.AsInternalLink(path, "Company Name X Company NameAddOn X"), "(Movie OtherCompany Role X1) Movie OtherCompany Details X1" };
            string[] dataOtherCompany2 = { Formatter.AsInternalLink(path, "Company Name Y Company NameAddOn Y"), "(Movie OtherCompany Role X2) Movie OtherCompany Details X2" };
            string[] dataOtherCompany3 = { Formatter.AsInternalLink(path, "Company Name Z Company NameAddOn Z"), "(Movie OtherCompany Role X3) Movie OtherCompany Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Other Companies")); break;
                case "de": content.Add(Formatter.AsHeading3("Weitere Firmen")); break;
                default: content.Add(Formatter.AsHeading3("Weitere Firmen")); break;
            }
            content.Add(Formatter.AsTableRow(dataOtherCompany1));
            content.Add(Formatter.AsTableRow(dataOtherCompany2));
            content.Add(Formatter.AsTableRow(dataOtherCompany3));
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
        public void CreateFilmingAndProductionChapterTest(string value)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateFilmingAndProductionChapter(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "info" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Filming and Production")); break;
                case "de": content.Add(Formatter.AsHeading2("Produktion")); break;
                default: content.Add(Formatter.AsHeading2("Produktion")); break;
            }

            // Filming Location
            string[] dataEn1 = { $"{Formatter.AsInternalLink(path, $"Location X")}, {Formatter.AsInternalLink(path, "Country OriginalFullName X", "Country EnglishShortName X")} -- Movie FilmingLocation Details X1" };
            string[] dataEn2 = { $"{Formatter.AsInternalLink(path, $"Location Y")}, {Formatter.AsInternalLink(path, "Country OriginalFullName Y", "Country EnglishShortName Y")} -- Movie FilmingLocation Details X2" };
            string[] dataEn3 = { $"{Formatter.AsInternalLink(path, $"Location Z")}, {Formatter.AsInternalLink(path, "Country OriginalFullName Z", "Country EnglishShortName Z")} -- Movie FilmingLocation Details X3" };
            string[] dataDe1 = { $"{Formatter.AsInternalLink(path, $"Location X")}, {Formatter.AsInternalLink(path, "Country OriginalFullName X", "Country GermanShortName X")} -- Movie FilmingLocation Details X1" };
            string[] dataDe2 = { $"{Formatter.AsInternalLink(path, $"Location Y")}, {Formatter.AsInternalLink(path, "Country OriginalFullName Y", "Country GermanShortName Y")} -- Movie FilmingLocation Details X2" };
            string[] dataDe3 = { $"{Formatter.AsInternalLink(path, $"Location Z")}, {Formatter.AsInternalLink(path, "Country OriginalFullName Z", "Country GermanShortName Z")} -- Movie FilmingLocation Details X3" };
            string[] dataZz1 = { $"{Formatter.AsInternalLink(path, $"Location X")}, {Formatter.AsInternalLink(path, "Country OriginalFullName X", "Country GermanShortName X")} -- Movie FilmingLocation Details X1" };
            string[] dataZz2 = { $"{Formatter.AsInternalLink(path, $"Location Y")}, {Formatter.AsInternalLink(path, "Country OriginalFullName Y", "Country GermanShortName Y")} -- Movie FilmingLocation Details X2" };
            string[] dataZz3 = { $"{Formatter.AsInternalLink(path, $"Location Z")}, {Formatter.AsInternalLink(path, "Country OriginalFullName Z", "Country GermanShortName Z")} -- Movie FilmingLocation Details X3" };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsHeading3("Filming Locations"));
                    content.Add(Formatter.AsTableRow(dataEn1));
                    content.Add(Formatter.AsTableRow(dataEn2));
                    content.Add(Formatter.AsTableRow(dataEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsHeading3("Drehorte"));
                    content.Add(Formatter.AsTableRow(dataDe1));
                    content.Add(Formatter.AsTableRow(dataDe2));
                    content.Add(Formatter.AsTableRow(dataDe3));
                    break;
                default:
                    content.Add(Formatter.AsHeading3("Drehorte"));
                    content.Add(Formatter.AsTableRow(dataZz1));
                    content.Add(Formatter.AsTableRow(dataZz2));
                    content.Add(Formatter.AsTableRow(dataZz3));
                    break;
            }
            content.Add($"");
            content.Add($"");

            // Filming Dates
            string[] pathFilmingDates = { value, "date" };
            string[] dataFilmingDates1 = { $"{Formatter.AsInternalLink(pathFilmingDates, "Movie FilmingDate StartDate X1")} - {Formatter.AsInternalLink(pathFilmingDates, "Movie FilmingDate EndDate X1")}" };
            string[] dataFilmingDates2 = { $"{Formatter.AsInternalLink(pathFilmingDates, "Movie FilmingDate StartDate X2")} - {Formatter.AsInternalLink(pathFilmingDates, "Movie FilmingDate EndDate X2")}" };
            string[] dataFilmingDates3 = { $"{Formatter.AsInternalLink(pathFilmingDates, "Movie FilmingDate StartDate X3")} - {Formatter.AsInternalLink(pathFilmingDates, "Movie FilmingDate EndDate X3")}" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Filming Dates")); break;
                case "de": content.Add(Formatter.AsHeading3("Drehdatum")); break;
                default: content.Add(Formatter.AsHeading3("Drehdatum")); break;
            }

            content.Add(Formatter.AsTableRow(dataFilmingDates1));
            content.Add(Formatter.AsTableRow(dataFilmingDates2));
            content.Add(Formatter.AsTableRow(dataFilmingDates3));

            content.Add($"");
            content.Add($"");

            // Production Dates
            string[] dataProductionDates1 = { $"{Formatter.AsInternalLink(pathFilmingDates, "Movie ProductionDate StartDate X1")} - {Formatter.AsInternalLink(pathFilmingDates, "Movie ProductionDate EndDate X1")}" };
            string[] dataProductionDates2 = { $"{Formatter.AsInternalLink(pathFilmingDates, "Movie ProductionDate StartDate X2")} - {Formatter.AsInternalLink(pathFilmingDates, "Movie ProductionDate EndDate X2")}" };
            string[] dataProductionDates3 = { $"{Formatter.AsInternalLink(pathFilmingDates, "Movie ProductionDate StartDate X3")} - {Formatter.AsInternalLink(pathFilmingDates, "Movie ProductionDate EndDate X3")}" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Production Dates")); break;
                case "de": content.Add(Formatter.AsHeading3("Produktionsdatum")); break;
                default: content.Add(Formatter.AsHeading3("Produktionsdatum")); break;
            }

            content.Add(Formatter.AsTableRow(dataProductionDates1));
            content.Add(Formatter.AsTableRow(dataProductionDates2));
            content.Add(Formatter.AsTableRow(dataProductionDates3));

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
        public void CreateAwardChapterTest(string value)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateAwardChapter(value);

            // Assert
            List<string> content = new List<string>();
            string[] path = { value, "info" };
            string[] pathDate = { value, "date" };
            string[] pathPerson = { value, "biography" };
            string[] dataEn10 = { Formatter.AsInternalLink(path, "Award Name X", "Award Name X"), Formatter.AsInternalLink(pathDate, "Movie Award Date X1", "Movie Award Date X1"), "Movie Award Category X1", "Winner", "Movie Award Details X1" };
            string[] dataEn20 = { Formatter.AsInternalLink(path, "Award Name Y", "Award Name Y"), Formatter.AsInternalLink(pathDate, "Movie Award Date X2", "Movie Award Date X2"), "Movie Award Category X2", "Nominee", "Movie Award Details X2" };
            string[] dataEn30 = { Formatter.AsInternalLink(path, "Award Name Z", "Award Name Z"), Formatter.AsInternalLink(pathDate, "Movie Award Date X3", "Movie Award Date X3"), "Movie Award Category X3", "Nominee", "Movie Award Details X3" };
            string[] dataDe10 = { Formatter.AsInternalLink(path, "Award Name X", "Award Name X"), Formatter.AsInternalLink(pathDate, "Movie Award Date X1", "Movie Award Date X1"), "Movie Award Category X1", "Gewinner", "Movie Award Details X1" };
            string[] dataDe20 = { Formatter.AsInternalLink(path, "Award Name Y", "Award Name Y"), Formatter.AsInternalLink(pathDate, "Movie Award Date X2", "Movie Award Date X2"), "Movie Award Category X2", "Nominierter", "Movie Award Details X2" };
            string[] dataDe30 = { Formatter.AsInternalLink(path, "Award Name Z", "Award Name Z"), Formatter.AsInternalLink(pathDate, "Movie Award Date X3", "Movie Award Date X3"), "Movie Award Category X3", "Nominierter", "Movie Award Details X3" };
            string[] data11 = { Formatter.CellSpanVertically(), Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathPerson, "Person FirstName X Person LastName X Person NameAddOn X", "Person FirstName X Person LastName X")} (Movie Award Person Role X11) Movie Award Person Details X11", " ", " " };
            string[] data12 = { Formatter.CellSpanVertically(), Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathPerson, "Person FirstName Y Person LastName Y Person NameAddOn Y", "Person FirstName Y Person LastName Y")} (Movie Award Person Role X12) Movie Award Person Details X12", " ", " " };
            string[] data13 = { Formatter.CellSpanVertically(), Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathPerson, "Person FirstName Z Person LastName Z Person NameAddOn Z", "Person FirstName Z Person LastName Z")} (Movie Award Person Role X13) Movie Award Person Details X13", " ", " " };
            string[] data21 = { Formatter.CellSpanVertically(), Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathPerson, "Person FirstName X Person LastName X Person NameAddOn X", "Person FirstName X Person LastName X")} (Movie Award Person Role X21) Movie Award Person Details X21", " ", " " };
            string[] data22 = { Formatter.CellSpanVertically(), Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathPerson, "Person FirstName Y Person LastName Y Person NameAddOn Y", "Person FirstName Y Person LastName Y")} (Movie Award Person Role X22) Movie Award Person Details X22", " ", " " };
            string[] data23 = { Formatter.CellSpanVertically(), Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathPerson, "Person FirstName Z Person LastName Z Person NameAddOn Z", "Person FirstName Z Person LastName Z")} (Movie Award Person Role X23) Movie Award Person Details X23", " ", " " };
            string[] data31 = { Formatter.CellSpanVertically(), Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathPerson, "Person FirstName X Person LastName X Person NameAddOn X", "Person FirstName X Person LastName X")} (Movie Award Person Role X31) Movie Award Person Details X31", " ", " " };
            string[] data32 = { Formatter.CellSpanVertically(), Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathPerson, "Person FirstName Y Person LastName Y Person NameAddOn Y", "Person FirstName Y Person LastName Y")} (Movie Award Person Role X32) Movie Award Person Details X32", " ", " " };
            string[] data33 = { Formatter.CellSpanVertically(), Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathPerson, "Person FirstName Z Person LastName Z Person NameAddOn Z", "Person FirstName Z Person LastName Z")} (Movie Award Person Role X33) Movie Award Person Details X33", " ", " " };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Awards")); break;
                case "de": content.Add(Formatter.AsHeading2("Auszeichnungen")); break;
                default: content.Add(Formatter.AsHeading2("Auszeichnungen")); break;
            }

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataEn10));
                    content.Add(Formatter.AsTableRow(data11));
                    content.Add(Formatter.AsTableRow(data12));
                    content.Add(Formatter.AsTableRow(data13));
                    content.Add(Formatter.AsTableRow(dataEn20));
                    content.Add(Formatter.AsTableRow(data21));
                    content.Add(Formatter.AsTableRow(data22));
                    content.Add(Formatter.AsTableRow(data23));
                    content.Add(Formatter.AsTableRow(dataEn30));
                    content.Add(Formatter.AsTableRow(data31));
                    content.Add(Formatter.AsTableRow(data32));
                    content.Add(Formatter.AsTableRow(data33));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataDe10));
                    content.Add(Formatter.AsTableRow(data11));
                    content.Add(Formatter.AsTableRow(data12));
                    content.Add(Formatter.AsTableRow(data13));
                    content.Add(Formatter.AsTableRow(dataDe20));
                    content.Add(Formatter.AsTableRow(data21));
                    content.Add(Formatter.AsTableRow(data22));
                    content.Add(Formatter.AsTableRow(data23));
                    content.Add(Formatter.AsTableRow(dataDe30));
                    content.Add(Formatter.AsTableRow(data31));
                    content.Add(Formatter.AsTableRow(data32));
                    content.Add(Formatter.AsTableRow(data33));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataDe10));
                    content.Add(Formatter.AsTableRow(data11));
                    content.Add(Formatter.AsTableRow(data12));
                    content.Add(Formatter.AsTableRow(data13));
                    content.Add(Formatter.AsTableRow(dataDe20));
                    content.Add(Formatter.AsTableRow(data21));
                    content.Add(Formatter.AsTableRow(data22));
                    content.Add(Formatter.AsTableRow(data23));
                    content.Add(Formatter.AsTableRow(dataDe30));
                    content.Add(Formatter.AsTableRow(data31));
                    content.Add(Formatter.AsTableRow(data32));
                    content.Add(Formatter.AsTableRow(data33));
                    break;
            }
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
        public void CreateWeblinkChapterTest(string value)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

            MovieFileContentCreator creator = new MovieFileContentCreator(movie);

            // Act
            creator.CreateWeblinkChapter(value);

            // Assert
            List<string> content = new List<string>();

            string dataEn1 = $"{Formatter.ListItemIndent()}{Formatter.ListItemUnsorted()} {Formatter.AsExternalLink("Weblink URL X", "Weblink EnglishTitle X")} (Language EnglishName X)";
            string dataEn2 = $"{Formatter.ListItemIndent()}{Formatter.ListItemUnsorted()} {Formatter.AsExternalLink("Weblink URL Y", "Weblink EnglishTitle Y")} (Language EnglishName Y)";
            string dataEn3 = $"{Formatter.ListItemIndent()}{Formatter.ListItemUnsorted()} {Formatter.AsExternalLink("Weblink URL Z", "Weblink EnglishTitle Z")} (Language EnglishName Z)";
            string dataDe1 = $"{Formatter.ListItemIndent()}{Formatter.ListItemUnsorted()} {Formatter.AsExternalLink("Weblink URL X", "Weblink GermanTitle X")} (Language GermanName X)";
            string dataDe2 = $"{Formatter.ListItemIndent()}{Formatter.ListItemUnsorted()} {Formatter.AsExternalLink("Weblink URL Y", "Weblink GermanTitle Y")} (Language GermanName Y)";
            string dataDe3 = $"{Formatter.ListItemIndent()}{Formatter.ListItemUnsorted()} {Formatter.AsExternalLink("Weblink URL Z", "Weblink GermanTitle Z")} (Language GermanName Z)";

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Other Sites")); break;
                case "de": content.Add(Formatter.AsHeading2("Andere Webseiten")); break;
                default: content.Add(Formatter.AsHeading2("Andere Webseiten")); break;
            }

            switch (value)
            {
                case "en":
                    content.Add(dataEn1);
                    content.Add(dataEn2);
                    content.Add(dataEn3);
                    break;
                case "de":
                    content.Add(dataDe1);
                    content.Add(dataDe2);
                    content.Add(dataDe3);
                    break;
                default:
                    content.Add(dataDe1);
                    content.Add(dataDe2);
                    content.Add(dataDe3);
                    break;
            }
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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

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
            DBReader reader = new SQLiteReader();
            Movie movie = new Movie(reader, "_xxx");
            movie.Retrieve(false);

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

            content.Add($"   Movie OriginalTitle X");
            content.Add($"");
            content.Add($"   @author  WikiPageCreator");
            content.Add($"   @date    {DateTime.Now:yyyy-MM-dd}");
            content.Add($"   @version Status EnglishTitle X: Movie LastUpdated X");

            content.Add(creator.Formatter.EndComment());
            content.Add("");

            // Title
            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading1("Movie EnglishTitle X")); break;
                case "de": content.Add(Formatter.AsHeading1("Movie GermanTitle X")); break;
                default: content.Add(Formatter.AsHeading1("Movie OriginalTitle X")); break;
            }

            content.Add("");

            // InfoBox Header
            content.Add(Formatter.BeginBox(475, Alignment.Right));
            content.Add(Formatter.DefineTable(445, width));

            // InfoBox Title
            string[] dataTitleEn = { "Original Title", "Movie OriginalTitle X" };
            string[] dataTitleDe = { "Originaltitel", "Movie OriginalTitle X" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsTableRow(dataTitleEn)); break;
                case "de": content.Add(Formatter.AsTableRow(dataTitleDe)); break;
                default: content.Add(Formatter.AsTableRow(dataTitleDe)); break;
            }

            // InfoBox Logo
            string[] pathLogo = { "cinema_and_television_movie" };
            string dataLogoEn0 = Formatter.AsImage(pathLogo, "Image FileName X", 450, "Type EnglishTitle X");
            string dataLogoDe0 = Formatter.AsImage(pathLogo, "Image FileName X", 450, "Type GermanTitle X");
            string[] dataLogoEn = { dataLogoEn0, null };
            string[] dataLogoDe = { dataLogoDe0, null };

            switch (value)
            {
                case "en": content.Add(Formatter.AsTableRow(dataLogoEn)); break;
                case "de": content.Add(Formatter.AsTableRow(dataLogoDe)); break;
                default: content.Add(Formatter.AsTableRow(dataLogoDe)); break;
            }

            // InfoBox Type
            string[] pathType = { value, "info" };
            string[] dataTypeEn = { "Type", Formatter.AsInternalLink(pathType, "Type EnglishTitle X", "Type EnglishTitle X") };
            string[] dataTypeDe = { "Typ", Formatter.AsInternalLink(pathType, "Type EnglishTitle X", "Type GermanTitle X") };
            string[] dataTypeZz = { "Typ", Formatter.AsInternalLink(pathType, "Type EnglishTitle X", "Type GermanTitle X") };

            switch (value)
            {
                case "en": content.Add(Formatter.AsTableRow(dataTypeEn)); break;
                case "de": content.Add(Formatter.AsTableRow(dataTypeDe)); break;
                default: content.Add(Formatter.AsTableRow(dataTypeZz)); break;
            }

            // InfoBox ReleaseDate
            string[] pathRelease = { value, "date" };
            string[] dataReleaseEn = { "Original Release Date", Formatter.AsInternalLink(pathRelease, "Movie ReleaseDate X", "Movie ReleaseDate X") };
            string[] dataReleaseDe = { "Erstausstrahlung", Formatter.AsInternalLink(pathRelease, "Movie ReleaseDate X", "Movie ReleaseDate X") };
            string[] dataReleaseZz = { "Erstausstrahlung", Formatter.AsInternalLink(pathRelease, "Movie ReleaseDate X", "Movie ReleaseDate X") };

            switch (value)
            {
                case "en": content.Add(Formatter.AsTableRow(dataReleaseEn)); break;
                case "de": content.Add(Formatter.AsTableRow(dataReleaseDe)); break;
                default: content.Add(Formatter.AsTableRow(dataReleaseZz)); break;
            }

            // InfoBox Genre
            string[] pathGenre = { value, "info" };
            string[] dataGenreEn1 = { "Genre", $"{Formatter.AsInternalLink(pathGenre, "Genre EnglishTitle X", "Genre EnglishTitle X")} Movie Genre Details X1" };
            string[] dataGenreEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathGenre, "Genre EnglishTitle Y", "Genre EnglishTitle Y")} Movie Genre Details X2" };
            string[] dataGenreEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathGenre, "Genre EnglishTitle Z", "Genre EnglishTitle Z")} Movie Genre Details X3" };
            string[] dataGenreDe1 = { "Genre", $"{Formatter.AsInternalLink(pathGenre, "Genre EnglishTitle X", "Genre GermanTitle X")} Movie Genre Details X1" };
            string[] dataGenreDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathGenre, "Genre EnglishTitle Y", "Genre GermanTitle Y")} Movie Genre Details X2" };
            string[] dataGenreDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathGenre, "Genre EnglishTitle Z", "Genre GermanTitle Z")} Movie Genre Details X3" };
            string[] dataGenreZz1 = { "Genre", $"{Formatter.AsInternalLink(pathGenre, "Genre EnglishTitle X", "Genre GermanTitle X")} Movie Genre Details X1" };
            string[] dataGenreZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathGenre, "Genre EnglishTitle Y", "Genre GermanTitle Y")} Movie Genre Details X2" };
            string[] dataGenreZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathGenre, "Genre EnglishTitle Z", "Genre GermanTitle Z")} Movie Genre Details X3" };

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
            string[] pathCertification = { "certification" };
            string[] dataCertificationEn1 = { "Certification", $"{Formatter.AsImage(pathCertification, "Image FileName X", 75)} Movie Certification Details X1" };
            string[] dataCertificationEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(pathCertification, "Image FileName Y", 75)} Movie Certification Details X2" };
            string[] dataCertificationEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(pathCertification, "Image FileName Z", 75)} Movie Certification Details X3" };
            string[] dataCertificationDe1 = { "Altersfreigabe", $"{Formatter.AsImage(pathCertification, "Image FileName X", 75)} Movie Certification Details X1" };
            string[] dataCertificationDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(pathCertification, "Image FileName Y", 75)} Movie Certification Details X2" };
            string[] dataCertificationDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(pathCertification, "Image FileName Z", 75)} Movie Certification Details X3" };
            string[] dataCertificationZz1 = { "Altersfreigabe", $"{Formatter.AsImage(pathCertification, "Image FileName X", 75)} Movie Certification Details X1" };
            string[] dataCertificationZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(pathCertification, "Image FileName Y", 75)} Movie Certification Details X2" };
            string[] dataCertificationZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsImage(pathCertification, "Image FileName Z", 75)} Movie Certification Details X3" };

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
            string[] dataCountryEn1 = { "Production Country", $"{Formatter.AsInternalLink(pathCountry, "Country OriginalFullName X", "Country EnglishShortName X")} Movie Country Details X1" };
            string[] dataCountryEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathCountry, "Country OriginalFullName Y", "Country EnglishShortName Y")} Movie Country Details X2" };
            string[] dataCountryEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathCountry, "Country OriginalFullName Z", "Country EnglishShortName Z")} Movie Country Details X3" };
            string[] dataCountryDe1 = { "Produktionsland", $"{Formatter.AsInternalLink(pathCountry, "Country OriginalFullName X", "Country GermanShortName X")} Movie Country Details X1" };
            string[] dataCountryDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathCountry, "Country OriginalFullName Y", "Country GermanShortName Y")} Movie Country Details X2" };
            string[] dataCountryDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathCountry, "Country OriginalFullName Z", "Country GermanShortName Z")} Movie Country Details X3" };
            string[] dataCountryZz1 = { "Produktionsland", $"{Formatter.AsInternalLink(pathCountry, "Country OriginalFullName X", "Country GermanShortName X")} Movie Country Details X1" };
            string[] dataCountryZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathCountry, "Country OriginalFullName Y", "Country GermanShortName Y")} Movie Country Details X2" };
            string[] dataCountryZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathCountry, "Country OriginalFullName Z", "Country GermanShortName Z")} Movie Country Details X3" };

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
            string[] dataLanguageEn1 = { "Language", $"{Formatter.AsInternalLink(pathLanguage, "Language OriginalName X", "Language EnglishName X")} Movie Language Details X1" };
            string[] dataLanguageEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathLanguage, "Language OriginalName Y", "Language EnglishName Y")} Movie Language Details X2" };
            string[] dataLanguageEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathLanguage, "Language OriginalName Z", "Language EnglishName Z")} Movie Language Details X3" };
            string[] dataLanguageDe1 = { "Sprache", $"{Formatter.AsInternalLink(pathLanguage, "Language OriginalName X", "Language GermanName X")} Movie Language Details X1" };
            string[] dataLanguageDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathLanguage, "Language OriginalName Y", "Language GermanName Y")} Movie Language Details X2" };
            string[] dataLanguageDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathLanguage, "Language OriginalName Z", "Language GermanName Z")} Movie Language Details X3" };
            string[] dataLanguageZz1 = { "Sprache", $"{Formatter.AsInternalLink(pathLanguage, "Language OriginalName X", "Language GermanName X")} Movie Language Details X1" };
            string[] dataLanguageZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathLanguage, "Language OriginalName Y", "Language GermanName Y")} Movie Language Details X2" };
            string[] dataLanguageZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathLanguage, "Language OriginalName Z", "Language GermanName Z")} Movie Language Details X3" };

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
            string[] dataGrossEn = { "Worldwide Gross", $"Movie WorldwideGross X ({Formatter.AsInternalLink(pathGross, "Movie WorldwideGrossDate X", "Movie WorldwideGrossDate X")})" };
            string[] dataGrossDe = { "Einspielergebnis (weltweit)", $"Movie WorldwideGross X ({Formatter.AsInternalLink(pathGross, "Movie WorldwideGrossDate X", "Movie WorldwideGrossDate X")})" };
            string[] dataGrossZz = { "Einspielergebnis (weltweit)", $"Movie WorldwideGross X ({Formatter.AsInternalLink(pathGross, "Movie WorldwideGrossDate X", "Movie WorldwideGrossDate X")})" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsTableRow(dataGrossEn)); break;
                case "de": content.Add(Formatter.AsTableRow(dataGrossDe)); break;
                default: content.Add(Formatter.AsTableRow(dataGrossZz)); break;
            }

            // InfoBox Runtime
            string[] pathRuntime = { value, "info" };
            string[] dataRuntimeEn1 = { "Runtime", $"11 min. ({Formatter.AsInternalLink(pathRuntime, "Edition EnglishTitle X", "Edition EnglishTitle X")}) Movie Runtime Details X1" };
            string[] dataRuntimeEn2 = { Formatter.CellSpanVertically(), $"12 min. ({Formatter.AsInternalLink(pathRuntime, "Edition EnglishTitle Y", "Edition EnglishTitle Y")}) Movie Runtime Details X2" };
            string[] dataRuntimeEn3 = { Formatter.CellSpanVertically(), $"13 min. ({Formatter.AsInternalLink(pathRuntime, "Edition EnglishTitle Z", "Edition EnglishTitle Z")}) Movie Runtime Details X3" };
            string[] dataRuntimeDe1 = { "Laufzeit", $"11 min. ({Formatter.AsInternalLink(pathRuntime, "Edition EnglishTitle X", "Edition GermanTitle X")}) Movie Runtime Details X1" };
            string[] dataRuntimeDe2 = { Formatter.CellSpanVertically(), $"12 min. ({Formatter.AsInternalLink(pathRuntime, "Edition EnglishTitle Y", "Edition GermanTitle Y")}) Movie Runtime Details X2" };
            string[] dataRuntimeDe3 = { Formatter.CellSpanVertically(), $"13 min. ({Formatter.AsInternalLink(pathRuntime, "Edition EnglishTitle Z", "Edition GermanTitle Z")}) Movie Runtime Details X3" };
            string[] dataRuntimeZz1 = { "Laufzeit", $"11 min. ({Formatter.AsInternalLink(pathRuntime, "Edition EnglishTitle X", "Edition GermanTitle X")}) Movie Runtime Details X1" };
            string[] dataRuntimeZz2 = { Formatter.CellSpanVertically(), $"12 min. ({Formatter.AsInternalLink(pathRuntime, "Edition EnglishTitle Y", "Edition GermanTitle Y")}) Movie Runtime Details X2" };
            string[] dataRuntimeZz3 = { Formatter.CellSpanVertically(), $"13 min. ({Formatter.AsInternalLink(pathRuntime, "Edition EnglishTitle Z", "Edition GermanTitle Z")}) Movie Runtime Details X3" };

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

            // InfoBox SoundMix
            string[] pathSoundMix = { value, "info" };
            string[] dataSoundMixEn1 = { "Sound Mix", $"{Formatter.AsInternalLink(pathSoundMix, "SoundMix EnglishTitle X", "SoundMix EnglishTitle X")} Movie SoundMix Details X1" };
            string[] dataSoundMixEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathSoundMix, "SoundMix EnglishTitle Y", "SoundMix EnglishTitle Y")} Movie SoundMix Details X2" };
            string[] dataSoundMixEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathSoundMix, "SoundMix EnglishTitle Z", "SoundMix EnglishTitle Z")} Movie SoundMix Details X3" };
            string[] dataSoundMixDe1 = { "Tonmischung", $"{Formatter.AsInternalLink(pathSoundMix, "SoundMix EnglishTitle X", "SoundMix GermanTitle X")} Movie SoundMix Details X1" };
            string[] dataSoundMixDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathSoundMix, "SoundMix EnglishTitle Y", "SoundMix GermanTitle Y")} Movie SoundMix Details X2" };
            string[] dataSoundMixDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathSoundMix, "SoundMix EnglishTitle Z", "SoundMix GermanTitle Z")} Movie SoundMix Details X3" };
            string[] dataSoundMixZz1 = { "Tonmischung", $"{Formatter.AsInternalLink(pathSoundMix, "SoundMix EnglishTitle X", "SoundMix GermanTitle X")} Movie SoundMix Details X1" };
            string[] dataSoundMixZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathSoundMix, "SoundMix EnglishTitle Y", "SoundMix GermanTitle Y")} Movie SoundMix Details X2" };
            string[] dataSoundMixZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathSoundMix, "SoundMix EnglishTitle Z", "SoundMix GermanTitle Z")} Movie SoundMix Details X3" };

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
            string[] dataColorEn1 = { "Color", $"{Formatter.AsInternalLink(pathColor, "Color EnglishTitle X", "Color EnglishTitle X")} Movie Color Details X1" };
            string[] dataColorEn2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathColor, "Color EnglishTitle Y", "Color EnglishTitle Y")} Movie Color Details X2" };
            string[] dataColorEn3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathColor, "Color EnglishTitle Z", "Color EnglishTitle Z")} Movie Color Details X3" };
            string[] dataColorDe1 = { "Farbe", $"{Formatter.AsInternalLink(pathColor, "Color EnglishTitle X", "Color GermanTitle X")} Movie Color Details X1" };
            string[] dataColorDe2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathColor, "Color EnglishTitle Y", "Color GermanTitle Y")} Movie Color Details X2" };
            string[] dataColorDe3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathColor, "Color EnglishTitle Z", "Color GermanTitle Z")} Movie Color Details X3" };
            string[] dataColorZz1 = { "Farbe", $"{Formatter.AsInternalLink(pathColor, "Color EnglishTitle X", "Color GermanTitle X")} Movie Color Details X1" };
            string[] dataColorZz2 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathColor, "Color EnglishTitle Y", "Color GermanTitle Y")} Movie Color Details X2" };
            string[] dataColorZz3 = { Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathColor, "Color EnglishTitle Z", "Color GermanTitle Z")} Movie Color Details X3" };

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
            string[] dataAspectRatioEn1 = { "Aspect Ratio", "AspectRatio Ratio X Movie AspectRatio Details X1" };
            string[] dataAspectRatioEn2 = { Formatter.CellSpanVertically(), "AspectRatio Ratio Y Movie AspectRatio Details X2" };
            string[] dataAspectRatioEn3 = { Formatter.CellSpanVertically(), "AspectRatio Ratio Z Movie AspectRatio Details X3" };
            string[] dataAspectRatioDe1 = { "Bildformat", "AspectRatio Ratio X Movie AspectRatio Details X1" };
            string[] dataAspectRatioDe2 = { Formatter.CellSpanVertically(), "AspectRatio Ratio Y Movie AspectRatio Details X2" };
            string[] dataAspectRatioDe3 = { Formatter.CellSpanVertically(), "AspectRatio Ratio Z Movie AspectRatio Details X3" };
            string[] dataAspectRatioZz1 = { "Bildformat", "AspectRatio Ratio X Movie AspectRatio Details X1" };
            string[] dataAspectRatioZz2 = { Formatter.CellSpanVertically(), "AspectRatio Ratio Y Movie AspectRatio Details X2" };
            string[] dataAspectRatioZz3 = { Formatter.CellSpanVertically(), "AspectRatio Ratio Z Movie AspectRatio Details X3" };

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
            string[] dataCameraEn1 = { "Camera", "Camera Name X, Camera Lenses X Movie Camera Details X1" };
            string[] dataCameraEn2 = { Formatter.CellSpanVertically(), "Camera Name Y, Camera Lenses Y Movie Camera Details X2" };
            string[] dataCameraEn3 = { Formatter.CellSpanVertically(), "Camera Name Z, Camera Lenses Z Movie Camera Details X3" };
            string[] dataCameraDe1 = { "Kamera", "Camera Name X, Camera Lenses X Movie Camera Details X1" };
            string[] dataCameraDe2 = { Formatter.CellSpanVertically(), "Camera Name Y, Camera Lenses Y Movie Camera Details X2" };
            string[] dataCameraDe3 = { Formatter.CellSpanVertically(), "Camera Name Z, Camera Lenses Z Movie Camera Details X3" };
            string[] dataCameraZz1 = { "Kamera", "Camera Name X, Camera Lenses X Movie Camera Details X1" };
            string[] dataCameraZz2 = { Formatter.CellSpanVertically(), "Camera Name Y, Camera Lenses Y Movie Camera Details X2" };
            string[] dataCameraZz3 = { Formatter.CellSpanVertically(), "Camera Name Z, Camera Lenses Z Movie Camera Details X3" };

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
            string[] dataFilmLengthEn1 = { "Film Length", "Movie FilmLength Length X1 Movie FilmLength Details X1" };
            string[] dataFilmLengthEn2 = { Formatter.CellSpanVertically(), "Movie FilmLength Length X2 Movie FilmLength Details X2" };
            string[] dataFilmLengthEn3 = { Formatter.CellSpanVertically(), "Movie FilmLength Length X3 Movie FilmLength Details X3" };
            string[] dataFilmLengthDe1 = { "Filmlänge", "Movie FilmLength Length X1 Movie FilmLength Details X1" };
            string[] dataFilmLengthDe2 = { Formatter.CellSpanVertically(), "Movie FilmLength Length X2 Movie FilmLength Details X2" };
            string[] dataFilmLengthDe3 = { Formatter.CellSpanVertically(), "Movie FilmLength Length X3 Movie FilmLength Details X3" };
            string[] dataFilmLengthZz1 = { "Filmlänge", "Movie FilmLength Length X1 Movie FilmLength Details X1" };
            string[] dataFilmLengthZz2 = { Formatter.CellSpanVertically(), "Movie FilmLength Length X2 Movie FilmLength Details X2" };
            string[] dataFilmLengthZz3 = { Formatter.CellSpanVertically(), "Movie FilmLength Length X3 Movie FilmLength Details X3" };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataFilmLengthEn1));
                    content.Add(Formatter.AsTableRow(dataFilmLengthEn2));
                    content.Add(Formatter.AsTableRow(dataFilmLengthEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataFilmLengthDe1));
                    content.Add(Formatter.AsTableRow(dataFilmLengthDe2));
                    content.Add(Formatter.AsTableRow(dataFilmLengthDe3));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataFilmLengthZz1));
                    content.Add(Formatter.AsTableRow(dataFilmLengthZz2));
                    content.Add(Formatter.AsTableRow(dataFilmLengthZz3));
                    break;
            }

            // Infobox Negative Format
            string[] dataNegativeFormatEn1 = { "Negative Format", "FilmFormat Format X Movie NegativeFormat Details X1" };
            string[] dataNegativeFormatEn2 = { Formatter.CellSpanVertically(), "FilmFormat Format Y Movie NegativeFormat Details X2" };
            string[] dataNegativeFormatEn3 = { Formatter.CellSpanVertically(), "FilmFormat Format Z Movie NegativeFormat Details X3" };
            string[] dataNegativeFormatDe1 = { "Negativformat", "FilmFormat Format X Movie NegativeFormat Details X1" };
            string[] dataNegativeFormatDe2 = { Formatter.CellSpanVertically(), "FilmFormat Format Y Movie NegativeFormat Details X2" };
            string[] dataNegativeFormatDe3 = { Formatter.CellSpanVertically(), "FilmFormat Format Z Movie NegativeFormat Details X3" };
            string[] dataNegativeFormatZz1 = { "Negativformat", "FilmFormat Format X Movie NegativeFormat Details X1" };
            string[] dataNegativeFormatZz2 = { Formatter.CellSpanVertically(), "FilmFormat Format Y Movie NegativeFormat Details X2" };
            string[] dataNegativeFormatZz3 = { Formatter.CellSpanVertically(), "FilmFormat Format Z Movie NegativeFormat Details X3" };

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
            string[] dataCinematographicProcessEn1 = { "Cinematographic Process", "CinematographicProcess Name X Movie CinematographicProcess Details X1" };
            string[] dataCinematographicProcessEn2 = { Formatter.CellSpanVertically(), "CinematographicProcess Name Y Movie CinematographicProcess Details X2" };
            string[] dataCinematographicProcessEn3 = { Formatter.CellSpanVertically(), "CinematographicProcess Name Z Movie CinematographicProcess Details X3" };
            string[] dataCinematographicProcessDe1 = { "Filmprozess", "CinematographicProcess Name X Movie CinematographicProcess Details X1" };
            string[] dataCinematographicProcessDe2 = { Formatter.CellSpanVertically(), "CinematographicProcess Name Y Movie CinematographicProcess Details X2" };
            string[] dataCinematographicProcessDe3 = { Formatter.CellSpanVertically(), "CinematographicProcess Name Z Movie CinematographicProcess Details X3" };
            string[] dataCinematographicProcessZz1 = { "Filmprozess", "CinematographicProcess Name X Movie CinematographicProcess Details X1" };
            string[] dataCinematographicProcessZz2 = { Formatter.CellSpanVertically(), "CinematographicProcess Name Y Movie CinematographicProcess Details X2" };
            string[] dataCinematographicProcessZz3 = { Formatter.CellSpanVertically(), "CinematographicProcess Name Z Movie CinematographicProcess Details X3" };

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

            // Infobox Printed FilmFormat
            string[] dataPrintedFilmFormatEn1 = { "Printed Film Format", "FilmFormat Format X Movie PrintedFilmFormat Details X1" };
            string[] dataPrintedFilmFormatEn2 = { Formatter.CellSpanVertically(), "FilmFormat Format Y Movie PrintedFilmFormat Details X2" };
            string[] dataPrintedFilmFormatEn3 = { Formatter.CellSpanVertically(), "FilmFormat Format Z Movie PrintedFilmFormat Details X3" };
            string[] dataPrintedFilmFormatDe1 = { "Filmformat", "FilmFormat Format X Movie PrintedFilmFormat Details X1" };
            string[] dataPrintedFilmFormatDe2 = { Formatter.CellSpanVertically(), "FilmFormat Format Y Movie PrintedFilmFormat Details X2" };
            string[] dataPrintedFilmFormatDe3 = { Formatter.CellSpanVertically(), "FilmFormat Format Z Movie PrintedFilmFormat Details X3" };
            string[] dataPrintedFilmFormatZz1 = { "Filmformat", "FilmFormat Format X Movie PrintedFilmFormat Details X1" };
            string[] dataPrintedFilmFormatZz2 = { Formatter.CellSpanVertically(), "FilmFormat Format Y Movie PrintedFilmFormat Details X2" };
            string[] dataPrintedFilmFormatZz3 = { Formatter.CellSpanVertically(), "FilmFormat Format Z Movie PrintedFilmFormat Details X3" };

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

            // Poster Chapter
            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Poster")); break;
                case "de": content.Add(Formatter.AsHeading2("Poster")); break;
                default: content.Add(Formatter.AsHeading2("Poster")); break;
            }

            string[] pathCompany = { value, "company" };

            switch (value)
            {
                case "en":
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName X?200|Type EnglishTitle X \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Y?200|Type EnglishTitle Y \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Z?200|Type EnglishTitle Z \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    break;
                case "de":
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName X?200|Type GermanTitle X \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Y?200|Type GermanTitle Y \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Z?200|Type GermanTitle Z \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    break;
                default:
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName X?200|Type GermanTitle X \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Y?200|Type GermanTitle Y \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Z?200|Type GermanTitle Z \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    break;
            }
            content.Add("");

            // Cover Chapter
            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Cover")); break;
                case "de": content.Add(Formatter.AsHeading2("Cover")); break;
                default: content.Add(Formatter.AsHeading2("Cover")); break;
            }

            switch (value)
            {
                case "en":
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName X?200|Type EnglishTitle X \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Y?200|Type EnglishTitle Y \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Z?200|Type EnglishTitle Z \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    break;
                case "de":
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName X?200|Type GermanTitle X \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Y?200|Type GermanTitle Y \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Z?200|Type GermanTitle Z \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    break;
                default:
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName X?200|Type GermanTitle X \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Y?200|Type GermanTitle Y \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Z?200|Type GermanTitle Z \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    break;
            }
            content.Add("");

            // Description Chapter
            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Descriptions")); break;
                case "de": content.Add(Formatter.AsHeading2("Beschreibungen")); break;
                default: content.Add(Formatter.AsHeading2("Beschreibungen")); break;
            }

            string[] pathPerson = { value, "biography" };

            string data = $"({Formatter.AsInternalLink(pathPerson, "Person FirstName X Person LastName X Person NameAddOn X")}, " +
                $"{Formatter.AsInternalLink(pathPerson, "Person FirstName Y Person LastName Y Person NameAddOn Y")}, " +
                $"{Formatter.AsInternalLink(pathPerson, "Person FirstName Z Person LastName Z Person NameAddOn Z")}, " +
                $"{Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, " +
                $"{Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, " +
                $"{Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})";


            switch (value)
            {
                case "en":
                    content.Add("Text Content X");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Y");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Z");
                    content.Add(data);
                    content.Add("");
                    break;
                case "de":
                    content.Add("Text Content X");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Y");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Z");
                    content.Add(data);
                    content.Add("");
                    break;
                default:
                    content.Add("Text Content X");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Y");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Z");
                    content.Add(data);
                    content.Add("");
                    break;
            }
            content.Add("");

            // Review Chapter
            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Reviews")); break;
                case "de": content.Add(Formatter.AsHeading2("Rezensionen")); break;
                default: content.Add(Formatter.AsHeading2("Rezensionen")); break;
            }

            switch (value)
            {
                case "en":
                    content.Add("Text Content X");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Y");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Z");
                    content.Add(data);
                    content.Add("");
                    break;
                case "de":
                    content.Add("Text Content X");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Y");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Z");
                    content.Add(data);
                    content.Add("");
                    break;
                default:
                    content.Add("Text Content X");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Y");
                    content.Add(data);
                    content.Add("");
                    content.Add("Text Content Z");
                    content.Add(data);
                    content.Add("");
                    break;
            }
            content.Add("");

            // Image Chapter
            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Images")); break;
                case "de": content.Add(Formatter.AsHeading2("Bilder")); break;
                default: content.Add(Formatter.AsHeading2("Bilder")); break;
            }

            switch (value)
            {
                case "en":
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName X?200|Type EnglishTitle X \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Y?200|Type EnglishTitle Y \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Z?200|Type EnglishTitle Z \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    break;
                case "de":
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName X?200|Type GermanTitle X \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Y?200|Type GermanTitle Y \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Z?200|Type GermanTitle Z \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    break;
                default:
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName X?200|Type GermanTitle X \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Y?200|Type GermanTitle Y \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    content.Add($"[{{{{cinema_and_television_movie:Image FileName Z?200|Type GermanTitle Z \\\\ ({Formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")}, {Formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")}, {Formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")})}}}}]");
                    break;
            }
            content.Add("");

            // Cast and Crew Chapter
            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Cast and Crew")); break;
                case "de": content.Add(Formatter.AsHeading2("Darsteller und Mannschaft")); break;
                default: content.Add(Formatter.AsHeading2("Darsteller und Mannschaft")); break;
            }

            // Director
            string[] pathDirector = { value, "biography" };
            string[] dataDirector1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie Director Role X1) Movie Director Details X1" };
            string[] dataDirector2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie Director Role X2) Movie Director Details X2" };
            string[] dataDirector3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie Director Role X3) Movie Director Details X3" };

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
            string[] dataWriter1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie Writer Role X1) Movie Writer Details X1" };
            string[] dataWriter2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie Writer Role X2) Movie Writer Details X2" };
            string[] dataWriter3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie Writer Role X3) Movie Writer Details X3" };

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
            string[] dataCast1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie Cast Character X1) Movie Cast Details X1", Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X") };
            string[] dataCast2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie Cast Character X2) Movie Cast Details X2", Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X") };
            string[] dataCast3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie Cast Character X3) Movie Cast Details X3", Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X") };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsHeading3("Cast"));
                    content.Add("Cast is Status EnglishTitle X.");
                    content.Add("");
                    break;
                case "de":
                    content.Add(Formatter.AsHeading3("Darsteller"));
                    content.Add("Darsteller sind Status GermanTitle X.");
                    content.Add("");
                    break;
                default:
                    content.Add(Formatter.AsHeading3("Darsteller"));
                    content.Add("Darsteller sind Status GermanTitle X.");
                    content.Add("");
                    break;
            }

            content.Add(Formatter.AsTableRow(dataCast1));
            content.Add(Formatter.AsTableRow(dataCast2));
            content.Add(Formatter.AsTableRow(dataCast3));

            content.Add($"");
            content.Add($"");

            // Producer
            string[] dataProducer1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie Producer Role X1) Movie Producer Details X1" };
            string[] dataProducer2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie Producer Role X2) Movie Producer Details X2" };
            string[] dataProducer3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie Producer Role X3) Movie Producer Details X3" };

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
            string[] dataMusician1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie Music Role X1) Movie Music Details X1" };
            string[] dataMusician2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie Music Role X2) Movie Music Details X2" };
            string[] dataMusician3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie Music Role X3) Movie Music Details X3" };

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
            string[] dataCinematographer1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie Cinematography Role X1) Movie Cinematography Details X1" };
            string[] dataCinematographer2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie Cinematography Role X2) Movie Cinematography Details X2" };
            string[] dataCinematographer3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie Cinematography Role X3) Movie Cinematography Details X3" };

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
            string[] dataFilmEditor1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie FilmEditing Role X1) Movie FilmEditing Details X1" };
            string[] dataFilmEditor2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie FilmEditing Role X2) Movie FilmEditing Details X2" };
            string[] dataFilmEditor3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie FilmEditing Role X3) Movie FilmEditing Details X3" };

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
            string[] dataCasting1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie Casting Role X1) Movie Casting Details X1" };
            string[] dataCasting2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie Casting Role X2) Movie Casting Details X2" };
            string[] dataCasting3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie Casting Role X3) Movie Casting Details X3" };

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
            string[] dataProductionDesigner1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie ProductionDesign Role X1) Movie ProductionDesign Details X1" };
            string[] dataProductionDesigner2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie ProductionDesign Role X2) Movie ProductionDesign Details X2" };
            string[] dataProductionDesigner3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie ProductionDesign Role X3) Movie ProductionDesign Details X3" };

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
            string[] dataArtDirector1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie ArtDirection Role X1) Movie ArtDirection Details X1" };
            string[] dataArtDirector2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie ArtDirection Role X2) Movie ArtDirection Details X2" };
            string[] dataArtDirector3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie ArtDirection Role X3) Movie ArtDirection Details X3" };

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
            string[] dataSetDecoration1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie SetDecoration Role X1) Movie SetDecoration Details X1" };
            string[] dataSetDecoration2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie SetDecoration Role X2) Movie SetDecoration Details X2" };
            string[] dataSetDecoration3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie SetDecoration Role X3) Movie SetDecoration Details X3" };

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
            string[] dataCostumeDesign1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie CostumeDesign Role X1) Movie CostumeDesign Details X1" };
            string[] dataCostumeDesign2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie CostumeDesign Role X2) Movie CostumeDesign Details X2" };
            string[] dataCostumeDesign3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie CostumeDesign Role X3) Movie CostumeDesign Details X3" };

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
            string[] dataMakeupDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie MakeupDepartment Role X1) Movie MakeupDepartment Details X1" };
            string[] dataMakeupDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie MakeupDepartment Role X2) Movie MakeupDepartment Details X2" };
            string[] dataMakeupDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie MakeupDepartment Role X3) Movie MakeupDepartment Details X3" };

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
            string[] dataProductionManagement1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie ProductionManagement Role X1) Movie ProductionManagement Details X1" };
            string[] dataProductionManagement2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie ProductionManagement Role X2) Movie ProductionManagement Details X2" };
            string[] dataProductionManagement3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie ProductionManagement Role X3) Movie ProductionManagement Details X3" };

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
            string[] dataAssistantDirector1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie AssistantDirector Role X1) Movie AssistantDirector Details X1" };
            string[] dataAssistantDirector2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie AssistantDirector Role X2) Movie AssistantDirector Details X2" };
            string[] dataAssistantDirector3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie AssistantDirector Role X3) Movie AssistantDirector Details X3" };

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
            string[] dataArtDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie ArtDepartment Role X1) Movie ArtDepartment Details X1" };
            string[] dataArtDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie ArtDepartment Role X2) Movie ArtDepartment Details X2" };
            string[] dataArtDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie ArtDepartment Role X3) Movie ArtDepartment Details X3" };

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
            string[] dataSoundDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie SoundDepartment Role X1) Movie SoundDepartment Details X1" };
            string[] dataSoundDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie SoundDepartment Role X2) Movie SoundDepartment Details X2" };
            string[] dataSoundDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie SoundDepartment Role X3) Movie SoundDepartment Details X3" };

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
            string[] dataSpecialEffects1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie SpecialEffects Role X1) Movie SpecialEffects Details X1" };
            string[] dataSpecialEffects2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie SpecialEffects Role X2) Movie SpecialEffects Details X2" };
            string[] dataSpecialEffects3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie SpecialEffects Role X3) Movie SpecialEffects Details X3" };

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
            string[] dataVisualEffects1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie VisualEffects Role X1) Movie VisualEffects Details X1" };
            string[] dataVisualEffects2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie VisualEffects Role X2) Movie VisualEffects Details X2" };
            string[] dataVisualEffects3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie VisualEffects Role X3) Movie VisualEffects Details X3" };

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
            string[] dataStunts1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie Stunts Role X1) Movie Stunts Details X1" };
            string[] dataStunts2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie Stunts Role X2) Movie Stunts Details X2" };
            string[] dataStunts3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie Stunts Role X3) Movie Stunts Details X3" };

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
            string[] dataElectricalDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie ElectricalDepartment Role X1) Movie ElectricalDepartment Details X1" };
            string[] dataElectricalDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie ElectricalDepartment Role X2) Movie ElectricalDepartment Details X2" };
            string[] dataElectricalDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie ElectricalDepartment Role X3) Movie ElectricalDepartment Details X3" };

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
            string[] dataAnimationDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie AnimationDepartment Role X1) Movie AnimationDepartment Details X1" };
            string[] dataAnimationDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie AnimationDepartment Role X2) Movie AnimationDepartment Details X2" };
            string[] dataAnimationDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie AnimationDepartment Role X3) Movie AnimationDepartment Details X3" };

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
            string[] dataCastingDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie CastingDepartment Role X1) Movie CastingDepartment Details X1" };
            string[] dataCastingDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie CastingDepartment Role X2) Movie CastingDepartment Details X2" };
            string[] dataCastingDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie CastingDepartment Role X3) Movie CastingDepartment Details X3" };

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
            string[] dataCostumeDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie CostumeDepartment Role X1) Movie CostumeDepartment Details X1" };
            string[] dataCostumeDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie CostumeDepartment Role X2) Movie CostumeDepartment Details X2" };
            string[] dataCostumeDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie CostumeDepartment Role X3) Movie CostumeDepartment Details X3" };

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
            string[] dataEditorialDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie EditorialDepartment Role X1) Movie EditorialDepartment Details X1" };
            string[] dataEditorialDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie EditorialDepartment Role X2) Movie EditorialDepartment Details X2" };
            string[] dataEditorialDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie EditorialDepartment Role X3) Movie EditorialDepartment Details X3" };

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
            string[] dataLocationManagement1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie LocationManagement Role X1) Movie LocationManagement Details X1" };
            string[] dataLocationManagement2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie LocationManagement Role X2) Movie LocationManagement Details X2" };
            string[] dataLocationManagement3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie LocationManagement Role X3) Movie LocationManagement Details X3" };

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
            string[] dataMusicDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie MusicDepartment Role X1) Movie MusicDepartment Details X1" };
            string[] dataMusicDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie MusicDepartment Role X2) Movie MusicDepartment Details X2" };
            string[] dataMusicDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie MusicDepartment Role X3) Movie MusicDepartment Details X3" };

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
            string[] dataContinuityDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie ContinuityDepartment Role X1) Movie ContinuityDepartment Details X1" };
            string[] dataContinuityDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie ContinuityDepartment Role X2) Movie ContinuityDepartment Details X2" };
            string[] dataContinuityDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie ContinuityDepartment Role X3) Movie ContinuityDepartment Details X3" };

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

            // Transportation Department
            string[] dataTransportationDepartment1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie TransportationDepartment Role X1) Movie TransportationDepartment Details X1" };
            string[] dataTransportationDepartment2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie TransportationDepartment Role X2) Movie TransportationDepartment Details X2" };
            string[] dataTransportationDepartment3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie TransportationDepartment Role X3) Movie TransportationDepartment Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Transportation Department")); break;
                case "de": content.Add(Formatter.AsHeading3("Transport")); break;
                default: content.Add(Formatter.AsHeading3("Transport")); break;
            }

            content.Add(Formatter.AsTableRow(dataTransportationDepartment1));
            content.Add(Formatter.AsTableRow(dataTransportationDepartment2));
            content.Add(Formatter.AsTableRow(dataTransportationDepartment3));

            content.Add($"");
            content.Add($"");

            // Other Crew
            string[] dataOtherCrew1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie OtherCrew Role X1) Movie OtherCrew Details X1" };
            string[] dataOtherCrew2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie OtherCrew Role X2) Movie OtherCrew Details X2" };
            string[] dataOtherCrew3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie OtherCrew Role X3) Movie OtherCrew Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Additional Crew")); break;
                case "de": content.Add(Formatter.AsHeading3("Weitere Crewmitglieder")); break;
                default: content.Add(Formatter.AsHeading3("Weitere Crewmitglieder")); break;
            }

            content.Add(Formatter.AsTableRow(dataOtherCrew1));
            content.Add(Formatter.AsTableRow(dataOtherCrew2));
            content.Add(Formatter.AsTableRow(dataOtherCrew3));

            content.Add($"");
            content.Add($"");

            // Thanks
            string[] dataThanks1 = { Formatter.AsInternalLink(pathDirector, "Person FirstName X Person LastName X Person NameAddOn X"), "(Movie Thanks Role X1) Movie Thanks Details X1" };
            string[] dataThanks2 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Y Person LastName Y Person NameAddOn Y"), "(Movie Thanks Role X2) Movie Thanks Details X2" };
            string[] dataThanks3 = { Formatter.AsInternalLink(pathDirector, "Person FirstName Z Person LastName Z Person NameAddOn Z"), "(Movie Thanks Role X3) Movie Thanks Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Thanks")); break;
                case "de": content.Add(Formatter.AsHeading3("Dank")); break;
                default: content.Add(Formatter.AsHeading3("Dank")); break;
            }

            content.Add(Formatter.AsTableRow(dataThanks1));
            content.Add(Formatter.AsTableRow(dataThanks2));
            content.Add(Formatter.AsTableRow(dataThanks3));

            content.Add($"");
            content.Add($"");

            switch (value)
            {
                case "en":
                    content.Add("Crew is Status EnglishTitle X.");
                    break;
                case "de":
                    content.Add("Crew ist Status GermanTitle X.");
                    break;
                default:
                    content.Add("Crew ist Status GermanTitle X.");
                    break;
            }

            content.Add($"");
            content.Add($"");

            // Company Chapter
            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Company Credits")); break;
                case "de": content.Add(Formatter.AsHeading2("Beteiligte Firmen")); break;
                default: content.Add(Formatter.AsHeading2("Beteiligte Firmen")); break;
            }

            // Production Company
            string[] pathProductionCompany = { value, "company" };
            string[] dataProductionCompany1 = { Formatter.AsInternalLink(pathProductionCompany, "Company Name X Company NameAddOn X"), "(Movie ProductionCompany Role X1) Movie ProductionCompany Details X1" };
            string[] dataProductionCompany2 = { Formatter.AsInternalLink(pathProductionCompany, "Company Name Y Company NameAddOn Y"), "(Movie ProductionCompany Role X2) Movie ProductionCompany Details X2" };
            string[] dataProductionCompany3 = { Formatter.AsInternalLink(pathProductionCompany, "Company Name Z Company NameAddOn Z"), "(Movie ProductionCompany Role X3) Movie ProductionCompany Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Production Companies")); break;
                case "de": content.Add(Formatter.AsHeading3("Produktionsfirmen")); break;
                default: content.Add(Formatter.AsHeading3("Produktionsfirmen")); break;
            }

            content.Add(Formatter.AsTableRow(dataProductionCompany1));
            content.Add(Formatter.AsTableRow(dataProductionCompany2));
            content.Add(Formatter.AsTableRow(dataProductionCompany3));

            content.Add($"");
            content.Add($"");

            // Distributor
            string[] pathDistributorCountry = { value, "info" };

            string[] dataDistributor1En = { Formatter.AsInternalLink(pathProductionCompany, "Company Name X Company NameAddOn X"), $"(Movie Distributor ReleaseDate X1)", $"({Formatter.AsInternalLink(pathDistributorCountry, "Country OriginalFullName X", "Country EnglishShortName X")})", "(Movie Distributor Role X1) Movie Distributor Details X1" };
            string[] dataDistributor1De = { Formatter.AsInternalLink(pathProductionCompany, "Company Name X Company NameAddOn X"), $"(Movie Distributor ReleaseDate X1)", $"({Formatter.AsInternalLink(pathDistributorCountry, "Country OriginalFullName X", "Country GermanShortName X")})", "(Movie Distributor Role X1) Movie Distributor Details X1" };
            string[] dataDistributor2En = { Formatter.AsInternalLink(pathProductionCompany, "Company Name Y Company NameAddOn Y"), $"(Movie Distributor ReleaseDate X2)", $"({Formatter.AsInternalLink(pathDistributorCountry, "Country OriginalFullName X", "Country EnglishShortName X")})", "(Movie Distributor Role X2) Movie Distributor Details X2" };
            string[] dataDistributor2De = { Formatter.AsInternalLink(pathProductionCompany, "Company Name Y Company NameAddOn Y"), $"(Movie Distributor ReleaseDate X2)", $"({Formatter.AsInternalLink(pathDistributorCountry, "Country OriginalFullName X", "Country GermanShortName X")})", "(Movie Distributor Role X2) Movie Distributor Details X2" };
            string[] dataDistributor3En = { Formatter.AsInternalLink(pathProductionCompany, "Company Name Z Company NameAddOn Z"), $"(Movie Distributor ReleaseDate X3)", $"({Formatter.AsInternalLink(pathDistributorCountry, "Country OriginalFullName X", "Country EnglishShortName X")})", "(Movie Distributor Role X3) Movie Distributor Details X3" };
            string[] dataDistributor3De = { Formatter.AsInternalLink(pathProductionCompany, "Company Name Z Company NameAddOn Z"), $"(Movie Distributor ReleaseDate X3)", $"({Formatter.AsInternalLink(pathDistributorCountry, "Country OriginalFullName X", "Country GermanShortName X")})", "(Movie Distributor Role X3) Movie Distributor Details X3" };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsHeading3("Distributors"));
                    content.Add(Formatter.AsTableRow(dataDistributor1En));
                    content.Add(Formatter.AsTableRow(dataDistributor2En));
                    content.Add(Formatter.AsTableRow(dataDistributor3En));
                    break;
                case "de":
                default:
                    content.Add(Formatter.AsHeading3("Vertrieb"));
                    content.Add(Formatter.AsTableRow(dataDistributor1De));
                    content.Add(Formatter.AsTableRow(dataDistributor2De));
                    content.Add(Formatter.AsTableRow(dataDistributor3De));
                    break;
            }

            content.Add($"");
            content.Add($"");

            // Special Effects Company
            string[] dataSpecialEffectsCompany1 = { Formatter.AsInternalLink(pathProductionCompany, "Company Name X Company NameAddOn X"), "(Movie SpecialEffectsCompany Role X1) Movie SpecialEffectsCompany Details X1" };
            string[] dataSpecialEffectsCompany2 = { Formatter.AsInternalLink(pathProductionCompany, "Company Name Y Company NameAddOn Y"), "(Movie SpecialEffectsCompany Role X2) Movie SpecialEffectsCompany Details X2" };
            string[] dataSpecialEffectsCompany3 = { Formatter.AsInternalLink(pathProductionCompany, "Company Name Z Company NameAddOn Z"), "(Movie SpecialEffectsCompany Role X3) Movie SpecialEffectsCompany Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Special Effects")); break;
                case "de": content.Add(Formatter.AsHeading3("Spezialeffekte")); break;
                default: content.Add(Formatter.AsHeading3("Spezialeffekte")); break;
            }

            content.Add(Formatter.AsTableRow(dataSpecialEffectsCompany1));
            content.Add(Formatter.AsTableRow(dataSpecialEffectsCompany2));
            content.Add(Formatter.AsTableRow(dataSpecialEffectsCompany3));

            content.Add($"");
            content.Add($"");

            // Other Company
            string[] dataOtherCompany1 = { Formatter.AsInternalLink(pathProductionCompany, "Company Name X Company NameAddOn X"), "(Movie OtherCompany Role X1) Movie OtherCompany Details X1" };
            string[] dataOtherCompany2 = { Formatter.AsInternalLink(pathProductionCompany, "Company Name Y Company NameAddOn Y"), "(Movie OtherCompany Role X2) Movie OtherCompany Details X2" };
            string[] dataOtherCompany3 = { Formatter.AsInternalLink(pathProductionCompany, "Company Name Z Company NameAddOn Z"), "(Movie OtherCompany Role X3) Movie OtherCompany Details X3" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Other Companies")); break;
                case "de": content.Add(Formatter.AsHeading3("Weitere Firmen")); break;
                default: content.Add(Formatter.AsHeading3("Weitere Firmen")); break;
            }

            content.Add(Formatter.AsTableRow(dataOtherCompany1));
            content.Add(Formatter.AsTableRow(dataOtherCompany2));
            content.Add(Formatter.AsTableRow(dataOtherCompany3));

            content.Add($"");
            content.Add($"");

            // Filming and Production Chapter

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Filming and Production")); break;
                case "de": content.Add(Formatter.AsHeading2("Produktion")); break;
                default: content.Add(Formatter.AsHeading2("Produktion")); break;
            }

            // FilmingLocation
            string[] pathFilmingLocation = { value, "info" };
            string[] dataFilmingLocationEn1 = { $"{Formatter.AsInternalLink(pathFilmingLocation, $"Location X")}, {Formatter.AsInternalLink(pathFilmingLocation, "Country OriginalFullName X", "Country EnglishShortName X")} -- Movie FilmingLocation Details X1" };
            string[] dataFilmingLocationEn2 = { $"{Formatter.AsInternalLink(pathFilmingLocation, $"Location Y")}, {Formatter.AsInternalLink(pathFilmingLocation, "Country OriginalFullName Y", "Country EnglishShortName Y")} -- Movie FilmingLocation Details X2" };
            string[] dataFilmingLocationEn3 = { $"{Formatter.AsInternalLink(pathFilmingLocation, $"Location Z")}, {Formatter.AsInternalLink(pathFilmingLocation, "Country OriginalFullName Z", "Country EnglishShortName Z")} -- Movie FilmingLocation Details X3" };
            string[] dataFilmingLocationDe1 = { $"{Formatter.AsInternalLink(pathFilmingLocation, $"Location X")}, {Formatter.AsInternalLink(pathFilmingLocation, "Country OriginalFullName X", "Country GermanShortName X")} -- Movie FilmingLocation Details X1" };
            string[] dataFilmingLocationDe2 = { $"{Formatter.AsInternalLink(pathFilmingLocation, $"Location Y")}, {Formatter.AsInternalLink(pathFilmingLocation, "Country OriginalFullName Y", "Country GermanShortName Y")} -- Movie FilmingLocation Details X2" };
            string[] dataFilmingLocationDe3 = { $"{Formatter.AsInternalLink(pathFilmingLocation, $"Location Z")}, {Formatter.AsInternalLink(pathFilmingLocation, "Country OriginalFullName Z", "Country GermanShortName Z")} -- Movie FilmingLocation Details X3" };
            string[] dataFilmingLocationZz1 = { $"{Formatter.AsInternalLink(pathFilmingLocation, $"Location X")}, {Formatter.AsInternalLink(pathFilmingLocation, "Country OriginalFullName X", "Country GermanShortName X")} -- Movie FilmingLocation Details X1" };
            string[] dataFilmingLocationZz2 = { $"{Formatter.AsInternalLink(pathFilmingLocation, $"Location Y")}, {Formatter.AsInternalLink(pathFilmingLocation, "Country OriginalFullName Y", "Country GermanShortName Y")} -- Movie FilmingLocation Details X2" };
            string[] dataFilmingLocationZz3 = { $"{Formatter.AsInternalLink(pathFilmingLocation, $"Location Z")}, {Formatter.AsInternalLink(pathFilmingLocation, "Country OriginalFullName Z", "Country GermanShortName Z")} -- Movie FilmingLocation Details X3" };

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsHeading3("Filming Locations"));
                    content.Add(Formatter.AsTableRow(dataFilmingLocationEn1));
                    content.Add(Formatter.AsTableRow(dataFilmingLocationEn2));
                    content.Add(Formatter.AsTableRow(dataFilmingLocationEn3));
                    break;
                case "de":
                    content.Add(Formatter.AsHeading3("Drehorte"));
                    content.Add(Formatter.AsTableRow(dataFilmingLocationDe1));
                    content.Add(Formatter.AsTableRow(dataFilmingLocationDe2));
                    content.Add(Formatter.AsTableRow(dataFilmingLocationDe3));
                    break;
                default:
                    content.Add(Formatter.AsHeading3("Drehorte"));
                    content.Add(Formatter.AsTableRow(dataFilmingLocationZz1));
                    content.Add(Formatter.AsTableRow(dataFilmingLocationZz2));
                    content.Add(Formatter.AsTableRow(dataFilmingLocationZz3));
                    break;
            }
            content.Add($"");
            content.Add($"");

            // Filming Dates
            string[] pathFilmingDates = { value, "date" };
            string[] dataFilmingDates1 = { $"{Formatter.AsInternalLink(pathFilmingDates, "Movie FilmingDate StartDate X1")} - {Formatter.AsInternalLink(pathFilmingDates, "Movie FilmingDate EndDate X1")}" };
            string[] dataFilmingDates2 = { $"{Formatter.AsInternalLink(pathFilmingDates, "Movie FilmingDate StartDate X2")} - {Formatter.AsInternalLink(pathFilmingDates, "Movie FilmingDate EndDate X2")}" };
            string[] dataFilmingDates3 = { $"{Formatter.AsInternalLink(pathFilmingDates, "Movie FilmingDate StartDate X3")} - {Formatter.AsInternalLink(pathFilmingDates, "Movie FilmingDate EndDate X3")}" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Filming Dates")); break;
                case "de": content.Add(Formatter.AsHeading3("Drehdatum")); break;
                default: content.Add(Formatter.AsHeading3("Drehdatum")); break;
            }

            content.Add(Formatter.AsTableRow(dataFilmingDates1));
            content.Add(Formatter.AsTableRow(dataFilmingDates2));
            content.Add(Formatter.AsTableRow(dataFilmingDates3));

            content.Add($"");
            content.Add($"");

            // Production Dates
            string[] dataProductionDates1 = { $"{Formatter.AsInternalLink(pathFilmingDates, "Movie ProductionDate StartDate X1")} - {Formatter.AsInternalLink(pathFilmingDates, "Movie ProductionDate EndDate X1")}" };
            string[] dataProductionDates2 = { $"{Formatter.AsInternalLink(pathFilmingDates, "Movie ProductionDate StartDate X2")} - {Formatter.AsInternalLink(pathFilmingDates, "Movie ProductionDate EndDate X2")}" };
            string[] dataProductionDates3 = { $"{Formatter.AsInternalLink(pathFilmingDates, "Movie ProductionDate StartDate X3")} - {Formatter.AsInternalLink(pathFilmingDates, "Movie ProductionDate EndDate X3")}" };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading3("Production Dates")); break;
                case "de": content.Add(Formatter.AsHeading3("Produktionsdatum")); break;
                default: content.Add(Formatter.AsHeading3("Produktionsdatum")); break;
            }

            content.Add(Formatter.AsTableRow(dataProductionDates1));
            content.Add(Formatter.AsTableRow(dataProductionDates2));
            content.Add(Formatter.AsTableRow(dataProductionDates3));

            content.Add($"");
            content.Add($"");

            // Award Chapter
            string[] pathAward = { value, "info" };
            string[] pathAwardDate = { value, "date" };
            string[] pathAwardPerson = { value, "biography" };
            string[] dataAwardEn10 = { Formatter.AsInternalLink(pathAward, "Award Name X", "Award Name X"), Formatter.AsInternalLink(pathAwardDate, "Movie Award Date X1", "Movie Award Date X1"), "Movie Award Category X1", "Winner", "Movie Award Details X1" };
            string[] dataAwardEn20 = { Formatter.AsInternalLink(pathAward, "Award Name Y", "Award Name Y"), Formatter.AsInternalLink(pathAwardDate, "Movie Award Date X2", "Movie Award Date X2"), "Movie Award Category X2", "Nominee", "Movie Award Details X2" };
            string[] dataAwardEn30 = { Formatter.AsInternalLink(pathAward, "Award Name Z", "Award Name Z"), Formatter.AsInternalLink(pathAwardDate, "Movie Award Date X3", "Movie Award Date X3"), "Movie Award Category X3", "Nominee", "Movie Award Details X3" };
            string[] dataAwardDe10 = { Formatter.AsInternalLink(pathAward, "Award Name X", "Award Name X"), Formatter.AsInternalLink(pathAwardDate, "Movie Award Date X1", "Movie Award Date X1"), "Movie Award Category X1", "Gewinner", "Movie Award Details X1" };
            string[] dataAwardDe20 = { Formatter.AsInternalLink(pathAward, "Award Name Y", "Award Name Y"), Formatter.AsInternalLink(pathAwardDate, "Movie Award Date X2", "Movie Award Date X2"), "Movie Award Category X2", "Nominierter", "Movie Award Details X2" };
            string[] dataAwardDe30 = { Formatter.AsInternalLink(pathAward, "Award Name Z", "Award Name Z"), Formatter.AsInternalLink(pathAwardDate, "Movie Award Date X3", "Movie Award Date X3"), "Movie Award Category X3", "Nominierter", "Movie Award Details X3" };
            string[] dataAward11 = { Formatter.CellSpanVertically(), Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathAwardPerson, "Person FirstName X Person LastName X Person NameAddOn X", "Person FirstName X Person LastName X")} (Movie Award Person Role X11) Movie Award Person Details X11", " ", " " };
            string[] dataAward12 = { Formatter.CellSpanVertically(), Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathAwardPerson, "Person FirstName Y Person LastName Y Person NameAddOn Y", "Person FirstName Y Person LastName Y")} (Movie Award Person Role X12) Movie Award Person Details X12", " ", " " };
            string[] dataAward13 = { Formatter.CellSpanVertically(), Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathAwardPerson, "Person FirstName Z Person LastName Z Person NameAddOn Z", "Person FirstName Z Person LastName Z")} (Movie Award Person Role X13) Movie Award Person Details X13", " ", " " };
            string[] dataAward21 = { Formatter.CellSpanVertically(), Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathAwardPerson, "Person FirstName X Person LastName X Person NameAddOn X", "Person FirstName X Person LastName X")} (Movie Award Person Role X21) Movie Award Person Details X21", " ", " " };
            string[] dataAward22 = { Formatter.CellSpanVertically(), Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathAwardPerson, "Person FirstName Y Person LastName Y Person NameAddOn Y", "Person FirstName Y Person LastName Y")} (Movie Award Person Role X22) Movie Award Person Details X22", " ", " " };
            string[] dataAward23 = { Formatter.CellSpanVertically(), Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathAwardPerson, "Person FirstName Z Person LastName Z Person NameAddOn Z", "Person FirstName Z Person LastName Z")} (Movie Award Person Role X23) Movie Award Person Details X23", " ", " " };
            string[] dataAward31 = { Formatter.CellSpanVertically(), Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathAwardPerson, "Person FirstName X Person LastName X Person NameAddOn X", "Person FirstName X Person LastName X")} (Movie Award Person Role X31) Movie Award Person Details X31", " ", " " };
            string[] dataAward32 = { Formatter.CellSpanVertically(), Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathAwardPerson, "Person FirstName Y Person LastName Y Person NameAddOn Y", "Person FirstName Y Person LastName Y")} (Movie Award Person Role X32) Movie Award Person Details X32", " ", " " };
            string[] dataAward33 = { Formatter.CellSpanVertically(), Formatter.CellSpanVertically(), $"{Formatter.AsInternalLink(pathAwardPerson, "Person FirstName Z Person LastName Z Person NameAddOn Z", "Person FirstName Z Person LastName Z")} (Movie Award Person Role X33) Movie Award Person Details X33", " ", " " };

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Awards")); break;
                case "de": content.Add(Formatter.AsHeading2("Auszeichnungen")); break;
                default: content.Add(Formatter.AsHeading2("Auszeichnungen")); break;
            }

            switch (value)
            {
                case "en":
                    content.Add(Formatter.AsTableRow(dataAwardEn10));
                    content.Add(Formatter.AsTableRow(dataAward11));
                    content.Add(Formatter.AsTableRow(dataAward12));
                    content.Add(Formatter.AsTableRow(dataAward13));
                    content.Add(Formatter.AsTableRow(dataAwardEn20));
                    content.Add(Formatter.AsTableRow(dataAward21));
                    content.Add(Formatter.AsTableRow(dataAward22));
                    content.Add(Formatter.AsTableRow(dataAward23));
                    content.Add(Formatter.AsTableRow(dataAwardEn30));
                    content.Add(Formatter.AsTableRow(dataAward31));
                    content.Add(Formatter.AsTableRow(dataAward32));
                    content.Add(Formatter.AsTableRow(dataAward33));
                    break;
                case "de":
                    content.Add(Formatter.AsTableRow(dataAwardDe10));
                    content.Add(Formatter.AsTableRow(dataAward11));
                    content.Add(Formatter.AsTableRow(dataAward12));
                    content.Add(Formatter.AsTableRow(dataAward13));
                    content.Add(Formatter.AsTableRow(dataAwardDe20));
                    content.Add(Formatter.AsTableRow(dataAward21));
                    content.Add(Formatter.AsTableRow(dataAward22));
                    content.Add(Formatter.AsTableRow(dataAward23));
                    content.Add(Formatter.AsTableRow(dataAwardDe30));
                    content.Add(Formatter.AsTableRow(dataAward31));
                    content.Add(Formatter.AsTableRow(dataAward32));
                    content.Add(Formatter.AsTableRow(dataAward33));
                    break;
                default:
                    content.Add(Formatter.AsTableRow(dataAwardDe10));
                    content.Add(Formatter.AsTableRow(dataAward11));
                    content.Add(Formatter.AsTableRow(dataAward12));
                    content.Add(Formatter.AsTableRow(dataAward13));
                    content.Add(Formatter.AsTableRow(dataAwardDe20));
                    content.Add(Formatter.AsTableRow(dataAward21));
                    content.Add(Formatter.AsTableRow(dataAward22));
                    content.Add(Formatter.AsTableRow(dataAward23));
                    content.Add(Formatter.AsTableRow(dataAwardDe30));
                    content.Add(Formatter.AsTableRow(dataAward31));
                    content.Add(Formatter.AsTableRow(dataAward32));
                    content.Add(Formatter.AsTableRow(dataAward33));
                    break;
            }
            content.Add($"");
            content.Add($"");

            // Weblink Chapter
            string dataWeblinksEn1 = $"{Formatter.ListItemIndent()}{Formatter.ListItemUnsorted()} {Formatter.AsExternalLink("Weblink URL X", "Weblink EnglishTitle X")} (Language EnglishName X)";
            string dataWeblinksEn2 = $"{Formatter.ListItemIndent()}{Formatter.ListItemUnsorted()} {Formatter.AsExternalLink("Weblink URL Y", "Weblink EnglishTitle Y")} (Language EnglishName Y)";
            string dataWeblinksEn3 = $"{Formatter.ListItemIndent()}{Formatter.ListItemUnsorted()} {Formatter.AsExternalLink("Weblink URL Z", "Weblink EnglishTitle Z")} (Language EnglishName Z)";
            string dataWeblinksDe1 = $"{Formatter.ListItemIndent()}{Formatter.ListItemUnsorted()} {Formatter.AsExternalLink("Weblink URL X", "Weblink GermanTitle X")} (Language GermanName X)";
            string dataWeblinksDe2 = $"{Formatter.ListItemIndent()}{Formatter.ListItemUnsorted()} {Formatter.AsExternalLink("Weblink URL Y", "Weblink GermanTitle Y")} (Language GermanName Y)";
            string dataWeblinksDe3 = $"{Formatter.ListItemIndent()}{Formatter.ListItemUnsorted()} {Formatter.AsExternalLink("Weblink URL Z", "Weblink GermanTitle Z")} (Language GermanName Z)";

            switch (value)
            {
                case "en": content.Add(Formatter.AsHeading2("Other Sites")); break;
                case "de": content.Add(Formatter.AsHeading2("Andere Webseiten")); break;
                default: content.Add(Formatter.AsHeading2("Andere Webseiten")); break;
            }

            switch (value)
            {
                case "en":
                    content.Add(dataWeblinksEn1);
                    content.Add(dataWeblinksEn2);
                    content.Add(dataWeblinksEn3);
                    break;
                case "de":
                    content.Add(dataWeblinksDe1);
                    content.Add(dataWeblinksDe2);
                    content.Add(dataWeblinksDe3);
                    break;
                default:
                    content.Add(dataWeblinksDe1);
                    content.Add(dataWeblinksDe2);
                    content.Add(dataWeblinksDe3);
                    break;
            }
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
