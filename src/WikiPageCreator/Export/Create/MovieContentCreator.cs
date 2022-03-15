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
    public class MovieContentCreator : ArticleContentCreator, IFileContentCreatable
    {
        // --- Properties ---

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new MovieContentCreator.
        /// </summary>
        public MovieContentCreator()
        {
            Logger.Trace($"MovieContentCreator() angelegt");
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

            Logger.Trace($"CreateInfoBoxContent() für Movie {((Movie)entry).OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            content.AddRange(base.CreateInfoBoxContent((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxLogo((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxReleaseDate((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxGenre((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxCertification((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxCountry((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxLanguage((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxBudget((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxWorldwideGross((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxRuntime((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxSoundMix((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxColor((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxAspectRatio((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxCamera((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxLaboratory((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxFilmLength((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxNegativeFormat((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxCinematographicProcess((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxPrintedFilmFormat((Movie)entry, targetLanguageCode, formatter));

            Logger.Trace($"CreateInfoBoxContent() für Movie {((Movie)entry).OriginalTitle}' beendet");

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

            Logger.Trace($"CreateChapterContent() für Movie '{((Movie)entry).OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            content.AddRange(CreateChapterPoster((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterCover((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterDescription((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterReview((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterImage((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterCastAndCrew((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterCompany((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterFilmingAndProduction((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterAward((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterWeblink((Movie)entry, targetLanguageCode, formatter));
            content.AddRange(CreateChapterConnection((Movie)entry, targetLanguageCode, formatter));

            Logger.Trace($"CreateInfoBoxContent() für Movie {((Movie)entry).OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox logo content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox logo content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxLogo(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxReleaseDate() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (movie.Logo != null)
            //{
            //    content.AddRange((new ImageContentCreator()).CreateInfoBoxContent(movie.Logo, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxReleaseDate() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox genre content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox genre content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxGenre(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxGenre() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (movie.Genres != null)
            //{
            //    content.AddRange((new GenreContentCreator()).CreateInfoBoxContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxGenre() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox certification content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox certification content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxCertification(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxCertification() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (movie.Certifications != null)
            //{
            //    content.AddRange((new CertificationContentCreator()).CreateInfoBoxContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxCertification() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox country content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox country content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxCountry(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxCountry() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (movie.Countries != null)
            //{
            //    content.AddRange((new CountryContentCreator()).CreateInfoBoxContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxCountry() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox language content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox language content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxLanguage(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxLanguage() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (movie.Languages != null)
            //{
            //    content.AddRange((new LanguageContentCreator()).CreateInfoBoxContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxLanguage() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox budget content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox budget content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxBudget(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxBudget() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];

            if (!String.IsNullOrEmpty(movie.Budget))
            {
                Logger.Trace($"Budget: {movie.Budget}");
                data[0] = "Budget";
                data[1] = $"{movie.Budget}";

                content.Add(formatter.AsTableRow(data));
            }
            Logger.Trace($"CreateInfoBoxBudget() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox worldwide gross content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox worldwide gross content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxWorldwideGross(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxWorldwideGross() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];
            string[] path = { targetLanguageCode, "date" };

            if (!String.IsNullOrEmpty(movie.WorldwideGross))
            {
                Logger.Trace($"Worldwide Gross: {movie.WorldwideGross}");

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Worldwide Gross";
                }
                else //incl. case "de"
                {
                    data[0] = "Einspielergebnis (weltweit)";
                }

                if (!String.IsNullOrEmpty(movie.WorldwideGrossDate))
                {
                    data[1] = $"{movie.WorldwideGross} ({formatter.AsInternalLink(path, movie.WorldwideGrossDate, movie.WorldwideGrossDate)})";
                }
                else
                {
                    data[1] = $"{movie.WorldwideGross}";
                }
                content.Add(formatter.AsTableRow(data));
            }
            Logger.Trace($"CreateInfoBoxWorldwideGross() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox runtime content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox runtime content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxRuntime(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxRuntime() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (movie.Runtimes != null)
            //{
            //    content.AddRange((new RuntimeContentCreator()).CreateInfoBoxContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxRuntime() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox soundmix content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox soundmix content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxSoundMix(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxSoundMix() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (movie.SoundMixes != null)
            //{
            //    content.AddRange((new SoundMixContentCreator()).CreateInfoBoxContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxSoundMix() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox color content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox color content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxColor(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxColor() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (movie.Colors != null)
            //{
            //    content.AddRange((new ColorContentCreator()).CreateInfoBoxContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxColor() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox aspect ratio content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox aspect ratio content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxAspectRatio(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxAspectRatio() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (movie.AspectRatios != null)
            //{
            //    content.AddRange((new AspectRatioContentCreator()).CreateInfoBoxContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxAspectRatio() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox camera content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox camera content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxCamera(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxCamera() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (movie.Cameras != null)
            //{
            //    content.AddRange((new CameraContentCreator()).CreateInfoBoxContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxCamera() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox laboratory content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox laboratory content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxLaboratory(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxLaboratory() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (movie.Laboratories != null)
            //{
            //    content.AddRange((new LaboratoryContentCreator()).CreateInfoBoxContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxLaboratory() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox film length content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox film length content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxFilmLength(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxFilmLength() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (movie.FilmLengths != null)
            //{
            //    content.AddRange((new FilmLengthContentCreator()).CreateInfoBoxContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxFilmLength() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox negative format content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox negative format content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxNegativeFormat(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxNegativeFormat() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (movie.NegativeFormats != null)
            //{
            //    content.AddRange((new NegativeFormatContentCreator()).CreateInfoBoxContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxNegativeFormat() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox cinematographic process content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox cinematographic process content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxCinematographicProcess(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxCinematographicProcess() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (movie.CinematographicProcesses != null)
            //{
            //    content.AddRange((new CinematographicProcessContentCreator()).CreateInfoBoxContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxCinematographicProcess() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox printed film format content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox printed film format content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxPrintedFilmFormat(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxPrintedFilmFormat() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // TODO: implement following stuff
            //if (movie.PrintedFilmFormats != null)
            //{
            //    content.AddRange((new PrintedFilmFormatContentCreator()).CreateInfoBoxContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateInfoBoxPrintedFilmFormat() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted poster chapter content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted poster chapter content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterPoster(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterPoster() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Poster");
            title.Add("de", "Poster");

            // TODO: implement following stuff
            //if (movie.Posters != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new PosterContentCreator()).CreateChapterContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterPoster() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted cover chapter content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted cover chapter content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterCover(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterCover() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Cover");
            title.Add("de", "Cover");

            // TODO: implement following stuff
            //if (movie.Covers != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new CoverContentCreator()).CreateChapterContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterCover() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted description chapter content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted description chapter content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterDescription(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterDescription() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Descriptions");
            title.Add("de", "Beschreibungen");

            // TODO: implement following stuff
            //if (movie.Descriptions != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new DescriptionContentCreator()).CreateChapterContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterDescription() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted review chapter content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted review chapter content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterReview(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterReview() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Reviews");
            title.Add("de", "Rezensionen");

            // TODO: implement following stuff
            //if (movie.Reviews != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new ReviewContentCreator()).CreateChapterContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterReview() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted image chapter content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted image chapter content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterImage(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterImage() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Images");
            title.Add("de", "Bilder");

            // TODO: implement following stuff
            //if (movie.Images != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new ImageContentCreator()).CreateChapterContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterImage() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted cast and crew chapter content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted cast and crew chapter content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterCastAndCrew(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterCastAndCrew() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Cast and Crew");
            title.Add("de", "Darsteller und Mannschaft");

            // TODO: implement following stuff
            //if (movie.x != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new CastAndCrewContentCreator()).CreateChapterContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterCastAndCrew() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted company chapter content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted company chapter content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterCompany(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterCompany() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Company Credits");
            title.Add("de", "Beteiligte Firmen");

            // TODO: implement following stuff
            //if (movie.x != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new CompanyCreator()).CreateChapterContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterCompany() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted filming and production chapter content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted filming and production chapter content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterFilmingAndProduction(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterFilmingAndProduction() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Filming and Production");
            title.Add("de", "Produktion");

            // TODO: implement following stuff
            //if (movie.x != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new ProductionCreator()).CreateChapterContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterFilmingAndProduction() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted award chapter content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted award chapter content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterAward(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterAward() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Awards");
            title.Add("de", "Auszeichnungen");

            // TODO: implement following stuff
            //if (movie.Awards != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new AwardContentCreator()).CreateChapterContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterAward() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted weblink chapter content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted weblink chapter content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterWeblink(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterWeblink() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Other Sites");
            title.Add("de", "Andere Webseiten");

            // TODO: implement following stuff
            //if (movie.Weblinks != null)
            //{
            //    content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
            //    content.AddRange((new WeblinkContentCreator()).CreateChapterContent(movie.Genres, targetLanguageCode, formatter));
            //}

            Logger.Trace($"CreateChapterWeblink() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted weblink chapter content of a given movie.
        /// </summary>
        /// <param name="movie">The movie that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted weblink chapter content of the movie.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterConnection(Movie movie, string targetLanguageCode, Formatter formatter)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterConnection() für Movie '{movie.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Connections to other articles");
            title.Add("de", "Bezüge zu anderen Artikeln");

            if (movie.Connection != null)
            {
                content.AddRange(CreateNewChapter(title, targetLanguageCode, formatter));
                content.AddRange((new ConnectionContentCreator()).CreateSectionContent(movie.Connection, targetLanguageCode, formatter));
            }

            Logger.Trace($"CreateChapterConnection() für Movie '{movie.OriginalTitle}' beendet");

            return content;
        }
    }
}
