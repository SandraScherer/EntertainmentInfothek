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


using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides a country.
    /// </summary>
    public class Country : Entry
    {
        // --- Properties ---

        /// <summary>
        /// The original name of the country.
        /// </summary>
        public string OriginalName { get; set; }

        /// <summary>
        /// The english name of the country.
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// The german name of the country.
        /// </summary>
        public string GermanName { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a country with an empty id string.
        /// </summary>
        public Country() : this("")
        {
        }

        /// <summary>
        /// Initializes a country with the given id string.
        /// </summary>
        /// <param name="id">The id of the country.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        public Country(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Logger.Trace($"Country() angelegt");

            ID = id;
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the country from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        /// <exception cref="NullReferenceException">Thrown when the id is null.</exception>
        public override int RetrieveBasicInformation(bool retrieveBasicInfoOnly)
        {
            Reader.Query = $"SELECT ID, OriginalName, EnglishName, GermanName, Details, StatusID, LastUpdated " +
                           $"FROM Country " +
                           $"WHERE ID=\"{ID}\"";

            if (Reader.Retrieve(true) == 1)
            {
                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                OriginalName = row["OriginalName"].ToString();
                EnglishName = row["EnglishName"].ToString();
                GermanName = row["GermanName"].ToString();
                Details = row["Details"].ToString();
                if (!String.IsNullOrEmpty(row["StatusID"].ToString()))
                {
                    Status = new Status();
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
        /// Retrieves the additional information of the country from the database (none available).
        /// </summary>
        /// <returns>0</returns>
        public override int RetrieveAdditionalInformation()
        {
            // nothing to do
            return 0;

        }
    }
}
