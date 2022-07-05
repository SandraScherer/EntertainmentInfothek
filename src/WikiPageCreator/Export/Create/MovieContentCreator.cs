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
using System;
using System.Collections.Generic;
using WikiPageCreator.Export.Format;

namespace WikiPageCreator.Export.Create
{
    /// <summary>
    /// Provides a content creator for a movie.
    /// </summary>
    public class MovieContentCreator : ArticleContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The movie to be used to create the content.
        /// </summary>
        public Movie Movie
        {
            get
            { return (Movie)Article; }
            protected set
            { Article = value; }
        }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new MovieContentCreator.
        /// </summary>
        /// <param name="movie">The movie to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public MovieContentCreator(Movie movie, Formatter formatter, string targetLanguageCode)
            : base(movie, formatter, targetLanguageCode)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"MovieContentCreator() angelegt");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the infobox content of a given movie.
        /// </summary>
        /// <returns>The formatted content of the movie.</returns>
        public override List<string> CreateInfoBoxContent()
        {
            Logger.Trace($"CreateInfoBoxContent() für Movie {Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            content.AddRange(CreateInfoBoxTitle());
            content.AddRange(CreateInfoBoxType());
            content.AddRange(CreateInfoBoxLogo());
            content.AddRange(CreateInfoBoxReleaseDate());
            content.AddRange(CreateInfoBoxGenre());
            content.AddRange(CreateInfoBoxCertification());
            content.AddRange(CreateInfoBoxCountry());
            content.AddRange(CreateInfoBoxLanguage());
            content.AddRange(CreateInfoBoxBudget());
            content.AddRange(CreateInfoBoxWorldwideGross());
            content.AddRange(CreateInfoBoxRuntime());
            content.AddRange(CreateInfoBoxSoundMix());
            content.AddRange(CreateInfoBoxColor());
            content.AddRange(CreateInfoBoxAspectRatio());
            content.AddRange(CreateInfoBoxCamera());
            content.AddRange(CreateInfoBoxLaboratory());
            content.AddRange(CreateInfoBoxFilmLength());
            content.AddRange(CreateInfoBoxNegativeFormat());
            content.AddRange(CreateInfoBoxCinematographicProcess());
            content.AddRange(CreateInfoBoxPrintedFilmFormat());

            Logger.Trace($"CreateInfoBoxContent() für Movie {Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted content of the movie.</returns>
        public override List<string> CreateChapterContent()
        {
            Logger.Trace($"CreateChapterContent() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            content.AddRange(CreateChapterPoster());
            content.AddRange(CreateChapterCover());
            content.AddRange(CreateChapterDescription());
            content.AddRange(CreateChapterReview());
            content.AddRange(CreateChapterImage());
            content.AddRange(CreateChapterCastAndCrew());
            content.AddRange(CreateChapterCompany());
            content.AddRange(CreateChapterFilmingAndProduction());
            content.AddRange(CreateChapterAward());
            content.AddRange(CreateChapterWeblink());
            content.AddRange(CreateChapterConnection());

            Logger.Trace($"CreateChapterContent() für Movie {Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the section content of a given movie.
        /// </summary>
        /// <returns>The formatted section content of the movie.</returns>
        public override List<string> CreateSectionContent()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates the formatted infobox logo content of a given movie.
        /// </summary>
        /// <returns>The formatted infobox logo content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxLogo()
        {
            Logger.Trace($"CreateInfoBoxReleaseDate() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            if (Movie.Logo != null)
            {
                // TODO: implement following stuff
                //content.AddRange(new ImageContentCreator(Movie.Logo, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxReleaseDate() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox genre content of a given movie.
        /// </summary>
        /// <returns>The formatted infobox genre content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxGenre()
        {
            Logger.Trace($"CreateInfoBoxGenre() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            if (Movie.Genres != null)
            {
                //TODO: implement following stuff
                //content.AddRange(new GenreContentCreator(Movie.Genres, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxGenre() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox certification content of a given movie.
        /// </summary>
        /// <returns>The formatted infobox certification content of the movie.</returns>
        protected virtual List<string> CreateInfoBoxCertification()
        {
            Logger.Trace($"CreateInfoBoxCertification() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            if (Movie.Certifications != null)
            {
                //TODO: implement following stuff
                //content.AddRange(new CertificationContentCreator(Movie.Certifications, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxCertification() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox country content of a given movie.
        /// </summary>
        /// <returns>The formatted infobox country content of the movie.</returns>
        protected virtual List<string> CreateInfoBoxCountry()
        {
            Logger.Trace($"CreateInfoBoxCountry() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            if (Movie.Countries != null)
            {
                //TODO: implement following stuff
                //content.AddRange(new CountryContentCreator(Movie.Countries, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxCountry() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox language content of a given movie.
        /// </summary>
        /// <returns>The formatted infobox language content of the movie.</returns>
        protected virtual List<string> CreateInfoBoxLanguage()
        {
            Logger.Trace($"CreateInfoBoxLanguage() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            if (Movie.Languages != null)
            {
                //TODO: implement following stuff
                //content.AddRange(new LanguageContentCreator(Movie.Languages, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxLanguage() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox budget content of a given movie.
        /// </summary>
        /// <returns>The formatted infobox budget content of the movie.</returns>
        protected virtual List<string> CreateInfoBoxBudget()
        {
            Logger.Trace($"CreateInfoBoxBudget() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];

            if (!String.IsNullOrEmpty(Movie.Budget))
            {
                Logger.Trace($"Budget: {Movie.Budget}");
                data[0] = "Budget";
                data[1] = $"{Movie.Budget}";

                content.Add(Formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxBudget() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox worldwide gross content of a given movie.
        /// </summary>
        /// <returns>The formatted infobox worldwide gross content of the movie.</returns>
        protected virtual List<string> CreateInfoBoxWorldwideGross()
        {
            Logger.Trace($"CreateInfoBoxWorldwideGross() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];
            string[] path = { TargetLanguageCode, "date" };

            if (!String.IsNullOrEmpty(Movie.WorldwideGross))
            {
                Logger.Trace($"Worldwide Gross: {Movie.WorldwideGross}");

                if (TargetLanguageCode.Equals("en"))
                {
                    data[0] = "Worldwide Gross";
                }
                else //incl. case "de"
                {
                    data[0] = "Einspielergebnis (weltweit)";
                }

                if (!String.IsNullOrEmpty(Movie.WorldwideGrossDate))
                {
                    data[1] = $"{Movie.WorldwideGross} ({Formatter.AsInternalLink(path, Movie.WorldwideGrossDate, Movie.WorldwideGrossDate)})";
                }
                else
                {
                    data[1] = $"{Movie.WorldwideGross}";
                }
                content.Add(Formatter.AsTableRow(data));
            }
            Logger.Trace($"CreateInfoBoxWorldwideGross() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox runtime content of a given movie.
        /// </summary>
        /// <returns>The formatted infobox runtime content of the movie.</returns>
        protected virtual List<string> CreateInfoBoxRuntime()
        {
            Logger.Trace($"CreateInfoBoxRuntime() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            if (Movie.Runtimes != null)
            {
                //TODO: implement following stuff
                //content.AddRange(new RuntimeContentCreator(Movie.Runtimes, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxRuntime() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox soundmix content of a given movie.
        /// </summary>
        /// <returns>The formatted infobox soundmix content of the movie.</returns>
        protected virtual List<string> CreateInfoBoxSoundMix()
        {
            Logger.Trace($"CreateInfoBoxSoundMix() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            if (Movie.SoundMixes != null)
            {
                //TODO: implement following stuff
                //content.AddRange(new SoundMixContentCreator(Movie.SoundMixes, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxSoundMix() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox color content of a given movie.
        /// </summary>
        /// <returns>The formatted infobox color content of the movie.</returns>
        protected virtual List<string> CreateInfoBoxColor()
        {
            Logger.Trace($"CreateInfoBoxColor() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            if (Movie.Colors != null)
            {
                //TODO: implement following stuff
                //content.AddRange(new ColorContentCreator(Movie.Colors, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxColor() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox aspect ratio content of a given movie.
        /// </summary>
        /// <returns>The formatted infobox aspect ratio content of the movie.</returns>
        protected virtual List<string> CreateInfoBoxAspectRatio()
        {
            Logger.Trace($"CreateInfoBoxAspectRatio() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            if (Movie.AspectRatios != null)
            {
                //TODO: implement following stuff
                //content.AddRange(new AspectRatioContentCreator(Movie.AspectRatios, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxAspectRatio() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox camera content of a given movie.
        /// </summary>
        /// <returns>The formatted infobox camera content of the movie.</returns>
        protected virtual List<string> CreateInfoBoxCamera()
        {
            Logger.Trace($"CreateInfoBoxCamera() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            if (Movie.Cameras != null)
            {
                //TODO: implement following stuff
                //content.AddRange(new CameraContentCreator(Movie.Cameras, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxCamera() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox laboratory content of a given movie.
        /// </summary>
        /// <returns>The formatted infobox laboratory content of the movie.</returns>
        protected virtual List<string> CreateInfoBoxLaboratory()
        {
            Logger.Trace($"CreateInfoBoxLaboratory() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            if (Movie.Laboratories != null)
            {
                //TODO: implement following stuff
                ////content.AddRange(new LaboratoryContentCreator(Movie.Laboratories, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxLaboratory() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox film length content of a given movie.
        /// </summary>
        /// <returns>The formatted infobox film length content of the movie.</returns>
        protected virtual List<string> CreateInfoBoxFilmLength()
        {
            Logger.Trace($"CreateInfoBoxFilmLength() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            if (Movie.FilmLengths != null)
            {
                //TODO: implement following stuff
                //content.AddRange(new FilmLengthContentCreator(Movie.FilmLengths, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxFilmLength() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox negative format content of a given movie.
        /// </summary>
        /// <returns>The formatted infobox negative format content of the movie.</returns>
        protected virtual List<string> CreateInfoBoxNegativeFormat()
        {
            Logger.Trace($"CreateInfoBoxNegativeFormat() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            if (Movie.NegativeFormats != null)
            {
                //TODO: implement following stuff
                //content.AddRange(new NegativeFormatContentCreator(Movie.NegativeFormats, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxNegativeFormat() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox cinematographic process content of a given movie.
        /// </summary>
        /// <returns>The formatted infobox cinematographic process content of the movie.</returns>
        protected virtual List<string> CreateInfoBoxCinematographicProcess()
        {
            Logger.Trace($"CreateInfoBoxCinematographicProcess() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            if (Movie.CinematographicProcesses != null)
            {
                //TODO: implement following stuff
                //content.AddRange(new CinematographicProcessContentCreator(Movie.CinematographicProcesses, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxCinematographicProcess() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox printed film format content of a given movie.
        /// </summary>
        /// <returns>The formatted infobox printed film format content of the movie.</returns>
        protected virtual List<string> CreateInfoBoxPrintedFilmFormat()
        {
            Logger.Trace($"CreateInfoBoxPrintedFilmFormat() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            if (Movie.PrintedFilmFormats != null)
            {
                //TODO: implement following stuff
                //content.AddRange(new PrintedFilmFormatsContentCreator(Movie.PrintedFilmFormats, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxPrintedFilmFormat() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted poster chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted poster chapter content of the movie.</returns>
        protected virtual List<string> CreateChapterPoster()
        {
            Logger.Trace($"CreateChapterPoster() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Poster");
            title.Add("de", "Poster");

            if (Movie.Posters != null)
            {
                // TODO: implement following stuff
                //content.AddRange(CreateNewChapter(title));
                //content.AddRange(new ImageContentCreator(Movie.Posters, Formatter, TargetLanguageCode).CreateChapterContent());
            }

            Logger.Trace($"CreateChapterPoster() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted cover chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted cover chapter content of the movie.</returns>
        protected virtual List<string> CreateChapterCover()
        {
            Logger.Trace($"CreateChapterCover() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Cover");
            title.Add("de", "Cover");

            if (Movie.Covers != null)
            {
                // TODO: implement following stuff
                //content.AddRange(CreateNewChapter(title));
                //content.AddRange(new ImageContentCreator(Movie.Covers, Formatter, TargetLanguageCode).CreateChapterContent());
            }

            Logger.Trace($"CreateChapterCover() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted description chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted description chapter content of the movie.</returns>
        protected virtual List<string> CreateChapterDescription()
        {
            Logger.Trace($"CreateChapterDescription() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Descriptions");
            title.Add("de", "Beschreibungen");

            if (Movie.Descriptions != null)
            {
                //TODO: implement following stuff
                //content.AddRange(CreateNewChapter(title));
                //content.AddRange(new TextContentCreator(Movie.Descriptions, Formatter, TargetLanguageCode).CreateChapterContent());
            }

            Logger.Trace($"CreateChapterDescription() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted review chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted review chapter content of the movie.</returns>
        protected virtual List<string> CreateChapterReview()
        {
            Logger.Trace($"CreateChapterReview() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Reviews");
            title.Add("de", "Rezensionen");

            if (Movie.Reviews != null)
            {
                //TODO: implement following stuff
                //content.AddRange(CreateNewChapter(title));
                //content.AddRange(new TextContentCreator(Movie.Reviews, Formatter, TargetLanguageCode).CreateChapterContent());
            }

            Logger.Trace($"CreateChapterReview() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted image chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted image chapter content of the movie.</returns>
        protected virtual List<string> CreateChapterImage()
        {
            Logger.Trace($"CreateChapterImage() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Images");
            title.Add("de", "Bilder");

            if (Movie.Images != null)
            {
                // TODO: implement following stuff
                //content.AddRange(CreateNewChapter(title));
                //content.AddRange(new ImageContentCreator(Movie.Images, Formatter, TargetLanguageCode).CreateChapterContent());
            }

            Logger.Trace($"CreateChapterImage() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted cast and crew chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted cast and crew chapter content of the movie.</returns>
        protected virtual List<string> CreateChapterCastAndCrew()
        {
            Logger.Trace($"CreateChapterCastAndCrew() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Cast and Crew");
            title.Add("de", "Darsteller und Mannschaft");

            // TODO: implement following stuff
            //content.AddRange(CreateNewChapter(title));

            //Dictionary<string, string> titleSection = new Dictionary<string, string>();

            //if (Movie.Directors != null)
            //{
            //    titleSection.Add("en", "Director");
            //    titleSection.Add("de", "Regie");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new PersonContentCreator(Movie.Directors, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            //if (Movie.Writers != null)
            //{
            //    titleSection.Add("en", "Writers");
            //    titleSection.Add("de", "Drehbuch");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new PersonContentCreator(Movie.Writers, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            // TODO: add more cast and crew sections

            Logger.Trace($"CreateChapterCastAndCrew() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted company chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted company chapter content of the movie.</returns>
        protected virtual List<string> CreateChapterCompany()
        {
            Logger.Trace($"CreateChapterCompany() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Company Credits");
            title.Add("de", "Beteiligte Firmen");

            // TODO: implement following stuff
            //content.AddRange(CreateNewChapter(title));

            //Dictionary<string, string> titleSection = new Dictionary<string, string>();

            //if (Movie.Directors != null)
            //{
            //    titleSection.Add("en", "Production Company");
            //    titleSection.Add("de", "Produktionsfirmen");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new CompanyContentCreator(Movie.ProductionCompanies, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            //if (Movie.Writers != null)
            //{
            //    titleSection.Add("en", "Distributors");
            //    titleSection.Add("de", "Vertrieb");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new CompanyContentCreator(Movie.Distributors, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            // TODO: add more cast and crew sections

            Logger.Trace($"CreateChapterCompany() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted filming and production chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted filming and production chapter content of the movie.</returns>
        protected virtual List<string> CreateChapterFilmingAndProduction()
        {
            Logger.Trace($"CreateChapterFilmingAndProduction() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Filming and Production");
            title.Add("de", "Produktion");

            // TODO: implement following stuff
            //content.AddRange(CreateNewChapter(title));

            //Dictionary<string, string> titleSection = new Dictionary<string, string>();

            //if (Movie.FilmingLocations != null)
            //{
            //    titleSection.Add("en", "Filming Locations");
            //    titleSection.Add("de", "Drehorte");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new LocationContentCreator(Movie.FilmingLocations, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            //if (Movie.FilmingDates != null)
            //{
            //    titleSection.Add("en", "Filming Dates");
            //    titleSection.Add("de", "");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new TimeSpanContentCreator(Movie.FilmingDates, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            //if (Movie.ProductionDates != null)
            //{
            //    titleSection.Add("en", "Production Dates");
            //    titleSection.Add("de", "");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new TimeSpanContentCreator(Movie.ProductionDates, Formatter, TargetLanguageCode).CreateSectionContent());
            //}

            Logger.Trace($"CreateChapterFilmingAndProduction() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted award chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted award chapter content of the movie.</returns>
        protected virtual List<string> CreateChapterAward()
        {
            Logger.Trace($"CreateChapterAward() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Awards");
            title.Add("de", "Auszeichnungen");

            if (Movie.Awards != null)
            {
                // TODO: implement following stuff
                //content.AddRange(CreateNewChapter(title));
                //content.AddRange(new AwardContentCreator(Movie.Awards, Formatter, TargetLanguageCode).CreateChapterContent());
            }

            Logger.Trace($"CreateChapterAward() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted weblink chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted weblink chapter content of the movie.</returns>
        protected virtual List<string> CreateChapterWeblink()
        {
            Logger.Trace($"CreateChapterWeblink() für Movie '{Movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Other Sites");
            title.Add("de", "Andere Webseiten");

            if (Movie.Weblinks != null)
            {
                // TODO: implement following stuff
                //content.AddRange(CreateNewChapter(title));
                //content.AddRange(new WeblinkContentCreator(Movie.Weblinks, Formatter, TargetLanguageCode).CreateChapterContent());
            }

            Logger.Trace($"CreateChapterWeblink() für Movie '{Movie.OriginalTitle}' beendet");

            return content;
        }
    }
}
