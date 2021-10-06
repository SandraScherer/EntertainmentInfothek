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
using System.Text;

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
        /// The year of the award item.
        /// </summary>
        public string Year { get; set; }

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
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes an award item with an empty id string.
        /// </summary>
        public AwardItem() : this("")
        {
        }

        /// <summary>
        /// Initializes an award item with the given id string.
        /// </summary>
        /// <param name="id">The id of the award item.</param>
        /// <param name="targetTableName">The target table name of the award item.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id or target table name is null.</exception>
        public AwardItem(string id, string targetTableName = "Award")
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (String.IsNullOrEmpty(targetTableName))
            {
                throw new ArgumentNullException(nameof(targetTableName));
            }

            Logger.Trace($"AwardItem() angelegt");

            ID = id;
            TargetTableName = targetTableName;
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the award item from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        /// <exception cref="NullReferenceException">Thrown when the id, base table name or target table name is null.</exception>
        public override int RetrieveBasicInformation(bool retrieveBasicInfoOnly)
        {
            Reader.Query = $"SELECT ID, AwardID, Category, Year, Winner, Details, StatusID, LastUpdated " +
                           $"FROM {BaseTableName}_{TargetTableName} " +
                           $"WHERE ID=\"{ID}\"";

            if (Reader.Retrieve(true) == 1)
            {
                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                if (!String.IsNullOrEmpty(row["AwardID"].ToString()))
                {
                    Award = new Award();
                    Award.ID = row["AwardID"].ToString();
                    Award.Retrieve(retrieveBasicInfoOnly);
                }
                Category = row["Category"].ToString();
                Year = row["Year"].ToString();
                Winner = row["Winner"].ToString();
                Details = row["Details"].ToString();
                if (!String.IsNullOrEmpty(row["StatusID"].ToString()))
                {
                    Status = new Status();
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
        /// Retrieves the additional information of the award item from the database.
        /// </summary>
        /// <returns>The number of data records retrieved.</returns>
        /// <exception cref="NullReferenceException">Thrown when the reader or id is null.</exception>
        public override int RetrieveAdditionalInformation()
        {
            int count = 0;

            Persons = PersonItem.RetrieveList(Reader, $"Movie_Award", ID, "Person");
            if (Persons != null)
            {
                count += Persons.Count;
            }

            return count;
        }

        /// <summary>
        /// Retrieves a list of award items from the database.
        /// </summary>
        /// <param name="reader">The reader to be used to retrieve the data records.</param>
        /// <param name="baseTableName">The base table name of the aspect ratio item.</param>
        /// <param name="baseTableID">The base table id of the award item.</param>
        /// <param name="targetTableName">The target table name of the award item.</param>
        /// <param name="order">The order in which the data records are to be sorted.</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">Thrown when the given reader is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the given base table name, base table id, target table name or order is null.</exception>
        public static List<AwardItem> RetrieveList(DBReader reader, string baseTableName, string baseTableID, string targetTableName = "Award", string order = "ID")
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

            List<AwardItem> list = new List<AwardItem>();

            if (reader.Retrieve(true) > 0)
            {
                list.Capacity = reader.Table.Rows.Count;

                foreach (DataRow row in reader.Table.Rows)
                {
                    AwardItem item = new AwardItem();
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
