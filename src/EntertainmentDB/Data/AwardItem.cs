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
    /// Provides an award item.
    /// </summary>
    public class AwardItem : EntryItem
    {
        // --- Properties ---

        /// <summary>
        /// The award of the award item.
        /// </summary>
        public Award Award { get; set; }

        /// <summary>
        /// The category of the award item.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// The date of the award item.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// The winner info of the award item.
        /// </summary>
        public string Winner { get; set; }

        /// <summary>
        /// The list of persons of the award item.
        /// </summary>
        public List<PersonItem> Persons { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes an award item with an empty id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the award item information from the database.</param>
        public AwardItem(DBReader reader) : this(reader, "", "", "")
        {
        }

        /// <summary>
        /// Initializes an award item with the given id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the award item information from the database.</param>
        /// <param name="id">The id of the award item.</param>
        /// <param name="baseTableName">The base table name of the aspect ratio item.</param>
        /// <param name="targetTableName">The target table name of the award item.</param>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public AwardItem(DBReader reader, string id, string baseTableName, string targetTableName) : base(reader, id, baseTableName, targetTableName)
        {
            Logger.Trace($"AwardItem(): AwardItem with ID = '{id}' created");
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the award item from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        protected override int RetrieveBasicInformation(bool retrieveBasicInfoOnly)
        {
            Logger.Trace($"AwardItem.RetrieveBasicInformation()");

            Reader.Query = $"SELECT ID, AwardID, Category, Date, Winner, Details, StatusID, LastUpdated " +
                           $"FROM {BaseTableName}_{TargetTableName} " +
                           $"WHERE ID='{ID}'";

            Logger.Debug($"Retrieve from DB: {Reader.Query}");

            int noOfDataRecords = Reader.Retrieve(true);
            if (noOfDataRecords == 1)
            {
                Logger.Debug($"Retrieved data records: '{noOfDataRecords}'");

                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                if (!String.IsNullOrEmpty(row["AwardID"].ToString()))
                {
                    Logger.Debug($"AwardItem.AwardID is not null -> retrieve");

                    Award = new Award(Reader.New());
                    Award.ID = row["AwardID"].ToString();
                    Award.Retrieve(retrieveBasicInfoOnly);
                }
                Category = row["Category"].ToString();
                Date = row["Date"].ToString();
                Winner = row["Winner"].ToString();
                Details = row["Details"].ToString();
                if (!String.IsNullOrEmpty(row["StatusID"].ToString()))
                {
                    Logger.Debug($"AwardItem.StatusID is not null -> retrieve");

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
        /// Retrieves the additional information of the award item from the database.
        /// </summary>
        /// <returns>The number of data records retrieved.</returns>
        protected override int RetrieveAdditionalInformation()
        {
            Logger.Trace($"AwardItem.RetrieveAdditionalInformation()");

            int noOfDataRecords = 0;

            Persons = PersonItem.RetrieveList(Reader, $"Movie_Award", ID, "Person");
            noOfDataRecords += Persons.Count;
            if (Persons.Count == 0)
            {
                Logger.Debug($"AwardItem.Persons.Count == 0 -> null");
                Persons = null;
            }

            return noOfDataRecords;
        }

        /// <summary>
        /// Retrieves a list of award items from the database.
        /// </summary>
        /// <param name="reader">The reader to be used to retrieve the data records.</param>
        /// <param name="baseTableName">The base table name of the aspect ratio item.</param>
        /// <param name="baseTableID">The base table id of the award item.</param>
        /// <param name="targetTableName">The target table name of the award item.</param>
        /// <param name="order">The order in which the data records are to be sorted.</param>
        /// <returns>The list of award items.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public static List<AwardItem> RetrieveList(DBReader reader, string baseTableName, string baseTableID, string targetTableName, string order = "ID")
        {
            Logger.Trace($"AwardItem.RetrieveList()");

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

            Logger.Debug($"Retrieve from DB: {reader.Query}");

            List<AwardItem> list = new List<AwardItem>();

            int noOfDataRecords = reader.Retrieve(true);
            if (noOfDataRecords > 0)
            {
                Logger.Debug($"Retrieved data records: '{noOfDataRecords}'");

                list.Capacity = reader.Table.Rows.Count;

                foreach (DataRow row in reader.Table.Rows)
                {
                    AwardItem item = new AwardItem(reader.New());
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
