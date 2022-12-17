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
using WikiPageCreator.Export.Format;

namespace WikiPageCreator.Export.Create
{
    /// <summary>
    /// Provides a file content crator for a movie.
    /// </summary>
    [Obsolete("Please use MovieContentCreator", false)]
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
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new movie file content creator with the given movie.
        /// </summary>
        /// <param name="movie"></param>
        public MovieFileContentCreator(Movie movie)
        {
            Logger.Trace($"MovieFileContentCreator()");

            if (movie == null)
            {
                Logger.Fatal($"Movie not specified");
                throw new ArgumentNullException(nameof(movie));
            }

            Movie = movie;

            Logger.Trace($"MovieFileContentCreator(): MovieFileContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the file name of the movie page.
        /// </summary>
        /// <returns>The formatted file name.</returns>
        public string GetFileName()
        {
            Logger.Trace($"GetFileName()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}' from '{Movie.ReleaseDate}'");

            return Formatter.AsFilename($"{Movie.OriginalTitle} ({Movie.ReleaseDate[0..4]})");
        }

        /// <summary>
        /// Creates the formatted content of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <returns>The formatted content of the movie.</returns>
        public List<string> CreateContent(string targetLanguageCode)
        {
            Logger.Trace($"CreateContent()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

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

            Logger.Trace($"CreateContent(): content for Movie '{Movie.OriginalTitle}' created");

            return Content;
        }

        // Header and End (Footer)

        /// <summary>
        /// Creates the formatted header of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateHeader(string targetLanguageCode)
        {
            Logger.Trace($"CreateHeader()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

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

            Logger.Trace($"CreateHeader(): header for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted footer of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateFooter(string targetLanguageCode)
        {
            Logger.Trace($"CreateFooter()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            // nothing to do at the moment

            Logger.Trace($"CreateFooter(): footer for Movie '{Movie.OriginalTitle}' created");
        }

        // Title

        /// <summary>
        /// Creates the formatted title of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateTitle(string targetLanguageCode)
        {
            Logger.Trace($"CreateTitle()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if (targetLanguageCode.Equals("en") && !String.IsNullOrEmpty(Movie.EnglishTitle))
            {
                Logger.Debug($"Title: '{Movie.EnglishTitle}' (english)");
                Content.Add(Formatter.AsHeading1(Movie.EnglishTitle));
            }
            else if (targetLanguageCode.Equals("de") && !String.IsNullOrEmpty(Movie.GermanTitle))
            {
                Logger.Debug($"Title: '{Movie.GermanTitle}' (german)");
                Content.Add(Formatter.AsHeading1(Movie.GermanTitle));
            }
            else
            {
                Logger.Debug($"Title: '{Movie.OriginalTitle}' (original)");
                Content.Add(Formatter.AsHeading1(Movie.OriginalTitle));
            }
            Content.Add("");

            Logger.Trace($"CreateTitle(): title for Movie '{Movie.OriginalTitle}' created");
        }

        // Info Box: Header and End (Footer)

        /// <summary>
        /// Creates the formatted infobox header of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxHeader(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxHeader()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Content.Add(Formatter.BeginBox(475, Alignment.Right));
            int[] width = { 30, 70 };
            Content.Add(Formatter.DefineTable(445, width));

            Logger.Trace($"CreateInfoBoxHeader(): infobox header for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox footer of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxEnd(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxEnd()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Content.Add(Formatter.EndBox());
            Content.Add("");
            Content.Add("");

            Logger.Trace($"CreateInfoBoxEnd(): infobox end for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox title field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxTitle(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxTitle()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            string[] data = new string[2];

            if (targetLanguageCode.Equals("en"))
            {
                Logger.Debug($"Title: '{Movie.OriginalTitle}' (english)");
                data[0] = "Original Title";
                data[1] = Movie.OriginalTitle;
            }
            else // incl. case "de"
            {
                Logger.Debug($"Title: '{Movie.OriginalTitle}' (german, ...)");
                data[0] = "Originaltitel";
                data[1] = Movie.OriginalTitle;
            }
            Content.Add(Formatter.AsTableRow(data));

            Logger.Trace($"CreateInfoBoxTitle(): infobox title for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox logo field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxLogo(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxLogo()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if (Movie.Logo != null)
            {
                Logger.Debug($"Movie.Logo is not null");

                string[] data = new string[2];
                string[] path = { "cinema_and_television_movie" };

                if (targetLanguageCode.Equals("en") && !String.IsNullOrEmpty(Movie.Logo.Type.EnglishTitle))
                {
                    Logger.Debug($"Logo: '{Movie.Logo.FileName}' (english)");
                    data[0] = Formatter.AsImage(path, Movie.Logo.FileName, 450, Movie.Logo.Type.EnglishTitle);
                }
                else if (!String.IsNullOrEmpty(Movie.Logo.Type.GermanTitle))
                {
                    Logger.Debug($"Logo: '{Movie.Logo.FileName}' (german, ...)");
                    data[0] = Formatter.AsImage(path, Movie.Logo.FileName, 450, Movie.Logo.Type.GermanTitle);
                }
                else
                {
                    Logger.Debug($"Logo: '{Movie.Logo.FileName}' (without type)");
                    data[0] = Formatter.AsImage(path, Movie.Logo.FileName, 450);
                }
                Content.Add(Formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxLogo(): infobox logo for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox type field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxType(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxType()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if (Movie.Type != null)
            {
                Logger.Debug($"Movie.Type is not null");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "info" };

                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"Type: '{Movie.Type.EnglishTitle}' (english)");
                    data[0] = "Type";
                    data[1] = Formatter.AsInternalLink(path, Movie.Type.EnglishTitle, Movie.Type.EnglishTitle);
                }
                else // incl. case "de"
                {
                    Logger.Debug($"Type: '{Movie.Type.GermanTitle}' (german, ...)");
                    data[0] = "Typ";
                    data[1] = Formatter.AsInternalLink(path, Movie.Type.EnglishTitle, Movie.Type.GermanTitle);
                }
                Content.Add(Formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxType(): infobox type for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox release date field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxOriginalReleaseDate(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxOriginalReleaseDate()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if (!String.IsNullOrEmpty(Movie.ReleaseDate))
            {
                Logger.Debug($"Movie.ReleaseDate is not null or empty");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "date" };

                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"ReleaseDate: '{Movie.ReleaseDate}' (english)");
                    data[0] = "Original Release Date";
                    data[1] = Formatter.AsInternalLink(path, Movie.ReleaseDate, Movie.ReleaseDate);
                }
                else // incl. case "de"
                {
                    Logger.Debug($"ReleaseDate: '{Movie.ReleaseDate}' (german, ...)");
                    data[0] = "Erstausstrahlung";
                    data[1] = Formatter.AsInternalLink(path, Movie.ReleaseDate, Movie.ReleaseDate);
                }
                Content.Add(Formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxOriginalReleaseDate(): infobox release date for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox genre field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxGenre(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxGenre()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.Genres != null) && (Movie.Genres.Count > 0))
            {
                Logger.Debug($"Movie.Genres is not null");
                Logger.Debug($"no of genres: '{Movie.Genres.Count}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "info" };

                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"Genre: '{Movie.Genres[0].Genre.EnglishTitle}' (english)");

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
                        Logger.Debug($"Genre: '{Movie.Genres[i].Genre.EnglishTitle}' (english)");

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
                    Logger.Debug($"Genre: '{Movie.Genres[0].Genre.GermanTitle}' (german, ...)");

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
                        Logger.Debug($"Genre: '{Movie.Genres[i].Genre.GermanTitle}' (german, ...)");

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

            Logger.Trace($"CreateInfoBoxGenre(): infobox genres for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox certification field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxCertification(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxCertification()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.Certifications != null) && (Movie.Certifications.Count > 0))
            {
                Logger.Debug($"Movie.Certifications is not null");
                Logger.Debug($"no of certifications: '{Movie.Certifications.Count}'");

                string[] data = new string[2];
                string[] path = { "certification" };

                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"Certification: '{Movie.Certifications[0].Certification.Name}' (english)");

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
                        Logger.Debug($"Certification: '{Movie.Certifications[i].Certification.Name}' (english)");

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
                    Logger.Debug($"Certification: '{Movie.Certifications[0].Certification.Name}' (german, ...)");

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
                        Logger.Debug($"Certification: '{Movie.Certifications[i].Certification.Name}' (german, ...)");

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

            Logger.Trace($"CreateInfoBoxCertification(): infobox certifications for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox country field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxCountry(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxCountry()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.Countries != null) && (Movie.Countries.Count > 0))
            {
                Logger.Debug($"Movie.Countries is not null");
                Logger.Debug($"no of countries: '{Movie.Countries.Count}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "info" };

                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"Country: '{Movie.Countries[0].Country.EnglishShortName}' (english)");

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
                        Logger.Debug($"Country: '{Movie.Countries[i].Country.EnglishShortName}' (english)");

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
                    Logger.Debug($"Country: '{Movie.Countries[0].Country.GermanShortName}' (german, ...)");

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
                        Logger.Debug($"Country: '{Movie.Countries[i].Country.GermanShortName}' (german, ...)");

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

            Logger.Trace($"CreateInfoBoxCountry(): infobox countries for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox language field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateInfoBoxLanguage(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxLanguage()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.Languages != null) && (Movie.Languages.Count > 0))
            {
                Logger.Debug($"Movie.Languages is not null");
                Logger.Debug($"no of languages: '{Movie.Languages.Count}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "info" };

                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"Language: '{Movie.Languages[0].Language.EnglishName}' (english)");

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
                        Logger.Debug($"Language: '{Movie.Languages[i].Language.EnglishName}' (english)");

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
                    Logger.Debug($"Language: '{Movie.Languages[0].Language.GermanName}' (german, ...)");

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
                        Logger.Debug($"Language: '{Movie.Languages[i].Language.GermanName}' (german, ...)");

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

            Logger.Trace($"CreateInfoBoxLanguage(): infobox languages for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox budget field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxBudget(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxBudget()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if (!String.IsNullOrEmpty(Movie.Budget))
            {
                Logger.Debug($"Movie.Budget is not null or empty");
                Logger.Debug($"Budget: '{Movie.Budget}'");

                string[] data = new string[2];

                data[0] = "Budget";
                data[1] = $"{Movie.Budget}";
                Content.Add(Formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxBudget(): infobox budget for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox worldwide gross field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxWorldwideGross(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxWorldwideGross()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if (!String.IsNullOrEmpty(Movie.WorldwideGross))
            {
                Logger.Debug($"Movie.WorldwideGross is not null or empty");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "date" };

                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"WorldwideGross: '{Movie.WorldwideGross}' (english)");

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
                    Logger.Debug($"WorldwideGross: '{Movie.WorldwideGross}' (german, ...)");

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

            Logger.Trace($"CreateInfoBoxWorldwideGross(): infobox worldwide gross for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox runtime field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxRuntime(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxRuntime()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.Runtimes != null) && (Movie.Runtimes.Count > 0))
            {
                Logger.Debug($"Movie.Runtimes is not null");
                Logger.Debug($"no of runtimes: '{Movie.Runtimes.Count}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "info" };

                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"Runtime: '{Movie.Runtimes[0].Runtime}' (english)");

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
                        Logger.Debug($"Runtime: '{Movie.Runtimes[i].Runtime}' (english)");

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
                    Logger.Debug($"Runtime: '{Movie.Runtimes[0].Runtime}' (german, ...)");

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
                        Logger.Debug($"Runtime: '{Movie.Runtimes[i].Runtime}' (german, ...)");

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

            Logger.Trace($"CreateInfoBoxRuntime(): infobox runtimes for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox sound mixes field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxSoundMix(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxSoundMixes()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.SoundMixes != null) && (Movie.SoundMixes.Count > 0))
            {
                Logger.Debug($"Movie.SoundMixes is not null");
                Logger.Debug($"no of sound mixes: '{Movie.SoundMixes.Count}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "info" };

                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"SoundMix: '{Movie.SoundMixes[0].SoundMix.EnglishTitle}' (english)");

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
                        Logger.Debug($"SoundMix: '{Movie.SoundMixes[i].SoundMix.EnglishTitle}' (english)");

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
                    Logger.Debug($"SoundMix: '{Movie.SoundMixes[0].SoundMix.GermanTitle}' (german, ...)");

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
                        Logger.Debug($"SoundMix: '{Movie.SoundMixes[i].SoundMix.GermanTitle}' (german, ...)");

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

            Logger.Trace($"CreateInfoBoxBoxSound(): infobox soundmixes for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox color field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxColor(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxColor()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.Colors != null) && (Movie.Colors.Count > 0))
            {
                Logger.Debug($"Movie.Colors is not null");
                Logger.Debug($"no of colors: '{Movie.Colors.Count}'");

                string[] data = new string[2];
                string[] path = { targetLanguageCode, "info" };

                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"Color: '{Movie.Colors[0].Color.EnglishTitle}' (english)");

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
                        Logger.Debug($"Color: '{Movie.Colors[i].Color.EnglishTitle}' (english)");

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
                    Logger.Debug($"Color: '{Movie.Colors[0].Color.GermanTitle}' (german, ...)");

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
                        Logger.Debug($"Color: '{Movie.Colors[i].Color.GermanTitle}' (german, ...)");

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

            Logger.Trace($"CreateInfoBoxColor(): infobox colors for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox aspect ratio field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxAspectRatio(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxAspectRatio()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.AspectRatios != null) && (Movie.AspectRatios.Count > 0))
            {
                Logger.Debug($"Movie.AspectRatios is not null");
                Logger.Debug($"no of aspect ratios: '{Movie.AspectRatios.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"AspectRatio: '{Movie.AspectRatios[0].AspectRatio.Ratio}' (english)");

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
                        Logger.Debug($"AspectRatio: '{Movie.AspectRatios[i].AspectRatio.Ratio}' (english)");

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
                    Logger.Debug($"AspectRatio: '{Movie.AspectRatios[0].AspectRatio.Ratio}' (german, ...)");

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
                        Logger.Debug($"AspectRatio: '{Movie.AspectRatios[i].AspectRatio.Ratio}' (german, ...)");

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

            Logger.Trace($"CreateInfoBoxAspectRatio(): infobox aspectratios for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox camera field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxCamera(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxCamera()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.Cameras != null) && (Movie.Cameras.Count > 0))
            {
                Logger.Debug($"Movie.Cameras is not null");
                Logger.Debug($"no of cameras: '{Movie.Cameras.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"Camera: '{Movie.Cameras[0].Camera.Name}, {Movie.Cameras[0].Camera.Lenses}' (english)");

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
                        Logger.Debug($"Camera: '{Movie.Cameras[i].Camera.Name}, {Movie.Cameras[i].Camera.Lenses}' (english)");

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
                    Logger.Debug($"Camera: '{Movie.Cameras[0].Camera.Name}, {Movie.Cameras[0].Camera.Lenses}' (german, ...)");

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
                        Logger.Debug($"Camera: '{Movie.Cameras[i].Camera.Name}, {Movie.Cameras[i].Camera.Lenses}' (german, ...)");

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

            Logger.Trace($"CreateInfoBoxCamera(): infobox cameras for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox laboratory field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxLaboratory(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxLaboratory()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.Laboratories != null) && (Movie.Laboratories.Count > 0))
            {
                Logger.Debug($"Movie.Laboratories is not null");
                Logger.Debug($"no of laboratories: '{Movie.Laboratories.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"Laboratory: '{Movie.Laboratories[0].Laboratory.Name}' (english)");

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
                        Logger.Debug($"Laboratory: '{Movie.Laboratories[i].Laboratory.Name}' (english)");

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
                    Logger.Debug($"Laboratory: '{Movie.Laboratories[0].Laboratory.Name}' (german, ...)");

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
                        Logger.Debug($"Laboratory: '{Movie.Laboratories[i].Laboratory.Name}' (german, ...)");

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

            Logger.Trace($"CreateInfoBoxLaboratory(): infobox laboratories for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox film length field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxFilmLength(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxFilmLength()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.FilmLengths != null) && (Movie.FilmLengths.Count > 0))
            {
                Logger.Debug($"Movie.FilmLengths is not null");
                Logger.Debug($"no of film lengths: '{Movie.FilmLengths.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"FilmLength: '{Movie.FilmLengths[0].Length}' (english)");

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
                        Logger.Debug($"FilmLength: '{Movie.FilmLengths[i].Length}' (english)");

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
                    Logger.Debug($"FilmLength: '{Movie.FilmLengths[0].Length}' (german, ...)");

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
                        Logger.Debug($"FilmLength: '{Movie.FilmLengths[i].Length}' (german, ...)");

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

            Logger.Trace($"CreateInfoBoxFilmLength(): infobox filmlenghts for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox negative format field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxNegativeFormat(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxNegativeFormat()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.NegativeFormats != null) && (Movie.NegativeFormats.Count > 0))
            {
                Logger.Debug($"Movie.NegativeFormats is not null");
                Logger.Debug($"no of negative formats: '{Movie.NegativeFormats.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"NegativeFormat: '{Movie.NegativeFormats[0].FilmFormat.Format}' (english)");

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
                        Logger.Debug($"NegativeFormat: '{Movie.NegativeFormats[i].FilmFormat.Format}' (english)");

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
                    Logger.Debug($"NegativeFormat: '{Movie.NegativeFormats[0].FilmFormat.Format}' (german, ...)");

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
                        Logger.Debug($"NegativeFormat: '{Movie.NegativeFormats[i].FilmFormat.Format}' (german, ...)");

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

            Logger.Trace($"CreateInfoBoxNegativeFormat(): infobox negative formats for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox cinematographic process field of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxCinematographicProcess(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxCinematographicProcess()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.CinematographicProcesses != null) && (Movie.CinematographicProcesses.Count > 0))
            {
                Logger.Debug($"Movie.CinematographicProcesses is not null");
                Logger.Debug($"no of cinematographic processes: '{Movie.CinematographicProcesses.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"CinematographicProcess: '{Movie.CinematographicProcesses[0].CinematographicProcess.Name}' (english)");

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
                        Logger.Debug($"CinematographicProcess: '{Movie.CinematographicProcesses[i].CinematographicProcess.Name}' (english)");

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
                    Logger.Debug($"CinematographicProcess: '{Movie.CinematographicProcesses[0].CinematographicProcess.Name}' (german, ...)");

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
                        Logger.Debug($"CinematographicProcess: '{Movie.CinematographicProcesses[i].CinematographicProcess.Name}' (german, ...)");

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

            Logger.Trace($"CreateInfoBoxCinematographicProcess(): infobox cinematographic processes for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted infobox printed film format of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public void CreateInfoBoxPrintedFilmFormat(string targetLanguageCode)
        {
            Logger.Trace($"CreateInfoBoxPrintedFilmFormat()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.PrintedFilmFormats != null) && (Movie.PrintedFilmFormats.Count > 0))
            {
                Logger.Debug($"Movie.PrintedFilmFormats is not null");
                Logger.Debug($"no of film formats: '{Movie.PrintedFilmFormats.Count}'");

                string[] data = new string[2];

                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"PrintedFilmFormat: '{Movie.PrintedFilmFormats[0].FilmFormat.Format}' (english)");

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
                        Logger.Debug($"PrintedFilmFormat: '{Movie.PrintedFilmFormats[i].FilmFormat.Format}' (english)");

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
                    Logger.Debug($"PrintedFilmFormat: '{Movie.PrintedFilmFormats[0].FilmFormat.Format}' (german, ...)");

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
                        Logger.Debug($"PrintedFilmFormat: '{Movie.PrintedFilmFormats[i].FilmFormat.Format}' (german, ...)");

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

            Logger.Trace($"CreateInfoBoxPrintedFilmFormat(): infobox printed filmformats for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted poster chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreatePosterChapter(string targetLanguageCode)
        {
            Logger.Trace($"CreatePosterChapter()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.Posters != null) && (Movie.Posters.Count > 0))
            {
                Logger.Debug($"Movie.Posters is not null -> create");

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
            Logger.Trace($"CreatePosterChapter(): chapter posters for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted cover chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateCoverChapter(string targetLanguageCode)
        {
            Logger.Trace($"CreateCoverChapter()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.Covers != null) && (Movie.Covers.Count > 0))
            {
                Logger.Debug($"Movie.Covers is not null -> create");

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

            Logger.Trace($"CreateCoverChapter(): chapter covers for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted description chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateDescriptionChapter(string targetLanguageCode)
        {
            Logger.Trace($"CreateDescriptionChapter()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.Descriptions != null) && (Movie.Descriptions.Count > 0))
            {
                Logger.Debug($"Movie.Descriptions is not null -> create");

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

            Logger.Trace($"CreateDescriptionChapter(): chapter descriptions for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted review chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateReviewChapter(string targetLanguageCode)
        {
            Logger.Trace($"CreateReviewChapter()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.Reviews != null) && (Movie.Reviews.Count > 0))
            {
                Logger.Debug($"Movie.Reviews is not null -> create");

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

            Logger.Trace($"CreateReviewChapter(): chapter reviews for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates a formatted text section of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="texts">The list of texts for the section.</param>
        private void CreateTextItemSection(string targetLanguageCode, List<TextItem> texts)
        {
            Logger.Trace($"CreateTextItemSection()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (texts == null)
            {
                Logger.Fatal($"Texts not specified");
                throw new ArgumentNullException(nameof(texts));
            }

            if (texts.Count > 0)
            {
                Logger.Debug($"no of texts: '{texts.Count}'");

                string data;
                string[] pathBiography = { targetLanguageCode, "biography" };
                string[] pathCompany = { targetLanguageCode, "company" };

                for (int i = 0; i < texts.Count; i++)
                {
                    if ((targetLanguageCode.Equals("en") && texts[i].Text.Language.ID.Equals("en")) ||
                       (targetLanguageCode.Equals("de") && texts[i].Text.Language.ID.Equals("de")))
                    {
                        Logger.Debug($"Text with correct language");
                        data = texts[i].Text.Content;
                    }
                    else
                    {
                        Logger.Debug($"Text with incorrect language -> use anyway for now");
                        data = texts[i].Text.Content;
                    }
                    Content.Add(data);

                    data = "";

                    if (texts[i].Text.Authors != null)
                    {
                        Logger.Debug($"Text.Authors not null");
                        Logger.Debug($"no of authors:  {texts[i].Text.Authors.Count}");

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
                        Logger.Debug($"Text.Sources is not null");
                        Logger.Debug($"no of sources:  {texts[i].Text.Sources.Count}");

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

            Logger.Trace($"CreateTextItemSection(): section text items for movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted image chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateImageChapter(string targetLanguageCode)
        {
            Logger.Trace($"CreateImageChapter()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.Images != null) && (Movie.Images.Count > 0))
            {
                Logger.Debug($"Movie.Images is not null -> create");

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

            Logger.Trace($"CreateImageChapter(): chapter image for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates a formatted image section of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="images">The list of images for the section.</param>
        private void CreateImageItemSection(string targetLanguageCode, List<ImageItem> images)
        {
            Logger.Trace($"CreateImageItemSection()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (images == null)
            {
                Logger.Fatal($"Images not specified");
                throw new ArgumentNullException(nameof(images));
            }

            if (images.Count > 0)
            {
                Logger.Trace($"no of images: '{images.Count}'");

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
                        Logger.Trace($"no of sources:  '{images[i].Image.Sources.Count}'");

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
                }

                Content.Add("");
            }

            Logger.Trace($"CreateImageItemSection(): chapter image for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted cast and crew chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateCastAndCrewChapter(string targetLanguageCode)
        {
            Logger.Trace($"CreateCastAndCrewChapter()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

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
                Logger.Debug($"Movie.CrewStatus is not null");

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

            Logger.Trace($"CreateCastAndCrewChapter(): chapter cast and crew for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates a formatted person section of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="heading">The heading for the section; [0] english; [1] german.</param>
        /// <param name="persons">The list of persons for the section.</param>
        private void CreatePersonItemSection(string targetLanguageCode, string[] heading, List<PersonItem> persons)
        {
            Logger.Trace($"CreatePersonItemSection()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((persons != null) && (persons.Count > 0))
            {
                Logger.Trace($"no of persons ({heading[0]}): '{persons.Count}'");

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

            Logger.Trace($"CreatePersonItemSection(): section person item for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates a formatted cast person section of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="heading">The heading for the section; [0] english; [1] german.</param>
        /// <param name="persons">The list of persons for the section.</param>
        private void CreateCastPersonItemSection(string targetLanguageCode, string[] heading, List<CastPersonItem> persons)
        {
            Logger.Trace($"CreateCastPersonItemSection()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (persons == null)
            {
                Logger.Fatal($"Persons not specified");
                throw new ArgumentNullException(nameof(persons));
            }

            if (persons.Count > 0)
            {
                Logger.Trace($"no of persons ({heading[0]}): '{persons.Count}'");

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

            Logger.Trace($"CreateCastPersonItemSection(): section cast person item for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted company chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateCompanyChapter(string targetLanguageCode)
        {
            Logger.Trace($"CreateCompanyChapter()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

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

            Logger.Trace($"CreateCompanyChapter(): chapter companies for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates a formatted company section of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="heading">The heading for the section; [0] english; [1] german.</param>
        /// <param name="companies">The list of companies for the section.</param>
        private void CreateCompanyItemSection(string targetLanguageCode, string[] heading, List<CompanyItem> companies)
        {
            Logger.Trace($"CreateCompanyItemSection()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((companies != null) && (companies.Count > 0))
            {
                Logger.Trace($"no of companies ({heading[0]}):  '{companies.Count}'");

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

            Logger.Trace($"CreateCompanyItemSection(): section company items for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates a formatted distributor company section of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="heading">The heading for the section; [0] english; [1] german.</param>
        /// <param name="companies">The list of distributor companies for the section.</param>
        private void CreateDistributorCompanyItemSection(string targetLanguageCode, string[] heading, List<DistributorCompanyItem> companies)
        {
            Logger.Trace($"CreateDistributorCompanyItemSection()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if (companies != null)
            {
                Logger.Trace($"no of companies ({heading[0]}): '{companies.Count}'");

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

            Logger.Trace($"CreateDistributorCompanyItemSection(): section distributor company items for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted filming and production chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateFilmingAndProductionChapter(string targetLanguageCode)
        {
            Logger.Trace($"CreateFilmingAndProductionChapter()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

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
                    Logger.Debug($"Movie.FilmingLocations is not null");
                    Logger.Debug($"no of filming locations: '{Movie.FilmingLocations.Count}'");

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
                    Logger.Debug($"Movie.FilmingDates is not null");
                    Logger.Debug($"no of filming dates: '{Movie.FilmingDates.Count}'");

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
                    Logger.Debug($"Movie.ProductionDates is not null");
                    Logger.Debug($"no of production dates: '{Movie.ProductionDates.Count}'");

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

            Logger.Trace($"CreateFilmingAndProductionChapter(): chapter filming and production for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted award chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateAwardChapter(string targetLanguageCode)
        {
            Logger.Trace($"CreateAwardChapter()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.Awards != null) && (Movie.Awards.Count > 0))
            {
                Logger.Debug($"Movie.Awards is not null");
                Logger.Debug($"no of awards: '{Movie.Awards.Count}'");

                if (targetLanguageCode.Equals("en"))
                {
                    Content.Add(Formatter.AsHeading2("Awards"));
                }
                else // incl. case "de"
                {
                    Content.Add(Formatter.AsHeading2("Auszeichnungen"));
                }

                string[] data = new string[5];
                string[] path = { targetLanguageCode, "info" };
                string[] pathDate = { targetLanguageCode, "date" };
                string[] dataPersons = new string[5];
                string[] pathPersons = { targetLanguageCode, "biography" };

                for (int i = 0; i < Movie.Awards.Count; i++)
                {
                    data[0] = $"{Formatter.AsInternalLink(path, Movie.Awards[i].Award.Name, Movie.Awards[i].Award.Name)}";
                    data[1] = $"{Formatter.AsInternalLink(pathDate, Movie.Awards[i].Date, Movie.Awards[i].Date)}";
                    data[2] = $"{Movie.Awards[i].Category}";
                    if (targetLanguageCode.Equals("en"))
                    {
                        if (Movie.Awards[i].Winner.Equals("1"))
                        {
                            data[3] = "Winner";
                        }
                        else
                        {
                            data[3] = "Nominee";
                        }
                    }
                    else // incl. case "de"
                    {
                        if (Movie.Awards[i].Winner.Equals("1"))
                        {
                            data[3] = "Gewinner";
                        }
                        else
                        {
                            data[3] = "Nominierter";
                        }

                    }
                    if (!String.IsNullOrEmpty(Movie.Awards[i].Details))
                    {
                        data[4] = $"{Movie.Awards[i].Details}";
                    }
                    else
                    {
                        data[4] = " ";
                    }
                    Content.Add(Formatter.AsTableRow(data));

                    if ((Movie.Awards[i].Persons != null) && (Movie.Awards[i].Persons.Count > 0))
                    {
                        for (int j = 0; j < Movie.Awards[i].Persons.Count; j++)
                        {
                            dataPersons[0] = Formatter.CellSpanVertically();
                            dataPersons[1] = Formatter.CellSpanVertically();

                            if (!String.IsNullOrEmpty(Movie.Awards[i].Persons[j].Person.Name) && !String.IsNullOrEmpty(Movie.Awards[i].Persons[j].Person.NameAddOn))
                            {
                                dataPersons[2] = Formatter.AsInternalLink(pathPersons, $"{Movie.Awards[i].Persons[j].Person.Name} {Movie.Awards[i].Persons[j].Person.NameAddOn}", $"{Movie.Awards[i].Persons[j].Person.Name}");
                            }
                            else
                            {
                                dataPersons[2] = Formatter.AsInternalLink(pathPersons, $"{Movie.Awards[i].Persons[j].Person.Name}", $"{Movie.Awards[i].Persons[j].Person.Name}");
                            }

                            if (!String.IsNullOrEmpty(Movie.Awards[i].Persons[j].Role) && !String.IsNullOrEmpty(Movie.Awards[i].Persons[j].Details))
                            {
                                dataPersons[2] = dataPersons[2] + $" ({Movie.Awards[i].Persons[j].Role}) {Movie.Awards[i].Persons[j].Details}";
                            }
                            else if (!String.IsNullOrEmpty(Movie.Awards[i].Persons[j].Role))
                            {
                                dataPersons[2] = dataPersons[2] + $" ({Movie.Awards[i].Persons[j].Role})";
                            }
                            else if (!String.IsNullOrEmpty(Movie.Awards[i].Persons[j].Details))
                            {
                                dataPersons[2] = dataPersons[2] + $" {Movie.Awards[i].Persons[j].Details}";
                            }
                            else
                            {
                                // nothing to do
                            }

                            dataPersons[3] = " ";
                            dataPersons[4] = " ";
                            Content.Add(Formatter.AsTableRow(dataPersons));
                        }
                    }
                }

                Content.Add("");
                Content.Add("");
            }

            Logger.Trace($"CreateAwardChapter(): chapter awards for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted weblink chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateWeblinkChapter(string targetLanguageCode)
        {
            Logger.Trace($"CreateWeblinkChapter()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if ((Movie.Weblinks != null) && (Movie.Weblinks.Count > 0))
            {
                Logger.Debug($"Movie.Weblinks is not null");
                Logger.Debug($"no of weblinks: '{Movie.Weblinks.Count}'");

                if (targetLanguageCode.Equals("en"))
                {
                    Content.Add(Formatter.AsHeading2("Other Sites"));
                }
                else // incl. case "de"
                {
                    Content.Add(Formatter.AsHeading2("Andere Webseiten"));
                }

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

            Logger.Trace($"CreateWeblinkChapter(): chapter weblinks for Movie '{Movie.OriginalTitle}' created");
        }

        /// <summary>
        /// Creates the formatted connection chapter of the movie page.
        /// </summary>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        public virtual void CreateConnectionChapter(string targetLanguageCode)
        {
            Logger.Trace($"CreateConnectionChapter()");
            Logger.Debug($"Movie is '{Movie.OriginalTitle}'");

            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            if (Movie.Connection != null)
            {
                Logger.Debug($"Movie.Connection is not null");

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

            Logger.Trace($"CreateConnectionChapter(): chapter connections for Movie '{Movie.OriginalTitle}' created");
        }
    }
}
