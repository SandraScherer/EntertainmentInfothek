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

namespace EntertainmentDB.DBAccess.Read
{
    /// <summary>
    /// Provides an interface for a database reader.
    /// </summary>
    public interface IDBReadable
    {
        // --- Methods ---

        /// <summary>
        /// Retrieves the information from the database.
        /// </summary>
        /// <returns>The number of data records retrieved.</returns>
        int Retrieve(bool retrieveBasicInfoOnly);
    }
}
