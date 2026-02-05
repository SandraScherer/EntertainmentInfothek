// WikiPageCreator.exe: Creates pages for use with a wiki from the
// EntertainmentInfothek.db using EntertainmentDB.dll
// Copyright (C) 2026 Sandra Scherer

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


using System.Collections.Generic;

namespace WikiPageCreator.Export.Create
{
    /// <summary>
    /// Provides an interface for a page creator.
    /// </summary>    
    public interface IPageCreator
    {
        // --- Methods ---

        /// <summary>
        /// Returns the page name of the entrys page.
        /// </summary>
        /// <returns>The formatted page name for the entry.</returns>
        /// </summary>
        string GetPageName();

        /// <summary>
        /// Creates the complete formatted page of a given entry.
        /// </summary>
        /// <returns>The complete formatted page of the entry.</returns>
        List<string> CreatePage();
    }
}
