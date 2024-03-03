// WikiPageCreator.exe: Creates pages for use with a wiki from the
// EntertainmentInfothek.db using EntertainmentDB.dll
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
using System.IO;

namespace WikiPageCreator.Export.Write
{
    /// <summary>
    /// Provides a file writer.
    /// </summary>
    public class FileWriter
    {
        // --- Properties ---

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new file writer.
        /// </summary>
        public FileWriter()
        {
            Logger.Trace($"FileWriter() created");
        }

        // --- Methods ---

        public void WriteToFile(string directory, string filename, List<string> content)
        {
            Logger.Trace($"WriteToFile()");

            if (String.IsNullOrEmpty(directory))
            {
                Logger.Fatal($"Directory not specified");
                throw new ArgumentNullException(nameof(directory));
            }
            if (String.IsNullOrEmpty(filename))
            {
                Logger.Fatal($"Filename not specified");
                throw new ArgumentNullException(nameof(filename));
            }
            if (content == null)
            {
                Logger.Fatal($"Content not specified");
                throw new ArgumentNullException(nameof(content));
            }

            // if directory does not exist, create it
            if (!Directory.Exists(directory))
            {
                Logger.Debug($"Directory '{directory}' does not exist");

                try
                {
                    Directory.CreateDirectory(directory);
                    Logger.Debug($"Directory created");
                }
                catch (UnauthorizedAccessException ex)
                {
                    Logger.Fatal(ex, $"???");
                    throw;
                }
                catch (PathTooLongException ex)
                {
                    Logger.Fatal(ex, $"Path '{directory}' is too long");
                    throw;
                }
            }

            // create complete filename incl. path
            if (directory[^1] != Path.DirectorySeparatorChar)
            {
                directory += Path.DirectorySeparatorChar;
            }
            filename = directory + filename;

            Logger.Debug($"Path is '{filename}'");

            StreamWriter writer;

            // open file
            try
            {
                writer = new StreamWriter(filename, false);
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Fatal(ex, $"???");
                throw;
            }
            catch (PathTooLongException ex)
            {
                Logger.Fatal(ex, $"Path '{filename}' is too long");
                throw;
            }

            // write content
            foreach (String item in content)
            {
                if (item != null)
                    writer.WriteLine(item);
            }

            // close file
            writer.Close();

            Logger.Trace($"WriteToFile() done");
        }
    }
}
