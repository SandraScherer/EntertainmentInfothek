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
    /// Provides a content creator for a camera.
    /// </summary>
    public class CameraContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The list of camera items to be used to create the content.
        /// </summary>
        public List<CameraItem> Cameras { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new CameraContentCreator.
        /// </summary>
        /// <param name="cameras">The list of camera items to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public CameraContentCreator(List<CameraItem> cameras, Formatter formatter, string targetLanguageCode)
            : base(cameras[0].Camera, formatter, targetLanguageCode)
        {
            Logger.Trace($"CameraContentCreator()");

            Cameras = cameras;
            Headings = new Dictionary<string, string>
            {
                { "en", "Camera" },
                { "de", "Kamera" }
            };

            Logger.Trace($"CameraContentCreator(): CameraContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the infobox content of a given list of cameras.
        /// </summary>
        /// <returns>The formatted content of the list of cameras.</returns>
        public override List<string> CreateInfoBoxContent()
        {
            Logger.Trace($"CreateInfoBoxContent()");

            List<string> content = new List<string>();

            if ((Cameras != null) && (Cameras.Count > 0))
            {
                Logger.Debug($"Cameras is not null");
                Logger.Debug($"no of cameras: '{Cameras.Count}'");

                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"Camera: '{Cameras[0].Camera.Name}, {Cameras[0].Camera.Lenses}' (english)");

                    CreateInfoBoxContentHelper(content, Headings["en"], $"{Cameras[0].Camera.Name}, {Cameras[0].Camera.Lenses}", Cameras[0].Details);

                    for (int i = 1; i < Cameras.Count; i++)
                    {
                        Logger.Debug($"Camera: '{Cameras[i].Camera.Name}, {Cameras[i].Camera.Lenses}' (english)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), $"{Cameras[i].Camera.Name}, {Cameras[i].Camera.Lenses}", Cameras[i].Details);
                    }
                }
                else // incl. case "de"
                {
                    Logger.Debug($"Camera: '{Cameras[0].Camera.Name}, {Cameras[0].Camera.Lenses}' (german, ...)");

                    CreateInfoBoxContentHelper(content, Headings["de"], $"{Cameras[0].Camera.Name}, {Cameras[0].Camera.Lenses}", Cameras[0].Details);

                    for (int i = 1; i < Cameras.Count; i++)
                    {
                        Logger.Debug($"Camera: '{Cameras[i].Camera.Name}, {Cameras[i].Camera.Lenses}' (german, ...)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), $"{Cameras[i].Camera.Name}, {Cameras[i].Camera.Lenses}", Cameras[i].Details);
                    }
                }
            }
            Logger.Trace($"CreateInfoBoxContent(): infobox content for the list of Cameras with count '{Cameras.Count}' created");

            return content;
        }
    }
}
