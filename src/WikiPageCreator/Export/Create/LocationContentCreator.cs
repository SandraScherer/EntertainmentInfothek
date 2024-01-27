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
    /// Provides a content creator for a location.
    /// </summary>
    public class LocationContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The list of location items to be used to create the content.
        /// </summary>
        public List<LocationItem> Locations { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new LocationContentCreator.
        /// </summary>
        /// <param name="locations">The list of location items to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public LocationContentCreator(List<LocationItem> locations, Formatter formatter, string targetLanguageCode)
            : base(locations[0], formatter, targetLanguageCode)
        {
            Logger.Trace($"LocationContentCreator()");

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

            Locations = locations;
            Headings = new Dictionary<string, string>
            {
                { "en", "Filming Locations" },
                { "de", "Drehorte" }
            };

            Logger.Trace($"LocationContentCreator(): LocationContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the section content of a given list of locations.
        /// </summary>
        /// <returns>The formatted content of the list of locations.</returns>
        public override List<string> CreateSectionContent()
        {
            Logger.Trace($"CreateSectionContent()");

            List<string> content = new List<string>();
            string[] path = { TargetLanguageCode, "info" };

            if ((Locations != null) && (Locations.Count > 0))
            {
                Logger.Debug($"Locations is not null");
                Logger.Debug($"no of locations: '{Locations.Count}'");

                Logger.Debug($"Location: '{Locations[0].Location.Name}'");

                if (TargetLanguageCode.Equals("en"))
                {
                    CreateSectionContentHelper(content, path, Locations[0].Location.Name, Locations[0].Location.Country.OriginalFullName, Locations[0].Location.Country.EnglishShortName, Locations[0].Details);

                    for (int i = 1; i < Locations.Count; i++)
                    {
                        Logger.Debug($"Location: '{Locations[i].Location.Name}'");

                        CreateSectionContentHelper(content, path, Locations[i].Location.Name, Locations[i].Location.Country.OriginalFullName, Locations[i].Location.Country.EnglishShortName, Locations[i].Details);
                    }
                }
                else // incl. case "de"
                {
                    CreateSectionContentHelper(content, path, Locations[0].Location.Name, Locations[0].Location.Country.OriginalFullName, Locations[0].Location.Country.GermanShortName, Locations[0].Details);

                    for (int i = 1; i < Locations.Count; i++)
                    {
                        Logger.Debug($"Location: '{Locations[i].Location.Name}'");

                        CreateSectionContentHelper(content, path, Locations[i].Location.Name, Locations[i].Location.Country.OriginalFullName, Locations[i].Location.Country.GermanShortName, Locations[i].Details);
                    }
                }

                content.Add("");
                content.Add("");
            }
            Logger.Trace($"CreateSectionContent(): section content for the list of Locations with count '{Locations.Count}' created");

            return content;
        }
    }
}
