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
    /// Provides a content creator for a runtime.
    /// </summary>
    public class RuntimeContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The list of runtime items to be used to create the content.
        /// </summary>
        public List<RuntimeItem> Runtimes { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new RuntimeContentCreator.
        /// </summary>
        /// <param name="runtimes">The list of runtime items to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public RuntimeContentCreator(List<RuntimeItem> runtimes, Formatter formatter, string targetLanguageCode)
            : base(runtimes[0].Edition, formatter, targetLanguageCode)
        {
            Logger.Trace($"RuntimeContentCreator()");

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

            Runtimes = runtimes;
            Headings = new Dictionary<string, string>
            {
                { "en", "Runtime" },
                { "de", "Laufzeit" }
            };

            Logger.Trace($"RuntimeContentCreator(): RuntimeContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the infobox content of a given runtime.
        /// </summary>
        /// <returns>The formatted content of the runtime.</returns>
        public override List<string> CreateInfoBoxContent()
        {
            return CreateInfoBoxContentInternal();
        }

        /// <summary>
        /// Creates the infobox content of a given list of runtimes.
        /// </summary>
        /// <returns>The formatted content of the list of runtimes.</returns>
        protected override List<string> CreateInfoBoxContentInternal()
        {
            Logger.Trace($"CreateInfoBoxContentInternal()");

            List<string> content = new List<string>();
            string[] path = { TargetLanguageCode, "info" };

            if ((Runtimes != null) && (Runtimes.Count > 0))
            {
                Logger.Debug($"Runtimes is not null");
                Logger.Debug($"no of runtimes: '{Runtimes.Count}'");

                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"Runtime: '{Runtimes[0].Runtime}' (english)");

                    CreateInfoBoxContentHelper(content, Headings["en"], Runtimes[0].Runtime, path, Runtimes[0].Edition.EnglishTitle, Runtimes[0].Edition.EnglishTitle, Runtimes[0].Details);

                    for (int i = 1; i < Runtimes.Count; i++)
                    {
                        Logger.Debug($"Runtime: '{Runtimes[i].Runtime}' (english)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), Runtimes[i].Runtime, path, Runtimes[i].Edition.EnglishTitle, Runtimes[i].Edition.EnglishTitle, Runtimes[i].Details);
                    }
                }
                else // incl. case "de"
                {
                    Logger.Debug($"Runtime: '{Runtimes[0].Runtime}' (german, ...)");

                    CreateInfoBoxContentHelper(content,  Headings["de"], Runtimes[0].Runtime, path, Runtimes[0].Edition.EnglishTitle, Runtimes[0].Edition.GermanTitle, Runtimes[0].Details);

                    for (int i = 1; i < Runtimes.Count; i++)
                    {
                        Logger.Debug($"Runtime: '{Runtimes[i].Runtime}' (german, ...)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), Runtimes[i].Runtime, path, Runtimes[i].Edition.EnglishTitle, Runtimes[i].Edition.GermanTitle, Runtimes[i].Details);
                    }
                }
            }
            Logger.Trace($"CreateInfoBoxContentInternal(): infobox content for List of Runtimes with Count '{Runtimes.Count}' created");

            return content;
        }
    }
}
