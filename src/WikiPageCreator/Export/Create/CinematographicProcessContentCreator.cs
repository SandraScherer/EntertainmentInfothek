// WikiPageCreator.exe: Creates pages for use with a wiki from the
// EntertainmentInfothek.db using EntertainmentDB.dll
// Copyright (C) 2023 Sandra Scherer

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
using System;
using System.Collections.Generic;
using WikiPageCreator.Export.Format;

namespace WikiPageCreator.Export.Create
{
    /// <summary>
    /// Provides a content creator for a cinematographic process.
    /// </summary>
    public class CinematographicProcessContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The list of cinematographic process items to be used to create the content.
        /// </summary>
        public List<CinematographicProcessItem> CinematographicProcesses { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new CinematographicProcessContentCreator.
        /// </summary>
        /// <param name="cinematographicProcesses">The list of cinematographic process items to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public CinematographicProcessContentCreator(List<CinematographicProcessItem> cinematographicProcesses, Formatter formatter, string targetLanguageCode)
            : base(cinematographicProcesses[0].CinematographicProcess, formatter, targetLanguageCode)
        {
            Logger.Trace($"CinematographicProcessContentCreator()");

            CinematographicProcesses = cinematographicProcesses;
            Headings = new Dictionary<string, string>
            {
                { "en", "Cinematographic Process" },
                { "de", "Filmprozess" }
            };

            Logger.Trace($"CinematographicProcessContentCreator(): CinematographicProcessContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the infobox content of a given list of cinematographic processes.
        /// </summary>
        /// <returns>The formatted content of the list of cinematographic processes.</returns>
        public override List<string> CreateInfoBoxContent()
        {
            Logger.Trace($"CreateInfoBoxContent()");

            List<string> content = new List<string>();
            string[] path = { TargetLanguageCode, Path.Info.ToString().ToLower() };

            if ((CinematographicProcesses != null) && (CinematographicProcesses.Count > 0))
            {
                Logger.Debug($"CinematographicProcesss is not null");
                Logger.Debug($"no of cinematographic processes: '{CinematographicProcesses.Count}'");

                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"CinematographicProcess: '{CinematographicProcesses[0].CinematographicProcess.Name}' (english)");

                    CreateInfoBoxContentHelper(content, Headings["en"], path, CinematographicProcesses[0].CinematographicProcess.Name, CinematographicProcesses[0].CinematographicProcess.Name, CinematographicProcesses[0].Details);

                    for (int i = 1; i < CinematographicProcesses.Count; i++)
                    {
                        Logger.Debug($"CinematographicProcess: '{CinematographicProcesses[i].CinematographicProcess.Name}' (english)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), path, CinematographicProcesses[i].CinematographicProcess.Name, CinematographicProcesses[i].CinematographicProcess.Name, CinematographicProcesses[i].Details);
                    }
                }
                else // incl. case "de"
                {
                    Logger.Debug($"CinematographicProcess: '{CinematographicProcesses[0].CinematographicProcess.Name}' (german, ...)");

                    CreateInfoBoxContentHelper(content, Headings["de"], path, CinematographicProcesses[0].CinematographicProcess.Name, CinematographicProcesses[0].CinematographicProcess.Name, CinematographicProcesses[0].Details);

                    for (int i = 1; i < CinematographicProcesses.Count; i++)
                    {
                        Logger.Debug($"CinematographicProcess: '{CinematographicProcesses[i].CinematographicProcess.Name}' (german, ...)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), path, CinematographicProcesses[i].CinematographicProcess.Name, CinematographicProcesses[i].CinematographicProcess.Name, CinematographicProcesses[i].Details);
                    }
                }
            }
            Logger.Trace($"CreateInfoBoxContent(): infobox content for the list of CinematographicProcesses with count '{CinematographicProcesses.Count}' created");

            return content;
        }
    }
}
