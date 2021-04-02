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
            CreateInfoBoxGenre(targetLanguageCode);
            CreateInfoBoxCertification(targetLanguageCode);
            CreateInfoBoxCountry(targetLanguageCode);
            CreateInfoBoxLanguage(targetLanguageCode);
            CreateInfoBoxBudget(targetLanguageCode);
            CreateInfoBoxWorldwideGross(targetLanguageCode);
            CreateInfoBoxRuntime(targetLanguageCode);
            CreateInfoBoxSoundMix(targetLanguageCode);
            CreateInfoBoxColor(targetLanguageCode);
            CreateInfoBoxAspectRatio(targetLanguageCode);
            CreateInfoBoxCamera(targetLanguageCode);
            CreateInfoBoxLaboratory(targetLanguageCode);
            CreateInfoBoxFilmLength(targetLanguageCode);
            CreateInfoBoxNegativeFormat(targetLanguageCode);
            CreateInfoBoxCinematographicProcess(targetLanguageCode);
            CreateInfoBoxPrintedFilmFormat(targetLanguageCode);
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
        /// Creates the formatted infobox title field of the movie page.
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
        /// Creates the formatted infobox type field of the movie page.
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

            Logger.Trace($"CreateInfoBoxType() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox release date field of the movie page.
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
        /// Creates the formatted infobox genre field of the movie page.
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
                    if (!String.IsNullOrEmpty(Movie.Genres[0].Details))
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Genres[0].Genre.EnglishTitle, Movie.Genres[0].Genre.EnglishTitle)} {Movie.Genres[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Genres[0].Genre.EnglishTitle, Movie.Genres[0].Genre.EnglishTitle)}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.Genres.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Genres[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Genres[i].Genre.EnglishTitle, Movie.Genres[i].Genre.EnglishTitle)} {Movie.Genres[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Genres[i].Genre.EnglishTitle, Movie.Genres[i].Genre.EnglishTitle)}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Genre";
                    if (!String.IsNullOrEmpty(Movie.Genres[0].Details))
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Genres[0].Genre.EnglishTitle, Movie.Genres[0].Genre.GermanTitle)} {Movie.Genres[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Genres[0].Genre.EnglishTitle, Movie.Genres[0].Genre.GermanTitle)}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.Genres.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Genres[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Genres[i].Genre.EnglishTitle, Movie.Genres[i].Genre.GermanTitle)} {Movie.Genres[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Genres[i].Genre.EnglishTitle, Movie.Genres[i].Genre.GermanTitle)}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxGenre() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox certification field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxCertification(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxCertification() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (Movie.Certifications.Count > 0)
            {
                Logger.Trace($"Anzahl Certifications: '{Movie.Certifications.Count}'");

                string[] data = new string[2];
                string[] path = { ".", "certification" };

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Certification";
                    if (!String.IsNullOrEmpty(Movie.Certifications[0].Details))
                    {
                        data[1] = $"{Formatter.AsImage(path, Movie.Certifications[0].Certification.Image.FileName, 75)} {Movie.Certifications[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsImage(path, Movie.Certifications[0].Certification.Image.FileName, 75)}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.Certifications.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Certifications[i].Details))
                        {
                            data[1] = $"{Formatter.AsImage(path, Movie.Certifications[i].Certification.Image.FileName, 75)} {Movie.Certifications[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsImage(path, Movie.Certifications[i].Certification.Image.FileName, 75)}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Altersfreigabe";
                    if (!String.IsNullOrEmpty(Movie.Certifications[0].Details))
                    {
                        data[1] = $"{Formatter.AsImage(path, Movie.Certifications[0].Certification.Image.FileName, 75)} {Movie.Certifications[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsImage(path, Movie.Certifications[0].Certification.Image.FileName, 75)}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.Certifications.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Certifications[i].Details))
                        {
                            data[1] = $"{Formatter.AsImage(path, Movie.Certifications[i].Certification.Image.FileName, 75)} {Movie.Certifications[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsImage(path, Movie.Certifications[i].Certification.Image.FileName, 75)}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxCertification() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox country field of the movie page.
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
                    if (!String.IsNullOrEmpty(Movie.Countries[0].Details))
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Countries[0].Country.OriginalName, Movie.Countries[0].Country.EnglishName)} {Movie.Countries[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Countries[0].Country.OriginalName, Movie.Countries[0].Country.EnglishName)}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.Countries.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Countries[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Countries[i].Country.OriginalName, Movie.Countries[i].Country.EnglishName)} {Movie.Countries[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Countries[i].Country.OriginalName, Movie.Countries[i].Country.EnglishName)}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Produktionsland";
                    if (!String.IsNullOrEmpty(Movie.Countries[0].Details))
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Countries[0].Country.OriginalName, Movie.Countries[0].Country.GermanName)} {Movie.Countries[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Countries[0].Country.OriginalName, Movie.Countries[0].Country.GermanName)}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.Countries.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Countries[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Countries[i].Country.OriginalName, Movie.Countries[i].Country.GermanName)} {Movie.Countries[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Countries[i].Country.OriginalName, Movie.Countries[i].Country.GermanName)}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxCountry() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox language field of the movie page.
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
                    if (!String.IsNullOrEmpty(Movie.Languages[0].Details))
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Languages[0].Language.OriginalName, Movie.Languages[0].Language.EnglishName)} {Movie.Languages[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Languages[0].Language.OriginalName, Movie.Languages[0].Language.EnglishName)}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.Languages.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Languages[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Languages[i].Language.OriginalName, Movie.Languages[i].Language.EnglishName)} {Movie.Languages[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Languages[i].Language.OriginalName, Movie.Languages[i].Language.EnglishName)}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Sprache";
                    if (!String.IsNullOrEmpty(Movie.Languages[0].Details))
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Languages[0].Language.OriginalName, Movie.Languages[0].Language.GermanName)} {Movie.Languages[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Languages[0].Language.OriginalName, Movie.Languages[0].Language.GermanName)}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.Languages.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Languages[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Languages[i].Language.OriginalName, Movie.Languages[i].Language.GermanName)} {Movie.Languages[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Languages[i].Language.OriginalName, Movie.Languages[i].Language.GermanName)}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxLanguage() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox budget field of the movie page.
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

            Logger.Trace($"CreateInfoBoxBudget() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox worldwide gross field of the movie page.
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
                    if (!String.IsNullOrEmpty(Movie.WorldwideGrossDate))
                    {
                        data[1] = $"{Movie.WorldwideGross} ({Formatter.AsInternalLink(path, Movie.WorldwideGrossDate, Movie.WorldwideGrossDate)})";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Movie.WorldwideGross}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Einspielergebnis (weltweit)";
                    if (!String.IsNullOrEmpty(Movie.WorldwideGrossDate))
                    {
                        data[1] = $"{Movie.WorldwideGross} ({Formatter.AsInternalLink(path, Movie.WorldwideGrossDate, Movie.WorldwideGrossDate)})";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Movie.WorldwideGross}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxWorldwideGross() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox runtime field of the movie page.
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
                    if (!String.IsNullOrEmpty(Movie.Runtimes[0].Details))
                    {
                        data[1] = $"{Movie.Runtimes[0].Runtime} min. ({Formatter.AsInternalLink(path, Movie.Runtimes[0].Edition.EnglishTitle, Movie.Runtimes[0].Edition.EnglishTitle)}) {Movie.Runtimes[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Movie.Runtimes[0].Runtime} min. ({Formatter.AsInternalLink(path, Movie.Runtimes[0].Edition.EnglishTitle, Movie.Runtimes[0].Edition.EnglishTitle)})";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.Runtimes.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Runtimes[i].Details))
                        {
                            data[1] = $"{Movie.Runtimes[i].Runtime} min. ({Formatter.AsInternalLink(path, Movie.Runtimes[i].Edition.EnglishTitle, Movie.Runtimes[i].Edition.EnglishTitle)}) {Movie.Runtimes[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Movie.Runtimes[i].Runtime} min. ({Formatter.AsInternalLink(path, Movie.Runtimes[i].Edition.EnglishTitle, Movie.Runtimes[i].Edition.EnglishTitle)})";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Laufzeit";
                    if (!String.IsNullOrEmpty(Movie.Runtimes[0].Details))
                    {
                        data[1] = $"{Movie.Runtimes[0].Runtime} min. ({Formatter.AsInternalLink(path, Movie.Runtimes[0].Edition.EnglishTitle, Movie.Runtimes[0].Edition.GermanTitle)}) {Movie.Runtimes[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Movie.Runtimes[0].Runtime} min. ({Formatter.AsInternalLink(path, Movie.Runtimes[0].Edition.EnglishTitle, Movie.Runtimes[0].Edition.GermanTitle)})";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.Runtimes.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Runtimes[i].Details))
                        {
                            data[1] = $"{Movie.Runtimes[i].Runtime} min. ({Formatter.AsInternalLink(path, Movie.Runtimes[i].Edition.EnglishTitle, Movie.Runtimes[i].Edition.GermanTitle)}) {Movie.Runtimes[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Movie.Runtimes[i].Runtime} min. ({Formatter.AsInternalLink(path, Movie.Runtimes[i].Edition.EnglishTitle, Movie.Runtimes[i].Edition.GermanTitle)})";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxRuntime() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox sound mixes field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxSoundMix(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxSoundMixes() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (Movie.SoundMixes.Count > 0)
            {
                Logger.Trace($"Anzahl Colors: '{Movie.SoundMixes.Count}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "info" };

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Sound Mix";
                    if (!String.IsNullOrEmpty(Movie.SoundMixes[0].Details))
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.SoundMixes[0].SoundMix.EnglishTitle, Movie.SoundMixes[0].SoundMix.EnglishTitle)} {Movie.SoundMixes[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.SoundMixes[0].SoundMix.EnglishTitle, Movie.SoundMixes[0].SoundMix.EnglishTitle)}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.SoundMixes.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.SoundMixes[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.SoundMixes[i].SoundMix.EnglishTitle, Movie.SoundMixes[i].SoundMix.EnglishTitle)} {Movie.SoundMixes[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.SoundMixes[i].SoundMix.EnglishTitle, Movie.SoundMixes[i].SoundMix.EnglishTitle)}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Tonmischung";
                    if (!String.IsNullOrEmpty(Movie.SoundMixes[0].Details))
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.SoundMixes[0].SoundMix.EnglishTitle, Movie.SoundMixes[0].SoundMix.GermanTitle)} {Movie.SoundMixes[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.SoundMixes[0].SoundMix.EnglishTitle, Movie.SoundMixes[0].SoundMix.GermanTitle)}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.SoundMixes.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.SoundMixes[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.SoundMixes[i].SoundMix.EnglishTitle, Movie.SoundMixes[i].SoundMix.GermanTitle)} {Movie.SoundMixes[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.SoundMixes[i].SoundMix.EnglishTitle, Movie.SoundMixes[i].SoundMix.GermanTitle)}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxBoxSound() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox color field of the movie page.
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
                    if (!String.IsNullOrEmpty(Movie.Colors[0].Details))
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Colors[0].Color.EnglishTitle, Movie.Colors[0].Color.EnglishTitle)} {Movie.Colors[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Colors[0].Color.EnglishTitle, Movie.Colors[0].Color.EnglishTitle)}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.Colors.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Colors[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Colors[i].Color.EnglishTitle, Movie.Colors[i].Color.EnglishTitle)} {Movie.Colors[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Colors[i].Color.EnglishTitle, Movie.Colors[i].Color.EnglishTitle)}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Farbe";
                    if (!String.IsNullOrEmpty(Movie.Colors[0].Details))
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Colors[0].Color.EnglishTitle, Movie.Colors[0].Color.GermanTitle)} {Movie.Colors[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Colors[0].Color.EnglishTitle, Movie.Colors[0].Color.GermanTitle)}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.Colors.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Colors[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Colors[i].Color.EnglishTitle, Movie.Colors[i].Color.GermanTitle)} {Movie.Colors[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Colors[i].Color.EnglishTitle, Movie.Colors[i].Color.GermanTitle)}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxColor() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox aspect ratio field of the movie page.
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
                    if (!String.IsNullOrEmpty(Movie.AspectRatios[0].Details))
                    {
                        data[1] = $"{Movie.AspectRatios[0].AspectRatio.Ratio} {Movie.AspectRatios[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Movie.AspectRatios[0].AspectRatio.Ratio}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.AspectRatios.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.AspectRatios[i].Details))
                        {
                            data[1] = $"{Movie.AspectRatios[i].AspectRatio.Ratio} {Movie.AspectRatios[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Movie.AspectRatios[i].AspectRatio.Ratio}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Bildformat";
                    if (!String.IsNullOrEmpty(Movie.AspectRatios[0].Details))
                    {
                        data[1] = $"{Movie.AspectRatios[0].AspectRatio.Ratio} {Movie.AspectRatios[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Movie.AspectRatios[0].AspectRatio.Ratio}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.AspectRatios.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.AspectRatios[i].Details))
                        {
                            data[1] = $"{Movie.AspectRatios[i].AspectRatio.Ratio} {Movie.AspectRatios[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Movie.AspectRatios[i].AspectRatio.Ratio}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxAspectRatio() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox camera field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxCamera(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxCamera() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (Movie.Cameras.Count > 0)
            {
                Logger.Trace($"Anzahl Cameras: '{Movie.Cameras.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Camera";
                    if (!String.IsNullOrEmpty(Movie.Cameras[0].Details))
                    {
                        data[1] = $"{Movie.Cameras[0].Camera.Name}, {Movie.Cameras[0].Camera.Lense} {Movie.Cameras[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Movie.Cameras[0].Camera.Name}, {Movie.Cameras[0].Camera.Lense}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.Cameras.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Cameras[i].Details))
                        {
                            data[1] = $"{Movie.Cameras[i].Camera.Name}, {Movie.Cameras[i].Camera.Lense} {Movie.Cameras[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Movie.Cameras[i].Camera.Name}, {Movie.Cameras[i].Camera.Lense}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Kamera";
                    if (!String.IsNullOrEmpty(Movie.Cameras[0].Details))
                    {
                        data[1] = $"{Movie.Cameras[0].Camera.Name}, {Movie.Cameras[0].Camera.Lense} {Movie.Cameras[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Movie.Cameras[0].Camera.Name}, {Movie.Cameras[0].Camera.Lense}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.Cameras.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Cameras[i].Details))
                        {
                            data[1] = $"{Movie.Cameras[i].Camera.Name}, {Movie.Cameras[i].Camera.Lense} {Movie.Cameras[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Movie.Cameras[i].Camera.Name}, {Movie.Cameras[i].Camera.Lense}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxCamera() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox laboratory field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxLaboratory(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxLaboratory() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (Movie.Laboratories.Count > 0)
            {
                Logger.Trace($"Anzahl Laboratories: '{Movie.Laboratories.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Laboratory";
                    if (!String.IsNullOrEmpty(Movie.Laboratories[0].Details))
                    {
                        data[1] = $"{Movie.Laboratories[0].Laboratory.Name} {Movie.Laboratories[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Movie.Laboratories[0].Laboratory.Name}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.Laboratories.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Laboratories[i].Details))
                        {
                            data[1] = $"{Movie.Laboratories[i].Laboratory.Name} {Movie.Laboratories[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Movie.Laboratories[i].Laboratory.Name}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Labor";
                    if (!String.IsNullOrEmpty(Movie.Laboratories[0].Details))
                    {
                        data[1] = $"{Movie.Laboratories[0].Laboratory.Name} {Movie.Laboratories[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Movie.Laboratories[0].Laboratory.Name}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.Laboratories.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Laboratories[i].Details))
                        {
                            data[1] = $"{Movie.Laboratories[i].Laboratory.Name} {Movie.Laboratories[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Movie.Laboratories[i].Laboratory.Name}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxLaboratory() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox film length field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxFilmLength(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxFilmLength() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (Movie.FilmLengths.Count > 0)
            {
                Logger.Trace($"Anzahl FilmLengths: '{Movie.FilmLengths.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Film Length";
                    if (!String.IsNullOrEmpty(Movie.FilmLengths[0].Details))
                    {
                        data[1] = $"{Movie.FilmLengths[0].Length} {Movie.FilmLengths[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Movie.FilmLengths[0].Length}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.FilmLengths.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.FilmLengths[i].Details))
                        {
                            data[1] = $"{Movie.FilmLengths[i].Length} {Movie.FilmLengths[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Movie.FilmLengths[i].Length}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Filmlänge";
                    if (!String.IsNullOrEmpty(Movie.FilmLengths[0].Details))
                    {
                        data[1] = $"{Movie.FilmLengths[0].Length} {Movie.FilmLengths[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Movie.FilmLengths[0].Length}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.FilmLengths.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.FilmLengths[i].Details))
                        {
                            data[1] = $"{Movie.FilmLengths[i].Length} {Movie.FilmLengths[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Movie.FilmLengths[i].Length}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxFilmLength() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox negative format field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxNegativeFormat(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxNegativeFormat() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (Movie.NegativeFormats.Count > 0)
            {
                Logger.Trace($"Anzahl NegativeFormats: '{Movie.NegativeFormats.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Negative Format";
                    if (!String.IsNullOrEmpty(Movie.NegativeFormats[0].Details))
                    {
                        data[1] = $"{Movie.NegativeFormats[0].FilmFormat.Name} {Movie.NegativeFormats[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Movie.NegativeFormats[0].FilmFormat.Name}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.NegativeFormats.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.NegativeFormats[i].Details))
                        {
                            data[1] = $"{Movie.NegativeFormats[i].FilmFormat.Name} {Movie.NegativeFormats[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Movie.NegativeFormats[i].FilmFormat.Name}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Negativformat";
                    if (!String.IsNullOrEmpty(Movie.NegativeFormats[0].Details))
                    {
                        data[1] = $"{Movie.NegativeFormats[0].FilmFormat.Name} {Movie.NegativeFormats[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Movie.NegativeFormats[0].FilmFormat.Name}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.NegativeFormats.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.NegativeFormats[i].Details))
                        {
                            data[1] = $"{Movie.NegativeFormats[i].FilmFormat.Name} {Movie.NegativeFormats[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Movie.NegativeFormats[i].FilmFormat.Name}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxNegativeFormat() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox cinematographic process field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxCinematographicProcess(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxCinematographicProcess() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (Movie.CinematographicProcesses.Count > 0)
            {
                Logger.Trace($"Anzahl CinematographicProcesses: '{Movie.CinematographicProcesses.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Cinematographic Process";
                    if (!String.IsNullOrEmpty(Movie.CinematographicProcesses[0].Details))
                    {
                        data[1] = $"{Movie.CinematographicProcesses[0].CinematographicProcess.Name} {Movie.CinematographicProcesses[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Movie.CinematographicProcesses[0].CinematographicProcess.Name}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.CinematographicProcesses.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.CinematographicProcesses[i].Details))
                        {
                            data[1] = $"{Movie.CinematographicProcesses[i].CinematographicProcess.Name} {Movie.CinematographicProcesses[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Movie.CinematographicProcesses[i].CinematographicProcess.Name}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Filmprozess";
                    if (!String.IsNullOrEmpty(Movie.CinematographicProcesses[0].Details))
                    {
                        data[1] = $"{Movie.CinematographicProcesses[0].CinematographicProcess.Name} {Movie.CinematographicProcesses[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Movie.CinematographicProcesses[0].CinematographicProcess.Name}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.CinematographicProcesses.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.CinematographicProcesses[i].Details))
                        {
                            data[1] = $"{Movie.CinematographicProcesses[i].CinematographicProcess.Name} {Movie.CinematographicProcesses[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Movie.CinematographicProcesses[i].CinematographicProcess.Name}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxCinematographicProcess() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox printed film format of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxPrintedFilmFormat(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxPrintedFilmFormat() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (Movie.PrintedFilmFormats.Count > 0)
            {
                Logger.Trace($"Anzahl PrintedFilmFormats: '{Movie.PrintedFilmFormats.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Printed Film Format";
                    if (!String.IsNullOrEmpty(Movie.PrintedFilmFormats[0].Details))
                    {
                        data[1] = $"{Movie.PrintedFilmFormats[0].FilmFormat.Name} {Movie.PrintedFilmFormats[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Movie.PrintedFilmFormats[0].FilmFormat.Name}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.PrintedFilmFormats.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.PrintedFilmFormats[i].Details))
                        {
                            data[1] = $"{Movie.PrintedFilmFormats[i].FilmFormat.Name} {Movie.PrintedFilmFormats[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Movie.PrintedFilmFormats[i].FilmFormat.Name}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Filmformat";
                    if (!String.IsNullOrEmpty(Movie.PrintedFilmFormats[0].Details))
                    {
                        data[1] = $"{Movie.PrintedFilmFormats[0].FilmFormat.Name} {Movie.PrintedFilmFormats[0].Details}";
                        Content.Add(Formatter.AsTableRow(data));
                    }
                    else
                    {
                        data[1] = $"{Movie.PrintedFilmFormats[0].FilmFormat.Name}";
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    for (int i = 1; i < Movie.PrintedFilmFormats.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.PrintedFilmFormats[i].Details))
                        {
                            data[1] = $"{Movie.PrintedFilmFormats[i].FilmFormat.Name} {Movie.PrintedFilmFormats[i].Details}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                        else
                        {
                            data[1] = $"{Movie.PrintedFilmFormats[i].FilmFormat.Name}";
                            Content.Add(Formatter.AsTableRow(data));
                        }
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxPrintedFilmFormat() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
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

            string[] heading = new string[2];

            // Directors
            heading[0] = "Directed by";
            heading[1] = "Regie";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.Directors);

            // Writers
            heading[0] = "Writing Credits";
            heading[1] = "Drehbuch";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.Writers);

            // Cast
            // TODO add cast status
            heading[0] = "Cast";
            heading[1] = "Darsteller";
            CreateCastPersonItemSection(targetLanguageCode, heading, Movie.Cast);

            // Producers
            heading[0] = "Produced by";
            heading[1] = "Produzenten";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.Producers);

            // Musicians
            heading[0] = "Music by";
            heading[1] = "Musik";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.Musicians);

            // Cinematographer
            heading[0] = "Cinematography by";
            heading[1] = "Kamera";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.Cinematographers);

            // FilmEditor
            heading[0] = "Film Editing by";
            heading[1] = "Schnitt";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.FilmEditors);

            Logger.Trace($"CreateCastAndCrewChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates a formatted person section of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="heading">The heading for the section; [0] english; [1] german.</param>
        /// <param name="persons">The list of persons for the section.</param>
        private void CreatePersonItemSection(string targetLanguageCode, string[] heading, List<PersonItem> persons)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (heading.Length != 2)
            {
                throw new ArgumentException(nameof(heading));
            }
            if (persons == null)
            {
                throw new ArgumentNullException(nameof(persons));
            }

            if (persons.Count > 0)
            {
                Logger.Trace($"Anzahl {heading[0]}: '{persons.Count}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "biography" };

                if (targetLanguageCode.Equals("en"))
                {
                    Content.Add(Formatter.AsHeading3(heading[0]));
                }
                else // incl. case "de"
                {
                    Content.Add(Formatter.AsHeading3(heading[1]));
                }

                for (int i = 0; i < persons.Count; i++)
                {
                    if (!String.IsNullOrEmpty(persons[i].Person.FirstName) && !String.IsNullOrEmpty(persons[i].Person.LastName) && !String.IsNullOrEmpty(persons[i].Person.NameAddOn))
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{persons[i].Person.FirstName} {persons[i].Person.LastName} {persons[i].Person.NameAddOn}");
                    }
                    else if (!String.IsNullOrEmpty(persons[i].Person.FirstName) && !String.IsNullOrEmpty(persons[i].Person.LastName))
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{persons[i].Person.FirstName} {persons[i].Person.LastName}");
                    }
                    else if (!String.IsNullOrEmpty(persons[i].Person.LastName) && !String.IsNullOrEmpty(persons[i].Person.NameAddOn))
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{persons[i].Person.LastName} {persons[i].Person.NameAddOn}");
                    }
                    else
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{persons[i].Person.LastName}");
                    }

                    if (!String.IsNullOrEmpty(persons[i].Role) && !String.IsNullOrEmpty(persons[i].Details))
                    {
                        data[1] = $"({persons[i].Role}) {persons[i].Details}";
                    }
                    else if (!String.IsNullOrEmpty(persons[i].Role))
                    {
                        data[1] = $"({persons[i].Role}";
                    }
                    else if (!String.IsNullOrEmpty(persons[i].Details))
                    {
                        data[1] = $"({persons[i].Details}";
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
        /// Creates a formatted cast person section of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="heading">The heading for the section; [0] english; [1] german.</param>
        /// <param name="persons">The list of persons for the section.</param>
        private void CreateCastPersonItemSection(string targetLanguageCode, string[] heading, List<CastPersonItem> persons)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (heading.Length != 2)
            {
                throw new ArgumentException(nameof(heading));
            }
            if (persons == null)
            {
                throw new ArgumentNullException(nameof(persons));
            }

            if (persons.Count > 0)
            {
                Logger.Trace($"Anzahl {heading[0]}: '{persons.Count}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "biography" };

                if (targetLanguageCode.Equals("en"))
                {
                    Content.Add(Formatter.AsHeading3(heading[0]));
                }
                else // incl. case "de"
                {
                    Content.Add(Formatter.AsHeading3(heading[1]));
                }

                for (int i = 0; i < persons.Count; i++)
                {
                    if (!String.IsNullOrEmpty(persons[i].Person.FirstName) && !String.IsNullOrEmpty(persons[i].Person.LastName) && !String.IsNullOrEmpty(persons[i].Person.NameAddOn))
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{persons[i].Person.FirstName} {persons[i].Person.LastName} {persons[i].Person.NameAddOn}");
                    }
                    else if (!String.IsNullOrEmpty(persons[i].Person.FirstName) && !String.IsNullOrEmpty(persons[i].Person.LastName))
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{persons[i].Person.FirstName} {persons[i].Person.LastName}");
                    }
                    else if (!String.IsNullOrEmpty(persons[i].Person.LastName) && !String.IsNullOrEmpty(persons[i].Person.NameAddOn))
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{persons[i].Person.LastName} {persons[i].Person.NameAddOn}");
                    }
                    else
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{persons[i].Person.LastName}");
                    }

                    // TODO: add dubbing information

                    if (!String.IsNullOrEmpty(persons[i].Role) && !String.IsNullOrEmpty(persons[i].Details))
                    {
                        data[1] = $"({persons[i].Role}) {persons[i].Details}";
                    }
                    else if (!String.IsNullOrEmpty(persons[i].Role))
                    {
                        data[1] = $"({persons[i].Role}";
                    }
                    else if (!String.IsNullOrEmpty(persons[i].Details))
                    {
                        data[1] = $"({persons[i].Details}";
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
