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
using System.Collections.Generic;
using System.Data;

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides a camera item.
    /// </summary>
    public class CameraItem : EntryItem
    {
        // --- Properties ---

        /// <summary>
        /// The camera of the camera item.
        /// </summary>
        public Camera Camera { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a camera item with an empty id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the camera item information from the database.</param>
        public CameraItem(DBReader reader) : this(reader, "", "", "")
        {
        }

        /// <summary>
        /// Initializes a camera item with the given id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the camera item information from the database.</param>
        /// <param name="id">The id of the camera item.</param>
        /// <param name="baseTableName">The base table name of the camera item.</param>
        /// <param name="targetTableName">The target table name of the camera item.</param>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public CameraItem(DBReader reader, string id, string baseTableName, string targetTableName) : base(reader, id, baseTableName, targetTableName)
        {
            Logger.Trace($"CameraItem()");

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
            if (baseTableName == null)
            {
                Logger.Fatal($"BaseTableName not specified");
                throw new ArgumentNullException(nameof(baseTableName));
            }
            if (targetTableName == null)
            {
                Logger.Fatal($"TargetTableName not specified");
                throw new ArgumentNullException(nameof(targetTableName));
            }

            Logger.Trace($"CameraItem(): CameraItem with ID = '{id}' created");
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the camera item from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        protected override int RetrieveBasicInformation(bool retrieveBasicInfoOnly)
        {
            Logger.Trace($"CameraItem.RetrieveBasicInformation()");

            Reader.Query = $"SELECT ID, CameraID, Details, StatusID, LastUpdated " +
                           $"FROM {BaseTableName}_{TargetTableName} " +
                           $"WHERE ID='{ID}'";

            Logger.Info($"Retrieve from DB: {Reader.Query}");

            int noOfDataRecords = Reader.Retrieve(true);
            if (noOfDataRecords == 1)
            {
                Logger.Info($"Retrieved data records: '{noOfDataRecords}'");

                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                if (!String.IsNullOrEmpty(row["CameraID"].ToString()))
                {
                    Logger.Info($"CameraItem.CameraID is not null -> retrieve");

                    Camera = new Camera(Reader.New());
                    Camera.ID = row["CameraID"].ToString();
                    Camera.Retrieve(retrieveBasicInfoOnly);
                }
                Details = row["Details"].ToString();
                if (!String.IsNullOrEmpty(row["StatusID"].ToString()))
                {
                    Logger.Info($"CameraItem.StatusID is not null -> retrieve");

                    Status = new Status(Reader.New());
                    Status.ID = row["StatusID"].ToString();
                    Status.Retrieve(retrieveBasicInfoOnly);
                }
                LastUpdated = row["LastUpdated"].ToString();

                return 1;
            }
            else
            {
                Logger.Debug($"Retrieved data records: '{noOfDataRecords}'");
                return 0;
            }
        }

        /// <summary>
        /// Retrieves a list of camera items from the database.
        /// </summary>
        /// <param name="reader">The reader to be used to retrieve the data records.</param>
        /// <param name="baseTableName">The base table name of the camera item.</param>
        /// <param name="baseTableID">The base table id of the camera item.</param>
        /// <param name="targetTableName">The target table name of the camera item.</param>
        /// <param name="order">The order in which the data records are to be sorted.</param>
        /// <returns>The list of camera items.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public static List<CameraItem> RetrieveList(DBReader reader, string baseTableName, string baseTableID, string targetTableName, string order = "ID")
        {
            Logger.Trace($"CameraItem.RetrieveList()");

            if (reader == null)
            {
                Logger.Fatal($"DBReader not specified");
                throw new ArgumentNullException(nameof(reader));
            }
            if (String.IsNullOrEmpty(baseTableName))
            {
                Logger.Fatal($"BaseTableName not specified");
                throw new ArgumentNullException(nameof(baseTableName));
            }
            if (String.IsNullOrEmpty(baseTableID))
            {
                Logger.Fatal($"BaseTableID not specified");
                throw new ArgumentNullException(nameof(baseTableID));
            }
            if (String.IsNullOrEmpty(targetTableName))
            {
                Logger.Fatal($"TargetTableName not specified");
                throw new ArgumentNullException(nameof(targetTableName));
            }
            if (String.IsNullOrEmpty(order))
            {
                Logger.Fatal($"Order not specified");
                throw new ArgumentNullException(nameof(order));
            }

            // Liste laden

            reader.Query = $"SELECT ID " +
                           $"FROM {baseTableName}_{targetTableName} " +
                           $"WHERE {baseTableName}ID='{baseTableID}'" +
                           $"ORDER BY {order}";

            Logger.Info($"Retrieve from DB: {reader.Query}");

            List<CameraItem> list = new List<CameraItem>();

            int noOfDataRecords = reader.Retrieve(true);
            if (noOfDataRecords > 0)
            {
                Logger.Info($"Retrieved data records: '{noOfDataRecords}'");

                list.Capacity = reader.Table.Rows.Count;

                foreach (DataRow row in reader.Table.Rows)
                {
                    CameraItem item = new CameraItem(reader.New());
                    item.BaseTableName = baseTableName;
                    item.TargetTableName = targetTableName;

                    item.ID = row["ID"].ToString();
                    item.Retrieve(false);
                    list.Add(item);
                }
            }

            return list;
        }
    }
}
