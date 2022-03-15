// WikiPageCreator.exe: Creates pages for use with a wiki from the
// EntertainmentInfothek.db using EntertainmentDB.dll
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


using EntertainmentDB.Data;
using System.Collections.Generic;
using WikiPageCreator.Export.Format;

namespace WikiPageCreator.Export.Create
{
    /// <summary>
    /// Provides an interface for a file content creator.
    /// </summary>
    public interface IFileContentCreatable
    {
        /// <summary>
        /// Creates the file name of a given entry.
        /// </summary>
        /// <param name="entry">The entry that is to be used to create the file name.</param>
        /// <param name="formatter">The formatter that is to be used to format the file name.</param>
        /// <returns>The formatted file name.</returns>
        string GetFileName(Entry entry, Formatter formatter);

        /// <summary>
        /// Creates the file content of a given entry.
        /// </summary>
        /// <param name="entry">The entry that is to be used to create the content.</param>
        /// <param name="targetLanguageCode">The language code of the target language.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <returns>The formatted content of the entry.</returns>
        List<string> CreateFileContent(Entry entry, string targetLanguageCode, Formatter formatter);
    }
}
