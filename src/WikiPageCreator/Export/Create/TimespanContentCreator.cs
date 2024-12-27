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
    /// Provides a content creator for a timespan.
    /// </summary>
    public class TimespanContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The list of timespan items to be used to create the content.
        /// </summary>
        public List<TimespanItem> Timespans { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new TimespanContentCreator.
        /// </summary>
        /// <param name="timespans">The list of timespan items to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public TimespanContentCreator(List<TimespanItem> timespans, Formatter formatter, string targetLanguageCode)
            : base(timespans[0], formatter, targetLanguageCode)
        {
            Logger.Trace($"TimespanContentCreator()");

            Timespans = timespans;
            Headings = new Dictionary<string, string>
            {
                { "en", "Dummy" },
                { "de", "Dummy" }
            };

            Logger.Trace($"TimespanContentCreator(): TimespanContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the section content of a given list of timespans.
        /// </summary>
        /// <returns>The formatted content of the list of timespans.</returns>
        public override List<string> CreateSectionContent()
        {
            Logger.Trace($"CreateSectionContent()");

            List<string> content = new List<string>();
            string[] path = { TargetLanguageCode, "date" };

            if ((Timespans != null) && (Timespans.Count > 0))
            {
                Logger.Debug($"Timespans is not null");
                Logger.Debug($"no of timespans: '{Timespans.Count}'");

                string[] title = { null };
                content.Add(Formatter.AsTableTitle(title));

                Logger.Debug($"Timespan: '{Timespans[0].StartDate} - {Timespans[0].EndDate}'");

                CreateSectionContentHelper(content, path, $"{Timespans[0].StartDate}", $"{Timespans[0].EndDate}", Timespans[0].Details);

                for (int i = 1; i < Timespans.Count; i++)
                {
                    Logger.Debug($"Timespan: '{Timespans[i].StartDate} - {Timespans[i].EndDate}'");

                    CreateSectionContentHelper(content, path, $"{Timespans[i].StartDate}", $"{Timespans[i].EndDate}", Timespans[i].Details);
                }

                content.Add("");
                content.Add("");
            }
            Logger.Trace($"CreateSectionContent(): section content for the list of Timespans with count '{Timespans.Count}' created");

            return content;
        }
    }
}
