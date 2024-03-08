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

namespace WikiPageCreator.Export.Format
{
    /// <summary>
    /// Provides a formatter.
    /// </summary>
    public abstract class Formatter
    {
        // --- Properties ---

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a formatter.
        /// </summary>
        protected Formatter()
        {
            Logger.Trace($"Formatter() created");
        }

        // --- Methods ---
        /// <summary>
        /// Formats the given pagename as a filename.
        /// </summary>
        /// <param name="pagename">The pagename to be formatted.</param>
        /// <returns>The formatted filename.</returns>
        public abstract string AsFilename(string pagename);

        /// <summary>
        /// Formats the given text as bold text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <returns>The text formatted as bold.</returns>
        public abstract string AsBold(string text);

        /// <summary>
        /// Formats the given text as italic text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <returns>The text formatted as italic.</returns>
        public abstract string AsItalic(string text);

        /// <summary>
        /// Formats the given text as underlinded text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <returns>The text formatted as underlined.</returns>
        public abstract string AsUnderlined(string text);

        /// <summary>
        /// Formats the given text as subscript text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <returns>The text formatted as subscript.</returns>
        public abstract string AsSubscript(string text);

        /// <summary>
        /// Formats the given text as superscript text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <returns>The text formatted as superscript.</returns>
        public abstract string AsSuperscript(string text);

        /// <summary>
        /// Formats the given text as deleted text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <returns>The text formatted as deleted.</returns>
        public abstract string AsDeleted(string text);

        /// <summary>
        /// Formats the given parameters as an internal link.
        /// </summary>
        /// <param name="path">The path for the link.</param>
        /// <param name="pagename">The pagename for the link.</param>
        /// <param name="section">The section of the page for the link.</param>
        /// <param name="text">The text to be displayed  for the link.</param>
        /// <returns>The parameters formatted as an internal link.</returns>
        public abstract string AsInternalLink(string[] path, string pagename, string section, string text);

        /// <summary>
        /// Formats the given parameters as an internal link.
        /// </summary>
        /// <param name="path">The path for the link.</param>
        /// <param name="pagename">The pagename for the link.</param>
        /// <param name="text">The text to be displayed for the link.</param>
        /// <returns>The parameters formatted as an internal link.</returns>
        public abstract string AsInternalLink(string[] path, string pagename, string text);

        /// <summary>
        /// Formats the given parameters as an internal link.
        /// </summary>
        /// <param name="path">The path for the link.</param>
        /// <param name="pagename">The pagename for the link.</param>
        /// <returns>The parameters formatted as an internal link.</returns>
        public abstract string AsInternalLink(string[] path, string pagename);

        /// <summary>
        /// Formats the given parameters as an internal link.
        /// </summary>
        /// <param name="pagename">The pagename for the link.</param>
        /// <param name="section">The section of the page for the link.</param>
        /// <param name="text">The text to be displayed for the link.</param>
        /// <returns>The parameters formatted as an internal link.</returns>
        public abstract string AsInternalLink(string pagename, string section, string text);

        /// <summary>
        /// Formats the given parameters as an internal link.
        /// </summary>
        /// <param name="pagename">The pagename for the link.</param>
        /// <param name="text">The text to be displayed for the link.</param>
        /// <returns>The parameters formatted as an internal link.</returns>
        public abstract string AsInternalLink(string pagename, string text);

        /// <summary>
        /// Formats the given parameters as an internal link.
        /// </summary>
        /// <param name="pagename">The pagename for the link.</param>
        /// <returns>The parameters formatted as an internal link.</returns>
        public abstract string AsInternalLink(string pagename);

        /// <summary>
        /// Formats the given parameters as an external link.
        /// </summary>
        /// <param name="link">The link for the link.</param>
        /// <param name="text">The text to be displayed for the link.</param>
        /// <returns>The parameters formatted as an external link.</returns>
        public abstract string AsExternalLink(string link, string text);

        /// <summary>
        /// Formats the given parameters as an external link.
        /// </summary>
        /// <param name="link">The link for the link.</param>
        /// <returns>The parameters formatted as an external link.</returns>
        public abstract string AsExternalLink(string link);

        /// <summary>
        /// Formats the given email adress as an email link.
        /// </summary>
        /// <param name="mail">the email adress for the link.</param>
        /// <returns>The email formatted as an email link.</returns>
        public abstract string AsEMail(string mail);

        /// <summary>
        /// Formats the given text as a level 1 heading.
        /// </summary>
        /// <param name="text">The text to be formatted</param>
        /// <returns>The text formatted as a level 1 heading.</returns>
        public abstract string AsHeading1(string text);

        /// <summary>
        /// Formats the given text as a level 2 heading.
        /// </summary>
        /// <param name="text">The text to be formatted</param>
        /// <returns>The text formatted as a level 2 heading.</returns>
        public abstract string AsHeading2(string text);

        /// <summary>
        /// Formats the given text as a level 3 heading.
        /// </summary>
        /// <param name="text">The text to be formatted</param>
        /// <returns>The text formatted as a level 3 heading.</returns>
        public abstract string AsHeading3(string text);

        /// <summary>
        /// Formats the given text as a level 4 heading.
        /// </summary>
        /// <param name="text">The text to be formatted</param>
        /// <returns>The text formatted as a level 4 heading.</returns>
        public abstract string AsHeading4(string text);

        /// <summary>
        /// Formats the given text as a level 5 heading.
        /// </summary>
        /// <param name="text">The text to be formatted</param>
        /// <returns>The text formatted as a level 5 heading.</returns>
        public abstract string AsHeading5(string text);

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="path">The path of the image.</param>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="width">The width for the image.</param>
        /// <param name="height">The height for the image.</param>
        /// <param name="text">The text to be displayed for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        public abstract string AsImage(string[] path, string filename, int width, int height, string text);

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="path">The path of the image.</param>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="width">The width for the image.</param>
        /// <param name="height">The height for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        public abstract string AsImage(string[] path, string filename, int width, int height);

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="path">The path of the image.</param>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="width">The width for the image.</param>
        /// <param name="text">The text to be displayed for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        public abstract string AsImage(string[] path, string filename, int width, string text);

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="path">The path of the image.</param>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="width">The width for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        public abstract string AsImage(string[] path, string filename, int width);

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="path">The path of the image.</param>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="text">The text to be displayed for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        public abstract string AsImage(string[] path, string filename, string text);

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="path">The path of the image.</param>
        /// <param name="filename">The filename of the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        public abstract string AsImage(string[] path, string filename);

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="width">The width for the image.</param>
        /// <param name="height">The height for the image.</param>
        /// <param name="text">The text to be displayed for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        public abstract string AsImage(string filename, int width, int height, string text);

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="width">The width for the image.</param>
        /// <param name="height">The height for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        public abstract string AsImage(string filename, int width, int height);

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="width">The width for the image.</param>
        /// <param name="text">The text to be displayed for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        public abstract string AsImage(string filename, int width, string text);

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="width">The width for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        public abstract string AsImage(string filename, int width);

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="text">The text to be displayed for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        public abstract string AsImage(string filename, string text);

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="filename">The filename of the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        public abstract string AsImage(string filename);

        /// <summary>
        /// Formats the given imagelink as an imagebox.
        /// </summary>
        /// <param name="imagelink">The imagelink to be boxed.</param>
        /// <returns>The boxed imagelink.</returns>
        public abstract string AsImageBox(string imagelink);

        /// <summary>
        /// Aligns the given text as given.
        /// </summary>
        /// <param name="text">The text to be aligned.</param>
        /// <param name="align">The alignment to be used.</param>
        /// <returns>The text aligned as given.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null or '0'.</exception>
        public abstract string Align(string text, Alignment align);

        /// <summary>
        /// Inserts an indicator to force a new line.
        /// </summary>
        /// <returns>Indicator to force a new line.</returns>
        public abstract string ForceNewLine();

        /// <summary>
        /// Inserts an indicator for a list item for an unsorted list.
        /// </summary>
        /// <returns>Indicator for a list item for an unsorted list.</returns>
        public abstract string ListItemUnsorted();

        /// <summary>
        /// Inserts an indicator for a list item for a sorted list.
        /// </summary>
        /// <returns>Indicator for a list item for a sorted list.</returns>
        public abstract string ListItemSorted();

        /// <summary>
        /// Inserts an indicator for an indentation.
        /// </summary>
        /// <returns>Indicator for an indentation.</returns>
        public abstract string ListItemIndent();

        /// <summary>
        /// Formats the given parameters as an inserted page.
        /// </summary>
        /// <param name="path">The path of the page.</param>
        /// <param name="pagename">The pagename of the page.</param>
        /// <returns>The parameters formatted as an inserted page.</returns>
        public abstract string AsInsertPage(string[] path, string pagename);

        /// <summary>
        /// Formats the given parameters ans an inserted page.
        /// </summary>
        /// <param name="pagename">The pagename of the page.</param>
        /// <returns>The parameters formatted as an inserted page.</returns>
        public abstract string AsInsertPage(string pagename);

        /// <summary>
        /// Inserts an indicator to disable the TOC (table of contents).
        /// </summary>
        /// <returns>Indicator to disable the TOC.</returns>
        public abstract string DisableTOC();

        /// <summary>
        /// Inserts an indicator to disable the cache.
        /// </summary>
        /// <returns>Indicator to disable the cache.</returns>
        public abstract string DisableCache();

        /// <summary>
        /// Inserts an indicator to begin a (multiline) comment.
        /// </summary>
        /// <returns>Indicator to begin a comment.</returns>
        public abstract string BeginComment();

        /// <summary>
        /// Inserts an indicator to end a (multiline) comment.
        /// </summary>
        /// <returns>Indicator to end a comment.</returns>
        public abstract string EndComment();

        /// <summary>
        /// Inserts an indicator to define a table with the given size and column widths.
        /// </summary>
        /// <param name="size">The size of the table.</param>
        /// <param name="width">The width(s) of the columns.</param>
        /// <returns>Indicator to define the table.</returns>
        public abstract string DefineTable(int size, int[] width);

        /// <summary>
        /// Formats the given data as column titles.
        /// </summary>
        /// <param name="data">The data for the title row.</param>
        /// <returns>The data formatted as a title row.</returns>
        public abstract string AsTableTitle(string[] data);

        /// <summary>
        /// Inserts an indicator to span cells vertically.
        /// </summary>
        /// <returns>Indicator to span cells vertically.</returns>
        public abstract string CellSpanVertically();

        /// <summary>
        /// Formats the given data as a table row.
        /// </summary>
        /// <param name="data">The data for the table row.</param>
        /// <returns>The data formatted as a table row.</returns>
        public abstract string AsTableRow(string[] data);

        /// <summary>
        /// Inserts an indicator to begin a box with the given size and alignment.
        /// </summary>
        /// <param name="size">The width of the box.</param>
        /// <param name="align">The alignment of the box.</param>
        /// <returns>Indicator to begin a box.</returns>
        public abstract string BeginBox(int size, Alignment align);

        /// <summary>
        /// Inserts an indicator to end a box.
        /// </summary>
        /// <returns>Indicator to end a box.</returns>
        public abstract string EndBox();

        /// <summary>
        /// Inserts an indicator to begin a data entry.
        /// </summary>
        /// <param name="name">The name of the data entry.</param>
        /// <returns>Indicator to begin a data entry.</returns>
        public abstract string BeginDataEntry(string name);

        /// <summary>
        /// Inserts an indicator to end a data entry.
        /// </summary>
        /// <returns>Indicator to end a data entry.</returns>
        public abstract string EndDataEntry();

    }
}
