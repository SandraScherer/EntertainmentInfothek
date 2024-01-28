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
    /// Provides a content creator for a filmlength.
    /// </summary>
    public class FilmLengthContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The list of filmlength items to be used to create the content.
        /// </summary>
        public List<FilmLengthItem> FilmLengths { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new FilmLengthContentCreator.
        /// </summary>
        /// <param name="filmlengths">The list of filmlength items to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public FilmLengthContentCreator(List<FilmLengthItem> filmlengths, Formatter formatter, string targetLanguageCode)
            : base(filmlengths[0], formatter, targetLanguageCode)
        {
            Logger.Trace($"FilmLengthContentCreator()");

            FilmLengths = filmlengths;
            Headings = new Dictionary<string, string>
            {
                { "en", "Film Length" },
                { "de", "Filmlänge" }
            };

            Logger.Trace($"FilmLengthContentCreator(): FilmLengthContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the infobox content of a given list of filmlengths.
        /// </summary>
        /// <returns>The formatted content of the list of filmlengths.</returns>
        public override List<string> CreateInfoBoxContent()
        {
            Logger.Trace($"CreateInfoBoxContent()");

            List<string> content = new List<string>();

            if ((FilmLengths != null) && (FilmLengths.Count > 0))
            {
                Logger.Debug($"FilmLengths is not null");
                Logger.Debug($"no of filmlengths: '{FilmLengths.Count}'");

                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"FilmLength: '{FilmLengths[0].Length}' (english)");

                    CreateInfoBoxContentHelper(content, Headings["en"], FilmLengths[0].Length, FilmLengths[0].Details);

                    for (int i = 1; i < FilmLengths.Count; i++)
                    {
                        Logger.Debug($"FilmLength: '{FilmLengths[i].Length}' (english)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), FilmLengths[i].Length, FilmLengths[i].Details);
                    }
                }
                else // incl. case "de"
                {
                    Logger.Debug($"FilmLength: '{FilmLengths[0].Length}' (german, ...)");

                    CreateInfoBoxContentHelper(content, Headings["de"], FilmLengths[0].Length, FilmLengths[0].Details);

                    for (int i = 1; i < FilmLengths.Count; i++)
                    {
                        Logger.Debug($"FilmLength: '{FilmLengths[i].Length}' (german, ...)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), FilmLengths[i].Length, FilmLengths[i].Details);
                    }
                }
            }
            Logger.Trace($"CreateInfoBoxContent(): infobox content for the list of FilmLengths with count '{FilmLengths.Count}' created");

            return content;
        }
    }
}
