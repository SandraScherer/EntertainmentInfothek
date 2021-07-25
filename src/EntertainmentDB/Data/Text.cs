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


using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a text with an empty id string.
        /// </summary>
        public Text() : this("")
        {
        }

        /// <summary>
        ///  Initializes a text with the given id string.
        /// </summary>
        /// <param name="id">The id of the text.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given id is null.</exception>
        public Text(string id)
        {
            if (id == null)
            {
                throw new NullReferenceException(nameof(ID));
            }

            Logger.Trace($"Text() angelegt");

            ID = id;
        }

        // --- Methods ---

        /// <summary>
        /// Retrieves the basic information of the text from the database.
        /// </summary>
        /// <param name="retrieveBasicInfoOnly">true if only the basic info is to be retrieved; false if also additional data is to be retrieved.</param>
        /// <returns>1 if data record was retrieved; 0 if no data record matched the id.</returns>
        /// <exception cref="NullReferenceException">Thrown when the id is null.</exception>
        public override int RetrieveBasicInformation(bool retrieveBasicInfoOnly)
        {
            if (String.IsNullOrEmpty(ID))
            {
                throw new NullReferenceException(nameof(ID));
            }

            Reader.Query = $"SELECT ID, Content, LanguageID, Details, StatusID, LastUpdated " +
                           $"FROM Text " +
                           $"WHERE ID=\"{ID}\"";

            if (Reader.Retrieve() == 1)
            {
                DataRow row = Reader.Table.Rows[0];

                ID = row["ID"].ToString();
                Content = row["Content"].ToString();
                if (!String.IsNullOrEmpty(row["LanguageID"].ToString()))
                {
                    Language = new Language();
                    Language.ID = row["LanguageID"].ToString();
                    Language.Retrieve(retrieveBasicInfoOnly);
                }
                Details = row["Details"].ToString();
                if (!String.IsNullOrEmpty(row["StatusID"].ToString()))
                {
                    Status = new Status();
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
        /// Retrieves the additional information of the text from the database (none available).
        /// </summary>
        /// <returns>The number of data records retrieved.</returns>
        /// <exception cref="NullReferenceException">Thrown when the reader or id is null.</exception>
        public override int RetrieveAdditionalInformation()
        {
            if (Reader == null)
            {
                throw new NullReferenceException(nameof(Reader));
            }
            if (String.IsNullOrEmpty(ID))
            {
                throw new NullReferenceException(nameof(ID));
            }

            int count = 0;

            Authors = PersonItem.RetrieveList(Reader, $"Text", ID, "Author");
            if (Authors != null)
            {
                count += Authors.Count;
            }
            Sources = CompanyItem.RetrieveList(Reader, $"Text", ID, "Source");
            if (Sources != null)
            {
                count += Sources.Count;
            }

            return count;
        }
    }
}
