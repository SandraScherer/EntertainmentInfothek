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


using EntertainmentDB.Data;
using System;
using System.Collections.Generic;
using WikiPageCreator.Export.Format;

namespace WikiPageCreator.Export.Create
{
    /// <summary>
    /// Provides a content creator for a production date.
    /// </summary>
    public class ProductionDateContentCreator : TimespanContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new ProductionDateContentCreator.
        /// </summary>
        /// <param name="timespans">The list of production date items to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public ProductionDateContentCreator(List<TimespanItem> timespans, Formatter formatter, string targetLanguageCode)
            : base(timespans, formatter, targetLanguageCode)
        {
            Logger.Trace($"ProductionDateContentCreator()");

            Timespans = timespans;
            Headings = new Dictionary<string, string>
            {
                { "en", "Production Dates" },
                { "de", "Produktionsdaten" }
            };

            Logger.Trace($"ProductionDateContentCreator(): ProductionDateContentCreator created");
        }
    }
}
