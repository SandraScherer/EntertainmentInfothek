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


using EntertainmentDB.Data;
using System;
using System.Collections.Generic;
using WikiPageCreator.Export.Format;
using Type = EntertainmentDB.Data.Type;

namespace WikiPageCreator.Export.Create
{
    /// <summary>
    /// Provides a content creator for a type
    /// </summary>
    public class TypeContentCreator : IInfoBoxContentCreatable
    {
        // --- Properties ---

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new TypeContentCreator.
        /// </summary>
        public TypeContentCreator()
        {
            Logger.Trace($"TypeContentCreator() angelegt");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the infobox content of a given entry.
        /// </summary>
        /// <param name="entry">The entry that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted content of the entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public virtual List<string> CreateInfoBoxContent(Entry entry, string targetLanguageCode, Formatter formatter)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxContent() für Type '{((Type)entry).ID}' gestartet");

            List<string> content = new List<string>();

            content.AddRange(this.CreateInfoBoxType((Type)entry, targetLanguageCode, formatter));

            Logger.Trace($"CreateInfoBoxContent() für Type '{((Type)entry).ID}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted infobox content of a given type.
        /// </summary>
        /// <param name="type">The type that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted infobox content of the type.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateInfoBoxType(Type type, string targetLanguageCode, Formatter formatter)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateInfoBoxType() für Type '{type.ID}' gestartet");

            List<string> content = new List<string>();
            string[] data = new string[2];
            string[] path = { targetLanguageCode, "info" };

            if (targetLanguageCode.Equals("en"))
            {
                data[0] = "Type";
                data[1] = formatter.AsInternalLink(path, type.EnglishTitle, type.EnglishTitle);
            }
            else // incl. case "de"
            {
                data[0] = "Typ";
                data[1] = formatter.AsInternalLink(path, type.EnglishTitle, type.GermanTitle);
            }
            content.Add(formatter.AsTableRow(data));

            Logger.Trace($"CreateInfoBoxType() für Type '{type.ID}' beendet");

            return content;
        }
    }
}
