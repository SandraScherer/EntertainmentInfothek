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
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            Logger.Trace($"TypeContentCreator() angelegt");
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
            Logger.Trace($"CreateInfoBoxContentInternal() für Type '{Type.ID}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];
            string[] path = { TargetLanguageCode, "info" };

            if (Type != null)
            {
                if (TargetLanguageCode.Equals("en"))
                {
                    data[0] = "Type";
                    data[1] = Formatter.AsInternalLink(path, Type.EnglishTitle, Type.EnglishTitle);
                }
                else // incl. case "de"
                {
                    data[0] = "Typ";
                    data[1] = Formatter.AsInternalLink(path, Type.EnglishTitle, Type.GermanTitle);
                }
                content.Add(Formatter.AsTableRow(data));
            }
            Logger.Trace($"CreateInfoBoxContentInternal() für Type '{Type.ID}' beendet");

            return content;
        }
    }
}
