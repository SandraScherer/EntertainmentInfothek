﻿// EntertainmentDB.dll: Provides access to the EntertainmentInfothek.db
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
using System.Data;
using System.Text;

namespace EntertainmentDB.Data
{
    /// <summary>
    /// Provides a person.
    /// </summary>
    public class Person : Entry
    {
        // --- Properties ---

        /// <summary>
        /// The first (and middle) name of the person.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the person.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The name addon of the person.
        /// </summary>
        public string NameAddOn { get; set; }

        /// <summary>
        /// The birth name of the person.
        /// </summary>
        public string BirthName { get; set; }

        /// <summary>
        /// The birth date of the person.
        /// </summary>
        public string DateOfBirth { get; set; }

        /// <summary>
        /// The death date of the person.
        /// </summary>
        public string DateOfDeath { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a person with an empty id string.
        /// </summary>
        public Person() : this("")
        {
        }

        /// <summary>
        /// Initializes a person with the given id string.
        /// </summary>
        /// <param name="id">The id of the person.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        public Person(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException(nameof(ID));
            }

            Logger.Trace($"Person() angelegt");

            ID = id;
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the person from the database.
        /// </summary>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        /// <exception cref="NullReferenceException">Thrown when the id is null.</exception>
        public override int RetrieveBasicInformation()
        {
            if (String.IsNullOrEmpty(ID))
            {
                throw new NullReferenceException(nameof(ID));
            }

            Reader.Query = $"SELECT ID, FirstName, LastName, NameAddOn, BirthName, DateOfBirth, DateOfDeath, Details, StatusID, LastUpdated " +
                           $"FROM Person " +
                           $"WHERE ID=\"{ID}\"";

            if (1 == Reader.Retrieve())
            {
                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                FirstName = row["FirstName"].ToString();
                LastName = row["LastName"].ToString();
                NameAddOn = row["NameAddOn"].ToString();
                BirthName = row["BirthName"].ToString();
                DateOfBirth = row["DateOfBirth"].ToString();
                DateOfDeath = row["DateOfDeath"].ToString();
                Details = row["Details"].ToString();
                if (!String.IsNullOrEmpty(row["StatusID"].ToString()))
                {
                    Status = new Status();
                    Status.ID = row["StatusID"].ToString();
                    Status.RetrieveBasicInformation();
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
        /// Retrieves the additional information of the person from the database (none available).
        /// </summary>
        /// <returns>0</returns>
        public override int RetrieveAdditionalInformation()
        {
            // nothing to do
            return 0;
        }
    }
}
