// WikiPageCreator.exe: Creates pages for use with a wiki from the
// EntertainmentInfothek.db using EntertainmentDB.dll
// Copyright (C) 2022 Sandra Scherer

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
    /// Provides a content creator for a country.
    /// </summary>
    public class CountryContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The list of country items to be used to create the content.
        /// </summary>
        public List<CountryItem> Countries { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new CountryContentCreator.
        /// </summary>
        /// <param name="countries">The list of country items to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public CountryContentCreator(List<CountryItem> countries, Formatter formatter, string targetLanguageCode)
            : base(countries[0].Country, formatter, targetLanguageCode)
        {
            Logger.Trace($"CountryContentCreator()");

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

            Countries = countries;
            Headings = new Dictionary<string, string>
            {
                { "en", "Production Country" },
                { "de", "Produktionsland" }
            };

            Logger.Trace($"CountryContentCreator(): CountryContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the infobox content of a given country.
        /// </summary>
        /// <returns>The formatted content of the country.</returns>
        public override List<string> CreateInfoBoxContent()
        {
            return CreateInfoBoxContentInternal();
        }

        /// <summary>
        /// Creates the infobox content of a given list of countries.
        /// </summary>
        /// <returns>The formatted content of the list of countries.</returns>
        protected override List<string> CreateInfoBoxContentInternal()
        {
            Logger.Trace($"CreateInfoBoxContentInternal()");

            List<string> content = new List<string>();
            string[] path = { TargetLanguageCode, "info" };

            if ((Countries != null) && (Countries.Count > 0))
            {
                Logger.Debug($"Countries is not null");
                Logger.Debug($"no of countries: '{Countries.Count}'");

                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"Country: '{Countries[0].Country.OriginalFullName}' (english)");

                    CreateInfoBoxContentHelper(content, Headings["en"], path, Countries[0].Country.OriginalFullName, Countries[0].Country.EnglishShortName, Countries[0].Details);

                    for (int i = 1; i < Countries.Count; i++)
                    {
                        Logger.Debug($"Country: '{Countries[i].Country.OriginalFullName}' (english)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), path, Countries[i].Country.OriginalFullName, Countries[i].Country.EnglishShortName, Countries[i].Details);
                    }
                }
                else // incl. case "de"
                {
                    Logger.Debug($"Country: '{Countries[0].Country.OriginalFullName}' (german, ...)");

                    CreateInfoBoxContentHelper(content, Headings["de"], path, Countries[0].Country.OriginalFullName, Countries[0].Country.GermanShortName, Countries[0].Details);

                    for (int i = 1; i < Countries.Count; i++)
                    {
                        Logger.Debug($"Country: '{Countries[i].Country.OriginalFullName}' (german, ...)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), path, Countries[i].Country.OriginalFullName, Countries[i].Country.GermanShortName, Countries[i].Details);
                    }
                }
            }
            Logger.Trace($"CreateInfoBoxContentInternal(): infobox content for List of Countries with Count '{Countries.Count}' created");

            return content;
        }
    }
}
