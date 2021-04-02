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
using System.Text;

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides a cast person item.
    /// </summary>
    public class CastPersonItem : PersonItem
    {
        // --- Properties ---

        /// <summary>
        /// The actor of the cast person item.
        /// </summary>
        public Person Actor
        {
            get
            { return Person; }
            set
            { Person = value; }
        }

        /// <summary>
        /// The dubber of the cast person item.
        /// </summary>
        public Person Dubber { get; set; }

        /// <summary>
        /// The character of the cast person item.
        /// </summary>
        public string Character
        {
            get
            { return Role; }
            set
            { Role = value; }
        }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a cast person item with an empty id string.
        /// </summary>
        public CastPersonItem() : this("", "")
        {
        }

        /// <summary>
        /// Initializes a cast person item with the given id string.
        /// </summary>
        /// <param name="id">The id of the person item.</param>
        /// <param name="targetTableName">The target table name of the person item.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id or target table name is null.</exception>
        public CastPersonItem(string id, string targetTableName)
        {
            if (id == null)
            {
                throw new NullReferenceException(nameof(ID));
            }
            if (targetTableName == null)
            {
                throw new NullReferenceException(nameof(ID));
            }

            Logger.Trace($"CastPersonItem() angelegt");

            ID = id;
            TargetTableName = targetTableName;
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the person item from the database.
        /// </summary>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        /// <exception cref="NullReferenceException">Thrown when the id, base table name or target table name is null.</exception>
        public override int RetrieveBasicInformation()
        {
            if (String.IsNullOrEmpty(ID))
            {
                throw new NullReferenceException(nameof(ID));
            }
            if (String.IsNullOrEmpty(BaseTableName))
            {
                throw new NullReferenceException(nameof(BaseTableName));
            }
            if (String.IsNullOrEmpty(TargetTableName))
            {
                throw new NullReferenceException(nameof(TargetTableName));
            }

            Reader.Query = $"SELECT ID, ActorID, DubberID, Character, Details, StatusID, LastUpdated " +
                           $"FROM {BaseTableName}_{TargetTableName} " +
                           $"WHERE ID=\"{ID}\"";

            if (1 == Reader.Retrieve())
            {
                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                if (!String.IsNullOrEmpty(row["ActorID"].ToString()))
                {
                    Actor = new Person();
                    Actor.ID = row["ActorID"].ToString();
                    Actor.RetrieveBasicInformation();
                }
                if (!String.IsNullOrEmpty(row["DubberID"].ToString()))
                {
                    Dubber = new Person();
                    Dubber.ID = row["DubberID"].ToString();
                    Dubber.RetrieveBasicInformation();
                }
                Character = row["Character"].ToString();
                Details = row["Details"].ToString();
                if (!String.IsNullOrEmpty(row["StatusID"].ToString()))
                {
                    Status = new Status();
                    Status.ID = row["StatusID"].ToString();
                    Status.RetrieveBasicInformation();
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
        /// Retrieves the additional information of the person item from the database (none available).
        /// </summary>
        /// <returns>0</returns>
        public override int RetrieveAdditionalInformation()
        {
            // nothing to do

            return 0;
        }

        /// <summary>
        /// Retrieves a list of person items from the database.
        /// </summary>
        /// <param name="reader">The reader to be used to retrieve the data records.</param>
        /// <param name="baseTableName">The base table name of the person item.</param>
        /// <param name="baseTableID">The base table id of the person item.</param>
        /// <param name="targetTableName">The target table name of the person item.</param>
        /// <param name="order">The order in which the data records are to be sorted.</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">Thrown when the given reader is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the given base table name, base table id, target table name or order is null.</exception>
        public static new List<CastPersonItem> RetrieveList(DBReader reader, string baseTableName, string baseTableID, string targetTableName, string order = "ID")
        {
            if (reader == null)
            {
                throw new NullReferenceException(nameof(reader));
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

            List<CastPersonItem> list = new List<CastPersonItem>();

            if (reader.Retrieve() > 0)
            {
                list.Capacity = reader.Table.Rows.Count;

                foreach (DataRow row in reader.Table.Rows)
                {
                    CastPersonItem item = new CastPersonItem();
                    item.BaseTableName = baseTableName;
                    item.TargetTableName = targetTableName;

                    item.ID = row["ID"].ToString();
                    item.RetrieveBasicInformation();
                    list.Add(item);
                }
            }
            else
            {
                // nothing to do
            }

            return list;
        }
    }
}
