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
    public class ObsidianFormatter : Formatter
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
        /// Formats the given pagename as a filename.
        /// </summary>
        /// <param name="pagename">The pagename to be formatted.</param>
        /// <returns>The formatted filename.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given filename is null.</exception>
        public override string AsFilename(string pagename)
        {
            Logger.Trace($"AsFilename()");

            if (String.IsNullOrEmpty(pagename))
            {
                Logger.Fatal($"Pagename not specified");
                throw new ArgumentNullException(nameof(pagename));
            }

            pagename = pagename.ToLower();

            pagename = pagename.Replace(' ', '_');
            pagename = pagename.Replace('+', '_');
            pagename = pagename.Replace('/', '_');
            pagename = pagename.Replace('%', '_');
            pagename = pagename.Replace('\'', '_');
            pagename = pagename.Replace('!', '_');
            pagename = pagename.Replace('&', '_');
            pagename = pagename.Replace('?', '_');
            pagename = pagename.Replace('=', '_');
            pagename = pagename.Replace('*', '_');
            pagename = pagename.Replace('#', '_');
            pagename = pagename.Replace('<', '_');
            pagename = pagename.Replace('>', '_');
            pagename = pagename.Replace('ä', 'a');
            pagename = pagename.Replace('ö', 'o');
            pagename = pagename.Replace('ü', 'u');
            pagename = pagename.Replace('ß', 's');

            pagename = pagename.Replace(",", "");
            pagename = pagename.Replace(":", "");
            pagename = pagename.Replace("(", "");
            pagename = pagename.Replace(")", "");

            pagename = String.Concat(pagename, ".md");

            Logger.Debug($"AsFilename(): '{pagename}'");

            return pagename;
        }

        /// <summary>
        /// Formats the given text as bold text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <returns>The text formatted as bold.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsBold(string text)
        {
            Logger.Trace($"AsBold()");

            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            text = $"**{text}**";

            Logger.Debug($"AsBold(): '{text}'");

            return text;
        }

        /// <summary>
        /// Formats the given text as italic text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <returns>The text formatted as italic.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsItalic(string text)
        {
            Logger.Trace($"AsItalic()");

            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            text = $"_{text}_";

            Logger.Debug($"AsItalic(): '{text}'");

            return text;
        }

        /// <summary>
        /// Formats the given text as underlinded text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <returns>The text formatted as underlined.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsUnderlined(string text)
        {
            Logger.Trace($"AsUnderlined()");

            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            text = $"<u>{text}</u>";

            Logger.Debug($"AsUnderlined(): '{text}'");

            return text;
        }

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
        /// <param name="section">The section of the page for the link.</param>
        /// <param name="text">The text to be displayed  for the link.</param>
        /// <returns>The parameters formatted as an internal link.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public override string AsInternalLink(string[] path, string pagename, string section, string text)
        {
            Logger.Trace($"AsInternalLink() [4 parameters]");

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

            string formatted = "";
            foreach (string item in path)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    formatted = String.Concat(formatted, item, "/");
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
            Logger.Trace($"AsInternalLink() [3 parameters]");

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
            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                return AsInternalLink(path, pagename);
            }

            string formatted = "";
            foreach (string item in path)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    formatted = String.Concat(formatted, item, "/");
                }
            }

            return AsInternalLink(formatted + pagename, text);
        }

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

            return AsInternalLink(formatted + pagename);
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

            pagename =$"[{text}]({pagename}#{section})";

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

            pagename = $"[{text}]({pagename})";

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

            pagename = $"[{pagename}]({pagename})";

            Logger.Debug($"AsInternalLink(): '{pagename}'");

            return pagename;
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
            Logger.Trace($"AsExternalLink() [2 parameters]");

            if (String.IsNullOrEmpty(link))
            {
                Logger.Fatal($"Link not specified");
                throw new ArgumentNullException(nameof(link));
            }
            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
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
            Logger.Trace($"AsExternalLink() [1 parameter]");

            if (String.IsNullOrEmpty(link))
            {
                Logger.Fatal($"Link not specified");
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
            Logger.Trace($"AsEMail()");

            if (String.IsNullOrEmpty(mail))
            {
                Logger.Fatal($"Mail not specified");
                throw new ArgumentNullException(nameof(mail));
            }

            mail = $"<{mail}>";

            Logger.Debug($"AsEMail(): '{mail}'");

            return mail;
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
            Logger.Trace($"AsHeading1()");

            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            text = $"# {text}";

            Logger.Debug($"AsHeading1(): '{text}'");

            return text;
        }

        /// <summary>
        /// Formats the given text as a level 2 heading.
        /// </summary>
        /// <param name="text">The text to be formatted</param>
        /// <returns>The text formatted as a level 2 heading.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsHeading2(string text)
        {
            Logger.Trace($"AsHeading2()");

            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            text = $"## {text}";

            Logger.Debug($"AsHeading2(): '{text}'");

            return text;
        }

        /// <summary>
        /// Formats the given text as a level 3 heading.
        /// </summary>
        /// <param name="text">The text to be formatted</param>
        /// <returns>The text formatted as a level 3 heading.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsHeading3(string text)
        {
            Logger.Trace($"AsHeading3()");

            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            text = $"### {text}";

            Logger.Debug($"AsHeading3(): '{text}'");

            return text;
        }

        /// <summary>
        /// Formats the given text as a level 4 heading.
        /// </summary>
        /// <param name="text">The text to be formatted</param>
        /// <returns>The text formatted as a level 4 heading.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsHeading4(string text)
        {
            Logger.Trace($"AsHeading4()");

            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            text = $"#### {text}";

            Logger.Debug($"AsHeading4(): '{text}'");

            return text;
        }

        /// <summary>
        /// Formats the given text as a level 5 heading.
        /// </summary>
        /// <param name="text">The text to be formatted</param>
        /// <returns>The text formatted as a level 5 heading.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given text is null.</exception>
        public override string AsHeading5(string text)
        {
            Logger.Trace($"AsHeading5()");

            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            text = $"##### {text}";

            Logger.Debug($"AsHeading5(): '{text}'");

            return text;
        }

        // ---------------

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="path">The path of the image.</param>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="width">The width for the image.</param>
        /// <param name="height">The height for the image.</param>
        /// <param name="text">The text to be displayed for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null or '0'.</exception>
        public override string AsImage(string[] path, string filename, int width, int height, string text)
        {
            Logger.Trace($"AsImage() [5 parameters]");

            if (path == null)
            {
                Logger.Fatal($"Path not specified");
                throw new ArgumentNullException(nameof(path));
            }
            if (String.IsNullOrEmpty(filename))
            {
                Logger.Fatal($"Filename not specified");
                throw new ArgumentNullException(nameof(filename));
            }
            if (width == 0)
            {
                Logger.Fatal($"Width not specified");
                throw new ArgumentNullException(nameof(width));
            }
            if (height == 0)
            {
                Logger.Fatal($"Height not specified");
                throw new ArgumentNullException(nameof(height));
            }
            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            string formatted = "";
            foreach (string item in path)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    formatted = String.Concat(formatted, item, "/");
                }
            }

            return AsImage(formatted + filename, width, height, text);
        }

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
            Logger.Trace($"AsImage() [4 parameters]");

            if (path == null)
            {
                Logger.Fatal($"Path not specified");
                throw new ArgumentNullException(nameof(path));
            }
            if (String.IsNullOrEmpty(filename))
            {
                Logger.Fatal($"Filename not specified");
                throw new ArgumentNullException(nameof(filename));
            }
            if (width == 0)
            {
                Logger.Fatal($"Width not specified");
                throw new ArgumentNullException(nameof(width));
            }
            if (height == 0)
            {
                Logger.Fatal($"Height not specified");
                throw new ArgumentNullException(nameof(height));
            }

            string formatted = "";
            foreach (string item in path)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    formatted = String.Concat(formatted, item, "/");
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
        /// <param name="text">The text to be displayed for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null or '0'.</exception>
        public override string AsImage(string[] path, string filename, int width, string text)
        {
            Logger.Trace($"AsImage() [4 parameters]");

            if (path == null)
            {
                Logger.Fatal($"Path not specified");
                throw new ArgumentNullException(nameof(path));
            }
            if (String.IsNullOrEmpty(filename))
            {
                Logger.Fatal($"Filename not specified");
                throw new ArgumentNullException(nameof(filename));
            }
            if (width == 0)
            {
                Logger.Fatal($"Width not specified");
                throw new ArgumentNullException(nameof(width));
            }
            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            string formatted = "";
            foreach (string item in path)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    formatted = String.Concat(formatted, item, "/");
                }
            }

            return AsImage(formatted + filename, width, text);
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
            Logger.Trace($"AsImage() [3 parameters]");

            if (path == null)
            {
                Logger.Fatal($"Path not specified");
                throw new ArgumentNullException(nameof(path));
            }
            if (String.IsNullOrEmpty(filename))
            {
                Logger.Fatal($"Filename not specified");
                throw new ArgumentNullException(nameof(filename));
            }
            if (width == 0)
            {
                Logger.Fatal($"Width not specified");
                throw new ArgumentNullException(nameof(width));
            }

            string formatted = "";
            foreach (string item in path)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    formatted = String.Concat(formatted, item, "/");
                }
            }

            return AsImage(formatted + filename, width);
        }

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="path">The path of the image.</param>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="text">The text to be displayed for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null or '0'.</exception>
        public override string AsImage(string[] path, string filename, string text)
        {
            Logger.Trace($"AsImage() [3 parameters]");

            if (path == null)
            {
                Logger.Fatal($"Path not specified");
                throw new ArgumentNullException(nameof(path));
            }
            if (String.IsNullOrEmpty(filename))
            {
                Logger.Fatal($"Filename not specified");
                throw new ArgumentNullException(nameof(filename));
            }
            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            string formatted = "";
            foreach (string item in path)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    formatted = String.Concat(formatted, item, "/");
                }
            }

            return AsImage(formatted + filename, text);
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
            Logger.Trace($"AsImage() [2 parameters]");

            if (path == null)
            {
                Logger.Fatal($"Path not specified");
                throw new ArgumentNullException(nameof(path));
            }
            if (String.IsNullOrEmpty(filename))
            {
                Logger.Fatal($"Filename not specified");
                throw new ArgumentNullException(nameof(filename));
            }

            string formatted = "";
            foreach (string item in path)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    formatted = String.Concat(formatted, item, "/");
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
        /// <param name="text">The text to be displayed for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null or '0'.</exception>
        public override string AsImage(string filename, int width, int height, string text)
        {
            Logger.Trace($"AsImage() [4 parameters]");

            if (String.IsNullOrEmpty(filename))
            {
                Logger.Fatal($"Filename not specified");
                throw new ArgumentNullException(nameof(filename));
            }
            if (width == 0)
            {
                Logger.Fatal($"Width not specified");
                throw new ArgumentNullException(nameof(width));
            }
            if (height == 0)
            {
                Logger.Fatal($"Height not specified");
                throw new ArgumentNullException(nameof(height));
            }
            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            filename = $"![{text}|{width}x{height}]({filename})";

            Logger.Debug($"AsImage(): '{filename}'");

            return filename;
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
            Logger.Trace($"AsImage() [3 parameters]");

            if (String.IsNullOrEmpty(filename))
            {
                Logger.Fatal($"Filename not specified");
                throw new ArgumentNullException(nameof(filename));
            }
            if (width == 0)
            {
                Logger.Fatal($"Width not specified");
                throw new ArgumentNullException(nameof(width));
            }
            if (height == 0)
            {
                Logger.Fatal($"Height not specified");
                throw new ArgumentNullException(nameof(height));
            }

            filename = $"![{filename}|{width}x{height}]({filename})";

            Logger.Debug($"AsImage(): '{filename}'");

            return filename;
        }

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="width">The width for the image.</param>
        /// <param name="text">The text to be displayed for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null or '0'.</exception>
        public override string AsImage(string filename, int width, string text)
        {
            Logger.Trace($"AsImage() [3 parameters]");

            if (String.IsNullOrEmpty(filename))
            {
                Logger.Fatal($"Filename not specified");
                throw new ArgumentNullException(nameof(filename));
            }
            if (width == 0)
            {
                Logger.Fatal($"Width not specified");
                throw new ArgumentNullException(nameof(width));
            }
            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            filename = $"![{text}|{width}]({filename})";

            Logger.Debug($"AsImage(): '{filename}'");

            return filename;
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
            Logger.Trace($"AsImage() [2 parameters]");

            if (String.IsNullOrEmpty(filename))
            {
                Logger.Fatal($"Filename not specified");
                throw new ArgumentNullException(nameof(filename));
            }
            if (width == 0)
            {
                Logger.Fatal($"Width not specified");
                throw new ArgumentNullException(nameof(width));
            }

            filename = $"![{filename}|{width}]({filename})";

            Logger.Debug($"AsImage(): '{filename}'");

            return filename;
        }

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="filename">The filename of the image.</param>
        /// <param name="text">The text to be displayed for the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null or '0'.</exception>
        public override string AsImage(string filename, string text)
        {
            Logger.Trace($"AsImage() [2 parameters]");

            if (String.IsNullOrEmpty(filename))
            {
                Logger.Fatal($"Filename not specified");
                throw new ArgumentNullException(nameof(filename));
            }
            if (String.IsNullOrEmpty(text))
            {
                Logger.Fatal($"Text not specified");
                throw new ArgumentNullException(nameof(text));
            }

            filename = $"![{text}]({filename})";

            Logger.Debug($"AsImage(): '{filename}'");

            return filename;
        }

        /// <summary>
        /// Formats the given parameters as an image.
        /// </summary>
        /// <param name="filename">The filename of the image.</param>
        /// <returns>The parameters formatted as an image.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null or '0'.</exception>
        public override string AsImage(string filename)
        {
            Logger.Trace($"AsImage() [1 parameter]");

            if (String.IsNullOrEmpty(filename))
            {
                Logger.Fatal($"Filename not specified");
                throw new ArgumentNullException(nameof(filename));
            }

            filename = $"![{filename}]({filename})";

            Logger.Debug($"AsImage(): '{filename}'");

            return filename;
        }

        /// <summary>
        /// Formats the given imagelink as an imagebox.
        /// </summary>
        /// <param name="imagelink">The imagelink to be boxed.</param>
        /// <returns>The boxed imagelink.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null or '0'.</exception>
        public override string AsImageBox(string imagelink)
        {
            Logger.Trace($"AsImageBox()");

            if (String.IsNullOrEmpty(imagelink))
            {
                Logger.Fatal($"ImageLink not specified");
                throw new ArgumentNullException(nameof(imagelink));
            }

            Logger.Debug($"Boxing not supported");

            Logger.Debug($"AsImageBox(): '{imagelink}'");

            return imagelink;
        }

        /// <summary>
        /// Aligns the given imagelink as given.
        /// </summary>
        /// <param name="imagelink">The imagelink to be aligned.</param>
        /// <param name="align">The alignment to be used.</param>
        /// <returns>The Imagelink aligned as given.</returns>
        /// <exception cref="NotSupportedException">Thrown because the operation is not supported.</exception>
        public override string AlignImage(string imagelink, Alignment align)
        {
            Logger.Fatal($"Operation not supported");
            throw new NotSupportedException();
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

        /// <summary>
        /// Inserts an indicator for a list item for a sorted list.
        /// </summary>
        /// <returns>Indicator for a list item for a sorted list.</returns>
        public override string ListItemSorted()
        {
            Logger.Trace($"ListItemSorted()");

            return $"1. ";
        }

        /// <summary>
        /// Inserts an indicator for an indentation.
        /// </summary>
        /// <returns>Indicator for an indentation.</returns>
        public override string ListItemIndent()
        {
            Logger.Trace($"ListItemIndent()");

            return $"    ";
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
            Logger.Trace($"AsInsertPage() [2 parameters]");

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
        /// Inserts an indicator to disable the TOC (table of contents).
        /// </summary>
        /// <returns>Indicator to disable the TOC.</returns>
        public override string DisableTOC()
        {
            Logger.Trace($"DisableTOC()");
            Logger.Trace($"Operation not supported");

            return $"";
        }

        /// <summary>
        /// Inserts an indicator to disable the cache.
        /// </summary>
        /// <returns>Indicator to disable the cache.</returns>
        public override string DisableCache()
        {
            Logger.Trace($"DisableCache()");
            Logger.Trace($"Operation not supported");

            return $"";
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
            Logger.Trace($"DefineTable()");

            if (size == 0)
            {
                Logger.Fatal($"Size not specified");
                throw new ArgumentNullException(nameof(size));
            }
            if (width == null)
            {
                Logger.Fatal($"Width not specified");
                throw new ArgumentNullException(nameof(width));
            }
            foreach (int item in width)
            {
                if (item == 0)
                {
                    Logger.Fatal($"Width not specified");
                    throw new ArgumentNullException(nameof(width));
                }
            }

            Logger.Info($"DefineTable(): size and width are not supported and will be ignored");

            string formatted = $"|";
            foreach (int item in width)
            {
                formatted = String.Concat(formatted, " |");
            }

            Logger.Debug($"DefineTable(): '{formatted}");

            return formatted;
        }

        /// <summary>
        /// Inserts an indicator to span cells vertically.
        /// </summary>
        /// <returns>Indicator to span cells vertically.</returns>
        public override string CellSpanVertically()
        {
            Logger.Trace($"CellSpanVertically()");

            return $"    ";
        }

        /// <summary>
        /// Formats the given data as a table row.
        /// </summary>
        /// <param name="data">The data for the table row.</param>
        /// <returns>The data formatted as a table row.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given data is null.</exception>
        public override string AsTableRow(string[] data)
        {
            Logger.Trace($"AsTableRow()");

            if (data == null)
            {
                Logger.Fatal($"Data not specified");
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

            Logger.Debug($"AsTableRow(): '{formatted}");

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
            Logger.Trace($"BeginBox()");
            Logger.Trace($"Operation not supported");

            return $"";
        }

        /// <summary>
        /// Inserts an indicator to end a box.
        /// </summary>
        /// <returns>Indicator to end a box.</returns>
        public override string EndBox()
        {
            Logger.Trace($"EndBox()");
            Logger.Trace($"Operation not supported");

            return $"";
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
            Logger.Trace($"BeginDataEntry()");

            if (String.IsNullOrEmpty(name))
            {
                Logger.Fatal($"Name not specified");
                throw new ArgumentNullException(nameof(name));
            }

            name = $"---";

            Logger.Debug($"BeginDataEntry(): '{name}'");

            return name;
        }

        /// <summary>
        /// Inserts an indicator to end a data entry.
        /// </summary>
        /// <returns>Indicator to end a data entry.</returns>
        public override string EndDataEntry()
        {
            Logger.Trace($"EndDataEntry()");

            return $"---";
        }
    }
}
