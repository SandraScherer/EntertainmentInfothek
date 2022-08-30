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
            Logger.Trace($"SeriesContentCreator()");

            if (series == null)
            {
                Logger.Fatal($"Series not specified");
                throw new ArgumentNullException(nameof(series));
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

            Logger.Trace($"SeriesContentCreator(): SeriesContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the infobox content of a given series.
        /// </summary>
        /// <returns>The formatted content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected override List<string> CreateInfoBoxContentInternal()
        {
            Logger.Trace($"CreateInfoBoxContentInternal()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

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

            Logger.Trace($"CreateInfoBoxContentInternal(): infobox content for  Series {Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the chapter content of a given series.
        /// </summary>
        /// <returns>The formatted content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected override List<string> CreateChapterContentInternal()
        {
            Logger.Trace($"CreateChapterContentInternal()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

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

            Logger.Trace($"CreateChapterContentInternal(): chapter content for Series {Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox logo content of a given series.
        /// </summary>
        /// <returns>The formatted infobox logo content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxLogo()
        {
            Logger.Trace($"CreateInfoBoxLogo()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (Series.Logo != null)
            //{
            //    Logger.Info($"Series.Logo is not null -> create");
            //    content.AddRange(new ImageContentCreator(Series.Logo, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxLogo(): infobox logo for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox release date content of a given series.
        /// </summary>
        /// <returns>The formatted infobox release date content of the series.</returns>
        protected virtual List<string> CreateInfoBoxReleaseDateFirstEpisode()
        {
            Logger.Trace($"CreateInfoBoxReleaseDateFirstEpisode()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            string[] data = new string[2];
            string[] path = { TargetLanguageCode, "date" };

            if (!String.IsNullOrEmpty(Series.ReleaseDateFirstEpisode))
            {
                Logger.Info($"Series.ReleaseDateFirstEpisode is not null");

                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Info($"ReleaseDate (First Episode): '{Series.ReleaseDateFirstEpisode}' (english)");
                    data[0] = "Release Date (First Episode)";
                    data[1] = Formatter.AsInternalLink(path, Series.ReleaseDateFirstEpisode, Series.ReleaseDateFirstEpisode);
                }
                else // incl. case "de"
                {
                    Logger.Info($"ReleaseDate (First Episode): '{Series.ReleaseDateFirstEpisode}' (german, ...)");
                    data[0] = "Erstausstrahlung (Erste Folge)";
                    data[1] = Formatter.AsInternalLink(path, Series.ReleaseDateFirstEpisode, Series.ReleaseDateFirstEpisode);
                }
                content.Add(Formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxReleaseDateFirstEpisode(): infobox release date of first episode for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox release date content of a given series.
        /// </summary>
        /// <returns>The formatted infobox release date content of the series.</returns>
        protected virtual List<string> CreateInfoBoxReleaseDateLastEpisode()
        {
            Logger.Trace($"CreateInfoBoxReleaseDateLastEpisode()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            string[] data = new string[2];
            string[] path = { TargetLanguageCode, "date" };

            if (!String.IsNullOrEmpty(Series.ReleaseDateLastEpisode))
            {
                Logger.Info($"Series.ReleaseDateLastEpisode is not null");

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

            Logger.Trace($"CreateInfoBoxReleaseDateLastEpisode(): infobox release date of last episode for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox genre content of a given series.
        /// </summary>
        /// <returns>The formatted infobox genre content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxGenre()
        {
            Logger.Trace($"CreateInfoBoxGenre()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (Series.Genres != null)
            //{
            //    Logger.Info($"Series.Genres is not null -> create");
            //    content.AddRange(new GenreContentCreator(Series.Genres, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxGenre(): infobox genre for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox certification content of a given series.
        /// </summary>
        /// <returns>The formatted infobox certification content of the series.</returns>
        protected virtual List<string> CreateInfoBoxCertification()
        {
            Logger.Trace($"CreateInfoBoxCertification()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (Series.Certifications != null)
            //{
            //    Logger.Info($"Series.Certifications is not null -> create");
            //    content.AddRange(new CertificationContentCreator(Series.Certifications, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxCertification(): infobox certification for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox country content of a given series.
        /// </summary>
        /// <returns>The formatted infobox country content of the series.</returns>
        protected virtual List<string> CreateInfoBoxCountry()
        {
            Logger.Trace($"CreateInfoBoxCountry()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (Series.Countries != null)
            //{
            //    Logger.Info($"Series.Countries is not null -> create");
            //    content.AddRange(new CountryContentCreator(Series.Countries, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxCountry(): infobox country for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox language content of a given series.
        /// </summary>
        /// <returns>The formatted infobox language content of the series.</returns>
        protected virtual List<string> CreateInfoBoxLanguage()
        {
            Logger.Trace($"CreateInfoBoxLanguage()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (Series.Languages != null)
            //{
            //    Logger.Info($"Series.Languages is not null -> create");
            //    content.AddRange(new LanguageContentCreator(Series.Languages, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxLanguage(): infobox language for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox language content of a given series.
        /// </summary>
        /// <returns>The formatted infobox language content of the series.</returns>
        protected virtual List<string> CreateInfoBoxNoOfSeasons()
        {
            Logger.Trace($"CreateInfoBoxNoOfSeasons()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            string[] data = new string[2];

            if (!String.IsNullOrEmpty(Series.NoOfSeasons))
            {
                Logger.Info($"Series.NoOfSeasons is not null or empty");

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

            Logger.Trace($"CreateInfoBoxNoOfSeasons(): infobox no of seasons for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox language content of a given series.
        /// </summary>
        /// <returns>The formatted infobox language content of the series.</returns>
        protected virtual List<string> CreateInfoBoxNoOfEpisodes()
        {
            Logger.Trace($"CreateInfoBoxNoOfEpisodes()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            string[] data = new string[2];

            if (!String.IsNullOrEmpty(Series.NoOfEpisodes))
            {
                Logger.Info($"Series.NoOfEpisodes is not null or empty");

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

            Logger.Trace($"CreateInfoBoxNoOfEpisodes(): infobox no of episodes for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox budget content of a given series.
        /// </summary>
        /// <returns>The formatted infobox budget content of the series.</returns>
        protected virtual List<string> CreateInfoBoxBudget()
        {
            Logger.Trace($"CreateInfoBoxBudget()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            string[] data = new string[2];

            if (!String.IsNullOrEmpty(Series.Budget))
            {
                Logger.Trace($"Budget: '{Series.Budget}'");
                data[0] = "Budget";
                data[1] = $"{Series.Budget}";

                content.Add(Formatter.AsTableRow(data));
            }
            Logger.Trace($"CreateInfoBoxBudget(): infobox budget for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox worldwide gross content of a given series.
        /// </summary>
        /// <returns>The formatted infobox worldwide gross content of the series.</returns>
        protected virtual List<string> CreateInfoBoxWorldwideGross()
        {
            Logger.Trace($"CreateInfoBoxWorldwideGross()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            string[] data = new string[2];
            string[] path = { TargetLanguageCode, "date" };

            if (!String.IsNullOrEmpty(Series.WorldwideGross))
            {
                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Info($"WorldwideGross: '{Series.WorldwideGross}' (english)");
                    data[0] = "Worldwide Gross";
                }
                else //incl. case "de"
                {
                    Logger.Info($"WorldwideGross: '{Series.WorldwideGross}' (german, ...)");
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
            Logger.Trace($"CreateInfoBoxWorldwideGross(): infobox worldwide gross for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox runtime content of a given series.
        /// </summary>
        /// <returns>The formatted infobox runtime content of the series.</returns>
        protected virtual List<string> CreateInfoBoxRuntime()
        {
            Logger.Trace($"CreateInfoBoxRuntime()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (Series.Runtimes != null)
            //{
            //    Logger.Info($"Series.Runtimes is not null -> create");
            //    content.AddRange(new RuntimeContentCreator(Series.Runtimes, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxRuntime(): infobox runtime for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox soundmix content of a given series.
        /// </summary>
        /// <returns>The formatted infobox soundmix content of the series.</returns>
        protected virtual List<string> CreateInfoBoxSoundMix()
        {
            Logger.Trace($"CreateInfoBoxSoundMix()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (Series.SoundMixes != null)
            //{
            //    Logger.Info($"Series.SoundMixes is not null -> create");
            //    content.AddRange(new SoundMixContentCreator(Series.SoundMixes, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxSoundMix(): infobox soundmix for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox color content of a given series.
        /// </summary>
        /// <returns>The formatted infobox color content of the series.</returns>
        protected virtual List<string> CreateInfoBoxColor()
        {
            Logger.Trace($"CreateInfoBoxColor()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (Series.Colors != null)
            //{
            //    Logger.Info($"Series.Color is not null -> create");
            //    content.AddRange(new ColorContentCreator(Series.Colors, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxColor(): infobox color for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox aspect ratio content of a given series.
        /// </summary>
        /// <returns>The formatted infobox aspect ratio content of the series.</returns>
        protected virtual List<string> CreateInfoBoxAspectRatio()
        {
            Logger.Trace($"CreateInfoBoxAspectRatio()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (Series.AspectRatios != null)
            //{
            //    Logger.Info($"Series.AspectRatio is not null -> create");
            //    content.AddRange(new AspectRatioContentCreator(Series.AspectRatios, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxAspectRatio(): infobox aspect ratio for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox camera content of a given series.
        /// </summary>
        /// <returns>The formatted infobox camera content of the series.</returns>
        protected virtual List<string> CreateInfoBoxCamera()
        {
            Logger.Trace($"CreateInfoBoxCamera()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (Series.Cameras != null)
            //{
            //    Logger.Info($"Series.Cameras is not null -> create");
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
            Logger.Trace($"CreateInfoBoxLaboratory()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (Series.Laboratories != null)
            //{
            //    Logger.Info($"Series.Laboratories is not null -> create");
            //    content.AddRange(new LaboratoryContentCreator(Series.Laboratories, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxLaboratory(): infobox laboratory for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox film length content of a given series.
        /// </summary>
        /// <returns>The formatted infobox film length content of the series.</returns>
        protected virtual List<string> CreateInfoBoxFilmLength()
        {
            Logger.Trace($"CreateInfoBoxFilmLength()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (Series.FilmLengths != null)
            //{
            //    Logger.Info($"Series.FilmLengths is not null -> create");
            //    content.AddRange(new FilmLengthContentCreator(Series.FilmLengths, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxFilmLength(): infobox film length for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox negative format content of a given series.
        /// </summary>
        /// <returns>The formatted infobox negative format content of the series.</returns>
        protected virtual List<string> CreateInfoBoxNegativeFormat()
        {
            Logger.Trace($"CreateInfoBoxNegativeFormat()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (Series.NegativeFormats != null)
            //{
            //    Logger.Info($"Series.NegativeFormats is not null -> create");
            //    content.AddRange(new NegativeFormatContentCreator(Series.NegativeFormats, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxNegativeFormat(): infobox negative format for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox cinematographic process content of a given series.
        /// </summary>
        /// <returns>The formatted infobox cinematographic process content of the series.</returns>
        protected virtual List<string> CreateInfoBoxCinematographicProcess()
        {
            Logger.Trace($"CreateInfoBoxCinematographicProcess()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (Series.CinematographicProcesses != null)
            //{
            //    Logger.Info($"Series.CinematographicProcesses is not null -> create");
            //    content.AddRange(new CinematographicProcessContentCreator(Series.CinematographicProcesses, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxCinematographicProcess(): infobox cinematographic process for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox printed film format content of a given series.
        /// </summary>
        /// <returns>The formatted infobox printed film format content of the series.</returns>
        protected virtual List<string> CreateInfoBoxPrintedFilmFormat()
        {
            Logger.Trace($"CreateInfoBoxPrintedFilmFormat()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (Series.PrintedFilmFormats != null)
            //{
            //    Logger.Info($"Series.PrintedFilmFormats is not null -> create");
            //    content.AddRange(new PrintedFilmFormatsContentCreator(Series.PrintedFilmFormats, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            //}

            Logger.Trace($"CreateInfoBoxPrintedFilmFormat(): infobox printed film formats for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted poster chapter content of a given series.
        /// </summary>
        /// <returns>The formatted poster chapter content of the series.</returns>
        protected virtual List<string> CreateChapterPoster()
        {
            Logger.Trace($"CreateChapterPoster()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Poster");
            title.Add("de", "Poster");

            // TODO: implement following stuff
            //if (Series.Posters != null)
            //{
            //    Logger.Info($"Series.Posters is not null -> create");
            //    content.AddRange(CreateNewChapter(title));
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
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Cover");
            title.Add("de", "Cover");

            // TODO: implement following stuff
            //if (Series.Covers != null)
            //{
            //    Logger.Info($"Series.Covers is not null -> create");
            //    content.AddRange(CreateNewChapter(title));
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
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Descriptions");
            title.Add("de", "Beschreibungen");

            // TODO: implement following stuff
            //if (Series.Descriptions != null)
            //{
            //    Logger.Info($"Series.Descriptions is not null -> create");
            //    content.AddRange(CreateNewChapter(title));
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
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Reviews");
            title.Add("de", "Rezensionen");

            // TODO: implement following stuff
            //if (Series.Reviews != null)
            //{
            //    Logger.Info($"Series.Reviews is not null -> create");
            //    content.AddRange(CreateNewChapter(title));
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
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Images");
            title.Add("de", "Bilder");

            // TODO: implement following stuff
            //if (Series.Images != null)
            //{
            //    Logger.Info($"Series.Images is not null -> create");
            //    content.AddRange(CreateNewChapter(title));
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
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Cast and Crew");
            title.Add("de", "Darsteller und Mannschaft");

            // TODO: implement following stuff
            //content.AddRange(CreateNewChapter(title));

            //Dictionary<string, string> titleSection = new Dictionary<string, string>();

            //if (Series.Directors != null)
            //{
            //    Logger.Info($"Series.Directors is not null -> create");
            //    titleSection.Add("en", "Director");
            //    titleSection.Add("de", "Regie");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new PersonContentCreator(Series.Directors, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            //if (Series.Writers != null)
            //{
            //    Logger.Info($"Series.Writers is not null -> create");
            //    titleSection.Add("en", "Writers");
            //    titleSection.Add("de", "Drehbuch");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new PersonContentCreator(Series.Writers, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            // TODO: add more cast and crew sections

            Logger.Trace($"CreateChapterCastAndCrew(): chapter cast and crew for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted company chapter content of a given series.
        /// </summary>
        /// <returns>The formatted company chapter content of the series.</returns>
        protected virtual List<string> CreateChapterCompany()
        {
            Logger.Trace($"CreateChapterCompany()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Company Credits");
            title.Add("de", "Beteiligte Firmen");

            // TODO: implement following stuff
            //content.AddRange(CreateNewChapter(title));

            //Dictionary<string, string> titleSection = new Dictionary<string, string>();

            //if (Series.ProductionCompanies != null)
            //{
            //    Logger.Info($"Series.ProductionCompanies is not null -> create");
            //    titleSection.Add("en", "Production Company");
            //    titleSection.Add("de", "Produktionsfirmen");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new CompanyContentCreator(Series.ProductionCompanies, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            //if (Series.Distributors != null)
            //{
            //    Logger.Info($"Series.Distributors is not null -> create");
            //    titleSection.Add("en", "Distributors");
            //    titleSection.Add("de", "Vertrieb");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new CompanyContentCreator(Series.Distributors, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            // TODO: add more company sections

            Logger.Trace($"CreateChapterCompany(): chapter companies for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted filming and production chapter content of a given series.
        /// </summary>
        /// <returns>The formatted filming and production chapter content of the series.</returns>
        protected virtual List<string> CreateChapterFilmingAndProduction()
        {
            Logger.Trace($"CreateChapterFilmingAndProduction()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Filming and Production");
            title.Add("de", "Produktion");

            //TODO: implement following stuff
            //content.AddRange(CreateNewChapter(title));

            //Dictionary<string, string> titleSection = new Dictionary<string, string>();

            //if (Series.FilmingLocations != null)
            //{
            //    Logger.Info($"Series.FilmingLocations is not null -> create");
            //    titleSection.Add("en", "Filming Locations");
            //    titleSection.Add("de", "Drehorte");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new LocationContentCreator(Series.FilmingLocations, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            //if (Series.FilmingDates != null)
            //{
            //    Logger.Info($"Series.FilmingDates is not null -> create");
            //    titleSection.Add("en", "Filming Dates");
            //    titleSection.Add("de", "");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new TimeSpanContentCreator(Series.FilmingDates, Formatter, TargetLanguageCode).CreateSectionContent());
            //}
            //if (Series.ProductionDates != null)
            //{
            //    Logger.Info($"Series.ProductionDates is not null -> create");
            //    titleSection.Add("en", "Production Dates");
            //    titleSection.Add("de", "");
            //    content.AddRange(CreateNewSection(titleSection));
            //    content.AddRange(new TimeSpanContentCreator(Series.ProductionDates, Formatter, TargetLanguageCode).CreateSectionContent());
            //}

            Logger.Trace($"CreateChapterFilmingAndProduction(): chapter filming and production for Series '{Series.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted award chapter content of a given series.
        /// </summary>
        /// <returns>The formatted award chapter content of the series.</returns>
        protected virtual List<string> CreateChapterAward()
        {
            Logger.Trace($"CreateChapterAward()");
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Awards");
            title.Add("de", "Auszeichnungen");

            // TODO: implement following stuff
            //if (Series.Awards != null)
            //{
            //    Logger.Info($"Series.Awards is not null -> create");
            //    content.AddRange(CreateNewChapter(title));
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
            Logger.Info($"Series is '{Series.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Other Sites");
            title.Add("de", "Andere Webseiten");

            // TODO: implement following stuff
            //if (Series.Weblinks != null)
            //{
            //    Logger.Info($"Series.Weblinks is not null -> create");
            //    content.AddRange(CreateNewChapter(title));
            //    content.AddRange(new WeblinkContentCreator(Series.Weblinks, Formatter, TargetLanguageCode).CreateChapterContent());
            //}

            Logger.Trace($"CreateChapterWeblink(): chapter weblinks for Series '{Series.OriginalTitle}' created");

            return content;
        }
    }
}
