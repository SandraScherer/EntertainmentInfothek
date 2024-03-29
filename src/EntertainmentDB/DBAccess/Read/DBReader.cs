﻿// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
// Copyright (C) 2020 Sandra Scherer

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


using System.Data;

namespace EntertainmentDB.DBAccess.Read
{
    /// <summary>
    /// Provides a database reader.
    /// </summary>
    public abstract class DBReader : IDBReadable
    {
        // --- Properties ---

        /// <summary>
        /// The query of the database reader.
        /// </summary>
        public string Query { get; set; } = "";

        /// <summary>
        /// The data table of the database reader.
        /// </summary>
        public DataTable Table { get; protected set; } = new DataTable();

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a database reader.
        /// </summary>
        protected DBReader()
        {
            Logger.Trace($"DBReader(): DBReader created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates a new DBReader of the same class as the current DBReader.
        /// </summary>
        /// <returns>A new DBReader of the same class as the current DBReader.</returns>
        public abstract DBReader New();

        /// <summary>
        /// Retrieves the information from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>The number of data records retrieved.</returns>
        public abstract int Retrieve(bool retrieveBasicInfoOnly);

    }
}
