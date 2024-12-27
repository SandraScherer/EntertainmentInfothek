// WikiPageCreator.exe: Creates pages for use with a wiki from the
// EntertainmentInfothek.db using EntertainmentDB.dll
// Copyright (C) 2023 Sandra Scherer

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
    /// Provides a content creator for a filmformat.
    /// </summary>
    public class FilmFormatContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The list of filmformat items to be used to create the content.
        /// </summary>
        public List<FilmFormatItem> FilmFormats { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new FilmFormatContentCreator.
        /// </summary>
        /// <param name="filmformats">The list of filmformat items to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public FilmFormatContentCreator(List<FilmFormatItem> filmformats, Formatter formatter, string targetLanguageCode)
            : base(filmformats[0].FilmFormat, formatter, targetLanguageCode)
        {
            Logger.Trace($"FilmFormatContentCreator()");

            FilmFormats = filmformats;

            Logger.Trace($"FilmFormatContentCreator(): FilmFormatContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the infobox content of a given list of filmformats.
        /// </summary>
        /// <returns>The formatted content of the list of filmformats.</returns>
        public override List<string> CreateInfoBoxContent()
        {
            Logger.Trace($"CreateInfoBoxContent()");

            List<string> content = new List<string>();

            if ((FilmFormats != null) && (FilmFormats.Count > 0))
            {
                Logger.Debug($"FilmFormats is not null");
                Logger.Debug($"no of filmformats: '{FilmFormats.Count}'");

                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"FilmFormat: '{FilmFormats[0].FilmFormat.Format}' (english)");

                    CreateInfoBoxContentHelper(content, Headings["en"], FilmFormats[0].FilmFormat.Format, FilmFormats[0].Details);

                    for (int i = 1; i < FilmFormats.Count; i++)
                    {
                        Logger.Debug($"FilmFormat: '{FilmFormats[i].FilmFormat.Format}' (english)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), FilmFormats[i].FilmFormat.Format, FilmFormats[i].Details);
                    }
                }
                else // incl. case "de"
                {
                    Logger.Debug($"FilmFormat: '{FilmFormats[0].FilmFormat.Format}' (german, ...)");

                    CreateInfoBoxContentHelper(content, Headings["de"], FilmFormats[0].FilmFormat.Format, FilmFormats[0].Details);

                    for (int i = 1; i < FilmFormats.Count; i++)
                    {
                        Logger.Debug($"FilmFormat: '{FilmFormats[i].FilmFormat.Format}' (german, ...)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), FilmFormats[i].FilmFormat.Format, FilmFormats[i].Details);
                    }
                }
            }
            Logger.Trace($"CreateInfoBoxContent(): infobox content for the list of FilmFormats with count '{FilmFormats.Count}' created");

            return content;
        }
    }
}
