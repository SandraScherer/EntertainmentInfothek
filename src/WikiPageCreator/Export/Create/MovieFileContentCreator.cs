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
            CreateInfoBoxType(targetLanguageCode);
            CreateInfoBoxOriginalReleaseDate(targetLanguageCode);
            CreateInfoBoxBudget(targetLanguageCode);
            CreateInfoBoxWorldwideGross(targetLanguageCode);
            CreateInfoBoxRuntime(targetLanguageCode);
            CreateInfoBoxGenre(targetLanguageCode);
            CreateInfoBoxCountry(targetLanguageCode);
            CreateInfoBoxLanguage(targetLanguageCode);
            CreateInfoBoxColor(targetLanguageCode);
            CreateInfoBoxAspectRatio(targetLanguageCode);
            CreateInfoBoxEnd(targetLanguageCode);

            CreateCastAndCrewChapter(targetLanguageCode);

            CreateConnectionChapter(targetLanguageCode);

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
            Content.Add($"   @version {Movie.Status.EnglishTitle}: {Movie.LastUpdated}");
            Content.Add(Formatter.EndComment());
            Content.Add("");

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

                Content.Add(Formatter.AsHeading1(Movie.EnglishTitle));
                Content.Add("");
            }
            else if (targetLanguageCode.Equals("de") && !String.IsNullOrEmpty(Movie.GermanTitle))
            {
                Logger.Trace($"Title: '{Movie.GermanTitle}' (deutsch)");

                Content.Add(Formatter.AsHeading1(Movie.GermanTitle));
                Content.Add("");
            }
            else
            {
                Logger.Trace($"Title: '{Movie.OriginalTitle}' (original)");

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
            Content.Add(Formatter.DefineTable(445, width));

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
        /// Creates the formatted infobox type of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode"></param>
        public void CreateInfoBoxType(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxType() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (Movie.Type != null)
            {
                Logger.Trace($"Type: '{Movie.Type.ID}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "info" };

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Type";
                    data[1] = Formatter.AsInternalLink(path, Movie.Type.EnglishTitle, Movie.Type.EnglishTitle);
                    Content.Add(Formatter.AsTableRow(data));
                }
                else // incl. case "de"
                {
                    data[0] = "Typ";
                    data[1] = Formatter.AsInternalLink(path, Movie.Type.EnglishTitle, Movie.Type.GermanTitle);
                    Content.Add(Formatter.AsTableRow(data));
                }
            }
        }

        /// <summary>
        /// Creates the formatted infobox release date of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxOriginalReleaseDate(string targetLanguageCode)
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
                string[] path = { targetLanguageCode, "date" };

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

        /// <summary>
        /// Creates the formatted infobox budget of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxBudget(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxBudget() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (!String.IsNullOrEmpty(Movie.Budget))
            {
                Logger.Trace($"Budget: '{Movie.Budget}'");

                string[] data = new string[2];

                data[0] = "Budget";
                data[1] = $"{Movie.Budget}";
                Content.Add(Formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxBudget() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");
        }

        /// <summary>
        /// Creates the formatted infobox  of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxWorldwideGross(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxWorldwideGross() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (!String.IsNullOrEmpty(Movie.WorldwideGross))
            {
                Logger.Trace($"Einspielergebnis: '{Movie.Budget}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "date" };

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Worldwide Gross";
                }
                else // incl. case "de"
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
                Content.Add(Formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxWorldwideGross() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox runtime of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxRuntime(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxRuntime() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (Movie.Runtimes.Count > 0)
            {
                Logger.Trace($"Anzahl Runtimes: '{Movie.Runtimes.Count}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "info" };

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Runtime";
                    data[1] = $"{Movie.Runtimes[0].Runtime} min. ({Formatter.AsInternalLink(path, Movie.Runtimes[0].Edition.EnglishTitle, Movie.Runtimes[0].Edition.EnglishTitle)})";
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Genres.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        data[1] = $"{Movie.Runtimes[i].Runtime} min. ({Formatter.AsInternalLink(path, Movie.Runtimes[i].Edition.EnglishTitle, Movie.Runtimes[i].Edition.EnglishTitle)})";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Laufzeit";
                    data[1] = $"{Movie.Runtimes[0].Runtime} min. ({Formatter.AsInternalLink(path, Movie.Runtimes[0].Edition.EnglishTitle, Movie.Runtimes[0].Edition.GermanTitle)})";
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Genres.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        data[1] = $"{Movie.Runtimes[i].Runtime} min. ({Formatter.AsInternalLink(path, Movie.Runtimes[i].Edition.EnglishTitle, Movie.Runtimes[i].Edition.GermanTitle)})";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxRuntime() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox genre of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxGenre(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxGenre() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (Movie.Genres.Count > 0)
            {
                Logger.Trace($"Anzahl Genres: '{Movie.Genres.Count}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "info" };

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Genre";
                    data[1] = Formatter.AsInternalLink(path, Movie.Genres[0].Genre.EnglishTitle, Movie.Genres[0].Genre.EnglishTitle);
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Genres.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        data[1] = Formatter.AsInternalLink(path, Movie.Genres[i].Genre.EnglishTitle, Movie.Genres[i].Genre.EnglishTitle);
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Genre";
                    data[1] = Formatter.AsInternalLink(path, Movie.Genres[0].Genre.EnglishTitle, Movie.Genres[0].Genre.GermanTitle);
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Genres.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        data[1] = Formatter.AsInternalLink(path, Movie.Genres[i].Genre.EnglishTitle, Movie.Genres[i].Genre.GermanTitle);
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }

                Logger.Trace($"CreateInfoBoxGenre() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
            }
        }

        /// <summary>
        /// Creates the formatted infobox country of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxCountry(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxCountry() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (Movie.Countries.Count > 0)
            {
                Logger.Trace($"Anzahl Countries: '{Movie.Countries.Count}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "info" };

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Production Country";
                    data[1] = Formatter.AsInternalLink(path, Movie.Countries[0].Country.OriginalName, Movie.Countries[0].Country.EnglishName);
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Countries.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        data[1] = Formatter.AsInternalLink(path, Movie.Countries[i].Country.OriginalName, Movie.Countries[i].Country.EnglishName);
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Produktionsland";
                    data[1] = Formatter.AsInternalLink(path, Movie.Countries[0].Country.OriginalName, Movie.Countries[0].Country.GermanName);
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Countries.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        data[1] = Formatter.AsInternalLink(path, Movie.Countries[i].Country.OriginalName, Movie.Countries[i].Country.GermanName);
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }

                Logger.Trace($"CreateInfoBoxCountry() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
            }
        }

        /// <summary>
        /// Creates the formatted infobox language of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateInfoBoxLanguage(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxLanguage() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (Movie.Languages.Count > 0)
            {
                Logger.Trace($"Anzahl Languages: '{Movie.Languages.Count}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "info" };

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Language";
                    data[1] = Formatter.AsInternalLink(path, Movie.Languages[0].Language.OriginalName, Movie.Languages[0].Language.EnglishName);
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Languages.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        data[1] = Formatter.AsInternalLink(path, Movie.Languages[i].Language.OriginalName, Movie.Languages[i].Language.EnglishName);
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Sprache";
                    data[1] = Formatter.AsInternalLink(path, Movie.Languages[0].Language.OriginalName, Movie.Languages[0].Language.GermanName);
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Languages.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        data[1] = Formatter.AsInternalLink(path, Movie.Languages[i].Language.OriginalName, Movie.Languages[i].Language.GermanName);
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxLanguage() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox color of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxColor(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxColor() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (Movie.Colors.Count > 0)
            {
                Logger.Trace($"Anzahl Colors: '{Movie.Colors.Count}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "info" };

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Color";
                    data[1] = Formatter.AsInternalLink(path, Movie.Colors[0].Color.EnglishTitle, Movie.Colors[0].Color.EnglishTitle);
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Colors.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        data[1] = Formatter.AsInternalLink(path, Movie.Colors[i].Color.EnglishTitle, Movie.Colors[i].Color.EnglishTitle);
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Farbe";
                    data[1] = Formatter.AsInternalLink(path, Movie.Colors[0].Color.EnglishTitle, Movie.Colors[0].Color.GermanTitle);
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Colors.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        data[1] = Formatter.AsInternalLink(path, Movie.Colors[i].Color.EnglishTitle, Movie.Colors[i].Color.GermanTitle);
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxColor() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox aspect ratio of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxAspectRatio(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxAspectRatio() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (Movie.AspectRatios.Count > 0)
            {
                Logger.Trace($"Anzahl AspectRatios: '{Movie.AspectRatios.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Aspect Ratio";
                    data[1] = $"{Movie.AspectRatios[0].AspectRatio.Ratio} {Movie.AspectRatios[0].Details}";
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.AspectRatios.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        data[1] = $"{Movie.AspectRatios[i].AspectRatio.Ratio} {Movie.AspectRatios[i].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Bildformat";
                    data[1] = $"{Movie.AspectRatios[0].AspectRatio.Ratio} {Movie.AspectRatios[0].Details}";
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.AspectRatios.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        data[1] = $"{Movie.AspectRatios[i].AspectRatio.Ratio} {Movie.AspectRatios[i].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxAspectRatio() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted cast and crew chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateCastAndCrewChapter(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateCastAndCrewChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (targetLanguageCode.Equals("en"))
            {
                Content.Add(Formatter.AsHeading2("Cast and Crew"));
            }
            else // incl. case "de"
            {
                Content.Add(Formatter.AsHeading2("Darsteller und Mannschaft"));
            }

            // Directors
            if (Movie.Directors.Count > 0)
            {
                Logger.Trace($"Anzahl Directors: '{Movie.Directors.Count}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "biography" };

                if (targetLanguageCode.Equals("en"))
                {
                    Content.Add(Formatter.AsHeading3("Director"));
                }
                else // incl. case "de"
                {
                    Content.Add(Formatter.AsHeading3("Regie"));
                }

                for (int i = 0; i < Movie.Directors.Count; i++)
                {
                    if (!String.IsNullOrEmpty(Movie.Directors[i].Person.FirstName) && !String.IsNullOrEmpty(Movie.Directors[i].Person.LastName) && !String.IsNullOrEmpty(Movie.Directors[i].Person.NameAddOn))
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{Movie.Directors[i].Person.FirstName} {Movie.Directors[i].Person.LastName} {Movie.Directors[i].Person.NameAddOn}");
                    }
                    else if (!String.IsNullOrEmpty(Movie.Directors[i].Person.FirstName) && !String.IsNullOrEmpty(Movie.Directors[i].Person.LastName))
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{Movie.Directors[i].Person.FirstName} {Movie.Directors[i].Person.LastName}");
                    }
                    else if (!String.IsNullOrEmpty(Movie.Directors[i].Person.LastName) && !String.IsNullOrEmpty(Movie.Directors[i].Person.NameAddOn))
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{Movie.Directors[i].Person.LastName} {Movie.Directors[i].Person.NameAddOn}");
                    }
                    else
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{Movie.Directors[i].Person.LastName}");
                    }

                    if (!String.IsNullOrEmpty(Movie.Directors[i].Role) && !String.IsNullOrEmpty(Movie.Directors[i].Details))
                    {
                        data[1] = $"({Movie.Directors[i].Role}) {Movie.Directors[i].Details}";
                    }
                    else if (!String.IsNullOrEmpty(Movie.Directors[i].Role))
                    {
                        data[1] = $"({Movie.Directors[i].Role}";
                    }
                    else if (!String.IsNullOrEmpty(Movie.Directors[i].Details))
                    {
                        data[1] = $"({Movie.Directors[i].Details}";
                    }
                    else
                    {
                        data[1] = "";
                    }
                    Content.Add(Formatter.AsTableRow(data));
                }
                Content.Add("");
                Content.Add("");
            }
        }

        /// <summary>
        /// Creates the formatted connection chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateConnectionChapter(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateConnectionChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (Movie.Connection != null)
            {
                Logger.Trace($"Connection: '{Movie.Connection.Title}'");

                if (targetLanguageCode.Equals("en"))
                {
                    Content.Add(Formatter.AsHeading2("Connections to other articles"));
                }
                else // incl. case "de"
                {
                    Content.Add(Formatter.AsHeading2("Bezüge zu anderen Artikeln"));
                }
                if (Movie.Connection.BaseConnection == null)
                    Content.Add(Formatter.AsInsertPage(targetLanguageCode + ":navigation:" + Movie.Connection.ID));
                else
                    Content.Add(Formatter.AsInsertPage(targetLanguageCode + ":navigation:" + Movie.Connection.BaseConnection.ID));

                Content.Add("");
                Content.Add("");
            }

            Logger.Trace($"CreateConnectionChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }
    }
}
