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
    public class ConnectionContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The connection to be used to create the content.
        /// </summary>
        public Connection Connection
        {
            get
            { return (Connection)Entry; }
            set
            { Entry = value; }
        }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new ConnectionContentCreator.
        /// </summary>
        /// <param name="connection">The connection to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public ConnectionContentCreator(Connection connection, Formatter formatter, string targetLanguageCode)
            : base(connection, formatter, targetLanguageCode)
        {
            Logger.Trace($"ConnectionContentCreator()");

            Headings = new Dictionary<string, string>
            {
                { "en", "Connections" },
                { "de", "Verbindungen" }
            };

            Logger.Trace($"ConnectionContentCreator(): ConnectionContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the chapter content of a given type.
        /// </summary>
        /// <returns>The formatted content of the type.</returns>
        public override List<string> CreateChapterContent()
        {
            Logger.Trace($"CreateChapterContent()");
            Logger.Debug($"Connection is '{Connection.Title}'");

            List<string> content = new List<string>();

            if (Connection != null)
            {
                if (Connection.BaseConnection == null)
                {
                    Logger.Debug($"Connection: '{Connection.ID}'");
                    content.Add(Formatter.AsInsertPage(TargetLanguageCode + ":navigation:" + Connection.ID));
                }
                else
                {
                    Logger.Debug($"Connection.BaseConnection is not null -> create");
                    content.AddRange(new ConnectionContentCreator(Connection.BaseConnection, Formatter, TargetLanguageCode).CreateChapterContent());
                }
            }

            Logger.Trace($"CreateChapterContent(): chapter content for Connection '{Connection.Title}' created");

            return content;
        }
    }
}
