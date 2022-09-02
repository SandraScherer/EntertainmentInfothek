﻿// WikiPageCreator.exe: Creates pages for use with a wiki from the
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
    /// Provides a content creator for an entry.
    /// </summary>
    public abstract class EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The formatter to be used to format the information of the entry.
        /// </summary>
        public Formatter Formatter { get; protected set; }

        /// <summary>
        /// The entry to be used to create the content.
        /// </summary>
        public Entry Entry { get; protected set; }

        /// <summary>
        /// The target language (as a language code) to specify the language of the created content.
        /// </summary>
        public string TargetLanguageCode { get; protected set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes an EntryContentCreator with the given entry, formatter and target language code.
        /// </summary>
        /// <param name="entry">The entry to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected EntryContentCreator(Entry entry, Formatter formatter, string targetLanguageCode)
        {
            Logger.Trace($"EntryContentCreator()");

            if (entry == null)
            {
                Logger.Fatal($"Entry not specified");
                throw new ArgumentNullException(nameof(entry));
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

            Entry = entry;
            Formatter = formatter;
            TargetLanguageCode = targetLanguageCode;

            Logger.Trace($"EntryContentCreator(): EntryContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Returns the page name of the entrys page.
        /// </summary>
        /// <returns>The formatted page name for the entry.</returns>
        /// <exception cref="NotSupportedException">Thrown because the operation is not supported.</exception>
        public virtual string GetPageName()
        {
            Logger.Fatal($"Operation not supported");
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates the page content of the entry.
        /// </summary>
        /// <returns>The formatted page content of the entry.</returns>
        /// <exception cref="NotSupportedException">Thrown because the operation is not supported.</exception>
        public virtual List<string> CreatePageContent()
        {
            Logger.Fatal($"Operation not supported");
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates the page content of the entry.
        /// </summary>
        /// <returns>The formatted page content of the entry.</returns>
        protected virtual List<string> CreatePageContentInternal()
        {
            Logger.Trace($"CreatePageContentInternal()");
            Logger.Debug($"Entry is '{Entry.ID}'");

            List<string> content = new List<string>();

            content.AddRange(CreatePageHeader());
            content.AddRange(CreatePageTitle());

            content.AddRange(CreateInfoBoxBegin());
            content.AddRange(CreateInfoBoxContentInternal());
            content.AddRange(CreateInfoBoxEnd());

            content.AddRange(CreateChapterContentInternal());

            content.AddRange(CreatePageFooter());

            Logger.Trace($"CreatePageContentInternal(): page content for Entry '{Entry.ID}' created");

            return content;
        }

        /// <summary>
        /// Creates the formatted header content of a given entry.
        /// </summary>
        /// <returns>The formatted header content of the entry.</returns>
        /// <exception cref="NotSupportedException">Thrown because the operation is not supported.</exception>
        protected virtual List<string> CreatePageHeader()
        {
            Logger.Fatal($"Operation not supported");
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates the formatted file title content of a given entry.
        /// </summary>
        /// <returns>The formatted file title of the entry.</returns>
        /// <exception cref="NotSupportedException">Thrown because the operation is not supported.</exception>
        protected virtual List<string> CreatePageTitle()
        {
            Logger.Fatal($"Operation not supported");
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates the formatted infobox begin content of a given entry
        /// </summary>
        /// <returns>The formatted infobox begin content of the entry.</returns>
        protected virtual List<string> CreateInfoBoxBegin()
        {
            Logger.Trace($"CreateInfoBoxBegin()");
            Logger.Debug($"Entry is '{Entry.ID}'");

            List<string> content = new List<string>();

            content.Add(Formatter.BeginBox(475, Alignment.Right));

            int[] width = { 30, 70 };
            content.Add(Formatter.DefineTable(445, width));

            Logger.Trace($"CreateInfoBoxBegin(): infobox begin for Entry '{Entry.ID}' created");

            return content;
        }

        /// <summary>
        /// Creates the infobox content of a given entry.
        /// </summary>
        /// <returns>The formatted infobox content of the entry.</returns>
        /// <exception cref="NotSupportedException">Thrown because the operation is not supported.</exception>
        public virtual List<string> CreateInfoBoxContent()
        {
            Logger.Fatal($"Operation not supported");
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates the infobox content of a given entry.
        /// </summary>
        /// <returns>The formatted infobox content of the entry.</returns>
        /// <exception cref="NotSupportedException">Thrown because the operation is not supported.</exception>
        protected virtual List<string> CreateInfoBoxContentInternal()
        {
            Logger.Fatal($"Operation not supported");
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates the formatted infobox end content of a given entry
        /// </summary>
        /// <returns>The formatted infobox end content of the article.</returns>
        protected virtual List<string> CreateInfoBoxEnd()
        {
            Logger.Trace($"CreateInfoBoxEnd()");
            Logger.Debug($"Entry is '{Entry.ID}'");

            List<string> content = new List<string>();

            content.Add(Formatter.EndBox());
            content.Add("");
            content.Add("");

            Logger.Trace($"CreateInfoBoxEnd(): infobox end for Entry '{Entry.ID}' created");

            return content;
        }

        /// <summary>
        /// Creates a formatted chapter heading with the given title.
        /// </summary>
        /// <param name="title">The title that is to be used as heading.</param>
        /// <returns>The fomatted chapter heading.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateNewChapter(Dictionary<string, string> title)
        {
            Logger.Trace($"CreateNewChapter()");
            Logger.Debug($"Entry is '{Entry.ID}'");

            if (title == null)
            {
                Logger.Fatal($"Title not specified");
                throw new ArgumentNullException(nameof(title));
            }

            List<string> content = new List<string>();

            if (TargetLanguageCode.Equals("en"))
            {
                Logger.Debug($"Chapter: '{title["en"]}' (english)");
                content.Add(Formatter.AsHeading2(title["en"]));
            }
            else // incl. case "de"
            {
                Logger.Debug($"Chapter: '{title["de"]}' (german, ...)");
                content.Add(Formatter.AsHeading2(title["de"]));
            }
            content.Add($"");
            content.Add($"");

            Logger.Trace($"CreateNewChapter(): new chapter for Entry '{Entry.ID}' created");

            return content;
        }

        /// <summary>
        /// Creates the chapter content of a given entry.
        /// </summary>
        /// <returns>The formatted content of the entry.</returns>
        /// <exception cref="NotSupportedException">Thrown because the operation is not supported.</exception>
        public virtual List<string> CreateChapterContent()
        {
            Logger.Fatal($"Operation not supported");
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates the chapter content of a given entry.
        /// </summary>
        /// <returns>The formatted content of the entry.</returns>
        /// <exception cref="NotSupportedException">Thrown because the operation is not supported.</exception>
        protected virtual List<string> CreateChapterContentInternal()
        {
            Logger.Fatal($"Operation not supported");
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates a formatted section heading with the given title.
        /// </summary>
        /// <param name="title">The title that is to be used as heading.</param>
        /// <returns>The fomatted chapter heading.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateNewSection(Dictionary<string, string> title)
        {
            Logger.Trace($"CreateNewSection()");
            Logger.Debug($"Entry is '{Entry.ID}'");

            if (title == null)
            {
                Logger.Fatal($"Title not specified");
                throw new ArgumentNullException(nameof(title));
            }

            List<string> content = new List<string>();

            if (TargetLanguageCode.Equals("en"))
            {
                Logger.Debug($"Section: '{title["en"]}' (english)");
                content.Add(Formatter.AsHeading3(title["en"]));
            }
            else // incl. case "de"
            {
                Logger.Debug($"Section: '{title["de"]}' (german, ...)");
                content.Add(Formatter.AsHeading3(title["de"]));
            }

            Logger.Trace($"CreateNewSection(): new section for Entry '{Entry.ID}' created");

            return content;
        }

        /// <summary>
        /// Creates the section content of a given entry.
        /// </summary>
        /// <returns>The formatted section content of the entry.</returns>
        /// <exception cref="NotSupportedException">Thrown because the operation is not supported.</exception>
        public virtual List<string> CreateSectionContent()
        {
            Logger.Fatal($"Operation not supported");
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates the section content of a given entry.
        /// </summary>
        /// <returns>The formatted section content of the entry.</returns>
        /// <exception cref="NotSupportedException">Thrown because the operation is not supported.</exception>
        protected virtual List<string> CreateSectionContentInternal()
        {
            Logger.Fatal($"Operation not supported");
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates the formatted footer content of a given entry.
        /// </summary>
        /// <returns>The formatted footer content of the entry.</returns>
        protected virtual List<string> CreatePageFooter()
        {
            Logger.Trace($"CreatePageFooter()");
            Logger.Debug($"Entry is '{Entry.ID}'");

            List<string> content = new List<string>();

            content.Add($"");
            content.Add($"");

            Logger.Trace($"CreatePageFooter(): page footer for Entry '{Entry.ID}' created");

            return content;
        }
    }
}
