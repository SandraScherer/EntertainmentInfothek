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
    public class MovieContentCreator : MovieAndTVArticleContentCreator
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
            Logger.Trace($"MovieContentCreator()");

            if (movie == null)
            {
                Logger.Fatal($"Movie not specified");
                throw new ArgumentNullException(nameof(movie));
            }
            if (formatter == null)
            {
                Logger.Fatal($"Formatter not specified");
                throw new ArgumentNullException(nameof(formatter));
            }
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"MovieContentCreator(): MovieContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the page content of the movie.
        /// </summary>
        /// <returns>The formatted page content of the movie.</returns>
        protected override List<string> CreatePageContent()
        {
            Logger.Trace($"CreatePageContent()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            List<string> content = new List<string>();

            content.AddRange(CreateInfoBoxBegin());
            content.AddRange(CreateInfoBoxContentInternal());
            content.AddRange(CreateInfoBoxEnd());

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

            Logger.Trace($"CreatePageContent(): page content for Movie '{Movie.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the infobox content of a given movie.
        /// </summary>
        /// <returns>The formatted content of the movie.</returns>
        protected virtual List<string> CreateInfoBoxContentInternal()
        {
            Logger.Trace($"CreateInfoBoxContentInternal()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            List<string> content = new List<string>();

            content.AddRange(CreateInfoBoxContentTitle());
            content.AddRange(CreateInfoBoxContentType());
            content.AddRange(CreateInfoBoxContentLogo());
            content.AddRange(CreateInfoBoxContentReleaseDate());
            content.AddRange(CreateInfoBoxContentGenre());
            content.AddRange(CreateInfoBoxContentCertification());
            content.AddRange(CreateInfoBoxContentCountry());
            content.AddRange(CreateInfoBoxContentLanguage());
            content.AddRange(CreateInfoBoxContentBudget());
            content.AddRange(CreateInfoBoxContentWorldwideGross());
            content.AddRange(CreateInfoBoxContentRuntime());
            content.AddRange(CreateInfoBoxContentSoundMix());
            content.AddRange(CreateInfoBoxContentColor());
            content.AddRange(CreateInfoBoxContentAspectRatio());
            content.AddRange(CreateInfoBoxContentCamera());
            content.AddRange(CreateInfoBoxContentLaboratory());
            content.AddRange(CreateInfoBoxContentFilmLength());
            content.AddRange(CreateInfoBoxContentNegativeFormat());
            content.AddRange(CreateInfoBoxContentCinematographicProcess());
            content.AddRange(CreateInfoBoxContentPrintedFilmFormat());

            Logger.Trace($"CreateInfoBoxContentInternal(): info box content for Movie '{Movie.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox logo content of a given movie.
        /// </summary>
        /// <returns>The formatted infobox logo content of the movie.</returns>
        protected virtual List<string> CreateInfoBoxContentLogo()
        {
            Logger.Trace($"CreateInfoBoxContentLogo()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            List<string> content = new List<string>();

            if (Movie.Logo != null)
            {
                Logger.Debug($"Movie.Logo is not null -> create");

                // TODO: implement following stuff
                //content.AddRange(new ImageContentCreator(Movie.Logo, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxContentLogo(): infobox content logo for Movie '{Movie.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted poster chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted poster chapter content of the movie.</returns>
        protected virtual List<string> CreateChapterPoster()
        {
            Logger.Trace($"CreateChapterPoster()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Poster");
            title.Add("de", "Poster");

            if (Movie.Posters != null)
            {
                Logger.Debug($"Movie.Posters is not null -> create");

                // TODO: implement following stuff
                //content.AddRange(CreateChapterHeading(title));
                //content.AddRange(new ImageContentCreator(Movie.Posters, Formatter, TargetLanguageCode).CreateChapterContent());
            }

            Logger.Trace($"CreateChapterPoster(): chapter poster for Movie '{Movie.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted cover chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted cover chapter content of the movie.</returns>
        protected virtual List<string> CreateChapterCover()
        {
            Logger.Trace($"CreateChapterCover()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Cover");
            title.Add("de", "Cover");

            if (Movie.Covers != null)
            {
                Logger.Debug($"Movie.Covers is not null -> create");

                // TODO: implement following stuff
                //content.AddRange(CreateChapterHeading(title));
                //content.AddRange(new ImageContentCreator(Movie.Covers, Formatter, TargetLanguageCode).CreateChapterContent());
            }

            Logger.Trace($"CreateChapterCover(): chapter cover for Movie '{Movie.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted description chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted description chapter content of the movie.</returns>
        protected virtual List<string> CreateChapterDescription()
        {
            Logger.Trace($"CreateChapterDescription()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Descriptions");
            title.Add("de", "Beschreibungen");

            if (Movie.Descriptions != null)
            {
                Logger.Debug($"Movie.Descriptions is not null -> create");

                //TODO: implement following stuff
                //content.AddRange(CreateChapterHeading(title));
                //content.AddRange(new TextContentCreator(Movie.Descriptions, Formatter, TargetLanguageCode).CreateChapterContent());
            }

            Logger.Trace($"CreateChapterDescription(): chapter descriptions for Movie '{Movie.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted review chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted review chapter content of the movie.</returns>
        protected virtual List<string> CreateChapterReview()
        {
            Logger.Trace($"CreateChapterReview()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Reviews");
            title.Add("de", "Rezensionen");

            if (Movie.Reviews != null)
            {
                Logger.Debug($"Movie.Reviews is not null -> create");

                //TODO: implement following stuff
                //content.AddRange(CreateChapterHeading(title));
                //content.AddRange(new TextContentCreator(Movie.Reviews, Formatter, TargetLanguageCode).CreateChapterContent());
            }

            Logger.Trace($"CreateChapterReview(): chapter reviews for Movie '{Movie.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted image chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted image chapter content of the movie.</returns>
        protected virtual List<string> CreateChapterImage()
        {
            Logger.Trace($"CreateChapterImage()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Images");
            title.Add("de", "Bilder");

            if (Movie.Images != null)
            {
                Logger.Debug($"Movie.Images is not null -> create");

                // TODO: implement following stuff
                //content.AddRange(CreateChapterHeading(title));
                //content.AddRange(new ImageContentCreator(Movie.Images, Formatter, TargetLanguageCode).CreateChapterContent());
            }

            Logger.Trace($"CreateChapterImage(): chapter images for Movie '{Movie.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted cast and crew chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted cast and crew chapter content of the movie.</returns>
        protected virtual List<string> CreateChapterCastAndCrew()
        {
            Logger.Trace($"CreateChapterCastAndCrew()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Cast and Crew");
            title.Add("de", "Darsteller und Mannschaft");

            // TODO: implement following stuff
            //content.AddRange(CreateChapterHeading(title));

            //Dictionary<string, string> titleSection = new Dictionary<string, string>();

            //if (Movie.Directors != null)
            //{
            //    Logger.Debug($"Movie.Directors is not null -> create");
            //    titleSection.Add("en", "Director");
            //    titleSection.Add("de", "Regie");
            //    content.AddRange(CreateSectionHeading(titleSection));
            //    content.AddRange(new PersonContentCreator(Movie.Directors, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            //if (Movie.Writers != null)
            //{
            //    Logger.Debug($"Movie.Writers is not null -> create");
            //    titleSection.Add("en", "Writers");
            //    titleSection.Add("de", "Drehbuch");
            //    content.AddRange(CreateSectionHeading(titleSection));
            //    content.AddRange(new PersonContentCreator(Movie.Writers, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            // TODO: add more cast and crew sections

            Logger.Trace($"CreateChapterCastAndCrew(): chapter cast and crew for Movie '{Movie.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted company chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted company chapter content of the movie.</returns>
        protected virtual List<string> CreateChapterCompany()
        {
            Logger.Trace($"CreateChapterCompany()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Company Credits");
            title.Add("de", "Beteiligte Firmen");

            // TODO: implement following stuff
            //content.AddRange(CreateChapterHeading(title));

            //Dictionary<string, string> titleSection = new Dictionary<string, string>();

            //if (Movie.ProductionCompanies != null)
            //{
            //    Logger.Debug($"Movie.ProductionCompanies is not null -> create");
            //    titleSection.Add("en", "Production Company");
            //    titleSection.Add("de", "Produktionsfirmen");
            //    content.AddRange(CreateSectionHeading(titleSection));
            //    content.AddRange(new CompanyContentCreator(Movie.ProductionCompanies, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            //if (Movie.Distributors != null)
            //{
            //    Logger.Debug($"Movie.Distributors is not null -> create");
            //    titleSection.Add("en", "Distributors");
            //    titleSection.Add("de", "Vertrieb");
            //    content.AddRange(CreateSectionHeading(titleSection));
            //    content.AddRange(new CompanyContentCreator(Movie.Distributors, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            // TODO: add more company sections

            Logger.Trace($"CreateChapterCompany(): chapter companies for Movie '{Movie.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted award chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted award chapter content of the movie.</returns>
        protected virtual List<string> CreateChapterAward()
        {
            Logger.Trace($"CreateChapterAward()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Awards");
            title.Add("de", "Auszeichnungen");

            if (Movie.Awards != null)
            {
                Logger.Debug($"Movie.Awards is not null -> create");

                // TODO: implement following stuff
                //content.AddRange(CreateChapterHeading(title));
                //content.AddRange(new AwardContentCreator(Movie.Awards, Formatter, TargetLanguageCode).CreateChapterContent());
            }

            Logger.Trace($"CreateChapterAward(): chapter awards for Movie '{Movie.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted weblink chapter content of a given movie.
        /// </summary>
        /// <returns>The formatted weblink chapter content of the movie.</returns>
        protected virtual List<string> CreateChapterWeblink()
        {
            Logger.Trace($"CreateChapterWeblink()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Other Sites");
            title.Add("de", "Andere Webseiten");

            if (Movie.Weblinks != null)
            {
                Logger.Debug($"Movie.Weblinks is not null -> create");

                // TODO: implement following stuff
                //content.AddRange(CreateChapterHeading(title));
                //content.AddRange(new WeblinkContentCreator(Movie.Weblinks, Formatter, TargetLanguageCode).CreateChapterContent());
            }

            Logger.Trace($"CreateChapterWeblink(): chapter weblinks for Movie '{Movie.OriginalTitle}' created");

            return content;
        }
    }
}
