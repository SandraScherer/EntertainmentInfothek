// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
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


using System;
using System.Collections.Generic;
using System.Text;

namespace WikiPageCreator.Export.Format
{
    /// <summary>
    /// Provides a formatter for a DokuWiki.
    /// </summary>
    public class DokuWikiFormatter : Formatter
    {
        // --- Properties ---

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a DokuWiki formatter.
        /// </summary>
        public DokuWikiFormatter()
        {
            Logger.Trace($"DokuWikiFormatter() angelegt");
        }

        // --- Methods ---

        /// <summary>
        /// Formats the given filename as a page name.
        /// </summary>
        /// <param name="filename">The filename to be formatted.</param>
        /// <returns>The formatted pagename.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given filename is null.</exception>
        public override string AsPagename(string filename)
        {
            if (String.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException(nameof(filename));
            }

            filename = filename.ToLower();

            filename = filename.Replace(' ', '_');
            filename = filename.Replace('+', '_');
            filename = filename.Replace('/', '_');
            filename = filename.Replace('%', '_');
            filename = filename.Replace('\'', '_');
            filename = filename.Replace('!', '_');
            filename = filename.Replace('&', '_');
            filename = filename.Replace('?', '_');
            filename = filename.Replace('=', '_');
            filename = filename.Replace('*', '_');
            filename = filename.Replace('#', '_');
            filename = filename.Replace('<', '_');
            filename = filename.Replace('>', '_');
            filename = filename.Replace('ä', 'a');
            filename = filename.Replace('ö', 'o');
            filename = filename.Replace('ü', 'u');
            filename = filename.Replace('ß', 's');

            filename = filename.Replace(",", "");
            filename = filename.Replace(":", "");
            filename = filename.Replace("(", "");
            filename = filename.Replace(")", "");

            filename = String.Concat(filename, ".txt");

            return filename;
        }

        /// <summary>
        /// Formats the given text as bold text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <returns>The text formatted as bold.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsBold(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            return $"**{text}**";
        }

        /// <summary>
        /// Formats the given text as italic text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <returns>The text formatted as italic.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsItalic(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            return $"//{text}//";
        }

        /// <summary>
        /// Formats the given text as underlinded text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <returns>The text formatted as underlined.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsUnderlined(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            return $"__{text}__";
        }

        /// <summary>
        /// Formats the given text as subscript text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <returns>The text formatted as subscript.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsSubscript(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            return $"<sub>{text}</sub>";
        }

        /// <summary>
        /// Formats the given text as superscript text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <returns>The text formatted as superscript.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsSuperscript(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            return $"<sup>{text}</sup>";
        }

        /// <summary>
        /// Formats the given text as deleted text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <returns>The text formatted as deleted.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsDeleted(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            return $"<del>{text}</del>";
        }

        // ---------------

        /// <summary>
        /// Formats the given parameters as an internal link.
        /// </summary>
        /// <param name="path">The path for the link.</param>
        /// <param name="pagename">The pagename for the link.</param>
        /// <param name="section">The section of the page for the link.</param>
        /// <param name="text">The text to be displayed  for the link.</param>
        /// <returns>The parameters formatted as an internal link.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public override string AsInternalLink(string[] path, string pagename, string section, string text)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (String.IsNullOrEmpty(pagename))
            {
                throw new ArgumentNullException(nameof(pagename));
            }

            if (String.IsNullOrEmpty(section))
            {
                throw new ArgumentNullException(nameof(section));
            }

            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            string formatted = "";
            foreach (string item in path)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    formatted = String.Concat(formatted, item, ":");
                }
            }

            return AsInternalLink(formatted + pagename, section, text);
        }

        /// <summary>
        /// Formats the given parameters as an internal link.
        /// </summary>
        /// <param name="path">The path for the link.</param>
        /// <param name="pagename">The pagename for the link.</param>
        /// <param name="text">The text to be displayed for the link.</param>
        /// <returns>The parameters formatted as an internal link.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public override string AsInternalLink(string[] path, string pagename, string text)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (String.IsNullOrEmpty(pagename))
            {
                throw new ArgumentNullException(nameof(pagename));
            }

            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            string formatted = "";
            foreach (string item in path)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    formatted = String.Concat(formatted, item, ":");
                }
            }

            return AsInternalLink(formatted + pagename, text);
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
            if (String.IsNullOrEmpty(pagename))
            {
                throw new ArgumentNullException(nameof(pagename));
            }

            if (String.IsNullOrEmpty(section))
            {
                throw new ArgumentNullException(nameof(section));
            }

            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            return $"[[{pagename}#{section}|{text}]]";
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
            if (String.IsNullOrEmpty(pagename))
            {
                throw new ArgumentNullException(nameof(pagename));
            }

            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            return $"[[{pagename}|{text}]]";
        }

        /// <summary>
        /// Formats the given parameters as an internal link.
        /// </summary>
        /// <param name="pagename">The pagename for the link.</param>
        /// <returns>The parameters formatted as an internal link.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public override string AsInternalLink(string pagename)
        {
            if (String.IsNullOrEmpty(pagename))
            {
                throw new ArgumentNullException(nameof(pagename));
            }

            return $"[[{pagename}]]";
        }

        /// <summary>
        /// Formats the given parameters as an external link.
        /// </summary>
        /// <param name="link">The link for the link.</param>
        /// <param name="text">The text to be displayed for the link.</param>
        /// <returns>The parameters formatted as an external link.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public override string AsExternalLink(string link, string text)
        {
            if (String.IsNullOrEmpty(link))
            {
                throw new ArgumentNullException(nameof(link));
            }

            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            return AsInternalLink(link, text);
        }

        /// <summary>
        /// Formats the given parameters as an external link.
        /// </summary>
        /// <param name="link">The link for the link.</param>
        /// <returns>The parameters formatted as an external link.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public override string AsExternalLink(string link)
        {
            if (String.IsNullOrEmpty(link))
            {
                throw new ArgumentNullException(nameof(link));
            }

            return AsInternalLink(link);
        }

        /// <summary>
        /// Formats the given email adress as an email link.
        /// </summary>
        /// <param name="mail">the email adress for the link.</param>
        /// <returns>The email formatted as an email link.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given email address is null.</exception>
        public override string AsEMail(string mail)
        {
            if (String.IsNullOrEmpty(mail))
            {
                throw new ArgumentNullException(nameof(mail));
            }

            return $"<{mail}>";
        }

        // ---------------

        /// <summary>
        /// Formats the given text as a level 1 heading.
        /// </summary>
        /// <param name="text">The text to be formatted</param>
        /// <returns>The text formatted as a level 1 heading.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsHeading1(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            return $"====== {text} ======";
        }

        /// <summary>
        /// Formats the given text as a level 2 heading.
        /// </summary>
        /// <param name="text">The text to be formatted</param>
        /// <returns>The text formatted as a level 2 heading.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsHeading2(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            return $"===== {text} =====";
        }

        /// <summary>
        /// Formats the given text as a level 3 heading.
        /// </summary>
        /// <param name="text">The text to be formatted</param>
        /// <returns>The text formatted as a level 3 heading.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsHeading3(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            return $"==== {text} ====";
        }

        /// <summary>
        /// Formats the given text as a level 4 heading.
        /// </summary>
        /// <param name="text">The text to be formatted</param>
        /// <returns>The text formatted as a level 4 heading.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsHeading4(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            return $"=== {text} ===";
        }

        /// <summary>
        /// Formats the given text as a level 5 heading.
        /// </summary>
        /// <param name="text">The text to be formatted</param>
        /// <returns>The text formatted as a level 5 heading.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsHeading5(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            return $"== {text} ==";
        }

        // ---------------

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="path">The path of the image.</param>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="width">The width for the image.</param>
        /// <param name="height">The height for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null or '0'.</exception>
        public override string AsImage(string[] path, string filename, int width, int height)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (String.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException(nameof(filename));
            }

            if (width == 0)
            {
                throw new ArgumentNullException(nameof(width));
            }

            if (height == 0)
            {
                throw new ArgumentNullException(nameof(height));
            }

            string formatted = "";
            foreach (string item in path)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    formatted = String.Concat(formatted, item, ":");
                }
            }

            return AsImage(formatted + filename, width, height);
        }

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="path">The path of the image.</param>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="width">The width for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null or '0'.</exception>
        public override string AsImage(string[] path, string filename, int width)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (String.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException(nameof(filename));
            }

            if (width == 0)
            {
                throw new ArgumentNullException(nameof(width));
            }

            string formatted = "";
            foreach (string item in path)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    formatted = String.Concat(formatted, item, ":");
                }
            }

            return AsImage(formatted + filename, width);
        }

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="path">The path of the image.</param>
        /// <param name="filename">The filename of the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null or '0'.</exception>
        public override string AsImage(string[] path, string filename)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (String.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException(nameof(filename));
            }

            string formatted = "";
            foreach (string item in path)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    formatted = String.Concat(formatted, item, ":");
                }
            }

            return AsImage(formatted + filename);
        }

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="width">The width for the image.</param>
        /// <param name="height">The height for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null or '0'.</exception>
        public override string AsImage(string filename, int width, int height)
        {
            if (String.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException(nameof(filename));
            }

            if (width == 0)
            {
                throw new ArgumentNullException(nameof(width));
            }

            if (height == 0)
            {
                throw new ArgumentNullException(nameof(height));
            }

            return $"{{{{{filename}?{width}x{height}}}}}";
        }

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="width">The width for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null or '0'.</exception>
        public override string AsImage(string filename, int width)
        {
            if (String.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException(nameof(filename));
            }

            if (width == 0)
            {
                throw new ArgumentNullException(nameof(width));
            }

            return $"{{{{{filename}?{width}}}}}";
        }

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="filename">The filename of the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null or '0'.</exception>
        public override string AsImage(string filename)
        {
            if (String.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException(nameof(filename));
            }

            return $"{{{{{filename}}}}}";
        }

        /// <summary>
        /// Aligns the given imagelink as given.
        /// </summary>
        /// <param name="imagelink">The imagelink to be aligned.</param>
        /// <param name="align">The alignment to be used.</param>
        /// <returns>The Imagelink aligned as given.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null or '0'.</exception>
        public override string AlignImage(string imagelink, Alignment align)
        {
            if (String.IsNullOrEmpty(imagelink))
            {
                throw new ArgumentNullException(nameof(imagelink));
            }

            switch (align)
            {
                case Alignment.Left:
                    return imagelink.Insert(imagelink.Length - 2, " ");
                case Alignment.Centered:
                    return imagelink.Insert(imagelink.Length - 2, " ").Insert(2, " ");
                case Alignment.Right:
                    return imagelink.Insert(2, " ");
                default:
                    return imagelink;
            }
        }

        // ---------------

        /// <summary>
        /// Inserts an indicator to force a new line.
        /// </summary>
        /// <returns>Indicator to force a new line.</returns>
        public override string ForceNewLine()
        {
            return $"\\";
        }

        /// <summary>
        /// Inserts an indicator for a list item for an unsorted list.
        /// </summary>
        /// <returns>Indicator for a list item for an unsorted list.</returns>
        public override string ListItemUnsorted()
        {
            return $"* ";
        }

        /// <summary>
        /// Inserts an indicator for a list item for a sorted list.
        /// </summary>
        /// <returns>Indicator for a list item for a sorted list.</returns>
        public override string ListItemSorted()
        {
            return $"- ";
        }

        /// <summary>
        /// Inserts an indicator for an indentation.
        /// </summary>
        /// <returns>Indicator for an indentation.</returns>
        public override string ListItemIndent()
        {
            return $"  ";
        }

        // ---------------

        /// <summary>
        /// Formats the given parameters as an inserted page.
        /// </summary>
        /// <param name="path">The path of the page.</param>
        /// <param name="pagename">The pagename of the page.</param>
        /// <returns>The parameters formatted as an inserted page.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public override string AsInsertPage(string[] path, string pagename)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (String.IsNullOrEmpty(pagename))
            {
                throw new ArgumentNullException(nameof(pagename));
            }

            string formatted = "";
            foreach (string item in path)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    formatted = String.Concat(formatted, item, ":");
                }
            }

            return AsInsertPage(formatted + pagename);
        }

        /// <summary>
        /// Formats the given parameters ans an inserted page.
        /// </summary>
        /// <param name="pagename">The pagename of the page.</param>
        /// <returns>The parameters formatted as an inserted page.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public override string AsInsertPage(string pagename)
        {
            if (String.IsNullOrEmpty(pagename))
            {
                throw new ArgumentNullException(nameof(pagename));
            }

            return $"{{{{page>{pagename}}}}}";
        }

        // ---------------

        /// <summary>
        /// Inserts an indicator to disable the TOC (table of contents).
        /// </summary>
        /// <returns>Indicator to disable the TOC.</returns>
        public override string DisableTOC()
        {
            return $"~~NOTOC~~";
        }

        /// <summary>
        /// Inserts an indicator to disable the cache.
        /// </summary>
        /// <returns>Indicator to disable the cache.</returns>
        public override string DisableCache()
        {
            return $"~~NOCACHE~~";
        }

        // ---------------

        /// <summary>
        /// Inserts an indicator to begin a (multiline) comment.
        /// </summary>
        /// <returns>Indicator to begin a comment.</returns>
        public override string BeginComment()
        {
            return $"/* ";
        }

        /// <summary>
        /// Inserts an indicator to end a (multiline) comment.
        /// </summary>
        /// <returns>Indicator to end a comment.</returns>
        public override string EndComment()
        {
            return $" */";
        }

        // ---------------

        /// <summary>
        /// Inserts an indicator to define a table with the given size and column widths.
        /// </summary>
        /// <param name="size">The size of the table</param>
        /// <param name="width">The width(s) of the columns.</param>
        /// <returns>Indicator to define the table.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is '0'.</exception>
        public override string DefineTable(int size, int[] width)
        {
            if (size == 0)
            {
                throw new ArgumentNullException(nameof(size));
            }

            if (width == null)
            {
                throw new ArgumentNullException(nameof(width));
            }

            foreach (int item in width)
            {
                if (item == 0)
                {
                    throw new ArgumentNullException(nameof(width));
                }
            }

            string formatted = $"|<   {size}px   ";
            foreach (int item in width)
            {
                formatted = String.Concat(formatted, item, "%   ");
            }
            formatted = $"{formatted}>|";

            return formatted;
        }

        /// <summary>
        /// Inserts an indicator to span cells vertically.
        /// </summary>
        /// <returns>Indicator to span cells vertically.</returns>
        public override string CellSpanVertically()
        {
            return $":::";
        }

        /// <summary>
        /// Formats the given data as a table row.
        /// </summary>
        /// <param name="data">The data for the table row.</param>
        /// <returns>The data formatted as a table row.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given data is null.</exception>
        public override string AsTableRow(string[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            string formatted = "| ";
            foreach (string item in data)
            {
                if (String.IsNullOrEmpty(item))
                    formatted = String.Concat(formatted[0..^1], "| ");
                else
                    formatted = String.Concat(formatted, item, " | ");
            }
            formatted = formatted[0..^1];

            return formatted;
        }

        // ---------------

        /// <summary>
        /// Inserts an indicator to begin a box with the given size and alignment.
        /// </summary>
        /// <param name="size">The width of the box.</param>
        /// <param name="align">The alignment of the box.</param>
        /// <returns>Indicator to begin a box.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given size is '0'.</exception>
        public override string BeginBox(int size, Alignment align)
        {
            if (size == 0)
            {
                throw new ArgumentNullException(nameof(size));
            }

            return $"<WRAP box {size}px {align}>";
        }

        /// <summary>
        /// Inserts an indicator to end a box.
        /// </summary>
        /// <returns>Indicator to end a box.</returns>
        public override string EndBox()
        {
            return $"</WRAP>";
        }

        // ---------------

        /// <summary>
        /// Inserts an indicator to begin a data entry.
        /// </summary>
        /// <param name="name">The name of the data entry.</param>
        /// <returns>Indicator to begin a data entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given name is null.</exception>
        public override string BeginDataEntry(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            return $"---- dataentry " + name + " ----";
        }

        /// <summary>
        /// Inserts an indicator to end a data entry.
        /// </summary>
        /// <returns>Indicator to end a data entry.</returns>
        public override string EndDataEntry()
        {
            return $"----";
        }
    }
}
