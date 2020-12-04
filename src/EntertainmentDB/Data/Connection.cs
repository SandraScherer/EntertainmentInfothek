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


using EntertainmentDB.DBAccess.Read;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides a connection
    /// </summary>
    public class Connection
    {
        // --- Properties ---

        /// <summary>
        /// The database reader to be used to read the entry information from the database.
        /// </summary>
        // TODO: which DB reader is to be used should be defined in configuration
        public DBReader Reader { get; protected set; } = new SQLiteReader();

        /// <summary>
        /// The id of the connection.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// The title of the connection.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The base connection of the connection.
        /// </summary>
        public Connection BaseConnection { get; set; }

        /// <summary>
        /// The details of the connection.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// The status of the connection.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        ///  The date of last update of the connection.
        /// </summary>
        public string LastUpdated { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a connection with an empty id string.
        /// </summary>
        public Connection() : this("")
        {
        }

        /// <summary>
        /// Initializes a connection with the given id string.
        /// </summary>
        /// <param name="id">The id of the connection.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        public Connection(string id)
        {
            Logger.Trace($"Connection() angelegt");

            ID = id ?? throw new ArgumentNullException(nameof(id));

        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the connection from the database.
        /// </summary>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        /// <exception cref="NullReferenceException">Thrown when the id is null.</exception>
        public virtual int RetrieveBasicInformation()
        {
            if (String.IsNullOrEmpty(ID))
            {
                throw new NullReferenceException(nameof(ID));
            }

            Reader.Query = $"SELECT ID, Title, ConnectionID, Details, StatusID, LastUpdated " +
                           $"FROM Connection " +
                           $"WHERE ID=\"{ID}\"";

            if (1 == Reader.Retrieve())
            {
                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                Title = row["Title"].ToString();
                if (!String.IsNullOrEmpty(row["ConnectionID"].ToString()))
                {
                    BaseConnection = new Connection();
                    BaseConnection.ID = row["ConnectionID"].ToString();
                    BaseConnection.RetrieveBasicInformation();
                }
                Details = row["Details"].ToString();
                if (!String.IsNullOrEmpty(row["StatusID"].ToString()))
                {
                    Status = new Status();
                    Status.ID = row["StatusID"].ToString();
                    Status.RetrieveBasicInformation();
                }
                LastUpdated = row["LastUpdated"].ToString();
            }
            else
            {
                return 0;
            }

            return 1;
        }

        /// <summary>
        /// Retrieves the additional information of the connection from the database (none available).
        /// </summary>
        /// <returns>0</returns>
        public virtual int RetrieveAdditionalInformation()
        {
            // nothing to do
            return 0;
        }
    }
}
