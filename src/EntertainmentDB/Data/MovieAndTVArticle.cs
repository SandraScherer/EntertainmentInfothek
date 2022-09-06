﻿// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
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


using EntertainmentDB.DBAccess.Read;
using System;

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides a movie and tv article.
    /// </summary>
    public abstract class MovieAndTVArticle : Article
    {
        // --- Properties ---

        /// <summary>
        /// The budget of the series.
        /// </summary>
        public string Budget { get; set; }

        /// <summary>
        /// The worldwide gross of the series.
        /// </summary>
        public string WorldwideGross { get; set; }

        /// <summary>
        /// The corresponding date to the worldwide gross of the series.
        /// </summary>
        public string WorldwideGrossDate { get; set; }

        /// <summary>
        /// The cast status of the series.
        /// </summary>
        public Status CastStatus { get; set; }

        /// <summary>
        /// The crew status of the series.
        /// </summary>
        public Status CrewStatus { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a movie and tv article with an empty id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the movie and tv article information from the database.</param>
        protected MovieAndTVArticle(DBReader reader) : this(reader, "")
        {
        }

        /// <summary>
        /// Initializes an article with the given id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the article information from the database.</param>
        /// <param name="id">The id of the article.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        protected MovieAndTVArticle(DBReader reader, string id) : base(reader, id)
        {
            Logger.Trace($"MovieAndTVArticle()");

            if (reader == null)
            {
                Logger.Fatal($"DBReader not specified");
                throw new ArgumentNullException(nameof(reader));
            }
            if (id == null)
            {
                Logger.Fatal($"ID not specified");
                throw new ArgumentNullException(nameof(id));
            }

            Logger.Trace($"MovieAndTVArticle(): MovieAndTVArticle with ID = '{id}' created");
        }
    }
}