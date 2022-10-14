// WikiPageCreator.exe: Creates pages for use with a wiki from the
// EntertainmentInfothek.db using EntertainmentDB.dll
// Copyright (C) 2022 Sandra Scherer

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
    /// Provides a content creator for a genre
    /// </summary>
    public class GenreContentCreator : EntryContentCreator
    {
        // --- Properties ---

        /// <summary>
        /// The list of genre items to be used to create the content.
        /// </summary>
        public List<GenreItem> Genres { get; set; }

        /// <summary>
        /// The logger to log everything.
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // --- Constructors ---

        /// <summary>
        /// Initializes a new GenreContentCreator.
        /// </summary>
        /// <param name="genres">The list of genre items to be used to create content.</param>
        /// <param name="formatter">The formatter to be used to format the content</param>
        /// <param name="targetLanguageCode">The language code for the created content.</param>
        /// <exception cref="ArgumentNullException">Thrown when one the given parameters is null.</exception>
        public GenreContentCreator(List<GenreItem> genres, Formatter formatter, string targetLanguageCode)
            : base(genres[0].Genre, formatter, targetLanguageCode)
        {
            Logger.Trace($"GenreContentCreator()");

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

            Genres = genres;

            Logger.Trace($"GenreContentCreator(): GenreContentCreator created");
        }

        // --- Methods ---

        /// <summary>
        /// Creates the infobox content of a given genre.
        /// </summary>
        /// <returns>Teh formatted content of the genre.</returns>
        public override List<string> CreateInfoBoxContent()
        {
            return CreateInfoBoxContentInternal();
        }

        /// <summary>
        /// Creates the infobox content of a given list of genres.
        /// </summary>
        /// <returns>The formatted content of the list of genres.</returns>
        protected override List<string> CreateInfoBoxContentInternal()
        {
            Logger.Trace($"CreateInfoBoxContentInternal()");

            List<string> content = new List<string>();
            string[] path = { TargetLanguageCode, "info" };

            if ((Genres != null) && (Genres.Count > 0))
            {
                Logger.Debug($"Genres is not null");
                Logger.Debug($"no of genres: '{Genres.Count}'");

                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"Genre: '{Genres[0].Genre.EnglishTitle}' (english)");

                    CreateInfoBoxContentHelper(content, "Genre", path, Genres[0].Genre.EnglishTitle, Genres[0].Genre.EnglishTitle, Genres[0].Details);

                    for (int i = 1; i < Genres.Count; i++)
                    {
                        Logger.Debug($"Genre: '{Genres[i].Genre.EnglishTitle}' (english)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), path, Genres[i].Genre.EnglishTitle, Genres[i].Genre.EnglishTitle, Genres[i].Details);
                    }
                }
                else // incl. case "de"
                {
                    Logger.Debug($"Genre: '{Genres[0].Genre.GermanTitle}' (german, ...)");

                    CreateInfoBoxContentHelper(content, "Genre", path, Genres[0].Genre.EnglishTitle, Genres[0].Genre.GermanTitle, Genres[0].Details);

                    for (int i = 1; i < Genres.Count; i++)
                    {
                        Logger.Debug($"Genre: '{Genres[i].Genre.GermanTitle}' (german, ...)");

                        CreateInfoBoxContentHelper(content, Formatter.CellSpanVertically(), path, Genres[i].Genre.EnglishTitle, Genres[i].Genre.GermanTitle, Genres[i].Details);
                    }
                }
            }
            Logger.Trace($"CreateInfoBoxContentInternal(): infobox content for List of Genres with Count '{Genres.Count}' created");

            return content;
        }

        /// <summary>
        /// Creates the specific row of the infobox content.
        /// </summary>
        /// <param name="content">The list that contains the content of the infobox.</param>
        /// <param name="title">The title for the row.</param>
        /// <param name="path">The path for the link.</param>
        /// <param name="pagename">The pagename for the link.</param>
        /// <param name="text">The text to be displayed for the link.</param>
        /// <param name="additionalInfo">Additional info to be displayed after the link.</param>
        private void CreateInfoBoxContentHelper(List<string> content, string title, string[] path, string pagename, string text, string additionalInfo)
        {
            string[] data = new string[2];

            data[0] = title;
            if (!String.IsNullOrEmpty(additionalInfo))
            {
                data[1] = $"{Formatter.AsInternalLink(path, pagename, text)} {additionalInfo}";
            }
            else
            {
                data[1] = $"{Formatter.AsInternalLink(path, pagename, text)}";
            }
            content.Add(Formatter.AsTableRow(data));
        }
    }
}
