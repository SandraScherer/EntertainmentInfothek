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
    /// Provides a content creator for a laboratory.
    /// </summary>
    public class LaboratoryContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The list of laboratory items to be used to create the content.
        /// </summary>
        public List<LaboratoryItem> Laboratories { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new LaboratoryContentCreator.
        /// </summary>
        /// <param name="laboratories">The list of laboratory items to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public LaboratoryContentCreator(List<LaboratoryItem> laboratories, Formatter formatter, string targetLanguageCode)
            : base(laboratories[0].Laboratory, formatter, targetLanguageCode)
        {
            Logger.Trace($"LaboratoryContentCreator()");

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

            Laboratories = laboratories;

            Logger.Trace($"LaboratoryContentCreator(): LaboratoryContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the infobox content of a given laboratory.
        /// </summary>
        /// <returns>The formatted content of the laboratory.</returns>
        public override List<string> CreateInfoBoxContent()
        {
            return CreateInfoBoxContentInternal();
        }

        /// <summary>
        /// Creates the infobox content of a given list of laboratories.
        /// </summary>
        /// <returns>The formatted content of the list of laboratories.</returns>
        protected override List<string> CreateInfoBoxContentInternal()
        {
            Logger.Trace($"CreateInfoBoxContentInternal()");

            List<string> content = new List<string>();
            string[] path = { TargetLanguageCode, "info" };

            if ((Laboratories != null) && (Laboratories.Count > 0))
            {
                Logger.Debug($"Laboratories is not null");
                Logger.Debug($"no of laboratories: '{Laboratories.Count}'");

                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"Laboratory: '{Laboratories[0].Laboratory.Name}' (english)");

                    CreateInfoBoxContentHelper(content, "Laboratory", path, Laboratories[0].Laboratory.Name, Laboratories[0].Laboratory.Name, Laboratories[0].Details);

                    for (int i = 1; i < Laboratories.Count; i++)
                    {
                        Logger.Debug($"Laboratory: '{Laboratories[i].Laboratory.Name}' (english)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), path, Laboratories[i].Laboratory.Name, Laboratories[i].Laboratory.Name, Laboratories[i].Details);
                    }
                }
                else // incl. case "de"
                {
                    Logger.Debug($"Laboratory: '{Laboratories[0].Laboratory.Name}' (german, ...)");

                    CreateInfoBoxContentHelper(content, "Labor", path, Laboratories[0].Laboratory.Name, Laboratories[0].Laboratory.Name, Laboratories[0].Details);

                    for (int i = 1; i < Laboratories.Count; i++)
                    {
                        Logger.Debug($"Laboratory: '{Laboratories[i].Laboratory.Name}' (german, ...)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), path, Laboratories[i].Laboratory.Name, Laboratories[i].Laboratory.Name, Laboratories[i].Details);
                    }
                }
            }
            Logger.Trace($"CreateInfoBoxContentInternal(): infobox content for List of Laboratories with Count '{Laboratories.Count}' created");

            return content;
        }
    }
}
