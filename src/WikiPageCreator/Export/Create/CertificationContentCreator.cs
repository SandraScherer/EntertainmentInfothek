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
    /// Provides a content creator for a certification.
    /// </summary>
    public class CertificationContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The list of certification items to be used to create the content.
        /// </summary>
        public List<CertificationItem> Certifications { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        public CertificationContentCreator(List<CertificationItem> certifications, Formatter formatter, string targetLanguageCode)
            : base(certifications[0].Certification, formatter, targetLanguageCode)
        {
            Logger.Trace($"CertificationContentCreator()");

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

            Certifications = certifications;

            Logger.Trace($"CertificationContentCreator(): CertificationContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the infobox content of a given certification.
        /// </summary>
        /// <returns>The formatted content of the certification.</returns>
        public override List<string> CreateInfoBoxContent()
        {
            return CreateInfoBoxContentInternal();
        }

        /// <summary>
        /// Creates the infobox content of a given list of certifications.
        /// </summary>
        /// <returns>The formatted content of the list of certifications.</returns>
        protected override List<string> CreateInfoBoxContentInternal()
        {
            Logger.Trace($"CreateInfoBoxContentInternal()");

            List<string> content = new List<string>();
            string[] path = { TargetLanguageCode, "info" };

            if ((Certifications != null) && (Certifications.Count > 0))
            {
                Logger.Debug($"Certifications is not null");
                Logger.Debug($"no of certifications: '{Certifications.Count}'");

                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"Certification: '{Certifications[0].Certification.Name}' (english)");

                    CreateInfoBoxContentHelper(content, "Certification", path, Certifications[0].Certification.Name, Certifications[0].Certification.Image, 75, Certifications[0].Details);

                    for (int i = 1; i < Certifications.Count; i++)
                    {
                        Logger.Debug($"Certification: '{Certifications[i].Certification.Name}' (english)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), path, Certifications[i].Certification.Name, Certifications[i].Certification.Image, 75, Certifications[i].Details);
                    }
                }
                else // incl. case "de"
                {
                    Logger.Debug($"Certification: '{Certifications[0].Certification.Name}' (german, ...)");

                    CreateInfoBoxContentHelper(content, "Altersfreigabe", path, Certifications[0].Certification.Name, Certifications[0].Certification.Image, 75, Certifications[0].Details);

                    for (int i = 1; i < Certifications.Count; i++)
                    {
                        Logger.Debug($"Certification: '{Certifications[i].Certification.Name}' (german, ...)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), path, Certifications[i].Certification.Name, Certifications[i].Certification.Image, 75, Certifications[i].Details);
                    }
                }
            }
            Logger.Trace($"CreateInfoBoxContentInternal(): infobox content for List of Certifications with Count '{Certifications.Count}' created");

            return content;
        }
    }
}
