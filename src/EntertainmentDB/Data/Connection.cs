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
using System.Data;

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides a connection.
    /// </summary>
    public class Connection : Entry
    {
        // --- Properties ---

        /// <summary>
        /// The title of the connection.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The base connection of the connection.
        /// </summary>
        public Connection BaseConnection { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a connection with an empty id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the connection information from the database.</param>
        public Connection(DBReader reader) : this(reader, "")
        {
        }

        /// <summary>
        /// Initializes a connection with the given id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the connection information from the database.</param>
        /// <param name="id">The id of the connection.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        public Connection(DBReader reader, string id) : base(reader, id)
        {
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

            Logger.Trace($"Connection() with ID = '{id}' created");
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the connection from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        protected override int RetrieveBasicInformation(bool retrieveBasicInfoOnly)
        {
            Reader.Query = $"SELECT ID, Title, ConnectionID, Details, StatusID, LastUpdated " +
                           $"FROM Connection " +
                           $"WHERE ID=\"{ID}\"";

            if (Reader.Retrieve(true) == 1)
            {
                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                Title = row["Title"].ToString();
                if (!String.IsNullOrEmpty(row["ConnectionID"].ToString()))
                {
                    BaseConnection = new Connection(Reader.New());
                    BaseConnection.ID = row["ConnectionID"].ToString();
                    BaseConnection.Retrieve(retrieveBasicInfoOnly);
                }
                Details = row["Details"].ToString();
                if (!String.IsNullOrEmpty(row["StatusID"].ToString()))
                {
                    Status = new Status(Reader.New());
                    Status.ID = row["StatusID"].ToString();
                    Status.Retrieve(retrieveBasicInfoOnly);
                }
                LastUpdated = row["LastUpdated"].ToString();
            }
            else
            {
                return 0;
            }

            return 1;
        }
    }
}
