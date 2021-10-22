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


using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides an image.
    /// </summary>
    public class Image : Entry
    {
        // --- Properties ---

        /// <summary>
        /// The file name of the image.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The description of the image.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The type of the image.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// The country of origin of the image.
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// The list of sources of the image.
        /// </summary>
        public List<CompanyItem> Sources { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes an image with an empty id string.
        /// </summary>
        public Image() : this("")
        {
        }

        /// <summary>
        /// Initializes an image with the given id string.
        /// </summary>
        /// <param name="id">The id of the image.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        public Image(string id) : base(id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Logger.Trace($"Image() angelegt");
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the image from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        /// <exception cref="NullReferenceException">Thrown when the id is null.</exception>
        public override int RetrieveBasicInformation(bool retrieveBasicInfoOnly)
        {
            Reader.Query = $"SELECT ID, FileName, Description, TypeID, CountryID, Details, StatusID, LastUpdated " +
                           $"FROM Image " +
                           $"WHERE ID=\"{ID}\"";

            if (Reader.Retrieve(true) == 1)
            {
                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                FileName = row["FileName"].ToString();
                Description = row["Description"].ToString();
                if (!String.IsNullOrEmpty(row["TypeID"].ToString()))
                {
                    Type = new Type();
                    Type.ID = row["TypeID"].ToString();
                    Type.Retrieve(retrieveBasicInfoOnly);
                }
                if (!String.IsNullOrEmpty(row["CountryID"].ToString()))
                {
                    Country = new Country();
                    Country.ID = row["CountryID"].ToString();
                    Country.Retrieve(retrieveBasicInfoOnly);
                }
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
        /// Retrieves the additional information of the image from the database (none available).
        /// </summary>
        /// <returns>The number of data records retrieved.</returns>
        /// <exception cref="NullReferenceException">Thrown when the reader or id is null.</exception>
        public override int RetrieveAdditionalInformation()
        {
            int count = 0;

            Sources = CompanyItem.RetrieveList(Reader, $"Image", ID, "Source");
            count += Sources.Count;

            return count;
        }
    }
}
