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
using System.Text;
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

            if (genres == null)
            {
                Logger.Fatal($"List<GenreItem> not specified");
                throw new ArgumentNullException(nameof(genres));
            }
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
            string[] data = new string[2];
            string[] path = { TargetLanguageCode, "info" };

            if ((Genres != null) && (Genres.Count > 0))
            {
                Logger.Debug($"Genres is not null");
                Logger.Debug($"no of genres: '{Genres.Count}'");

                if (TargetLanguageCode.Equals("en"))
                {
                    Logger.Debug($"Genre: '{Genres[0].Genre.EnglishTitle}' (english)");

                    data[0] = "Genre";
                    if (!String.IsNullOrEmpty(Genres[0].Details))
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Genres[0].Genre.EnglishTitle, Genres[0].Genre.EnglishTitle)} {Genres[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Genres[0].Genre.EnglishTitle, Genres[0].Genre.EnglishTitle)}";
                    }
                    content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Genres.Count; i++)
                    {
                        Logger.Debug($"Genre: '{Genres[i].Genre.EnglishTitle}' (english)");

                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Genres[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Genres[i].Genre.EnglishTitle, Genres[i].Genre.EnglishTitle)} {Genres[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Genres[i].Genre.EnglishTitle, Genres[i].Genre.EnglishTitle)}";
                        }
                        content.Add(Formatter.AsTableRow(data));
                    }
                }
                else // incl. case "de"
                {
                    Logger.Debug($"Genre: '{Genres[0].Genre.GermanTitle}' (german, ...)");

                    data[0] = "Genre";
                    if (!String.IsNullOrEmpty(Genres[0].Details))
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Genres[0].Genre.EnglishTitle, Genres[0].Genre.GermanTitle)} {Genres[0].Details}";
                    }
                    else
                    {
                        data[1] = $"{Formatter.AsInternalLink(path, Genres[0].Genre.EnglishTitle, Genres[0].Genre.GermanTitle)}";
                    }
                    content.Add(Formatter.AsTableRow(data));

                    for (int i = 1; i < Genres.Count; i++)
                    {
                        Logger.Debug($"Genre: '{Genres[i].Genre.GermanTitle}' (german, ...)");

                        data[0] = Formatter.CellSpanVertically();
                        if (!String.IsNullOrEmpty(Genres[i].Details))
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Genres[i].Genre.EnglishTitle, Genres[i].Genre.GermanTitle)} {Genres[i].Details}";
                        }
                        else
                        {
                            data[1] = $"{Formatter.AsInternalLink(path, Genres[i].Genre.EnglishTitle, Genres[i].Genre.GermanTitle)}";
                        }
                        content.Add(Formatter.AsTableRow(data));
                    }
                }
            }
            Logger.Trace($"CreateInfoBoxContentInternal(): infobox content for List of Genres with Count '{Genres.Count}' created");

            return content;
        }
    }
}
