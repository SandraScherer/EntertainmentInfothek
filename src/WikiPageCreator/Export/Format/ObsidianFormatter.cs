// WikiPageCreator.exe: Creates pages for use with a wiki from the
// EntertainmentInfothek.db using EntertainmentDB.dll
// Copyright (C) 2024 Sandra Scherer

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


using System;

namespace WikiPageCreator.Export.Format
{
    /// <summary>
    /// Provides a formatter for a Obsidian.
    /// </summary>
    public class ObsidianFormatter : MarkdownFormatter
    {
        // --- Properties ---

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a Obsidian formatter.
        /// </summary>
        public ObsidianFormatter()
        {
            Logger.Trace($"ObsidianFormatter() created");
        }

        // --- Methods ---

        /// <summary>
        /// Formats the given text as subscript text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <returns>The text formatted as subscript.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsSubscript(string text)
        {
            Logger.Trace($"AsSubscript()");

            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            text = $"<sub>{text}</sub>";

            Logger.Debug($"AsSubscript(): '{text}'");

            return text;
        }

        /// <summary>
        /// Formats the given text as superscript text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <returns>The text formatted as superscript.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsSuperscript(string text)
        {
            Logger.Trace($"AsSuperscript()");

            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            text = $"<sup>{text}</sup>";

            Logger.Debug($"AsSuperscript(): '{text}'");

            return text;
        }

        /// <summary>
        /// Formats the given text as deleted text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <returns>The text formatted as deleted.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsDeleted(string text)
        {
            Logger.Trace($"AsDeleted()");

            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            text = $"<del>{text}</del>";

            Logger.Debug($"AsDeleted(): '{text}'");

            return text;
        }

        // ---------------

        /// <summary>
        /// Formats the given parameters as an internal link.
        /// </summary>
        /// <param name="path">The path for the link.</param>
        /// <param name="pagename">The pagename for the link.</param>
        /// <returns>The parameters formatted as an internal link.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public override string AsInternalLink(string[] path, string pagename)
        {
            Logger.Trace($"AsInternalLink() [2 parameters]");

            if (path == null)
            {
                Logger.Fatal($"Path not specified");
                throw new ArgumentNullException(nameof(path));
            }
            if (String.IsNullOrEmpty(pagename))
            {
                Logger.Fatal($"Pagename not specified");
                throw new ArgumentNullException(nameof(pagename));
            }

            string formatted = "";
            foreach (string item in path)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    formatted = String.Concat(formatted, item, "/");
                }
            }

            pagename = $"[[{formatted}{pagename}|{pagename}]]";

            Logger.Debug($"AsInternalLink(): '{pagename}'");

            return pagename;
        }

        /// <summary>
        /// Formats the given parameters as an internal link.
        /// </summary>
        /// <param name="pagename">The pagename for the link.</param>
        /// <param name="section">The section of the page for the link.</param>
        /// <param name="text">The text to be displayed for the link.</param>
        /// <returns>The parameters formatted as an internal link.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public override string AsInternalLink(string pagename, string section, string text)
        {
            Logger.Trace($"AsInternalLink() [3 parameters]");

            if (String.IsNullOrEmpty(pagename))
            {
                Logger.Fatal($"Pagename not specified");
                throw new ArgumentNullException(nameof(pagename));
            }
            if (String.IsNullOrEmpty(section))
            {
                Logger.Fatal($"Section not specified");
                throw new ArgumentNullException(nameof(section));
            }
            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            pagename = $"[[{pagename}#{section}|{text}]]";

            Logger.Debug($"AsInternalLink(): '{pagename}'");

            return pagename;
        }

        /// <summary>
        /// Formats the given parameters as an internal link.
        /// </summary>
        /// <param name="pagename">The pagename for the link.</param>
        /// <param name="text">The text to be displayed for the link.</param>
        /// <returns>The parameters formatted as an internal link.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public override string AsInternalLink(string pagename, string text)
        {
            Logger.Trace($"AsInternalLink() [2 parameters]");

            if (String.IsNullOrEmpty(pagename))
            {
                Logger.Fatal($"Pagename not specified");
                throw new ArgumentNullException(nameof(pagename));
            }
            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            pagename = $"[[{pagename}|{text}]]";

            Logger.Debug($"AsInternalLink(): '{pagename}'");

            return pagename;
        }

        /// <summary>
        /// Formats the given parameters as an internal link.
        /// </summary>
        /// <param name="pagename">The pagename for the link.</param>
        /// <returns>The parameters formatted as an internal link.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public override string AsInternalLink(string pagename)
        {
            Logger.Trace($"AsInternalLink() [1 parameter]");

            if (String.IsNullOrEmpty(pagename))
            {
                Logger.Fatal($"Pagename not specified");
                throw new ArgumentNullException(nameof(pagename));
            }

            pagename = $"[[{pagename}]]";

            Logger.Debug($"AsInternalLink(): '{pagename}'");

            return pagename;
        }

        // ---------------

        /// <summary>
        /// Aligns the given text as given.
        /// </summary>
        /// <param name="text">The text to be aligned.</param>
        /// <param name="align">The alignment to be used.</param>
        /// <returns>The text aligned as given.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null or '0'.</exception>
        public override string Align(string text, Alignment align)
        {
            Logger.Trace($"Align()");

            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            Logger.Debug($"Operation not supported");
            Logger.Debug($"Align(): '{text}'");

            return text;
        }

        // ---------------

        /// <summary>
        /// Inserts an indicator to force a new line.
        /// </summary>
        /// <returns>Indicator to force a new line.</returns>
        public override string ForceNewLine()
        {
            Logger.Trace($"ForceNewLine()");

            return $"<br>";
        }

        /// <summary>
        /// Inserts an indicator for a list item for an unsorted list.
        /// </summary>
        /// <returns>Indicator for a list item for an unsorted list.</returns>
        public override string ListItemUnsorted()
        {
            Logger.Trace($"ListItemUnsorted()");

            return $"- ";
        }

        // ---------------

        /// <summary>
        /// Formats the given parameters ans an inserted page.
        /// </summary>
        /// <param name="pagename">The pagename of the page.</param>
        /// <returns>The parameters formatted as an inserted page.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public override string AsInsertPage(string pagename)
        {
            Logger.Trace($"AsInsertPage() [1 parameter]");

            if (String.IsNullOrEmpty(pagename))
            {
                Logger.Fatal($"Pagename not specified");
                throw new ArgumentNullException(nameof(pagename));
            }

            pagename = $"![[{pagename}]]";

            Logger.Debug($"AsInsertPage(): '{pagename}'");

            return pagename;
        }

        // ---------------

        /// <summary>
        /// Inserts an indicator to begin a (multiline) comment.
        /// </summary>
        /// <returns>Indicator to begin a comment.</returns>
        public override string BeginComment()
        {
            Logger.Trace($"BeginComment()");

            return $"%%";
        }

        /// <summary>
        /// Inserts an indicator to end a (multiline) comment.
        /// </summary>
        /// <returns>Indicator to end a comment.</returns>
        public override string EndComment()
        {
            Logger.Trace($"EndComment()");

            return $"%%";
        }
    }
}
