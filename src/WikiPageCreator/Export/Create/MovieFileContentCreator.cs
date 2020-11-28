// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
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
using System;
using System.Collections.Generic;
using System.Text;
using WikiPageCreator.Export.Format;

namespace WikiPageCreator.Export.Create
{
    /// <summary>
    /// Provides a file content crator for a movie.
    /// </summary>
    public class MovieFileContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The formatter to be used to format the content of the movie.
        /// </summary>
        public Formatter Formatter { get; set; } = new DokuWikiFormatter();

        /// <summary>
        /// The movie of the movie file content creator.
        /// </summary>
        public Movie Movie { get; set; }

        /// <summary>
        /// The Content of the movie file content creator.
        /// </summary>
        public List<string> Content { get; set; } = new List<string>();

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new movie file content creator with the given movie.
        /// </summary>
        /// <param name="movie"></param>
        public MovieFileContentCreator(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            Logger.Trace($"MovieFileContentCreator() angelegt");

            Movie = movie;
        }

        // --- Methods ---

        /// <summary>
        /// Creates the file name of the movie page.
        /// </summary>
        /// <returns>The formatted file name.</returns>
        public string GetFileName()
        {
            Logger.Trace($"GetFileName() für Movie '{Movie.OriginalTitle}' aufgerufen");

            return Formatter.AsPagename($"{Movie.OriginalTitle} ({Movie.ReleaseDate[0..4]})");
        }

        /// <summary>
        /// Creates the formatted content of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <returns>The formatted content of the movie.</returns>
        public List<string> CreateContent(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateContent() für Movie '{Movie.OriginalTitle}' gestartet");

            CreateHeader(targetLanguageCode);
            CreateTitle(targetLanguageCode);

            CreateInfoBoxHeader(targetLanguageCode);
            CreateInfoBoxTitle(targetLanguageCode);
            CreateInfoBoxOriginalReleaseDate(targetLanguageCode);
            CreateInfoBoxEnd(targetLanguageCode);

            CreateFooter(targetLanguageCode);

            Logger.Trace($"CreateContent() für Artikel '{Movie.OriginalTitle}' beendet");

            return Content;
        }

        // Header and End (Footer)

        /// <summary>
        /// Creates the formatted header of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateHeader(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateHeader() für Movie '{Movie.OriginalTitle}' gestartet");

            Content.Add(Formatter.DisableCache());
            Content.Add(Formatter.DisableTOC());

            Content.Add(Formatter.BeginComment());
            Content.Add($"   {Movie.OriginalTitle}");
            Content.Add($"");
            Content.Add($"   @author  WikiPageCreator");
            Content.Add($"   @date    {DateTime.Now:yyyy-MM-dd}");
            Content.Add($"   @version {Movie.Status.Details}: {Movie.LastUpdated}");
            Content.Add(Formatter.EndComment());

            Logger.Trace($"CreateHeader() für Movie '{Movie.OriginalTitle}' beendet");
        }

        /// <summary>
        /// Creates the formatted footer of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateFooter(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateHeader() für Movie '{Movie.OriginalTitle}' gestartet");

            // nothing to do at the moment

            Logger.Trace($"CreateHeader() für Movie '{Movie.OriginalTitle}' beendet");
        }

        // Title

        /// <summary>
        /// Creates the formatted title of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateTitle(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateTitle() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (targetLanguageCode.Equals("en") && !String.IsNullOrEmpty(Movie.EnglishTitle))
            {
                Logger.Trace($"Title: '{Movie.EnglishTitle}' (englisch)");

                Content.Add("");
                Content.Add(Formatter.AsHeading1(Movie.EnglishTitle));
                Content.Add("");
            }
            else if (targetLanguageCode.Equals("de") && !String.IsNullOrEmpty(Movie.GermanTitle))
            {
                Logger.Trace($"Title: '{Movie.GermanTitle}' (deutsch)");

                Content.Add("");
                Content.Add(Formatter.AsHeading1(Movie.GermanTitle));
                Content.Add("");
            }
            else
            {
                Logger.Trace($"Title: '{Movie.OriginalTitle}' (original)");

                Content.Add("");
                Content.Add(Formatter.AsHeading1(Movie.OriginalTitle));
                Content.Add("");
            }

            Logger.Trace($"CreateTitle() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        // Info Box: Header and End (Footer)

        /// <summary>
        /// Creates the formatted infobox header of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxHeader(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxHeader() für Movie '{Movie.OriginalTitle}' gestartet");

            Content.Add(Formatter.BeginBox(475, Alignment.Right));
            int[] width = { 30, 70 };
            Content.Add(Formatter.DefineTable(450, width));

            Logger.Trace($"CreateInfoBoxHeader() für Movie '{Movie.OriginalTitle}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox footer of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxEnd(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxEnd() für Movie '{Movie.OriginalTitle}' gestartet");

            Content.Add(Formatter.EndBox());
            Content.Add("");

            Logger.Trace($"CreateInfoBoxEnd() für Movie '{Movie.OriginalTitle}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox title of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxTitle(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxTitle() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            string[] data = new string[2];

            if (targetLanguageCode.Equals("en"))
            {
                data[0] = "Original Title";
                data[1] = Movie.OriginalTitle;
                Content.Add(Formatter.AsTableRow(data));
            }
            else // incl. case "de"
            {
                data[0] = "Originaltitel";
                data[1] = Movie.OriginalTitle;
                Content.Add(Formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxTitle() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox release date of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public  void CreateInfoBoxOriginalReleaseDate(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxOriginalReleaseDate() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (!String.IsNullOrEmpty(Movie.ReleaseDate))
            {
                Logger.Trace($"Erstausstrahlung: '{Movie.ReleaseDate}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "dates" };

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Original Release Date";
                    data[1] = Formatter.AsInternalLink(path, Movie.ReleaseDate, Movie.ReleaseDate);
                    Content.Add(Formatter.AsTableRow(data));
                }
                else // incl. case "de"
                {
                    data[0] = "Erstausstrahlung";
                    data[1] = Formatter.AsInternalLink(path, Movie.ReleaseDate, Movie.ReleaseDate);
                    Content.Add(Formatter.AsTableRow(data));
                }
            }

            Logger.Trace($"CreateInfoBoxOriginalReleaseDate() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }
    }
}
