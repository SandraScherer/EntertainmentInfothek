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
    /// Provides a weblink.
    /// </summary>
    public class Weblink : Entry
    {
        // --- Properties ---

        /// <summary>
        /// The URL of the weblink.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The english title of the weblink.
        /// </summary>
        public string EnglishTitle { get; set; }

        /// <summary>
        /// The german title of the weblink.
        /// </summary>
        public string GermanTitle { get; set; }

        /// <summary>
        /// The language of the weblink.
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a weblink with an empty id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the weblink information from the database.</param>
        public Weblink(DBReader reader) : this(reader, "")
        {
        }

        /// <summary>
        /// Initializes a weblink with the given id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the weblink information from the database.</param>
        /// <param name="id">The id of the weblink.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        public Weblink(DBReader reader, string id) : base(reader, id)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Logger.Trace($"Weblink() angelegt");
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the weblink from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        protected override int RetrieveBasicInformation(bool retrieveBasicInfoOnly)
        {
            Reader.Query = $"SELECT ID, URL, EnglishTitle, GermanTitle, LanguageID, Details, StatusID, LastUpdated " +
               $"FROM Weblink " +
               $"WHERE ID=\"{ID}\"";

            if (Reader.Retrieve(true) == 1)
            {
                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                Url = row["URL"].ToString();
                EnglishTitle = row["EnglishTitle"].ToString();
                GermanTitle = row["GermanTitle"].ToString();
                if (!String.IsNullOrEmpty(row["LanguageID"].ToString()))
                {
                    Language = new Language(Reader.New());
                    Language.ID = row["LanguageID"].ToString();
                    Language.Retrieve(retrieveBasicInfoOnly);
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
    }
}
