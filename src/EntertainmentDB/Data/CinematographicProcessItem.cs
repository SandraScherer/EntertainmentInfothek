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
using System.Collections.Generic;
using System.Data;

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides a cinematographic process item.
    /// </summary>
    public class CinematographicProcessItem : EntryItem
    {
        // --- Properties ---

        /// <summary>
        /// The cinematographic process of the cinematographic process item.
        /// </summary>
        public CinematographicProcess CinematographicProcess { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a cinematographic process item with an empty id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the cinematographic process item information from the database.</param>
        public CinematographicProcessItem(DBReader reader) : this(reader, "", "", "")
        {
        }

        /// <summary>
        /// Initializes a cinematographic process item with the given id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the cinematographic process item information from the database.</param>
        /// <param name="id">The id of the cinematographic process item.</param>
        /// <param name="baseTableName">The base table name of the cinematographic process item.</param>
        /// <param name="targetTableName">The target table name of the cinematographic process item.</param>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public CinematographicProcessItem(DBReader reader, string id, string baseTableName, string targetTableName) : base(reader, id, baseTableName, targetTableName)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (baseTableName == null)
            {
                throw new ArgumentNullException(nameof(baseTableName));
            }
            if (targetTableName == null)
            {
                throw new ArgumentNullException(nameof(targetTableName));
            }

            Logger.Trace($"CinematographicProcessItem() angelegt");
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the cinematographic process item from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        public override int RetrieveBasicInformation(bool retrieveBasicInfoOnly)
        {
            Reader.Query = $"SELECT ID, CinematographicProcessID, Details, StatusID, LastUpdated " +
                           $"FROM {BaseTableName}_{TargetTableName} " +
                           $"WHERE ID=\"{ID}\"";

            if (Reader.Retrieve(true) == 1)
            {
                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                if (!String.IsNullOrEmpty(row["CinematographicProcessID"].ToString()))
                {
                    CinematographicProcess = new CinematographicProcess(Reader.New());
                    CinematographicProcess.ID = row["CinematographicProcessID"].ToString();
                    CinematographicProcess.Retrieve(retrieveBasicInfoOnly);
                }
                Details = row["Details"].ToString();
                if (!String.IsNullOrEmpty(row["StatusID"].ToString()))
                {
                    Status = new Status(Reader.New());
                    Status.ID = row["StatusID"].ToString();
                    Status.Retrieve(retrieveBasicInfoOnly);
                }
                LastUpdated = row["LastUpdated"].ToString();

                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Retrieves the additional information of the cinematographic process item from the database (none available).
        /// </summary>
        /// <returns>0</returns>
        public override int RetrieveAdditionalInformation()
        {
            // nothing to do
            return 0;
        }

        /// <summary>
        /// Retrieves a list of cinematographic process items from the database.
        /// </summary>
        /// <param name="reader">The reader to be used to retrieve the data records.</param>
        /// <param name="baseTableName">The base table name of the cinematographic process item.</param>
        /// <param name="baseTableID">The base table id of the cinematographic process item.</param>
        /// <param name="targetTableName">The target table name of the cinematographic process item.</param>
        /// <param name="order">The order in which the data records are to be sorted.</param>
        /// <returns>The list of cinematographic process items.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public static List<CinematographicProcessItem> RetrieveList(DBReader reader, string baseTableName, string baseTableID, string targetTableName, string order = "ID")
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }
            if (String.IsNullOrEmpty(baseTableName))
            {
                throw new ArgumentNullException(nameof(baseTableName));
            }
            if (String.IsNullOrEmpty(baseTableID))
            {
                throw new ArgumentNullException(nameof(baseTableID));
            }
            if (String.IsNullOrEmpty(targetTableName))
            {
                throw new ArgumentNullException(nameof(targetTableName));
            }
            if (String.IsNullOrEmpty(order))
            {
                throw new ArgumentNullException(nameof(order));
            }

            // Liste laden

            reader.Query = $"SELECT ID " +
                           $"FROM {baseTableName}_{targetTableName} " +
                           $"WHERE {baseTableName}ID=\"{baseTableID}\"" +
                           $"ORDER BY {order}";

            List<CinematographicProcessItem> list = new List<CinematographicProcessItem>();

            if (reader.Retrieve(true) > 0)
            {
                list.Capacity = reader.Table.Rows.Count;

                foreach (DataRow row in reader.Table.Rows)
                {
                    CinematographicProcessItem item = new CinematographicProcessItem(reader.New());
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
