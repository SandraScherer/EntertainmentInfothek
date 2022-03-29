﻿// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
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


using EntertainmentDB.DBAccess.Read;
using System;

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides an article.
    /// </summary>
    public abstract class Article : Entry
    {
        // --- Properties ---

        /// <summary>
        /// The original title of the series.
        /// </summary>
        public string OriginalTitle { get; set; }

        /// <summary>
        /// The english title of the series.
        /// </summary>
        public string EnglishTitle { get; set; }

        /// <summary>
        /// The german title of the series.
        /// </summary>
        public string GermanTitle { get; set; }

        /// <summary>
        /// The type of the series.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// The release date of the movie.
        /// </summary>
        public string ReleaseDate { get; set; }

        /// <summary>
        /// The connection of the movie.
        /// </summary>
        public Connection Connection { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes an article with an empty id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the article information from the database.</param>
        protected Article(DBReader reader) : this(reader, "")
        {
        }

        /// <summary>
        /// Initializes an article with the given id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the article information from the database.</param>
        /// <param name="id">The id of the article.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        protected Article(DBReader reader, string id) : base(reader, id)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Logger.Trace($"Article() angelegt");
        }
    }
}