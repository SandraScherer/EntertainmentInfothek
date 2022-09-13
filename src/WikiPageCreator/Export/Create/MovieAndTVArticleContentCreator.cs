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
    }
}
