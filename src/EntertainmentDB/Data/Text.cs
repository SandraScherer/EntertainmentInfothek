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
    /// Provides a text.
    /// </summary>
    public class Text : Entry
    {
        // --- Properties ---

        /// <summary>
        /// The content of the text.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// The language of the text.
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        /// The list of authors of the text.
        /// </summary>
        public List<PersonItem> Authors { get; set; }

        /// <summary>
        /// The list of sources of the text.
        /// </summary>
        public List<CompanyItem> Sources { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a text with an empty id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the text information from the database.</param>
        public Text(DBReader reader) : this(reader, "")
        {
        }

        /// <summary>
        ///  Initializes a text with the given id string.
        /// </summary>
        /// <param name="reader">The database reader to be used to read the text information from the database.</param>
        /// <param name="id">The id of the text.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        public Text(DBReader reader, string id) : base(reader, id)
        {
            Logger.Trace($"Text()");
            if (reader == null)
            {
                Logger.Fatal($"DBReader not specified");
                throw new ArgumentNullException(nameof(reader));
            }
            if (id == null)
            {
                Logger.Fatal($"ID not specified");
                throw new ArgumentNullException(nameof(id));
            }

            Logger.Trace($"Text()Text with ID = '{id}' created");
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the text from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        protected override int RetrieveBasicInformation(bool retrieveBasicInfoOnly)
        {
            Logger.Trace($"Text.RetrieveBasicInformation()");

            Reader.Query = $"SELECT ID, Content, LanguageID, Details, StatusID, LastUpdated " +
                           $"FROM Text " +
                           $"WHERE ID='{ID}'";

            Logger.Info($"Retrieve from DB: {Reader.Query}");

            int noOfDataRecords = Reader.Retrieve(true);
            if (noOfDataRecords == 1)
            {
                Logger.Info($"Retrieved data records: '{noOfDataRecords}'");

                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                Content = row["Content"].ToString();
                if (!String.IsNullOrEmpty(row["LanguageID"].ToString()))
                {
                    Logger.Info($"Text.LanguageID is not null -> retrieve");

                    Language = new Language(Reader.New());
                    Language.ID = row["LanguageID"].ToString();
                    Language.Retrieve(retrieveBasicInfoOnly);
                }
                Details = row["Details"].ToString();
                if (!String.IsNullOrEmpty(row["StatusID"].ToString()))
                {
                    Logger.Info($"Text.StatusID is not null -> retrieve");

                    Status = new Status(Reader.New());
                    Status.ID = row["StatusID"].ToString();
                    Status.Retrieve(retrieveBasicInfoOnly);
                }
                LastUpdated = row["LastUpdated"].ToString();
            }
            else
            {
                Logger.Debug($"Retrieved data records: '{noOfDataRecords}'");
                return 0;
            }

            return 1;
        }

        /// <summary>
        /// Retrieves the additional information of the text from the database (none available).
        /// </summary>
        /// <returns>The number of data records retrieved.</returns>
        protected override int RetrieveAdditionalInformation()
        {
            Logger.Trace($"Text.RetrieveAdditionalInformation()");

            int noOfDataRecords = 0;

            Authors = PersonItem.RetrieveList(Reader, "Text", ID, "Author");
            noOfDataRecords += Authors.Count;
            if (Authors.Count == 0)
            {
                Logger.Info($"Text.Authors.Count == 0 -> null");
                Authors = null;
            }

            Sources = CompanyItem.RetrieveList(Reader, "Text", ID, "Source");
            noOfDataRecords += Sources.Count;
            if (Sources.Count == 0)
            {
                Logger.Info($"Text.Sources.Count == 0 -> null");
                Sources = null;
            }

            Logger.Info($"Retrieved data records: '{noOfDataRecords}'");
            return noOfDataRecords;
        }
    }
}
