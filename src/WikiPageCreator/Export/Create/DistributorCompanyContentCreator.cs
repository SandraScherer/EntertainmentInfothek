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
    /// Provides a content creator for a distributor company.
    /// </summary>
    public class DistributorCompanyContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The list of distributor company items to be used to create the content.
        /// </summary>
        public List<DistributorCompanyItem> Distributors { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new DistributorCompanyContentCreator.
        /// </summary>
        /// <param name="distributors">The list of company items to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public DistributorCompanyContentCreator(List<DistributorCompanyItem> distributors, Formatter formatter, string targetLanguageCode)
            : base(distributors[0], formatter, targetLanguageCode)
        {
            Logger.Trace($"istributorCompanyContentCreator()");

            Distributors = distributors;
            Headings = new Dictionary<string, string>
            {
                { "en", "Dummy" },
                { "de", "Dummy" }
            };

            Logger.Trace($"istributorCompanyContentCreator(): istributorCompanyContentCreator created");
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
            string[] pathCompany = { TargetLanguageCode, Path.Company.ToString().ToLower() };
            string[] pathDate = { TargetLanguageCode, Path.Date.ToString().ToLower() };
            string[] pathInfo = { TargetLanguageCode, Path.Info.ToString().ToLower() };

            if ((Distributors != null) && (Distributors.Count > 0))
            {
                Logger.Debug($"Distributors is not null");
                Logger.Debug($"no of distributors: '{Distributors.Count}'");

                string[] title = { null };
                content.Add(Formatter.AsTableTitle(title));

                if (TargetLanguageCode.Equals("en"))
                {
                    for (int i = 0; i < Distributors.Count; i++)
                    {
                        Logger.Debug($"Distributor: '{Distributors[i].Company.Name}'");

                        if ((!String.IsNullOrEmpty(Distributors[i].Company.NameAddOn)) && (!String.IsNullOrEmpty(Distributors[i].Role)) && (!String.IsNullOrEmpty(Distributors[i].ReleaseDate)) && (null != (Distributors[i].Country)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name} {Distributors[i].Company.NameAddOn}", pathDate, $"{Distributors[i].ReleaseDate}", pathInfo, $"{Distributors[i].Country.OriginalFullName}", $"{Distributors[i].Country.EnglishShortName}", $"({Distributors[i].Role}) {Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].Company.NameAddOn)) && (!String.IsNullOrEmpty(Distributors[i].Role)) && (!String.IsNullOrEmpty(Distributors[i].ReleaseDate)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name} {Distributors[i].Company.NameAddOn}", pathDate, $"{Distributors[i].ReleaseDate}", $"({Distributors[i].Role}) {Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].Company.NameAddOn)) && (!String.IsNullOrEmpty(Distributors[i].Role)) && (null != (Distributors[i].Country)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name} {Distributors[i].Company.NameAddOn}", pathInfo, $"{Distributors[i].Country.OriginalFullName}", $"{Distributors[i].Country.EnglishShortName}", $"({Distributors[i].Role}) {Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].Company.NameAddOn)) && (!String.IsNullOrEmpty(Distributors[i].ReleaseDate)) && (null != (Distributors[i].Country)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name} {Distributors[i].Company.NameAddOn}", pathDate, $"{Distributors[i].ReleaseDate}", pathInfo, $"{Distributors[i].Country.OriginalFullName}", $"{Distributors[i].Country.EnglishShortName}", $"{Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].Role)) && (!String.IsNullOrEmpty(Distributors[i].ReleaseDate)) && (null != (Distributors[i].Country)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name}", pathDate, $"{Distributors[i].ReleaseDate}", pathInfo, $"{Distributors[i].Country.OriginalFullName}", $"{Distributors[i].Country.EnglishShortName}", $"({Distributors[i].Role}) {Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].Company.NameAddOn)) && (!String.IsNullOrEmpty(Distributors[i].Role)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name} {Distributors[i].Company.NameAddOn}", $"({Distributors[i].Role}) {Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].Company.NameAddOn)) && (!String.IsNullOrEmpty(Distributors[i].ReleaseDate)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name} {Distributors[i].Company.NameAddOn}", pathDate, $"{Distributors[i].ReleaseDate}", $"{Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].Role)) && (!String.IsNullOrEmpty(Distributors[i].ReleaseDate)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name}", pathDate, $"{Distributors[i].ReleaseDate}", $"({Distributors[i].Role}) {Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].Company.NameAddOn)) && (null != (Distributors[i].Country)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name} {Distributors[i].Company.NameAddOn}", pathInfo, $"{Distributors[i].Country.OriginalFullName}", $"{Distributors[i].Country.EnglishShortName}", $"{Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].Role)) && (null != (Distributors[i].Country)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name}", pathInfo, $"{Distributors[i].Country.OriginalFullName}", $"{Distributors[i].Country.EnglishShortName}", $"({Distributors[i].Role}) {Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].ReleaseDate)) && (null != (Distributors[i].Country)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name}", pathDate, $"{Distributors[i].ReleaseDate}", pathInfo, $"{Distributors[i].Country.OriginalFullName}", $"{Distributors[i].Country.EnglishShortName}", $"{Distributors[i].Details}");
                        }
                        else if (!String.IsNullOrEmpty(Distributors[i].Company.NameAddOn))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name} {Distributors[i].Company.NameAddOn}", Distributors[i].Details);
                        }
                        else if (!String.IsNullOrEmpty(Distributors[i].Role))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name}", $"({Distributors[i].Role}) {Distributors[i].Details}");
                        }
                        else if (!String.IsNullOrEmpty(Distributors[i].ReleaseDate))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name}", pathDate, $"{Distributors[i].ReleaseDate}", $"{Distributors[i].Details}");
                        }
                        else if (null != (Distributors[i].Country))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name}", pathInfo, $"{Distributors[i].Country.OriginalFullName}", $"{Distributors[i].Country.EnglishShortName}", $"{Distributors[i].Details}");
                        }
                        else
                        {
                            CreateSectionContentHelper(content, pathCompany, Distributors[i].Company.Name, Distributors[i].Details);
                        }
                    }
                }
                else // incl. case "de""
                {
                    for (int i = 0; i < Distributors.Count; i++)
                    {
                        Logger.Debug($"Distributor: '{Distributors[i].Company.Name}'");

                        if ((!String.IsNullOrEmpty(Distributors[i].Company.NameAddOn)) && (!String.IsNullOrEmpty(Distributors[i].Role)) && (!String.IsNullOrEmpty(Distributors[i].ReleaseDate)) && (null != (Distributors[i].Country)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name} {Distributors[i].Company.NameAddOn}", pathDate, $"{Distributors[i].ReleaseDate}", pathInfo, $"{Distributors[i].Country.OriginalFullName}", $"{Distributors[i].Country.GermanShortName}", $"({Distributors[i].Role}) {Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].Company.NameAddOn)) && (!String.IsNullOrEmpty(Distributors[i].Role)) && (!String.IsNullOrEmpty(Distributors[i].ReleaseDate)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name} {Distributors[i].Company.NameAddOn}", pathDate, $"{Distributors[i].ReleaseDate}", $"({Distributors[i].Role}) {Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].Company.NameAddOn)) && (!String.IsNullOrEmpty(Distributors[i].Role)) && (null != (Distributors[i].Country)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name} {Distributors[i].Company.NameAddOn}", pathInfo, $"{Distributors[i].Country.OriginalFullName}", $"{Distributors[i].Country.GermanShortName}", $"({Distributors[i].Role}) {Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].Company.NameAddOn)) && (!String.IsNullOrEmpty(Distributors[i].ReleaseDate)) && (null != (Distributors[i].Country)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name} {Distributors[i].Company.NameAddOn}", pathDate, $"{Distributors[i].ReleaseDate}", pathInfo, $"{Distributors[i].Country.OriginalFullName}", $"{Distributors[i].Country.GermanShortName}", $"{Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].Role)) && (!String.IsNullOrEmpty(Distributors[i].ReleaseDate)) && (null != (Distributors[i].Country)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name}", pathDate, $"{Distributors[i].ReleaseDate}", pathInfo, $"{Distributors[i].Country.OriginalFullName}", $"{Distributors[i].Country.GermanShortName}", $"({Distributors[i].Role}) {Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].Company.NameAddOn)) && (!String.IsNullOrEmpty(Distributors[i].Role)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name} {Distributors[i].Company.NameAddOn}", $"({Distributors[i].Role}) {Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].Company.NameAddOn)) && (!String.IsNullOrEmpty(Distributors[i].ReleaseDate)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name} {Distributors[i].Company.NameAddOn}", pathDate, $"{Distributors[i].ReleaseDate}", $"{Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].Role)) && (!String.IsNullOrEmpty(Distributors[i].ReleaseDate)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name}", pathDate, $"{Distributors[i].ReleaseDate}", $"({Distributors[i].Role}) {Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].Company.NameAddOn)) && (null != (Distributors[i].Country)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name} {Distributors[i].Company.NameAddOn}", pathInfo, $"{Distributors[i].Country.OriginalFullName}", $"{Distributors[i].Country.GermanShortName}", $"{Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].Role)) && (null != (Distributors[i].Country)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name}", pathInfo, $"{Distributors[i].Country.OriginalFullName}", $"{Distributors[i].Country.GermanShortName}", $"({Distributors[i].Role}) {Distributors[i].Details}");
                        }
                        else if ((!String.IsNullOrEmpty(Distributors[i].ReleaseDate)) && (null != (Distributors[i].Country)))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name}", pathDate, $"{Distributors[i].ReleaseDate}", pathInfo, $"{Distributors[i].Country.OriginalFullName}", $"{Distributors[i].Country.GermanShortName}", $"{Distributors[i].Details}");
                        }
                        else if (!String.IsNullOrEmpty(Distributors[i].Company.NameAddOn))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name} {Distributors[i].Company.NameAddOn}", Distributors[i].Details);
                        }
                        else if (!String.IsNullOrEmpty(Distributors[i].Role))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name}", $"({Distributors[i].Role}) {Distributors[i].Details}");
                        }
                        else if (!String.IsNullOrEmpty(Distributors[i].ReleaseDate))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name}", pathDate, $"{Distributors[i].ReleaseDate}", $"{Distributors[i].Details}");
                        }
                        else if (null != (Distributors[i].Country))
                        {
                            CreateSectionContentHelper(content, pathCompany, $"{Distributors[i].Company.Name}", pathInfo, $"{Distributors[i].Country.OriginalFullName}", $"{Distributors[i].Country.GermanShortName}", $"{Distributors[i].Details}");
                        }
                        else
                        {
                            CreateSectionContentHelper(content, pathCompany, Distributors[i].Company.Name, Distributors[i].Details);
                        }
                    }
                }

                content.Add("");
                content.Add("");
            }
            Logger.Trace($"CreateSectionContent(): section content for the list of Distributors with count '{Distributors.Count}' created");

            return content;
        }
    }
}
