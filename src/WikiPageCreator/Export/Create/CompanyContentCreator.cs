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
    /// Provides a content creator for a company.
    /// </summary>
    public class CompanyContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The list of company items to be used to create the content.
        /// </summary>
        public List<CompanyItem> Companies { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new CompanyContentCreator.
        /// </summary>
        /// <param name="companies">The list of company items to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public CompanyContentCreator(List<CompanyItem> companies, Formatter formatter, string targetLanguageCode)
            : base(companies[0], formatter, targetLanguageCode)
        {
            Logger.Trace($"CompanyContentCreator()");

            Companies = companies;
            Headings = new Dictionary<string, string>
            {
                { "en", "Dummy" },
                { "de", "Dummy" }
            };

            Logger.Trace($"CompanyContentCreator(): CompanyContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the section content of a given list of companies.
        /// </summary>
        /// <returns>The formatted content of the list of companies.</returns>
        public override List<string> CreateSectionContent()
        {
            Logger.Trace($"CreateSectionContent()");

            List<string> content = new List<string>();
            string[] path = { TargetLanguageCode, "company" };

            if ((Companies != null) && (Companies.Count > 0))
            {
                Logger.Debug($"Companies is not null");
                Logger.Debug($"no of companies: '{Companies.Count}'");

                string[] title = { null };
                content.Add(Formatter.AsTableTitle(title));

                Logger.Debug($"Company: '{Companies[0].Company.Name}'");

                if (!String.IsNullOrEmpty(Companies[0].Company.NameAddOn))
                {
                    CreateSectionContentHelper(content, path, $"{Companies[0].Company.Name} {Companies[0].Company.NameAddOn}", Companies[0].Details);
                }
                else
                {
                    CreateSectionContentHelper(content, path, Companies[0].Company.Name, Companies[0].Details);
                }

                for (int i = 1; i < Companies.Count; i++)
                {
                    Logger.Debug($"Company: '{Companies[i].Company.Name}'");

                    if (!String.IsNullOrEmpty(Companies[i].Company.NameAddOn))
                    {
                        CreateSectionContentHelper(content, path, $"{Companies[i].Company.Name} {Companies[i].Company.NameAddOn}", Companies[i].Details);
                    }
                    else
                    {
                        CreateSectionContentHelper(content, path, Companies[i].Company.Name, Companies[i].Details);
                    }
                }

                content.Add("");
                content.Add("");
            }
            Logger.Trace($"CreateSectionContent(): section content for the list of Companies with count '{Companies.Count}' created");

            return content;
        }
    }
}
