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
    /// Provides a content creator for a language.
    /// </summary>
    public class LanguageContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The list of language items to be used to create the content.
        /// </summary>
        public List<LanguageItem> Languages { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new LanguageContentCreator.
        /// </summary>
        /// <param name="languages">The list of language items to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public LanguageContentCreator(List<LanguageItem> languages, Formatter formatter, string targetLanguageCode)
            : base(languages[0].Language, formatter, targetLanguageCode)
        {
            Logger.Trace($"LanguageContentCreator()");

            Languages = languages;
            Headings = new Dictionary<string, string>
            {
                { "en", "Language" },
                { "de", "Sprache" }
            };

            Logger.Trace($"LanguageContentCreator(): LanguageContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the infobox content of a given list of languages.
        /// </summary>
        /// <returns>The formatted content of the list of languages.</returns>
        public override List<string> CreateInfoBoxContent()
        {
            Logger.Trace($"CreateInfoBoxContent()");

            List<string> content = new List<string>();
            string[] path = { TargetLanguageCode, "info" };

            if ((Languages != null) && (Languages.Count > 0))
            {
                Logger.Debug($"Languages is not null");
                Logger.Debug($"no of languages: '{Languages.Count}'");

                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"Language: '{Languages[0].Language.EnglishName}' (english)");

                    CreateInfoBoxContentHelper(content, Headings["en"], path, Languages[0].Language.OriginalName, Languages[0].Language.EnglishName, Languages[0].Details);

                    for (int i = 1; i < Languages.Count; i++)
                    {
                        Logger.Debug($"Language: '{Languages[i].Language.EnglishName}' (english)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), path, Languages[i].Language.OriginalName, Languages[i].Language.EnglishName, Languages[i].Details);
                    }
                }
                else // incl. case "de"
                {
                    Logger.Debug($"Language: '{Languages[0].Language.GermanName}' (german, ...)");

                    CreateInfoBoxContentHelper(content, Headings["de"], path, Languages[0].Language.OriginalName, Languages[0].Language.GermanName, Languages[0].Details);

                    for (int i = 1; i < Languages.Count; i++)
                    {
                        Logger.Debug($"Language: '{Languages[i].Language.GermanName}' (german, ...)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), path, Languages[i].Language.OriginalName, Languages[i].Language.GermanName, Languages[i].Details);
                    }
                }
            }
            Logger.Trace($"CreateInfoBoxContent(): infobox content for the list of Languages with count '{Languages.Count}' created");

            return content;
        }
    }
}
