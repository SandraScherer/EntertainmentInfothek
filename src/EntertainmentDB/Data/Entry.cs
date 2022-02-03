// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
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


using EntertainmentDB.DBAccess.Read;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides an entry.
    /// </summary>
    public abstract class Entry : IDBReadable
    {
        // --- Properties ---

        /// <summary>
        /// The database reader to be used to read the entry information from the database.
        /// </summary>
        public DBReader Reader { get; set; } = new SQLiteReader();

        /// <summary>
        /// The id of the entry.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// The details of the entry.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// The status of the entry.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        ///  The date of last update of the entry.
        /// </summary>
        public string LastUpdated { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructor ---

        /// <summary>
        /// Initializes an entry with an empty id string.
        /// </summary>
        protected Entry() : this("")
        {
        }

        /// <summary>
        /// Initializes an entry with the given id string.
        /// </summary>
        /// <param name="id">The id of the entry.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        protected Entry(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Logger.Trace($"Entry() angelegt");

            ID = id;
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the information of the entry from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>The number of data records retrieved.</returns>
        public virtual int Retrieve(bool retrieveBasicInfoOnly)
        {
            Logger.Trace($"Retrieve() aufgerufen");

            int count = RetrieveBasicInformation(retrieveBasicInfoOnly);

            if (!retrieveBasicInfoOnly)
            {
                RetrieveAdditionalInformation();
            }

            return count;
        }

        /// <summary>
        /// Retrieves the basic information of the entry from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        public abstract int RetrieveBasicInformation(bool retrieveBasicInfoOnly);

        /// <summary>
        /// Retrieves the additional information of the entry from the database.
        /// </summary>
        /// <returns>The number of data records retrieved.</returns>
        public abstract int RetrieveAdditionalInformation();
    }
}
