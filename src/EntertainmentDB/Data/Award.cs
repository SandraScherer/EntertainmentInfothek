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
using System.Data;

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides an award.
    /// </summary>
    public class Award : Entry
    {
        // --- Properties ---

        /// <summary>
        /// The name of the award.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The presenter of the award.
        /// </summary>
        public Company Presenter { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes an award with an empty id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the award information from the database.</param>
        public Award(DBReader reader) : this(reader, "")
        {
        }

        /// <summary>
        ///  Initializes an award with the given id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the award information from the database.</param>
        /// <param name="id">The id of the award.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        public Award(DBReader reader, string id) : base(reader, id)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Logger.Trace($"Award() angelegt");
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the award from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        public override int RetrieveBasicInformation(bool retrieveBasicInfoOnly)
        {
            Reader.Query = $"SELECT ID, Name, PresenterID, Details, StatusID, LastUpdated " +
                           $"FROM Award " +
                           $"WHERE ID=\"{ID}\"";

            if (Reader.Retrieve(true) == 1)
            {
                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                Name = row["Name"].ToString();
                if (!String.IsNullOrEmpty(row["PresenterID"].ToString()))
                {
                    Presenter = new Company(Reader.New());
                    Presenter.ID = row["PresenterID"].ToString();
                    Presenter.Retrieve(retrieveBasicInfoOnly);
                }
                Details = row["Details"].ToString();
                if (!String.IsNullOrEmpty(row["StatusID"].ToString()))
                {
                    Status = new Status(Reader.New());
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
        /// Retrieves the additional information of the award from the database (none available).
        /// </summary>
        /// <returns>0</returns>
        public override int RetrieveAdditionalInformation()
        {
            // nothing to do
            return 0;
        }
    }
}
