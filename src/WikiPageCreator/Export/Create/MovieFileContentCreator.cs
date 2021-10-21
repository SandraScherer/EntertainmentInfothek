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
            CreateInfoBoxLogo(targetLanguageCode);
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

            CreatePosterChapter(targetLanguageCode);
            CreateCoverChapter(targetLanguageCode);

            CreateDescriptionChapter(targetLanguageCode);
            CreateReviewChapter(targetLanguageCode);

            CreateImageChapter(targetLanguageCode);

            CreateCastAndCrewChapter(targetLanguageCode);
            CreateCompanyChapter(targetLanguageCode);

            CreateFilmingAndProductionChapter(targetLanguageCode);

            CreateAwardChapter(targetLanguageCode);
            CreateWeblinkChapter(targetLanguageCode);
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
            }
            else if (targetLanguageCode.Equals("de") && !String.IsNullOrEmpty(Movie.GermanTitle))
            {
                Logger.Trace($"Title: '{Movie.GermanTitle}' (deutsch)");

                Content.Add(Formatter.AsHeading1(Movie.GermanTitle));
            }
            else
            {
                Logger.Trace($"Title: '{Movie.OriginalTitle}' (original)");

                Content.Add(Formatter.AsHeading1(Movie.OriginalTitle));
            }
            Content.Add("");

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
            }
            else // incl. case "de"
            {
                data[0] = "Originaltitel";
                data[1] = Movie.OriginalTitle;
            }
            Content.Add(Formatter.AsTableRow(data));

            Logger.Trace($"CreateInfoBoxTitle() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox logo field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxLogo(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateInfoBoxLogo() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (Movie.Logo != null)
            {
                string[] data = new string[2];
                string[] path = { "cinema_and_television_movie" };

                if (targetLanguageCode.Equals("en") && !String.IsNullOrEmpty(Movie.Logo.Type.EnglishTitle))
                {
                    data[0] = Formatter.AsImage(path, Movie.Logo.FileName, 450, Movie.Logo.Type.EnglishTitle);
                }
                else if (!String.IsNullOrEmpty(Movie.Logo.Type.GermanTitle))
                {
                    data[0] = Formatter.AsImage(path, Movie.Logo.FileName, 450, Movie.Logo.Type.GermanTitle);
                }
                else
                {
                    data[0] = Formatter.AsImage(path, Movie.Logo.FileName, 450);
                }
                Content.Add(Formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxLogo() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted infobox type field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
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
                }
                else // incl. case "de"
                {
                    data[0] = "Typ";
                    data[1] = Formatter.AsInternalLink(path, Movie.Type.EnglishTitle, Movie.Type.GermanTitle);
                }
                Content.Add(Formatter.AsTableRow(data));
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
                }
                else // incl. case "de"
                {
                    data[0] = "Erstausstrahlung";
                    data[1] = Formatter.AsInternalLink(path, Movie.ReleaseDate, Movie.ReleaseDate);
                }
                Content.Add(Formatter.AsTableRow(data));
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

            if ((Movie.Genres != null) && (Movie.Genres.Count > 0))
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
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Genres[0].Genre.EnglishTitle, Movie.Genres[0].Genre.EnglishTitle)}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Genres.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Genres[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Genres[i].Genre.EnglishTitle, Movie.Genres[i].Genre.EnglishTitle)} {Movie.Genres[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Genres[i].Genre.EnglishTitle, Movie.Genres[i].Genre.EnglishTitle)}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Genre";
                    if (!String.IsNullOrEmpty(Movie.Genres[0].Details))
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Genres[0].Genre.EnglishTitle, Movie.Genres[0].Genre.GermanTitle)} {Movie.Genres[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Genres[0].Genre.EnglishTitle, Movie.Genres[0].Genre.GermanTitle)}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Genres.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Genres[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Genres[i].Genre.EnglishTitle, Movie.Genres[i].Genre.GermanTitle)} {Movie.Genres[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Genres[i].Genre.EnglishTitle, Movie.Genres[i].Genre.GermanTitle)}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
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

            if ((Movie.Certifications != null) && (Movie.Certifications.Count > 0))
            {
                Logger.Trace($"Anzahl Certifications: '{Movie.Certifications.Count}'");

                string[] data = new string[2];
                string[] path = { "certification" };

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Certification";
                    if (Movie.Certifications[0].Certification.Image != null && !String.IsNullOrEmpty(Movie.Certifications[0].Details))
                    {
                        data[1] = $"{Formatter.AsImage(path, Movie.Certifications[0].Certification.Image.FileName, 75)} {Movie.Certifications[0].Details}";
                    }
                    else if (Movie.Certifications[0].Certification.Image != null)
                    {
                        data[1] = $"{Formatter.AsImage(path, Movie.Certifications[0].Certification.Image.FileName, 75)}";
                    }
                    else
                    {
                        data[1] = $"{Movie.Certifications[0].Certification.Name}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Certifications.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (Movie.Certifications[i].Certification.Image != null && !String.IsNullOrEmpty(Movie.Certifications[i].Details))
                        {
                            data[1] = $"{Formatter.AsImage(path, Movie.Certifications[i].Certification.Image.FileName, 75)} {Movie.Certifications[i].Details}";
                        }
                        else if (Movie.Certifications[i].Certification.Image != null)
                        {
                            data[1] = $"{Formatter.AsImage(path, Movie.Certifications[i].Certification.Image.FileName, 75)}";
                        }
                        else
                        {
                            data[1] = $"{Movie.Certifications[i].Certification.Name}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Altersfreigabe";
                    if (Movie.Certifications[0].Certification.Image != null && !String.IsNullOrEmpty(Movie.Certifications[0].Details))
                    {
                        data[1] = $"{Formatter.AsImage(path, Movie.Certifications[0].Certification.Image.FileName, 75)} {Movie.Certifications[0].Details}";
                    }
                    else if (Movie.Certifications[0].Certification.Image != null)
                    {
                        data[1] = $"{Formatter.AsImage(path, Movie.Certifications[0].Certification.Image.FileName, 75)}";
                    }
                    else
                    {
                        data[1] = $"{Movie.Certifications[0].Certification.Name}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Certifications.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (Movie.Certifications[i].Certification.Image != null && !String.IsNullOrEmpty(Movie.Certifications[i].Details))
                        {
                            data[1] = $"{Formatter.AsImage(path, Movie.Certifications[i].Certification.Image.FileName, 75)} {Movie.Certifications[i].Details}";
                        }
                        else if (Movie.Certifications[i].Certification.Image != null)
                        {
                            data[1] = $"{Formatter.AsImage(path, Movie.Certifications[i].Certification.Image.FileName, 75)}";
                        }
                        else
                        {
                            data[1] = $"{Movie.Certifications[i].Certification.Name}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
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

            if ((Movie.Countries != null) && (Movie.Countries.Count > 0))
            {
                Logger.Trace($"Anzahl Countries: '{Movie.Countries.Count}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "info" };

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Production Country";
                    if (!String.IsNullOrEmpty(Movie.Countries[0].Details))
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Countries[0].Country.OriginalFullName, Movie.Countries[0].Country.EnglishShortName)} {Movie.Countries[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Countries[0].Country.OriginalFullName, Movie.Countries[0].Country.EnglishShortName)}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Countries.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Countries[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Countries[i].Country.OriginalFullName, Movie.Countries[i].Country.EnglishShortName)} {Movie.Countries[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Countries[i].Country.OriginalFullName, Movie.Countries[i].Country.EnglishShortName)}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Produktionsland";
                    if (!String.IsNullOrEmpty(Movie.Countries[0].Details))
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Countries[0].Country.OriginalFullName, Movie.Countries[0].Country.GermanShortName)} {Movie.Countries[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Countries[0].Country.OriginalFullName, Movie.Countries[0].Country.GermanShortName)}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Countries.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Countries[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Countries[i].Country.OriginalFullName, Movie.Countries[i].Country.GermanShortName)} {Movie.Countries[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Countries[i].Country.OriginalFullName, Movie.Countries[i].Country.GermanShortName)}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
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

            if ((Movie.Languages != null) && (Movie.Languages.Count > 0))
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
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Languages[0].Language.OriginalName, Movie.Languages[0].Language.EnglishName)}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Languages.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Languages[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Languages[i].Language.OriginalName, Movie.Languages[i].Language.EnglishName)} {Movie.Languages[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Languages[i].Language.OriginalName, Movie.Languages[i].Language.EnglishName)}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Sprache";
                    if (!String.IsNullOrEmpty(Movie.Languages[0].Details))
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Languages[0].Language.OriginalName, Movie.Languages[0].Language.GermanName)} {Movie.Languages[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Languages[0].Language.OriginalName, Movie.Languages[0].Language.GermanName)}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Languages.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Languages[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Languages[i].Language.OriginalName, Movie.Languages[i].Language.GermanName)} {Movie.Languages[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Languages[i].Language.OriginalName, Movie.Languages[i].Language.GermanName)}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
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
                    }
                    else
                    {
                        data[1] = $"{Movie.WorldwideGross}";
                    }
                    Content.Add(Formatter.AsTableRow(data));
                }
                else // incl. case "de"
                {
                    data[0] = "Einspielergebnis (weltweit)";
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

            if ((Movie.Runtimes != null) && (Movie.Runtimes.Count > 0))
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
                    }
                    else
                    {
                        data[1] = $"{Movie.Runtimes[0].Runtime} min. ({Formatter.AsInternalLink(path, Movie.Runtimes[0].Edition.EnglishTitle, Movie.Runtimes[0].Edition.EnglishTitle)})";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Runtimes.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Runtimes[i].Details))
                        {
                            data[1] = $"{Movie.Runtimes[i].Runtime} min. ({Formatter.AsInternalLink(path, Movie.Runtimes[i].Edition.EnglishTitle, Movie.Runtimes[i].Edition.EnglishTitle)}) {Movie.Runtimes[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Movie.Runtimes[i].Runtime} min. ({Formatter.AsInternalLink(path, Movie.Runtimes[i].Edition.EnglishTitle, Movie.Runtimes[i].Edition.EnglishTitle)})";
                        }
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Laufzeit";
                    if (!String.IsNullOrEmpty(Movie.Runtimes[0].Details))
                    {
                        data[1] = $"{Movie.Runtimes[0].Runtime} min. ({Formatter.AsInternalLink(path, Movie.Runtimes[0].Edition.EnglishTitle, Movie.Runtimes[0].Edition.GermanTitle)}) {Movie.Runtimes[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Movie.Runtimes[0].Runtime} min. ({Formatter.AsInternalLink(path, Movie.Runtimes[0].Edition.EnglishTitle, Movie.Runtimes[0].Edition.GermanTitle)})";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Runtimes.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Runtimes[i].Details))
                        {
                            data[1] = $"{Movie.Runtimes[i].Runtime} min. ({Formatter.AsInternalLink(path, Movie.Runtimes[i].Edition.EnglishTitle, Movie.Runtimes[i].Edition.GermanTitle)}) {Movie.Runtimes[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Movie.Runtimes[i].Runtime} min. ({Formatter.AsInternalLink(path, Movie.Runtimes[i].Edition.EnglishTitle, Movie.Runtimes[i].Edition.GermanTitle)})";
                        }
                        Content.Add(Formatter.AsTableRow(data));
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

            if ((Movie.SoundMixes != null) && (Movie.SoundMixes.Count > 0))
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
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.SoundMixes[0].SoundMix.EnglishTitle, Movie.SoundMixes[0].SoundMix.EnglishTitle)}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.SoundMixes.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.SoundMixes[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.SoundMixes[i].SoundMix.EnglishTitle, Movie.SoundMixes[i].SoundMix.EnglishTitle)} {Movie.SoundMixes[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.SoundMixes[i].SoundMix.EnglishTitle, Movie.SoundMixes[i].SoundMix.EnglishTitle)}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Tonmischung";
                    if (!String.IsNullOrEmpty(Movie.SoundMixes[0].Details))
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.SoundMixes[0].SoundMix.EnglishTitle, Movie.SoundMixes[0].SoundMix.GermanTitle)} {Movie.SoundMixes[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.SoundMixes[0].SoundMix.EnglishTitle, Movie.SoundMixes[0].SoundMix.GermanTitle)}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.SoundMixes.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.SoundMixes[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.SoundMixes[i].SoundMix.EnglishTitle, Movie.SoundMixes[i].SoundMix.GermanTitle)} {Movie.SoundMixes[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.SoundMixes[i].SoundMix.EnglishTitle, Movie.SoundMixes[i].SoundMix.GermanTitle)}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
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

            if ((Movie.Colors != null) && (Movie.Colors.Count > 0))
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
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Colors[0].Color.EnglishTitle, Movie.Colors[0].Color.EnglishTitle)}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Colors.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Colors[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Colors[i].Color.EnglishTitle, Movie.Colors[i].Color.EnglishTitle)} {Movie.Colors[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Colors[i].Color.EnglishTitle, Movie.Colors[i].Color.EnglishTitle)}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Farbe";
                    if (!String.IsNullOrEmpty(Movie.Colors[0].Details))
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Colors[0].Color.EnglishTitle, Movie.Colors[0].Color.GermanTitle)} {Movie.Colors[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Movie.Colors[0].Color.EnglishTitle, Movie.Colors[0].Color.GermanTitle)}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Colors.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Colors[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Colors[i].Color.EnglishTitle, Movie.Colors[i].Color.GermanTitle)} {Movie.Colors[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Movie.Colors[i].Color.EnglishTitle, Movie.Colors[i].Color.GermanTitle)}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
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

            if ((Movie.AspectRatios != null) && (Movie.AspectRatios.Count > 0))
            {
                Logger.Trace($"Anzahl AspectRatios: '{Movie.AspectRatios.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Aspect Ratio";
                    if (!String.IsNullOrEmpty(Movie.AspectRatios[0].Details))
                    {
                        data[1] = $"{Movie.AspectRatios[0].AspectRatio.Ratio} {Movie.AspectRatios[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Movie.AspectRatios[0].AspectRatio.Ratio}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.AspectRatios.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.AspectRatios[i].Details))
                        {
                            data[1] = $"{Movie.AspectRatios[i].AspectRatio.Ratio} {Movie.AspectRatios[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Movie.AspectRatios[i].AspectRatio.Ratio}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Bildformat";
                    if (!String.IsNullOrEmpty(Movie.AspectRatios[0].Details))
                    {
                        data[1] = $"{Movie.AspectRatios[0].AspectRatio.Ratio} {Movie.AspectRatios[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Movie.AspectRatios[0].AspectRatio.Ratio}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.AspectRatios.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.AspectRatios[i].Details))
                        {
                            data[1] = $"{Movie.AspectRatios[i].AspectRatio.Ratio} {Movie.AspectRatios[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Movie.AspectRatios[i].AspectRatio.Ratio}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
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

            if ((Movie.Cameras != null) && (Movie.Cameras.Count > 0))
            {
                Logger.Trace($"Anzahl Cameras: '{Movie.Cameras.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Camera";
                    if (!String.IsNullOrEmpty(Movie.Cameras[0].Details))
                    {
                        data[1] = $"{Movie.Cameras[0].Camera.Name}, {Movie.Cameras[0].Camera.Lenses} {Movie.Cameras[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Movie.Cameras[0].Camera.Name}, {Movie.Cameras[0].Camera.Lenses}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Cameras.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Cameras[i].Details))
                        {
                            data[1] = $"{Movie.Cameras[i].Camera.Name}, {Movie.Cameras[i].Camera.Lenses} {Movie.Cameras[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Movie.Cameras[i].Camera.Name}, {Movie.Cameras[i].Camera.Lenses}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Kamera";
                    if (!String.IsNullOrEmpty(Movie.Cameras[0].Details))
                    {
                        data[1] = $"{Movie.Cameras[0].Camera.Name}, {Movie.Cameras[0].Camera.Lenses} {Movie.Cameras[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Movie.Cameras[0].Camera.Name}, {Movie.Cameras[0].Camera.Lenses}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Cameras.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Cameras[i].Details))
                        {
                            data[1] = $"{Movie.Cameras[i].Camera.Name}, {Movie.Cameras[i].Camera.Lenses} {Movie.Cameras[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Movie.Cameras[i].Camera.Name}, {Movie.Cameras[i].Camera.Lenses}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
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

            if ((Movie.Laboratories != null) && (Movie.Laboratories.Count > 0))
            {
                Logger.Trace($"Anzahl Laboratories: '{Movie.Laboratories.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Laboratory";
                    if (!String.IsNullOrEmpty(Movie.Laboratories[0].Details))
                    {
                        data[1] = $"{Movie.Laboratories[0].Laboratory.Name} {Movie.Laboratories[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Movie.Laboratories[0].Laboratory.Name}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Laboratories.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Laboratories[i].Details))
                        {
                            data[1] = $"{Movie.Laboratories[i].Laboratory.Name} {Movie.Laboratories[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Movie.Laboratories[i].Laboratory.Name}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Labor";
                    if (!String.IsNullOrEmpty(Movie.Laboratories[0].Details))
                    {
                        data[1] = $"{Movie.Laboratories[0].Laboratory.Name} {Movie.Laboratories[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Movie.Laboratories[0].Laboratory.Name}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.Laboratories.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.Laboratories[i].Details))
                        {
                            data[1] = $"{Movie.Laboratories[i].Laboratory.Name} {Movie.Laboratories[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Movie.Laboratories[i].Laboratory.Name}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
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

            if ((Movie.FilmLengths != null) && (Movie.FilmLengths.Count > 0))
            {
                Logger.Trace($"Anzahl FilmLengths: '{Movie.FilmLengths.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Film Length";
                    if (!String.IsNullOrEmpty(Movie.FilmLengths[0].Details))
                    {
                        data[1] = $"{Movie.FilmLengths[0].Length} {Movie.FilmLengths[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Movie.FilmLengths[0].Length}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.FilmLengths.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.FilmLengths[i].Details))
                        {
                            data[1] = $"{Movie.FilmLengths[i].Length} {Movie.FilmLengths[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Movie.FilmLengths[i].Length}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Filmlänge";
                    if (!String.IsNullOrEmpty(Movie.FilmLengths[0].Details))
                    {
                        data[1] = $"{Movie.FilmLengths[0].Length} {Movie.FilmLengths[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Movie.FilmLengths[0].Length}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.FilmLengths.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.FilmLengths[i].Details))
                        {
                            data[1] = $"{Movie.FilmLengths[i].Length} {Movie.FilmLengths[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Movie.FilmLengths[i].Length}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
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

            if ((Movie.NegativeFormats != null) && (Movie.NegativeFormats.Count > 0))
            {
                Logger.Trace($"Anzahl NegativeFormats: '{Movie.NegativeFormats.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Negative Format";
                    if (!String.IsNullOrEmpty(Movie.NegativeFormats[0].Details))
                    {
                        data[1] = $"{Movie.NegativeFormats[0].FilmFormat.Format} {Movie.NegativeFormats[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Movie.NegativeFormats[0].FilmFormat.Format}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.NegativeFormats.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.NegativeFormats[i].Details))
                        {
                            data[1] = $"{Movie.NegativeFormats[i].FilmFormat.Format} {Movie.NegativeFormats[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Movie.NegativeFormats[i].FilmFormat.Format}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Negativformat";
                    if (!String.IsNullOrEmpty(Movie.NegativeFormats[0].Details))
                    {
                        data[1] = $"{Movie.NegativeFormats[0].FilmFormat.Format} {Movie.NegativeFormats[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Movie.NegativeFormats[0].FilmFormat.Format}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.NegativeFormats.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.NegativeFormats[i].Details))
                        {
                            data[1] = $"{Movie.NegativeFormats[i].FilmFormat.Format} {Movie.NegativeFormats[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Movie.NegativeFormats[i].FilmFormat.Format}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
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

            if ((Movie.CinematographicProcesses != null) && (Movie.CinematographicProcesses.Count > 0))
            {
                Logger.Trace($"Anzahl CinematographicProcesses: '{Movie.CinematographicProcesses.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Cinematographic Process";
                    if (!String.IsNullOrEmpty(Movie.CinematographicProcesses[0].Details))
                    {
                        data[1] = $"{Movie.CinematographicProcesses[0].CinematographicProcess.Name} {Movie.CinematographicProcesses[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Movie.CinematographicProcesses[0].CinematographicProcess.Name}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.CinematographicProcesses.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.CinematographicProcesses[i].Details))
                        {
                            data[1] = $"{Movie.CinematographicProcesses[i].CinematographicProcess.Name} {Movie.CinematographicProcesses[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Movie.CinematographicProcesses[i].CinematographicProcess.Name}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Filmprozess";
                    if (!String.IsNullOrEmpty(Movie.CinematographicProcesses[0].Details))
                    {
                        data[1] = $"{Movie.CinematographicProcesses[0].CinematographicProcess.Name} {Movie.CinematographicProcesses[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Movie.CinematographicProcesses[0].CinematographicProcess.Name}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.CinematographicProcesses.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.CinematographicProcesses[i].Details))
                        {
                            data[1] = $"{Movie.CinematographicProcesses[i].CinematographicProcess.Name} {Movie.CinematographicProcesses[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Movie.CinematographicProcesses[i].CinematographicProcess.Name}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
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

            if ((Movie.PrintedFilmFormats != null) && (Movie.PrintedFilmFormats.Count > 0))
            {
                Logger.Trace($"Anzahl PrintedFilmFormats: '{Movie.PrintedFilmFormats.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    data[0] = "Printed Film Format";
                    if (!String.IsNullOrEmpty(Movie.PrintedFilmFormats[0].Details))
                    {
                        data[1] = $"{Movie.PrintedFilmFormats[0].FilmFormat.Format} {Movie.PrintedFilmFormats[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Movie.PrintedFilmFormats[0].FilmFormat.Format}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.PrintedFilmFormats.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.PrintedFilmFormats[i].Details))
                        {
                            data[1] = $"{Movie.PrintedFilmFormats[i].FilmFormat.Format} {Movie.PrintedFilmFormats[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Movie.PrintedFilmFormats[i].FilmFormat.Format}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    data[0] = "Filmformat";
                    if (!String.IsNullOrEmpty(Movie.PrintedFilmFormats[0].Details))
                    {
                        data[1] = $"{Movie.PrintedFilmFormats[0].FilmFormat.Format} {Movie.PrintedFilmFormats[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Movie.PrintedFilmFormats[0].FilmFormat.Format}";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Movie.PrintedFilmFormats.Count; i++)
                    {
                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Movie.PrintedFilmFormats[i].Details))
                        {
                            data[1] = $"{Movie.PrintedFilmFormats[i].FilmFormat.Format} {Movie.PrintedFilmFormats[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Movie.PrintedFilmFormats[i].FilmFormat.Format}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
                    }
                }
            }

            Logger.Trace($"CreateInfoBoxPrintedFilmFormat() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted poster chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreatePosterChapter(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreatePosterChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if ((Movie.Posters != null) && (Movie.Posters.Count > 0))
            {
                if (targetLanguageCode.Equals("en"))
                {
                    Content.Add(Formatter.AsHeading2("Poster"));
                }
                else // incl. case "de"
                {
                    Content.Add(Formatter.AsHeading2("Poster"));
                }

                CreateImageItemSection(targetLanguageCode, Movie.Posters);
            }
            Logger.Trace($"CreatePosterChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted cover chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateCoverChapter(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateCoverChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if ((Movie.Covers != null) && (Movie.Covers.Count > 0))
            {
                if (targetLanguageCode.Equals("en"))
                {
                    Content.Add(Formatter.AsHeading2("Cover"));
                }
                else // incl. case "de"
                {
                    Content.Add(Formatter.AsHeading2("Cover"));
                }

                CreateImageItemSection(targetLanguageCode, Movie.Covers);
            }

            Logger.Trace($"CreateCoverChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted description chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateDescriptionChapter(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateDescriptionChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if ((Movie.Descriptions != null) && (Movie.Descriptions.Count > 0))
            {
                if (targetLanguageCode.Equals("en"))
                {
                    Content.Add(Formatter.AsHeading2("Descriptions"));
                }
                else // incl. case "de"
                {
                    Content.Add(Formatter.AsHeading2("Beschreibungen"));
                }

                CreateTextItemSection(targetLanguageCode, Movie.Descriptions);
            }

            Logger.Trace($"CreateDescriptionChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted review chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateReviewChapter(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateReviewChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if ((Movie.Reviews != null) && (Movie.Reviews.Count > 0))
            {
                if (targetLanguageCode.Equals("en"))
                {
                    Content.Add(Formatter.AsHeading2("Reviews"));
                }
                else // incl. case "de"
                {
                    Content.Add(Formatter.AsHeading2("Rezensionen"));
                }

                CreateTextItemSection(targetLanguageCode, Movie.Reviews);
            }

            Logger.Trace($"CreateReviewChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates a formatted text section of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="images">The list of texts for the section.</param>
        private void CreateTextItemSection(string targetLanguageCode, List<TextItem> texts)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (texts == null)
            {
                throw new ArgumentNullException(nameof(texts));
            }

            if (texts.Count > 0)
            {
                Logger.Trace($"Anzahl Texte: '{texts.Count}'");

                string data;
                string[] pathBiography = { targetLanguageCode, "biography" };
                string[] pathCompany = { targetLanguageCode, "company" };

                for (int i = 0; i < texts.Count; i++)
                {
                    if (targetLanguageCode.Equals("en") && texts[i].Text.Language.ID.Equals("en"))
                    {
                        data = texts[i].Text.Content;
                    }
                    else if (targetLanguageCode.Equals("de") && texts[i].Text.Language.ID.Equals("de"))
                    {
                        data = texts[i].Text.Content;
                    }
                    else // for testing purposes
                    {
                        data = texts[i].Text.Content;
                    }
                    Content.Add(data);

                    data = "";

                    if (texts[i].Text.Authors != null)
                    {
                        Logger.Trace($"Anzahl Authors:  '{texts[i].Text.Authors.Count}'");

                        for (int j = 0; j < texts[i].Text.Authors.Count; j++)
                        {
                            if (!String.IsNullOrEmpty(texts[i].Text.Authors[j].Person.Name) && !String.IsNullOrEmpty(texts[i].Text.Authors[j].Person.NameAddOn))
                            {
                                if (String.IsNullOrEmpty(data))
                                {
                                    data = $"{ Formatter.AsInternalLink(pathBiography, $"{texts[i].Text.Authors[j].Person.Name} {texts[i].Text.Authors[j].Person.NameAddOn}")}";
                                }
                                else
                                {
                                    data = $"{data}, { Formatter.AsInternalLink(pathBiography, $"{texts[i].Text.Authors[j].Person.Name} {texts[i].Text.Authors[j].Person.NameAddOn}")}";
                                }
                            }
                            else
                            {
                                if (String.IsNullOrEmpty(data))
                                {
                                    data = $"{ Formatter.AsInternalLink(pathBiography, $"{texts[i].Text.Authors[j].Person.Name}")}";
                                }
                                else
                                {
                                    data = $"{data}, { Formatter.AsInternalLink(pathBiography, $"{texts[i].Text.Authors[j].Person.Name}")}";
                                }
                            }
                        }
                    }
                    if (texts[i].Text.Sources != null)
                    {
                        Logger.Trace($"Anzahl Sources:  '{texts[i].Text.Sources.Count}'");

                        for (int j = 0; j < texts[i].Text.Sources.Count; j++)
                        {
                            if (!String.IsNullOrEmpty(texts[i].Text.Sources[j].Company.Name) && !String.IsNullOrEmpty(texts[i].Text.Sources[j].Company.NameAddOn))
                            {
                                if (String.IsNullOrEmpty(data))
                                {
                                    data = $"{ Formatter.AsInternalLink(pathCompany, $"{texts[i].Text.Sources[j].Company.Name} {texts[i].Text.Sources[j].Company.NameAddOn}")}";
                                }
                                else
                                {
                                    data = $"{data}, { Formatter.AsInternalLink(pathCompany, $"{texts[i].Text.Sources[j].Company.Name} {texts[i].Text.Sources[j].Company.NameAddOn}")}";
                                }
                            }
                            else
                            {
                                if (String.IsNullOrEmpty(data))
                                {
                                    data = $"{ Formatter.AsInternalLink(pathCompany, $"{texts[i].Text.Sources[j].Company.Name}")}";
                                }
                                else
                                {
                                    data = $"{data}, { Formatter.AsInternalLink(pathCompany, $"{texts[i].Text.Sources[j].Company.Name}")}";
                                }
                            }
                        }
                    }

                    Content.Add($"({data})");
                    Content.Add("");
                }

                Content.Add("");
            }
        }

        /// <summary>
        /// Creates the formatted image chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateImageChapter(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateImageChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if ((Movie.Images != null) && (Movie.Images.Count > 0))
            {
                if (targetLanguageCode.Equals("en"))
                {
                    Content.Add(Formatter.AsHeading2("Images"));
                }
                else // incl. case "de"
                {
                    Content.Add(Formatter.AsHeading2("Bilder"));
                }

                CreateImageItemSection(targetLanguageCode, Movie.Images);
            }

            Logger.Trace($"CreateImageChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates a formatted image section of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="images">The list of images for the section.</param>
        private void CreateImageItemSection(string targetLanguageCode, List<ImageItem> images)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (images == null)
            {
                throw new ArgumentNullException(nameof(images));
            }

            if (images.Count > 0)
            {
                Logger.Trace($"Anzahl Images: '{images.Count}'");

                string[] path = { "cinema_and_television_movie" };
                string text = "";
                string[] pathCompany = { targetLanguageCode, "company" };

                for (int i = 0; i < images.Count; i++)
                {
                    if (targetLanguageCode.Equals("en"))
                    {
                        if (!String.IsNullOrEmpty(images[i].Image.Type.EnglishTitle))
                        {
                            text = $"{images[i].Image.Type.EnglishTitle}";
                        }
                    }
                    else // incl. case "de"
                    {
                        if (!String.IsNullOrEmpty(images[i].Image.Type.GermanTitle))
                        {
                            text = $"{images[i].Image.Type.GermanTitle}";
                        }
                    }

                    if (images[i].Image.Sources.Count > 0)
                    {
                        Logger.Trace($"Anzahl Sources:  '{images[i].Image.Sources.Count}'");

                        for (int j = 0; j < images[i].Image.Sources.Count; j++)
                        {
                            if (j == 0)
                            {
                                if (!String.IsNullOrEmpty(images[i].Image.Sources[j].Company.Name) && !String.IsNullOrEmpty(images[i].Image.Sources[j].Company.NameAddOn))
                                {
                                    text = $"{text} {Formatter.ForceNewLine()} ({Formatter.AsInternalLink(pathCompany, $"{images[i].Image.Sources[j].Company.Name} {images[i].Image.Sources[j].Company.NameAddOn}")}";
                                }
                                else
                                {
                                    text = $"{text} {Formatter.ForceNewLine()} ({Formatter.AsInternalLink(pathCompany, $"{images[i].Image.Sources[j].Company.Name}")}";
                                }
                            }
                            else
                            {
                                if (!String.IsNullOrEmpty(images[i].Image.Sources[j].Company.Name) && !String.IsNullOrEmpty(images[i].Image.Sources[j].Company.NameAddOn))
                                {
                                    text = $"{text}, {Formatter.AsInternalLink(pathCompany, $"{images[i].Image.Sources[j].Company.Name} {images[i].Image.Sources[j].Company.NameAddOn}")}";
                                }
                                else
                                {
                                    text = $"{text}, {Formatter.AsInternalLink(pathCompany, $"{images[i].Image.Sources[j].Company.Name}")}";
                                }
                            }
                        }

                        text = $"{text})";
                    }

                    Content.Add(Formatter.AsImageBox(Formatter.AsImage(path, images[i].Image.FileName, 200, text)));
                    Content.Add("");
                }

                Content.Add("");
            }
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
            heading[0] = "Cast";
            heading[1] = "Darsteller";
            CreateCastPersonItemSection(targetLanguageCode, heading, Movie.Cast);

            // Producers
            heading[0] = "Produced by";
            heading[1] = "Produzenten";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.Producers);

            // Music
            heading[0] = "Music by";
            heading[1] = "Musik";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.Music);

            // Cinematography
            heading[0] = "Cinematography by";
            heading[1] = "Kamera";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.Cinematography);

            // FilmEditing
            heading[0] = "Film Editing by";
            heading[1] = "Schnitt";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.FilmEditing);

            // Casting
            heading[0] = "Casting by";
            heading[1] = "Casting";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.Casting);

            // Production Design
            heading[0] = "Production Design by";
            heading[1] = "Szenenbild";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.ProductionDesign);

            // Art Direction
            heading[0] = "Art Direction by";
            heading[1] = "Ausstattung";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.ArtDirection);

            // Set Decoration
            heading[0] = "Set Decoration by";
            heading[1] = "Bühnenbild";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.SetDecoration);

            // Costume Design
            heading[0] = "Costume Design by";
            heading[1] = "Kostümausstattung";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.CostumeDesign);

            // Makeup Department
            heading[0] = "Makeup Department";
            heading[1] = "Maske";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.MakeupDepartment);

            // Production Management
            heading[0] = "Production Management";
            heading[1] = "Produktionsleitung";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.ProductionManagement);

            // Assistant Directors
            heading[0] = "Second Unit Director or Assistant Director";
            heading[1] = "Second Unit Regie und Regieassistenz";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.AssistantDirectors);

            // Art Department
            heading[0] = "Art Department";
            heading[1] = "Art Abteilung";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.ArtDepartment);

            // Sound Department
            heading[0] = "Sound Department";
            heading[1] = "Sound Abteilung";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.SoundDepartment);

            // Special Effects
            heading[0] = "Special Effects by";
            heading[1] = "Spezialeffekte";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.SpecialEffects);

            // Visual Effects
            heading[0] = "Visual Effects by";
            heading[1] = "Visuelle Effekte";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.VisualEffects);

            // Stunts
            heading[0] = "Stunts by";
            heading[1] = "Stunts";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.Stunts);

            // Electrical Department
            heading[0] = "Camera and Electrical Department";
            heading[1] = "Kamera und Beleuchtung";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.ElectricalDepartment);

            // Animation Department
            heading[0] = "Animation Department";
            heading[1] = "Animationen";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.AnimationDepartment);

            // Casting Department
            heading[0] = "Casting Department";
            heading[1] = "Casting";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.CastingDepartment);

            // Costume Department
            heading[0] = "Costume and Wardrobe Department";
            heading[1] = "Kostümbildnerei";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.CostumeDepartment);

            // Editorial Department
            heading[0] = "Editorial Department";
            heading[1] = "Redaktion";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.EditorialDepartment);

            // Location Management
            heading[0] = "Location Management";
            heading[1] = "Drehort Management";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.LocationManagement);

            // Music Department
            heading[0] = "Music Department";
            heading[1] = "Musik";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.MusicDepartment);

            // Continuity Department
            heading[0] = "Script and Continuity Department";
            heading[1] = "Dramaturgie und Continuity";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.ContinuityDepartment);

            // Transportation Department
            heading[0] = "Transportation Department";
            heading[1] = "Transport";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.TransportationDepartment);

            // Other Crew
            heading[0] = "Additional Crew";
            heading[1] = "Weitere Crewmitglieder";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.OtherCrew);

            // Thanks
            heading[0] = "Thanks";
            heading[1] = "Dank";
            CreatePersonItemSection(targetLanguageCode, heading, Movie.Thanks);

            // Crew status
            if (Movie.CrewStatus != null)
            {
                if (targetLanguageCode.Equals("en"))
                {
                    Content.Add($"Crew is {Movie.CrewStatus.EnglishTitle}.");
                }
                else // incl. case "de"
                {
                    Content.Add($"Crew ist {Movie.CrewStatus.GermanTitle}.");
                }
                Content.Add("");
                Content.Add("");
            }

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
                    if (!String.IsNullOrEmpty(persons[i].Person.Name) && !String.IsNullOrEmpty(persons[i].Person.NameAddOn))
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{persons[i].Person.Name} {persons[i].Person.NameAddOn}");
                    }
                    else
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{persons[i].Person.Name}");
                    }

                    if (!String.IsNullOrEmpty(persons[i].Role) && !String.IsNullOrEmpty(persons[i].Details))
                    {
                        data[1] = $"({persons[i].Role}) {persons[i].Details}";
                    }
                    else if (!String.IsNullOrEmpty(persons[i].Role))
                    {
                        data[1] = $"({persons[i].Role})";
                    }
                    else if (!String.IsNullOrEmpty(persons[i].Details))
                    {
                        data[1] = $"{persons[i].Details}";
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

            if (persons != null)
            {
                Logger.Trace($"Anzahl {heading[0]}: '{persons.Count}'");

                string[] data = new string[3];
                string[] path = { targetLanguageCode, "biography" };

                if (targetLanguageCode.Equals("en"))
                {
                    Content.Add(Formatter.AsHeading3(heading[0]));
                }
                else // incl. case "de"
                {
                    Content.Add(Formatter.AsHeading3(heading[1]));
                }

                if (Movie.CastStatus != null)
                {
                    if (targetLanguageCode.Equals("en"))
                    {
                        Content.Add($"Cast is {Movie.CastStatus.EnglishTitle}.");
                    }
                    else // incl. case "de"
                    {
                        Content.Add($"Darsteller sind {Movie.CastStatus.GermanTitle}.");
                    }
                    Content.Add("");
                }

                for (int i = 0; i < persons.Count; i++)
                {
                    if (!String.IsNullOrEmpty(persons[i].Person.Name) && !String.IsNullOrEmpty(persons[i].Person.NameAddOn))
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{persons[i].Person.Name} {persons[i].Person.NameAddOn}");
                    }
                    else
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{persons[i].Person.Name}");
                    }

                    if (!String.IsNullOrEmpty(persons[i].Role) && !String.IsNullOrEmpty(persons[i].Details))
                    {
                        data[1] = $"({persons[i].Role}) {persons[i].Details}";
                    }
                    else if (!String.IsNullOrEmpty(persons[i].Role))
                    {
                        data[1] = $"({persons[i].Role})";
                    }
                    else if (!String.IsNullOrEmpty(persons[i].Details))
                    {
                        data[1] = $"{persons[i].Details}";
                    }
                    else
                    {
                        data[1] = " ";
                    }

                    if (persons[i].GermanDubber != null)
                    {
                        if (!String.IsNullOrEmpty(persons[i].GermanDubber.Name) && !String.IsNullOrEmpty(persons[i].GermanDubber.NameAddOn))
                        {
                            data[2] = Formatter.AsInternalLink(path, $"{persons[i].GermanDubber.Name} {persons[i].GermanDubber.NameAddOn}");
                        }
                        else if (!String.IsNullOrEmpty(persons[i].GermanDubber.Name))
                        {
                            data[2] = Formatter.AsInternalLink(path, $"{persons[i].GermanDubber.Name}");
                        }
                    }
                    else
                    {
                        data[2] = "";
                    }

                    Content.Add(Formatter.AsTableRow(data));
                }

                Content.Add("");
                Content.Add("");
            }
        }

        /// <summary>
        /// Creates the formatted company chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateCompanyChapter(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateCompanyChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (targetLanguageCode.Equals("en"))
            {
                Content.Add(Formatter.AsHeading2("Company Credits"));
            }
            else // incl. case "de"
            {
                Content.Add(Formatter.AsHeading2("Beteiligte Firmen"));
            }

            string[] heading = new string[2];

            // Production Companies
            heading[0] = "Production Companies";
            heading[1] = "Produktionsfirmen";
            CreateCompanyItemSection(targetLanguageCode, heading, Movie.ProductionCompanies);

            // Distributors
            heading[0] = "Distributors";
            heading[1] = "Vertrieb";
            CreateDistributorCompanyItemSection(targetLanguageCode, heading, Movie.Distributors);

            // Special Effects Companies
            heading[0] = "Special Effects";
            heading[1] = "Spezialeffekte";
            CreateCompanyItemSection(targetLanguageCode, heading, Movie.SpecialEffectsCompanies);

            // Other Companies
            heading[0] = "Other Companies";
            heading[1] = "Weitere Firmen";
            CreateCompanyItemSection(targetLanguageCode, heading, Movie.OtherCompanies);
        }

        /// <summary>
        /// Creates a formatted company section of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="heading">The heading for the section; [0] english; [1] german.</param>
        /// <param name="companies">The list of companies for the section.</param>
        private void CreateCompanyItemSection(string targetLanguageCode, string[] heading, List<CompanyItem> companies)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (heading.Length != 2)
            {
                throw new ArgumentException(nameof(heading));
            }
            if (companies == null)
            {
                throw new ArgumentNullException(nameof(companies));
            }

            if (companies.Count > 0)
            {
                Logger.Trace($"Anzahl {heading[0]}:  '{companies.Count}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "company" };

                if (targetLanguageCode.Equals("en"))
                {
                    Content.Add(Formatter.AsHeading3(heading[0]));
                }
                else // incl. case "de"
                {
                    Content.Add(Formatter.AsHeading3(heading[1]));
                }

                for (int i = 0; i < companies.Count; i++)
                {
                    if (!String.IsNullOrEmpty(companies[i].Company.Name) && !String.IsNullOrEmpty(companies[i].Company.NameAddOn))
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{companies[i].Company.Name} {companies[i].Company.NameAddOn}");
                    }
                    else if (!String.IsNullOrEmpty(companies[i].Company.Name))
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{companies[i].Company.Name}");
                    }

                    if (!String.IsNullOrEmpty(companies[i].Role) && !String.IsNullOrEmpty(companies[i].Details))
                    {
                        data[1] = $"({companies[i].Role}) {companies[i].Details}";
                    }
                    else if (!String.IsNullOrEmpty(companies[i].Role))
                    {
                        data[1] = $"({companies[i].Role})";
                    }
                    else if (!String.IsNullOrEmpty(companies[i].Details))
                    {
                        data[1] = $"{companies[i].Details}";
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
        /// Creates a formatted distributor company section of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="heading">The heading for the section; [0] english; [1] german.</param>
        /// <param name="companies">The list of distributor companies for the section.</param>
        private void CreateDistributorCompanyItemSection(string targetLanguageCode, string[] heading, List<DistributorCompanyItem> companies)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (heading.Length != 2)
            {
                throw new ArgumentException(nameof(heading));
            }

            if (companies != null)
            {
                Logger.Trace($"Anzahl {heading[0]}: '{companies.Count}'");

                string[] data = new string[4];
                string[] path = { targetLanguageCode, "company" };

                if (targetLanguageCode.Equals("en"))
                {
                    Content.Add(Formatter.AsHeading3(heading[0]));
                }
                else // incl. case "de"
                {
                    Content.Add(Formatter.AsHeading3(heading[1]));
                }

                for (int i = 0; i < companies.Count; i++)
                {
                    if (!String.IsNullOrEmpty(companies[i].Company.Name) && !String.IsNullOrEmpty(companies[i].Company.NameAddOn))
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{companies[i].Company.Name} {companies[i].Company.NameAddOn}");
                    }
                    else
                    {
                        data[0] = Formatter.AsInternalLink(path, $"{companies[i].Company.Name}");
                    }

                    if (!String.IsNullOrEmpty(companies[i].ReleaseDate))
                    {
                        data[1] = $"({companies[i].ReleaseDate})";
                    }
                    else
                    {
                        data[1] = " ";
                    }

                    // prepare country information
                    string dataCountry;
                    string[] pathCountry = { targetLanguageCode, "info" };

                    if (targetLanguageCode.Equals("en"))
                    {
                        dataCountry = $"{Formatter.AsInternalLink(pathCountry, companies[i].Country.OriginalFullName, companies[i].Country.EnglishShortName)}";
                    }
                    else // incl. case "de"
                    {
                        dataCountry = $"{Formatter.AsInternalLink(pathCountry, companies[i].Country.OriginalFullName, companies[i].Country.GermanShortName)}";
                    }
                    data[2] = $"({dataCountry})";

                    if (!String.IsNullOrEmpty(companies[i].Role) && !String.IsNullOrEmpty(companies[i].Details))
                    {
                        data[3] = $"({companies[i].Role}) {companies[i].Details}";
                    }
                    else if (!String.IsNullOrEmpty(companies[i].Role))
                    {
                        data[3] = $"({companies[i].Role})";
                    }
                    else if (!String.IsNullOrEmpty(companies[i].Details))
                    {
                        data[3] = $"{companies[i].Details}";
                    }
                    else
                    {
                        data[3] = "";
                    }
                    Content.Add(Formatter.AsTableRow(data));
                }

                Content.Add("");
                Content.Add("");
            }
        }

        /// <summary>
        /// Creates the formatted filming and production chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateFilmingAndProductionChapter(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateFilmingAndProductionChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if (((Movie.FilmingLocations != null) && (Movie.FilmingLocations.Count > 0))
                || ((Movie.FilmingDates != null) && (Movie.FilmingDates.Count > 0))
                || ((Movie.ProductionDates != null) && (Movie.ProductionDates.Count > 0)))
            {
                if (targetLanguageCode.Equals("en"))
                {
                    Content.Add(Formatter.AsHeading2("Filming and Production"));
                }
                else // incl. case "de"
                {
                    Content.Add(Formatter.AsHeading2("Produktion"));
                }

                string[] heading = new string[2];

                // Filming Locations
                heading[0] = "Filming Locations";
                heading[1] = "Drehorte";

                if ((Movie.FilmingLocations != null) && (Movie.FilmingLocations.Count > 0))
                {
                    Logger.Trace($"Anzahl {heading[0]}:  '{Movie.FilmingLocations.Count}'");

                    string[] data = new string[1];
                    string[] path = { targetLanguageCode, "info" };

                    if (targetLanguageCode.Equals("en"))
                    {
                        Content.Add(Formatter.AsHeading3(heading[0]));
                    }
                    else // incl. case "de"
                    {
                        Content.Add(Formatter.AsHeading3(heading[1]));
                    }

                    for (int i = 0; i < Movie.FilmingLocations.Count; i++)
                    {
                        // prepare country information
                        string dataCountry;
                        string[] pathCountry = { targetLanguageCode, "info" };

                        if (targetLanguageCode.Equals("en") && Movie.FilmingLocations[i].Location.Country != null)
                        {
                            dataCountry = $"{Formatter.AsInternalLink(pathCountry, Movie.FilmingLocations[i].Location.Country.OriginalFullName, Movie.FilmingLocations[i].Location.Country.EnglishShortName)}";
                        }
                        else if (Movie.FilmingLocations[i].Location.Country != null) // incl. case "de" 
                        {
                            dataCountry = $"{Formatter.AsInternalLink(pathCountry, Movie.FilmingLocations[i].Location.Country.OriginalFullName, Movie.FilmingLocations[i].Location.Country.GermanShortName)}";
                        }
                        else
                        {
                            dataCountry = "";
                        }

                        if (!String.IsNullOrEmpty(Movie.FilmingLocations[i].Location.Name) && !String.IsNullOrEmpty(dataCountry) && !String.IsNullOrEmpty(Movie.FilmingLocations[i].Details))
                        {
                            data[0] = $"{Formatter.AsInternalLink(path, $"{Movie.FilmingLocations[i].Location.Name}")}, {dataCountry} -- {Movie.FilmingLocations[i].Details}";
                        }
                        else if (!String.IsNullOrEmpty(Movie.FilmingLocations[i].Location.Name) && !String.IsNullOrEmpty(dataCountry))
                        {
                            data[0] = $"{Formatter.AsInternalLink(path, $"{Movie.FilmingLocations[i].Location.Name}")}, {dataCountry}";
                        }
                        else if (!String.IsNullOrEmpty(Movie.FilmingLocations[i].Location.Name))
                        {
                            data[0] = $"{Formatter.AsInternalLink(path, $"{Movie.FilmingLocations[i].Location.Name}")}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    Content.Add("");
                    Content.Add("");
                }

                // Filming Dates
                heading[0] = "Filming Dates";
                heading[1] = "Drehdatum";

                if ((Movie.FilmingDates != null) && (Movie.FilmingDates.Count > 0))
                {
                    Logger.Trace($"Anzahl {heading[0]}:  '{Movie.FilmingDates.Count}'");

                    string[] data = new string[1];
                    string[] path = { targetLanguageCode, "date" };

                    if (targetLanguageCode.Equals("en"))
                    {
                        Content.Add(Formatter.AsHeading3(heading[0]));
                    }
                    else // incl. case "de"
                    {
                        Content.Add(Formatter.AsHeading3(heading[1]));
                    }

                    for (int i = 0; i < Movie.FilmingDates.Count; i++)
                    {
                        if (!String.IsNullOrEmpty(Movie.FilmingDates[i].StartDate) && !String.IsNullOrEmpty(Movie.FilmingDates[i].EndDate))
                        {
                            data[0] = $"{Formatter.AsInternalLink(path, Movie.FilmingDates[i].StartDate)} - {Formatter.AsInternalLink(path, Movie.FilmingDates[i].EndDate)}";
                        }
                        else if (!String.IsNullOrEmpty(Movie.FilmingDates[i].StartDate))
                        {
                            data[0] = $"{Formatter.AsInternalLink(path, Movie.FilmingDates[i].StartDate)} - ??";
                        }
                        else if (!String.IsNullOrEmpty(Movie.FilmingDates[i].EndDate))
                        {
                            data[0] = $"?? - {Formatter.AsInternalLink(path, Movie.FilmingDates[i].EndDate)}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    Content.Add("");
                    Content.Add("");
                }

                // Production Dates
                heading[0] = "Production Dates";
                heading[1] = "Produktionsdatum";

                if ((Movie.ProductionDates != null) && (Movie.ProductionDates.Count > 0))
                {
                    Logger.Trace($"Anzahl {heading[0]}:  '{Movie.ProductionDates.Count}'");

                    string[] data = new string[1];
                    string[] path = { targetLanguageCode, "date" };

                    if (targetLanguageCode.Equals("en"))
                    {
                        Content.Add(Formatter.AsHeading3(heading[0]));
                    }
                    else // incl. case "de"
                    {
                        Content.Add(Formatter.AsHeading3(heading[1]));
                    }

                    for (int i = 0; i < Movie.ProductionDates.Count; i++)
                    {
                        if (!String.IsNullOrEmpty(Movie.ProductionDates[i].StartDate) && !String.IsNullOrEmpty(Movie.ProductionDates[i].EndDate))
                        {
                            data[0] = $"{Formatter.AsInternalLink(path, Movie.ProductionDates[i].StartDate)} - {Formatter.AsInternalLink(path, Movie.ProductionDates[i].EndDate)}";
                        }
                        else if (!String.IsNullOrEmpty(Movie.ProductionDates[i].StartDate))
                        {
                            data[0] = $"{Formatter.AsInternalLink(path, Movie.ProductionDates[i].StartDate)} - ??";
                        }
                        else if (!String.IsNullOrEmpty(Movie.ProductionDates[i].EndDate))
                        {
                            data[0] = $"?? - {Formatter.AsInternalLink(path, Movie.ProductionDates[i].EndDate)}";
                        }
                        Content.Add(Formatter.AsTableRow(data));
                    }

                    Content.Add("");
                    Content.Add("");
                }
            }
        }

        /// <summary>
        /// Creates the formatted award chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateAwardChapter(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateAwardChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if ((Movie.Awards != null) && (Movie.Awards.Count > 0))
            {
                if (targetLanguageCode.Equals("en"))
                {
                    Content.Add(Formatter.AsHeading2("Awards"));
                }
                else // incl. case "de"
                {
                    Content.Add(Formatter.AsHeading2("Auszeichnungen"));
                }

                Logger.Trace($"Anzahl Awards:  '{Movie.Awards.Count}'");

                string[] data = new string[4];
                string[] path = { targetLanguageCode, "info" };
                string[] dataPersons = new string[4];
                string[] pathPersons = { targetLanguageCode, "biography" };

                for (int i = 0; i < Movie.Awards.Count; i++)
                {
                    data[0] = $"{Formatter.AsInternalLink(path, Movie.Awards[i].Award.Name, Movie.Awards[i].Award.Name)}";
                    data[1] = $"{Movie.Awards[i].Category}";
                    if (targetLanguageCode.Equals("en"))
                    {
                        if (Movie.Awards[i].Winner.Equals("1"))
                        {
                            data[2] = "Winner";
                        }
                        else
                        {
                            data[2] = "Nominee";
                        }
                    }
                    else // incl. case "de"
                    {
                        if (Movie.Awards[i].Winner.Equals("1"))
                        {
                            data[2] = "Gewinner";
                        }
                        else
                        {
                            data[2] = "Nominierter";
                        }

                    }
                    if (!String.IsNullOrEmpty(Movie.Awards[i].Details))
                    {
                        data[3] = $"{Movie.Awards[i].Details}";
                    }
                    else
                    {
                        data[3] = " ";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    if ((Movie.Awards[i].Persons != null) && (Movie.Awards[i].Persons.Count > 0))
                    {
                        for (int j = 0; j < Movie.Awards[i].Persons.Count; j++)
                        {
                            dataPersons[0] = Formatter.CellSpanVertically();

                            if (!String.IsNullOrEmpty(Movie.Awards[i].Persons[j].Person.Name) && !String.IsNullOrEmpty(Movie.Awards[i].Persons[j].Person.NameAddOn))
                            {
                                dataPersons[1] = Formatter.AsInternalLink(pathPersons, $"{Movie.Awards[i].Persons[j].Person.Name} {Movie.Awards[i].Persons[j].Person.NameAddOn}", $"{Movie.Awards[i].Persons[j].Person.Name}");
                            }
                            else
                            {
                                dataPersons[1] = Formatter.AsInternalLink(pathPersons, $"{Movie.Awards[i].Persons[j].Person.Name}", $"{Movie.Awards[i].Persons[j].Person.Name}");
                            }

                            if (!String.IsNullOrEmpty(Movie.Awards[i].Persons[j].Role) && !String.IsNullOrEmpty(Movie.Awards[i].Persons[j].Details))
                            {
                                dataPersons[1] = dataPersons[1] + $" ({Movie.Awards[i].Persons[j].Role}) {Movie.Awards[i].Persons[j].Details}";
                            }
                            else if (!String.IsNullOrEmpty(Movie.Awards[i].Persons[j].Role))
                            {
                                dataPersons[1] = dataPersons[1] + $" ({Movie.Awards[i].Persons[j].Role})";
                            }
                            else if (!String.IsNullOrEmpty(Movie.Awards[i].Persons[j].Details))
                            {
                                dataPersons[1] = dataPersons[1] + $" {Movie.Awards[i].Persons[j].Details}";
                            }
                            else
                            {
                                // nothing to do
                            }

                            dataPersons[2] = " ";
                            dataPersons[3] = " ";
                            Content.Add(Formatter.AsTableRow(dataPersons));
                        }
                    }
                }

                Content.Add("");
                Content.Add("");
            }

            Logger.Trace($"CreateAwardChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }

        /// <summary>
        /// Creates the formatted weblink chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateWeblinkChapter(string targetLanguageCode)
        {
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"CreateWeblinkChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' gestartet");

            if ((Movie.Weblinks != null) && (Movie.Weblinks.Count > 0))
            {
                if (targetLanguageCode.Equals("en"))
                {
                    Content.Add(Formatter.AsHeading2("Other Sites"));
                }
                else // incl. case "de"
                {
                    Content.Add(Formatter.AsHeading2("Andere Webseiten"));
                }

                Logger.Trace($"Anzahl Webseiten:  '{Movie.Weblinks.Count}'");

                for (int i = 0; i < Movie.Weblinks.Count; i++)
                {
                    string data;

                    if (targetLanguageCode.Equals("en"))
                    {
                        data = $"{Formatter.AsExternalLink(Movie.Weblinks[i].Weblink.Url, Movie.Weblinks[i].Weblink.EnglishTitle)} ({Movie.Weblinks[i].Weblink.Language.EnglishName})";
                    }
                    else // incl. case "de"
                    {
                        data = $"{Formatter.AsExternalLink(Movie.Weblinks[i].Weblink.Url, Movie.Weblinks[i].Weblink.GermanTitle)} ({Movie.Weblinks[i].Weblink.Language.GermanName})";
                    }
                    Content.Add($"{Formatter.ListItemIndent()}{Formatter.ListItemUnsorted()} {data}");
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
                {
                    Content.Add(Formatter.AsInsertPage(targetLanguageCode + ":navigation:" + Movie.Connection.ID));
                }
                else
                {
                    Content.Add(Formatter.AsInsertPage(targetLanguageCode + ":navigation:" + Movie.Connection.BaseConnection.ID));
                }

                Content.Add("");
                Content.Add("");
            }

            Logger.Trace($"CreateConnectionChapter() für Movie '{Movie.OriginalTitle}' mit TargetLanguage '{targetLanguageCode}' beendet");
        }
    }
}
