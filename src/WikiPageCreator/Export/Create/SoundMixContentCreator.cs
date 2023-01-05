﻿// WikiPageCreator.exe: Creates pages for use with a wiki from the
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
    /// Provides a content creator for a sound mix.
    /// </summary>
    public class SoundMixContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The list of sound mix items to be used to create the content.
        /// </summary>
        public List<SoundMixItem> SoundMixes { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new SoundMixContentCreator.
        /// </summary>
        /// <param name="soundmixes">The list of sound mix items to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content.</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>

        public SoundMixContentCreator(List<SoundMixItem> soundmixes, Formatter formatter, string targetLanguageCode)
            : base(soundmixes[0].SoundMix, formatter, targetLanguageCode)
        {
            Logger.Trace($"SoundMixContentCreator()");

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

            SoundMixes = soundmixes;

            Logger.Trace($"SoundMixContentCreator(): SoundMixContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the infobox content of a given sound mix.
        /// </summary>
        /// <returns>The formatted content of the sound mix.</returns>
        public override List<string> CreateInfoBoxContent()
        {
            return CreateInfoBoxContentInternal();
        }

        /// <summary>
        /// Creates the infobox content of a given list of sound mixes.
        /// </summary>
        /// <returns>The formatted content of the list of sound mixes.</returns>
        protected override List<string> CreateInfoBoxContentInternal()
        {
            Logger.Trace($"CreateInfoBoxContentInternal()");

            List<string> content = new List<string>();
            string[] path = { TargetLanguageCode, "info" };

            if ((SoundMixes != null) && (SoundMixes.Count > 0))
            {
                Logger.Debug($"SoundMixes is not null");
                Logger.Debug($"no of sound mixes: '{SoundMixes.Count}'");

                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"SoundMix: '{SoundMixes[0].SoundMix.EnglishTitle}' (english)");

                    CreateInfoBoxContentHelper(content, "SoundMix", path, SoundMixes[0].SoundMix.EnglishTitle, SoundMixes[0].SoundMix.EnglishTitle, SoundMixes[0].Details);

                    for (int i = 1; i < SoundMixes.Count; i++)
                    {
                        Logger.Debug($"SoundMix: '{SoundMixes[i].SoundMix.EnglishTitle}' (english)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), path, SoundMixes[i].SoundMix.EnglishTitle, SoundMixes[i].SoundMix.EnglishTitle, SoundMixes[i].Details);
                    }
                }
                else // incl. case "de"
                {
                    Logger.Debug($"Tonmischung: '{SoundMixes[0].SoundMix.GermanTitle}' (german, ...)");

                    CreateInfoBoxContentHelper(content, "Tonmischung", path, SoundMixes[0].SoundMix.EnglishTitle, SoundMixes[0].SoundMix.GermanTitle, SoundMixes[0].Details);

                    for (int i = 1; i < SoundMixes.Count; i++)
                    {
                        Logger.Debug($"Tonmischung: '{SoundMixes[i].SoundMix.GermanTitle}' (german, ...)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), path, SoundMixes[i].SoundMix.EnglishTitle, SoundMixes[i].SoundMix.GermanTitle, SoundMixes[i].Details);
                    }
                }
            }
            Logger.Trace($"CreateInfoBoxContentInternal(): infobox content for List of SoundMixes with Count '{SoundMixes.Count}' created");

            return content;
        }
    }
}
