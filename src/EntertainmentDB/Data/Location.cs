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
using System.Data;

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides a location.
    /// </summary>
    public class Location : Entry
    {
        // --- Properties ---

        /// <summary>
        /// The location of the location.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The country of the location.
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a location with an empty id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the location information from the database.</param>
        public Location(DBReader reader) : this(reader, "")
        {
        }

        /// <summary>
        ///  Initializes a location with the given id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the location information from the database.</param>
        /// <param name="id">The id of the location.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        public Location(DBReader reader, string id) : base(reader, id)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Logger.Trace($"Location() angelegt");
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the location from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        public override int RetrieveBasicInformation(bool retrieveBasicInfoOnly)
        {
            Reader.Query = $"SELECT ID, Location, CountryID, Details, StatusID, LastUpdated " +
                           $"FROM Location " +
                           $"WHERE ID=\"{ID}\"";

            if (Reader.Retrieve(true) == 1)
            {
                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                Name = row["Location"].ToString();
                if (!String.IsNullOrEmpty(row["CountryID"].ToString()))
                {
                    Country = new Country(Reader.New());
                    Country.ID = row["CountryID"].ToString();
                    Country.Retrieve(retrieveBasicInfoOnly);
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

        /// <summary>
        /// Retrieves the additional information of the aspect ratio from the database (none available).
        /// </summary>
        /// <returns>0</returns>
        public override int RetrieveAdditionalInformation()
        {
            // nothing to do
            return 0;
        }
    }
}
