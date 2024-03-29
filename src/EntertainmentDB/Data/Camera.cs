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


using EntertainmentDB.DBAccess.Read;
using System;
using System.Data;

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides a camera.
    /// </summary>
    public class Camera : Entry
    {
        // --- Properties ---

        /// <summary>
        /// The name of the camera.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The lense of the camera.
        /// </summary>
        public string Lenses { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a camera with an empty id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the camera information from the database.</param>
        public Camera(DBReader reader) : this(reader, "")
        {
        }

        /// <summary>
        /// Initializes a camera with the given id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the camera information from the database.</param>
        /// <param name="id">The id of the camera.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        public Camera(DBReader reader, string id) : base(reader, id)
        {
            Logger.Trace($"Camera(): Camera with ID = '{id}' created");
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the camera from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        protected override int RetrieveBasicInformation(bool retrieveBasicInfoOnly)
        {
            Logger.Trace($"Camera.RetrieveBasicInformation()");

            Reader.Query = $"SELECT ID, Name, Lenses, Details, StatusID, LastUpdated " +
                           $"FROM Camera " +
                           $"WHERE ID='{ID}'";

            Logger.Debug($"Retrieve from DB: {Reader.Query}");

            int noOfDataRecords = Reader.Retrieve(true);
            if (noOfDataRecords == 1)
            {
                Logger.Debug($"Retrieved data records: '{noOfDataRecords}'");

                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                Name = row["Name"].ToString();
                Lenses = row["Lenses"].ToString();
                Details = row["Details"].ToString();
                if (!String.IsNullOrEmpty(row["StatusID"].ToString()))
                {
                    Logger.Debug($"Camera.StatusID is not null -> retrieve");

                    Status = new Status(Reader.New());
                    Status.ID = row["StatusID"].ToString();
                    Status.Retrieve(retrieveBasicInfoOnly);
                }
                LastUpdated = row["LastUpdated"].ToString();
            }
            else
            {
                Logger.Debug($"Retrieved data records: '{noOfDataRecords}'");
                return 0;
            }

            return 1;
        }
    }
}
