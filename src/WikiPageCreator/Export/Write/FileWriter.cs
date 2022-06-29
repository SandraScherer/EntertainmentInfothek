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
using System.Text;

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
            Logger.Trace($"FileWriter() angelegt");
        }

        // --- Methods ---

        public void WriteToFile(string directory, string filename, List<string> content)
        {
            if (String.IsNullOrEmpty(directory))
            {
                throw new ArgumentNullException(nameof(directory));
            }

            if (String.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException(nameof(filename));
            }
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            Logger.Trace($"WriteToFile() mit Directory '{directory}' und Filename '{filename}' gestartet");

            // if directory does not exist, create it
            if (!Directory.Exists(directory))
            {
                Logger.Trace($"Verzeichnis '{directory}' erstellen");

                try
                {
                    Directory.CreateDirectory(directory);
                }
                catch (UnauthorizedAccessException ex)
                {
                    Logger.Error(ex, $"???");
                    throw new UnauthorizedAccessException("???", ex);
                }
                catch (PathTooLongException ex)
                {
                    Logger.Error(ex, $"Pfad '{directory}' ist zu lang");
                    throw new PathTooLongException("Path '{directory}' is too long", ex);
                }
            }

            // create complete filename incl. path
            if (directory[^1] != Path.DirectorySeparatorChar)
            {
                directory += Path.DirectorySeparatorChar;
            }
            filename = directory + filename;

            StreamWriter writer;

            // open file
            try
            {
                Logger.Trace($"Datei '{filename}' erstellen bzw. öffnen");
                writer = new StreamWriter(filename, false);
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Error(ex, $"???");
                throw new UnauthorizedAccessException("???", ex);
            }
            catch (PathTooLongException ex)
            {
                Logger.Error(ex, $"Pfad '{filename}' ist zu lang");
                throw new PathTooLongException("Path '{directory}' is too long", ex);
            }

            // write content
            foreach (String item in content)
            {
                writer.WriteLine(item);
            }

            // close file
            writer.Close();

            Logger.Trace($"WriteToFile() mit Directory '{directory}' und Filename '{filename}' beendet");
        }
    }
}
