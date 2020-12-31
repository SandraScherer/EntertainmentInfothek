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


using System;
using System.Collections.Generic;
using System.Text;

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides an entry item.
    /// </summary>
    public abstract class EntryItem : Entry
    {
        // --- Properties ---

        /// <summary>
        /// The base table name of the entry.
        /// </summary>
        public string BaseTableName { get; set; } = "";

        /// <summary>
        /// The target table name of the entry.
        /// </summary>
        public string TargetTableName { get; set; } = "";

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructor ---

        /// <summary>
        /// Initializes an entry item with an emtpy id string.
        /// </summary>
        public EntryItem() : this("")
        {
        }

        /// <summary>
        /// Initializes an entry item with the given id string.
        /// </summary>
        /// <param name="id"></param>
        public EntryItem(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException(nameof(ID));
            }

            Logger.Trace($"Entry() angelegt");

            ID = id;
        }

        // --- Methods ---

        // public static abstract int RetrieveList(...);
        // this is to be used as a reminder ;-)
    }
}
