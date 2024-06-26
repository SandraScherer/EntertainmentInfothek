﻿// WikiPageCreator.exe: Creates pages for use with a wiki from the
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
    /// Provides a content creator for a series.
    /// </summary>
    public class SeriesContentCreator : MovieAndTVArticleContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The series to be used to create the content.
        /// </summary>
        public Series Series
        {
            get
            { return (Series)Article; }
            protected set
            { Article = value; }
        }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new SeriesContentCreator.
        /// </summary>
        /// <param name="series">The series to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public SeriesContentCreator(Series series, Formatter formatter, string targetLanguageCode)
            : base(series, formatter, targetLanguageCode)
        {
            Logger.Trace($"SeriesContentCreator(): SeriesContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the page content of the movie.
        /// </summary>
        /// <returns>The formatted page content of the movie.</returns>
        protected override List<string> CreatePageContent()
        {
            Logger.Trace($"CreatePageContent()");
            Logger.Debug($"Series is '{Series.OriginalTitle}'");

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

            Logger.Trace($"CreatePageContent(): page content for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the infobox content of a given series.
        /// </summary>
        /// <returns>The formatted content of the series.</returns>
        protected virtual List<string> CreateInfoBoxContentInternal()
        {
            Logger.Trace($"CreateInfoBoxContentInternal()");
            Logger.Debug($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();

            content.AddRange(CreateInfoBoxContentTitle());
            content.AddRange(CreateInfoBoxContentType());
            content.AddRange(CreateInfoBoxContentLogo());
            content.AddRange(CreateInfoBoxContentReleaseDateFirstEpisode());
            content.AddRange(CreateInfoBoxContentReleaseDateLastEpisode());
            content.AddRange(CreateInfoBoxContentGenre());
            content.AddRange(CreateInfoBoxContentCertification());
            content.AddRange(CreateInfoBoxContentCountry());
            content.AddRange(CreateInfoBoxContentLanguage());
            content.AddRange(CreateInfoBoxContentNoOfSeasons());
            content.AddRange(CreateInfoBoxContentNoOfEpisodes());
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

            Logger.Trace($"CreateInfoBoxContentInternal(): infobox content for  Series {Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox logo content of a given series.
        /// </summary>
        /// <returns>The formatted infobox logo content of the series.</returns>
        protected virtual List<string> CreateInfoBoxContentLogo()
        {
            Logger.Trace($"CreateInfoBoxContentLogo()");
            Logger.Debug($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (Series.Logo != null)
            //{
            //    Logger.Debug($"Series.Logo is not null -> create");
            //    content.AddRange(new ImageContentCreator(Series.Logo, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxContentLogo(): infobox content logo for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox release date content of a given series.
        /// </summary>
        /// <returns>The formatted infobox release date content of the series.</returns>
        protected virtual List<string> CreateInfoBoxContentReleaseDateFirstEpisode()
        {
            Logger.Trace($"CreateInfoBoxContentReleaseDateFirstEpisode()");
            Logger.Debug($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            string[] data = new string[2];
            string[] path = { TargetLanguageCode, "date" };

            if (!String.IsNullOrEmpty(Series.ReleaseDateFirstEpisode))
            {
                Logger.Debug($"Series.ReleaseDateFirstEpisode is not null");

                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"ReleaseDate (First Episode): '{Series.ReleaseDateFirstEpisode}' (english)");
                    data[0] = "Release Date (First Episode)";
                    data[1] = Formatter.AsInternalLink(path, Series.ReleaseDateFirstEpisode, Series.ReleaseDateFirstEpisode);
                }
                else // incl. case "de"
                {
                    Logger.Debug($"ReleaseDate (First Episode): '{Series.ReleaseDateFirstEpisode}' (german, ...)");
                    data[0] = "Erstausstrahlung (Erste Folge)";
                    data[1] = Formatter.AsInternalLink(path, Series.ReleaseDateFirstEpisode, Series.ReleaseDateFirstEpisode);
                }
                content.Add(Formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxContentReleaseDateFirstEpisode(): infobox content release date of first episode for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox release date content of a given series.
        /// </summary>
        /// <returns>The formatted infobox release date content of the series.</returns>
        protected virtual List<string> CreateInfoBoxContentReleaseDateLastEpisode()
        {
            Logger.Trace($"CreateInfoBoxContentReleaseDateLastEpisode()");
            Logger.Debug($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            string[] data = new string[2];
            string[] path = { TargetLanguageCode, "date" };

            if (!String.IsNullOrEmpty(Series.ReleaseDateLastEpisode))
            {
                Logger.Debug($"Series.ReleaseDateLastEpisode is not null");

                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Trace($"ReleaseDate (Last Episode): '{Series.ReleaseDateLastEpisode}' (english)");
                    data[0] = "Release Date (Last Episode)";
                    data[1] = Formatter.AsInternalLink(path, Series.ReleaseDateLastEpisode, Series.ReleaseDateLastEpisode);
                }
                else // incl. case "de"
                {
                    Logger.Trace($"ReleaseDate (Last Episode): '{Series.ReleaseDateLastEpisode}' (german, ...)");
                    data[0] = "Erstausstrahlung (Letzte Folge)";
                    data[1] = Formatter.AsInternalLink(path, Series.ReleaseDateLastEpisode, Series.ReleaseDateLastEpisode);
                }
                content.Add(Formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxContentReleaseDateLastEpisode(): infobox content release date of last episode for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox language content of a given series.
        /// </summary>
        /// <returns>The formatted infobox language content of the series.</returns>
        protected virtual List<string> CreateInfoBoxContentNoOfSeasons()
        {
            Logger.Trace($"CreateInfoBoxContentNoOfSeasons()");
            Logger.Debug($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            string[] data = new string[2];

            if (!String.IsNullOrEmpty(Series.NoOfSeasons))
            {
                Logger.Debug($"Series.NoOfSeasons is not null or empty");

                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Trace($"NoOfSeasons: '{Series.NoOfSeasons}' (english)");
                    data[0] = "# Seasons";
                    data[1] = Series.NoOfSeasons;
                }
                else // incl. case "de"
                {
                    Logger.Trace($"NoOfSeasons: '{Series.NoOfSeasons}' (german, ...)");
                    data[0] = "# Staffeln";
                    data[1] = Series.NoOfSeasons;
                }
                content.Add(Formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxContentNoOfSeasons(): infobox content no of seasons for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox language content of a given series.
        /// </summary>
        /// <returns>The formatted infobox language content of the series.</returns>
        protected virtual List<string> CreateInfoBoxContentNoOfEpisodes()
        {
            Logger.Trace($"CreateInfoBoxContentNoOfEpisodes()");
            Logger.Debug($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            string[] data = new string[2];

            if (!String.IsNullOrEmpty(Series.NoOfEpisodes))
            {
                Logger.Debug($"Series.NoOfEpisodes is not null or empty");

                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Trace($"NoOfEpisodes: '{Series.NoOfEpisodes}' (english)");
                    data[0] = "# Episodes";
                    data[1] = Series.NoOfEpisodes;
                }
                else // incl. case "de"
                {
                    Logger.Trace($"NoOfEpisodes: '{Series.NoOfEpisodes}' (german, ...)");
                    data[0] = "# Folgen";
                    data[1] = Series.NoOfEpisodes;
                }
                content.Add(Formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxContentNoOfEpisodes(): infobox content no of episodes for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted poster chapter content of a given series.
        /// </summary>
        /// <returns>The formatted poster chapter content of the series.</returns>
        protected virtual List<string> CreateChapterPoster()
        {
            Logger.Trace($"CreateChapterPoster()");
            Logger.Debug($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Poster");
            title.Add("de", "Poster");

            // TODO: implement following stuff
            //if (Series.Posters != null)
            //{
            //    Logger.Debug($"Series.Posters is not null -> create");
            //    content.AddRange(CreateChapterHeading(title));
            //    content.AddRange(new ImageContentCreator(Series.Posters, Formatter, TargetLanguageCode).CreateChapterContent());
            //}

            Logger.Trace($"CreateChapterPoster(): chapter poster for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted cover chapter content of a given series.
        /// </summary>
        /// <returns>The formatted cover chapter content of the series.</returns>
        protected virtual List<string> CreateChapterCover()
        {
            Logger.Trace($"CreateChapterCover()");
            Logger.Debug($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Cover");
            title.Add("de", "Cover");

            // TODO: implement following stuff
            //if (Series.Covers != null)
            //{
            //    Logger.Debug($"Series.Covers is not null -> create");
            //    content.AddRange(CreateChapterHeading(title));
            //    content.AddRange(new ImageContentCreator(Series.Covers, Formatter, TargetLanguageCode).CreateChapterContent());
            //}

            Logger.Trace($"CreateChapterCover(): chapter cover for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted description chapter content of a given series.
        /// </summary>
        /// <returns>The formatted description chapter content of the series.</returns>
        protected virtual List<string> CreateChapterDescription()
        {
            Logger.Trace($"CreateChapterDescription()");
            Logger.Debug($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Descriptions");
            title.Add("de", "Beschreibungen");

            // TODO: implement following stuff
            //if (Series.Descriptions != null)
            //{
            //    Logger.Debug($"Series.Descriptions is not null -> create");
            //    content.AddRange(CreateChapterHeading(title));
            //    content.AddRange(new TextContentCreator(Series.Descriptions, Formatter, TargetLanguageCode).CreateChapterContent());
            //}

            Logger.Trace($"CreateChapterDescription(): chapter descriptions for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted review chapter content of a given series.
        /// </summary>
        /// <returns>The formatted review chapter content of the series.</returns>
        protected virtual List<string> CreateChapterReview()
        {
            Logger.Trace($"CreateChapterReview()");
            Logger.Debug($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Reviews");
            title.Add("de", "Rezensionen");

            // TODO: implement following stuff
            //if (Series.Reviews != null)
            //{
            //    Logger.Debug($"Series.Reviews is not null -> create");
            //    content.AddRange(CreateChapterHeading(title));
            //    content.AddRange(new TextContentCreator(Series.Reviews, Formatter, TargetLanguageCode).CreateChapterContent());
            //}

            Logger.Trace($"CreateChapterReview(): chapter reviews for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted image chapter content of a given series.
        /// </summary>
        /// <returns>The formatted image chapter content of the series.</returns>
        protected virtual List<string> CreateChapterImage()
        {
            Logger.Trace($"CreateChapterImage()");
            Logger.Debug($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Images");
            title.Add("de", "Bilder");

            // TODO: implement following stuff
            //if (Series.Images != null)
            //{
            //    Logger.Debug($"Series.Images is not null -> create");
            //    content.AddRange(CreateChapterHeading(title));
            //    content.AddRange(new ImageContentCreator(Series.Images, Formatter, TargetLanguageCode).CreateChapterContent());
            //}

            Logger.Trace($"CreateChapterImage(): chapter images for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted cast and crew chapter content of a given series.
        /// </summary>
        /// <returns>The formatted cast and crew chapter content of the series.</returns>
        protected virtual List<string> CreateChapterCastAndCrew()
        {
            Logger.Trace($"CreateChapterCastAndCrew()");
            Logger.Debug($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Cast and Crew");
            title.Add("de", "Darsteller und Mannschaft");

            // TODO: implement following stuff
            //content.AddRange(CreateChapterHeading(title));

            //Dictionary<string, string> titleSection = new Dictionary<string, string>();

            //if (Series.Creators != null)
            //{
            //    Logger.Debug($"Series.Creators is not null -> create");
            //    titleSection.Add("en", "Creator");
            //    titleSection.Add("de", "Erfinder");
            //    content.AddRange(CreateSectionHeading(titleSection));
            //    content.AddRange(new PersonContentCreator(Series.Creators, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            //if (Series.Directors != null)
            //{
            //    Logger.Debug($"Series.Directors is not null -> create");
            //    titleSection.Add("en", "Director");
            //    titleSection.Add("de", "Regie");
            //    content.AddRange(CreateSectionHeading(titleSection));
            //    content.AddRange(new PersonContentCreator(Series.Directors, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            //if (Series.Writers != null)
            //{
            //    Logger.Debug($"Series.Writers is not null -> create");
            //    titleSection.Add("en", "Writers");
            //    titleSection.Add("de", "Drehbuch");
            //    content.AddRange(CreateSectionHeading(titleSection));
            //    content.AddRange(new PersonContentCreator(Series.Writers, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            // TODO: add more cast and crew sections

            Logger.Trace($"CreateChapterCastAndCrew(): chapter cast and crew for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted award chapter content of a given series.
        /// </summary>
        /// <returns>The formatted award chapter content of the series.</returns>
        protected virtual List<string> CreateChapterAward()
        {
            Logger.Trace($"CreateChapterAward()");
            Logger.Debug($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Awards");
            title.Add("de", "Auszeichnungen");

            // TODO: implement following stuff
            //if (Series.Awards != null)
            //{
            //    Logger.Debug($"Series.Awards is not null -> create");
            //    content.AddRange(CreateChapterHeading(title));
            //    content.AddRange(new AwardContentCreator(Series.Awards, Formatter, TargetLanguageCode).CreateChapterContent());
            //}

            Logger.Trace($"CreateChapterAward(): chapter awards for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted weblink chapter content of a given series.
        /// </summary>
        /// <returns>The formatted weblink chapter content of the series.</returns>
        protected virtual List<string> CreateChapterWeblink()
        {
            Logger.Trace($"CreateChapterWeblink()");
            Logger.Debug($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Other Sites");
            title.Add("de", "Andere Webseiten");

            // TODO: implement following stuff
            //if (Series.Weblinks != null)
            //{
            //    Logger.Debug($"Series.Weblinks is not null -> create");
            //    content.AddRange(CreateChapterHeading(title));
            //    content.AddRange(new WeblinkContentCreator(Series.Weblinks, Formatter, TargetLanguageCode).CreateChapterContent());
            //}

            Logger.Trace($"CreateChapterWeblink(): chapter weblinks for Series '{Series.OriginalTitle}' created");

            return content;
        }
    }
}
