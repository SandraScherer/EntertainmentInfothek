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
using System.Configuration;
using System.Data.SQLite;

namespace EntertainmentDB.DBAccess.Read
{
    /// <summary>
    /// Provides a SQLite database reader.
    /// </summary>
    public class SQLiteReader : DBReader
    {
        // --- Properties ---

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a SQLite database reader.
        /// </summary>
        public SQLiteReader()
        {
            Logger.Trace($"SQLiteReader(): SQLiteReader created");
        }

        // --- Methods ---

        /// <summary>
        /// Returns a new SQLiteReader. 
        /// </summary>
        /// <returns>A new SQLiteReader.</returns>
        public override DBReader New()
        {
            Logger.Trace($"SQLiteReader.New()");
            return new SQLiteReader();
        }

        /// <summary>
        /// Retrieves the information from the SQLite database.
        /// </summary>
        /// <returns>The number of data records retrieved.</returns>
        /// <exception cref="NullReferenceException">Thrown when the query/command text is null.</exception>
        public override int Retrieve(bool retrieveBasicInfoOnly)
        {
            Logger.Trace($"SQLiteReader.Retrieve()");

            string connectionString;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            }
            catch (ConfigurationErrorsException ex)
            {
                Logger.Error($"ConnectionString \"Database\" in default configuration does not exist");
                throw;
            }
            Logger.Debug($"ConnectionString to database from configuration: '{connectionString}'");

            SQLiteConnection connection;
            try
            {
                connection = new SQLiteConnection(connectionString);
                connection.Open();
                Logger.Debug($"Connection opened");
            }
            catch (SQLiteException ex)
            {
                Logger.Error($"Opening database connection is not possible");
                throw;
            }
            catch (InvalidOperationException ex)
            {
                Logger.Error($"Database connection is already open");
                throw;
            }

            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(Query, connection);
            try
            {
                Table.Clear();
                dataAdapter.Fill(Table);
                Logger.Debug($"Database table filled with data from database");
            }
            catch (InvalidOperationException ex)
            {
                Logger.Error($"Database table is invalid");
                throw;
            }
            finally
            {
                dataAdapter.Dispose();
                connection.Close();
                Logger.Debug($"Connection closed");
            }

            Logger.Debug($"Retrieved data records: '{Table.Rows.Count}'");
            return Table.Rows.Count;
        }
    }
}
