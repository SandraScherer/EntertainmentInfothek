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

namespace WikiPageCreator.Export.Create
{
    /// <summary>
    /// Provides a content creator for a connection.
    /// </summary>
    public class ConnectionContentCreator : ISectionContentCreatable
    {
        // --- Properties ---

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new ConnectionContentCreator.
        /// </summary>
        public ConnectionContentCreator()
        {
            Logger.Trace($"ConnectionContentCreator() angelegt");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the section content of a given entry.
        /// </summary>
        /// <param name="entry">The entry that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted content of the entry.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public virtual List<string> CreateSectionContent(Entry entry, string targetLanguageCode, Formatter formatter)
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

            Logger.Trace($"CreateSectionContent() für Connection '{((Connection)entry).ID}' gestartet");

            List<string> content = new List<string>();

            content.AddRange(this.CreateSectionConnection((Connection)entry, targetLanguageCode, formatter));
            content.Add("");
            content.Add("");

            Logger.Trace($"CreateSectionContent() für Connection '{((Connection)entry).ID}' beendet");

            return content;
        }

        /// <summary>
        /// Creates the formatted connection section content of a given connection.
        /// </summary>
        /// <param name="connection">The connection that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted section content of the connection.</returns>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        protected virtual List<string> CreateSectionConnection(Connection connection, string targetLanguageCode, Formatter formatter)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (targetLanguageCode == null)
            {
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            Logger.Trace($"CreateSectionConnection() für Connection '{connection.ID}' gestartet");

            List<string> content = new List<string>();

            if (connection.BaseConnection == null)
            {
                content.Add(formatter.AsInsertPage(targetLanguageCode + ":navigation:" + connection.ID));
            }
            else
            {
                content.Add(formatter.AsInsertPage(targetLanguageCode + ":navigation:" + connection.BaseConnection.ID));
            }

            Logger.Trace($"CreateSectionConnection() für Connection '{connection.ID}' beendet");

            return content;
        }
    }
}
