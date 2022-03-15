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
    public abstract class ArticleContentCreator : IFileContentCreatable
    {
        // --- Properties ---

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new ArticleContentCreator.
        /// </summary>
        protected ArticleContentCreator()
        {
            Logger.Trace($"ArticleContentCreator() angelegt");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the file name of the article page (or not).
        /// </summary>
        /// <param name="entry">The entry that is to be used to create the file name.</param>
        /// <param name="formatter">The formatter that is to be used to format the file name.</param>
        /// <returns>The formatted file name.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public virtual string GetFileName(Entry entry, Formatter formatter)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            return GetFileName((Article)entry, formatter);
        }

        /// <summary>
        /// Creates the file name of the article page.
        /// </summary>
        /// <param name="article">The article that is to be used to create the file name.</param>
        /// <param name="formatter">The formatter that is to be used to format the file name.</param>
        /// <returns>The formatted file name.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public virtual string GetFileName(Article article, Formatter formatter)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"GetFileName() für Article '{article.OriginalTitle}' aufgerufen");

            return formatter.AsPagename($"{article.OriginalTitle} ({article.ReleaseDate[0..4]})");
        }

        /// <summary>
        /// Creates the file content of a given entry.
        /// </summary>
        /// <param name="entry">The entry that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted content of the entry.</returns>
        public virtual List<string> CreateFileContent(Entry entry, string targetLanguageCode, Formatter formatter)
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

            Logger.Trace($"CreateFileContent() für Movie '{((Article)entry).OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            content.AddRange(CreateFileHeader((Article)entry, targetLanguageCode, formatter));
            content.AddRange(CreateFileTitle((Article)entry, targetLanguageCode, formatter));

            content.AddRange(CreateInfoBoxBegin((Article)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxContent((Article)entry, targetLanguageCode, formatter));
            content.AddRange(CreateInfoBoxEnd((Article)entry, targetLanguageCode, formatter));

            content.AddRange(CreateChapterContent((Article)entry, targetLanguageCode, formatter));

            content.AddRange(CreateFileFooter((Article)entry, targetLanguageCode, formatter));

            Logger.Trace($"CreateFileContent() für Movie '{((Article)entry).OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the infobox content of a given entry.
        /// </summary>
        /// <param name="entry">The entry that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted content of the entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxContent(Entry entry, string targetLanguageCode, Formatter formatter)
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

            Logger.Trace($"CreateInfoBoxContent() für Article '{((Article)entry).OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            content.AddRange(this.CreateInfoBoxTitle((Article)entry, targetLanguageCode, formatter));
            content.AddRange(this.CreateInfoboxType((Article)entry, targetLanguageCode, formatter));

            Logger.Trace($"CreateInfoBoxContent() für Article '{((Article)entry).OriginalTitle}' beendet");

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
        protected abstract List<string> CreateChapterContent(Entry entry, string targetLanguageCode, Formatter formatter);

        /// <summary>
        /// Creates the formatted header content of a given article.
        /// </summary>
        /// <param name="article">The article that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted haeder content of the article.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateFileHeader(Article article, string targetLanguageCode, Formatter formatter)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateFileHaeder() für Article '{article.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            content.Add(formatter.DisableCache());
            content.Add(formatter.DisableTOC());

            content.Add(formatter.BeginComment());
            content.Add($"   {article.OriginalTitle}");
            content.Add($"");
            content.Add($"   @author  WikiPageCreator");
            content.Add($"   @date    {DateTime.Now:yyyy-MM-dd}");
            content.Add($"   @version {article.Status.EnglishTitle}: {article.LastUpdated}");
            content.Add(formatter.EndComment());
            content.Add("");
            content.Add("");

            Logger.Trace($"CreateFileHaeder() für Article '{article.OriginalTitle}' gestartet");

            return content;
        }

        /// <summary>
        /// Creates the formatted footer content of a given article.
        /// </summary>
        /// <param name="article">The article that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted footer content of the article.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateFileFooter(Article article, string targetLanguageCode, Formatter formatter)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateFileFooter() für Article '{article.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            // nothing to do at the moment

            Logger.Trace($"CreateFileFooter() für Article '{article.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox begin content of a given article.
        /// </summary>
        /// <param name="article">The article that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox begin content of the article.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxBegin(Article article, string targetLanguageCode, Formatter formatter)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxBegin() für Article '{article.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            content.Add(formatter.BeginBox(475, Alignment.Right));

            int[] width = { 30, 70 };
            content.Add(formatter.DefineTable(445, width));

            Logger.Trace($"CreateInfoBoxBegin() für Article '{article.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox end content of a given article
        /// </summary>
        /// <param name="article">The article that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox end content of the article.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxEnd(Article article, string targetLanguageCode, Formatter formatter)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxEnd() für Article '{article.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            content.Add(formatter.EndBox());
            content.Add("");
            content.Add("");

            Logger.Trace($"CreateInfoBoxEnd() für Article '{article.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates a formatted chapter heading with the given title.
        /// </summary>
        /// <param name="title">The title that is to be used as heading.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The fomatted chapter heading.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateNewChapter(Dictionary<string, string> title, string targetLanguageCode, Formatter formatter)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }
            if (title.Count != 2)
            {
                throw new ArgumentOutOfRangeException(nameof(title));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateNewChapter() gestartet");

            List<string> content = new List<string>();

            if (targetLanguageCode.Equals("en"))
            {
                Logger.Trace($"Chapter: {title["en"]}");
                content.Add(formatter.AsHeading2(title["en"]));
            }
            else // incl. case "de"
            {
                Logger.Trace($"Chapter: {title["de"]}");
                content.Add(formatter.AsHeading2(title["de"]));
            }

            Logger.Trace($"CreateNewChapter() beendet");

            return content;
        }

        /// <summary>
        /// Creates a formatted section heading with the given title.
        /// </summary>
        /// <param name="title">The title that is to be used as heading.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The fomatted chapter heading.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateNewSection(Dictionary<string, string> title, string targetLanguageCode, Formatter formatter)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }
            if (title.Count != 2)
            {
                throw new ArgumentOutOfRangeException(nameof(title));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateNewSection() gestartet");

            List<string> content = new List<string>();

            if (targetLanguageCode.Equals("en"))
            {
                Logger.Trace($"Section: {title["en"]}");
                content.Add(formatter.AsHeading3(title["en"]));
            }
            else // incl. case "de"
            {
                Logger.Trace($"Section: {title["de"]}");
                content.Add(formatter.AsHeading3(title["de"]));
            }

            Logger.Trace($"CreateNewSection() beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted file title content of a given article.
        /// </summary>
        /// <param name="article">The article that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted file title content of the article.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateFileTitle(Article article, string targetLanguageCode, Formatter formatter)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateFileTitle() für Article '{article.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            if (targetLanguageCode.Equals("en") && !String.IsNullOrEmpty(article.EnglishTitle))
            {
                Logger.Trace($"Title: '{article.EnglishTitle}' (englisch)");
                content.Add(formatter.AsHeading1(article.EnglishTitle));
            }
            else if (targetLanguageCode.Equals("de") && !String.IsNullOrEmpty(article.GermanTitle))
            {
                Logger.Trace($"Title: '{article.GermanTitle}' (deutsch)");
                content.Add(formatter.AsHeading1(article.GermanTitle));
            }
            else
            {
                Logger.Trace($"Title: '{article.OriginalTitle}' (original)");
                content.Add(formatter.AsHeading1(article.OriginalTitle));
            }
            content.Add("");
            content.Add("");

            Logger.Trace($"CreateFileTitle() für Article '{article.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox title content of a given article.
        /// </summary>
        /// <param name="article">The article that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox title content of the article.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxTitle(Article article, string targetLanguageCode, Formatter formatter)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxTitle() für Article '{article.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];

            if (targetLanguageCode.Equals("en"))
            {
                Logger.Trace($"Title: '{article.OriginalTitle}' (englisch)");
                data[0] = "Original Title";
                data[1] = article.OriginalTitle;
            }
            else // incl. case "de"
            {
                Logger.Trace($"Title: '{article.OriginalTitle}' (deutsch, ...)");
                data[0] = "Originaltitel";
                data[1] = article.OriginalTitle;
            }
            content.Add(formatter.AsTableRow(data));

            Logger.Trace($"CreateInfoBoxTitle() für Article '{article.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox release date content of a given article.
        /// </summary>
        /// <param name="article">The article that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox release date content of the article.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxReleaseDate(Article article, string targetLanguageCode, Formatter formatter)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxReleaseDate() für Article '{article.OriginalTitle}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];
            string[] path = { targetLanguageCode, "date" };

            if (!String.IsNullOrEmpty(article.ReleaseDate))
            {
                if (targetLanguageCode.Equals("en"))
                {
                    Logger.Trace($"Release Date: '{article.ReleaseDate}' (englisch)");
                    data[0] = "Original Release Date";
                    data[1] = formatter.AsInternalLink(path, article.ReleaseDate, article.ReleaseDate);
                }
                else // incl. case "de"
                {
                    Logger.Trace($"Release Date: '{article.ReleaseDate}' (deutsch, ...)");
                    data[0] = "Erstausstrahlung";
                    data[1] = formatter.AsInternalLink(path, article.ReleaseDate, article.ReleaseDate);
                }
                content.Add(formatter.AsTableRow(data));
            }

            Logger.Trace($"CreateInfoBoxReleaseDate() für Article '{article.OriginalTitle}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox type content of a given article.
        /// </summary>
        /// <param name="article">The article that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox type content of the article.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoboxType(Article article, string targetLanguageCode, Formatter formatter)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoboxType() für Article '{article.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            if (article.Type != null)
            {
                content.AddRange((new TypeContentCreator()).CreateInfoBoxContent(article.Type, targetLanguageCode, formatter));
            }

            Logger.Trace($"CreateInfoboxType() für Article '{article.OriginalTitle}' gestartet");

            return content;
        }

        /// <summary>
        /// Creates the formatted connection chapter content of a given article.
        /// </summary>
        /// <param name="article">The article that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted conncetion chapter content of the article.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateChapterConnection(Article article, string targetLanguageCode, Formatter formatter)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateChapterConnection() für Article '{article.OriginalTitle}' gestartet");

            List<string> content = new List<string>();

            //TODO: implement following class/method
            //content.AddRange((new ConnectionContentCreator).CreateChapterContent(article.Connection, targetLanguageCode, formatter));

            Logger.Trace($"CreateChapterConnection() für Article '{article.OriginalTitle}' beendet");

            return content;
        }
    }
}
