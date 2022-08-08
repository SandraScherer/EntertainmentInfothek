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
    /// Provides a country.
    /// </summary>
    public class Country : Entry
    {
        // --- Properties ---

        /// <summary>
        /// The original short name of the country.
        /// </summary>
        public string OriginalShortName { get; set; }

        /// <summary>
        /// The original full name of the country.
        /// </summary>
        public string OriginalFullName { get; set; }

        /// <summary>
        /// The english short name of the country.
        /// </summary>
        public string EnglishShortName { get; set; }

        /// <summary>
        /// The english full name of the country.
        /// </summary>
        public string EnglishFullName { get; set; }

        /// <summary>
        /// The german short name of the country.
        /// </summary>
        public string GermanShortName { get; set; }

        /// <summary>
        /// The german full name of the country.
        /// </summary>
        public string GermanFullName { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a country with an empty id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the country information from the database.</param>
        public Country(DBReader reader) : this(reader, "")
        {
        }

        /// <summary>
        /// Initializes a country with the given id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the country information from the database.</param>
        /// <param name="id">The id of the country.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        public Country(DBReader reader, string id) : base(reader, id)
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

            Logger.Trace($"Country() with ID = '{id}' created");
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the country from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        protected override int RetrieveBasicInformation(bool retrieveBasicInfoOnly)
        {
            Reader.Query = $"SELECT ID, OriginalShortName, OriginalFullName, EnglishShortName, EnglishFullName, GermanShortName, GermanFullName, Details, StatusID, LastUpdated " +
                           $"FROM Country " +
                           $"WHERE ID=\"{ID}\"";

            if (Reader.Retrieve(true) == 1)
            {
                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                OriginalShortName = row["OriginalShortName"].ToString();
                OriginalFullName = row["OriginalFullName"].ToString();
                EnglishShortName = row["EnglishShortName"].ToString();
                EnglishFullName = row["EnglishFullName"].ToString();
                GermanShortName = row["GermanShortName"].ToString();
                GermanFullName = row["GermanFullName"].ToString();
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
