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
    public class SeriesContentCreator : ArticleContentCreator
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
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"SeriesContentCreator() angelegt");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the infobox content of a given series.
        /// </summary>
        /// <returns>The formatted content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public override List<string> CreateInfoBoxContent()
        {
            Logger.Trace($"CreateInfoBoxContent() für Series {Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            content.AddRange(CreateInfoBoxTitle());
            content.AddRange(CreateInfoBoxType());
            content.AddRange(CreateInfoBoxLogo());
            content.AddRange(CreateInfoBoxReleaseDateFirstEpisode());
            content.AddRange(CreateInfoBoxReleaseDateLastEpisode());
            content.AddRange(CreateInfoBoxGenre());
            content.AddRange(CreateInfoBoxCertification());
            content.AddRange(CreateInfoBoxCountry());
            content.AddRange(CreateInfoBoxLanguage());
            content.AddRange(CreateInfoBoxNoOfSeasons());
            content.AddRange(CreateInfoBoxNoOfEpisodes());
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

            Logger.Trace($"CreateInfoBoxContent() für Series {Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the chapter content of a given series.
        /// </summary>
        /// <returns>The formatted content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public override List<string> CreateChapterContent()
        {
            Logger.Trace($"CreateChapterContent() für Series '{Series.OriginalTitle}' gestartet");

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

            Logger.Trace($"CreateInfoBoxContent() für Series {Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the section content of a given series.
        /// </summary>
        /// <returns>The formatted section content of the series.</returns>
        public override List<string> CreateSectionContent()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates the formatted infobox logo content of a given series.
        /// </summary>
        /// <returns>The formatted infobox logo content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxLogo()
        {
            Logger.Trace($"CreateInfoBoxReleaseDate() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (Series.Logo != null)
            //{
            //    content.AddRange(new ImageContentCreator(Series.Logo, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxReleaseDate() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox release date content of a given series.
        /// </summary>
        /// <returns>The formatted infobox release date content of the series.</returns>
        protected virtual List<string> CreateInfoBoxReleaseDateFirstEpisode()
        {
            Logger.Trace($"CreateInfoBoxReleaseDateFirstEpisode() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];
            string[] path = { TargetLanguageCode, "date" };

            if (!String.IsNullOrEmpty(Series.ReleaseDateFirstEpisode))
            {
                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Trace($"Release Date (First Episode): '{Series.ReleaseDateFirstEpisode}' (englisch)");
                    data[0] = "Release Date (First Episode)";
                    data[1] = Formatter.AsInternalLink(path, Series.ReleaseDateFirstEpisode, Series.ReleaseDateFirstEpisode);
                }
                else // incl. case "de"
                {
                    Logger.Trace($"Release Date (First Episode): '{Series.ReleaseDateFirstEpisode}' (deutsch, ...)");
                    data[0] = "Erstausstrahlung (Erste Folge)";
                    data[1] = Formatter.AsInternalLink(path, Series.ReleaseDateFirstEpisode, Series.ReleaseDateFirstEpisode);
                }
                content.Add(Formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxReleaseDateFirstEpisode() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox release date content of a given series.
        /// </summary>
        /// <returns>The formatted infobox release date content of the series.</returns>
        protected virtual List<string> CreateInfoBoxReleaseDateLastEpisode()
        {
            Logger.Trace($"CreateInfoBoxReleaseDateLastEpisode() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];
            string[] path = { TargetLanguageCode, "date" };

            if (!String.IsNullOrEmpty(Series.ReleaseDateLastEpisode))
            {
                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Trace($"Release Date (Last Episode): '{Series.ReleaseDateLastEpisode}' (englisch)");
                    data[0] = "Release Date (Last Episode)";
                    data[1] = Formatter.AsInternalLink(path, Series.ReleaseDateLastEpisode, Series.ReleaseDateLastEpisode);
                }
                else // incl. case "de"
                {
                    Logger.Trace($"Release Date (Last Episode): '{Series.ReleaseDateLastEpisode}' (deutsch, ...)");
                    data[0] = "Erstausstrahlung (Letzte Folge)";
                    data[1] = Formatter.AsInternalLink(path, Series.ReleaseDateLastEpisode, Series.ReleaseDateLastEpisode);
                }
                content.Add(Formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxReleaseDateLastEpisode() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox genre content of a given series.
        /// </summary>
        /// <returns>The formatted infobox genre content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxGenre()
        {
            Logger.Trace($"CreateInfoBoxGenre() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            //TODO: implement following stuff
            //if (Series.Genres != null)
            //{
            //    content.AddRange(new GenreContentCreator(Series.Genres, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxGenre() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox certification content of a given series.
        /// </summary>
        /// <returns>The formatted infobox certification content of the series.</returns>
        protected virtual List<string> CreateInfoBoxCertification()
        {
            Logger.Trace($"CreateInfoBoxCertification() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            //TODO: implement following stuff
            //if (Series.Certifications != null)
            // {
            //     content.AddRange(new CertificationContentCreator(Series.Certifications, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            // }

            Logger.Trace($"CreateInfoBoxCertification() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox country content of a given series.
        /// </summary>
        /// <returns>The formatted infobox country content of the series.</returns>
        protected virtual List<string> CreateInfoBoxCountry()
        {
            Logger.Trace($"CreateInfoBoxCountry() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            //TODO: implement following stuff
            //if (Series.Countries != null)
            //{
            //    content.AddRange(new CountryContentCreator(Series.Countries, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxCountry() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox language content of a given series.
        /// </summary>
        /// <returns>The formatted infobox language content of the series.</returns>
        protected virtual List<string> CreateInfoBoxLanguage()
        {
            Logger.Trace($"CreateInfoBoxLanguage() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            //TODO: implement following stuff
            //if (Series.Languages != null)
            //{
            //    content.AddRange(new LanguageContentCreator(Series.Languages, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxLanguage() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox language content of a given series.
        /// </summary>
        /// <returns>The formatted infobox language content of the series.</returns>
        protected virtual List<string> CreateInfoBoxNoOfSeasons()
        {
            Logger.Trace($"CreateInfoBoxNoOfSeasons() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];

            if (!String.IsNullOrEmpty(Series.NoOfSeasons))
            {
                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Trace($"No of Seasons: '{Series.NoOfSeasons}' (englisch)");
                    data[0] = "# Seasons";
                    data[1] = Series.NoOfSeasons;
                }
                else // incl. case "de"
                {
                    Logger.Trace($"No of Seasons: '{Series.NoOfSeasons}' (deutsch, ...)");
                    data[0] = "# Staffeln";
                    data[1] = Series.NoOfSeasons;
                }
                content.Add(Formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxNoOfSeasons() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox language content of a given series.
        /// </summary>
        /// <returns>The formatted infobox language content of the series.</returns>
        protected virtual List<string> CreateInfoBoxNoOfEpisodes()
        {
            Logger.Trace($"CreateInfoBoxNoOfEpisodes() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];

            if (!String.IsNullOrEmpty(Series.NoOfEpisodes))
            {
                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Trace($"No of Episodes: '{Series.NoOfEpisodes}' (englisch)");
                    data[0] = "# Episodes";
                    data[1] = Series.NoOfEpisodes;
                }
                else // incl. case "de"
                {
                    Logger.Trace($"No of Episodes: '{Series.NoOfEpisodes}' (deutsch, ...)");
                    data[0] = "# Folgen";
                    data[1] = Series.NoOfEpisodes;
                }
                content.Add(Formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxNoOfEpisodes() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox budget content of a given series.
        /// </summary>
        /// <returns>The formatted infobox budget content of the series.</returns>
        protected virtual List<string> CreateInfoBoxBudget()
        {
            Logger.Trace($"CreateInfoBoxBudget() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];

            if (!String.IsNullOrEmpty(Series.Budget))
            {
                Logger.Trace($"Budget: {Series.Budget}");
                data[0] = "Budget";
                data[1] = $"{Series.Budget}";

                content.Add(Formatter.AsTableRow(data));
            }
            Logger.Trace($"CreateInfoBoxBudget() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox worldwide gross content of a given series.
        /// </summary>
        /// <returns>The formatted infobox worldwide gross content of the series.</returns>
        protected virtual List<string> CreateInfoBoxWorldwideGross()
        {
            Logger.Trace($"CreateInfoBoxWorldwideGross() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];
            string[] path = { TargetLanguageCode, "date" };

            if (!String.IsNullOrEmpty(Series.WorldwideGross))
            {
                Logger.Trace($"Worldwide Gross: {Series.WorldwideGross}");

                if (TargetLanguageCode.Equals("en"))
                {
                    data[0] = "Worldwide Gross";
                }
                else //incl. case "de"
                {
                    data[0] = "Einspielergebnis (weltweit)";
                }

                if (!String.IsNullOrEmpty(Series.WorldwideGrossDate))
                {
                    data[1] = $"{Series.WorldwideGross} ({Formatter.AsInternalLink(path, Series.WorldwideGrossDate, Series.WorldwideGrossDate)})";
                }
                else
                {
                    data[1] = $"{Series.WorldwideGross}";
                }
                content.Add(Formatter.AsTableRow(data));
            }
            Logger.Trace($"CreateInfoBoxWorldwideGross() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox runtime content of a given series.
        /// </summary>
        /// <returns>The formatted infobox runtime content of the series.</returns>
        protected virtual List<string> CreateInfoBoxRuntime()
        {
            Logger.Trace($"CreateInfoBoxRuntime() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            //TODO: implement following stuff
            //if (Series.Runtimes != null)
            //{
            //    content.AddRange(new RuntimeContentCreator(Series.Runtimes, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxRuntime() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox soundmix content of a given series.
        /// </summary>
        /// <returns>The formatted infobox soundmix content of the series.</returns>
        protected virtual List<string> CreateInfoBoxSoundMix()
        {
            Logger.Trace($"CreateInfoBoxSoundMix() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            //TODO: implement following stuff
            //if (Series.SoundMixes != null)
            //{
            //    content.AddRange(new SoundMixContentCreator(Series.SoundMixes, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxSoundMix() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox color content of a given series.
        /// </summary>
        /// <returns>The formatted infobox color content of the series.</returns>
        protected virtual List<string> CreateInfoBoxColor()
        {
            Logger.Trace($"CreateInfoBoxColor() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            //TODO: implement following stuff
            //if (Series.Colors != null)
            //{
            //    content.AddRange(new ColorContentCreator(Series.Colors, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxColor() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox aspect ratio content of a given series.
        /// </summary>
        /// <returns>The formatted infobox aspect ratio content of the series.</returns>
        protected virtual List<string> CreateInfoBoxAspectRatio()
        {
            Logger.Trace($"CreateInfoBoxAspectRatio() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            //TODO: implement following stuff
            //if (Series.AspectRatios != null)
            //{
            //    content.AddRange(new AspectRatioContentCreator(Series.AspectRatios, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxAspectRatio() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox camera content of a given series.
        /// </summary>
        /// <returns>The formatted infobox camera content of the series.</returns>
        protected virtual List<string> CreateInfoBoxCamera()
        {
            Logger.Trace($"CreateInfoBoxCamera() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            //TODO: implement following stuff
            //if (Series.Cameras != null)
            //{
            //    content.AddRange(new CameraContentCreator(Series.Cameras, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxCamera() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox camera content of a given series.
        /// </summary>
        /// <returns>The formatted infobox camera content of the series.</returns>
        protected virtual List<string> CreateInfoBoxLaboratory()
        {
            Logger.Trace($"CreateInfoBoxLaboratory() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            //TODO: implement following stuff
            //if (Series.Laboratories != null)
            //{
            //    content.AddRange(new LaboratoryContentCreator(Series.Laboratories, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxLaboratory() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox film length content of a given series.
        /// </summary>
        /// <returns>The formatted infobox film length content of the series.</returns>
        protected virtual List<string> CreateInfoBoxFilmLength()
        {
            Logger.Trace($"CreateInfoBoxFilmLength() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            //TODO: implement following stuff
            //if (Series.FilmLengths != null)
            //{
            //    content.AddRange(new FilmLengthContentCreator(Series.FilmLengths, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxFilmLength() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox negative format content of a given series.
        /// </summary>
        /// <returns>The formatted infobox negative format content of the series.</returns>
        protected virtual List<string> CreateInfoBoxNegativeFormat()
        {
            Logger.Trace($"CreateInfoBoxNegativeFormat() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            //TODO: implement following stuff
            //if (Series.NegativeFormats != null)
            //{
            //    content.AddRange(new NegativeFormatContentCreator(Series.NegativeFormats, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxNegativeFormat() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox cinematographic process content of a given series.
        /// </summary>
        /// <returns>The formatted infobox cinematographic process content of the series.</returns>
        protected virtual List<string> CreateInfoBoxCinematographicProcess()
        {
            Logger.Trace($"CreateInfoBoxCinematographicProcess() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            //TODO: implement following stuff
            //if (Series.CinematographicProcesses != null)
            // {
            //     content.AddRange(new CinematographicProcessContentCreator(Series.CinematographicProcesses, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            // }

            Logger.Trace($"CreateInfoBoxCinematographicProcess() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox printed film format content of a given series.
        /// </summary>
        /// <returns>The formatted infobox printed film format content of the series.</returns>
        protected virtual List<string> CreateInfoBoxPrintedFilmFormat()
        {
            Logger.Trace($"CreateInfoBoxPrintedFilmFormat() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            //TODO: implement following stuff
            //if (Series.PrintedFilmFormats != null)
            //{
            //    content.AddRange(new PrintedFilmFormatsContentCreator(Series.PrintedFilmFormats, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxPrintedFilmFormat() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted poster chapter content of a given series.
        /// </summary>
        /// <returns>The formatted poster chapter content of the series.</returns>
        protected virtual List<string> CreateChapterPoster()
        {
            Logger.Trace($"CreateChapterPoster() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Poster");
            title.Add("de", "Poster");

            //TODO: implement following stuff
            //if (Series.Posters != null)
            //{
            //    content.AddRange(CreateNewChapter(title));
            //    content.AddRange(new ImageContentCreator(Series.Posters, Formatter, TargetLanguageCode).CreateChapterContent());
            //}

            Logger.Trace($"CreateChapterPoster() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted cover chapter content of a given series.
        /// </summary>
        /// <returns>The formatted cover chapter content of the series.</returns>
        protected virtual List<string> CreateChapterCover()
        {
            Logger.Trace($"CreateChapterCover() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Cover");
            title.Add("de", "Cover");

            //TODO: implement following stuff
            //if (Series.Covers != null)
            //{
            //    content.AddRange(CreateNewChapter(title));
            //    content.AddRange(new ImageContentCreator(Series.Covers, Formatter, TargetLanguageCode).CreateChapterContent());
            //}

            Logger.Trace($"CreateChapterCover() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted description chapter content of a given series.
        /// </summary>
        /// <returns>The formatted description chapter content of the series.</returns>
        protected virtual List<string> CreateChapterDescription()
        {
            Logger.Trace($"CreateChapterDescription() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Descriptions");
            title.Add("de", "Beschreibungen");

            //TODO: implement following stuff
            //if (Series.Descriptions != null)
            //{
            //    content.AddRange(CreateNewChapter(title));
            //    content.AddRange(new TextContentCreator(Series.Descriptions, Formatter, TargetLanguageCode).CreateChapterContent());
            //}

            Logger.Trace($"CreateChapterDescription() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted review chapter content of a given series.
        /// </summary>
        /// <returns>The formatted review chapter content of the series.</returns>
        protected virtual List<string> CreateChapterReview()
        {
            Logger.Trace($"CreateChapterReview() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Reviews");
            title.Add("de", "Rezensionen");

            //TODO: implement following stuff
            //if (Series.Reviews != null)
            //{
            //    content.AddRange(CreateNewChapter(title));
            //    content.AddRange(new TextContentCreator(Series.Reviews, Formatter, TargetLanguageCode).CreateChapterContent());
            //}

            Logger.Trace($"CreateChapterReview() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted image chapter content of a given series.
        /// </summary>
        /// <returns>The formatted image chapter content of the series.</returns>
        protected virtual List<string> CreateChapterImage()
        {
            Logger.Trace($"CreateChapterImage() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Images");
            title.Add("de", "Bilder");

            //TODO: implement following stuff
            //if (Series.Images != null)
            //{
            //    content.AddRange(CreateNewChapter(title));
            //    content.AddRange(new ImageContentCreator(Series.Images, Formatter, TargetLanguageCode).CreateChapterContent());
            //}

            Logger.Trace($"CreateChapterImage() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted cast and crew chapter content of a given series.
        /// </summary>
        /// <returns>The formatted cast and crew chapter content of the series.</returns>
        protected virtual List<string> CreateChapterCastAndCrew()
        {
            Logger.Trace($"CreateChapterCastAndCrew() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Cast and Crew");
            title.Add("de", "Darsteller und Mannschaft");

            //TODO: implement following stuff
            //content.AddRange(CreateNewChapter(title));

            //Dictionary<string, string> titleSection = new Dictionary<string, string>();

            //if (Series.Directors != null)
            //{
            //    titleSection.Add("en", "Director");
            //    titleSection.Add("de", "Regie");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new PersonContentCreator(Series.Directors, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            //if (Series.Writers != null)
            //{
            //    titleSection.Add("en", "Writers");
            //    titleSection.Add("de", "Drehbuch");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new PersonContentCreator(Series.Writers, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            // TODO: add more cast and crew sections

            Logger.Trace($"CreateChapterCastAndCrew() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted company chapter content of a given series.
        /// </summary>
        /// <returns>The formatted company chapter content of the series.</returns>
        protected virtual List<string> CreateChapterCompany()
        {
            Logger.Trace($"CreateChapterCompany() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Company Credits");
            title.Add("de", "Beteiligte Firmen");

            //TODO: implement following stuff
            //content.AddRange(CreateNewChapter(title));

            //Dictionary<string, string> titleSection = new Dictionary<string, string>();

            //if (Series.Directors != null)
            //{
            //    titleSection.Add("en", "Production Company");
            //    titleSection.Add("de", "Produktionsfirmen");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new CompanyContentCreator(Series.ProductionCompanies, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            //if (Series.Writers != null)
            //{
            //    titleSection.Add("en", "Distributors");
            //    titleSection.Add("de", "Vertrieb");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new CompanyContentCreator(Series.Distributors, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            // TODO: add more cast and crew sections

            Logger.Trace($"CreateChapterCompany() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted filming and production chapter content of a given series.
        /// </summary>
        /// <returns>The formatted filming and production chapter content of the series.</returns>
        protected virtual List<string> CreateChapterFilmingAndProduction()
        {
            Logger.Trace($"CreateChapterFilmingAndProduction() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Filming and Production");
            title.Add("de", "Produktion");

            //TODO: implement following stuff
            //content.AddRange(CreateNewChapter(title));

            //Dictionary<string, string> titleSection = new Dictionary<string, string>();

            //if (Series.FilmingLocations != null)
            //{
            //    titleSection.Add("en", "Filming Locations");
            //    titleSection.Add("de", "Drehorte");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new LocationContentCreator(Series.FilmingLocations, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            //if (Series.FilmingDates != null)
            //{
            //    titleSection.Add("en", "Filming Dates");
            //    titleSection.Add("de", "");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new TimeSpanContentCreator(Series.FilmingDates, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            //if (Series.ProductionDates != null)
            //{
            //    titleSection.Add("en", "Production Dates");
            //    titleSection.Add("de", "");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new TimeSpanContentCreator(Series.ProductionDates, Formatter, TargetLanguageCode).CreateSectionContent());
            //}

            Logger.Trace($"CreateChapterFilmingAndProduction() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted award chapter content of a given series.
        /// </summary>
        /// <returns>The formatted award chapter content of the series.</returns>
        protected virtual List<string> CreateChapterAward()
        {
            Logger.Trace($"CreateChapterAward() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Awards");
            title.Add("de", "Auszeichnungen");

            //TODO: implement following stuff
            //if (Series.Awards != null)
            //{
            //    content.AddRange(CreateNewChapter(title));
            //    content.AddRange(new AwardContentCreator(Series.Awards, Formatter, TargetLanguageCode).CreateChapterContent());
            //}

            Logger.Trace($"CreateChapterAward() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted weblink chapter content of a given series.
        /// </summary>
        /// <returns>The formatted weblink chapter content of the series.</returns>
        protected virtual List<string> CreateChapterWeblink()
        {
            Logger.Trace($"CreateChapterWeblink() für Series '{Series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Other Sites");
            title.Add("de", "Andere Webseiten");

            //TODO: implement following stuff
            //if (Series.Weblinks != null)
            // {
            //     content.AddRange(CreateNewChapter(title));
            //     content.AddRange(new WeblinkContentCreator(Series.Weblinks, Formatter, TargetLanguageCode).CreateChapterContent());
            // }

            Logger.Trace($"CreateChapterWeblink() für Series '{Series.OriginalTitle}' beendet");

            return content;
        }
    }
}
