﻿// WikiPageCreator.exe: Creates pages for use with a wiki from the
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
            if (connection == null)
            {
                Logger.Fatal($"Connection not specified");
                throw new ArgumentNullException(nameof(connection));
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

            Logger.Trace($"ConnectionContentCreator() with ID = '{id}' created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the chapter content of a given type.
        /// </summary>
        /// <returns>The formatted content of the type.</returns>
        public override List<string> CreateChapterContent()
        {
            return CreateChapterContentInternal();
        }

        /// <summary>
        /// Creates the section content of a given type.
        /// </summary>
        /// <returns>The formatted section content of the type.</returns>
        public override List<string> CreateSectionContent()
        {
            return CreateChapterContentInternal();
        }

        /// <summary>
        /// Creates the chapter content of a given type.
        /// </summary>
        /// <returns>The formatted content of the type.</returns>
        protected override List<string> CreateChapterContentInternal()
        {
            Logger.Trace($"CreateChapterContentInternal() für Connection '{Connection.ID}' gestartet");

            List<string> content = new List<string>();

            if (Connection != null)
            {
                if (Connection.BaseConnection == null)
                {
                    content.Add(Formatter.AsInsertPage(TargetLanguageCode + ":navigation:" + Connection.ID));
                }
                else
                {
                    content.Add(Formatter.AsInsertPage(TargetLanguageCode + ":navigation:" + Connection.BaseConnection.ID));
                }
            }

            Logger.Trace($"CreateChapterContentInternal() für Connection '{Connection.ID}' beendet");

            return content;
        }
    }
}
