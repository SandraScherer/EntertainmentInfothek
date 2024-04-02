// WikiPageCreator.exe: Creates pages for use with a wiki from the
// EntertainmentInfothek.db using EntertainmentDB.dll
// Copyright (C) 2022 Sandra Scherer

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
    /// Provides a content creator for an article.
    /// </summary>
    public abstract class MovieAndTVArticleContentCreator : ArticleContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The movie and tv article to be used to create the content.
        /// </summary>
        public MovieAndTVArticle MovieAndTVArticle
        {
            get
            { return (MovieAndTVArticle)Article; }
            protected set
            { Article = value; }
        }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new MovieAndTVArticleContentCreator.
        /// </summary>
        /// <param name="article">The movie and tv article to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected MovieAndTVArticleContentCreator(MovieAndTVArticle article, Formatter formatter, string targetLanguageCode)
            : base(article, formatter, targetLanguageCode)
        {
            Logger.Trace($"MovieAndTVArticleContentCreator(): MovieAndTVArticleContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the formatted infobox budget content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox budget content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxContentBudget()
        {
            Logger.Trace($"CreateInfoBoxContentBudget()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();
            string[] data = new string[2];

            if (!String.IsNullOrEmpty(MovieAndTVArticle.Budget))
            {
                Logger.Trace($"Budget: '{MovieAndTVArticle.Budget}'");
                data[0] = "Budget";
                data[1] = $"{MovieAndTVArticle.Budget}";

                content.Add(Formatter.AsTableRow(data));
            }
            Logger.Trace($"CreateInfoBoxContentBudget(): infobox content budget for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox worldwide gross content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox worldwide gross content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxContentWorldwideGross()
        {
            Logger.Trace($"CreateInfoBoxContentWorldwideGross()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();
            string[] data = new string[2];
            string[] path = { TargetLanguageCode, "date" };

            if (!String.IsNullOrEmpty(MovieAndTVArticle.WorldwideGross))
            {
                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"WorldwideGross: '{MovieAndTVArticle.WorldwideGross}' (english)");
                    data[0] = "Worldwide Gross";
                }
                else //incl. case "de"
                {
                    Logger.Debug($"WorldwideGross: '{MovieAndTVArticle.WorldwideGross}' (german, ...)");
                    data[0] = "Einspielergebnis (weltweit)";
                }

                if (!String.IsNullOrEmpty(MovieAndTVArticle.WorldwideGrossDate))
                {
                    data[1] = $"{MovieAndTVArticle.WorldwideGross} ({Formatter.AsInternalLink(path, MovieAndTVArticle.WorldwideGrossDate, MovieAndTVArticle.WorldwideGrossDate)})";
                }
                else
                {
                    data[1] = $"{MovieAndTVArticle.WorldwideGross}";
                }
                content.Add(Formatter.AsTableRow(data));
            }
            Logger.Trace($"CreateInfoBoxContentWorldwideGross(): infobox content worldwide gross for Series '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox country content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox country content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxContentCountry()
        {
            Logger.Trace($"CreateInfoBoxContentCountry()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.Countries != null)
            {
                Logger.Debug($"MovieAndTVArticle.Countries is not null -> create");
                content.AddRange(new CountryContentCreator(MovieAndTVArticle.Countries, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxContentCountry(): infobox content country for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox language content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox language content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxContentLanguage()
        {
            Logger.Trace($"CreateInfoBoxLanguage()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.Languages != null)
            {
                Logger.Debug($"MovieAndTVArticle.Languages is not null -> create");
                content.AddRange(new LanguageContentCreator(MovieAndTVArticle.Languages, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxContentLanguage(): infobox content language for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox runtime content of a given series.
        /// </summary>
        /// <returns>The formatted infobox runtime content of the series.</returns>
        protected virtual List<string> CreateInfoBoxContentRuntime()
        {
            Logger.Trace($"CreateInfoBoxRuntime()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.Runtimes != null)
            {
                Logger.Debug($"MovieAndTVArticle.Runtimes is not null -> create");
                content.AddRange(new RuntimeContentCreator(MovieAndTVArticle.Runtimes, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxContentRuntime(): infobox content runtime for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox soundmix content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox soundmix content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxContentSoundMix()
        {
            Logger.Trace($"CreateInfoBoxContentSoundMix()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.SoundMixes != null)
            {
                Logger.Debug($"Movie.SoundMixes is not null -> create");
                content.AddRange(new SoundMixContentCreator(MovieAndTVArticle.SoundMixes, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxContentSoundMix(): infobox content soundmix for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox color content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox color content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxContentColor()
        {
            Logger.Trace($"CreateInfoBoxContentColor()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.Colors != null)
            {
                Logger.Debug($"MovieAndTVArticle.Colors is not null -> create");
                content.AddRange(new ColorContentCreator(MovieAndTVArticle.Colors, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxContentColor(): infobox content color for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox aspect ratio content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox aspect ratio content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxContentAspectRatio()
        {
            Logger.Trace($"CreateInfoBoxContentAspectRatio()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.AspectRatios != null)
            {
                Logger.Debug($"MovieAndTVArticle.AspectRatios is not null -> create");
                content.AddRange(new AspectRatioContentCreator(MovieAndTVArticle.AspectRatios, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxContentAspectRatio(): infobox content aspect ratio for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox camera content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox camera content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxContentCamera()
        {
            Logger.Trace($"CreateInfoBoxContentCamera()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.Cameras != null)
            {
                Logger.Debug($"MovieAndTVArticle.Cameras is not null -> create");
                content.AddRange(new CameraContentCreator(MovieAndTVArticle.Cameras, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxContentCamera(): infobox content camera for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox laboratory content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox laboratory content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxContentLaboratory()
        {
            Logger.Trace($"CreateInfoBoxContentLaboratory()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.Laboratories != null)
            {
                Logger.Debug($"MovieAndTVArticle.Laboratories is not null -> create");
                content.AddRange(new LaboratoryContentCreator(MovieAndTVArticle.Laboratories, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxContentLaboratory(): infobox laboratory for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox film length content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox film length content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxContentFilmLength()
        {
            Logger.Trace($"CreateInfoBoxContentFilmLength()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.FilmLengths != null)
            {
                Logger.Debug("MovieAndTVArticle.FilmLengths is not null -> create");
                content.AddRange(new FilmLengthContentCreator(MovieAndTVArticle.FilmLengths, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxContentFilmLength(): infobox content film length for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox negative format content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox negative format content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxContentNegativeFormat()
        {
            Logger.Trace($"CreateInfoBoxContentNegativeFormat()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.NegativeFormats != null)
            {
                Logger.Debug($"MovieAndTVArticle.NegativeFormats is not null -> create");
                content.AddRange(new NegativeFormatContentCreator(MovieAndTVArticle.NegativeFormats, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxContentNegativeFormat(): infobox content negative format for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox cinematographic process content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox cinematographic process content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxContentCinematographicProcess()
        {
            Logger.Trace($"CreateInfoBoxContentCinematographicProcess()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.CinematographicProcesses != null)
            {
                Logger.Debug($"MovieAndTVArticle.CinematicProcesses is not null -> create");
                content.AddRange(new CinematographicProcessContentCreator(MovieAndTVArticle.CinematographicProcesses, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxContentCinematographicProcess(): infobox content cinematic processes for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox printed film format content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox printed film format content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxContentPrintedFilmFormat()
        {
            Logger.Trace($"CreateInfoBoxContentPrintedFilmFormat()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.PrintedFilmFormats != null)
            {
                Logger.Debug($"MovieAndTVArticle.PrintedFilmFormats is not null -> create");
                content.AddRange(new PrintedFilmFormatContentCreator(MovieAndTVArticle.PrintedFilmFormats, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxContentPrintedFilmFormat(): infobox content printed film format for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted company chapter content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted company chapter content of the movie and tv article.</returns>
        protected virtual List<string> CreateChapterCompany()
        {
            Logger.Trace($"CreateChapterCompany()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Company Credits");
            title.Add("de", "Beteiligte Firmen");

            // TODO: implement following stuff
            content.AddRange(CreateChapterHeading(title));

            if (MovieAndTVArticle.ProductionCompanies != null)
            {
                Logger.Debug($"MovieAndTVArticle.ProductionCompanies is not null -> create");
                Dictionary<string, string> titleSection = new Dictionary<string, string>();
                titleSection.Add("en", "Production Companies");
                titleSection.Add("de", "Produktionsfirmen");
                content.AddRange(CreateSectionHeading(titleSection));
                content.AddRange(new CompanyContentCreator(MovieAndTVArticle.ProductionCompanies, Formatter, TargetLanguageCode).CreateSectionContent());
            }
            //if (MovieAndTVArticle.Distributors != null)
            //{
            //    Logger.Debug($"MovieAndTVArticle.Distributors is not null -> create");
            //    Dictionary<string, string> titleSection = new Dictionary<string, string>();
            //    titleSection.Add("en", "Distributors");
            //    titleSection.Add("de", "Vertrieb");
            //    content.AddRange(CreateSectionHeading(titleSection));
            //    content.AddRange(new DistributorContentCreator(MovieAndTVArticle.Distributors, Formatter, TargetLanguageCode).CreateSectionContent());
            //}

            Logger.Trace($"CreateChapterCompany(): chapter companies for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted filming and production chapter content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted filming and production chapter content of the movie and tv article.</returns>
        protected virtual List<string> CreateChapterFilmingAndProduction()
        {
            Logger.Trace($"CreateChapterFilmingAndProduction()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Filming and Production");
            title.Add("de", "Produktion");

            content.AddRange(CreateChapterHeading(title));

            if (MovieAndTVArticle.FilmingLocations != null)
            {
                Logger.Debug($"MovieAndTVArticle.FilmingLocations is not null -> create");
                Dictionary<string, string> titleSection = new Dictionary<string, string>();
                titleSection.Add("en", "Filming Locations");
                titleSection.Add("de", "Drehorte");
                content.AddRange(CreateSectionHeading(titleSection));
                content.AddRange(new LocationContentCreator(MovieAndTVArticle.FilmingLocations, Formatter, TargetLanguageCode).CreateSectionContent());
            }
            if (MovieAndTVArticle.FilmingDates != null)
            {
                Logger.Debug($"MovieAndTVArticle.FilmingDates is not null -> create");
                Dictionary<string, string> titleSection = new Dictionary<string, string>();
                titleSection.Add("en", "Filming Dates");
                titleSection.Add("de", "Drehdaten");
                content.AddRange(CreateSectionHeading(titleSection));
                content.AddRange(new FilmingDateContentCreator(MovieAndTVArticle.FilmingDates, Formatter, TargetLanguageCode).CreateSectionContent());
            }
            if (MovieAndTVArticle.ProductionDates != null)
            {
                Logger.Debug($"MovieAndTVArticle.ProductionDates is not null -> create");
                Dictionary<string, string> titleSection = new Dictionary<string, string>();
                titleSection.Add("en", "Production Dates");
                titleSection.Add("de", "Produktionsdaten");
                content.AddRange(CreateSectionHeading(titleSection));
                content.AddRange(new ProductionDateContentCreator(MovieAndTVArticle.ProductionDates, Formatter, TargetLanguageCode).CreateSectionContent());
            }

            Logger.Trace($"CreateChapterFilmingAndProduction(): chapter filming and production for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }
    }
}
