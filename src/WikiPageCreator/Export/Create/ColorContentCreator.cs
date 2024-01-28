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
    /// Provides a content creator for a color.
    /// </summary>
    public class ColorContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The list of color items to be used to create the content.
        /// </summary>
        public List<ColorItem> Colors { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new ColorContentCreator.
        /// </summary>
        /// <param name="colors">The list of color items to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public ColorContentCreator(List<ColorItem> colors, Formatter formatter, string targetLanguageCode)
            : base(colors[0].Color, formatter, targetLanguageCode)
        {
            Logger.Trace($"ColorContentCreator()");

            Colors = colors;
            Headings = new Dictionary<string, string>
            {
                { "en", "Color" },
                { "de", "Farbe" }
            };

            Logger.Trace($"ColorContentCreator(): ColorContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the infobox content of a given list of colors.
        /// </summary>
        /// <returns>The formatted content of the list of colors.</returns>
        public override List<string> CreateInfoBoxContent()
        {
            Logger.Trace($"CreateInfoBoxContent()");

            List<string> content = new List<string>();
            string[] path = { TargetLanguageCode, "info" };

            if ((Colors != null) && (Colors.Count > 0))
            {
                Logger.Debug($"Colors is not null");
                Logger.Debug($"no of colors: '{Colors.Count}'");

                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"Color: '{Colors[0].Color.EnglishTitle}' (english)");

                    CreateInfoBoxContentHelper(content, Headings["en"], path, Colors[0].Color.EnglishTitle, Colors[0].Color.EnglishTitle, Colors[0].Details);

                    for (int i = 1; i < Colors.Count; i++)
                    {
                        Logger.Debug($"Color: '{Colors[i].Color.EnglishTitle}' (english)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), path, Colors[i].Color.EnglishTitle, Colors[i].Color.EnglishTitle, Colors[i].Details);
                    }
                }
                else // incl. case "de"
                {
                    Logger.Debug($"Color: '{Colors[0].Color.GermanTitle}' (german, ...)");

                    CreateInfoBoxContentHelper(content, Headings["de"], path, Colors[0].Color.EnglishTitle, Colors[0].Color.GermanTitle, Colors[0].Details);

                    for (int i = 1; i < Colors.Count; i++)
                    {
                        Logger.Debug($"Color: '{Colors[i].Color.GermanTitle}' (german, ...)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), path, Colors[i].Color.EnglishTitle, Colors[i].Color.GermanTitle, Colors[i].Details);
                    }
                }
            }
            Logger.Trace($"CreateInfoBoxContent(): infobox content for the list of Colors with count '{Colors.Count}' created");

            return content;
        }
    }
}
