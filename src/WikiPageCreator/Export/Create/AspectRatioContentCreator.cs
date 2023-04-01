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
    /// Provides a content creator for a aspect ratio.
    /// </summary>
    public class AspectRatioContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The list of aspect ratio items to be used to create the content.
        /// </summary>
        public List<AspectRatioItem> AspectRatios { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new AspectRatioContentCreator.
        /// </summary>
        /// <param name="aspectratios">The list of aspect ratio items to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public AspectRatioContentCreator(List<AspectRatioItem> aspectratios, Formatter formatter, string targetLanguageCode)
            : base(aspectratios[0].AspectRatio, formatter, targetLanguageCode)
        {
            Logger.Trace($"AspectRatioContentCreator()");

            if (formatter == null)
            {
                Logger.Fatal($"Formatter not specified");
                throw new ArgumentNullException(nameof(formatter));
            }
            if (String.IsNullOrEmpty(targetLanguageCode))
            {
                Logger.Fatal($"TargetLanguageCode not specified");
                throw new ArgumentNullException(nameof(targetLanguageCode));
            }

            AspectRatios = aspectratios;
            Headings = new Dictionary<string, string>
            {
                { "en", "Aspect Ratio" },
                { "de", "Bildformat" }
            };

            Logger.Trace($"AspectRatioContentCreator(): AspectRatioContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the infobox content of a given aspect ratio.
        /// </summary>
        /// <returns>The formatted content of the aspect ratio.</returns>
        public override List<string> CreateInfoBoxContent()
        {
            return CreateInfoBoxContentInternal();
        }

        /// <summary>
        /// Creates the infobox content of a given list of aspect ratios.
        /// </summary>
        /// <returns>The formatted content of the list of aspect ratios.</returns>
        protected override List<string> CreateInfoBoxContentInternal()
        {
            Logger.Trace($"CreateInfoBoxContentInternal()");

            List<string> content = new List<string>();

            if ((AspectRatios != null) && (AspectRatios.Count > 0))
            {
                Logger.Debug($"AspectRatios is not null");
                Logger.Debug($"no of aspect ratios: '{AspectRatios.Count}'");

                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"AspectRatio: '{AspectRatios[0].AspectRatio.Ratio}' (english)");

                    CreateInfoBoxContentHelper(content, Headings["en"], AspectRatios[0].AspectRatio.Ratio, AspectRatios[0].Details);

                    for (int i = 1; i < AspectRatios.Count; i++)
                    {
                        Logger.Debug($"AspectRatio: '{AspectRatios[i].AspectRatio.Ratio}' (english)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), AspectRatios[i].AspectRatio.Ratio, AspectRatios[i].Details);
                    }
                }
                else // incl. case "de"
                {
                    Logger.Debug($"AspectRatio: '{AspectRatios[0].AspectRatio.Ratio}' (german, ...)");

                    CreateInfoBoxContentHelper(content, Headings["de"], AspectRatios[0].AspectRatio.Ratio, AspectRatios[0].Details);

                    for (int i = 1; i < AspectRatios.Count; i++)
                    {
                        Logger.Debug($"AspectRatio: '{AspectRatios[i].AspectRatio.Ratio}' (german, ...)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), AspectRatios[i].AspectRatio.Ratio, AspectRatios[i].Details);
                    }
                }
            }
            Logger.Trace($"CreateInfoBoxContentInternal(): infobox content for List of AspectRatios with Count '{AspectRatios.Count}' created");

            return content;
        }
    }
}
