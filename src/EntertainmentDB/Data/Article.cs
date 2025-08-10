// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
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
using System.Collections.Generic;

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides an article.
    /// </summary>
    public abstract class Article : Entry
    {
        // --- Properties ---

        /// <summary>
        /// The original title of the article.
        /// </summary>
        public string OriginalTitle { get; set; }

        /// <summary>
        /// The english title of the article.
        /// </summary>
        public string EnglishTitle { get; set; }

        /// <summary>
        /// The german title of the article.
        /// </summary>
        public string GermanTitle { get; set; }

        /// <summary>
        /// The type of the article.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// The release date of the article.
        /// </summary>
        public string ReleaseDate { get; set; }

        /// <summary>
        /// The list of genres of the article.
        /// </summary>
        public List<GenreItem> Genres { get; set; }

        /// <summary>
        /// The list of certifications of the article.
        /// </summary>
        public List<CertificationItem> Certifications { get; set; }

        /// <summary>
        /// The connection of the article.
        /// </summary>
        public Connection Connection { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes an article with the given reader and id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the article information from the database.</param>
        /// <param name="id">The id of the article.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        protected Article(DBReader reader, string id) : base(reader, id)
        {
            Logger.Trace($"Article(): Article with ID = '{id}' created");
        }
    }
}
