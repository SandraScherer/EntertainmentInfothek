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
using System.Collections.Generic;
using System.Data;

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides a color item.
    /// </summary>
    public class ColorItem : EntryItem
    {
        // --- Properties ---

        /// <summary>
        /// The color of the color item.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a color item with an empty id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the color item information from the database.</param>
        public ColorItem(DBReader reader) : this(reader, "", "", "")
        {
        }

        /// <summary>
        /// Initializes a color item with the given id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the color item information from the database.</param>
        /// <param name="id">The id of the color item.</param>
        /// <param name="baseTableName">The base table name of the color item.</param>
        /// <param name="targetTableName">The target table name of the color item.</param>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public ColorItem(DBReader reader, string id, string baseTableName, string targetTableName) : base(reader, id, baseTableName, targetTableName)
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

            Logger.Trace($"ColorItem() angelegt");
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the color item from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        public override int RetrieveBasicInformation(bool retrieveBasicInfoOnly)
        {
            Reader.Query = $"SELECT ID, ColorID, Details, StatusID, LastUpdated " +
                           $"FROM {BaseTableName}_{TargetTableName} " +
                           $"WHERE ID=\"{ID}\"";

            if (Reader.Retrieve(true) == 1)
            {
                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                if (!String.IsNullOrEmpty(row["ColorID"].ToString()))
                {
                    Color = new Color(Reader.New());
                    Color.ID = row["ColorID"].ToString();
                    Color.Retrieve(retrieveBasicInfoOnly);
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
        /// Retrieves the additional information of the color item from the database (none available).
        /// </summary>
        /// <returns>0</returns>
        public override int RetrieveAdditionalInformation()
        {
            // nothing to do
            return 0;
        }

        /// <summary>
        /// Retrieves a list of color items from the database.
        /// </summary>
        /// <param name="reader">The reader to be used to retrieve the data records.</param>
        /// <param name="baseTableName">The base table name of the color item.</param>
        /// <param name="baseTableID">The base table id of the color item.</param>
        /// <param name="targetTableName">The target table name of the color item.</param>
        /// <param name="order">The order in which the data records are to be sorted.</param>
        /// <returns>The list of color items.</returns>
        /// <exception cref="ArgumentNullException">Thrown when any of the given parameters is null.</exception>
        public static List<ColorItem> RetrieveList(DBReader reader, string baseTableName, string baseTableID, string targetTableName, string order = "ID")
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

            List<ColorItem> list = new List<ColorItem>();

            if (reader.Retrieve(true) > 0)
            {
                list.Capacity = reader.Table.Rows.Count;

                foreach (DataRow row in reader.Table.Rows)
                {
                    ColorItem item = new ColorItem(reader.New());
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
