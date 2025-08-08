// WikiPageCreator.exe: Creates pages for use with a wiki from the
// EntertainmentInfothek.db using EntertainmentDB.dll
// Copyright (C) 2025 Sandra Scherer

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

namespace WikiPageCreator.Export.Create
{
    /// <summary>
    /// Specifies constants that define possible paths.
    /// </summary>
    public enum Path
    {
        /// <summary>
        /// Path is biography.
        /// </summary>
        Biography,
        /// <summary>
        /// Path is company.
        /// </summary>
        Company,
        /// <summary>
        /// Path is date
        /// </summary>
        Date,
        /// <summary>
        /// Path is info.
        /// </summary>
        Info,
        /// <summary
        /// Path is navigation.
        /// </summary>
        Navigation
    }
}
