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

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides an entry item.
    /// </summary>
    public abstract class EntryItem : Entry
    {
        // --- Properties ---

        /// <summary>
        /// The base table name of the entry item.
        /// </summary>
        public string BaseTableName { get; set; }

        /// <summary>
        /// The target table name of the entry item.
        /// </summary>
        public string TargetTableName { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructor ---

        /// <summary>
        /// Initializes an entry item with an emtpy id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the entry item information from the database.</param>
        protected EntryItem(DBReader reader) : this(reader, "", "", "")
        {
        }

        /// <summary>
        /// Initializes an entry item with the given id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the entry item information from the database.</param>
        /// <param name="id">The id of the entry item.</param>
        /// <param name="baseTableName">The base table name of the entry item.</param>
        /// <param name="targetTableName">The target table name of the entry item.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id or targetTableName is null.</exception>
        protected EntryItem(DBReader reader, string id, string baseTableName, string targetTableName) : base(reader, id)
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

            Logger.Trace($"EntryItem() angelegt");

            BaseTableName = baseTableName;
            TargetTableName = targetTableName;
        }

        // --- Methods ---

        // public static abstract int RetrieveList(...);
        // this is to be used as a reminder ;-)
    }
}
