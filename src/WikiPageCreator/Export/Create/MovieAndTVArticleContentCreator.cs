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
            Logger.Trace($"MovieAndTVArticleContentCreator()");

            if (article == null)
            {
                Logger.Fatal($"Article not specified");
                throw new ArgumentNullException(nameof(article));
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

            Logger.Trace($"MovieAndTVArticleContentCreator(): MovieAndTVArticleContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the formatted infobox budget content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox budget content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxBudget()
        {
            Logger.Trace($"CreateInfoBoxBudget()");
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
            Logger.Trace($"CreateInfoBoxBudget(): infobox budget for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox worldwide gross content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox worldwide gross content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxWorldwideGross()
        {
            Logger.Trace($"CreateInfoBoxWorldwideGross()");
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
            Logger.Trace($"CreateInfoBoxWorldwideGross(): infobox worldwide gross for Series '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox country content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox country content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxCountry()
        {
            Logger.Trace($"CreateInfoBoxCountry()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.Countries != null)
            {
                Logger.Debug($"MovieAndTVArticle.Countries is not null -> create");
                content.AddRange(new CountryContentCreator(MovieAndTVArticle.Countries, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxCountry(): infobox country for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox language content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox language content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxLanguage()
        {
            Logger.Trace($"CreateInfoBoxLanguage()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.Languages != null)
            {
                Logger.Debug($"MovieAndTVArticle.Languages is not null -> create");
                content.AddRange(new LanguageContentCreator(MovieAndTVArticle.Languages, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxLanguage(): infobox language for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox runtime content of a given series.
        /// </summary>
        /// <returns>The formatted infobox runtime content of the series.</returns>
        protected virtual List<string> CreateInfoBoxRuntime()
        {
            Logger.Trace($"CreateInfoBoxRuntime()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.Runtimes != null)
            {
                Logger.Debug($"MovieAndTVArticle.Runtimes is not null -> create");
                content.AddRange(new RuntimeContentCreator(MovieAndTVArticle.Runtimes, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxRuntime(): infobox runtime for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox soundmix content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox soundmix content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxSoundMix()
        {
            Logger.Trace($"CreateInfoBoxSoundMix()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.SoundMixes != null)
            {
                Logger.Debug($"Movie.SoundMixes is not null -> create");
                content.AddRange(new SoundMixContentCreator(MovieAndTVArticle.SoundMixes, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxSoundMix(): infobox soundmix for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox color content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox color content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxColor()
        {
            Logger.Trace($"CreateInfoBoxColor()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.Colors != null)
            {
                Logger.Debug($"MovieAndTVArticle.Colors is not null -> create");
                content.AddRange(new ColorContentCreator(MovieAndTVArticle.Colors, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxColor(): infobox color for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox aspect ratio content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox aspect ratio content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxAspectRatio()
        {
            Logger.Trace($"CreateInfoBoxAspectRatio()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.AspectRatios != null)
            {
                Logger.Debug($"MovieAndTVArticle.AspectRatios is not null -> create");
                content.AddRange(new AspectRatioContentCreator(MovieAndTVArticle.AspectRatios, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxAspectRatio(): infobox aspect ratio for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox camera content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox camera content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxCamera()
        {
            Logger.Trace($"CreateInfoBoxCamera()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.Cameras != null)
            {
                Logger.Debug($"MovieAndTVArticle.Cameras is not null -> create");
                content.AddRange(new CameraContentCreator(MovieAndTVArticle.Cameras, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxCamera(): infobox camera for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox laboratory content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox laboratory content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxLaboratory()
        {
            Logger.Trace($"CreateInfoBoxLaboratory()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.Laboratories != null)
            {
                Logger.Debug($"MovieAndTVArticle.Laboratories is not null -> create");
                content.AddRange(new LaboratoryContentCreator(MovieAndTVArticle.Laboratories, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxLaboratory(): infobox laboratory for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox film length content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox film length content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxFilmLength()
        {
            Logger.Trace($"CreateInfoBoxFilmLength()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.FilmLengths != null)
            {
                Logger.Debug("MovieAndTVArticle.FilmLengths is not null -> create");
                content.AddRange(new FilmLengthContentCreator(MovieAndTVArticle.FilmLengths, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxFilmLength(): infobox film length for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox negative format content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox negative format content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxNegativeFormat()
        {
            Logger.Trace($"CreateInfoBoxNegativeFormat()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.NegativeFormats != null)
            {
                Logger.Debug($"MovieAndTVArticle.NegativeFormats is not null -> create");
                content.AddRange(new NegativeFormatContentCreator(MovieAndTVArticle.NegativeFormats, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxNegativeFormat(): infobox negative format for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox cinematographic process content of a given movie and tv article.
        /// </summary>
        /// <returns>The formatted infobox cinematographic process content of the movie and tv article.</returns>
        protected virtual List<string> CreateInfoBoxCinematographicProcess()
        {
            Logger.Trace($"CreateInfoBoxCinematographicProcess()");
            Logger.Debug($"MovieAndTVArticle is '{MovieAndTVArticle.OriginalTitle}'");

            List<string> content = new List<string>();

            if (MovieAndTVArticle.CinematographicProcesses != null)
            {
                Logger.Debug($"MovieAndTVArticle.CinematicProcesses is not null -> create");
                content.AddRange(new CinematographicProcessContentCreator(MovieAndTVArticle.CinematographicProcesses, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoBoxCinematographicProcess(): infobox cinematic processes for MovieAndTVArticle '{MovieAndTVArticle.OriginalTitle}' created");

            return content;
        }
    }
}
