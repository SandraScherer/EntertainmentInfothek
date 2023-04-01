// WikiPageCreator.exe: Creates pages for use with a wiki from the
// EntertainmentInfothek.db using EntertainmentDB.dll
// Copyright (C) 2021 Sandra Scherer

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


using System;
using System.Collections.Generic;
using WikiPageCreator.Export.Format;
using Type = EntertainmentDB.Data.Type;

namespace WikiPageCreator.Export.Create
{
    /// <summary>
    /// Provides a content creator for a type
    /// </summary>
    public class TypeContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The type to be used to create the content.
        /// </summary>
        public Type Type
        {
            get
            { return (Type)Entry; }
            set
            { Entry = value; }
        }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new TypeContentCreator.
        /// </summary>
        /// <param name="type">The type to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public TypeContentCreator(Type type, Formatter formatter, string targetLanguageCode)
            : base(type, formatter, targetLanguageCode)
        {
            Logger.Trace($"TypeContentCreator()");

            if (type == null)
            {
                Logger.Fatal($"Type not specified");
                throw new ArgumentNullException(nameof(type));
            }
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

            Headings = new Dictionary<string, string>
            {
                { "en", "Type" },
                { "de", "Typ" }
            };

            Logger.Trace($"TypeContentCreator(): TypeContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the infobox content of a given type.
        /// </summary>
        /// <returns>The formatted content of the type.</returns>
        public override List<string> CreateInfoBoxContent()
        {
            return CreateInfoBoxContentInternal();
        }

        /// <summary>
        /// Creates the infobox content of a given type.
        /// </summary>
        /// <returns>The formatted content of the type.</returns>
        protected override List<string> CreateInfoBoxContentInternal()
        {
            Logger.Trace($"CreateInfoBoxContentInternal()");
            Logger.Debug($"Type is '{Type.ID}'");

            List<string> content = new List<string>();
            string[] data = new string[2];
            string[] path = { TargetLanguageCode, "info" };

            if (Type != null)
            {
                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"Type: '{Type.EnglishTitle}' (english)");
                    data[0] = Headings["en"];
                    data[1] = Formatter.AsInternalLink(path, Type.EnglishTitle, Type.EnglishTitle);
                }
                else // incl. case "de"
                {
                    Logger.Debug($"Type: '{Type.GermanTitle}' (german, ...)");
                    data[0] = Headings["de"];
                    data[1] = Formatter.AsInternalLink(path, Type.EnglishTitle, Type.GermanTitle);
                }
                content.Add(Formatter.AsTableRow(data));
            }
            Logger.Trace($"CreateInfoBoxContentInternal(): infobox content for Type '{Type.ID}' created");

            return content;
        }
    }
}
