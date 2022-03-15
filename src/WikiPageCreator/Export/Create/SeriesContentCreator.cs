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
    public class SeriesContentCreator : ArticleContentCreator, IFileContentCreatable
    {
        // --- Properties ---

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new SeriesContentCreator.
        /// </summary>
        public SeriesContentCreator()
        {
            Logger.Trace($"SeriesContentCreator() angelegt");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the infobox content of a given entry.
        /// </summary>
        /// <param name="entry">The entry that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted content of the entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected override List<string> CreateInfoBoxContent(Entry entry, string targetLanguageCode, Formatter formatter)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxContent() für Series {((Series)entry).OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            content.AddRange(base.CreateInfoBoxContent((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxLogo((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxReleaseDateFirstEpisode((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxReleaseDateLastEpisode((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxGenre((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxCertification((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxCountry((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxLanguage((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxNoOfSeasons((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxNoOfEpisodes((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxBudget((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxWorldwideGross((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxRuntime((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxSoundMix((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxColor((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxAspectRatio((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxCamera((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxLaboratory((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxFilmLength((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxNegativeFormat((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxCinematographicProcess((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxPrintedFilmFormat((Series)entry, targetLanguageCode, formatter));

            Logger.Trace($"CreateInfoBoxContent() für Series {((Series)entry).OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the chapter content of a given entry.
        /// </summary>
        /// <param name="entry">The entry that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted content of the entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected override List<string> CreateChapterContent(Entry entry, string targetLanguageCode, Formatter formatter)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterContent() für Series '{((Series)entry).OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            content.AddRange(CreateChapterPoster((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterCover((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterDescription((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterReview((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterImage((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterCastAndCrew((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterCompany((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterFilmingAndProduction((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterAward((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterWeblink((Series)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterConnection((Series)entry, targetLanguageCode, formatter));

            Logger.Trace($"CreateInfoBoxContent() für Series {((Series)entry).OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox logo content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox logo content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxLogo(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxReleaseDate() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (series.Logo != null)
            //{
            //    content.AddRange((new ImageContentCreator()).CreateInfoBoxContent(series.Logo, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxReleaseDate() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox release date content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox release date content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxReleaseDateFirstEpisode(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxReleaseDateFirstEpisode() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];
            string[] path = { targetLanguageCode, "date" };

            if (!String.IsNullOrEmpty(series.ReleaseDateFirstEpisode))
            {
                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Trace($"Release Date (First Episode): '{series.ReleaseDateFirstEpisode}' (englisch)");
                    data[0] = "Release Date (First Episode)";
                    data[1] = formatter.AsInternalLink(path, series.ReleaseDateFirstEpisode, series.ReleaseDateFirstEpisode);
                }
                else // incl. case "de"
                {
                    Logger.Trace($"Release Date (First Episode): '{series.ReleaseDateFirstEpisode}' (deutsch, ...)");
                    data[0] = "Erstausstrahlung (Erste Folge)";
                    data[1] = formatter.AsInternalLink(path, series.ReleaseDateFirstEpisode, series.ReleaseDateFirstEpisode);
                }
                content.Add(formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxReleaseDateFirstEpisode() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox release date content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox release date content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxReleaseDateLastEpisode(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxReleaseDateLastEpisode() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];
            string[] path = { targetLanguageCode, "date" };

            if (!String.IsNullOrEmpty(series.ReleaseDateLastEpisode))
            {
                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Trace($"Release Date (Last Episode): '{series.ReleaseDateLastEpisode}' (englisch)");
                    data[0] = "Release Date (Last Episode)";
                    data[1] = formatter.AsInternalLink(path, series.ReleaseDateLastEpisode, series.ReleaseDateLastEpisode);
                }
                else // incl. case "de"
                {
                    Logger.Trace($"Release Date (Last Episode): '{series.ReleaseDateLastEpisode}' (deutsch, ...)");
                    data[0] = "Erstausstrahlung (Letzte Folge)";
                    data[1] = formatter.AsInternalLink(path, series.ReleaseDateLastEpisode, series.ReleaseDateLastEpisode);
                }
                content.Add(formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxReleaseDateLastEpisode() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox genre content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox genre content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxGenre(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxGenre() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (series.Genres != null)
            //{
            //    content.AddRange((new GenreContentCreator()).CreateInfoBoxContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxGenre() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox certification content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox certification content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxCertification(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxCertification() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (series.Certifications != null)
            //{
            //    content.AddRange((new CertificationContentCreator()).CreateInfoBoxContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxCertification() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox country content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox country content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxCountry(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxCountry() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (series.Countries != null)
            //{
            //    content.AddRange((new CountryContentCreator()).CreateInfoBoxContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxCountry() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox language content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox language content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxLanguage(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxLanguage() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (series.Languages != null)
            //{
            //    content.AddRange((new LanguageContentCreator()).CreateInfoBoxContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxLanguage() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox language content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox language content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxNoOfSeasons(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxNoOfSeasons() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];

            if (!String.IsNullOrEmpty(series.NoOfSeasons))
            {
                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Trace($"No of Seasons: '{series.NoOfSeasons}' (englisch)");
                    data[0] = "No of Seasons";
                    data[1] = series.NoOfSeasons;
                }
                else // incl. case "de"
                {
                    Logger.Trace($"No of Seasons: '{series.NoOfSeasons}' (deutsch, ...)");
                    data[0] = "# Staffeln";
                    data[1] = series.NoOfSeasons;
                }
                content.Add(formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxNoOfSeasons() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox language content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox language content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxNoOfEpisodes(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxNoOfEpisodes() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];

            if (!String.IsNullOrEmpty(series.NoOfEpisodes))
            {
                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Trace($"No of Episodes: '{series.NoOfEpisodes}' (englisch)");
                    data[0] = "No of Episodes";
                    data[1] = series.NoOfEpisodes;
                }
                else // incl. case "de"
                {
                    Logger.Trace($"No of Episodes: '{series.NoOfEpisodes}' (deutsch, ...)");
                    data[0] = "# Folgen";
                    data[1] = series.NoOfEpisodes;
                }
                content.Add(formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxNoOfEpisodes() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox budget content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox budget content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxBudget(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxBudget() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];

            if (!String.IsNullOrEmpty(series.Budget))
            {
                Logger.Trace($"Budget: {series.Budget}");
                data[0] = "Budget";
                data[1] = $"{series.Budget}";

                content.Add(formatter.AsTableRow(data));
            }
            Logger.Trace($"CreateInfoBoxBudget() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox worldwide gross content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox worldwide gross content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxWorldwideGross(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxWorldwideGross() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];
            string[] path = { targetLanguageCode, "date" };

            if (!String.IsNullOrEmpty(series.WorldwideGross))
            {
                Logger.Trace($"Worldwide Gross: {series.WorldwideGross}");

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Worldwide Gross";
                }
                else //incl. case "de"
                {
                    data[0] = "Einspielergebnis (weltweit)";
                }

                if (!String.IsNullOrEmpty(series.WorldwideGrossDate))
                {
                    data[1] = $"{series.WorldwideGross} ({formatter.AsInternalLink(path, series.WorldwideGrossDate, series.WorldwideGrossDate)})";
                }
                else
                {
                    data[1] = $"{series.WorldwideGross}";
                }
                content.Add(formatter.AsTableRow(data));
            }
            Logger.Trace($"CreateInfoBoxWorldwideGross() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox runtime content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox runtime content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxRuntime(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxRuntime() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (series.Runtimes != null)
            //{
            //    content.AddRange((new RuntimeContentCreator()).CreateInfoBoxContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxRuntime() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox soundmix content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox soundmix content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxSoundMix(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxSoundMix() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (series.SoundMixes != null)
            //{
            //    content.AddRange((new SoundMixContentCreator()).CreateInfoBoxContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxSoundMix() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox color content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox color content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxColor(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxColor() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (series.Colors != null)
            //{
            //    content.AddRange((new ColorContentCreator()).CreateInfoBoxContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxColor() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox aspect ratio content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox aspect ratio content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxAspectRatio(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxAspectRatio() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (series.AspectRatios != null)
            //{
            //    content.AddRange((new AspectRatioContentCreator()).CreateInfoBoxContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxAspectRatio() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox camera content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox camera content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxCamera(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxCamera() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (series.Cameras != null)
            //{
            //    content.AddRange((new CameraContentCreator()).CreateInfoBoxContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxCamera() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox laboratory content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox laboratory content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxLaboratory(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxLaboratory() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (series.Laboratories != null)
            //{
            //    content.AddRange((new LaboratoryContentCreator()).CreateInfoBoxContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxLaboratory() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox film length content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox film length content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxFilmLength(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxFilmLength() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (series.FilmLengths != null)
            //{
            //    content.AddRange((new FilmLengthContentCreator()).CreateInfoBoxContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxFilmLength() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox negative format content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox negative format content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxNegativeFormat(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxNegativeFormat() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (series.NegativeFormats != null)
            //{
            //    content.AddRange((new NegativeFormatContentCreator()).CreateInfoBoxContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxNegativeFormat() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox cinematographic process content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox cinematographic process content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxCinematographicProcess(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxCinematographicProcess() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (series.CinematographicProcesses != null)
            //{
            //    content.AddRange((new CinematographicProcessContentCreator()).CreateInfoBoxContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxCinematographicProcess() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox printed film format content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox printed film format content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxPrintedFilmFormat(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxPrintedFilmFormat() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (series.PrintedFilmFormats != null)
            //{
            //    content.AddRange((new PrintedFilmFormatContentCreator()).CreateInfoBoxContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxPrintedFilmFormat() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted poster chapter content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted poster chapter content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterPoster(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterPoster() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Poster");
            title.Add("de", "Poster");

            // TODO: implement following stuff
            //if (series.Posters != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new PosterContentCreator()).CreateChapterContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterPoster() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted cover chapter content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted cover chapter content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterCover(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterCover() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Cover");
            title.Add("de", "Cover");

            // TODO: implement following stuff
            //if (series.Covers != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new CoverContentCreator()).CreateChapterContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterCover() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted description chapter content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted description chapter content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterDescription(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterDescription() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Descriptions");
            title.Add("de", "Beschreibungen");

            // TODO: implement following stuff
            //if (series.Descriptions != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new DescriptionContentCreator()).CreateChapterContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterDescription() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted review chapter content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted review chapter content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterReview(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterReview() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Reviews");
            title.Add("de", "Rezensionen");

            // TODO: implement following stuff
            //if (series.Reviews != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new ReviewContentCreator()).CreateChapterContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterReview() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted image chapter content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted image chapter content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterImage(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterImage() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Images");
            title.Add("de", "Bilder");

            // TODO: implement following stuff
            //if (series.Images != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new ImageContentCreator()).CreateChapterContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterImage() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted cast and crew chapter content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted cast and crew chapter content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterCastAndCrew(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterCastAndCrew() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Cast and Crew");
            title.Add("de", "Darsteller und Mannschaft");

            // TODO: implement following stuff
            //if (series.x != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new CastAndCrewContentCreator()).CreateChapterContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterCastAndCrew() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted company chapter content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted company chapter content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterCompany(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterCompany() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Company Credits");
            title.Add("de", "Beteiligte Firmen");

            // TODO: implement following stuff
            //if (series.x != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new CompanyCreator()).CreateChapterContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterCompany() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted filming and production chapter content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted filming and production chapter content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterFilmingAndProduction(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterFilmingAndProduction() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Filming and Production");
            title.Add("de", "Produktion");

            // TODO: implement following stuff
            //if (series.x != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new ProductionCreator()).CreateChapterContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterFilmingAndProduction() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted award chapter content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted award chapter content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterAward(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterAward() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Awards");
            title.Add("de", "Auszeichnungen");

            // TODO: implement following stuff
            //if (series.Awards != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new AwardContentCreator()).CreateChapterContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterAward() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted weblink chapter content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted weblink chapter content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterWeblink(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterWeblink() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Other Sites");
            title.Add("de", "Andere Webseiten");

            // TODO: implement following stuff
            //if (series.Weblinks != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new WeblinkContentCreator()).CreateChapterContent(series.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterWeblink() für Series '{series.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted weblink chapter content of a given series.
        /// </summary>
        /// <param name="series">The series that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted weblink chapter content of the series.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterConnection(Series series, string targetLanguageCode, Formatter formatter)
        {
            if (series == null)
            {
                throw new ArgumentNullException(nameof(series));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterConnection() für Series '{series.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Connections to other articles");
            title.Add("de", "Bezüge zu anderen Artikeln");

            if (series.Connection != null)
            {
                content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
                content.AddRange((new ConnectionContentCreator()).CreateSectionContent(series.Connection, targetLanguageCode, formatter));
            }

            Logger.Trace($"CreateChapterConnection() für Series '{series.OriginalTitle}' beendet");

            return content;
        }
    }
}
