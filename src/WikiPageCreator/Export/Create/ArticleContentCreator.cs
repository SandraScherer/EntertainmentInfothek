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
    /// Provides a content creator for an article.
    /// </summary>
    public abstract class ArticleContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The article to be used to create the content.
        /// </summary>
        public Article Article
        {
            get
            { return (Article)Entry; }
            protected set
            { Entry = value; }
        }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new ArticleContentCreator.
        /// </summary>
        /// <param name="article">The article to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected ArticleContentCreator(Article article, Formatter formatter, string targetLanguageCode)
            : base(article, formatter, targetLanguageCode)
        {
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

            Logger.Trace($"ArticleContentCreator() with ID = '{id}' created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the page name of the article page.
        /// </summary>
        /// <returns>The formatted file name for the article.</returns>
        public override string GetPageName()
        {
            Logger.Trace($"GetPageName() für Article '{Article.OriginalTitle}' aufgerufen");

            return Formatter.AsFilename($"{Article.OriginalTitle} ({Article.ReleaseDate[0..4]})");
        }

        /// <summary>
        /// Creates the page content of the entry.
        /// </summary>
        /// <returns>The formatted page content of the entry.</returns>
        public override List<string> CreatePageContent()
        {
            return CreatePageContentInternal();
        }

        /// <summary>
        /// Creates the formatted header content of a given article.
        /// </summary>
        /// <returns>The formatted haeder content of the article.</returns>
        protected override List<string> CreatePageHeader()
        {
            Logger.Trace($"CreatePageHeader() für Article '{Article.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            content.Add(Formatter.DisableCache());
            content.Add(Formatter.DisableTOC());

            content.Add(Formatter.BeginComment());
            content.Add($"   {Article.OriginalTitle}");
            content.Add($"");
            content.Add($"   @author  WikiPageCreator");
            content.Add($"   @date    {DateTime.Now:yyyy-MM-dd}");
            content.Add($"   @version {Article.Status.EnglishTitle}: {Article.LastUpdated}");
            content.Add(Formatter.EndComment());
            content.Add("");
            content.Add("");

            Logger.Trace($"CreatePageHeader() für Article '{Article.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted file title content of a given article.
        /// </summary>
        /// <returns>The formatted file title content of the article.</returns>
        protected override List<string> CreatePageTitle()
        {
            Logger.Trace($"CreatePageTitle() für Article '{Article.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            if (TargetLanguageCode.Equals("en") && !String.IsNullOrEmpty(Article.EnglishTitle))
            {
                Logger.Trace($"Title: '{Article.EnglishTitle}' (englisch)");
                content.Add(Formatter.AsHeading1(Article.EnglishTitle));
            }
            else if (TargetLanguageCode.Equals("de") && !String.IsNullOrEmpty(Article.GermanTitle))
            {
                Logger.Trace($"Title: '{Article.GermanTitle}' (deutsch)");
                content.Add(Formatter.AsHeading1(Article.GermanTitle));
            }
            else
            {
                Logger.Trace($"Title: '{Article.OriginalTitle}' (original)");
                content.Add(Formatter.AsHeading1(Article.OriginalTitle));
            }
            content.Add("");
            content.Add("");

            Logger.Trace($"CreatePageTitle() für Article '{Article.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox title content of a given article.
        /// </summary>
        /// <returns>The formatted infobox title content of the article.</returns>
        protected virtual List<string> CreateInfoBoxTitle()
        {
            Logger.Trace($"CreateInfoBoxTitle() für Article '{Article.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];

            if (TargetLanguageCode.Equals("en"))
            {
                Logger.Trace($"Title: '{Article.OriginalTitle}' (englisch)");
                data[0] = "Original Title";
                data[1] = Article.OriginalTitle;
            }
            else // incl. case "de"
            {
                Logger.Trace($"Title: '{Article.OriginalTitle}' (deutsch, ...)");
                data[0] = "Originaltitel";
                data[1] = Article.OriginalTitle;
            }
            content.Add(Formatter.AsTableRow(data));

            Logger.Trace($"CreateInfoBoxTitle() für Article '{Article.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox type content of a given article.
        /// </summary>
        /// <returns>The formatted infobox type content of the article.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxType()
        {
            Logger.Trace($"CreateInfoboxType() für Article '{Article.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            if (Article.Type != null)
            {
                content.AddRange(new TypeContentCreator(Article.Type, Formatter, TargetLanguageCode).CreateInfoBoxContent());
            }

            Logger.Trace($"CreateInfoboxType() für Article '{Article.OriginalTitle}' gestartet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox release date content of a given article.
        /// </summary>
        /// <returns>The formatted infobox release date content of the article.</returns>
        protected virtual List<string> CreateInfoBoxReleaseDate()
        {
            Logger.Trace($"CreateInfoBoxReleaseDate() für Article '{Article.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];
            string[] path = { TargetLanguageCode, "date" };

            if (!String.IsNullOrEmpty(Article.ReleaseDate))
            {
                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Trace($"Release Date: '{Article.ReleaseDate}' (englisch)");
                    data[0] = "Original Release Date";
                    data[1] = Formatter.AsInternalLink(path, Article.ReleaseDate, Article.ReleaseDate);
                }
                else // incl. case "de"
                {
                    Logger.Trace($"Release Date: '{Article.ReleaseDate}' (deutsch, ...)");
                    data[0] = "Erstausstrahlung";
                    data[1] = Formatter.AsInternalLink(path, Article.ReleaseDate, Article.ReleaseDate);
                }
                content.Add(Formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxReleaseDate() für Article '{Article.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted connection chapter content of a given article.
        /// </summary>
        /// <returns>The formatted conncetion chapter content of the article.</returns>
        protected virtual List<string> CreateChapterConnection()
        {
            Logger.Trace($"CreateChapterConnection() für Article '{Article.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            Dictionary<string, string> title = new Dictionary<string, string>();
            title.Add("en", "Connections to other articles");
            title.Add("de", "Bezüge zu anderen Artikeln");

            if (Article.Connection != null)
            {
                content.AddRange(CreateNewChapter(title));
                content.AddRange(new ConnectionContentCreator(Article.Connection, Formatter, TargetLanguageCode).CreateChapterContent());
            }

            Logger.Trace($"CreateChapterConnection() für Article '{Article.OriginalTitle}' beendet");

            return content;
        }
    }
}
