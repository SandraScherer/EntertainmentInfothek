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
using EntertainmentDB.DBAccess.Read;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WikiPageCreator.Export.Format;

namespace WikiPageCreator.Export.Create.IntegrationTests
{
    [TestClass()]
    public class MovieContentCreatorTests_WithDB
    {
        const string VALID_ID = "_xxx";
        const string INVALID_ID = "_aaa";

        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        public void MovieContentCreatorTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie entry = new Movie(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            // Act
            MovieContentCreator creator = new MovieContentCreator(entry, formatter, targetLanguageCode);

            // Assert
            Assert.IsNotNull(creator);
            Assert.AreEqual(entry, creator.Movie);
            Assert.AreEqual(formatter, creator.Formatter);
            Assert.AreEqual(targetLanguageCode, creator.TargetLanguageCode);
            Assert.AreEqual("Dummy", creator.Headings["en"]);
            Assert.AreEqual("Dummy", creator.Headings["de"]);
        }

        [DataTestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MovieContentCreatorTest_withMovieNull(string targetLanguageCode)
        {
            // Arrange
            Formatter formatter = new DokuWikiFormatter();

            // Act, Assert
            MovieContentCreator creator = new MovieContentCreator(null, formatter, targetLanguageCode);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MovieContentCreatorTest_withFormatterNull(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie entry = new Movie(reader, id);

            // Act, Assert
            MovieContentCreator creator = new MovieContentCreator(entry, null, targetLanguageCode);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MovieContentCreatorTest_withTargetLanguageCodeNull(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie entry = new Movie(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            // Act, Assert
            MovieContentCreator creator = new MovieContentCreator(entry, formatter, null);
        }

        [DataTestMethod()]
        [DataRow(VALID_ID)]
        [DataRow(INVALID_ID)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MovieContentCreatorTest_withTargetLanguageCodeEmptyString(string id)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie entry = new Movie(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            // Act, Assert
            MovieContentCreator creator = new MovieContentCreator(entry, formatter, "");
        }

        [DataTestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void GetPageNameTest_withValidID(string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie entry = new Movie(reader, VALID_ID);
            entry.Retrieve(false);
            Formatter formatter = new DokuWikiFormatter();

            MovieContentCreator creator = new MovieContentCreator(entry, formatter, targetLanguageCode);

            string testContent = $"{formatter.AsFilename("Movie OriginalTitle X (Movi)")}";

            // Act
            string content = creator.GetPageName();

            // Assert
            Assert.AreEqual(testContent, content);
        }

        [DataTestMethod()]
        [DataRow("en")]
        [DataRow("de")]
        [DataRow("zz")]
        public void CreatePageTest_withValidID(string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie entry = new Movie(reader, VALID_ID);
            entry.Retrieve(false);
            Formatter formatter = new DokuWikiFormatter();

            MovieContentCreator creator = new MovieContentCreator(entry, formatter, targetLanguageCode);

            List<string> testContent = new List<string>();

            string[] pathInfo = { targetLanguageCode, "info" };
            string[] pathDate = { targetLanguageCode, "date" };
            string[] pathCompany = { targetLanguageCode, "company" };
            string[] pathCertification = { "certification" };

            // File Header
            testContent.Add(formatter.DisableCache());
            testContent.Add(formatter.DisableTOC());
            testContent.Add(formatter.BeginComment());
            testContent.Add($"   Movie OriginalTitle X");
            testContent.Add($"");
            testContent.Add($"   @author  WikiPageCreator");
            testContent.Add($"   @date    {DateTime.Now:yyyy-MM-dd}");
            testContent.Add($"   @version Status EnglishTitle X: Movie LastUpdated X");
            testContent.Add(formatter.EndComment());
            testContent.Add($"");
            testContent.Add($"");

            // Title
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsHeading1("Movie EnglishTitle X"));
            }
            else if (targetLanguageCode.Equals("de"))
            {
                testContent.Add(formatter.AsHeading1("Movie GermanTitle X"));
            }
            else
            {
                testContent.Add(formatter.AsHeading1("Movie OriginalTitle X"));
            }
            testContent.Add($"");

            // InfoBox Begin
            int[] width = { 30, 70 };
            testContent.Add(formatter.BeginBox(475, Alignment.Right));
            testContent.Add(formatter.DefineTable(445, width));
            testContent.Add(formatter.AsTableTitle(new string[] { null, null }));

            // InfoBox Title
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Original Title",
                                   "Movie OriginalTitle X" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Originaltitel",
                                   "Movie OriginalTitle X" }));
            }

            // InfoBox Type
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Type",
                                   formatter.AsInternalLink(pathInfo, "Type EnglishTitle X", "Type EnglishTitle X") }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Typ",
                                   formatter.AsInternalLink(pathInfo, "Type EnglishTitle X", "Type GermanTitle X") }));
            }

            // InfoBox ReleaseDate
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Original Release Date",
                                   formatter.AsInternalLink(pathDate, "Movie ReleaseDate X", "Movie ReleaseDate X") }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Erstausstrahlung",
                                   formatter.AsInternalLink(pathDate, "Movie ReleaseDate X", "Movie ReleaseDate X") }));
            }

            // InfoBox Genre
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Genre",
                                   $"{formatter.AsInternalLink(pathInfo, "Genre EnglishTitle X", "Genre EnglishTitle X")} Movie Genre Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Genre EnglishTitle Y", "Genre EnglishTitle Y")} Movie Genre Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Genre EnglishTitle Z", "Genre EnglishTitle Z")} Movie Genre Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Genre",
                                   $"{formatter.AsInternalLink(pathInfo, "Genre EnglishTitle X", "Genre GermanTitle X")} Movie Genre Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Genre EnglishTitle Y", "Genre GermanTitle Y")} Movie Genre Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Genre EnglishTitle Z", "Genre GermanTitle Z")} Movie Genre Details X3" }));
            }

            // InfoBox Certification
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Certification",
                                   $"{formatter.AsImage(pathCertification, "Image FileName X", 75)} Movie Certification Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsImage(pathCertification, "Image FileName Y", 75)} Movie Certification Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsImage(pathCertification, "Image FileName Z", 75)} Movie Certification Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Altersfreigabe",
                                   $"{formatter.AsImage(pathCertification, "Image FileName X", 75)} Movie Certification Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsImage(pathCertification, "Image FileName Y", 75)} Movie Certification Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsImage(pathCertification, "Image FileName Z", 75)} Movie Certification Details X3" }));
            }

            // InfoBox Country
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Production Country",
                                   $"{formatter.AsInternalLink(pathInfo, "Country OriginalFullName X", "Country EnglishShortName X")} Movie Country Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Country OriginalFullName Y", "Country EnglishShortName Y")} Movie Country Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Country OriginalFullName Z", "Country EnglishShortName Z")} Movie Country Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Produktionsland",
                                   $"{formatter.AsInternalLink(pathInfo, "Country OriginalFullName X", "Country GermanShortName X")} Movie Country Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Country OriginalFullName Y", "Country GermanShortName Y")} Movie Country Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Country OriginalFullName Z", "Country GermanShortName Z")} Movie Country Details X3" }));
            }

            // InfoBox Language
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Language",
                                   $"{formatter.AsInternalLink(pathInfo, "Language OriginalName X", "Language EnglishName X")} Movie Language Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Language OriginalName Y", "Language EnglishName Y")} Movie Language Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Language OriginalName Z", "Language EnglishName Z")} Movie Language Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Sprache",
                                   $"{formatter.AsInternalLink(pathInfo, "Language OriginalName X", "Language GermanName X")} Movie Language Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Language OriginalName Y", "Language GermanName Y")} Movie Language Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Language OriginalName Z", "Language GermanName Z")} Movie Language Details X3" }));
            }

            // InfoBox Budget
            testContent.Add(formatter.AsTableRow(
                new string[] { "Budget",
                               "Movie Budget X" }));

            // InfoBox Worldwide Gross
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Worldwide Gross",
                                   $"Movie WorldwideGross X ({formatter.AsInternalLink(pathDate, "Movie WorldwideGrossDate X", "Movie WorldwideGrossDate X")})" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Einspielergebnis (weltweit)",
                                   $"Movie WorldwideGross X ({formatter.AsInternalLink(pathDate, "Movie WorldwideGrossDate X", "Movie WorldwideGrossDate X")})" }));
            }

            // InfoBox Runtime
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Runtime",
                                   $"11 min. ({formatter.AsInternalLink(pathInfo, "Edition EnglishTitle X", "Edition EnglishTitle X")}) Movie Runtime Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"12 min. ({formatter.AsInternalLink(pathInfo, "Edition EnglishTitle Y", "Edition EnglishTitle Y")}) Movie Runtime Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"13 min. ({formatter.AsInternalLink(pathInfo, "Edition EnglishTitle Z", "Edition EnglishTitle Z")}) Movie Runtime Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Laufzeit",
                                   $"11 min. ({formatter.AsInternalLink(pathInfo, "Edition EnglishTitle X", "Edition GermanTitle X")}) Movie Runtime Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"12 min. ({formatter.AsInternalLink(pathInfo, "Edition EnglishTitle Y", "Edition GermanTitle Y")}) Movie Runtime Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"13 min. ({formatter.AsInternalLink(pathInfo, "Edition EnglishTitle Z", "Edition GermanTitle Z")}) Movie Runtime Details X3" }));
            }

            // InfoBox SoundMix
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "SoundMix",
                                   $"{formatter.AsInternalLink(pathInfo, "SoundMix EnglishTitle X", "SoundMix EnglishTitle X")} Movie SoundMix Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "SoundMix EnglishTitle Y", "SoundMix EnglishTitle Y")} Movie SoundMix Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "SoundMix EnglishTitle Z", "SoundMix EnglishTitle Z")} Movie SoundMix Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Tonmischung",
                                   $"{formatter.AsInternalLink(pathInfo, "SoundMix EnglishTitle X", "SoundMix GermanTitle X")} Movie SoundMix Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "SoundMix EnglishTitle Y", "SoundMix GermanTitle Y")} Movie SoundMix Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "SoundMix EnglishTitle Z", "SoundMix GermanTitle Z")} Movie SoundMix Details X3" }));
            }

            // InfoBox Color
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Color",
                                   $"{formatter.AsInternalLink(pathInfo, "Color EnglishTitle X", "Color EnglishTitle X")} Movie Color Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Color EnglishTitle Y", "Color EnglishTitle Y")} Movie Color Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Color EnglishTitle Z", "Color EnglishTitle Z")} Movie Color Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Farbe",
                                   $"{formatter.AsInternalLink(pathInfo, "Color EnglishTitle X", "Color GermanTitle X")} Movie Color Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Color EnglishTitle Y", "Color GermanTitle Y")} Movie Color Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "Color EnglishTitle Z", "Color GermanTitle Z")} Movie Color Details X3" }));
            }

            // InfoBox AspectRatio
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Aspect Ratio",
                                   "AspectRatio Ratio X Movie AspectRatio Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   "AspectRatio Ratio Y Movie AspectRatio Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   "AspectRatio Ratio Z Movie AspectRatio Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Bildformat",
                                   "AspectRatio Ratio X Movie AspectRatio Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   "AspectRatio Ratio Y Movie AspectRatio Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   "AspectRatio Ratio Z Movie AspectRatio Details X3" }));
            }

            // InfoBox Camera
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Camera",
                                   "Camera Name X, Camera Lenses X Movie Camera Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   "Camera Name Y, Camera Lenses Y Movie Camera Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   "Camera Name Z, Camera Lenses Z Movie Camera Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Kamera",
                                   "Camera Name X, Camera Lenses X Movie Camera Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   "Camera Name Y, Camera Lenses Y Movie Camera Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   "Camera Name Z, Camera Lenses Z Movie Camera Details X3" }));
            }

            // InfoBox Laboratory
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Laboratory",
                                   "Laboratory Name X Movie Laboratory Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   "Laboratory Name Y Movie Laboratory Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   "Laboratory Name Z Movie Laboratory Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Labor",
                                   "Laboratory Name X Movie Laboratory Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   "Laboratory Name Y Movie Laboratory Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   "Laboratory Name Z Movie Laboratory Details X3" }));
            }

            // InfoBox FilmLength
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] {"Film Length",
                                  "Movie FilmLength Length X1 Movie FilmLength Details X1"}));
                testContent.Add(formatter.AsTableRow(
                    new string[] {formatter.CellSpanVertically(),
                                  "Movie FilmLength Length X2 Movie FilmLength Details X2"}));
                testContent.Add(formatter.AsTableRow(
                    new string[] {formatter.CellSpanVertically(),
                                  "Movie FilmLength Length X3 Movie FilmLength Details X3"}));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] {"Filmlänge",
                                  "Movie FilmLength Length X1 Movie FilmLength Details X1"}));
                testContent.Add(formatter.AsTableRow(
                    new string[] {formatter.CellSpanVertically(),
                                  "Movie FilmLength Length X2 Movie FilmLength Details X2"}));
                testContent.Add(formatter.AsTableRow(
                    new string[] {formatter.CellSpanVertically(),
                                  "Movie FilmLength Length X3 Movie FilmLength Details X3"}));
            }

            // InfoBox NegativeFormat
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] {"Negative Format",
                                  "FilmFormat Format X Movie NegativeFormat Details X1"}));
                testContent.Add(formatter.AsTableRow(
                    new string[] {formatter.CellSpanVertically(),
                                  "FilmFormat Format Y Movie NegativeFormat Details X2"}));
                testContent.Add(formatter.AsTableRow(
                    new string[] {formatter.CellSpanVertically(),
                                  "FilmFormat Format Z Movie NegativeFormat Details X3"}));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] {"Negativformat",
                                  "FilmFormat Format X Movie NegativeFormat Details X1"}));
                testContent.Add(formatter.AsTableRow(
                    new string[] {formatter.CellSpanVertically(),
                                  "FilmFormat Format Y Movie NegativeFormat Details X2"}));
                testContent.Add(formatter.AsTableRow(
                    new string[] {formatter.CellSpanVertically(),
                                  "FilmFormat Format Z Movie NegativeFormat Details X3"}));
            }

            // InfoBox CinematographicProcess
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Cinematographic Process",
                                   $"{formatter.AsInternalLink(pathInfo, "CinematographicProcess Name X", "CinematographicProcess Name X")} Movie CinematographicProcess Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "CinematographicProcess Name Y", "CinematographicProcess Name Y")} Movie CinematographicProcess Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "CinematographicProcess Name Z", "CinematographicProcess Name Z")} Movie CinematographicProcess Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] { "Filmprozess",
                                   $"{formatter.AsInternalLink(pathInfo, "CinematographicProcess Name X", "CinematographicProcess Name X")} Movie CinematographicProcess Details X1" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "CinematographicProcess Name Y", "CinematographicProcess Name Y")} Movie CinematographicProcess Details X2" }));
                testContent.Add(formatter.AsTableRow(
                    new string[] { formatter.CellSpanVertically(),
                                   $"{formatter.AsInternalLink(pathInfo, "CinematographicProcess Name Z", "CinematographicProcess Name Z")} Movie CinematographicProcess Details X3" }));
            }

            // InfoBox PrintedFilmFormat
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] {"Printed Film Format",
                                  "FilmFormat Format X Movie PrintedFilmFormat Details X1"}));
                testContent.Add(formatter.AsTableRow(
                    new string[] {formatter.CellSpanVertically(),
                                  "FilmFormat Format Y Movie PrintedFilmFormat Details X2"}));
                testContent.Add(formatter.AsTableRow(
                    new string[] {formatter.CellSpanVertically(),
                                  "FilmFormat Format Z Movie PrintedFilmFormat Details X3"}));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(
                    new string[] {"Filmformat",
                                  "FilmFormat Format X Movie PrintedFilmFormat Details X1"}));
                testContent.Add(formatter.AsTableRow(
                    new string[] {formatter.CellSpanVertically(),
                                  "FilmFormat Format Y Movie PrintedFilmFormat Details X2"}));
                testContent.Add(formatter.AsTableRow(
                    new string[] {formatter.CellSpanVertically(),
                                  "FilmFormat Format Z Movie PrintedFilmFormat Details X3"}));
            }

            // InfoBox End
            testContent.Add(formatter.EndBox());
            testContent.Add($"");
            testContent.Add($"");

            // Company Chapter
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsHeading2("Company Credits"));
            }
            else
            {
                testContent.Add(formatter.AsHeading2("Beteiligte Firmen"));
            }
            testContent.Add($"");

            // Production Company Section
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsHeading3("Production Companies"));
            }
            else
            {
                testContent.Add(formatter.AsHeading3("Produktionsfirmen"));
            }
            testContent.Add($"");

            testContent.Add(formatter.AsTableTitle(new string[] { null }));

            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")} (Movie ProductionCompany Role X1) Movie ProductionCompany Details X1" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")} (Movie ProductionCompany Role X2) Movie ProductionCompany Details X2" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")} (Movie ProductionCompany Role X3) Movie ProductionCompany Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")} (Movie ProductionCompany Role X1) Movie ProductionCompany Details X1" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")} (Movie ProductionCompany Role X2) Movie ProductionCompany Details X2" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")} (Movie ProductionCompany Role X3) Movie ProductionCompany Details X3" }));
            }
            testContent.Add($"");
            testContent.Add($"");

            // Distributor Section
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsHeading3("Distributors"));
            }
            else
            {
                testContent.Add(formatter.AsHeading3("Vertrieb"));
            }
            testContent.Add($"");

            testContent.Add(formatter.AsTableTitle(new string[] { null }));

            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")} ({formatter.AsInternalLink(pathDate, "Movie Distributor ReleaseDate X1")}) ({formatter.AsInternalLink(pathInfo, "Country OriginalFullName X", "Country EnglishShortName X")}) (Movie Distributor Role X1) Movie Distributor Details X1" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")} ({formatter.AsInternalLink(pathDate, "Movie Distributor ReleaseDate X2")}) ({formatter.AsInternalLink(pathInfo, "Country OriginalFullName X", "Country EnglishShortName X")}) (Movie Distributor Role X2) Movie Distributor Details X2" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")} ({formatter.AsInternalLink(pathDate, "Movie Distributor ReleaseDate X3")}) ({formatter.AsInternalLink(pathInfo, "Country OriginalFullName X", "Country EnglishShortName X")}) (Movie Distributor Role X3) Movie Distributor Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")} ({formatter.AsInternalLink(pathDate, "Movie Distributor ReleaseDate X1")}) ({formatter.AsInternalLink(pathInfo, "Country OriginalFullName X", "Country GermanShortName X")}) (Movie Distributor Role X1) Movie Distributor Details X1" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")} ({formatter.AsInternalLink(pathDate, "Movie Distributor ReleaseDate X2")}) ({formatter.AsInternalLink(pathInfo, "Country OriginalFullName X", "Country GermanShortName X")}) (Movie Distributor Role X2) Movie Distributor Details X2" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")} ({formatter.AsInternalLink(pathDate, "Movie Distributor ReleaseDate X3")}) ({formatter.AsInternalLink(pathInfo, "Country OriginalFullName X", "Country GermanShortName X")}) (Movie Distributor Role X3) Movie Distributor Details X3" }));
            }
            testContent.Add($"");
            testContent.Add($"");

            // Special Effects Company Section
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsHeading3("Special Effects Companies"));
            }
            else
            {
                testContent.Add(formatter.AsHeading3("Firmen für Spezialeffekte"));
            }
            testContent.Add($"");

            testContent.Add(formatter.AsTableTitle(new string[] { null }));

            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")} (Movie SpecialEffectsCompany Role X1) Movie SpecialEffectsCompany Details X1" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")} (Movie SpecialEffectsCompany Role X2) Movie SpecialEffectsCompany Details X2" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")} (Movie SpecialEffectsCompany Role X3) Movie SpecialEffectsCompany Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")} (Movie SpecialEffectsCompany Role X1) Movie SpecialEffectsCompany Details X1" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")} (Movie SpecialEffectsCompany Role X2) Movie SpecialEffectsCompany Details X2" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")} (Movie SpecialEffectsCompany Role X3) Movie SpecialEffectsCompany Details X3" }));
            }
            testContent.Add($"");
            testContent.Add($"");

            // Other Company Section
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsHeading3("Additional Companies"));
            }
            else
            {
                testContent.Add(formatter.AsHeading3("Weitere Firmen"));
            }
            testContent.Add($"");

            testContent.Add(formatter.AsTableTitle(new string[] { null }));

            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")} (Movie OtherCompany Role X1) Movie OtherCompany Details X1" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")} (Movie OtherCompany Role X2) Movie OtherCompany Details X2" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")} (Movie OtherCompany Role X3) Movie OtherCompany Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name X Company NameAddOn X")} (Movie OtherCompany Role X1) Movie OtherCompany Details X1" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name Y Company NameAddOn Y")} (Movie OtherCompany Role X2) Movie OtherCompany Details X2" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathCompany, "Company Name Z Company NameAddOn Z")} (Movie OtherCompany Role X3) Movie OtherCompany Details X3" }));
            }
            testContent.Add($"");
            testContent.Add($"");

            // Filming and Production Chapter
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsHeading2("Filming and Production"));
            }
            else
            {
                testContent.Add(formatter.AsHeading2("Produktion"));
            }
            testContent.Add($"");

            // Filming Location Section
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsHeading3("Filming Locations"));
            }
            else
            {
                testContent.Add(formatter.AsHeading3("Drehorte"));
            }
            testContent.Add($"");

            testContent.Add(formatter.AsTableTitle(new string[] { null }));

            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathInfo, "Location X")}, {formatter.AsInternalLink(pathInfo, "Country OriginalFullName X", "Country EnglishShortName X")} Movie FilmingLocation Details X1" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathInfo, "Location Y")}, {formatter.AsInternalLink(pathInfo, "Country OriginalFullName Y", "Country EnglishShortName Y")} Movie FilmingLocation Details X2" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathInfo, "Location Z")}, {formatter.AsInternalLink(pathInfo, "Country OriginalFullName Z", "Country EnglishShortName Z")} Movie FilmingLocation Details X3" }));
            }
            else
            {
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathInfo, "Location X")}, {formatter.AsInternalLink(pathInfo, "Country OriginalFullName X", "Country GermanShortName X")} Movie FilmingLocation Details X1" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathInfo, "Location Y")}, {formatter.AsInternalLink(pathInfo, "Country OriginalFullName Y", "Country GermanShortName Y")} Movie FilmingLocation Details X2" }));
                testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathInfo, "Location Z")}, {formatter.AsInternalLink(pathInfo, "Country OriginalFullName Z", "Country GermanShortName Z")} Movie FilmingLocation Details X3" }));
            }
            testContent.Add($"");
            testContent.Add($"");

            // Filming Dates Section
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsHeading3("Filming Dates"));
            }
            else
            {
                testContent.Add(formatter.AsHeading3("Drehdaten"));
            }
            testContent.Add($"");

            testContent.Add(formatter.AsTableTitle(new string[] { null }));
            testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathDate, "Movie FilmingDate StartDate X1")} - {formatter.AsInternalLink(pathDate, "Movie FilmingDate EndDate X1")} Movie FilmingDate Details X1" }));
            testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathDate, "Movie FilmingDate StartDate X2")} - {formatter.AsInternalLink(pathDate, "Movie FilmingDate EndDate X2")} Movie FilmingDate Details X2" }));
            testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathDate, "Movie FilmingDate StartDate X3")} - {formatter.AsInternalLink(pathDate, "Movie FilmingDate EndDate X3")} Movie FilmingDate Details X3" }));
            testContent.Add($"");
            testContent.Add($"");

            // Production Dates Section
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsHeading3("Production Dates"));
            }
            else
            {
                testContent.Add(formatter.AsHeading3("Produktionsdaten"));
            }
            testContent.Add($"");

            testContent.Add(formatter.AsTableTitle(new string[] { null }));
            testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathDate, "Movie ProductionDate StartDate X1")} - {formatter.AsInternalLink(pathDate, "Movie ProductionDate EndDate X1")} Movie ProductionDate Details X1" }));
            testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathDate, "Movie ProductionDate StartDate X2")} - {formatter.AsInternalLink(pathDate, "Movie ProductionDate EndDate X2")} Movie ProductionDate Details X2" }));
            testContent.Add(formatter.AsTableRow(new string[] { $"{formatter.AsInternalLink(pathDate, "Movie ProductionDate StartDate X3")} - {formatter.AsInternalLink(pathDate, "Movie ProductionDate EndDate X3")} Movie ProductionDate Details X3" }));
            testContent.Add($"");
            testContent.Add($"");

            // Connection Chapter
            if (targetLanguageCode.Equals("en"))
            {
                testContent.Add(formatter.AsHeading2("Connections to other articles"));
            }
            else
            {
                testContent.Add(formatter.AsHeading2("Bezüge zu anderen Artikeln"));
            }
            testContent.Add($"");

            testContent.Add(formatter.AsInsertPage(targetLanguageCode + ":navigation:_xxx"));

            // File Footer
            testContent.Add($"");
            testContent.Add($"");

            // Act
            List<string> content = creator.CreatePage();

            // Assert
            Assert.AreEqual(testContent.Count, content.Count);
            for (int i = 0; i < testContent.Count; i++)
            {
                Assert.AreEqual(testContent[i], content[i]);
            }
        }

        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        [ExpectedException(typeof(NotSupportedException))]
        public void CreateInfoBoxContentTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie entry = new Movie(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            MovieContentCreator creator = new MovieContentCreator(entry, formatter, targetLanguageCode);

            // Act, Assert
            creator.CreateInfoBoxContent();
        }

        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        [ExpectedException(typeof(NotSupportedException))]
        public void CreateChapterContentTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie entry = new Movie(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            MovieContentCreator creator = new MovieContentCreator(entry, formatter, targetLanguageCode);

            // Act, Assert
            creator.CreateChapterContent();
        }

        [DataTestMethod()]
        [DataRow(VALID_ID, "en")]
        [DataRow(VALID_ID, "de")]
        [DataRow(VALID_ID, "zz")]
        [DataRow(INVALID_ID, "en")]
        [DataRow(INVALID_ID, "de")]
        [DataRow(INVALID_ID, "zz")]
        [ExpectedException(typeof(NotSupportedException))]
        public void CreateSectionContentTest(string id, string targetLanguageCode)
        {
            // Arrange
            DBReader reader = new SQLiteReader();
            Movie entry = new Movie(reader, id);
            Formatter formatter = new DokuWikiFormatter();

            MovieContentCreator creator = new MovieContentCreator(entry, formatter, targetLanguageCode);

            // Act, Assert
            creator.CreateSectionContent();
        }
    }
}
