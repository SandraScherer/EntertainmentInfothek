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


using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides a certification.
    /// </summary>
    public class Certification : Entry
    {
        // --- Properties ---

        /// <summary>
        /// The name of the certification.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The image of the certification
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// The country of the certification.
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a certification with an empty id string.
        /// </summary>
        public Certification() : this("")
        {
        }

        /// <summary>
        ///  Initializes a certification with the given id string.
        /// </summary>
        /// <param name="id">The id of the certification.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        public Certification(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException(nameof(ID));
            }

            Logger.Trace($"Certification() angelegt");

            ID = id;
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the certification from the database.
        /// </summary>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        /// <exception cref="NullReferenceException">Thrown when the id is null.</exception>
        public override int RetrieveBasicInformation()
        {
            if (String.IsNullOrEmpty(ID))
            {
                throw new NullReferenceException(nameof(ID));
            }

            Reader.Query = $"SELECT ID, Name, ImageID, CountryID, Details, StatusID, LastUpdated " +
                           $"FROM Certification " +
                           $"WHERE ID=\"{ID}\"";

            if (1 == Reader.Retrieve())
            {
                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                Name = row["Name"].ToString();
                if (!String.IsNullOrEmpty(row["ImageID"].ToString()))
                {
                    Image = new Image();
                    Image.ID = row["ImageID"].ToString();
                    Image.RetrieveBasicInformation();
                }
                if (!String.IsNullOrEmpty(row["CountryID"].ToString()))
                {
                    Country = new Country();
                    Country.ID = row["CountryID"].ToString();
                    Country.RetrieveBasicInformation();
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
        /// Retrieves the additional information of the certification from the database (none available).
        /// </summary>
        /// <returns>0</returns>
        public override int RetrieveAdditionalInformation()
        {
            // nothing to do
            return 0;
        }
    }
}