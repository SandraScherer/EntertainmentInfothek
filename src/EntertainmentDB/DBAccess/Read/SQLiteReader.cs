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
using System.Configuration;
using System.Data.SQLite;
using System.Text;

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
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a SQLite database reader.
        /// </summary>
        public SQLiteReader()
        {
            Logger.Trace($"SQLiteReader() angelegt");
        }

        // --- Methods ---

        /// <summary>
        /// Returns a new SQLiteReader. 
        /// </summary>
        /// <returns>A new SQLiteReader.</returns>
        public override DBReader New()
        {
            return new SQLiteReader();
        }

        /// <summary>
        /// Retrieves the information from the SQLite database.
        /// </summary>
        /// <returns>The number of data records retrieved.</returns>
        /// <exception cref="NullReferenceException">Thrown when the query/command text is null.</exception>
        public override int Retrieve(bool retrieveBasicInfoOnly)
        {
            string connectionString;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            }
            catch (ConfigurationErrorsException ex)
            {
                Logger.Error(ex, $"Angabe für ConnectionString \"Database\" fehlt in der Standard-Konfiguration der Anwendung");
                throw new ConfigurationErrorsException("ConnectionString in default configuration does not exist", ex);
            }

            SQLiteConnection connection;
            try
            {
                connection = new SQLiteConnection(connectionString);
                connection.Open();
            }
            catch (SQLiteException ex)
            {
                Logger.Error(ex, $"Datenbank-Verbindung kann nicht geöffnet werden");
                throw new SQLiteException("Opening database connection is not possible", ex);
            }
            catch (InvalidOperationException ex)
            {
                Logger.Error(ex, $"Datenbank-Verbindung ist bereits geöffnet");
                throw new InvalidOperationException("Database connection is already open", ex);
            }

            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(Query, connection);
            try
            {
                Table.Clear();
                dataAdapter.Fill(Table);
            }
            catch (InvalidOperationException ex)
            {
                Logger.Error(ex, $"Datenbank-Tabelle ist ungültig");
                throw new InvalidOperationException("Database table is invalid", ex);
            }
            finally
            {
                dataAdapter.Dispose();
                connection.Close();
            }

            return Table.Rows.Count;
        }
    }
}
